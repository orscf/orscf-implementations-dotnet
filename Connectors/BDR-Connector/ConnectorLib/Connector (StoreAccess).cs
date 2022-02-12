/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.BillingData.Model;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MedicalResearch.BillingData.StoreAccess {
  
  public partial class BdrStoreConnector {
    
    public BdrStoreConnector(string url, string apiToken) {
      
      if (!url.EndsWith("/")) {
        url = url + "/";
      }
      
      _BillableTasksClient = new BillableTasksClient(url + "billableTasks/", apiToken);
      _BillableVisitsClient = new BillableVisitsClient(url + "billableVisits/", apiToken);
      _StudyExecutionScopesClient = new StudyExecutionScopesClient(url + "studyExecutionScopes/", apiToken);
      _BillingDemandsClient = new BillingDemandsClient(url + "billingDemands/", apiToken);
      _InvoicesClient = new InvoicesClient(url + "invoices/", apiToken);
      
    }
    
    private BillableTasksClient _BillableTasksClient = null;
    /// <summary> Provides CRUD access to stored BillableTasks (based on schema version '1.5.0') </summary>
    public IBillableTasks BillableTasks {
      get {
        return _BillableTasksClient;
      }
    }
    
    private BillableVisitsClient _BillableVisitsClient = null;
    /// <summary> Provides CRUD access to stored BillableVisits (based on schema version '1.5.0') </summary>
    public IBillableVisits BillableVisits {
      get {
        return _BillableVisitsClient;
      }
    }
    
    private StudyExecutionScopesClient _StudyExecutionScopesClient = null;
    /// <summary> Provides CRUD access to stored StudyExecutionScopes (based on schema version '1.5.0') </summary>
    public IStudyExecutionScopes StudyExecutionScopes {
      get {
        return _StudyExecutionScopesClient;
      }
    }
    
    private BillingDemandsClient _BillingDemandsClient = null;
    /// <summary> Provides CRUD access to stored BillingDemands (based on schema version '1.5.0') </summary>
    public IBillingDemands BillingDemands {
      get {
        return _BillingDemandsClient;
      }
    }
    
    private InvoicesClient _InvoicesClient = null;
    /// <summary> Provides CRUD access to stored Invoices (based on schema version '1.5.0') </summary>
    public IInvoices Invoices {
      get {
        return _InvoicesClient;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored BillableTasks (based on schema version '1.5.0') </summary>
  internal partial class BillableTasksClient : IBillableTasks {
    
    private string _Url;
    private string _ApiToken;
    
    public BillableTasksClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific BillableTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
    public BillableTask GetBillableTaskByTaskGuid(Guid taskGuid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getBillableTaskByTaskGuid";
        var requestWrapper = new GetBillableTaskByTaskGuidRequest {
          taskGuid = taskGuid
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<GetBillableTaskByTaskGuidResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Loads BillableTasks. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of BillableTasks which should be returned </param>
    public BillableTask[] GetBillableTasks(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getBillableTasks";
        var requestWrapper = new GetBillableTasksRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<GetBillableTasksResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Loads BillableTasks where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of BillableTasks which should be returned </param>
    public BillableTask[] SearchBillableTasks(string filterExpression, string sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchBillableTasks";
        var requestWrapper = new SearchBillableTasksRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<SearchBillableTasksResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Adds a new BillableTask and returns its primary identifier (or null on failure). </summary>
    /// <param name="billableTask"> BillableTask containing the new values </param>
    public Boolean AddNewBillableTask(BillableTask billableTask) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewBillableTask";
        var requestWrapper = new AddNewBillableTaskRequest {
          billableTask = billableTask
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<AddNewBillableTaskResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillableTask addressed by the primary identifier fields within the given BillableTask. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="billableTask"> BillableTask containing the new values (the primary identifier fields within the given BillableTask will be used to address the target record) </param>
    public Boolean UpdateBillableTask(BillableTask billableTask) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateBillableTask";
        var requestWrapper = new UpdateBillableTaskRequest {
          billableTask = billableTask
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<UpdateBillableTaskResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillableTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
    /// <param name="billableTask"> BillableTask containing the new values (the primary identifier fields within the given BillableTask will be ignored) </param>
    public Boolean UpdateBillableTaskByTaskGuid(Guid taskGuid, BillableTask billableTask) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateBillableTaskByTaskGuid";
        var requestWrapper = new UpdateBillableTaskByTaskGuidRequest {
          taskGuid = taskGuid,
          billableTask = billableTask
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<UpdateBillableTaskByTaskGuidResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Deletes a specific BillableTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
    public Boolean DeleteBillableTaskByTaskGuid(Guid taskGuid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteBillableTaskByTaskGuid";
        var requestWrapper = new DeleteBillableTaskByTaskGuidRequest {
          taskGuid = taskGuid
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<DeleteBillableTaskByTaskGuidResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored BillableVisits (based on schema version '1.5.0') </summary>
  internal partial class BillableVisitsClient : IBillableVisits {
    
    private string _Url;
    private string _ApiToken;
    
    public BillableVisitsClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific BillableVisit addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="visitGuid"> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </param>
    public BillableVisit GetBillableVisitByVisitGuid(Guid visitGuid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getBillableVisitByVisitGuid";
        var requestWrapper = new GetBillableVisitByVisitGuidRequest {
          visitGuid = visitGuid
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<GetBillableVisitByVisitGuidResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Loads BillableVisits. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of BillableVisits which should be returned </param>
    public BillableVisit[] GetBillableVisits(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getBillableVisits";
        var requestWrapper = new GetBillableVisitsRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<GetBillableVisitsResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Loads BillableVisits where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of BillableVisits which should be returned </param>
    public BillableVisit[] SearchBillableVisits(string filterExpression, string sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchBillableVisits";
        var requestWrapper = new SearchBillableVisitsRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<SearchBillableVisitsResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Adds a new BillableVisit and returns its primary identifier (or null on failure). </summary>
    /// <param name="billableVisit"> BillableVisit containing the new values </param>
    public Boolean AddNewBillableVisit(BillableVisit billableVisit) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewBillableVisit";
        var requestWrapper = new AddNewBillableVisitRequest {
          billableVisit = billableVisit
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<AddNewBillableVisitResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillableVisit addressed by the primary identifier fields within the given BillableVisit. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="billableVisit"> BillableVisit containing the new values (the primary identifier fields within the given BillableVisit will be used to address the target record) </param>
    public Boolean UpdateBillableVisit(BillableVisit billableVisit) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateBillableVisit";
        var requestWrapper = new UpdateBillableVisitRequest {
          billableVisit = billableVisit
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<UpdateBillableVisitResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillableVisit addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="visitGuid"> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </param>
    /// <param name="billableVisit"> BillableVisit containing the new values (the primary identifier fields within the given BillableVisit will be ignored) </param>
    public Boolean UpdateBillableVisitByVisitGuid(Guid visitGuid, BillableVisit billableVisit) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateBillableVisitByVisitGuid";
        var requestWrapper = new UpdateBillableVisitByVisitGuidRequest {
          visitGuid = visitGuid,
          billableVisit = billableVisit
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<UpdateBillableVisitByVisitGuidResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Deletes a specific BillableVisit addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="visitGuid"> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </param>
    public Boolean DeleteBillableVisitByVisitGuid(Guid visitGuid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteBillableVisitByVisitGuid";
        var requestWrapper = new DeleteBillableVisitByVisitGuidRequest {
          visitGuid = visitGuid
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<DeleteBillableVisitByVisitGuidResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored StudyExecutionScopes (based on schema version '1.5.0') </summary>
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
        var requestWrapper = new GetStudyExecutionScopeByStudyExecutionIdentifierRequest {
          studyExecutionIdentifier = studyExecutionIdentifier
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<GetStudyExecutionScopeByStudyExecutionIdentifierResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Loads StudyExecutionScopes. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of StudyExecutionScopes which should be returned </param>
    public StudyExecutionScope[] GetStudyExecutionScopes(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getStudyExecutionScopes";
        var requestWrapper = new GetStudyExecutionScopesRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<GetStudyExecutionScopesResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Loads StudyExecutionScopes where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of StudyExecutionScopes which should be returned </param>
    public StudyExecutionScope[] SearchStudyExecutionScopes(string filterExpression, string sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchStudyExecutionScopes";
        var requestWrapper = new SearchStudyExecutionScopesRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<SearchStudyExecutionScopesResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Adds a new StudyExecutionScope and returns its primary identifier (or null on failure). </summary>
    /// <param name="studyExecutionScope"> StudyExecutionScope containing the new values </param>
    public Boolean AddNewStudyExecutionScope(StudyExecutionScope studyExecutionScope) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewStudyExecutionScope";
        var requestWrapper = new AddNewStudyExecutionScopeRequest {
          studyExecutionScope = studyExecutionScope
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<AddNewStudyExecutionScopeResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyExecutionScope addressed by the primary identifier fields within the given StudyExecutionScope. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="studyExecutionScope"> StudyExecutionScope containing the new values (the primary identifier fields within the given StudyExecutionScope will be used to address the target record) </param>
    public Boolean UpdateStudyExecutionScope(StudyExecutionScope studyExecutionScope) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateStudyExecutionScope";
        var requestWrapper = new UpdateStudyExecutionScopeRequest {
          studyExecutionScope = studyExecutionScope
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<UpdateStudyExecutionScopeResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyExecutionScope addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="studyExecutionIdentifier"> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </param>
    /// <param name="studyExecutionScope"> StudyExecutionScope containing the new values (the primary identifier fields within the given StudyExecutionScope will be ignored) </param>
    public Boolean UpdateStudyExecutionScopeByStudyExecutionIdentifier(Guid studyExecutionIdentifier, StudyExecutionScope studyExecutionScope) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateStudyExecutionScopeByStudyExecutionIdentifier";
        var requestWrapper = new UpdateStudyExecutionScopeByStudyExecutionIdentifierRequest {
          studyExecutionIdentifier = studyExecutionIdentifier,
          studyExecutionScope = studyExecutionScope
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<UpdateStudyExecutionScopeByStudyExecutionIdentifierResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Deletes a specific StudyExecutionScope addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="studyExecutionIdentifier"> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </param>
    public Boolean DeleteStudyExecutionScopeByStudyExecutionIdentifier(Guid studyExecutionIdentifier) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteStudyExecutionScopeByStudyExecutionIdentifier";
        var requestWrapper = new DeleteStudyExecutionScopeByStudyExecutionIdentifierRequest {
          studyExecutionIdentifier = studyExecutionIdentifier
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<DeleteStudyExecutionScopeByStudyExecutionIdentifierResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored BillingDemands (based on schema version '1.5.0') </summary>
  internal partial class BillingDemandsClient : IBillingDemands {
    
    private string _Url;
    private string _ApiToken;
    
    public BillingDemandsClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific BillingDemand addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="id"> Represents the primary identity of a BillingDemand </param>
    public BillingDemand GetBillingDemandById(Guid id) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getBillingDemandById";
        var requestWrapper = new GetBillingDemandByIdRequest {
          id = id
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<GetBillingDemandByIdResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Loads BillingDemands. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of BillingDemands which should be returned </param>
    public BillingDemand[] GetBillingDemands(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getBillingDemands";
        var requestWrapper = new GetBillingDemandsRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<GetBillingDemandsResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Loads BillingDemands where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of BillingDemands which should be returned </param>
    public BillingDemand[] SearchBillingDemands(string filterExpression, string sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchBillingDemands";
        var requestWrapper = new SearchBillingDemandsRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<SearchBillingDemandsResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Adds a new BillingDemand and returns its primary identifier (or null on failure). </summary>
    /// <param name="billingDemand"> BillingDemand containing the new values </param>
    public Boolean AddNewBillingDemand(BillingDemand billingDemand) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewBillingDemand";
        var requestWrapper = new AddNewBillingDemandRequest {
          billingDemand = billingDemand
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<AddNewBillingDemandResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillingDemand addressed by the primary identifier fields within the given BillingDemand. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="billingDemand"> BillingDemand containing the new values (the primary identifier fields within the given BillingDemand will be used to address the target record) </param>
    public Boolean UpdateBillingDemand(BillingDemand billingDemand) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateBillingDemand";
        var requestWrapper = new UpdateBillingDemandRequest {
          billingDemand = billingDemand
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<UpdateBillingDemandResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillingDemand addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="id"> Represents the primary identity of a BillingDemand </param>
    /// <param name="billingDemand"> BillingDemand containing the new values (the primary identifier fields within the given BillingDemand will be ignored) </param>
    public Boolean UpdateBillingDemandById(Guid id, BillingDemand billingDemand) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateBillingDemandById";
        var requestWrapper = new UpdateBillingDemandByIdRequest {
          id = id,
          billingDemand = billingDemand
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<UpdateBillingDemandByIdResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Deletes a specific BillingDemand addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="id"> Represents the primary identity of a BillingDemand </param>
    public Boolean DeleteBillingDemandById(Guid id) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteBillingDemandById";
        var requestWrapper = new DeleteBillingDemandByIdRequest {
          id = id
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<DeleteBillingDemandByIdResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored Invoices (based on schema version '1.5.0') </summary>
  internal partial class InvoicesClient : IInvoices {
    
    private string _Url;
    private string _ApiToken;
    
    public InvoicesClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific Invoice addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="id"> Represents the primary identity of a Invoice </param>
    public Invoice GetInvoiceById(Guid id) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getInvoiceById";
        var requestWrapper = new GetInvoiceByIdRequest {
          id = id
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<GetInvoiceByIdResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Loads Invoices. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of Invoices which should be returned </param>
    public Invoice[] GetInvoices(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getInvoices";
        var requestWrapper = new GetInvoicesRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<GetInvoicesResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Loads Invoices where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of Invoices which should be returned </param>
    public Invoice[] SearchInvoices(string filterExpression, string sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchInvoices";
        var requestWrapper = new SearchInvoicesRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<SearchInvoicesResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Adds a new Invoice and returns its primary identifier (or null on failure). </summary>
    /// <param name="invoice"> Invoice containing the new values </param>
    public Boolean AddNewInvoice(Invoice invoice) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewInvoice";
        var requestWrapper = new AddNewInvoiceRequest {
          invoice = invoice
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<AddNewInvoiceResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Invoice addressed by the primary identifier fields within the given Invoice. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="invoice"> Invoice containing the new values (the primary identifier fields within the given Invoice will be used to address the target record) </param>
    public Boolean UpdateInvoice(Invoice invoice) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateInvoice";
        var requestWrapper = new UpdateInvoiceRequest {
          invoice = invoice
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<UpdateInvoiceResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Invoice addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="id"> Represents the primary identity of a Invoice </param>
    /// <param name="invoice"> Invoice containing the new values (the primary identifier fields within the given Invoice will be ignored) </param>
    public Boolean UpdateInvoiceById(Guid id, Invoice invoice) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateInvoiceById";
        var requestWrapper = new UpdateInvoiceByIdRequest {
          id = id,
          invoice = invoice
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<UpdateInvoiceByIdResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Deletes a specific Invoice addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="id"> Represents the primary identity of a Invoice </param>
    public Boolean DeleteInvoiceById(Guid id) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteInvoiceById";
        var requestWrapper = new DeleteInvoiceByIdRequest {
          id = id
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<DeleteInvoiceByIdResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
  }
  
}
