/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.StudyManagement.InstituteMgmt;
using MedicalResearch.StudyManagement.Model;
using MedicalResearch.StudyManagement.SiteParticipation;
using MedicalResearch.StudyManagement.SmsApiInfo;
using MedicalResearch.StudyManagement.StudyAccess;
using MedicalResearch.StudyManagement.StudySetup;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MedicalResearch.StudyManagement {
  
  public partial class SmsApiConnector {
    
    public SmsApiConnector(string url, string apiToken) {
      
      if (!url.EndsWith("/")) {
        url = url + "/";
      }
      
      _InstituteMgmtClient = new InstituteMgmtClient(url + "instituteMgmt/", apiToken);
      _SiteParticipationClient = new SiteParticipationClient(url + "siteParticipation/", apiToken);
      _SmsApiInfoClient = new SmsApiInfoClient(url + "smsApiInfo/", apiToken);
      _StudyAccessClient = new StudyAccessClient(url + "studyAccess/", apiToken);
      _StudySetupClient = new StudySetupClient(url + "studySetup/", apiToken);
      
    }
    
    private InstituteMgmtClient _InstituteMgmtClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    public IInstituteMgmtService InstituteMgmt {
      get {
        return _InstituteMgmtClient;
      }
    }
    
    private SiteParticipationClient _SiteParticipationClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    public ISiteParticipationService SiteParticipation {
      get {
        return _SiteParticipationClient;
      }
    }
    
    private SmsApiInfoClient _SmsApiInfoClient = null;
    /// <summary> Provides interoperability information for the current implementation </summary>
    public ISmsApiInfoService SmsApiInfo {
      get {
        return _SmsApiInfoClient;
      }
    }
    
    private StudyAccessClient _StudyAccessClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    public IStudyAccessService StudyAccess {
      get {
        return _StudyAccessClient;
      }
    }
    
    private StudySetupClient _StudySetupClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    public IStudySetupService StudySetup {
      get {
        return _StudySetupClient;
      }
    }
    
  }
  
  namespace InstituteMgmt {
    
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    internal partial class InstituteMgmtClient : IInstituteMgmtService {
      
      private string _Url;
      private string _ApiToken;
      
      public InstituteMgmtClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> GetInstituteUidByTitle </summary>
      /// <param name="instituteTitle">  </param>
      public Guid GetInstituteUidByTitle(string instituteTitle) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getInstituteUidByTitle";
          var requestWrapper = new GetInstituteUidByTitleRequest {
            instituteTitle = instituteTitle
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetInstituteUidByTitleResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> GetInstituteTitleByUid </summary>
      /// <param name="instituteUid">  </param>
      public String GetInstituteTitleByUid(Guid instituteUid) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getInstituteTitleByUid";
          var requestWrapper = new GetInstituteTitleByUidRequest {
            instituteUid = instituteUid
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetInstituteTitleByUidResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> ArchiveInstitute </summary>
      /// <param name="instituteUid">  </param>
      public String ArchiveInstitute(Guid instituteUid) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "archiveInstitute";
          var requestWrapper = new ArchiveInstituteRequest {
            instituteUid = instituteUid
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ArchiveInstituteResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> GetInstituteInfos </summary>
      /// <param name="instituteUid">  </param>
      public InstituteInfo[] GetInstituteInfos(Guid instituteUid) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getInstituteInfos";
          var requestWrapper = new GetInstituteInfosRequest {
            instituteUid = instituteUid
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetInstituteInfosResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> ensures, that an institute with the given Uid exists and returns true, if it has been newly created </summary>
      /// <param name="instituteUid">  </param>
      public Boolean CreateInstituteIfMissing(Guid instituteUid) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "createInstituteIfMissing";
          var requestWrapper = new CreateInstituteIfMissingRequest {
            instituteUid = instituteUid
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<CreateInstituteIfMissingResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> updated the title of the the institute or returns false, if there is no record for the given instituteUid </summary>
      /// <param name="instituteUid">  </param>
      /// <param name="newTitle">  </param>
      public Boolean UpdateInstitueTitle(Guid instituteUid, string newTitle) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "updateInstitueTitle";
          var requestWrapper = new UpdateInstitueTitleRequest {
            instituteUid = instituteUid,
            newTitle = newTitle
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<UpdateInstitueTitleResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
    }
    
  }
  
  namespace SiteParticipation {
    
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    internal partial class SiteParticipationClient : ISiteParticipationService {
      
      private string _Url;
      private string _ApiToken;
      
      public SiteParticipationClient(string url, string apiToken) {
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
  
  namespace SmsApiInfo {
    
    /// <summary> Provides interoperability information for the current implementation </summary>
    internal partial class SmsApiInfoClient : ISmsApiInfoService {
      
      private string _Url;
      private string _ApiToken;
      
      public SmsApiInfoClient(string url, string apiToken) {
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
          var requestWrapper = new GetApiVersionRequest {
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetApiVersionResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'InstituteMgmt', 'StudySetup', 'StudyAccess', 'SiteParticipation' </summary>
      public String[] GetCapabilities() {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getCapabilities";
          var requestWrapper = new GetCapabilitiesRequest {
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetCapabilitiesResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> returns a list of available capabilities ("API:StudyAccess") and/or data-scopes ("Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72") which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be: 0=auth needed / 1=authenticated / -1=auth expired / -2=auth invalid/disabled </summary>
      /// <param name="authState">  </param>
      public String[] GetPermittedAuthScopes(out Int32 authState) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getPermittedAuthScopes";
          var requestWrapper = new GetPermittedAuthScopesRequest {
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetPermittedAuthScopesResponse>(rawResponse);
          authState = responseWrapper.authState;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> OPTIONAL: If the authentication on the current service is mapped using tokens and should provide information about the source at this point, the login URL to be called up via browser (OAuth <see href="https://openid.net/specs/openid-client-initiated-backchannel-authentication-core-1_0.html">'CIBA-Flow'</see>) is returned here. </summary>
      public String GetOAuthTokenRequestUrl() {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getOAuthTokenRequestUrl";
          var requestWrapper = new GetOAuthTokenRequestUrlRequest {
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetOAuthTokenRequestUrlResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
    }
    
  }
  
  namespace StudyAccess {
    
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    internal partial class StudyAccessClient : IStudyAccessService {
      
      private string _Url;
      private string _ApiToken;
      
      public StudyAccessClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> Subscribes the Event when the State of a Study was changed to the given "EventQueue" which is accessable via "EventQueueService" (including http notifications) </summary>
      /// <param name="eventQueueId">  </param>
      public Boolean SubscribeStudyStateChangedEvents(Guid eventQueueId) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "subscribeStudyStateChangedEvents";
          var requestWrapper = new SubscribeStudyStateChangedEventsRequest {
            eventQueueId = eventQueueId
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<SubscribeStudyStateChangedEventsResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> Unsubscribes the Event when the State of a Study was changed for the given "EventQueue" </summary>
      /// <param name="eventQueueId">  </param>
      public Boolean UnsubscribeStudyStateChangedEvents(Guid eventQueueId) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "unsubscribeStudyStateChangedEvents";
          var requestWrapper = new UnsubscribeStudyStateChangedEventsRequest {
            eventQueueId = eventQueueId
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<UnsubscribeStudyStateChangedEventsResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
    }
    
  }
  
  namespace StudySetup {
    
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    internal partial class StudySetupClient : IStudySetupService {
      
      private string _Url;
      private string _ApiToken;
      
      public StudySetupClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> returns null, if there is no matching record </summary>
      /// <param name="studyIdentifier">  </param>
      public String GetStudyTitleByIdentifier(string studyIdentifier) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getStudyTitleByIdentifier";
          var requestWrapper = new GetStudyTitleByIdentifierRequest {
            studyIdentifier = studyIdentifier
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetStudyTitleByIdentifierResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
    }
    
  }
  
}
