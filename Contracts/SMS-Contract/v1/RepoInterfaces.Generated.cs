using MedicalResearch.StudyManagement.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace MedicalResearch.StudyManagement.StoreAccess {

/// <summary> Provides CRUD access to stored Institutes (based on schema version '1.5.0') </summary>
public partial interface IInstitutes {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding Institutes.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific Institute addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="instituteUid"> Represents the primary identity of a Institute </param>
  Institute GetInstituteByInstituteUid(Guid instituteUid);

  /// <summary> Loads Institutes. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of Institutes which should be returned </param>
  Institute[] GetInstitutes(int page = 1, int pageSize = 20);

  /// <summary> Loads Institutes where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of Institutes which should be returned</param>
  Institute[] SearchInstitutes(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new Institute and returns its primary identifier (or null on failure). </summary>
  /// <param name="institute"> Institute containing the new values </param>
  bool AddNewInstitute(Institute institute);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Institute addressed by the primary identifier fields within the given Institute. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="institute"> Institute containing the new values (the primary identifier fields within the given Institute will be used to address the target record) </param>
  bool UpdateInstitute(Institute institute);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Institute addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="instituteUid"> Represents the primary identity of a Institute </param>
  /// <param name="institute"> Institute containing the new values (the primary identifier fields within the given Institute will be ignored) </param>
  bool UpdateInstituteByInstituteUid(Guid instituteUid, Institute institute);

  /// <summary> Deletes a specific Institute addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="instituteUid"> Represents the primary identity of a Institute </param>
  bool ArchiveInstituteByInstituteUid(Guid instituteUid);

}

/// <summary> Provides CRUD access to stored ResearchStudies (based on schema version '1.5.0') </summary>
public partial interface IResearchStudies {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding ResearchStudies.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific ResearchStudy addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="studyIdentifier"> Represents the primary identity of a ResearchStudy </param>
  ResearchStudy GetResearchStudyByStudyIdentifier(String studyIdentifier);

  /// <summary> Loads ResearchStudies. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of ResearchStudies which should be returned </param>
  ResearchStudy[] GetResearchStudies(int page = 1, int pageSize = 20);

  /// <summary> Loads ResearchStudies where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of ResearchStudies which should be returned</param>
  ResearchStudy[] SearchResearchStudies(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new ResearchStudy and returns its primary identifier (or null on failure). </summary>
  /// <param name="researchStudy"> ResearchStudy containing the new values </param>
  bool AddNewResearchStudy(ResearchStudy researchStudy);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ResearchStudy addressed by the primary identifier fields within the given ResearchStudy. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="researchStudy"> ResearchStudy containing the new values (the primary identifier fields within the given ResearchStudy will be used to address the target record) </param>
  bool UpdateResearchStudy(ResearchStudy researchStudy);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ResearchStudy addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="studyIdentifier"> Represents the primary identity of a ResearchStudy </param>
  /// <param name="researchStudy"> ResearchStudy containing the new values (the primary identifier fields within the given ResearchStudy will be ignored) </param>
  bool UpdateResearchStudyByStudyIdentifier(String studyIdentifier, ResearchStudy researchStudy);

  /// <summary> Deletes a specific ResearchStudy addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="studyIdentifier"> Represents the primary identity of a ResearchStudy </param>
  bool ArchiveResearchStudyByStudyIdentifier(String studyIdentifier);

}

/// <summary> Provides CRUD access to stored Sites (based on schema version '1.5.0') </summary>
public partial interface ISites {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding Sites.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific Site addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="siteIdentity"> Composite Key, which represents the primary identity of a Site </param>
  Site GetSiteBySiteIdentity(SiteIdentity siteIdentity);

  /// <summary> Loads Sites. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of Sites which should be returned </param>
  Site[] GetSites(int page = 1, int pageSize = 20);

  /// <summary> Loads Sites where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of Sites which should be returned</param>
  Site[] SearchSites(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new Site and returns its primary identifier (or null on failure). </summary>
  /// <param name="site"> Site containing the new values </param>
  bool AddNewSite(Site site);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Site addressed by the primary identifier fields within the given Site. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="site"> Site containing the new values (the primary identifier fields within the given Site will be used to address the target record) </param>
  bool UpdateSite(Site site);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Site addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="siteIdentity"> Composite Key, which represents the primary identity of a Site </param>
  /// <param name="site"> Site containing the new values (the primary identifier fields within the given Site will be ignored) </param>
  bool UpdateSiteBySiteIdentity(SiteIdentity siteIdentity, Site site);

  /// <summary> Deletes a specific Site addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="siteIdentity"> Composite Key, which represents the primary identity of a Site </param>
  bool ArchiveSiteBySiteIdentity(SiteIdentity siteIdentity);

}

/// <summary> Composite Key, which represents the primary identity of a Site </summary>
public class SiteIdentity {
  public String SiteIdentifier;
  public String StudyIdentifier;
}

/// <summary> Provides CRUD access to stored Subjects (based on schema version '1.5.0') </summary>
public partial interface ISubjects {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding Subjects.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific Subject addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="subjectIdentity"> Composite Key, which represents the primary identity of a Subject </param>
  Subject GetSubjectBySubjectIdentity(SubjectIdentity subjectIdentity);

  /// <summary> Loads Subjects. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of Subjects which should be returned </param>
  Subject[] GetSubjects(int page = 1, int pageSize = 20);

  /// <summary> Loads Subjects where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of Subjects which should be returned</param>
  Subject[] SearchSubjects(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new Subject and returns its primary identifier (or null on failure). </summary>
  /// <param name="subject"> Subject containing the new values </param>
  bool AddNewSubject(Subject subject);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Subject addressed by the primary identifier fields within the given Subject. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="subject"> Subject containing the new values (the primary identifier fields within the given Subject will be used to address the target record) </param>
  bool UpdateSubject(Subject subject);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Subject addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="subjectIdentity"> Composite Key, which represents the primary identity of a Subject </param>
  /// <param name="subject"> Subject containing the new values (the primary identifier fields within the given Subject will be ignored) </param>
  bool UpdateSubjectBySubjectIdentity(SubjectIdentity subjectIdentity, Subject subject);

  /// <summary> Deletes a specific Subject addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="subjectIdentity"> Composite Key, which represents the primary identity of a Subject </param>
  bool ArchiveSubjectBySubjectIdentity(SubjectIdentity subjectIdentity);

}

/// <summary> Composite Key, which represents the primary identity of a Subject </summary>
public class SubjectIdentity {
  public String CandidateIdentifier;
  public String StudyIdentifier;
}

}
