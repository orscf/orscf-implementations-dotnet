using MedicalResearch.StudyManagement.Model;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MedicalResearch.StudyManagement.StoreAccess {
  
  public partial class SmsStoreConnector {
    
    public SmsStoreConnector(string url, string apiToken) {
      
      if (!url.EndsWith("/")) {
        url = url + "/";
      }
      
      _InstitutesClient = new InstitutesClient(url + "institutes/", apiToken);
      _ResearchStudiesClient = new ResearchStudiesClient(url + "researchStudies/", apiToken);
      _SitesClient = new SitesClient(url + "sites/", apiToken);
      _SystemEndpointsClient = new SystemEndpointsClient(url + "systemEndpoints/", apiToken);
      _InstituteRelatedSystemAssignemntsClient = new InstituteRelatedSystemAssignemntsClient(url + "instituteRelatedSystemAssignemnts/", apiToken);
      _SystemConnectionsClient = new SystemConnectionsClient(url + "systemConnections/", apiToken);
      _InvolvedPersonsClient = new InvolvedPersonsClient(url + "involvedPersons/", apiToken);
      _InvolvementRolesClient = new InvolvementRolesClient(url + "involvementRoles/", apiToken);
      _StudyRelatedSystemAssignmentsClient = new StudyRelatedSystemAssignmentsClient(url + "studyRelatedSystemAssignments/", apiToken);
      _SiteRelatedSystemAssignmentsClient = new SiteRelatedSystemAssignmentsClient(url + "siteRelatedSystemAssignments/", apiToken);
      
    }
    
    private InstitutesClient _InstitutesClient = null;
    /// <summary> Provides CRUD access to stored Institutes (based on schema version '1.6.0') </summary>
    public IInstitutes Institutes {
      get {
        return _InstitutesClient;
      }
    }
    
    private ResearchStudiesClient _ResearchStudiesClient = null;
    /// <summary> Provides CRUD access to stored ResearchStudies (based on schema version '1.6.0') </summary>
    public IResearchStudies ResearchStudies {
      get {
        return _ResearchStudiesClient;
      }
    }
    
    private SitesClient _SitesClient = null;
    /// <summary> Provides CRUD access to stored Sites (based on schema version '1.6.0') </summary>
    public ISites Sites {
      get {
        return _SitesClient;
      }
    }
    
    private SystemEndpointsClient _SystemEndpointsClient = null;
    /// <summary> Provides CRUD access to stored SystemEndpoints (based on schema version '1.6.0') </summary>
    public ISystemEndpoints SystemEndpoints {
      get {
        return _SystemEndpointsClient;
      }
    }
    
    private InstituteRelatedSystemAssignemntsClient _InstituteRelatedSystemAssignemntsClient = null;
    /// <summary> Provides CRUD access to stored InstituteRelatedSystemAssignemnts (based on schema version '1.6.0') </summary>
    public IInstituteRelatedSystemAssignemnts InstituteRelatedSystemAssignemnts {
      get {
        return _InstituteRelatedSystemAssignemntsClient;
      }
    }
    
    private SystemConnectionsClient _SystemConnectionsClient = null;
    /// <summary> Provides CRUD access to stored SystemConnections (based on schema version '1.6.0') </summary>
    public ISystemConnections SystemConnections {
      get {
        return _SystemConnectionsClient;
      }
    }
    
    private InvolvedPersonsClient _InvolvedPersonsClient = null;
    /// <summary> Provides CRUD access to stored InvolvedPersons (based on schema version '1.6.0') </summary>
    public IInvolvedPersons InvolvedPersons {
      get {
        return _InvolvedPersonsClient;
      }
    }
    
    private InvolvementRolesClient _InvolvementRolesClient = null;
    /// <summary> Provides CRUD access to stored InvolvementRoles (based on schema version '1.6.0') </summary>
    public IInvolvementRoles InvolvementRoles {
      get {
        return _InvolvementRolesClient;
      }
    }
    
    private StudyRelatedSystemAssignmentsClient _StudyRelatedSystemAssignmentsClient = null;
    /// <summary> Provides CRUD access to stored StudyRelatedSystemAssignments (based on schema version '1.6.0') </summary>
    public IStudyRelatedSystemAssignments StudyRelatedSystemAssignments {
      get {
        return _StudyRelatedSystemAssignmentsClient;
      }
    }
    
    private SiteRelatedSystemAssignmentsClient _SiteRelatedSystemAssignmentsClient = null;
    /// <summary> Provides CRUD access to stored SiteRelatedSystemAssignments (based on schema version '1.6.0') </summary>
    public ISiteRelatedSystemAssignments SiteRelatedSystemAssignments {
      get {
        return _SiteRelatedSystemAssignmentsClient;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored Institutes (based on schema version '1.6.0') </summary>
  internal partial class InstitutesClient : IInstitutes {
    
    private string _Url;
    private string _ApiToken;
    
    public InstitutesClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific Institute addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="instituteUid"> An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </param>
    public Institute GetInstituteByInstituteUid(Guid instituteUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getInstituteByInstituteUid";
        var args = new GetInstituteByInstituteUidRequest {
          instituteUid = instituteUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetInstituteByInstituteUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads Institutes. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of Institutes which should be returned </param>
    public Institute[] GetInstitutes(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getInstitutes";
        var args = new GetInstitutesRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetInstitutesResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads Institutes where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of Institutes which should be returned </param>
    public Institute[] SearchInstitutes(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchInstitutes";
        var args = new SearchInstitutesRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchInstitutesResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new Institute and returns its primary identifier (or null on failure). </summary>
    /// <param name="institute"> Institute containing the new values </param>
    public Boolean AddNewInstitute(Institute institute) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewInstitute";
        var args = new AddNewInstituteRequest {
          institute = institute
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewInstituteResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Institute addressed by the primary identifier fields within the given Institute. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="institute"> Institute containing the new values (the primary identifier fields within the given Institute will be used to address the target record) </param>
    public Boolean UpdateInstitute(Institute institute) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateInstitute";
        var args = new UpdateInstituteRequest {
          institute = institute
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateInstituteResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Institute addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="instituteUid"> An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </param>
    /// <param name="institute"> Institute containing the new values (the primary identifier fields within the given Institute will be ignored) </param>
    public Boolean UpdateInstituteByInstituteUid(Guid instituteUid, Institute institute) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateInstituteByInstituteUid";
        var args = new UpdateInstituteByInstituteUidRequest {
          instituteUid = instituteUid,
          institute = institute
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateInstituteByInstituteUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific Institute addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="instituteUid"> An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </param>
    public Boolean DeleteInstituteByInstituteUid(Guid instituteUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteInstituteByInstituteUid";
        var args = new DeleteInstituteByInstituteUidRequest {
          instituteUid = instituteUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteInstituteByInstituteUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored ResearchStudies (based on schema version '1.6.0') </summary>
  internal partial class ResearchStudiesClient : IResearchStudies {
    
    private string _Url;
    private string _ApiToken;
    
    public ResearchStudiesClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific ResearchStudy addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="researchStudyUid"> An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </param>
    public ResearchStudy GetResearchStudyByResearchStudyUid(Guid researchStudyUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getResearchStudyByResearchStudyUid";
        var args = new GetResearchStudyByResearchStudyUidRequest {
          researchStudyUid = researchStudyUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetResearchStudyByResearchStudyUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads ResearchStudies. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of ResearchStudies which should be returned </param>
    public ResearchStudy[] GetResearchStudies(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getResearchStudies";
        var args = new GetResearchStudiesRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetResearchStudiesResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads ResearchStudies where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of ResearchStudies which should be returned </param>
    public ResearchStudy[] SearchResearchStudies(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchResearchStudies";
        var args = new SearchResearchStudiesRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchResearchStudiesResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new ResearchStudy and returns its primary identifier (or null on failure). </summary>
    /// <param name="researchStudy"> ResearchStudy containing the new values </param>
    public Boolean AddNewResearchStudy(ResearchStudy researchStudy) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewResearchStudy";
        var args = new AddNewResearchStudyRequest {
          researchStudy = researchStudy
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewResearchStudyResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ResearchStudy addressed by the primary identifier fields within the given ResearchStudy. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="researchStudy"> ResearchStudy containing the new values (the primary identifier fields within the given ResearchStudy will be used to address the target record) </param>
    public Boolean UpdateResearchStudy(ResearchStudy researchStudy) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateResearchStudy";
        var args = new UpdateResearchStudyRequest {
          researchStudy = researchStudy
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateResearchStudyResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ResearchStudy addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="researchStudyUid"> An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </param>
    /// <param name="researchStudy"> ResearchStudy containing the new values (the primary identifier fields within the given ResearchStudy will be ignored) </param>
    public Boolean UpdateResearchStudyByResearchStudyUid(Guid researchStudyUid, ResearchStudy researchStudy) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateResearchStudyByResearchStudyUid";
        var args = new UpdateResearchStudyByResearchStudyUidRequest {
          researchStudyUid = researchStudyUid,
          researchStudy = researchStudy
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateResearchStudyByResearchStudyUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific ResearchStudy addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="researchStudyUid"> An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </param>
    public Boolean DeleteResearchStudyByResearchStudyUid(Guid researchStudyUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteResearchStudyByResearchStudyUid";
        var args = new DeleteResearchStudyByResearchStudyUidRequest {
          researchStudyUid = researchStudyUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteResearchStudyByResearchStudyUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored Sites (based on schema version '1.6.0') </summary>
  internal partial class SitesClient : ISites {
    
    private string _Url;
    private string _ApiToken;
    
    public SitesClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific Site addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="siteUid"> An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </param>
    public Site GetSiteBySiteUid(Guid siteUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getSiteBySiteUid";
        var args = new GetSiteBySiteUidRequest {
          siteUid = siteUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetSiteBySiteUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads Sites. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of Sites which should be returned </param>
    public Site[] GetSites(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getSites";
        var args = new GetSitesRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetSitesResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads Sites where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of Sites which should be returned </param>
    public Site[] SearchSites(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchSites";
        var args = new SearchSitesRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchSitesResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new Site and returns its primary identifier (or null on failure). </summary>
    /// <param name="site"> Site containing the new values </param>
    public Boolean AddNewSite(Site site) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewSite";
        var args = new AddNewSiteRequest {
          site = site
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewSiteResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Site addressed by the primary identifier fields within the given Site. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="site"> Site containing the new values (the primary identifier fields within the given Site will be used to address the target record) </param>
    public Boolean UpdateSite(Site site) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateSite";
        var args = new UpdateSiteRequest {
          site = site
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateSiteResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Site addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="siteUid"> An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </param>
    /// <param name="site"> Site containing the new values (the primary identifier fields within the given Site will be ignored) </param>
    public Boolean UpdateSiteBySiteUid(Guid siteUid, Site site) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateSiteBySiteUid";
        var args = new UpdateSiteBySiteUidRequest {
          siteUid = siteUid,
          site = site
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateSiteBySiteUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific Site addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="siteUid"> An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </param>
    public Boolean DeleteSiteBySiteUid(Guid siteUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteSiteBySiteUid";
        var args = new DeleteSiteBySiteUidRequest {
          siteUid = siteUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteSiteBySiteUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored SystemEndpoints (based on schema version '1.6.0') </summary>
  internal partial class SystemEndpointsClient : ISystemEndpoints {
    
    private string _Url;
    private string _ApiToken;
    
    public SystemEndpointsClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific SystemEndpoint addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="systemEndpointUid"> Represents the primary identity of a SystemEndpoint </param>
    public SystemEndpoint GetSystemEndpointBySystemEndpointUid(Guid systemEndpointUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getSystemEndpointBySystemEndpointUid";
        var args = new GetSystemEndpointBySystemEndpointUidRequest {
          systemEndpointUid = systemEndpointUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetSystemEndpointBySystemEndpointUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads SystemEndpoints. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of SystemEndpoints which should be returned </param>
    public SystemEndpoint[] GetSystemEndpoints(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getSystemEndpoints";
        var args = new GetSystemEndpointsRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetSystemEndpointsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads SystemEndpoints where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of SystemEndpoints which should be returned </param>
    public SystemEndpoint[] SearchSystemEndpoints(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchSystemEndpoints";
        var args = new SearchSystemEndpointsRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchSystemEndpointsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new SystemEndpoint and returns its primary identifier (or null on failure). </summary>
    /// <param name="systemEndpoint"> SystemEndpoint containing the new values </param>
    public Boolean AddNewSystemEndpoint(SystemEndpoint systemEndpoint) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewSystemEndpoint";
        var args = new AddNewSystemEndpointRequest {
          systemEndpoint = systemEndpoint
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewSystemEndpointResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SystemEndpoint addressed by the primary identifier fields within the given SystemEndpoint. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="systemEndpoint"> SystemEndpoint containing the new values (the primary identifier fields within the given SystemEndpoint will be used to address the target record) </param>
    public Boolean UpdateSystemEndpoint(SystemEndpoint systemEndpoint) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateSystemEndpoint";
        var args = new UpdateSystemEndpointRequest {
          systemEndpoint = systemEndpoint
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateSystemEndpointResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SystemEndpoint addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="systemEndpointUid"> Represents the primary identity of a SystemEndpoint </param>
    /// <param name="systemEndpoint"> SystemEndpoint containing the new values (the primary identifier fields within the given SystemEndpoint will be ignored) </param>
    public Boolean UpdateSystemEndpointBySystemEndpointUid(Guid systemEndpointUid, SystemEndpoint systemEndpoint) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateSystemEndpointBySystemEndpointUid";
        var args = new UpdateSystemEndpointBySystemEndpointUidRequest {
          systemEndpointUid = systemEndpointUid,
          systemEndpoint = systemEndpoint
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateSystemEndpointBySystemEndpointUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific SystemEndpoint addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="systemEndpointUid"> Represents the primary identity of a SystemEndpoint </param>
    public Boolean DeleteSystemEndpointBySystemEndpointUid(Guid systemEndpointUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteSystemEndpointBySystemEndpointUid";
        var args = new DeleteSystemEndpointBySystemEndpointUidRequest {
          systemEndpointUid = systemEndpointUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteSystemEndpointBySystemEndpointUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored InstituteRelatedSystemAssignemnts (based on schema version '1.6.0') </summary>
  internal partial class InstituteRelatedSystemAssignemntsClient : IInstituteRelatedSystemAssignemnts {
    
    private string _Url;
    private string _ApiToken;
    
    public InstituteRelatedSystemAssignemntsClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific InstituteRelatedSystemAssignemnt addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="instituteRelatedSystemAssignemntUid"> Represents the primary identity of a InstituteRelatedSystemAssignemnt </param>
    public InstituteRelatedSystemAssignemnt GetInstituteRelatedSystemAssignemntByInstituteRelatedSystemAssignemntUid(Guid instituteRelatedSystemAssignemntUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getInstituteRelatedSystemAssignemntByInstituteRelatedSystemAssignemntUid";
        var args = new GetInstituteRelatedSystemAssignemntByInstituteRelatedSystemAssignemntUidRequest {
          instituteRelatedSystemAssignemntUid = instituteRelatedSystemAssignemntUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetInstituteRelatedSystemAssignemntByInstituteRelatedSystemAssignemntUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads InstituteRelatedSystemAssignemnts. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of InstituteRelatedSystemAssignemnts which should be returned </param>
    public InstituteRelatedSystemAssignemnt[] GetInstituteRelatedSystemAssignemnts(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getInstituteRelatedSystemAssignemnts";
        var args = new GetInstituteRelatedSystemAssignemntsRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetInstituteRelatedSystemAssignemntsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads InstituteRelatedSystemAssignemnts where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of InstituteRelatedSystemAssignemnts which should be returned </param>
    public InstituteRelatedSystemAssignemnt[] SearchInstituteRelatedSystemAssignemnts(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchInstituteRelatedSystemAssignemnts";
        var args = new SearchInstituteRelatedSystemAssignemntsRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchInstituteRelatedSystemAssignemntsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new InstituteRelatedSystemAssignemnt and returns its primary identifier (or null on failure). </summary>
    /// <param name="instituteRelatedSystemAssignemnt"> InstituteRelatedSystemAssignemnt containing the new values </param>
    public Boolean AddNewInstituteRelatedSystemAssignemnt(InstituteRelatedSystemAssignemnt instituteRelatedSystemAssignemnt) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewInstituteRelatedSystemAssignemnt";
        var args = new AddNewInstituteRelatedSystemAssignemntRequest {
          instituteRelatedSystemAssignemnt = instituteRelatedSystemAssignemnt
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewInstituteRelatedSystemAssignemntResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InstituteRelatedSystemAssignemnt addressed by the primary identifier fields within the given InstituteRelatedSystemAssignemnt. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="instituteRelatedSystemAssignemnt"> InstituteRelatedSystemAssignemnt containing the new values (the primary identifier fields within the given InstituteRelatedSystemAssignemnt will be used to address the target record) </param>
    public Boolean UpdateInstituteRelatedSystemAssignemnt(InstituteRelatedSystemAssignemnt instituteRelatedSystemAssignemnt) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateInstituteRelatedSystemAssignemnt";
        var args = new UpdateInstituteRelatedSystemAssignemntRequest {
          instituteRelatedSystemAssignemnt = instituteRelatedSystemAssignemnt
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateInstituteRelatedSystemAssignemntResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InstituteRelatedSystemAssignemnt addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="instituteRelatedSystemAssignemntUid"> Represents the primary identity of a InstituteRelatedSystemAssignemnt </param>
    /// <param name="instituteRelatedSystemAssignemnt"> InstituteRelatedSystemAssignemnt containing the new values (the primary identifier fields within the given InstituteRelatedSystemAssignemnt will be ignored) </param>
    public Boolean UpdateInstituteRelatedSystemAssignemntByInstituteRelatedSystemAssignemntUid(Guid instituteRelatedSystemAssignemntUid, InstituteRelatedSystemAssignemnt instituteRelatedSystemAssignemnt) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateInstituteRelatedSystemAssignemntByInstituteRelatedSystemAssignemntUid";
        var args = new UpdateInstituteRelatedSystemAssignemntByInstituteRelatedSystemAssignemntUidRequest {
          instituteRelatedSystemAssignemntUid = instituteRelatedSystemAssignemntUid,
          instituteRelatedSystemAssignemnt = instituteRelatedSystemAssignemnt
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateInstituteRelatedSystemAssignemntByInstituteRelatedSystemAssignemntUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific InstituteRelatedSystemAssignemnt addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="instituteRelatedSystemAssignemntUid"> Represents the primary identity of a InstituteRelatedSystemAssignemnt </param>
    public Boolean DeleteInstituteRelatedSystemAssignemntByInstituteRelatedSystemAssignemntUid(Guid instituteRelatedSystemAssignemntUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteInstituteRelatedSystemAssignemntByInstituteRelatedSystemAssignemntUid";
        var args = new DeleteInstituteRelatedSystemAssignemntByInstituteRelatedSystemAssignemntUidRequest {
          instituteRelatedSystemAssignemntUid = instituteRelatedSystemAssignemntUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteInstituteRelatedSystemAssignemntByInstituteRelatedSystemAssignemntUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored SystemConnections (based on schema version '1.6.0') </summary>
  internal partial class SystemConnectionsClient : ISystemConnections {
    
    private string _Url;
    private string _ApiToken;
    
    public SystemConnectionsClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific SystemConnection addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="systemConnectionUid"> Represents the primary identity of a SystemConnection </param>
    public SystemConnection GetSystemConnectionBySystemConnectionUid(Guid systemConnectionUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getSystemConnectionBySystemConnectionUid";
        var args = new GetSystemConnectionBySystemConnectionUidRequest {
          systemConnectionUid = systemConnectionUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetSystemConnectionBySystemConnectionUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads SystemConnections. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of SystemConnections which should be returned </param>
    public SystemConnection[] GetSystemConnections(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getSystemConnections";
        var args = new GetSystemConnectionsRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetSystemConnectionsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads SystemConnections where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of SystemConnections which should be returned </param>
    public SystemConnection[] SearchSystemConnections(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchSystemConnections";
        var args = new SearchSystemConnectionsRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchSystemConnectionsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new SystemConnection and returns its primary identifier (or null on failure). </summary>
    /// <param name="systemConnection"> SystemConnection containing the new values </param>
    public Boolean AddNewSystemConnection(SystemConnection systemConnection) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewSystemConnection";
        var args = new AddNewSystemConnectionRequest {
          systemConnection = systemConnection
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewSystemConnectionResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SystemConnection addressed by the primary identifier fields within the given SystemConnection. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="systemConnection"> SystemConnection containing the new values (the primary identifier fields within the given SystemConnection will be used to address the target record) </param>
    public Boolean UpdateSystemConnection(SystemConnection systemConnection) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateSystemConnection";
        var args = new UpdateSystemConnectionRequest {
          systemConnection = systemConnection
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateSystemConnectionResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SystemConnection addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="systemConnectionUid"> Represents the primary identity of a SystemConnection </param>
    /// <param name="systemConnection"> SystemConnection containing the new values (the primary identifier fields within the given SystemConnection will be ignored) </param>
    public Boolean UpdateSystemConnectionBySystemConnectionUid(Guid systemConnectionUid, SystemConnection systemConnection) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateSystemConnectionBySystemConnectionUid";
        var args = new UpdateSystemConnectionBySystemConnectionUidRequest {
          systemConnectionUid = systemConnectionUid,
          systemConnection = systemConnection
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateSystemConnectionBySystemConnectionUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific SystemConnection addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="systemConnectionUid"> Represents the primary identity of a SystemConnection </param>
    public Boolean DeleteSystemConnectionBySystemConnectionUid(Guid systemConnectionUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteSystemConnectionBySystemConnectionUid";
        var args = new DeleteSystemConnectionBySystemConnectionUidRequest {
          systemConnectionUid = systemConnectionUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteSystemConnectionBySystemConnectionUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored InvolvedPersons (based on schema version '1.6.0') </summary>
  internal partial class InvolvedPersonsClient : IInvolvedPersons {
    
    private string _Url;
    private string _ApiToken;
    
    public InvolvedPersonsClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific InvolvedPerson addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="involvedPersonUid"> An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </param>
    public InvolvedPerson GetInvolvedPersonByInvolvedPersonUid(Guid involvedPersonUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getInvolvedPersonByInvolvedPersonUid";
        var args = new GetInvolvedPersonByInvolvedPersonUidRequest {
          involvedPersonUid = involvedPersonUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetInvolvedPersonByInvolvedPersonUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads InvolvedPersons. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of InvolvedPersons which should be returned </param>
    public InvolvedPerson[] GetInvolvedPersons(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getInvolvedPersons";
        var args = new GetInvolvedPersonsRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetInvolvedPersonsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads InvolvedPersons where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of InvolvedPersons which should be returned </param>
    public InvolvedPerson[] SearchInvolvedPersons(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchInvolvedPersons";
        var args = new SearchInvolvedPersonsRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchInvolvedPersonsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new InvolvedPerson and returns its primary identifier (or null on failure). </summary>
    /// <param name="involvedPerson"> InvolvedPerson containing the new values </param>
    public Boolean AddNewInvolvedPerson(InvolvedPerson involvedPerson) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewInvolvedPerson";
        var args = new AddNewInvolvedPersonRequest {
          involvedPerson = involvedPerson
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewInvolvedPersonResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InvolvedPerson addressed by the primary identifier fields within the given InvolvedPerson. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="involvedPerson"> InvolvedPerson containing the new values (the primary identifier fields within the given InvolvedPerson will be used to address the target record) </param>
    public Boolean UpdateInvolvedPerson(InvolvedPerson involvedPerson) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateInvolvedPerson";
        var args = new UpdateInvolvedPersonRequest {
          involvedPerson = involvedPerson
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateInvolvedPersonResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InvolvedPerson addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="involvedPersonUid"> An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </param>
    /// <param name="involvedPerson"> InvolvedPerson containing the new values (the primary identifier fields within the given InvolvedPerson will be ignored) </param>
    public Boolean UpdateInvolvedPersonByInvolvedPersonUid(Guid involvedPersonUid, InvolvedPerson involvedPerson) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateInvolvedPersonByInvolvedPersonUid";
        var args = new UpdateInvolvedPersonByInvolvedPersonUidRequest {
          involvedPersonUid = involvedPersonUid,
          involvedPerson = involvedPerson
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateInvolvedPersonByInvolvedPersonUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific InvolvedPerson addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="involvedPersonUid"> An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </param>
    public Boolean DeleteInvolvedPersonByInvolvedPersonUid(Guid involvedPersonUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteInvolvedPersonByInvolvedPersonUid";
        var args = new DeleteInvolvedPersonByInvolvedPersonUidRequest {
          involvedPersonUid = involvedPersonUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteInvolvedPersonByInvolvedPersonUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored InvolvementRoles (based on schema version '1.6.0') </summary>
  internal partial class InvolvementRolesClient : IInvolvementRoles {
    
    private string _Url;
    private string _ApiToken;
    
    public InvolvementRolesClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific InvolvementRole addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="involvedPersonRoleUid"> An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </param>
    public InvolvementRole GetInvolvementRoleByInvolvedPersonRoleUid(Guid involvedPersonRoleUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getInvolvementRoleByInvolvedPersonRoleUid";
        var args = new GetInvolvementRoleByInvolvedPersonRoleUidRequest {
          involvedPersonRoleUid = involvedPersonRoleUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetInvolvementRoleByInvolvedPersonRoleUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads InvolvementRoles. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of InvolvementRoles which should be returned </param>
    public InvolvementRole[] GetInvolvementRoles(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getInvolvementRoles";
        var args = new GetInvolvementRolesRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetInvolvementRolesResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads InvolvementRoles where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of InvolvementRoles which should be returned </param>
    public InvolvementRole[] SearchInvolvementRoles(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchInvolvementRoles";
        var args = new SearchInvolvementRolesRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchInvolvementRolesResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new InvolvementRole and returns its primary identifier (or null on failure). </summary>
    /// <param name="involvementRole"> InvolvementRole containing the new values </param>
    public Boolean AddNewInvolvementRole(InvolvementRole involvementRole) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewInvolvementRole";
        var args = new AddNewInvolvementRoleRequest {
          involvementRole = involvementRole
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewInvolvementRoleResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InvolvementRole addressed by the primary identifier fields within the given InvolvementRole. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="involvementRole"> InvolvementRole containing the new values (the primary identifier fields within the given InvolvementRole will be used to address the target record) </param>
    public Boolean UpdateInvolvementRole(InvolvementRole involvementRole) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateInvolvementRole";
        var args = new UpdateInvolvementRoleRequest {
          involvementRole = involvementRole
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateInvolvementRoleResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InvolvementRole addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="involvedPersonRoleUid"> An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </param>
    /// <param name="involvementRole"> InvolvementRole containing the new values (the primary identifier fields within the given InvolvementRole will be ignored) </param>
    public Boolean UpdateInvolvementRoleByInvolvedPersonRoleUid(Guid involvedPersonRoleUid, InvolvementRole involvementRole) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateInvolvementRoleByInvolvedPersonRoleUid";
        var args = new UpdateInvolvementRoleByInvolvedPersonRoleUidRequest {
          involvedPersonRoleUid = involvedPersonRoleUid,
          involvementRole = involvementRole
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateInvolvementRoleByInvolvedPersonRoleUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific InvolvementRole addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="involvedPersonRoleUid"> An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </param>
    public Boolean DeleteInvolvementRoleByInvolvedPersonRoleUid(Guid involvedPersonRoleUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteInvolvementRoleByInvolvedPersonRoleUid";
        var args = new DeleteInvolvementRoleByInvolvedPersonRoleUidRequest {
          involvedPersonRoleUid = involvedPersonRoleUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteInvolvementRoleByInvolvedPersonRoleUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored StudyRelatedSystemAssignments (based on schema version '1.6.0') </summary>
  internal partial class StudyRelatedSystemAssignmentsClient : IStudyRelatedSystemAssignments {
    
    private string _Url;
    private string _ApiToken;
    
    public StudyRelatedSystemAssignmentsClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific StudyRelatedSystemAssignment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="studyRelatedSystemAssignmentUid"> Represents the primary identity of a StudyRelatedSystemAssignment </param>
    public StudyRelatedSystemAssignment GetStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid(Guid studyRelatedSystemAssignmentUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid";
        var args = new GetStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUidRequest {
          studyRelatedSystemAssignmentUid = studyRelatedSystemAssignmentUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads StudyRelatedSystemAssignments. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of StudyRelatedSystemAssignments which should be returned </param>
    public StudyRelatedSystemAssignment[] GetStudyRelatedSystemAssignments(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getStudyRelatedSystemAssignments";
        var args = new GetStudyRelatedSystemAssignmentsRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetStudyRelatedSystemAssignmentsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads StudyRelatedSystemAssignments where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of StudyRelatedSystemAssignments which should be returned </param>
    public StudyRelatedSystemAssignment[] SearchStudyRelatedSystemAssignments(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchStudyRelatedSystemAssignments";
        var args = new SearchStudyRelatedSystemAssignmentsRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchStudyRelatedSystemAssignmentsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new StudyRelatedSystemAssignment and returns its primary identifier (or null on failure). </summary>
    /// <param name="studyRelatedSystemAssignment"> StudyRelatedSystemAssignment containing the new values </param>
    public Boolean AddNewStudyRelatedSystemAssignment(StudyRelatedSystemAssignment studyRelatedSystemAssignment) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewStudyRelatedSystemAssignment";
        var args = new AddNewStudyRelatedSystemAssignmentRequest {
          studyRelatedSystemAssignment = studyRelatedSystemAssignment
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewStudyRelatedSystemAssignmentResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyRelatedSystemAssignment addressed by the primary identifier fields within the given StudyRelatedSystemAssignment. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="studyRelatedSystemAssignment"> StudyRelatedSystemAssignment containing the new values (the primary identifier fields within the given StudyRelatedSystemAssignment will be used to address the target record) </param>
    public Boolean UpdateStudyRelatedSystemAssignment(StudyRelatedSystemAssignment studyRelatedSystemAssignment) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateStudyRelatedSystemAssignment";
        var args = new UpdateStudyRelatedSystemAssignmentRequest {
          studyRelatedSystemAssignment = studyRelatedSystemAssignment
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateStudyRelatedSystemAssignmentResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyRelatedSystemAssignment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="studyRelatedSystemAssignmentUid"> Represents the primary identity of a StudyRelatedSystemAssignment </param>
    /// <param name="studyRelatedSystemAssignment"> StudyRelatedSystemAssignment containing the new values (the primary identifier fields within the given StudyRelatedSystemAssignment will be ignored) </param>
    public Boolean UpdateStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid(Guid studyRelatedSystemAssignmentUid, StudyRelatedSystemAssignment studyRelatedSystemAssignment) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid";
        var args = new UpdateStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUidRequest {
          studyRelatedSystemAssignmentUid = studyRelatedSystemAssignmentUid,
          studyRelatedSystemAssignment = studyRelatedSystemAssignment
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific StudyRelatedSystemAssignment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="studyRelatedSystemAssignmentUid"> Represents the primary identity of a StudyRelatedSystemAssignment </param>
    public Boolean DeleteStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid(Guid studyRelatedSystemAssignmentUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid";
        var args = new DeleteStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUidRequest {
          studyRelatedSystemAssignmentUid = studyRelatedSystemAssignmentUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored SiteRelatedSystemAssignments (based on schema version '1.6.0') </summary>
  internal partial class SiteRelatedSystemAssignmentsClient : ISiteRelatedSystemAssignments {
    
    private string _Url;
    private string _ApiToken;
    
    public SiteRelatedSystemAssignmentsClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific SiteRelatedSystemAssignment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="siteRelatedSystemAssignmentUid"> Represents the primary identity of a SiteRelatedSystemAssignment </param>
    public SiteRelatedSystemAssignment GetSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid(Guid siteRelatedSystemAssignmentUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid";
        var args = new GetSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUidRequest {
          siteRelatedSystemAssignmentUid = siteRelatedSystemAssignmentUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads SiteRelatedSystemAssignments. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of SiteRelatedSystemAssignments which should be returned </param>
    public SiteRelatedSystemAssignment[] GetSiteRelatedSystemAssignments(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getSiteRelatedSystemAssignments";
        var args = new GetSiteRelatedSystemAssignmentsRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetSiteRelatedSystemAssignmentsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads SiteRelatedSystemAssignments where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of SiteRelatedSystemAssignments which should be returned </param>
    public SiteRelatedSystemAssignment[] SearchSiteRelatedSystemAssignments(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchSiteRelatedSystemAssignments";
        var args = new SearchSiteRelatedSystemAssignmentsRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchSiteRelatedSystemAssignmentsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new SiteRelatedSystemAssignment and returns its primary identifier (or null on failure). </summary>
    /// <param name="siteRelatedSystemAssignment"> SiteRelatedSystemAssignment containing the new values </param>
    public Boolean AddNewSiteRelatedSystemAssignment(SiteRelatedSystemAssignment siteRelatedSystemAssignment) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewSiteRelatedSystemAssignment";
        var args = new AddNewSiteRelatedSystemAssignmentRequest {
          siteRelatedSystemAssignment = siteRelatedSystemAssignment
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewSiteRelatedSystemAssignmentResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SiteRelatedSystemAssignment addressed by the primary identifier fields within the given SiteRelatedSystemAssignment. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="siteRelatedSystemAssignment"> SiteRelatedSystemAssignment containing the new values (the primary identifier fields within the given SiteRelatedSystemAssignment will be used to address the target record) </param>
    public Boolean UpdateSiteRelatedSystemAssignment(SiteRelatedSystemAssignment siteRelatedSystemAssignment) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateSiteRelatedSystemAssignment";
        var args = new UpdateSiteRelatedSystemAssignmentRequest {
          siteRelatedSystemAssignment = siteRelatedSystemAssignment
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateSiteRelatedSystemAssignmentResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SiteRelatedSystemAssignment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="siteRelatedSystemAssignmentUid"> Represents the primary identity of a SiteRelatedSystemAssignment </param>
    /// <param name="siteRelatedSystemAssignment"> SiteRelatedSystemAssignment containing the new values (the primary identifier fields within the given SiteRelatedSystemAssignment will be ignored) </param>
    public Boolean UpdateSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid(Guid siteRelatedSystemAssignmentUid, SiteRelatedSystemAssignment siteRelatedSystemAssignment) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid";
        var args = new UpdateSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUidRequest {
          siteRelatedSystemAssignmentUid = siteRelatedSystemAssignmentUid,
          siteRelatedSystemAssignment = siteRelatedSystemAssignment
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific SiteRelatedSystemAssignment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="siteRelatedSystemAssignmentUid"> Represents the primary identity of a SiteRelatedSystemAssignment </param>
    public Boolean DeleteSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid(Guid siteRelatedSystemAssignmentUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid";
        var args = new DeleteSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUidRequest {
          siteRelatedSystemAssignmentUid = siteRelatedSystemAssignmentUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
}
