using MedicalResearch.StudyManagement.Model;
using MedicalResearch.StudyManagement.StoreAccess;
using MedicalResearch.StudyManagement.WebAPI.DTOs;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MedicalResearch.StudyManagement.WebAPI {
  
  public partial class SmsConnector {
    
    public SmsConnector(string url, string apiToken) {
      
      if (!url.EndsWith("/")) {
        url = url + "/";
      }
      
      _InstitutesClient = new InstitutesClient(url + "institutes/", apiToken);
      _ResearchStudiesClient = new ResearchStudiesClient(url + "researchStudies/", apiToken);
      _SitesClient = new SitesClient(url + "sites/", apiToken);
      _SubjectsClient = new SubjectsClient(url + "subjects/", apiToken);
      
    }
    
    private InstitutesClient _InstitutesClient = null;
    /// <summary> Provides CRUD access to stored Institutes (based on schema version '1.5.0') </summary>
    public IInstitutes Institutes {
      get {
        return _InstitutesClient;
      }
    }
    
    private ResearchStudiesClient _ResearchStudiesClient = null;
    /// <summary> Provides CRUD access to stored ResearchStudies (based on schema version '1.5.0') </summary>
    public IResearchStudies ResearchStudies {
      get {
        return _ResearchStudiesClient;
      }
    }
    
    private SitesClient _SitesClient = null;
    /// <summary> Provides CRUD access to stored Sites (based on schema version '1.5.0') </summary>
    public ISites Sites {
      get {
        return _SitesClient;
      }
    }
    
    private SubjectsClient _SubjectsClient = null;
    /// <summary> Provides CRUD access to stored Subjects (based on schema version '1.5.0') </summary>
    public ISubjects Subjects {
      get {
        return _SubjectsClient;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored Institutes (based on schema version '1.5.0') </summary>
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
    /// <param name="instituteUid"> Represents the primary identity of a Institute </param>
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
    /// <param name="instituteUid"> Represents the primary identity of a Institute </param>
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
    /// <param name="instituteUid"> Represents the primary identity of a Institute </param>
    public Boolean ArchiveInstituteByInstituteUid(Guid instituteUid) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "archiveInstituteByInstituteUid";
        var args = new ArchiveInstituteByInstituteUidRequest {
          instituteUid = instituteUid
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<ArchiveInstituteByInstituteUidResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored ResearchStudies (based on schema version '1.5.0') </summary>
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
    /// <param name="studyIdentifier"> Represents the primary identity of a ResearchStudy </param>
    public ResearchStudy GetResearchStudyByStudyIdentifier(String studyIdentifier) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getResearchStudyByStudyIdentifier";
        var args = new GetResearchStudyByStudyIdentifierRequest {
          studyIdentifier = studyIdentifier
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetResearchStudyByStudyIdentifierResponse>(rawResponse);
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
    /// <param name="studyIdentifier"> Represents the primary identity of a ResearchStudy </param>
    /// <param name="researchStudy"> ResearchStudy containing the new values (the primary identifier fields within the given ResearchStudy will be ignored) </param>
    public Boolean UpdateResearchStudyByStudyIdentifier(String studyIdentifier, ResearchStudy researchStudy) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateResearchStudyByStudyIdentifier";
        var args = new UpdateResearchStudyByStudyIdentifierRequest {
          studyIdentifier = studyIdentifier,
          researchStudy = researchStudy
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateResearchStudyByStudyIdentifierResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific ResearchStudy addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="studyIdentifier"> Represents the primary identity of a ResearchStudy </param>
    public Boolean ArchiveResearchStudyByStudyIdentifier(String studyIdentifier) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "archiveResearchStudyByStudyIdentifier";
        var args = new ArchiveResearchStudyByStudyIdentifierRequest {
          studyIdentifier = studyIdentifier
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<ArchiveResearchStudyByStudyIdentifierResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored Sites (based on schema version '1.5.0') </summary>
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
    /// <param name="siteIdentity"> Composite Key, which represents the primary identity of a Site </param>
    public Site GetSiteBySiteIdentity(SiteIdentity siteIdentity) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getSiteBySiteIdentity";
        var args = new GetSiteBySiteIdentityRequest {
          siteIdentity = siteIdentity
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetSiteBySiteIdentityResponse>(rawResponse);
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
    /// <param name="siteIdentity"> Composite Key, which represents the primary identity of a Site </param>
    /// <param name="site"> Site containing the new values (the primary identifier fields within the given Site will be ignored) </param>
    public Boolean UpdateSiteBySiteIdentity(SiteIdentity siteIdentity, Site site) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateSiteBySiteIdentity";
        var args = new UpdateSiteBySiteIdentityRequest {
          siteIdentity = siteIdentity,
          site = site
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateSiteBySiteIdentityResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific Site addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="siteIdentity"> Composite Key, which represents the primary identity of a Site </param>
    public Boolean ArchiveSiteBySiteIdentity(SiteIdentity siteIdentity) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "archiveSiteBySiteIdentity";
        var args = new ArchiveSiteBySiteIdentityRequest {
          siteIdentity = siteIdentity
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<ArchiveSiteBySiteIdentityResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored Subjects (based on schema version '1.5.0') </summary>
  internal partial class SubjectsClient : ISubjects {
    
    private string _Url;
    private string _ApiToken;
    
    public SubjectsClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific Subject addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="subjectIdentity"> Composite Key, which represents the primary identity of a Subject </param>
    public Subject GetSubjectBySubjectIdentity(SubjectIdentity subjectIdentity) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getSubjectBySubjectIdentity";
        var args = new GetSubjectBySubjectIdentityRequest {
          subjectIdentity = subjectIdentity
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetSubjectBySubjectIdentityResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads Subjects. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of Subjects which should be returned </param>
    public Subject[] GetSubjects(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getSubjects";
        var args = new GetSubjectsRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetSubjectsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads Subjects where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of Subjects which should be returned </param>
    public Subject[] SearchSubjects(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchSubjects";
        var args = new SearchSubjectsRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchSubjectsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new Subject and returns its primary identifier (or null on failure). </summary>
    /// <param name="subject"> Subject containing the new values </param>
    public Boolean AddNewSubject(Subject subject) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewSubject";
        var args = new AddNewSubjectRequest {
          subject = subject
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewSubjectResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Subject addressed by the primary identifier fields within the given Subject. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="subject"> Subject containing the new values (the primary identifier fields within the given Subject will be used to address the target record) </param>
    public Boolean UpdateSubject(Subject subject) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateSubject";
        var args = new UpdateSubjectRequest {
          subject = subject
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateSubjectResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Subject addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="subjectIdentity"> Composite Key, which represents the primary identity of a Subject </param>
    /// <param name="subject"> Subject containing the new values (the primary identifier fields within the given Subject will be ignored) </param>
    public Boolean UpdateSubjectBySubjectIdentity(SubjectIdentity subjectIdentity, Subject subject) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateSubjectBySubjectIdentity";
        var args = new UpdateSubjectBySubjectIdentityRequest {
          subjectIdentity = subjectIdentity,
          subject = subject
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateSubjectBySubjectIdentityResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific Subject addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="subjectIdentity"> Composite Key, which represents the primary identity of a Subject </param>
    public Boolean ArchiveSubjectBySubjectIdentity(SubjectIdentity subjectIdentity) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "archiveSubjectBySubjectIdentity";
        var args = new ArchiveSubjectBySubjectIdentityRequest {
          subjectIdentity = subjectIdentity
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<ArchiveSubjectBySubjectIdentityResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
}
