/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.SubjectData.Model;
using MedicalResearch.SubjectData.SdrApiInfo;
using MedicalResearch.SubjectData.SdrEventSubscription;
using MedicalResearch.SubjectData.SubjectConsume;
using MedicalResearch.SubjectData.SubjectHL7Export;
using MedicalResearch.SubjectData.SubjectHL7Import;
using MedicalResearch.SubjectData.SubjectSubmission;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace MedicalResearch.SubjectData {
  
  public partial class SdrApiConnector {
    
    public SdrApiConnector(string url, string apiToken) {
      
      if (!url.EndsWith("/")) {
        url = url + "/";
      }
      
      _SdrApiInfoClient = new SdrApiInfoClient(url + "sdrApiInfo/", apiToken);
      _SdrEventSubscriptionClient = new SdrEventSubscriptionClient(url + "sdrEventSubscription/", apiToken);
      _SubjectConsumeClient = new SubjectConsumeClient(url + "subjectConsume/", apiToken);
      _SubjectHL7ExportClient = new SubjectHL7ExportClient(url + "subjectHL7Export/", apiToken);
      _SubjectHL7ImportClient = new SubjectHL7ImportClient(url + "subjectHL7Import/", apiToken);
      _SubjectSubmissionClient = new SubjectSubmissionClient(url + "subjectSubmission/", apiToken);
      
    }
    
    private SdrApiInfoClient _SdrApiInfoClient = null;
    /// <summary> Provides interoperability information for the current implementation </summary>
    public ISdrApiInfoService SdrApiInfo {
      get {
        return _SdrApiInfoClient;
      }
    }
    
    private SdrEventSubscriptionClient _SdrEventSubscriptionClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'SubjectDataRepository' (VDR) </summary>
    public ISdrEventSubscriptionService SdrEventSubscription {
      get {
        return _SdrEventSubscriptionClient;
      }
    }
    
    private SubjectConsumeClient _SubjectConsumeClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'SubjectDataRepository' (VDR) </summary>
    public ISubjectConsumeService SubjectConsume {
      get {
        return _SubjectConsumeClient;
      }
    }
    
    private SubjectHL7ExportClient _SubjectHL7ExportClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'SubjectDataRepository' (VDR) </summary>
    public ISubjectHL7ExportService SubjectHL7Export {
      get {
        return _SubjectHL7ExportClient;
      }
    }
    
    private SubjectHL7ImportClient _SubjectHL7ImportClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'SubjectDataRepository' (VDR) </summary>
    public ISubjectHL7ImportService SubjectHL7Import {
      get {
        return _SubjectHL7ImportClient;
      }
    }
    
    private SubjectSubmissionClient _SubjectSubmissionClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'SubjectDataRepository' (VDR) </summary>
    public ISubjectSubmissionService SubjectSubmission {
      get {
        return _SubjectSubmissionClient;
      }
    }
    
  }
  
  namespace SdrApiInfo {
    
    /// <summary> Provides interoperability information for the current implementation </summary>
    internal partial class SdrApiInfoClient : ISdrApiInfoService {
      
      private string _Url;
      private string _ApiToken;
      
      public SdrApiInfoClient(string url, string apiToken) {
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
      
      /// <summary> returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'SdrEventSubscription', 'SubjectConsume', 'SubjectSubmission', 'SubjectHL7Export' 'SubjectHL7Import' </summary>
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
      
      /// <summary> returns a list of available capabilities ("API:SubjectOverview") and/or data-scopes ("Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72") which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be: 0=auth needed / 1=authenticated / -1=auth expired / -2=auth invalid/disabled </summary>
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
  
  namespace SdrEventSubscription {
    
    /// <summary> Provides an workflow-level API for interating with a 'SubjectDataRepository' (VDR) </summary>
    internal partial class SdrEventSubscriptionClient : ISdrEventSubscriptionService {
      
      private string _Url;
      private string _ApiToken;
      
      public SdrEventSubscriptionClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> Creates a subscription for changes which are affecting Subjects. On success, a 'SubscriptionUid' will be returned and a call will be made to the given subscriberUrl + '/ConfirmAsSubscriber'. After the subscription has been confirmed, the requested events will be pushed to subscriberUrl + '/NoticeChangedSubjects' (NOTICE: the receiving methods also are documented here, because this service itself can act as subscriber) </summary>
      /// <param name="subscriberUrl"> the root-url of the subscriber which needs to provide at least the methods '/ConfirmAsSubscriber' and '/NoticeChangedSubjects' </param>
      /// <param name="filter"> if provided, the subscription will only publish events for records matching to the given filter </param>
      public Guid SubscribeForChangedSubjects(string subscriberUrl, SubjectFilter filter = null) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "subscribeForChangedSubjects";
          var requestWrapper = new SubscribeForChangedSubjectsRequest {
            subscriberUrl = subscriberUrl,
            filter = filter
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<SubscribeForChangedSubjectsResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> Receives notifications about changes which are affecting Subjects. IMPORTANT: this method is dedicated to the usecase, when this service itself acts as a subscriber! So this can be called by an foreign service during the setup of a subscription, which was previously requested from here. The opposite case: any client subscribing to events from here, must provide its own http endpoint that has such a method! </summary>
      /// <param name="eventUid"> a UUID which identifies the current event message </param>
      /// <param name="eventSignature"> a SHA256 Hash of SubscriptionSecret + EventUid (in lower string representation, without '-' characters!) Sample: SHA256('ThEs3Cr3T'+'c997dfb1c445fea84afe995307713b59') = 'a320ef5b0f563e8dcb16d759961739977afc98b90628d9dc3be519fb20701490' </param>
      /// <param name="subscriptionUid"> a UUID which identifies the subscription for which this event is published </param>
      /// <param name="publisherUrl"> root-URL of the VDR-Service which is publishing this event </param>
      /// <param name="createdRecords"> an array, which contains one element per changed record </param>
      /// <param name="modifiedRecords"> an array, which contains one element per modified record </param>
      /// <param name="archivedRecords"> an array, which contains one element per archived record </param>
      /// <param name="terminateSubscription"> an array, which contains one element per changed record </param>
      public void NoticeChangedSubjects(Guid eventUid, string eventSignature, Guid subscriptionUid, string publisherUrl, SubjectMetaRecord[] createdRecords, SubjectMetaRecord[] modifiedRecords, SubjectMetaRecord[] archivedRecords, out bool terminateSubscription) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "noticeChangedSubjects";
          var requestWrapper = new NoticeChangedSubjectsRequest {
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
          var responseWrapper = JsonConvert.DeserializeObject<NoticeChangedSubjectsResponse>(rawResponse);
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
  
  namespace SubjectConsume {
    
    /// <summary> Provides an workflow-level API for interating with a 'SubjectDataRepository' (VDR) </summary>
    internal partial class SubjectConsumeClient : ISubjectConsumeService {
      
      private string _Url;
      private string _ApiToken;
      
      public SubjectConsumeClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> Searches Subjects by a given 'filter' (if provided), sorts the results by the given 'sortingField' (if provided) and returns an array of SubjectUids for the matching records. </summary>
      /// <param name="result">  </param>
      /// <param name="sortingField"> A fieldname, which should be used to sort the result (can also be a 'CustomField'). If not provided, the result will be sorted by the creation date of the records </param>
      /// <param name="sortDescending"> toggles the sorting direction </param>
      /// <param name="filter"> values by field name (can also be a 'CustomField') which will used as AND-linked filter </param>
      /// <param name="includeArchivedRecords"> includes archived records in the result </param>
      /// <param name="limitResults"> a value greather than zero will represent a maximum count of results, that sould be returned </param>
      public void SearchSubjects(out SubjectMetaRecord[] result, string sortingField = null, bool sortDescending = false, SubjectFilter filter = null, bool includeArchivedRecords = false, Int32 limitResults = 0) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "searchSubjects";
          var requestWrapper = new SearchSubjectsRequest {
            sortingField = sortingField,
            sortDescending = sortDescending,
            filter = filter,
            includeArchivedRecords = includeArchivedRecords,
            limitResults = limitResults,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<SearchSubjectsResponse>(rawResponse);
          result = responseWrapper.result;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> Searches Subjects which have been modified after(or at) the given 'minTimestampUtc', matching to the given 'filter' (if provided). The result is sorted descenting by the timestamp of the modification (latest first) and will include archived records. </summary>
      /// <param name="minTimestampUtc"> start of the timespan to search (as UNIX-Timestamp) </param>
      /// <param name="latestTimestampUtc"> the exact timestamp of the search (as UNIX-Timestamp) </param>
      /// <param name="createdRecords">  </param>
      /// <param name="modifiedRecords">  </param>
      /// <param name="archivedRecords">  </param>
      /// <param name="filter"> values by field name (can also be a 'CustomField') which will used as AND-linked filter </param>
      public void SearchChangedSubjects(Int64 minTimestampUtc, out Int64 latestTimestampUtc, out SubjectMetaRecord[] createdRecords, out SubjectMetaRecord[] modifiedRecords, out SubjectMetaRecord[] archivedRecords, SubjectFilter filter = null) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "searchChangedSubjects";
          var requestWrapper = new SearchChangedSubjectsRequest {
            minTimestampUtc = minTimestampUtc,
            filter = filter,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<SearchChangedSubjectsResponse>(rawResponse);
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
      
      /// <summary> GetCustomFieldDescriptorsForSubject </summary>
      /// <param name="languagePref"> Preferred language for the 'DisplayLabel' and 'InputDescription' fields of the returned descriptors. The default is 'EN'. </param>
      public CustomFieldDescriptor[] GetCustomFieldDescriptorsForSubject(string languagePref = "EN") {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getCustomFieldDescriptorsForSubject";
          var requestWrapper = new GetCustomFieldDescriptorsForSubjectRequest {
            languagePref = languagePref
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetCustomFieldDescriptorsForSubjectResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> Checks the existence of 'Subjects' for a given list of subjectUids </summary>
      /// <param name="subjectUids">  </param>
      /// <param name="unavailableSubjectUids">  </param>
      /// <param name="availableSubjectUids">  </param>
      public void CheckSubjectExisitence(Guid[] subjectUids, out Guid[] unavailableSubjectUids, out Guid[] availableSubjectUids) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "checkSubjectExisitence";
          var requestWrapper = new CheckSubjectExisitenceRequest {
            subjectUids = subjectUids,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<CheckSubjectExisitenceResponse>(rawResponse);
          unavailableSubjectUids = responseWrapper.unavailableSubjectUids;
          availableSubjectUids = responseWrapper.availableSubjectUids;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> loads the requested Subjects and returns lightweight json objects (without childs), which are optimized to be displayed as table (the most common UI use case). This models containig a combination of: essential fieds from the record, calculated fields (numbers of child records), custom fields (choosen by the service) </summary>
      /// <param name="subjectUids">  </param>
      /// <param name="unavailableSubjectUids">  </param>
      /// <param name="result">  </param>
      public void GetSubjectFields(Guid[] subjectUids, out Guid[] unavailableSubjectUids, out SubjectFields[] result) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getSubjectFields";
          var requestWrapper = new GetSubjectFieldsRequest {
            subjectUids = subjectUids,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetSubjectFieldsResponse>(rawResponse);
          unavailableSubjectUids = responseWrapper.unavailableSubjectUids;
          result = responseWrapper.result;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> exports full 'SubjectStructures' </summary>
      /// <param name="subjectUids">  </param>
      /// <param name="unavailableSubjectUids">  </param>
      /// <param name="result">  </param>
      public void ExportSubjects(Guid[] subjectUids, out Guid[] unavailableSubjectUids, out SubjectStructure[] result) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "exportSubjects";
          var requestWrapper = new ExportSubjectsRequest {
            subjectUids = subjectUids,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ExportSubjectsResponse>(rawResponse);
          unavailableSubjectUids = responseWrapper.unavailableSubjectUids;
          result = responseWrapper.result;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
    }
    
  }
  
  namespace SubjectHL7Export {
    
    /// <summary> Provides an workflow-level API for interating with a 'SubjectDataRepository' (VDR) </summary>
    internal partial class SubjectHL7ExportClient : ISubjectHL7ExportService {
      
      private string _Url;
      private string _ApiToken;
      
      public SubjectHL7ExportClient(string url, string apiToken) {
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
      /// <param name="subjectUid">  </param>
      /// <param name="subjectFhirRessources">  </param>
      public Boolean ExportSubjectFhirRessources(Guid subjectUid, out SubjectFhirRessourceContainer[] subjectFhirRessources) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "exportSubjectFhirRessources";
          var requestWrapper = new ExportSubjectFhirRessourcesRequest {
            subjectUid = subjectUid,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ExportSubjectFhirRessourcesResponse>(rawResponse);
          subjectFhirRessources = responseWrapper.subjectFhirRessources;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
    }
    
  }
  
  namespace SubjectHL7Import {
    
    /// <summary> Provides an workflow-level API for interating with a 'SubjectDataRepository' (VDR) </summary>
    internal partial class SubjectHL7ImportClient : ISubjectHL7ImportService {
      
      private string _Url;
      private string _ApiToken;
      
      public SubjectHL7ImportClient(string url, string apiToken) {
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
      /// <param name="subjectFhirRessources"> A structure containing HL7/FHIR-Ressources (JSON only) and the essential fields which are required to qualify a ORSCF record. </param>
      /// <param name="createdSubjectUids">  </param>
      /// <param name="updatedSubjectUids">  </param>
      public void ImportSubjectFhirRessources(SubjectFhirRessourceContainer[] subjectFhirRessources, out Guid[] createdSubjectUids, out Guid[] updatedSubjectUids) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "importSubjectFhirRessources";
          var requestWrapper = new ImportSubjectFhirRessourcesRequest {
            subjectFhirRessources = subjectFhirRessources,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ImportSubjectFhirRessourcesResponse>(rawResponse);
          createdSubjectUids = responseWrapper.createdSubjectUids;
          updatedSubjectUids = responseWrapper.updatedSubjectUids;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
    }
    
  }
  
  namespace SubjectSubmission {
    
    /// <summary> Provides an workflow-level API for interating with a 'SubjectDataRepository' (VDR) </summary>
    internal partial class SubjectSubmissionClient : ISubjectSubmissionService {
      
      private string _Url;
      private string _ApiToken;
      
      public SubjectSubmissionClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> ArchiveSubjects </summary>
      /// <param name="subjectUids">  </param>
      /// <param name="archivedSubjectUids"> also including the Uids of already archived records </param>
      public void ArchiveSubjects(Guid[] subjectUids, out Guid[] archivedSubjectUids) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "archiveSubjects";
          var requestWrapper = new ArchiveSubjectsRequest {
            subjectUids = subjectUids,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ArchiveSubjectsResponse>(rawResponse);
          archivedSubjectUids = responseWrapper.archivedSubjectUids;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> UnarchiveSubjects </summary>
      /// <param name="subjectUids">  </param>
      /// <param name="unarchivedSubjectUids">  </param>
      public void UnarchiveSubjects(Guid[] subjectUids, out Guid[] unarchivedSubjectUids) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "unarchiveSubjects";
          var requestWrapper = new UnarchiveSubjectsRequest {
            subjectUids = subjectUids,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<UnarchiveSubjectsResponse>(rawResponse);
          unarchivedSubjectUids = responseWrapper.unarchivedSubjectUids;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> ApplySubjectMutations </summary>
      /// <param name="mutationsBySubjecttUid">  </param>
      /// <param name="updatedSubjectUids">  </param>
      public void ApplySubjectMutations(Dictionary<Guid, SubjectMutation> mutationsBySubjecttUid, out Guid[] updatedSubjectUids) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "applySubjectMutations";
          var requestWrapper = new ApplySubjectMutationsRequest {
            mutationsBySubjecttUid = mutationsBySubjecttUid,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ApplySubjectMutationsResponse>(rawResponse);
          updatedSubjectUids = responseWrapper.updatedSubjectUids;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> ApplySubjectBatchMutation </summary>
      /// <param name="subjectUids">  </param>
      /// <param name="mutation">  </param>
      /// <param name="updatedSubjectUids">  </param>
      public void ApplySubjectBatchMutation(Guid[] subjectUids, BatchableSubjectMutation mutation, out Guid[] updatedSubjectUids) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "applySubjectBatchMutation";
          var requestWrapper = new ApplySubjectBatchMutationRequest {
            subjectUids = subjectUids,
            mutation = mutation,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ApplySubjectBatchMutationResponse>(rawResponse);
          updatedSubjectUids = responseWrapper.updatedSubjectUids;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> ImportSubjects </summary>
      /// <param name="subjects">  </param>
      /// <param name="createdSubjectUids">  </param>
      /// <param name="updatedSubjectUids">  </param>
      public void ImportSubjects(SubjectStructure[] subjects, out Guid[] createdSubjectUids, out Guid[] updatedSubjectUids) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "importSubjects";
          var requestWrapper = new ImportSubjectsRequest {
            subjects = subjects,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ImportSubjectsResponse>(rawResponse);
          createdSubjectUids = responseWrapper.createdSubjectUids;
          updatedSubjectUids = responseWrapper.updatedSubjectUids;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
    }
    
  }
  
}
