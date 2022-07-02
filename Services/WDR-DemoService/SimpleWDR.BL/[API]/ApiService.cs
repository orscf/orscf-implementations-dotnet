using System;
using System.Security;
using System.Data.AccessControl;
using System.Linq;
using Security;

namespace MedicalResearch.Workflow {

  public partial class ApiService : IWdrApiInfoService {

    private static Version _Version = typeof(IWdrApiInfoService).Assembly.GetName().Version;
    private string _OAuthTokenRequestUrl = "";

    public ApiService(string oAuthTokenRequestUrl,string publicServiceUrl, string subscriptionStorageDirectory) {
      _OAuthTokenRequestUrl = oAuthTokenRequestUrl;
    }

    public string GetApiVersion() {
      return _Version.ToString(3);
    }

    public string[] GetCapabilities() {
      return new string[] {
        WdrCapabilities.WorkflowConsume,
        WdrCapabilities.WorkflowSubmission,
        WdrCapabilities.FhirQuestionaireConsume,
        WdrCapabilities.FhirQuestionaireSubmission
      };
    }

    public string GetOAuthTokenRequestUrl() {
      return _OAuthTokenRequestUrl;
    }

    public string[] GetPermittedAuthScopes(out int authState) {
      var mac = AccessControlContext.Current;

      string[] scopes = mac.EffectivePermissions.Select(p => "API:" + p).Union(mac.ExportClearences()).ToArray();
      authState = mac.AuthStateCode;

      return scopes;
    }

  }

}
