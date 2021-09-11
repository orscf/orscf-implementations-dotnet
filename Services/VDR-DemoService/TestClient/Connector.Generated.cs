using MedicalResearch.VisitData.WebAPI;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MedicalResearch.VisitData {
  
  public partial class VdrConnector {
    
    public VdrConnector(string url, string apiToken) {
      
      if (!url.EndsWith("/")) {
        url = url + "/";
      }
      
      _DataRecordingsClient = new DataRecordingsClient(url + "dataRecordings/", apiToken);
      _VisitsClient = new VisitsClient(url + "visits/", apiToken);
      _DrugApplymentsClient = new DrugApplymentsClient(url + "drugApplyments/", apiToken);
      _StudyEventsClient = new StudyEventsClient(url + "studyEvents/", apiToken);
      _StudyExecutionScopesClient = new StudyExecutionScopesClient(url + "studyExecutionScopes/", apiToken);
      _TreatmentsClient = new TreatmentsClient(url + "treatments/", apiToken);
      
    }
    
    private DataRecordingsClient _DataRecordingsClient = null;
    /// <summary> Provides CRUD access to stored DataRecordings (based on schema version '1.3.0') </summary>
    public IDataRecordings DataRecordings {
      get {
        return _DataRecordingsClient;
      }
    }
    
    private VisitsClient _VisitsClient = null;
    /// <summary> Provides CRUD access to stored Visits (based on schema version '1.3.0') </summary>
    public IVisits Visits {
      get {
        return _VisitsClient;
      }
    }
    
    private DrugApplymentsClient _DrugApplymentsClient = null;
    /// <summary> Provides CRUD access to stored DrugApplyments (based on schema version '1.3.0') </summary>
    public IDrugApplyments DrugApplyments {
      get {
        return _DrugApplymentsClient;
      }
    }
    
    private StudyEventsClient _StudyEventsClient = null;
    /// <summary> Provides CRUD access to stored StudyEvents (based on schema version '1.3.0') </summary>
    public IStudyEvents StudyEvents {
      get {
        return _StudyEventsClient;
      }
    }
    
    private StudyExecutionScopesClient _StudyExecutionScopesClient = null;
    /// <summary> Provides CRUD access to stored StudyExecutionScopes (based on schema version '1.3.0') </summary>
    public IStudyExecutionScopes StudyExecutionScopes {
      get {
        return _StudyExecutionScopesClient;
      }
    }
    
    private TreatmentsClient _TreatmentsClient = null;
    /// <summary> Provides CRUD access to stored Treatments (based on schema version '1.3.0') </summary>
    public ITreatments Treatments {
      get {
        return _TreatmentsClient;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored DataRecordings (based on schema version '1.3.0') </summary>
  internal partial class DataRecordingsClient : IDataRecordings {
    
    private string _Url;
    private string _ApiToken;
    
    public DataRecordingsClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific DataRecording addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
    public DataRecording GetDataRecordingByTaskGuid(Guid taskGuid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getDataRecordingByTaskGuid";
        var args = new GetDataRecordingByTaskGuidRequest {
          taskGuid = taskGuid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetDataRecordingByTaskGuidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads DataRecordings. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of DataRecordings which should be returned </param>
    public DataRecording[] GetDataRecordings(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getDataRecordings";
        var args = new GetDataRecordingsRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetDataRecordingsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads DataRecordings where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of DataRecordings which should be returned </param>
    public DataRecording[] SearchDataRecordings(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchDataRecordings";
        var args = new SearchDataRecordingsRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchDataRecordingsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new DataRecording and returns its primary identifier (or null on failure). </summary>
    /// <param name="dataRecording"> DataRecording containing the new values </param>
    public Boolean AddNewDataRecording(DataRecording dataRecording) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewDataRecording";
        var args = new AddNewDataRecordingRequest {
          dataRecording = dataRecording
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewDataRecordingResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DataRecording addressed by the primary identifier fields within the given DataRecording. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="dataRecording"> DataRecording containing the new values (the primary identifier fields within the given DataRecording will be used to address the target record) </param>
    public Boolean UpdateDataRecording(DataRecording dataRecording) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateDataRecording";
        var args = new UpdateDataRecordingRequest {
          dataRecording = dataRecording
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateDataRecordingResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DataRecording addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
    /// <param name="dataRecording"> DataRecording containing the new values (the primary identifier fields within the given DataRecording will be ignored) </param>
    public Boolean UpdateDataRecordingByTaskGuid(Guid taskGuid, DataRecording dataRecording) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateDataRecordingByTaskGuid";
        var args = new UpdateDataRecordingByTaskGuidRequest {
          taskGuid = taskGuid,
          dataRecording = dataRecording
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateDataRecordingByTaskGuidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific DataRecording addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
    public Boolean DeleteDataRecordingByTaskGuid(Guid taskGuid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteDataRecordingByTaskGuid";
        var args = new DeleteDataRecordingByTaskGuidRequest {
          taskGuid = taskGuid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteDataRecordingByTaskGuidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored Visits (based on schema version '1.3.0') </summary>
  internal partial class VisitsClient : IVisits {
    
    private string _Url;
    private string _ApiToken;
    
    public VisitsClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific Visit addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="visitGuid"> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </param>
    public Visit GetVisitByVisitGuid(Guid visitGuid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getVisitByVisitGuid";
        var args = new GetVisitByVisitGuidRequest {
          visitGuid = visitGuid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetVisitByVisitGuidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads Visits. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of Visits which should be returned </param>
    public Visit[] GetVisits(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getVisits";
        var args = new GetVisitsRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetVisitsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads Visits where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of Visits which should be returned </param>
    public Visit[] SearchVisits(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchVisits";
        var args = new SearchVisitsRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchVisitsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new Visit and returns its primary identifier (or null on failure). </summary>
    /// <param name="visit"> Visit containing the new values </param>
    public Boolean AddNewVisit(Visit visit) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewVisit";
        var args = new AddNewVisitRequest {
          visit = visit
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewVisitResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Visit addressed by the primary identifier fields within the given Visit. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="visit"> Visit containing the new values (the primary identifier fields within the given Visit will be used to address the target record) </param>
    public Boolean UpdateVisit(Visit visit) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateVisit";
        var args = new UpdateVisitRequest {
          visit = visit
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateVisitResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Visit addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="visitGuid"> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </param>
    /// <param name="visit"> Visit containing the new values (the primary identifier fields within the given Visit will be ignored) </param>
    public Boolean UpdateVisitByVisitGuid(Guid visitGuid, Visit visit) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateVisitByVisitGuid";
        var args = new UpdateVisitByVisitGuidRequest {
          visitGuid = visitGuid,
          visit = visit
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateVisitByVisitGuidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific Visit addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="visitGuid"> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </param>
    public Boolean DeleteVisitByVisitGuid(Guid visitGuid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteVisitByVisitGuid";
        var args = new DeleteVisitByVisitGuidRequest {
          visitGuid = visitGuid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteVisitByVisitGuidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored DrugApplyments (based on schema version '1.3.0') </summary>
  internal partial class DrugApplymentsClient : IDrugApplyments {
    
    private string _Url;
    private string _ApiToken;
    
    public DrugApplymentsClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific DrugApplyment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
    public DrugApplyment GetDrugApplymentByTaskGuid(Guid taskGuid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getDrugApplymentByTaskGuid";
        var args = new GetDrugApplymentByTaskGuidRequest {
          taskGuid = taskGuid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetDrugApplymentByTaskGuidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads DrugApplyments. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of DrugApplyments which should be returned </param>
    public DrugApplyment[] GetDrugApplyments(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getDrugApplyments";
        var args = new GetDrugApplymentsRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetDrugApplymentsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads DrugApplyments where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of DrugApplyments which should be returned </param>
    public DrugApplyment[] SearchDrugApplyments(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchDrugApplyments";
        var args = new SearchDrugApplymentsRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchDrugApplymentsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new DrugApplyment and returns its primary identifier (or null on failure). </summary>
    /// <param name="drugApplyment"> DrugApplyment containing the new values </param>
    public Boolean AddNewDrugApplyment(DrugApplyment drugApplyment) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewDrugApplyment";
        var args = new AddNewDrugApplymentRequest {
          drugApplyment = drugApplyment
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewDrugApplymentResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DrugApplyment addressed by the primary identifier fields within the given DrugApplyment. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="drugApplyment"> DrugApplyment containing the new values (the primary identifier fields within the given DrugApplyment will be used to address the target record) </param>
    public Boolean UpdateDrugApplyment(DrugApplyment drugApplyment) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateDrugApplyment";
        var args = new UpdateDrugApplymentRequest {
          drugApplyment = drugApplyment
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateDrugApplymentResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DrugApplyment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
    /// <param name="drugApplyment"> DrugApplyment containing the new values (the primary identifier fields within the given DrugApplyment will be ignored) </param>
    public Boolean UpdateDrugApplymentByTaskGuid(Guid taskGuid, DrugApplyment drugApplyment) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateDrugApplymentByTaskGuid";
        var args = new UpdateDrugApplymentByTaskGuidRequest {
          taskGuid = taskGuid,
          drugApplyment = drugApplyment
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateDrugApplymentByTaskGuidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific DrugApplyment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
    public Boolean DeleteDrugApplymentByTaskGuid(Guid taskGuid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteDrugApplymentByTaskGuid";
        var args = new DeleteDrugApplymentByTaskGuidRequest {
          taskGuid = taskGuid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteDrugApplymentByTaskGuidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored StudyEvents (based on schema version '1.3.0') </summary>
  internal partial class StudyEventsClient : IStudyEvents {
    
    private string _Url;
    private string _ApiToken;
    
    public StudyEventsClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific StudyEvent addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="eventGuid"> a global unique id of a concrete study-event occurrence which is usually originated at the primary CRF or study management system ('SMS') </param>
    public StudyEvent GetStudyEventByEventGuid(Guid eventGuid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getStudyEventByEventGuid";
        var args = new GetStudyEventByEventGuidRequest {
          eventGuid = eventGuid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetStudyEventByEventGuidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads StudyEvents. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of StudyEvents which should be returned </param>
    public StudyEvent[] GetStudyEvents(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getStudyEvents";
        var args = new GetStudyEventsRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetStudyEventsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads StudyEvents where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of StudyEvents which should be returned </param>
    public StudyEvent[] SearchStudyEvents(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchStudyEvents";
        var args = new SearchStudyEventsRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchStudyEventsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new StudyEvent and returns its primary identifier (or null on failure). </summary>
    /// <param name="studyEvent"> StudyEvent containing the new values </param>
    public Boolean AddNewStudyEvent(StudyEvent studyEvent) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewStudyEvent";
        var args = new AddNewStudyEventRequest {
          studyEvent = studyEvent
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewStudyEventResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyEvent addressed by the primary identifier fields within the given StudyEvent. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="studyEvent"> StudyEvent containing the new values (the primary identifier fields within the given StudyEvent will be used to address the target record) </param>
    public Boolean UpdateStudyEvent(StudyEvent studyEvent) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateStudyEvent";
        var args = new UpdateStudyEventRequest {
          studyEvent = studyEvent
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateStudyEventResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyEvent addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="eventGuid"> a global unique id of a concrete study-event occurrence which is usually originated at the primary CRF or study management system ('SMS') </param>
    /// <param name="studyEvent"> StudyEvent containing the new values (the primary identifier fields within the given StudyEvent will be ignored) </param>
    public Boolean UpdateStudyEventByEventGuid(Guid eventGuid, StudyEvent studyEvent) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateStudyEventByEventGuid";
        var args = new UpdateStudyEventByEventGuidRequest {
          eventGuid = eventGuid,
          studyEvent = studyEvent
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateStudyEventByEventGuidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific StudyEvent addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="eventGuid"> a global unique id of a concrete study-event occurrence which is usually originated at the primary CRF or study management system ('SMS') </param>
    public Boolean DeleteStudyEventByEventGuid(Guid eventGuid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteStudyEventByEventGuid";
        var args = new DeleteStudyEventByEventGuidRequest {
          eventGuid = eventGuid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteStudyEventByEventGuidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored StudyExecutionScopes (based on schema version '1.3.0') </summary>
  internal partial class StudyExecutionScopesClient : IStudyExecutionScopes {
    
    private string _Url;
    private string _ApiToken;
    
    public StudyExecutionScopesClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific StudyExecutionScope addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="studyExecutionIdentifier"> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </param>
    public StudyExecutionScope GetStudyExecutionScopeByStudyExecutionIdentifier(Guid studyExecutionIdentifier) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getStudyExecutionScopeByStudyExecutionIdentifier";
        var args = new GetStudyExecutionScopeByStudyExecutionIdentifierRequest {
          studyExecutionIdentifier = studyExecutionIdentifier
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetStudyExecutionScopeByStudyExecutionIdentifierResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads StudyExecutionScopes. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of StudyExecutionScopes which should be returned </param>
    public StudyExecutionScope[] GetStudyExecutionScopes(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getStudyExecutionScopes";
        var args = new GetStudyExecutionScopesRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetStudyExecutionScopesResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads StudyExecutionScopes where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of StudyExecutionScopes which should be returned </param>
    public StudyExecutionScope[] SearchStudyExecutionScopes(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchStudyExecutionScopes";
        var args = new SearchStudyExecutionScopesRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchStudyExecutionScopesResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new StudyExecutionScope and returns its primary identifier (or null on failure). </summary>
    /// <param name="studyExecutionScope"> StudyExecutionScope containing the new values </param>
    public Boolean AddNewStudyExecutionScope(StudyExecutionScope studyExecutionScope) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewStudyExecutionScope";
        var args = new AddNewStudyExecutionScopeRequest {
          studyExecutionScope = studyExecutionScope
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewStudyExecutionScopeResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyExecutionScope addressed by the primary identifier fields within the given StudyExecutionScope. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="studyExecutionScope"> StudyExecutionScope containing the new values (the primary identifier fields within the given StudyExecutionScope will be used to address the target record) </param>
    public Boolean UpdateStudyExecutionScope(StudyExecutionScope studyExecutionScope) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateStudyExecutionScope";
        var args = new UpdateStudyExecutionScopeRequest {
          studyExecutionScope = studyExecutionScope
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateStudyExecutionScopeResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyExecutionScope addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="studyExecutionIdentifier"> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </param>
    /// <param name="studyExecutionScope"> StudyExecutionScope containing the new values (the primary identifier fields within the given StudyExecutionScope will be ignored) </param>
    public Boolean UpdateStudyExecutionScopeByStudyExecutionIdentifier(Guid studyExecutionIdentifier, StudyExecutionScope studyExecutionScope) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateStudyExecutionScopeByStudyExecutionIdentifier";
        var args = new UpdateStudyExecutionScopeByStudyExecutionIdentifierRequest {
          studyExecutionIdentifier = studyExecutionIdentifier,
          studyExecutionScope = studyExecutionScope
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateStudyExecutionScopeByStudyExecutionIdentifierResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific StudyExecutionScope addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="studyExecutionIdentifier"> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </param>
    public Boolean DeleteStudyExecutionScopeByStudyExecutionIdentifier(Guid studyExecutionIdentifier) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteStudyExecutionScopeByStudyExecutionIdentifier";
        var args = new DeleteStudyExecutionScopeByStudyExecutionIdentifierRequest {
          studyExecutionIdentifier = studyExecutionIdentifier
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteStudyExecutionScopeByStudyExecutionIdentifierResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored Treatments (based on schema version '1.3.0') </summary>
  internal partial class TreatmentsClient : ITreatments {
    
    private string _Url;
    private string _ApiToken;
    
    public TreatmentsClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific Treatment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
    public Treatment GetTreatmentByTaskGuid(Guid taskGuid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getTreatmentByTaskGuid";
        var args = new GetTreatmentByTaskGuidRequest {
          taskGuid = taskGuid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetTreatmentByTaskGuidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads Treatments. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of Treatments which should be returned </param>
    public Treatment[] GetTreatments(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getTreatments";
        var args = new GetTreatmentsRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetTreatmentsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads Treatments where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of Treatments which should be returned </param>
    public Treatment[] SearchTreatments(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchTreatments";
        var args = new SearchTreatmentsRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchTreatmentsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new Treatment and returns its primary identifier (or null on failure). </summary>
    /// <param name="treatment"> Treatment containing the new values </param>
    public Boolean AddNewTreatment(Treatment treatment) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewTreatment";
        var args = new AddNewTreatmentRequest {
          treatment = treatment
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewTreatmentResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Treatment addressed by the primary identifier fields within the given Treatment. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="treatment"> Treatment containing the new values (the primary identifier fields within the given Treatment will be used to address the target record) </param>
    public Boolean UpdateTreatment(Treatment treatment) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateTreatment";
        var args = new UpdateTreatmentRequest {
          treatment = treatment
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateTreatmentResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Treatment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
    /// <param name="treatment"> Treatment containing the new values (the primary identifier fields within the given Treatment will be ignored) </param>
    public Boolean UpdateTreatmentByTaskGuid(Guid taskGuid, Treatment treatment) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateTreatmentByTaskGuid";
        var args = new UpdateTreatmentByTaskGuidRequest {
          taskGuid = taskGuid,
          treatment = treatment
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateTreatmentByTaskGuidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific Treatment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
    public Boolean DeleteTreatmentByTaskGuid(Guid taskGuid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteTreatmentByTaskGuid";
        var args = new DeleteTreatmentByTaskGuidRequest {
          taskGuid = taskGuid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteTreatmentByTaskGuidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
}
