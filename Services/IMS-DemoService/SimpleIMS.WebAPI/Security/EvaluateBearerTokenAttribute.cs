using Jose;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Data.AccessControl;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security {

  [AttributeUsage(validOn: AttributeTargets.Method)]
  public class EvaluateBearerTokenAttribute : Attribute, IAsyncActionFilter {

    private string[] _RequiredApiPermissions;
    private bool _RequireValidToken;

    public EvaluateBearerTokenAttribute(params string[] requiredApiPermissions) {
      _RequireValidToken = true;
      _RequiredApiPermissions = requiredApiPermissions;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
      int authStateCode = 1;
      string publicErrorMessage = "UNAUTHORIZED";
      AccessSettings settings = AccessSettings.Current;
      JwtContent jwtContent = null;
      SubjectProfileConfigurationEntry profile = null;

      //evaluate, if we have a token
      if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var extractedAuthHeader)) {
        publicErrorMessage = "'Authorization'-Header was not provided";
        authStateCode = 0;
      }

      //if we have not failed until here -> DECODE the Token
      if (authStateCode == 1) {

        //TODO: das hier splitten - hier erstmal nur payload und anhand des payloads dann einen issuer-spezifischen singnkey laden!!!

        string rawJwt = extractedAuthHeader.ToString();
        if (rawJwt.StartsWith("bearer ")) {
          rawJwt = rawJwt.Substring(7);
        }
        try {
          byte[] jwtSignKeyBytes = Encoding.ASCII.GetBytes(settings.JwtSignKey);
          jwtContent = JWT.Decode<JwtContent>(rawJwt, jwtSignKeyBytes);
        }
        catch {
          publicErrorMessage = "'Authorization'-Header contains an invalid bearer token (decode failure)!";
          authStateCode = -2;
        }
      }

      //if we have not failed until here -> DECODE the Token
      if (authStateCode == 1) {
        var expirationTimeUtc = new DateTime(1970, 01, 01, 0, 0, 0, DateTimeKind.Utc).AddSeconds(jwtContent.exp);
        if (DateTime.UtcNow > expirationTimeUtc) {
          publicErrorMessage = "'Authorization'-Header contains an invalid bearer token (expired)!";
          authStateCode = -1;
        }
      }

      //if we have not failed until here -> validate the ISSUER
      if (authStateCode == 1) {
        if (settings.JwtAllowedIssuers != null && !settings.JwtAllowedIssuers.Contains("*")) {
          if (!settings.JwtAllowedIssuers.Contains(jwtContent.iss)) {
            publicErrorMessage = "'Authorization'-Header contains an invalid bearer token (invalid issuer)!";
            authStateCode = -2;
          }
        }
      }

      //TODO: hier mit einem issuer-spezifischen signkey valisieren

      //if we have not failed until here -> validate the SUBJECT (try to find corr. profile)
      if (authStateCode == 1) {
        string subjectName = jwtContent.sub;
        profile = settings.SubjectProfiles.Where(e => e.SubjectName.Equals(subjectName, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();
        if (profile == null) {
          //fallback
          profile = settings.SubjectProfiles.Where(e => e.SubjectName == "(generic)").SingleOrDefault();
        }
        if (profile == null) {
          publicErrorMessage = "'Authorization'-Header contains an invalid bearer token (unknown subject)!";
          authStateCode = -2;
        }
        else if (profile.Disabled) {
          publicErrorMessage = "subject is blocked!";
          authStateCode = -2;
          profile = null;
        }
      }

      if (profile == null) {
        //this will be loaded for not-authenticated requests (if existing)
        profile = settings.SubjectProfiles.Where(e => e.SubjectName == "(public)").SingleOrDefault();
        if (profile != null && profile.Disabled) {
          profile = null;
        }
      }

      //evaluate the optional Firewall-Rules (can only be done after a profile was assigned...)
      if (profile != null && profile.AllowedHosts != null && !profile.AllowedHosts.Contains("*")) {
        HostString apiCaller = context.HttpContext.Request.Host;

        //TODO: *-resolving via regex!!!!!!!!!! + fallback for DNS-names to IP!!!
        if (!profile.AllowedHosts.Contains(apiCaller.Host.ToLower())) {
          context.Result = new ContentResult() {
            StatusCode = 401,
            Content = "access denied by firewall rules"
          };
          return;
        }
      }

      //note: <0 is correct because that are errors regarding an exisiting jwt!
      //0 means that there was just no token, which could be ok when there is a '(public)' profile
      //(further evaluations will be done below just based on the 
      //permissions which are defined by the ressolved profile)
      if (authStateCode < 0) {
        if (_RequireValidToken) { 
          context.Result = new ContentResult() {
            StatusCode = 401,
            Content = publicErrorMessage //token error details
          };
          return;
        }
       }

      using (var mac = new AccessControlContext()) {
        mac.SetAuthStateCode(authStateCode);

        if (profile == null) { 
          mac.SetAccessorName("(not authenticated)");
        }
        else {
          mac.SetAccessorName(profile.SubjectName);
          //import permissions/clearances from profile
          if (profile.DefaultApiPermissions != null) {
            mac.AddPermissions(profile.DefaultApiPermissions);
          }
          if(profile.DefaultDataAccessClearances != null) {
            foreach (string dimensionName in profile.DefaultDataAccessClearances.Keys) {
              string[] values = profile.DefaultDataAccessClearances[dimensionName].Split(',').Select(t => t.Trim()).Where(t => !string.IsNullOrWhiteSpace(t)).ToArray();
              mac.AddClearances(dimensionName, values);
            }
          }
        }

        //if there is a VALID token and we are configured to import permissions/clearances from the JWT-scope field!
        if (authStateCode == 1 && jwtContent != null && settings.ApplyApiPermissionsFromJwtScope) {
          string[] jwtScopes;
          jwtContent.scp = jwtContent.scp.Replace(";",",");
          if (jwtContent.scp.Contains(",")) {
            jwtScopes = jwtContent.scp.Split(',').Select(t => t.Trim()).Where(t => !string.IsNullOrWhiteSpace(t)).ToArray();
          }
          else {
            jwtScopes = jwtContent.scp.Split(' ').Select(t => t.Trim()).Where(t => !string.IsNullOrWhiteSpace(t)).ToArray();
          }
          foreach (string jwtScope in jwtScopes) {
            if (jwtScope.Contains(":")) {
              var idx = jwtScope.IndexOf(':');
              var dimensionName = jwtScope.Substring(0, idx);
              var clearanceValue = jwtScope.Substring(idx+1);
              if(string.Equals (dimensionName ,"API", StringComparison.InvariantCultureIgnoreCase)) {
                mac.AddPermissions(clearanceValue);
              }
              else {
                mac.AddClearance(dimensionName, clearanceValue);
              }
            }
          }
        }

        bool missingPermission = false;
        if (_RequiredApiPermissions != null && _RequiredApiPermissions.Length > 0) {
          foreach (string requiredPermission in _RequiredApiPermissions) {
            if (!mac.HasEffectivePermission(requiredPermission)) {
              missingPermission = true;
              break;
            }
          }
        }

        if (missingPermission) {
          if (authStateCode == 0) {
            context.Result = new ContentResult() {
              StatusCode = 401,
              Content = "'Authorization'-Header is required for this operation!"
          };
            return;
          }
          else {
            context.Result = new ContentResult() {
              StatusCode = 401,
              Content = "PERMISSION DENIED for this operation!"
            };
            return;
          }
        }

        await next();
      }
    }
  }

  internal class JwtContent {

    /// <summary> issuer </summary>
    public String iss { get; set; } = string.Empty;

    /// <summary> subject </summary>
    public String sub { get; set; } = string.Empty;

    /// <summary> expires (unix-epoch utc) </summary>
    public long exp { get; set; } = 0;

    /// <summary> audience </summary>
    public String aud { get; set; } = string.Empty;

    /// <summary> scope </summary>
    public String scp { get; set; } = string.Empty;

  }

}