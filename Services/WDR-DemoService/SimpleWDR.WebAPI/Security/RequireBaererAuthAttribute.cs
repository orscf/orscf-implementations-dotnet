using Jose;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Data.AccessControl;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security {

  [AttributeUsage(validOn: AttributeTargets.Method)]
  public class RequireBaererAuthAttribute : Attribute, IAsyncActionFilter {

    private string[] _RequiredPermissions;

    public RequireBaererAuthAttribute(params string[] requiredExplicitPermissions) {
      _RequiredPermissions = requiredExplicitPermissions;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {

      if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var extractedAuthHeader)) {
        context.Result = new ContentResult() {
          StatusCode = 401,
          Content = "'Authorization'-Header was not provided"
        };
        return;
      }

      string bearerToken = extractedAuthHeader.ToString();
      if (bearerToken.StartsWith("bearer ")) {
        bearerToken = bearerToken.Substring(7);
      }

      BearerContent bearerContent = null;
      try {
        byte[] jwtSignKeyBytes = Encoding.ASCII.GetBytes(AccessSettings.Current.JwtSignKey);
        bearerContent = JWT.Decode<BearerContent>(bearerToken, jwtSignKeyBytes);
      }
      catch (Exception ex) {
        context.Result = new ContentResult() {
          StatusCode = 401,
          Content = "'Authorization'-Header contains an invlaid bearer token (signature)!"
        };
        return;
      }

      if (AccessSettings.Current.JwtAllowedIssuers != null && !AccessSettings.Current.JwtAllowedIssuers.Contains("*")) {
        if (!AccessSettings.Current.JwtAllowedIssuers.Contains(bearerContent.iss)) {
          context.Result = new ContentResult() {
            StatusCode = 401,
            Content = "'Authorization'-Header contains an invlaid bearer token (invalid issuer)!"
          };
          return;
        }
      }

      var expirationTimeUtc = new DateTime(1970, 01, 01, 0, 0, 0, DateTimeKind.Utc).AddSeconds(bearerContent.exp);
      if (DateTime.UtcNow > expirationTimeUtc) {
        context.Result = new ContentResult() {
          StatusCode = 401,
          Content = "'Authorization'-Header contains an invlaid bearer token (expired)!"
        };
        return;
      }

      string subjectName = bearerContent.sub;
      SubjectProfileConfigurationEntry profile = AccessSettings.Current.SubjectProfiles.Where(e => e.SubjectName.Equals(subjectName, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();

      if (profile == null) {
        //fallback
        profile = AccessSettings.Current.SubjectProfiles.Where(e => e.SubjectName == "*").SingleOrDefault();
      }

      if (profile == null) {
        context.Result = new ContentResult() {
          StatusCode = 401,
          Content = "unknown subject!"
        };
        return;
      }

      //TODO: *-auflösung via regex!!!!!!!!!!
      if (profile.AllowedHosts != null && !profile.AllowedHosts.Contains("*")) {
        if (!profile.AllowedHosts.Contains(context.HttpContext.Request.Host.Host.ToLower())) {
          context.Result = new ContentResult() {
            StatusCode = 401,
            Content = "access denied by firewall rules"
          };
          return;
        }
      }

      if (profile.Disabled) {
        context.Result = new ContentResult() {
          StatusCode = 401,
          Content = "subject is blocked!"
        };
        return;
      }

      using (var mac = new AccessControlContext()) {

        mac.AddPermissions(profile.Permissions);
        mac.AddDeniedPermissions(profile.DenyPermissions);

        mac.AddClearances(new {
          Institute = profile.ScopeToExecutingInstituteIdentifier,
          Study = profile.ScopeToStudyIdentifier,
        });

        if (_RequiredPermissions.Length > 0) {
          foreach (string requiredPermission in _RequiredPermissions) {
            if (!mac.HasEffectivePermission(requiredPermission)) {
              context.Result = new ContentResult() {
                StatusCode = 401,
                Content = "permission denied for this operation"
              };
              return;
            }
          }
        }

        await next();

      }
    }
  }

  internal class BearerContent {

    /// <summary> issuer </summary>
    public String iss { get; set; } = string.Empty;

    /// <summary> subject </summary>
    public String sub { get; set; } = string.Empty;

    /// <summary> expires (unix-epoch utc) </summary>
    public int exp { get; set; } = 0;

  }

}