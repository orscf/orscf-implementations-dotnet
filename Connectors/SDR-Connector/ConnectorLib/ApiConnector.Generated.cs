/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.SubjectData.Model;
using MedicalResearch.SubjectData.ParticipationStateMgmt;
using MedicalResearch.SubjectData.SdrApiInfo;
using MedicalResearch.SubjectData.SubjectEnrollment;
using MedicalResearch.SubjectData.SubjectOverview;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MedicalResearch.SubjectData {
  
  public partial class SdrApiConnector {
    
    public SdrApiConnector(string url, string apiToken) {
      
      if (!url.EndsWith("/")) {
        url = url + "/";
      }
      
      _SdrApiInfoServiceClient = new SdrApiInfoServiceClient(url + "sdrApiInfoService/", apiToken);
      _ParticipationStateMgmtServiceClient = new ParticipationStateMgmtServiceClient(url + "participationStateMgmtService/", apiToken);
      _SubjectEnrollmentServiceClient = new SubjectEnrollmentServiceClient(url + "subjectEnrollmentService/", apiToken);
      _SubjectOverviewServiceClient = new SubjectOverviewServiceClient(url + "subjectOverviewService/", apiToken);
      
    }
    
    private SdrApiInfoServiceClient _SdrApiInfoServiceClient = null;
    /// <summary> Provides interoperability information for the current implementation </summary>
    public ISdrApiInfoService SdrApiInfoService {
      get {
        return _SdrApiInfoServiceClient;
      }
    }
    
    private ParticipationStateMgmtServiceClient _ParticipationStateMgmtServiceClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'SubjectDataRepository' (SDR) </summary>
    public IParticipationStateMgmtService ParticipationStateMgmtService {
      get {
        return _ParticipationStateMgmtServiceClient;
      }
    }
    
    private SubjectEnrollmentServiceClient _SubjectEnrollmentServiceClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'SubjectDataRepository' (SDR) </summary>
    public ISubjectEnrollmentService SubjectEnrollmentService {
      get {
        return _SubjectEnrollmentServiceClient;
      }
    }
    
    private SubjectOverviewServiceClient _SubjectOverviewServiceClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'SubjectDataRepository' (SDR) </summary>
    public ISubjectOverviewService SubjectOverviewService {
      get {
        return _SubjectOverviewServiceClient;
      }
    }
    
  }
  
  namespace SdrApiInfo {
    
    /// <summary> Provides interoperability information for the current implementation </summary>
    internal partial class SdrApiInfoServiceClient : ISdrApiInfoService {
      
      private string _Url;
      private string _ApiToken;
      
      public SdrApiInfoServiceClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> returns the version of the ORSCF specification which is implemented by this API, (this can be used for backward compatibility within inhomogeneous infrastructures) </summary>
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
      
      /// <summary> returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'SubjectOverview', 'SubjectEnrollment', 'ParticipationStateMgmt' </summary>
      public String[] GetCapabilities() {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getCapabilities";
          var args = new GetCapabilitiesRequest {
          };
          string rawRequest = JsonConvert.SerializeObject(args);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var result = JsonConvert.DeserializeObject<GetCapabilitiesResponse>(rawResponse);
          if(result.fault != null){
            throw new Exception(result.fault);
          }
          return result.@return;
        }
      }
      
      /// <summary> returns a list of available capabilities ("API:SubjectOverview") and/or data-scopes ("Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72") which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be: 0=auth needed / 1=authenticated / -1=auth expired / -2=auth invalid/disabled </summary>
      /// <param name="authState">  </param>
      public String[] GetPermittedAuthScopes(out Int32 authState) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getPermittedAuthScopes";
          var args = new GetPermittedAuthScopesRequest {
          };
          string rawRequest = JsonConvert.SerializeObject(args);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var result = JsonConvert.DeserializeObject<GetPermittedAuthScopesResponse>(rawResponse);
          authState = result.authState;
          if(result.fault != null){
            throw new Exception(result.fault);
          }
          return result.@return;
        }
      }
      
      /// <summary> OPTIONAL: If the authentication on the current service is mapped using tokens and should provide information about the source at this point, the login URL to be called up via browser (OAuth <see href="https://openid.net/specs/openid-client-initiated-backchannel-authentication-core-1_0.html">'CIBA-Flow'</see>) is returned here. </summary>
      public String GetOAuthTokenRequestUrl() {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getOAuthTokenRequestUrl";
          var args = new GetOAuthTokenRequestUrlRequest {
          };
          string rawRequest = JsonConvert.SerializeObject(args);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var result = JsonConvert.DeserializeObject<GetOAuthTokenRequestUrlResponse>(rawResponse);
          if(result.fault != null){
            throw new Exception(result.fault);
          }
          return result.@return;
        }
      }
      
    }
    
  }
  
  namespace ParticipationStateMgmt {
    
    /// <summary> Provides an workflow-level API for interating with a 'SubjectDataRepository' (SDR) </summary>
    internal partial class ParticipationStateMgmtServiceClient : IParticipationStateMgmtService {
      
      private string _Url;
      private string _ApiToken;
      
      public ParticipationStateMgmtServiceClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
    }
    
  }
  
  namespace SubjectEnrollment {
    
    /// <summary> Provides an workflow-level API for interating with a 'SubjectDataRepository' (SDR) </summary>
    internal partial class SubjectEnrollmentServiceClient : ISubjectEnrollmentService {
      
      private string _Url;
      private string _ApiToken;
      
      public SubjectEnrollmentServiceClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> returns the null on failure or the assigned SubjectIdentifier on success </summary>
      /// <param name="researchStudyName">  </param>
      /// <param name="siteName">  </param>
      /// <param name="dateOfEnrollment">  </param>
      /// <param name="details">  </param>
      /// <param name="preDefinedSubjectId">  </param>
      public String EnrollIdentityAsSubject(string researchStudyName, string siteName, DateTime dateOfEnrollment, IdentityDetails details, string preDefinedSubjectId = null) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "enrollIdentityAsSubject";
          var args = new EnrollIdentityAsSubjectRequest {
            researchStudyName = researchStudyName,
            siteName = siteName,
            dateOfEnrollment = dateOfEnrollment,
            details = details,
            preDefinedSubjectId = preDefinedSubjectId
          };
          string rawRequest = JsonConvert.SerializeObject(args);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var result = JsonConvert.DeserializeObject<EnrollIdentityAsSubjectResponse>(rawResponse);
          if(result.fault != null){
            throw new Exception(result.fault);
          }
          return result.@return;
        }
      }
      
      /// <summary> UpdateIdentityInformationBySubjectId </summary>
      /// <param name="researchStudyName">  </param>
      /// <param name="subjectId">  </param>
      /// <param name="newDetails">  </param>
      /// <param name="clearUnsuppliedValues">  </param>
      /// <param name="newSiteName">  </param>
      public Boolean UpdateIdentityInformationBySubjectId(string researchStudyName, string subjectId, IdentityDetails newDetails, bool clearUnsuppliedValues = false, string newSiteName = null) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "updateIdentityInformationBySubjectId";
          var args = new UpdateIdentityInformationBySubjectIdRequest {
            researchStudyName = researchStudyName,
            subjectId = subjectId,
            newDetails = newDetails,
            clearUnsuppliedValues = clearUnsuppliedValues,
            newSiteName = newSiteName
          };
          string rawRequest = JsonConvert.SerializeObject(args);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var result = JsonConvert.DeserializeObject<UpdateIdentityInformationBySubjectIdResponse>(rawResponse);
          if(result.fault != null){
            throw new Exception(result.fault);
          }
          return result.@return;
        }
      }
      
      /// <summary> GetSiteNameBySubjectId </summary>
      /// <param name="researchStudyName">  </param>
      /// <param name="subjectId">  </param>
      public String GetSiteNameBySubjectId(string researchStudyName, string subjectId) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getSiteNameBySubjectId";
          var args = new GetSiteNameBySubjectIdRequest {
            researchStudyName = researchStudyName,
            subjectId = subjectId
          };
          string rawRequest = JsonConvert.SerializeObject(args);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var result = JsonConvert.DeserializeObject<GetSiteNameBySubjectIdResponse>(rawResponse);
          if(result.fault != null){
            throw new Exception(result.fault);
          }
          return result.@return;
        }
      }
      
    }
    
  }
  
  namespace SubjectOverview {
    
    /// <summary> Provides an workflow-level API for interating with a 'SubjectDataRepository' (SDR) </summary>
    internal partial class SubjectOverviewServiceClient : ISubjectOverviewService {
      
      private string _Url;
      private string _ApiToken;
      
      public SubjectOverviewServiceClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
    }
    
  }
  
}
