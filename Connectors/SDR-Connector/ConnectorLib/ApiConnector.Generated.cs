using MedicalResearch.SubjectData.Model;
using MedicalResearch.SubjectData.SubjectParticipation;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MedicalResearch.SubjectData {
  
  public partial class SdrApiConnector {
    
    public SdrApiConnector(string url, string apiToken) {
      
      if (!url.EndsWith("/")) {
        url = url + "/";
      }
      
      _SubjectParticipationServiceClient = new SubjectParticipationServiceClient(url + "subjectParticipationService/", apiToken);
      
    }
    
    private SubjectParticipationServiceClient _SubjectParticipationServiceClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    public ISubjectParticipationService SubjectParticipationService {
      get {
        return _SubjectParticipationServiceClient;
      }
    }
    
  }
  
  namespace SubjectParticipation {
    
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    internal partial class SubjectParticipationServiceClient : ISubjectParticipationService {
      
      private string _Url;
      private string _ApiToken;
      
      public SubjectParticipationServiceClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> returns the Version of the API itself, which can be used for backward compatibility within inhomogeneous infrastructures </summary>
      public String GetApiVersion() {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getApiVersion";
          var args = new GetApiVersionRequest {
          };
          string rawRequest = JsonConvert.SerializeObject(args);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var result = JsonConvert.DeserializeObject<GetApiVersionResponse>(rawResponse);
          if(result.fault != null){
            throw new Exception(result.fault);
          }
          return result.@return;
        }
      }
      
      /// <summary> returns if the authenticated accessor of the API has the permission to use this service </summary>
      public Boolean HasAccess() {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "hasAccess";
          var args = new HasAccessRequest {
          };
          string rawRequest = JsonConvert.SerializeObject(args);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var result = JsonConvert.DeserializeObject<HasAccessResponse>(rawResponse);
          if(result.fault != null){
            throw new Exception(result.fault);
          }
          return result.@return;
        }
      }
      
    }
    
  }
  
}
