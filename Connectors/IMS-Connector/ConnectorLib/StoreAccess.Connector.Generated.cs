using MedicalResearch.IdentityManagement.Model;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MedicalResearch.IdentityManagement.StoreAccess {
  
  public partial class ImsStoreConnector {
    
    public ImsStoreConnector(string url, string apiToken) {
      
      if (!url.EndsWith("/")) {
        url = url + "/";
      }
      
      _AdditionalSubjectParticipationIdentifiersClient = new AdditionalSubjectParticipationIdentifiersClient(url + "additionalSubjectParticipationIdentifiers/", apiToken);
      _SubjectParticipationsClient = new SubjectParticipationsClient(url + "subjectParticipations/", apiToken);
      _StudyExecutionScopesClient = new StudyExecutionScopesClient(url + "studyExecutionScopes/", apiToken);
      _StudyScopesClient = new StudyScopesClient(url + "studyScopes/", apiToken);
      _SubjectAddressesClient = new SubjectAddressesClient(url + "subjectAddresses/", apiToken);
      _SubjectIdentitiesClient = new SubjectIdentitiesClient(url + "subjectIdentities/", apiToken);
      
    }
    
    private AdditionalSubjectParticipationIdentifiersClient _AdditionalSubjectParticipationIdentifiersClient = null;
    /// <summary> Provides CRUD access to stored AdditionalSubjectParticipationIdentifiers (based on schema version '1.5.0') </summary>
    public IAdditionalSubjectParticipationIdentifiers AdditionalSubjectParticipationIdentifiers {
      get {
        return _AdditionalSubjectParticipationIdentifiersClient;
      }
    }
    
    private SubjectParticipationsClient _SubjectParticipationsClient = null;
    /// <summary> Provides CRUD access to stored SubjectParticipations (based on schema version '1.5.0') </summary>
    public ISubjectParticipations SubjectParticipations {
      get {
        return _SubjectParticipationsClient;
      }
    }
    
    private StudyExecutionScopesClient _StudyExecutionScopesClient = null;
    /// <summary> Provides CRUD access to stored StudyExecutionScopes (based on schema version '1.5.0') </summary>
    public IStudyExecutionScopes StudyExecutionScopes {
      get {
        return _StudyExecutionScopesClient;
      }
    }
    
    private StudyScopesClient _StudyScopesClient = null;
    /// <summary> Provides CRUD access to stored StudyScopes (based on schema version '1.5.0') </summary>
    public IStudyScopes StudyScopes {
      get {
        return _StudyScopesClient;
      }
    }
    
    private SubjectAddressesClient _SubjectAddressesClient = null;
    /// <summary> Provides CRUD access to stored SubjectAddresses (based on schema version '1.5.0') </summary>
    public ISubjectAddresses SubjectAddresses {
      get {
        return _SubjectAddressesClient;
      }
    }
    
    private SubjectIdentitiesClient _SubjectIdentitiesClient = null;
    /// <summary> Provides CRUD access to stored SubjectIdentities (based on schema version '1.5.0') </summary>
    public ISubjectIdentities SubjectIdentities {
      get {
        return _SubjectIdentitiesClient;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored AdditionalSubjectParticipationIdentifiers (based on schema version '1.5.0') </summary>
  internal partial class AdditionalSubjectParticipationIdentifiersClient : IAdditionalSubjectParticipationIdentifiers {
    
    private string _Url;
    private string _ApiToken;
    
    public AdditionalSubjectParticipationIdentifiersClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific AdditionalSubjectParticipationIdentifier addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="additionalSubjectParticipationIdentifierIdentity"> Composite Key, which represents the primary identity of a AdditionalSubjectParticipationIdentifier </param>
    public AdditionalSubjectParticipationIdentifier GetAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity(AdditionalSubjectParticipationIdentifierIdentity additionalSubjectParticipationIdentifierIdentity) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity";
        var args = new GetAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityRequest {
          additionalSubjectParticipationIdentifierIdentity = additionalSubjectParticipationIdentifierIdentity
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads AdditionalSubjectParticipationIdentifiers. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of AdditionalSubjectParticipationIdentifiers which should be returned </param>
    public AdditionalSubjectParticipationIdentifier[] GetAdditionalSubjectParticipationIdentifiers(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getAdditionalSubjectParticipationIdentifiers";
        var args = new GetAdditionalSubjectParticipationIdentifiersRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetAdditionalSubjectParticipationIdentifiersResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads AdditionalSubjectParticipationIdentifiers where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of AdditionalSubjectParticipationIdentifiers which should be returned </param>
    public AdditionalSubjectParticipationIdentifier[] SearchAdditionalSubjectParticipationIdentifiers(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchAdditionalSubjectParticipationIdentifiers";
        var args = new SearchAdditionalSubjectParticipationIdentifiersRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchAdditionalSubjectParticipationIdentifiersResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new AdditionalSubjectParticipationIdentifier and returns its primary identifier (or null on failure). </summary>
    /// <param name="additionalSubjectParticipationIdentifier"> AdditionalSubjectParticipationIdentifier containing the new values </param>
    public Boolean AddNewAdditionalSubjectParticipationIdentifier(AdditionalSubjectParticipationIdentifier additionalSubjectParticipationIdentifier) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewAdditionalSubjectParticipationIdentifier";
        var args = new AddNewAdditionalSubjectParticipationIdentifierRequest {
          additionalSubjectParticipationIdentifier = additionalSubjectParticipationIdentifier
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewAdditionalSubjectParticipationIdentifierResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given AdditionalSubjectParticipationIdentifier addressed by the primary identifier fields within the given AdditionalSubjectParticipationIdentifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="additionalSubjectParticipationIdentifier"> AdditionalSubjectParticipationIdentifier containing the new values (the primary identifier fields within the given AdditionalSubjectParticipationIdentifier will be used to address the target record) </param>
    public Boolean UpdateAdditionalSubjectParticipationIdentifier(AdditionalSubjectParticipationIdentifier additionalSubjectParticipationIdentifier) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateAdditionalSubjectParticipationIdentifier";
        var args = new UpdateAdditionalSubjectParticipationIdentifierRequest {
          additionalSubjectParticipationIdentifier = additionalSubjectParticipationIdentifier
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateAdditionalSubjectParticipationIdentifierResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given AdditionalSubjectParticipationIdentifier addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="additionalSubjectParticipationIdentifierIdentity"> Composite Key, which represents the primary identity of a AdditionalSubjectParticipationIdentifier </param>
    /// <param name="additionalSubjectParticipationIdentifier"> AdditionalSubjectParticipationIdentifier containing the new values (the primary identifier fields within the given AdditionalSubjectParticipationIdentifier will be ignored) </param>
    public Boolean UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity(AdditionalSubjectParticipationIdentifierIdentity additionalSubjectParticipationIdentifierIdentity, AdditionalSubjectParticipationIdentifier additionalSubjectParticipationIdentifier) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity";
        var args = new UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityRequest {
          additionalSubjectParticipationIdentifierIdentity = additionalSubjectParticipationIdentifierIdentity,
          additionalSubjectParticipationIdentifier = additionalSubjectParticipationIdentifier
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific AdditionalSubjectParticipationIdentifier addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="additionalSubjectParticipationIdentifierIdentity"> Composite Key, which represents the primary identity of a AdditionalSubjectParticipationIdentifier </param>
    public Boolean DeleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity(AdditionalSubjectParticipationIdentifierIdentity additionalSubjectParticipationIdentifierIdentity) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity";
        var args = new DeleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityRequest {
          additionalSubjectParticipationIdentifierIdentity = additionalSubjectParticipationIdentifierIdentity
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored SubjectParticipations (based on schema version '1.5.0') </summary>
  internal partial class SubjectParticipationsClient : ISubjectParticipations {
    
    private string _Url;
    private string _ApiToken;
    
    public SubjectParticipationsClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific SubjectParticipation addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="participantIdentifier"> identity of the patient which can be a randomization or screening number (the exact semantic is defined per study) </param>
    public SubjectParticipation GetSubjectParticipationByParticipantIdentifier(String participantIdentifier) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getSubjectParticipationByParticipantIdentifier";
        var args = new GetSubjectParticipationByParticipantIdentifierRequest {
          participantIdentifier = participantIdentifier
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetSubjectParticipationByParticipantIdentifierResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads SubjectParticipations. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of SubjectParticipations which should be returned </param>
    public SubjectParticipation[] GetSubjectParticipations(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getSubjectParticipations";
        var args = new GetSubjectParticipationsRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetSubjectParticipationsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads SubjectParticipations where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of SubjectParticipations which should be returned </param>
    public SubjectParticipation[] SearchSubjectParticipations(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchSubjectParticipations";
        var args = new SearchSubjectParticipationsRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchSubjectParticipationsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new SubjectParticipation and returns its primary identifier (or null on failure). </summary>
    /// <param name="subjectParticipation"> SubjectParticipation containing the new values </param>
    public Boolean AddNewSubjectParticipation(SubjectParticipation subjectParticipation) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewSubjectParticipation";
        var args = new AddNewSubjectParticipationRequest {
          subjectParticipation = subjectParticipation
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewSubjectParticipationResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectParticipation addressed by the primary identifier fields within the given SubjectParticipation. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="subjectParticipation"> SubjectParticipation containing the new values (the primary identifier fields within the given SubjectParticipation will be used to address the target record) </param>
    public Boolean UpdateSubjectParticipation(SubjectParticipation subjectParticipation) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateSubjectParticipation";
        var args = new UpdateSubjectParticipationRequest {
          subjectParticipation = subjectParticipation
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateSubjectParticipationResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectParticipation addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="participantIdentifier"> identity of the patient which can be a randomization or screening number (the exact semantic is defined per study) </param>
    /// <param name="subjectParticipation"> SubjectParticipation containing the new values (the primary identifier fields within the given SubjectParticipation will be ignored) </param>
    public Boolean UpdateSubjectParticipationByParticipantIdentifier(String participantIdentifier, SubjectParticipation subjectParticipation) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateSubjectParticipationByParticipantIdentifier";
        var args = new UpdateSubjectParticipationByParticipantIdentifierRequest {
          participantIdentifier = participantIdentifier,
          subjectParticipation = subjectParticipation
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateSubjectParticipationByParticipantIdentifierResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific SubjectParticipation addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="participantIdentifier"> identity of the patient which can be a randomization or screening number (the exact semantic is defined per study) </param>
    public Boolean DeleteSubjectParticipationByParticipantIdentifier(String participantIdentifier) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteSubjectParticipationByParticipantIdentifier";
        var args = new DeleteSubjectParticipationByParticipantIdentifierRequest {
          participantIdentifier = participantIdentifier
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteSubjectParticipationByParticipantIdentifierResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
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
  
  /// <summary> Provides CRUD access to stored StudyScopes (based on schema version '1.5.0') </summary>
  internal partial class StudyScopesClient : IStudyScopes {
    
    private string _Url;
    private string _ApiToken;
    
    public StudyScopesClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific StudyScope addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="studyScopeIdentity"> Composite Key, which represents the primary identity of a StudyScope </param>
    public StudyScope GetStudyScopeByStudyScopeIdentity(StudyScopeIdentity studyScopeIdentity) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getStudyScopeByStudyScopeIdentity";
        var args = new GetStudyScopeByStudyScopeIdentityRequest {
          studyScopeIdentity = studyScopeIdentity
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetStudyScopeByStudyScopeIdentityResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads StudyScopes. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of StudyScopes which should be returned </param>
    public StudyScope[] GetStudyScopes(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getStudyScopes";
        var args = new GetStudyScopesRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetStudyScopesResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads StudyScopes where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of StudyScopes which should be returned </param>
    public StudyScope[] SearchStudyScopes(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchStudyScopes";
        var args = new SearchStudyScopesRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchStudyScopesResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new StudyScope and returns its primary identifier (or null on failure). </summary>
    /// <param name="studyScope"> StudyScope containing the new values </param>
    public Boolean AddNewStudyScope(StudyScope studyScope) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewStudyScope";
        var args = new AddNewStudyScopeRequest {
          studyScope = studyScope
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewStudyScopeResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyScope addressed by the primary identifier fields within the given StudyScope. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="studyScope"> StudyScope containing the new values (the primary identifier fields within the given StudyScope will be used to address the target record) </param>
    public Boolean UpdateStudyScope(StudyScope studyScope) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateStudyScope";
        var args = new UpdateStudyScopeRequest {
          studyScope = studyScope
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateStudyScopeResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyScope addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="studyScopeIdentity"> Composite Key, which represents the primary identity of a StudyScope </param>
    /// <param name="studyScope"> StudyScope containing the new values (the primary identifier fields within the given StudyScope will be ignored) </param>
    public Boolean UpdateStudyScopeByStudyScopeIdentity(StudyScopeIdentity studyScopeIdentity, StudyScope studyScope) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateStudyScopeByStudyScopeIdentity";
        var args = new UpdateStudyScopeByStudyScopeIdentityRequest {
          studyScopeIdentity = studyScopeIdentity,
          studyScope = studyScope
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateStudyScopeByStudyScopeIdentityResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific StudyScope addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="studyScopeIdentity"> Composite Key, which represents the primary identity of a StudyScope </param>
    public Boolean DeleteStudyScopeByStudyScopeIdentity(StudyScopeIdentity studyScopeIdentity) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteStudyScopeByStudyScopeIdentity";
        var args = new DeleteStudyScopeByStudyScopeIdentityRequest {
          studyScopeIdentity = studyScopeIdentity
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteStudyScopeByStudyScopeIdentityResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored SubjectAddresses (based on schema version '1.5.0') </summary>
  internal partial class SubjectAddressesClient : ISubjectAddresses {
    
    private string _Url;
    private string _ApiToken;
    
    public SubjectAddressesClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific SubjectAddress addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="internalRecordId"> Represents the primary identity of a SubjectAddress </param>
    public SubjectAddress GetSubjectAddressByInternalRecordId(Guid internalRecordId) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getSubjectAddressByInternalRecordId";
        var args = new GetSubjectAddressByInternalRecordIdRequest {
          internalRecordId = internalRecordId
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetSubjectAddressByInternalRecordIdResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads SubjectAddresses. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of SubjectAddresses which should be returned </param>
    public SubjectAddress[] GetSubjectAddresses(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getSubjectAddresses";
        var args = new GetSubjectAddressesRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetSubjectAddressesResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads SubjectAddresses where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of SubjectAddresses which should be returned </param>
    public SubjectAddress[] SearchSubjectAddresses(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchSubjectAddresses";
        var args = new SearchSubjectAddressesRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchSubjectAddressesResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new SubjectAddress and returns its primary identifier (or null on failure). </summary>
    /// <param name="subjectAddress"> SubjectAddress containing the new values </param>
    public Boolean AddNewSubjectAddress(SubjectAddress subjectAddress) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewSubjectAddress";
        var args = new AddNewSubjectAddressRequest {
          subjectAddress = subjectAddress
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewSubjectAddressResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectAddress addressed by the primary identifier fields within the given SubjectAddress. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="subjectAddress"> SubjectAddress containing the new values (the primary identifier fields within the given SubjectAddress will be used to address the target record) </param>
    public Boolean UpdateSubjectAddress(SubjectAddress subjectAddress) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateSubjectAddress";
        var args = new UpdateSubjectAddressRequest {
          subjectAddress = subjectAddress
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateSubjectAddressResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectAddress addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="internalRecordId"> Represents the primary identity of a SubjectAddress </param>
    /// <param name="subjectAddress"> SubjectAddress containing the new values (the primary identifier fields within the given SubjectAddress will be ignored) </param>
    public Boolean UpdateSubjectAddressByInternalRecordId(Guid internalRecordId, SubjectAddress subjectAddress) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateSubjectAddressByInternalRecordId";
        var args = new UpdateSubjectAddressByInternalRecordIdRequest {
          internalRecordId = internalRecordId,
          subjectAddress = subjectAddress
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateSubjectAddressByInternalRecordIdResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific SubjectAddress addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="internalRecordId"> Represents the primary identity of a SubjectAddress </param>
    public Boolean DeleteSubjectAddressByInternalRecordId(Guid internalRecordId) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteSubjectAddressByInternalRecordId";
        var args = new DeleteSubjectAddressByInternalRecordIdRequest {
          internalRecordId = internalRecordId
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteSubjectAddressByInternalRecordIdResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored SubjectIdentities (based on schema version '1.5.0') </summary>
  internal partial class SubjectIdentitiesClient : ISubjectIdentities {
    
    private string _Url;
    private string _ApiToken;
    
    public SubjectIdentitiesClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific SubjectIdentity addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="recordId"> Represents the primary identity of a SubjectIdentity </param>
    public SubjectIdentity GetSubjectIdentityByRecordId(Guid recordId) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getSubjectIdentityByRecordId";
        var args = new GetSubjectIdentityByRecordIdRequest {
          recordId = recordId
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetSubjectIdentityByRecordIdResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads SubjectIdentities. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of SubjectIdentities which should be returned </param>
    public SubjectIdentity[] GetSubjectIdentities(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getSubjectIdentities";
        var args = new GetSubjectIdentitiesRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetSubjectIdentitiesResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads SubjectIdentities where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of SubjectIdentities which should be returned </param>
    public SubjectIdentity[] SearchSubjectIdentities(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchSubjectIdentities";
        var args = new SearchSubjectIdentitiesRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchSubjectIdentitiesResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new SubjectIdentity and returns its primary identifier (or null on failure). </summary>
    /// <param name="subjectIdentity"> SubjectIdentity containing the new values </param>
    public Boolean AddNewSubjectIdentity(SubjectIdentity subjectIdentity) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewSubjectIdentity";
        var args = new AddNewSubjectIdentityRequest {
          subjectIdentity = subjectIdentity
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewSubjectIdentityResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectIdentity addressed by the primary identifier fields within the given SubjectIdentity. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="subjectIdentity"> SubjectIdentity containing the new values (the primary identifier fields within the given SubjectIdentity will be used to address the target record) </param>
    public Boolean UpdateSubjectIdentity(SubjectIdentity subjectIdentity) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateSubjectIdentity";
        var args = new UpdateSubjectIdentityRequest {
          subjectIdentity = subjectIdentity
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateSubjectIdentityResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectIdentity addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="recordId"> Represents the primary identity of a SubjectIdentity </param>
    /// <param name="subjectIdentity"> SubjectIdentity containing the new values (the primary identifier fields within the given SubjectIdentity will be ignored) </param>
    public Boolean UpdateSubjectIdentityByRecordId(Guid recordId, SubjectIdentity subjectIdentity) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateSubjectIdentityByRecordId";
        var args = new UpdateSubjectIdentityByRecordIdRequest {
          recordId = recordId,
          subjectIdentity = subjectIdentity
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateSubjectIdentityByRecordIdResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific SubjectIdentity addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="recordId"> Represents the primary identity of a SubjectIdentity </param>
    public Boolean DeleteSubjectIdentityByRecordId(Guid recordId) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteSubjectIdentityByRecordId";
        var args = new DeleteSubjectIdentityByRecordIdRequest {
          recordId = recordId
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteSubjectIdentityByRecordIdResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
}
