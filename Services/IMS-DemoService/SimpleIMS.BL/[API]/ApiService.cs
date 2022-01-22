using System;
using System.Data.AccessControl;
using System.Linq;

namespace MedicalResearch.IdentityManagement {

  public partial class ApiService : IImsApiInfoService {

    private static Version _Version = typeof(IImsApiInfoService).Assembly.GetName().Version;
    private string _OAuthTokenRequestUrl = "";

    public ApiService(string oAuthTokenRequestUrl) {
      _OAuthTokenRequestUrl = oAuthTokenRequestUrl;
    }

    public string GetApiVersion() {
      return _Version.ToString(3);
    }

    public string[] GetCapabilities() {
      return new string[] {
        ImsCapabilities.Pseudonymization
      };
    }

    public string GetOAuthTokenRequestUrl() {
      return _OAuthTokenRequestUrl;
    }

    public string[] GetPermittedAuthScopes(out int authState) {
      var mac = AccessControlContext.Current;

      string[] scopes =  mac.EffectivePermissions.Select(p => "API:" + p).Union(mac.ExportClearences()).ToArray();
      authState = mac.AuthStateCode;

      return scopes;
    }

  }

}
