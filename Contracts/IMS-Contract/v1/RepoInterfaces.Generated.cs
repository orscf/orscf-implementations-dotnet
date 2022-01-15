using MedicalResearch.IdentityManagement.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace MedicalResearch.IdentityManagement.StoreAccess {

/// <summary> Provides CRUD access to stored AdditionalSubjectParticipationIdentifiers (based on schema version '1.5.0') </summary>
public partial interface IAdditionalSubjectParticipationIdentifiers {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding AdditionalSubjectParticipationIdentifiers.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific AdditionalSubjectParticipationIdentifier addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="additionalSubjectParticipationIdentifierIdentity"> Composite Key, which represents the primary identity of a AdditionalSubjectParticipationIdentifier </param>
  AdditionalSubjectParticipationIdentifier GetAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity(AdditionalSubjectParticipationIdentifierIdentity additionalSubjectParticipationIdentifierIdentity);

  /// <summary> Loads AdditionalSubjectParticipationIdentifiers. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of AdditionalSubjectParticipationIdentifiers which should be returned </param>
  AdditionalSubjectParticipationIdentifier[] GetAdditionalSubjectParticipationIdentifiers(int page = 1, int pageSize = 20);

  /// <summary> Loads AdditionalSubjectParticipationIdentifiers where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of AdditionalSubjectParticipationIdentifiers which should be returned</param>
  AdditionalSubjectParticipationIdentifier[] SearchAdditionalSubjectParticipationIdentifiers(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new AdditionalSubjectParticipationIdentifier and returns its primary identifier (or null on failure). </summary>
  /// <param name="additionalSubjectParticipationIdentifier"> AdditionalSubjectParticipationIdentifier containing the new values </param>
  bool AddNewAdditionalSubjectParticipationIdentifier(AdditionalSubjectParticipationIdentifier additionalSubjectParticipationIdentifier);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given AdditionalSubjectParticipationIdentifier addressed by the primary identifier fields within the given AdditionalSubjectParticipationIdentifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="additionalSubjectParticipationIdentifier"> AdditionalSubjectParticipationIdentifier containing the new values (the primary identifier fields within the given AdditionalSubjectParticipationIdentifier will be used to address the target record) </param>
  bool UpdateAdditionalSubjectParticipationIdentifier(AdditionalSubjectParticipationIdentifier additionalSubjectParticipationIdentifier);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given AdditionalSubjectParticipationIdentifier addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="additionalSubjectParticipationIdentifierIdentity"> Composite Key, which represents the primary identity of a AdditionalSubjectParticipationIdentifier </param>
  /// <param name="additionalSubjectParticipationIdentifier"> AdditionalSubjectParticipationIdentifier containing the new values (the primary identifier fields within the given AdditionalSubjectParticipationIdentifier will be ignored) </param>
  bool UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity(AdditionalSubjectParticipationIdentifierIdentity additionalSubjectParticipationIdentifierIdentity, AdditionalSubjectParticipationIdentifier additionalSubjectParticipationIdentifier);

  /// <summary> Deletes a specific AdditionalSubjectParticipationIdentifier addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="additionalSubjectParticipationIdentifierIdentity"> Composite Key, which represents the primary identity of a AdditionalSubjectParticipationIdentifier </param>
  bool DeleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity(AdditionalSubjectParticipationIdentifierIdentity additionalSubjectParticipationIdentifierIdentity);

}

/// <summary> Composite Key, which represents the primary identity of a AdditionalSubjectParticipationIdentifier </summary>
public class AdditionalSubjectParticipationIdentifierIdentity {
  public String ParticipantIdentifier;
  public String IdentifierName;
  public Guid ResearchStudyUid;
}

/// <summary> Provides CRUD access to stored SubjectParticipations (based on schema version '1.5.0') </summary>
public partial interface ISubjectParticipations {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding SubjectParticipations.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific SubjectParticipation addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="subjectParticipationIdentity"> Composite Key, which represents the primary identity of a SubjectParticipation </param>
  SubjectParticipation GetSubjectParticipationBySubjectParticipationIdentity(SubjectParticipationIdentity subjectParticipationIdentity);

  /// <summary> Loads SubjectParticipations. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of SubjectParticipations which should be returned </param>
  SubjectParticipation[] GetSubjectParticipations(int page = 1, int pageSize = 20);

  /// <summary> Loads SubjectParticipations where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of SubjectParticipations which should be returned</param>
  SubjectParticipation[] SearchSubjectParticipations(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new SubjectParticipation and returns its primary identifier (or null on failure). </summary>
  /// <param name="subjectParticipation"> SubjectParticipation containing the new values </param>
  bool AddNewSubjectParticipation(SubjectParticipation subjectParticipation);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectParticipation addressed by the primary identifier fields within the given SubjectParticipation. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="subjectParticipation"> SubjectParticipation containing the new values (the primary identifier fields within the given SubjectParticipation will be used to address the target record) </param>
  bool UpdateSubjectParticipation(SubjectParticipation subjectParticipation);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectParticipation addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="subjectParticipationIdentity"> Composite Key, which represents the primary identity of a SubjectParticipation </param>
  /// <param name="subjectParticipation"> SubjectParticipation containing the new values (the primary identifier fields within the given SubjectParticipation will be ignored) </param>
  bool UpdateSubjectParticipationBySubjectParticipationIdentity(SubjectParticipationIdentity subjectParticipationIdentity, SubjectParticipation subjectParticipation);

  /// <summary> Deletes a specific SubjectParticipation addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="subjectParticipationIdentity"> Composite Key, which represents the primary identity of a SubjectParticipation </param>
  bool DeleteSubjectParticipationBySubjectParticipationIdentity(SubjectParticipationIdentity subjectParticipationIdentity);

}

/// <summary> Composite Key, which represents the primary identity of a SubjectParticipation </summary>
public class SubjectParticipationIdentity {
  /// <summary> pseudonym of the patient which can be a randomization or screening number (the exact semantic is defined per study) </summary>
  public String ParticipantIdentifier;
  public Guid ResearchStudyUid;
}

/// <summary> Provides CRUD access to stored StudyExecutionScopes (based on schema version '1.5.0') </summary>
public partial interface IStudyExecutionScopes {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding StudyExecutionScopes.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific StudyExecutionScope addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="studyExecutionIdentifier"> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </param>
  StudyExecutionScope GetStudyExecutionScopeByStudyExecutionIdentifier(Guid studyExecutionIdentifier);

  /// <summary> Loads StudyExecutionScopes. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of StudyExecutionScopes which should be returned </param>
  StudyExecutionScope[] GetStudyExecutionScopes(int page = 1, int pageSize = 20);

  /// <summary> Loads StudyExecutionScopes where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of StudyExecutionScopes which should be returned</param>
  StudyExecutionScope[] SearchStudyExecutionScopes(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new StudyExecutionScope and returns its primary identifier (or null on failure). </summary>
  /// <param name="studyExecutionScope"> StudyExecutionScope containing the new values </param>
  bool AddNewStudyExecutionScope(StudyExecutionScope studyExecutionScope);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyExecutionScope addressed by the primary identifier fields within the given StudyExecutionScope. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="studyExecutionScope"> StudyExecutionScope containing the new values (the primary identifier fields within the given StudyExecutionScope will be used to address the target record) </param>
  bool UpdateStudyExecutionScope(StudyExecutionScope studyExecutionScope);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyExecutionScope addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="studyExecutionIdentifier"> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </param>
  /// <param name="studyExecutionScope"> StudyExecutionScope containing the new values (the primary identifier fields within the given StudyExecutionScope will be ignored) </param>
  bool UpdateStudyExecutionScopeByStudyExecutionIdentifier(Guid studyExecutionIdentifier, StudyExecutionScope studyExecutionScope);

  /// <summary> Deletes a specific StudyExecutionScope addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="studyExecutionIdentifier"> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </param>
  bool DeleteStudyExecutionScopeByStudyExecutionIdentifier(Guid studyExecutionIdentifier);

}

/// <summary> Provides CRUD access to stored StudyScopes (based on schema version '1.5.0') </summary>
public partial interface IStudyScopes {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding StudyScopes.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific StudyScope addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="researchStudyUid"> the official invariant name of the study as given by the sponsor </param>
  StudyScope GetStudyScopeByResearchStudyUid(Guid researchStudyUid);

  /// <summary> Loads StudyScopes. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of StudyScopes which should be returned </param>
  StudyScope[] GetStudyScopes(int page = 1, int pageSize = 20);

  /// <summary> Loads StudyScopes where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of StudyScopes which should be returned</param>
  StudyScope[] SearchStudyScopes(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new StudyScope and returns its primary identifier (or null on failure). </summary>
  /// <param name="studyScope"> StudyScope containing the new values </param>
  bool AddNewStudyScope(StudyScope studyScope);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyScope addressed by the primary identifier fields within the given StudyScope. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="studyScope"> StudyScope containing the new values (the primary identifier fields within the given StudyScope will be used to address the target record) </param>
  bool UpdateStudyScope(StudyScope studyScope);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyScope addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="researchStudyUid"> the official invariant name of the study as given by the sponsor </param>
  /// <param name="studyScope"> StudyScope containing the new values (the primary identifier fields within the given StudyScope will be ignored) </param>
  bool UpdateStudyScopeByResearchStudyUid(Guid researchStudyUid, StudyScope studyScope);

  /// <summary> Deletes a specific StudyScope addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="researchStudyUid"> the official invariant name of the study as given by the sponsor </param>
  bool DeleteStudyScopeByResearchStudyUid(Guid researchStudyUid);

}

/// <summary> Provides CRUD access to stored SubjectAddresses (based on schema version '1.5.0') </summary>
public partial interface ISubjectAddresses {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding SubjectAddresses.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific SubjectAddress addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="internalRecordId"> Represents the primary identity of a SubjectAddress </param>
  SubjectAddress GetSubjectAddressByInternalRecordId(Guid internalRecordId);

  /// <summary> Loads SubjectAddresses. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of SubjectAddresses which should be returned </param>
  SubjectAddress[] GetSubjectAddresses(int page = 1, int pageSize = 20);

  /// <summary> Loads SubjectAddresses where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of SubjectAddresses which should be returned</param>
  SubjectAddress[] SearchSubjectAddresses(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new SubjectAddress and returns its primary identifier (or null on failure). </summary>
  /// <param name="subjectAddress"> SubjectAddress containing the new values </param>
  bool AddNewSubjectAddress(SubjectAddress subjectAddress);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectAddress addressed by the primary identifier fields within the given SubjectAddress. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="subjectAddress"> SubjectAddress containing the new values (the primary identifier fields within the given SubjectAddress will be used to address the target record) </param>
  bool UpdateSubjectAddress(SubjectAddress subjectAddress);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectAddress addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="internalRecordId"> Represents the primary identity of a SubjectAddress </param>
  /// <param name="subjectAddress"> SubjectAddress containing the new values (the primary identifier fields within the given SubjectAddress will be ignored) </param>
  bool UpdateSubjectAddressByInternalRecordId(Guid internalRecordId, SubjectAddress subjectAddress);

  /// <summary> Deletes a specific SubjectAddress addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="internalRecordId"> Represents the primary identity of a SubjectAddress </param>
  bool DeleteSubjectAddressByInternalRecordId(Guid internalRecordId);

}

/// <summary> Provides CRUD access to stored SubjectIdentities (based on schema version '1.5.0') </summary>
public partial interface ISubjectIdentities {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding SubjectIdentities.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific SubjectIdentity addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="recordId"> Represents the primary identity of a SubjectIdentity </param>
  SubjectIdentity GetSubjectIdentityByRecordId(Guid recordId);

  /// <summary> Loads SubjectIdentities. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of SubjectIdentities which should be returned </param>
  SubjectIdentity[] GetSubjectIdentities(int page = 1, int pageSize = 20);

  /// <summary> Loads SubjectIdentities where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of SubjectIdentities which should be returned</param>
  SubjectIdentity[] SearchSubjectIdentities(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new SubjectIdentity and returns its primary identifier (or null on failure). </summary>
  /// <param name="subjectIdentity"> SubjectIdentity containing the new values </param>
  bool AddNewSubjectIdentity(SubjectIdentity subjectIdentity);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectIdentity addressed by the primary identifier fields within the given SubjectIdentity. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="subjectIdentity"> SubjectIdentity containing the new values (the primary identifier fields within the given SubjectIdentity will be used to address the target record) </param>
  bool UpdateSubjectIdentity(SubjectIdentity subjectIdentity);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectIdentity addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="recordId"> Represents the primary identity of a SubjectIdentity </param>
  /// <param name="subjectIdentity"> SubjectIdentity containing the new values (the primary identifier fields within the given SubjectIdentity will be ignored) </param>
  bool UpdateSubjectIdentityByRecordId(Guid recordId, SubjectIdentity subjectIdentity);

  /// <summary> Deletes a specific SubjectIdentity addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="recordId"> Represents the primary identity of a SubjectIdentity </param>
  bool DeleteSubjectIdentityByRecordId(Guid recordId);

}

}
