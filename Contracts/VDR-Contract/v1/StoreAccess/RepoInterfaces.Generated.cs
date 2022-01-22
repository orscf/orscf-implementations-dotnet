using MedicalResearch.VisitData.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace MedicalResearch.VisitData.StoreAccess {

/// <summary> Provides CRUD access to stored DataRecordings (based on schema version '1.5.0') </summary>
public partial interface IDataRecordings {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding DataRecordings.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific DataRecording addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  DataRecording GetDataRecordingByTaskGuid(Guid taskGuid);

  /// <summary> Loads DataRecordings. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of DataRecordings which should be returned </param>
  DataRecording[] GetDataRecordings(int page = 1, int pageSize = 20);

  /// <summary> Loads DataRecordings where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of DataRecordings which should be returned</param>
  DataRecording[] SearchDataRecordings(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new DataRecording and returns its primary identifier (or null on failure). </summary>
  /// <param name="dataRecording"> DataRecording containing the new values </param>
  bool AddNewDataRecording(DataRecording dataRecording);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DataRecording addressed by the primary identifier fields within the given DataRecording. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="dataRecording"> DataRecording containing the new values (the primary identifier fields within the given DataRecording will be used to address the target record) </param>
  bool UpdateDataRecording(DataRecording dataRecording);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DataRecording addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  /// <param name="dataRecording"> DataRecording containing the new values (the primary identifier fields within the given DataRecording will be ignored) </param>
  bool UpdateDataRecordingByTaskGuid(Guid taskGuid, DataRecording dataRecording);

  /// <summary> Deletes a specific DataRecording addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  bool DeleteDataRecordingByTaskGuid(Guid taskGuid);

}

/// <summary> Provides CRUD access to stored Visits (based on schema version '1.5.0') </summary>
public partial interface IVisits {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding Visits.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific Visit addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="visitGuid"> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  Visit GetVisitByVisitGuid(Guid visitGuid);

  /// <summary> Loads Visits. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of Visits which should be returned </param>
  Visit[] GetVisits(int page = 1, int pageSize = 20);

  /// <summary> Loads Visits where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of Visits which should be returned</param>
  Visit[] SearchVisits(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new Visit and returns its primary identifier (or null on failure). </summary>
  /// <param name="visit"> Visit containing the new values </param>
  bool AddNewVisit(Visit visit);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Visit addressed by the primary identifier fields within the given Visit. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="visit"> Visit containing the new values (the primary identifier fields within the given Visit will be used to address the target record) </param>
  bool UpdateVisit(Visit visit);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Visit addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="visitGuid"> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  /// <param name="visit"> Visit containing the new values (the primary identifier fields within the given Visit will be ignored) </param>
  bool UpdateVisitByVisitGuid(Guid visitGuid, Visit visit);

  /// <summary> Deletes a specific Visit addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="visitGuid"> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  bool DeleteVisitByVisitGuid(Guid visitGuid);

}

/// <summary> Provides CRUD access to stored DrugApplyments (based on schema version '1.5.0') </summary>
public partial interface IDrugApplyments {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding DrugApplyments.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific DrugApplyment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  DrugApplyment GetDrugApplymentByTaskGuid(Guid taskGuid);

  /// <summary> Loads DrugApplyments. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of DrugApplyments which should be returned </param>
  DrugApplyment[] GetDrugApplyments(int page = 1, int pageSize = 20);

  /// <summary> Loads DrugApplyments where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of DrugApplyments which should be returned</param>
  DrugApplyment[] SearchDrugApplyments(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new DrugApplyment and returns its primary identifier (or null on failure). </summary>
  /// <param name="drugApplyment"> DrugApplyment containing the new values </param>
  bool AddNewDrugApplyment(DrugApplyment drugApplyment);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DrugApplyment addressed by the primary identifier fields within the given DrugApplyment. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="drugApplyment"> DrugApplyment containing the new values (the primary identifier fields within the given DrugApplyment will be used to address the target record) </param>
  bool UpdateDrugApplyment(DrugApplyment drugApplyment);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DrugApplyment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  /// <param name="drugApplyment"> DrugApplyment containing the new values (the primary identifier fields within the given DrugApplyment will be ignored) </param>
  bool UpdateDrugApplymentByTaskGuid(Guid taskGuid, DrugApplyment drugApplyment);

  /// <summary> Deletes a specific DrugApplyment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  bool DeleteDrugApplymentByTaskGuid(Guid taskGuid);

}

/// <summary> Provides CRUD access to stored StudyEvents (based on schema version '1.5.0') </summary>
public partial interface IStudyEvents {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding StudyEvents.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific StudyEvent addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="eventGuid"> a global unique id of a concrete study-event occurrence which is usually originated at the primary CRF or study management system ('SMS') </param>
  StudyEvent GetStudyEventByEventGuid(Guid eventGuid);

  /// <summary> Loads StudyEvents. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of StudyEvents which should be returned </param>
  StudyEvent[] GetStudyEvents(int page = 1, int pageSize = 20);

  /// <summary> Loads StudyEvents where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of StudyEvents which should be returned</param>
  StudyEvent[] SearchStudyEvents(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new StudyEvent and returns its primary identifier (or null on failure). </summary>
  /// <param name="studyEvent"> StudyEvent containing the new values </param>
  bool AddNewStudyEvent(StudyEvent studyEvent);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyEvent addressed by the primary identifier fields within the given StudyEvent. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="studyEvent"> StudyEvent containing the new values (the primary identifier fields within the given StudyEvent will be used to address the target record) </param>
  bool UpdateStudyEvent(StudyEvent studyEvent);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyEvent addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="eventGuid"> a global unique id of a concrete study-event occurrence which is usually originated at the primary CRF or study management system ('SMS') </param>
  /// <param name="studyEvent"> StudyEvent containing the new values (the primary identifier fields within the given StudyEvent will be ignored) </param>
  bool UpdateStudyEventByEventGuid(Guid eventGuid, StudyEvent studyEvent);

  /// <summary> Deletes a specific StudyEvent addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="eventGuid"> a global unique id of a concrete study-event occurrence which is usually originated at the primary CRF or study management system ('SMS') </param>
  bool DeleteStudyEventByEventGuid(Guid eventGuid);

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

/// <summary> Provides CRUD access to stored Treatments (based on schema version '1.5.0') </summary>
public partial interface ITreatments {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding Treatments.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific Treatment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  Treatment GetTreatmentByTaskGuid(Guid taskGuid);

  /// <summary> Loads Treatments. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of Treatments which should be returned </param>
  Treatment[] GetTreatments(int page = 1, int pageSize = 20);

  /// <summary> Loads Treatments where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of Treatments which should be returned</param>
  Treatment[] SearchTreatments(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new Treatment and returns its primary identifier (or null on failure). </summary>
  /// <param name="treatment"> Treatment containing the new values </param>
  bool AddNewTreatment(Treatment treatment);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Treatment addressed by the primary identifier fields within the given Treatment. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="treatment"> Treatment containing the new values (the primary identifier fields within the given Treatment will be used to address the target record) </param>
  bool UpdateTreatment(Treatment treatment);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Treatment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  /// <param name="treatment"> Treatment containing the new values (the primary identifier fields within the given Treatment will be ignored) </param>
  bool UpdateTreatmentByTaskGuid(Guid taskGuid, Treatment treatment);

  /// <summary> Deletes a specific Treatment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  bool DeleteTreatmentByTaskGuid(Guid taskGuid);

}

}
