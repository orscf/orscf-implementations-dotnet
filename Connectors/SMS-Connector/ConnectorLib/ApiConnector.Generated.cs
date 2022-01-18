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
      
      _InstituteMgmtServiceClient = new InstituteMgmtServiceClient(url + "instituteMgmtService/", apiToken);
      _SiteParticipationServiceClient = new SiteParticipationServiceClient(url + "siteParticipationService/", apiToken);
      _SmsApiInfoServiceClient = new SmsApiInfoServiceClient(url + "smsApiInfoService/", apiToken);
      _StudyAccessServiceClient = new StudyAccessServiceClient(url + "studyAccessService/", apiToken);
      _StudySetupServiceClient = new StudySetupServiceClient(url + "studySetupService/", apiToken);
      
    }
    
    private InstituteMgmtServiceClient _InstituteMgmtServiceClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    public IInstituteMgmtService InstituteMgmtService {
      get {
        return _InstituteMgmtServiceClient;
      }
    }
    
    private SiteParticipationServiceClient _SiteParticipationServiceClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    public ISiteParticipationService SiteParticipationService {
      get {
        return _SiteParticipationServiceClient;
      }
    }
    
    private SmsApiInfoServiceClient _SmsApiInfoServiceClient = null;
    /// <summary> Provides interoperability information for the current implementation </summary>
    public ISmsApiInfoService SmsApiInfoService {
      get {
        return _SmsApiInfoServiceClient;
      }
    }
    
    private StudyAccessServiceClient _StudyAccessServiceClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    public IStudyAccessService StudyAccessService {
      get {
        return _StudyAccessServiceClient;
      }
    }
    
    private StudySetupServiceClient _StudySetupServiceClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    public IStudySetupService StudySetupService {
      get {
        return _StudySetupServiceClient;
      }
    }
    
  }
  
  namespace InstituteMgmt {
    
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    internal partial class InstituteMgmtServiceClient : IInstituteMgmtService {
      
      private string _Url;
      private string _ApiToken;
      
      public InstituteMgmtServiceClient(string url, string apiToken) {
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
          var args = new GetInstituteUidByTitleRequest {
            instituteTitle = instituteTitle
          };
          string rawRequest = JsonConvert.SerializeObject(args);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var result = JsonConvert.DeserializeObject<GetInstituteUidByTitleResponse>(rawResponse);
          if(result.fault != null){
            throw new Exception(result.fault);
          }
          return result.@return;
        }
      }
      
      /// <summary> GetInstituteTitleByUid </summary>
      /// <param name="instituteUid">  </param>
      public String GetInstituteTitleByUid(Guid instituteUid) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getInstituteTitleByUid";
          var args = new GetInstituteTitleByUidRequest {
            instituteUid = instituteUid
          };
          string rawRequest = JsonConvert.SerializeObject(args);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var result = JsonConvert.DeserializeObject<GetInstituteTitleByUidResponse>(rawResponse);
          if(result.fault != null){
            throw new Exception(result.fault);
          }
          return result.@return;
        }
      }
      
      /// <summary> ArchiveInstitute </summary>
      /// <param name="instituteUid">  </param>
      public String ArchiveInstitute(Guid instituteUid) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "archiveInstitute";
          var args = new ArchiveInstituteRequest {
            instituteUid = instituteUid
          };
          string rawRequest = JsonConvert.SerializeObject(args);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var result = JsonConvert.DeserializeObject<ArchiveInstituteResponse>(rawResponse);
          if(result.fault != null){
            throw new Exception(result.fault);
          }
          return result.@return;
        }
      }
      
      /// <summary> GetInstituteInfos </summary>
      /// <param name="instituteUid">  </param>
      public String GetInstituteInfos(Guid instituteUid) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getInstituteInfos";
          var args = new GetInstituteInfosRequest {
            instituteUid = instituteUid
          };
          string rawRequest = JsonConvert.SerializeObject(args);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var result = JsonConvert.DeserializeObject<GetInstituteInfosResponse>(rawResponse);
          if(result.fault != null){
            throw new Exception(result.fault);
          }
          return result.@return;
        }
      }
      
      /// <summary> ensures, that an institute with the given Uid exists and returns true, if it has been newly created </summary>
      /// <param name="instituteUid">  </param>
      public Boolean CreateInstituteIfMissing(Guid instituteUid) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "createInstituteIfMissing";
          var args = new CreateInstituteIfMissingRequest {
            instituteUid = instituteUid
          };
          string rawRequest = JsonConvert.SerializeObject(args);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var result = JsonConvert.DeserializeObject<CreateInstituteIfMissingResponse>(rawResponse);
          if(result.fault != null){
            throw new Exception(result.fault);
          }
          return result.@return;
        }
      }
      
      /// <summary> updated the title of the the institute or returns false, if there is no record for the given instituteUid </summary>
      /// <param name="instituteUid">  </param>
      /// <param name="newTitle">  </param>
      public Boolean UpdateInstitueTitle(Guid instituteUid, string newTitle) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "updateInstitueTitle";
          var args = new UpdateInstitueTitleRequest {
            instituteUid = instituteUid,
            newTitle = newTitle
          };
          string rawRequest = JsonConvert.SerializeObject(args);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var result = JsonConvert.DeserializeObject<UpdateInstitueTitleResponse>(rawResponse);
          if(result.fault != null){
            throw new Exception(result.fault);
          }
          return result.@return;
        }
      }
      
    }
    
  }
  
  namespace SiteParticipation {
    
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    internal partial class SiteParticipationServiceClient : ISiteParticipationService {
      
      private string _Url;
      private string _ApiToken;
      
      public SiteParticipationServiceClient(string url, string apiToken) {
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
    internal partial class SmsApiInfoServiceClient : ISmsApiInfoService {
      
      private string _Url;
      private string _ApiToken;
      
      public SmsApiInfoServiceClient(string url, string apiToken) {
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
      
      /// <summary> returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'InstituteMgmt', 'StudySetup', 'StudyAccess', 'SiteParticipation' </summary>
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
      
      /// <summary> returns a list of available capabilities ("API:StudyAccess") and/or data-scopes ("Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72") which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be: 0=auth needed / 1=authenticated / -1=auth expired / -2=auth invalid/disabled </summary>
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
  
  namespace StudyAccess {
    
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    internal partial class StudyAccessServiceClient : IStudyAccessService {
      
      private string _Url;
      private string _ApiToken;
      
      public StudyAccessServiceClient(string url, string apiToken) {
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
          var args = new SubscribeStudyStateChangedEventsRequest {
            eventQueueId = eventQueueId
          };
          string rawRequest = JsonConvert.SerializeObject(args);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var result = JsonConvert.DeserializeObject<SubscribeStudyStateChangedEventsResponse>(rawResponse);
          if(result.fault != null){
            throw new Exception(result.fault);
          }
          return result.@return;
        }
      }
      
      /// <summary> Unsubscribes the Event when the State of a Study was changed for the given "EventQueue" </summary>
      /// <param name="eventQueueId">  </param>
      public Boolean UnsubscribeStudyStateChangedEvents(Guid eventQueueId) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "unsubscribeStudyStateChangedEvents";
          var args = new UnsubscribeStudyStateChangedEventsRequest {
            eventQueueId = eventQueueId
          };
          string rawRequest = JsonConvert.SerializeObject(args);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var result = JsonConvert.DeserializeObject<UnsubscribeStudyStateChangedEventsResponse>(rawResponse);
          if(result.fault != null){
            throw new Exception(result.fault);
          }
          return result.@return;
        }
      }
      
    }
    
  }
  
  namespace StudySetup {
    
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    internal partial class StudySetupServiceClient : IStudySetupService {
      
      private string _Url;
      private string _ApiToken;
      
      public StudySetupServiceClient(string url, string apiToken) {
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
          var args = new GetStudyTitleByIdentifierRequest {
            studyIdentifier = studyIdentifier
          };
          string rawRequest = JsonConvert.SerializeObject(args);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var result = JsonConvert.DeserializeObject<GetStudyTitleByIdentifierResponse>(rawResponse);
          if(result.fault != null){
            throw new Exception(result.fault);
          }
          return result.@return;
        }
      }
      
    }
    
  }
  
}
