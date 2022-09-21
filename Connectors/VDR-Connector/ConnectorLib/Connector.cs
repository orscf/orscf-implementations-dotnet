/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.VisitData.DataEnrollment;
using MedicalResearch.VisitData.DataRecordingSubmission;
using MedicalResearch.VisitData.Model;
using MedicalResearch.VisitData.VdrApiInfo;
using MedicalResearch.VisitData.VdrEventSubscription;
using MedicalResearch.VisitData.VisitConsume;
using MedicalResearch.VisitData.VisitHL7Export;
using MedicalResearch.VisitData.VisitHL7Import;
using MedicalResearch.VisitData.VisitSubmission;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace MedicalResearch.VisitData {
  
  public partial class VdrApiConnector {
    
    public VdrApiConnector(string url, string apiToken) {
      
      if (!url.EndsWith("/")) {
        url = url + "/";
      }
      
      _VdrApiInfoClient = new VdrApiInfoClient(url + "vdrApiInfo/", apiToken);
      _VdrEventSubscriptionClient = new VdrEventSubscriptionClient(url + "vdrEventSubscription/", apiToken);
      _DataEnrollmentClient = new DataEnrollmentClient(url + "dataEnrollment/", apiToken);
      _DataRecordingSubmissionClient = new DataRecordingSubmissionClient(url + "dataRecordingSubmission/", apiToken);
      _VisitConsumeClient = new VisitConsumeClient(url + "visitConsume/", apiToken);
      _VisitHL7ExportClient = new VisitHL7ExportClient(url + "visitHL7Export/", apiToken);
      _VisitHL7ImportClient = new VisitHL7ImportClient(url + "visitHL7Import/", apiToken);
      _VisitSubmissionClient = new VisitSubmissionClient(url + "visitSubmission/", apiToken);
      
    }
    
    private VdrApiInfoClient _VdrApiInfoClient = null;
    /// <summary> Provides interoperability information for the current implementation </summary>
    public IVdrApiInfoService VdrApiInfo {
      get {
        return _VdrApiInfoClient;
      }
    }
    
    private VdrEventSubscriptionClient _VdrEventSubscriptionClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR) </summary>
    public IVdrEventSubscriptionService VdrEventSubscription {
      get {
        return _VdrEventSubscriptionClient;
      }
    }
    
    private DataEnrollmentClient _DataEnrollmentClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR) </summary>
    public IDataEnrollmentService DataEnrollment {
      get {
        return _DataEnrollmentClient;
      }
    }
    
    private DataRecordingSubmissionClient _DataRecordingSubmissionClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR) </summary>
    public IDataRecordingSubmissionService DataRecordingSubmission {
      get {
        return _DataRecordingSubmissionClient;
      }
    }
    
    private VisitConsumeClient _VisitConsumeClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR) </summary>
    public IVisitConsumeService VisitConsume {
      get {
        return _VisitConsumeClient;
      }
    }
    
    private VisitHL7ExportClient _VisitHL7ExportClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR) </summary>
    public IVisitHL7ExportService VisitHL7Export {
      get {
        return _VisitHL7ExportClient;
      }
    }
    
    private VisitHL7ImportClient _VisitHL7ImportClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR) </summary>
    public IVisitHL7ImportService VisitHL7Import {
      get {
        return _VisitHL7ImportClient;
      }
    }
    
    private VisitSubmissionClient _VisitSubmissionClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR) </summary>
    public IVisitSubmissionService VisitSubmission {
      get {
        return _VisitSubmissionClient;
      }
    }
    
  }
  
  namespace VdrApiInfo {
    
    /// <summary> Provides interoperability information for the current implementation </summary>
    internal partial class VdrApiInfoClient : IVdrApiInfoService {
      
      private string _Url;
      private string _ApiToken;
      
      public VdrApiInfoClient(string url, string apiToken) {
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
      
      /// <summary> returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'VdrEventSubscription', 'VisitConsume', 'VisitSubmission', 'VisitHL7Export', 'VisitHL7Import', 'DataRecordingSubmission' </summary>
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
      
      /// <summary> returns a list of available capabilities ("API:VisitDataConsume") and/or data-scopes ("Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72") which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be: 0=auth needed / 1=authenticated / -1=auth expired / -2=auth invalid/disabled </summary>
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
  
  namespace VdrEventSubscription {
    
    /// <summary> Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR) </summary>
    internal partial class VdrEventSubscriptionClient : IVdrEventSubscriptionService {
      
      private string _Url;
      private string _ApiToken;
      
      public VdrEventSubscriptionClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> Creates a subscription for changes which are affecting Visits. On success, a 'SubscriptionUid' will be returned and a call will be made to the given subscriberUrl + '/ConfirmAsSubscriber'. After the subscription has been confirmed, the requested events will be pushed to subscriberUrl + '/NoticeChangedVisits' (NOTICE: the receiving methods also are documented here, because this service itself can act as subscriber) </summary>
      /// <param name="subscriberUrl"> the root-url of the subscriber which needs to provide at least the methods '/ConfirmAsSubscriber' and '/NoticeChangedVisits' </param>
      /// <param name="filter"> if provided, the subscription will only publish events for records matching to the given filter </param>
      public Guid SubscribeForChangedVisits(string subscriberUrl, VisitFilter filter = null) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "subscribeForChangedVisits";
          var requestWrapper = new SubscribeForChangedVisitsRequest {
            subscriberUrl = subscriberUrl,
            filter = filter
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<SubscribeForChangedVisitsResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> Receives notifications about changes which are affecting Visits. IMPORTANT: this method is dedicated to the usecase, when this service itself acts as a subscriber! So this can be called by an foreign service during the setup of a subscription, which was previously requested from here. The opposite case: any client subscribing to events from here, must provide its own http endpoint that has such a method! </summary>
      /// <param name="eventUid"> a UUID which identifies the current event message </param>
      /// <param name="eventSignature"> a SHA256 Hash of SubscriptionSecret + EventUid (in lower string representation, without '-' characters!) Sample: SHA256('ThEs3Cr3T'+'c997dfb1c445fea84afe995307713b59') = 'a320ef5b0f563e8dcb16d759961739977afc98b90628d9dc3be519fb20701490' </param>
      /// <param name="subscriptionUid"> a UUID which identifies the subscription for which this event is published </param>
      /// <param name="publisherUrl"> root-URL of the VDR-Service which is publishing this event </param>
      /// <param name="createdRecords">  </param>
      /// <param name="modifiedRecords">  </param>
      /// <param name="archivedRecords">  </param>
      /// <param name="terminateSubscription"> an array, which contains one element per changed visit </param>
      public void NoticeChangedVisits(Guid eventUid, string eventSignature, Guid subscriptionUid, string publisherUrl, VisitMetaRecord[] createdRecords, VisitMetaRecord[] modifiedRecords, VisitMetaRecord[] archivedRecords, out bool terminateSubscription) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "noticeChangedVisits";
          var requestWrapper = new NoticeChangedVisitsRequest {
            eventUid = eventUid,
            eventSignature = eventSignature,
            subscriptionUid = subscriptionUid,
            publisherUrl = publisherUrl,
            createdRecords = createdRecords,
            modifiedRecords = modifiedRecords,
            archivedRecords = archivedRecords,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<NoticeChangedVisitsResponse>(rawResponse);
          terminateSubscription = responseWrapper.terminateSubscription;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> Confirms a Subscription. IMPORTANT: this method is dedicated to the usecase, when this service itself acts as a subscriber! So this can be called by an foreign service during the setup of a subscription, which was previously requested from here. The opposite case: any client subscribing to events from here, must provide its own http endpoint that has such a method! </summary>
      /// <param name="publisherUrl"> root-URL of the VDR-Service on which the subscription was requested </param>
      /// <param name="subscriptionUid"> the Uid of the subscription which should be confirmed </param>
      /// <param name="secret"> A secret which is generated by the subscriber and used to provide additional security. It will be required for the 'TerminateSubscription' method and it is used to generate SHA256 hashes for signing the delivered event messages. The secret should: have a minimum length of 32 characters. A null or empty string has the semantics that the subscriber refuses to confirm and cancels the subscription setup. </param>
      public void ConfirmAsSubscriber(string publisherUrl, Guid subscriptionUid, out string secret) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "confirmAsSubscriber";
          var requestWrapper = new ConfirmAsSubscriberRequest {
            publisherUrl = publisherUrl,
            subscriptionUid = subscriptionUid,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ConfirmAsSubscriberResponse>(rawResponse);
          secret = responseWrapper.secret;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> Terminates a subscription (on publisher side) and returns a boolean, which indicates success. </summary>
      /// <param name="subscriptionUid"> the Uid of the subscription which should be terminated </param>
      /// <param name="secret"> the (same) secret, which was given by the subscriber during the subscription setup </param>
      public Boolean TerminateSubscription(Guid subscriptionUid, string secret) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "terminateSubscription";
          var requestWrapper = new TerminateSubscriptionRequest {
            subscriptionUid = subscriptionUid,
            secret = secret
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<TerminateSubscriptionResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> Returns an array of subscriptionUid's. This method helps subscribers to evaluate whether current subscriptions are still active. </summary>
      /// <param name="subscriberUrl">  </param>
      /// <param name="secret"> the (same) secret, which was given by the subscriber during the subscription setup </param>
      public Guid[] GetSubsriptionsBySubscriberUrl(string subscriberUrl, string secret) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getSubsriptionsBySubscriberUrl";
          var requestWrapper = new GetSubsriptionsBySubscriberUrlRequest {
            subscriberUrl = subscriberUrl,
            secret = secret
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetSubsriptionsBySubscriberUrlResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
    }
    
  }
  
  namespace DataEnrollment {
    
    /// <summary> Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR) </summary>
    internal partial class DataEnrollmentClient : IDataEnrollmentService {
      
      private string _Url;
      private string _ApiToken;
      
      public DataEnrollmentClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> Enrolls recorded data to be stored as 'DataRecording'-Record related to a explicitly addressed Visit inside of this repository. This goes ahead with an validation process for each enrollment, therefore a dataEnrollmentUid will be returned which can be used to query the state of this process via 'GetValidationState'. </summary>
      /// <param name="targetvisitUid"> the ORSCF-Visit-UID to address the parent visit for which the given data should be submitted </param>
      /// <param name="taskExecutionTitle"> title of the task execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </param>
      /// <param name="executionDateTimeUtc"> the time, when the data was recorded </param>
      /// <param name="dataSchemaKind"> 'FhirQuestionaire' / 'XML' / 'CSV' / 'Custom' </param>
      /// <param name="dataSchemaUrl"> the schema-url of the data which were stored inside of the 'RecordedData' field </param>
      /// <param name="dataSchemaVersion"> version of schema, which is addressed by the 'DataSchemaUrl' </param>
      /// <param name="dataLanguage"> Language of free-text information inside of the data content </param>
      /// <param name="recordedData"> RAW data, in the schema as defined at the 'DataSchemaUrl' </param>
      public Guid EnrollDataForVisitExplicit(Guid targetvisitUid, string taskExecutionTitle, DateTime executionDateTimeUtc, string dataSchemaKind, string dataSchemaUrl, string dataSchemaVersion, string dataLanguage, string recordedData) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "enrollDataForVisitExplicit";
          var requestWrapper = new EnrollDataForVisitExplicitRequest {
            targetvisitUid = targetvisitUid,
            taskExecutionTitle = taskExecutionTitle,
            executionDateTimeUtc = executionDateTimeUtc,
            dataSchemaKind = dataSchemaKind,
            dataSchemaUrl = dataSchemaUrl,
            dataSchemaVersion = dataSchemaVersion,
            dataLanguage = dataLanguage,
            recordedData = recordedData
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<EnrollDataForVisitExplicitResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> Enrolls recorded data to be stored as 'DataRecording'-Record related to a visit inside of this repository (which is implicitely resolved using the given 'visitExecutionTitle' and 'subjectIdentifier') . This goes ahead with an validation process for each enrollment, therefore a dataEnrollmentUid will be returned which can be used to query the state of this process via 'GetValidationState'. </summary>
      /// <param name="studyUid"> the ORSCF-Study-UID which is used to lookup for the target visit for which the given data should be submitted </param>
      /// <param name="subjectIdentifier"> the study related identity of the patient (usually a pseudonym) which is used to lookup for the target visit for which the given data should be submitted </param>
      /// <param name="visitExecutionTitle"> unique title of the visit execution as defined in the 'StudyWorkflowDefinition' which is used to lookup for the target visit for which the given data should be submitted </param>
      /// <param name="taskExecutionTitle"> title of the task execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </param>
      /// <param name="executionDateTimeUtc"> the time, when the data was recorded </param>
      /// <param name="dataSchemaKind"> 'FhirQuestionaire' / 'XML' / 'CSV' / 'Custom' </param>
      /// <param name="dataSchemaUrl"> the schema-url of the data which were stored inside of the 'RecordedData' field </param>
      /// <param name="dataSchemaVersion"> version of schema, which is addressed by the 'DataSchemaUrl' </param>
      /// <param name="dataLanguage"> Language of free-text information inside of the data content </param>
      /// <param name="recordedData"> RAW data, in the schema as defined at the 'DataSchemaUrl' </param>
      public Guid EnrollDataForVisitImplicit(Guid studyUid, string subjectIdentifier, string visitExecutionTitle, string taskExecutionTitle, DateTime executionDateTimeUtc, string dataSchemaKind, string dataSchemaUrl, string dataSchemaVersion, string dataLanguage, string recordedData) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "enrollDataForVisitImplicit";
          var requestWrapper = new EnrollDataForVisitImplicitRequest {
            studyUid = studyUid,
            subjectIdentifier = subjectIdentifier,
            visitExecutionTitle = visitExecutionTitle,
            taskExecutionTitle = taskExecutionTitle,
            executionDateTimeUtc = executionDateTimeUtc,
            dataSchemaKind = dataSchemaKind,
            dataSchemaUrl = dataSchemaUrl,
            dataSchemaVersion = dataSchemaVersion,
            dataLanguage = dataLanguage,
            recordedData = recordedData
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<EnrollDataForVisitImplicitResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> Providing the current validation state for a given data enrollment process </summary>
      /// <param name="dataEnrollmentUid">  </param>
      public DataEnrollmentValidationState GetValidationState(Guid dataEnrollmentUid) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getValidationState";
          var requestWrapper = new GetValidationStateRequest {
            dataEnrollmentUid = dataEnrollmentUid
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetValidationStateResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return.Value;
        }
      }
      
    }
    
  }
  
  namespace DataRecordingSubmission {
    
    /// <summary> Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR) </summary>
    internal partial class DataRecordingSubmissionClient : IDataRecordingSubmissionService {
      
      private string _Url;
      private string _ApiToken;
      
      public DataRecordingSubmissionClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> ImportDataRecordings </summary>
      /// <param name="dataRecordings">  </param>
      /// <param name="createdDataRecordingUids">  </param>
      /// <param name="updatedDataRecordingUids">  </param>
      public void ImportDataRecordings(DataRecordingStructure[] dataRecordings, out Guid[] createdDataRecordingUids, out Guid[] updatedDataRecordingUids) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "importDataRecordings";
          var requestWrapper = new ImportDataRecordingsRequest {
            dataRecordings = dataRecordings,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ImportDataRecordingsResponse>(rawResponse);
          createdDataRecordingUids = responseWrapper.createdDataRecordingUids;
          updatedDataRecordingUids = responseWrapper.updatedDataRecordingUids;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
    }
    
  }
  
  namespace VisitConsume {
    
    /// <summary> Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR) </summary>
    internal partial class VisitConsumeClient : IVisitConsumeService {
      
      private string _Url;
      private string _ApiToken;
      
      public VisitConsumeClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> Searches Visits by a given 'filter' (if provided), sorts the results by the given 'sortingField' (if provided) and returns an array of VisitUids for the matching records. </summary>
      /// <param name="result">  </param>
      /// <param name="sortingField"> A fieldname, which should be used to sort the result (can also be a 'CustomField'). If not provided, the result will be sorted by the creation date of the records </param>
      /// <param name="sortDescending"> toggles the sorting direction </param>
      /// <param name="filter"> values by field name (can also be a 'CustomField') which will used as AND-linked filter </param>
      /// <param name="includeArchivedRecords"> includes archived records in the result </param>
      /// <param name="limitResults"> a value greather than zero will represent a maximum count of results, that sould be returned </param>
      public void SearchVisits(out VisitMetaRecord[] result, string sortingField = null, bool sortDescending = false, VisitFilter filter = null, bool includeArchivedRecords = false, Int32 limitResults = 0) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "searchVisits";
          var requestWrapper = new SearchVisitsRequest {
            sortingField = sortingField,
            sortDescending = sortDescending,
            filter = filter,
            includeArchivedRecords = includeArchivedRecords,
            limitResults = limitResults,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<SearchVisitsResponse>(rawResponse);
          result = responseWrapper.result;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> Searches Visits which have been modified after(or at) the given 'minTimestampUtc', matching to the given 'filter' (if provided). The result is sorted descenting by the timestamp of the modification (latest first) and will include archived records. </summary>
      /// <param name="minTimestampUtc"> start of the timespan to search (as UNIX-Timestamp) </param>
      /// <param name="latestTimestampUtc"> the exact timestamp of the search (as UNIX-Timestamp) </param>
      /// <param name="createdRecords">  </param>
      /// <param name="modifiedRecords">  </param>
      /// <param name="archivedRecords">  </param>
      /// <param name="filter"> values by field name (can also be a 'CustomField') which will used as AND-linked filter </param>
      public void SearchChangedVisits(Int64 minTimestampUtc, out Int64 latestTimestampUtc, out VisitMetaRecord[] createdRecords, out VisitMetaRecord[] modifiedRecords, out VisitMetaRecord[] archivedRecords, VisitFilter filter = null) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "searchChangedVisits";
          var requestWrapper = new SearchChangedVisitsRequest {
            minTimestampUtc = minTimestampUtc,
            filter = filter,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<SearchChangedVisitsResponse>(rawResponse);
          latestTimestampUtc = responseWrapper.latestTimestampUtc;
          createdRecords = responseWrapper.createdRecords;
          modifiedRecords = responseWrapper.modifiedRecords;
          archivedRecords = responseWrapper.archivedRecords;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> GetCustomFieldDescriptorsForVisit </summary>
      /// <param name="languagePref"> Preferred language for the 'DisplayLabel' and 'InputDescription' fields of the returned descriptors. The default is 'EN'. </param>
      public CustomFieldDescriptor[] GetCustomFieldDescriptorsForVisit(string languagePref = "EN") {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getCustomFieldDescriptorsForVisit";
          var requestWrapper = new GetCustomFieldDescriptorsForVisitRequest {
            languagePref = languagePref
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetCustomFieldDescriptorsForVisitResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> Checks the existence of 'Visits' for a given list of visitUids </summary>
      /// <param name="visitUids">  </param>
      /// <param name="unavailableVisitUids">  </param>
      /// <param name="availableVisitUids">  </param>
      public void CheckVisitExisitence(Guid[] visitUids, out Guid[] unavailableVisitUids, out Guid[] availableVisitUids) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "checkVisitExisitence";
          var requestWrapper = new CheckVisitExisitenceRequest {
            visitUids = visitUids,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<CheckVisitExisitenceResponse>(rawResponse);
          unavailableVisitUids = responseWrapper.unavailableVisitUids;
          availableVisitUids = responseWrapper.availableVisitUids;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> loads the requested visits and returns lightweight json objects (without childs), which are optimized to be displayed as table (the most common UI use case). This models containig a combination of: essential fieds from the record, calculated fields (numbers of child records), custom fields (choosen by the service) </summary>
      /// <param name="visitUids">  </param>
      /// <param name="unavailableVisitUids">  </param>
      /// <param name="result">  </param>
      public void GetVisitFields(Guid[] visitUids, out Guid[] unavailableVisitUids, out VisitFields[] result) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getVisitFields";
          var requestWrapper = new GetVisitFieldsRequest {
            visitUids = visitUids,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetVisitFieldsResponse>(rawResponse);
          unavailableVisitUids = responseWrapper.unavailableVisitUids;
          result = responseWrapper.result;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> exports full 'VisitStructures' </summary>
      /// <param name="visitUids">  </param>
      /// <param name="unavailableVisitUids">  </param>
      /// <param name="result">  </param>
      public void ExportVisits(Guid[] visitUids, out Guid[] unavailableVisitUids, out VisitStructure[] result) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "exportVisits";
          var requestWrapper = new ExportVisitsRequest {
            visitUids = visitUids,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ExportVisitsResponse>(rawResponse);
          unavailableVisitUids = responseWrapper.unavailableVisitUids;
          result = responseWrapper.result;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
    }
    
  }
  
  namespace VisitHL7Export {
    
    /// <summary> Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR) </summary>
    internal partial class VisitHL7ExportClient : IVisitHL7ExportService {
      
      private string _Url;
      private string _ApiToken;
      
      public VisitHL7ExportClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> Exports a structure containing HL7/FHIR-Ressources (JSON only) and the essential fields which are required to qualify a ORSCF record. </summary>
      /// <param name="visitUid">  </param>
      /// <param name="visitFhirRessources">  </param>
      public Boolean ExportVisitFhirRessources(Guid visitUid, out VisitFhirRessourceContainer[] visitFhirRessources) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "exportVisitFhirRessources";
          var requestWrapper = new ExportVisitFhirRessourcesRequest {
            visitUid = visitUid,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ExportVisitFhirRessourcesResponse>(rawResponse);
          visitFhirRessources = responseWrapper.visitFhirRessources;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
    }
    
  }
  
  namespace VisitHL7Import {
    
    /// <summary> Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR) </summary>
    internal partial class VisitHL7ImportClient : IVisitHL7ImportService {
      
      private string _Url;
      private string _ApiToken;
      
      public VisitHL7ImportClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> Exports a structure containing HL7/FHIR-Ressources (JSON only) and the essential fields which are required to qualify a ORSCF record. </summary>
      /// <param name="visitFhirRessources"> A structure containing HL7/FHIR-Ressources (JSON only) and the essential fields which are required to qualify a ORSCF record. </param>
      /// <param name="createdVisitUids">  </param>
      /// <param name="updatedVisitUids">  </param>
      public void ImportVisitFhirRessources(VisitFhirRessourceContainer[] visitFhirRessources, out Guid[] createdVisitUids, out Guid[] updatedVisitUids) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "importVisitFhirRessources";
          var requestWrapper = new ImportVisitFhirRessourcesRequest {
            visitFhirRessources = visitFhirRessources,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ImportVisitFhirRessourcesResponse>(rawResponse);
          createdVisitUids = responseWrapper.createdVisitUids;
          updatedVisitUids = responseWrapper.updatedVisitUids;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
    }
    
  }
  
  namespace VisitSubmission {
    
    /// <summary> Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR) </summary>
    internal partial class VisitSubmissionClient : IVisitSubmissionService {
      
      private string _Url;
      private string _ApiToken;
      
      public VisitSubmissionClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> ArchiveVisits </summary>
      /// <param name="visitUids">  </param>
      /// <param name="archivedVisitUids"> also including the Uids of already archived records </param>
      public void ArchiveVisits(Guid[] visitUids, out Guid[] archivedVisitUids) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "archiveVisits";
          var requestWrapper = new ArchiveVisitsRequest {
            visitUids = visitUids,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ArchiveVisitsResponse>(rawResponse);
          archivedVisitUids = responseWrapper.archivedVisitUids;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> UnarchiveVisits </summary>
      /// <param name="visitUids">  </param>
      /// <param name="unarchivedVisitUids">  </param>
      public void UnarchiveVisits(Guid[] visitUids, out Guid[] unarchivedVisitUids) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "unarchiveVisits";
          var requestWrapper = new UnarchiveVisitsRequest {
            visitUids = visitUids,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<UnarchiveVisitsResponse>(rawResponse);
          unarchivedVisitUids = responseWrapper.unarchivedVisitUids;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> ApplyVisitMutations </summary>
      /// <param name="mutationsByVisitUid">  </param>
      /// <param name="updatedVisitUids">  </param>
      public void ApplyVisitMutations(Dictionary<Guid, VisitMutation> mutationsByVisitUid, out Guid[] updatedVisitUids) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "applyVisitMutations";
          var requestWrapper = new ApplyVisitMutationsRequest {
            mutationsByVisitUid = mutationsByVisitUid,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ApplyVisitMutationsResponse>(rawResponse);
          updatedVisitUids = responseWrapper.updatedVisitUids;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> ApplyVisitBatchMutation </summary>
      /// <param name="visitUids">  </param>
      /// <param name="mutation">  </param>
      /// <param name="updatedVisitUids">  </param>
      public void ApplyVisitBatchMutation(Guid[] visitUids, BatchableVisitMutation mutation, out Guid[] updatedVisitUids) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "applyVisitBatchMutation";
          var requestWrapper = new ApplyVisitBatchMutationRequest {
            visitUids = visitUids,
            mutation = mutation,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ApplyVisitBatchMutationResponse>(rawResponse);
          updatedVisitUids = responseWrapper.updatedVisitUids;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> ImportVisits </summary>
      /// <param name="visits">  </param>
      /// <param name="createdVisitUids">  </param>
      /// <param name="updatedVisitUids">  </param>
      public void ImportVisits(VisitStructure[] visits, out Guid[] createdVisitUids, out Guid[] updatedVisitUids) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "importVisits";
          var requestWrapper = new ImportVisitsRequest {
            visits = visits,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ImportVisitsResponse>(rawResponse);
          createdVisitUids = responseWrapper.createdVisitUids;
          updatedVisitUids = responseWrapper.updatedVisitUids;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
    }
    
  }
  
}
