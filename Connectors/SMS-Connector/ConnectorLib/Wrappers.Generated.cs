using MedicalResearch.StudyManagement.Model;
using MedicalResearch.StudyManagement.StoreAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalResearch.StudyManagement.WebAPI.DTOs {
  
  /// <summary>
  /// Contains arguments for calling 'GetInstituteByInstituteUid'.
  /// Method: Loads a specific Institute addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetInstituteByInstituteUidRequest {
  
    /// <summary> Required Argument for 'GetInstituteByInstituteUid' (Guid): Represents the primary identity of a Institute </summary>
    [Required]
    public Guid instituteUid { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetInstituteByInstituteUid'.
  /// Method: Loads a specific Institute addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetInstituteByInstituteUidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetInstituteByInstituteUid' (Institute) </summary>
    public Institute @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetInstitutes'.
  /// Method: Loads Institutes.
  /// </summary>
  public class GetInstitutesRequest {
  
    /// <summary> Optional Argument for 'GetInstitutes' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'GetInstitutes' (Int32?): Max count of Institutes which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetInstitutes'.
  /// Method: Loads Institutes.
  /// </summary>
  public class GetInstitutesResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetInstitutes' (Institute[]) </summary>
    public Institute[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchInstitutes'.
  /// Method: Loads Institutes where values matching to the given filterExpression
  /// </summary>
  public class SearchInstitutesRequest {
  
    /// <summary> Required Argument for 'SearchInstitutes' (String): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public String filterExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchInstitutes' (String): one or more property names which are used as sort order (before pagination) </summary>
    public String sortingExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchInstitutes' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'SearchInstitutes' (Int32?): Max count of Institutes which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'SearchInstitutes'.
  /// Method: Loads Institutes where values matching to the given filterExpression
  /// </summary>
  public class SearchInstitutesResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'SearchInstitutes' (Institute[]) </summary>
    public Institute[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewInstitute'.
  /// Method: Adds a new Institute and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewInstituteRequest {
  
    /// <summary> Required Argument for 'AddNewInstitute' (Institute): Institute containing the new values </summary>
    [Required]
    public Institute institute { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewInstitute'.
  /// Method: Adds a new Institute and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewInstituteResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'AddNewInstitute' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateInstitute'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Institute addressed by the primary identifier fields within the given Institute. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateInstituteRequest {
  
    /// <summary> Required Argument for 'UpdateInstitute' (Institute): Institute containing the new values (the primary identifier fields within the given Institute will be used to address the target record) </summary>
    [Required]
    public Institute institute { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateInstitute'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Institute addressed by the primary identifier fields within the given Institute. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateInstituteResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateInstitute' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateInstituteByInstituteUid'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Institute addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateInstituteByInstituteUidRequest {
  
    /// <summary> Required Argument for 'UpdateInstituteByInstituteUid' (Guid): Represents the primary identity of a Institute </summary>
    [Required]
    public Guid instituteUid { get; set; }
  
    /// <summary> Required Argument for 'UpdateInstituteByInstituteUid' (Institute): Institute containing the new values (the primary identifier fields within the given Institute will be ignored) </summary>
    [Required]
    public Institute institute { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateInstituteByInstituteUid'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Institute addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateInstituteByInstituteUidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateInstituteByInstituteUid' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'ArchiveInstituteByInstituteUid'.
  /// Method: Deletes a specific Institute addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class ArchiveInstituteByInstituteUidRequest {
  
    /// <summary> Required Argument for 'ArchiveInstituteByInstituteUid' (Guid): Represents the primary identity of a Institute </summary>
    [Required]
    public Guid instituteUid { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'ArchiveInstituteByInstituteUid'.
  /// Method: Deletes a specific Institute addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class ArchiveInstituteByInstituteUidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'ArchiveInstituteByInstituteUid' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetResearchStudyByStudyIdentifier'.
  /// Method: Loads a specific ResearchStudy addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetResearchStudyByStudyIdentifierRequest {
  
    /// <summary> Required Argument for 'GetResearchStudyByStudyIdentifier' (String): Represents the primary identity of a ResearchStudy </summary>
    [Required]
    public String studyIdentifier { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetResearchStudyByStudyIdentifier'.
  /// Method: Loads a specific ResearchStudy addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetResearchStudyByStudyIdentifierResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetResearchStudyByStudyIdentifier' (ResearchStudy): entity, which relates to <see href="https://www.hl7.org/fhir/researchstudy.html">HL7.ResearchStudy</see> </summary>
    public ResearchStudy @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetResearchStudies'.
  /// Method: Loads ResearchStudies.
  /// </summary>
  public class GetResearchStudiesRequest {
  
    /// <summary> Optional Argument for 'GetResearchStudies' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'GetResearchStudies' (Int32?): Max count of ResearchStudies which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetResearchStudies'.
  /// Method: Loads ResearchStudies.
  /// </summary>
  public class GetResearchStudiesResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetResearchStudies' (ResearchStudy[]): entity, which relates to <see href="https://www.hl7.org/fhir/researchstudy.html">HL7.ResearchStudy</see> </summary>
    public ResearchStudy[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchResearchStudies'.
  /// Method: Loads ResearchStudies where values matching to the given filterExpression
  /// </summary>
  public class SearchResearchStudiesRequest {
  
    /// <summary> Required Argument for 'SearchResearchStudies' (String): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public String filterExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchResearchStudies' (String): one or more property names which are used as sort order (before pagination) </summary>
    public String sortingExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchResearchStudies' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'SearchResearchStudies' (Int32?): Max count of ResearchStudies which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'SearchResearchStudies'.
  /// Method: Loads ResearchStudies where values matching to the given filterExpression
  /// </summary>
  public class SearchResearchStudiesResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'SearchResearchStudies' (ResearchStudy[]): entity, which relates to <see href="https://www.hl7.org/fhir/researchstudy.html">HL7.ResearchStudy</see> </summary>
    public ResearchStudy[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewResearchStudy'.
  /// Method: Adds a new ResearchStudy and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewResearchStudyRequest {
  
    /// <summary> Required Argument for 'AddNewResearchStudy' (ResearchStudy): ResearchStudy containing the new values </summary>
    [Required]
    public ResearchStudy researchStudy { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewResearchStudy'.
  /// Method: Adds a new ResearchStudy and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewResearchStudyResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'AddNewResearchStudy' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateResearchStudy'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given ResearchStudy addressed by the primary identifier fields within the given ResearchStudy. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateResearchStudyRequest {
  
    /// <summary> Required Argument for 'UpdateResearchStudy' (ResearchStudy): ResearchStudy containing the new values (the primary identifier fields within the given ResearchStudy will be used to address the target record) </summary>
    [Required]
    public ResearchStudy researchStudy { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateResearchStudy'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given ResearchStudy addressed by the primary identifier fields within the given ResearchStudy. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateResearchStudyResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateResearchStudy' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateResearchStudyByStudyIdentifier'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given ResearchStudy addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateResearchStudyByStudyIdentifierRequest {
  
    /// <summary> Required Argument for 'UpdateResearchStudyByStudyIdentifier' (String): Represents the primary identity of a ResearchStudy </summary>
    [Required]
    public String studyIdentifier { get; set; }
  
    /// <summary> Required Argument for 'UpdateResearchStudyByStudyIdentifier' (ResearchStudy): ResearchStudy containing the new values (the primary identifier fields within the given ResearchStudy will be ignored) </summary>
    [Required]
    public ResearchStudy researchStudy { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateResearchStudyByStudyIdentifier'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given ResearchStudy addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateResearchStudyByStudyIdentifierResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateResearchStudyByStudyIdentifier' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'ArchiveResearchStudyByStudyIdentifier'.
  /// Method: Deletes a specific ResearchStudy addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class ArchiveResearchStudyByStudyIdentifierRequest {
  
    /// <summary> Required Argument for 'ArchiveResearchStudyByStudyIdentifier' (String): Represents the primary identity of a ResearchStudy </summary>
    [Required]
    public String studyIdentifier { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'ArchiveResearchStudyByStudyIdentifier'.
  /// Method: Deletes a specific ResearchStudy addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class ArchiveResearchStudyByStudyIdentifierResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'ArchiveResearchStudyByStudyIdentifier' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetSiteBySiteIdentity'.
  /// Method: Loads a specific Site addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetSiteBySiteIdentityRequest {
  
    /// <summary> Required Argument for 'GetSiteBySiteIdentity' (SiteIdentity): Composite Key, which represents the primary identity of a Site </summary>
    [Required]
    public SiteIdentity siteIdentity { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetSiteBySiteIdentity'.
  /// Method: Loads a specific Site addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetSiteBySiteIdentityResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetSiteBySiteIdentity' (Site) </summary>
    public Site @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetSites'.
  /// Method: Loads Sites.
  /// </summary>
  public class GetSitesRequest {
  
    /// <summary> Optional Argument for 'GetSites' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'GetSites' (Int32?): Max count of Sites which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetSites'.
  /// Method: Loads Sites.
  /// </summary>
  public class GetSitesResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetSites' (Site[]) </summary>
    public Site[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchSites'.
  /// Method: Loads Sites where values matching to the given filterExpression
  /// </summary>
  public class SearchSitesRequest {
  
    /// <summary> Required Argument for 'SearchSites' (String): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public String filterExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchSites' (String): one or more property names which are used as sort order (before pagination) </summary>
    public String sortingExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchSites' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'SearchSites' (Int32?): Max count of Sites which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'SearchSites'.
  /// Method: Loads Sites where values matching to the given filterExpression
  /// </summary>
  public class SearchSitesResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'SearchSites' (Site[]) </summary>
    public Site[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewSite'.
  /// Method: Adds a new Site and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewSiteRequest {
  
    /// <summary> Required Argument for 'AddNewSite' (Site): Site containing the new values </summary>
    [Required]
    public Site site { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewSite'.
  /// Method: Adds a new Site and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewSiteResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'AddNewSite' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateSite'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Site addressed by the primary identifier fields within the given Site. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSiteRequest {
  
    /// <summary> Required Argument for 'UpdateSite' (Site): Site containing the new values (the primary identifier fields within the given Site will be used to address the target record) </summary>
    [Required]
    public Site site { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateSite'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Site addressed by the primary identifier fields within the given Site. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSiteResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateSite' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateSiteBySiteIdentity'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Site addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSiteBySiteIdentityRequest {
  
    /// <summary> Required Argument for 'UpdateSiteBySiteIdentity' (SiteIdentity): Composite Key, which represents the primary identity of a Site </summary>
    [Required]
    public SiteIdentity siteIdentity { get; set; }
  
    /// <summary> Required Argument for 'UpdateSiteBySiteIdentity' (Site): Site containing the new values (the primary identifier fields within the given Site will be ignored) </summary>
    [Required]
    public Site site { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateSiteBySiteIdentity'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Site addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSiteBySiteIdentityResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateSiteBySiteIdentity' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'ArchiveSiteBySiteIdentity'.
  /// Method: Deletes a specific Site addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class ArchiveSiteBySiteIdentityRequest {
  
    /// <summary> Required Argument for 'ArchiveSiteBySiteIdentity' (SiteIdentity): Composite Key, which represents the primary identity of a Site </summary>
    [Required]
    public SiteIdentity siteIdentity { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'ArchiveSiteBySiteIdentity'.
  /// Method: Deletes a specific Site addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class ArchiveSiteBySiteIdentityResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'ArchiveSiteBySiteIdentity' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetSubjectBySubjectIdentity'.
  /// Method: Loads a specific Subject addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetSubjectBySubjectIdentityRequest {
  
    /// <summary> Required Argument for 'GetSubjectBySubjectIdentity' (SubjectIdentity): Composite Key, which represents the primary identity of a Subject </summary>
    [Required]
    public SubjectIdentity subjectIdentity { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetSubjectBySubjectIdentity'.
  /// Method: Loads a specific Subject addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetSubjectBySubjectIdentityResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetSubjectBySubjectIdentity' (Subject): entity, which relates to <see href="https://www.hl7.org/fhir/researchsubject.html">HL7.ResearchSubject</see> </summary>
    public Subject @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetSubjects'.
  /// Method: Loads Subjects.
  /// </summary>
  public class GetSubjectsRequest {
  
    /// <summary> Optional Argument for 'GetSubjects' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'GetSubjects' (Int32?): Max count of Subjects which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetSubjects'.
  /// Method: Loads Subjects.
  /// </summary>
  public class GetSubjectsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetSubjects' (Subject[]): entity, which relates to <see href="https://www.hl7.org/fhir/researchsubject.html">HL7.ResearchSubject</see> </summary>
    public Subject[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchSubjects'.
  /// Method: Loads Subjects where values matching to the given filterExpression
  /// </summary>
  public class SearchSubjectsRequest {
  
    /// <summary> Required Argument for 'SearchSubjects' (String): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public String filterExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchSubjects' (String): one or more property names which are used as sort order (before pagination) </summary>
    public String sortingExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchSubjects' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'SearchSubjects' (Int32?): Max count of Subjects which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'SearchSubjects'.
  /// Method: Loads Subjects where values matching to the given filterExpression
  /// </summary>
  public class SearchSubjectsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'SearchSubjects' (Subject[]): entity, which relates to <see href="https://www.hl7.org/fhir/researchsubject.html">HL7.ResearchSubject</see> </summary>
    public Subject[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewSubject'.
  /// Method: Adds a new Subject and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewSubjectRequest {
  
    /// <summary> Required Argument for 'AddNewSubject' (Subject): Subject containing the new values </summary>
    [Required]
    public Subject subject { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewSubject'.
  /// Method: Adds a new Subject and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewSubjectResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'AddNewSubject' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateSubject'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Subject addressed by the primary identifier fields within the given Subject. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectRequest {
  
    /// <summary> Required Argument for 'UpdateSubject' (Subject): Subject containing the new values (the primary identifier fields within the given Subject will be used to address the target record) </summary>
    [Required]
    public Subject subject { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateSubject'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Subject addressed by the primary identifier fields within the given Subject. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateSubject' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateSubjectBySubjectIdentity'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Subject addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectBySubjectIdentityRequest {
  
    /// <summary> Required Argument for 'UpdateSubjectBySubjectIdentity' (SubjectIdentity): Composite Key, which represents the primary identity of a Subject </summary>
    [Required]
    public SubjectIdentity subjectIdentity { get; set; }
  
    /// <summary> Required Argument for 'UpdateSubjectBySubjectIdentity' (Subject): Subject containing the new values (the primary identifier fields within the given Subject will be ignored) </summary>
    [Required]
    public Subject subject { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateSubjectBySubjectIdentity'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Subject addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectBySubjectIdentityResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateSubjectBySubjectIdentity' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'ArchiveSubjectBySubjectIdentity'.
  /// Method: Deletes a specific Subject addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class ArchiveSubjectBySubjectIdentityRequest {
  
    /// <summary> Required Argument for 'ArchiveSubjectBySubjectIdentity' (SubjectIdentity): Composite Key, which represents the primary identity of a Subject </summary>
    [Required]
    public SubjectIdentity subjectIdentity { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'ArchiveSubjectBySubjectIdentity'.
  /// Method: Deletes a specific Subject addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class ArchiveSubjectBySubjectIdentityResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'ArchiveSubjectBySubjectIdentity' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
}
