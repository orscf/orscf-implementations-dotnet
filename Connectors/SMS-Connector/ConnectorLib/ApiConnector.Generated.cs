/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.StudyManagement.InstituteRegistry;
using MedicalResearch.StudyManagement.Model;
using MedicalResearch.StudyManagement.SiteParticipation;
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
      
      _InstituteRegistryServiceClient = new InstituteRegistryServiceClient(url + "instituteRegistryService/", apiToken);
      _SiteParticipationServiceClient = new SiteParticipationServiceClient(url + "siteParticipationService/", apiToken);
      _StudyAccessServiceClient = new StudyAccessServiceClient(url + "studyAccessService/", apiToken);
      _StudySetupServiceClient = new StudySetupServiceClient(url + "studySetupService/", apiToken);
      
    }
    
    private InstituteRegistryServiceClient _InstituteRegistryServiceClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    public IInstituteRegistryService InstituteRegistryService {
      get {
        return _InstituteRegistryServiceClient;
      }
    }
    
    private SiteParticipationServiceClient _SiteParticipationServiceClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    public ISiteParticipationService SiteParticipationService {
      get {
        return _SiteParticipationServiceClient;
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
  
  namespace InstituteRegistry {
    
    /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
    internal partial class InstituteRegistryServiceClient : IInstituteRegistryService {
      
      private string _Url;
      private string _ApiToken;
      
      public InstituteRegistryServiceClient(string url, string apiToken) {
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
      public Guid GetInstituteUidByTitle(String instituteTitle) {
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
      public Boolean UpdateInstitueTitle(Guid instituteUid, String newTitle) {
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
      public String GetStudyTitleByIdentifier(String studyIdentifier) {
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
