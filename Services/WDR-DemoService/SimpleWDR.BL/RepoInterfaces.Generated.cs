using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace MedicalResearch.Workflow.Persistence {

/// <summary> Provides CRUD access to stored Arms (based on schema version '1.3.0') </summary>
public partial interface IArmRepository {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding Arms.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific Arm addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="armIdentity"> Composite Key, which represents the primary identity of a Arm </param>
  Arm GetArmByArmIdentity(ArmIdentity armIdentity);

  /// <summary> Loads Arms. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of Arms which should be returned </param>
  Arm[] GetArms(int page = 1, int pageSize = 20);

  /// <summary> Loads Arms where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of Arms which should be returned</param>
  Arm[] SearchArms(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new Arm and returns its primary identifier (or null on failure). </summary>
  /// <param name="arm"> Arm containing the new values </param>
  bool AddNewArm(Arm arm);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Arm addressed by the primary identifier fields within the given Arm. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="arm"> Arm containing the new values (the primary identifier fields within the given Arm will be used to address the target record) </param>
  bool UpdateArm(Arm arm);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Arm addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="armIdentity"> Composite Key, which represents the primary identity of a Arm </param>
  /// <param name="arm"> Arm containing the new values (the primary identifier fields within the given Arm will be ignored) </param>
  bool UpdateArmByArmIdentity(ArmIdentity armIdentity, Arm arm);

  /// <summary> Deletes a specific Arm addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="armIdentity"> Composite Key, which represents the primary identity of a Arm </param>
  bool DeleteArmByArmIdentity(ArmIdentity armIdentity);

}

/// <summary> Composite Key, which represents the primary identity of a Arm </summary>
public class ArmIdentity {
  public String StudyArmName;
  public String StudyWorkflowName;
  public String StudyWorkflowVersion;
}

/// <summary> Provides CRUD access to stored ResearchStudies (based on schema version '1.3.0') </summary>
public partial interface IResearchStudyRepository {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding ResearchStudies.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific ResearchStudy addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="researchStudyIdentity"> Composite Key, which represents the primary identity of a ResearchStudy </param>
  ResearchStudy GetResearchStudyByResearchStudyIdentity(ResearchStudyIdentity researchStudyIdentity);

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
  /// <param name="researchStudyIdentity"> Composite Key, which represents the primary identity of a ResearchStudy </param>
  /// <param name="researchStudy"> ResearchStudy containing the new values (the primary identifier fields within the given ResearchStudy will be ignored) </param>
  bool UpdateResearchStudyByResearchStudyIdentity(ResearchStudyIdentity researchStudyIdentity, ResearchStudy researchStudy);

  /// <summary> Deletes a specific ResearchStudy addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="researchStudyIdentity"> Composite Key, which represents the primary identity of a ResearchStudy </param>
  bool DeleteResearchStudyByResearchStudyIdentity(ResearchStudyIdentity researchStudyIdentity);

}

/// <summary> Composite Key, which represents the primary identity of a ResearchStudy </summary>
public class ResearchStudyIdentity {
  /// <summary> the official invariant name of the study as given by the sponsor </summary>
  public String StudyWorkflowName;
  /// <summary> This value follows the rules of 'Semantic Versioning' (https://semver.org) and needs to be updated exactly and only on transition to DraftState.Released! If the previously DraftState was 'DraftNewFix', then the 3. number must be increased at this time! If the previously DraftState was 'DraftNewMinor', then the 2. number must be increased, and the 3. number must be set to 0 at this time! If the previously DraftState was 'DraftNewMajor', then the 1. number must be increased, and the 2.+3. number must be set to 0 at this time! </summary>
  public String StudyWorkflowVersion;
}

/// <summary> Provides CRUD access to stored ProcedureSchedules (based on schema version '1.3.0') </summary>
public partial interface IProcedureScheduleRepository {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding ProcedureSchedules.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific ProcedureSchedule addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="procedureScheduleId"> Represents the primary identity of a ProcedureSchedule </param>
  ProcedureSchedule GetProcedureScheduleByProcedureScheduleId(Guid procedureScheduleId);

  /// <summary> Loads ProcedureSchedules. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of ProcedureSchedules which should be returned </param>
  ProcedureSchedule[] GetProcedureSchedules(int page = 1, int pageSize = 20);

  /// <summary> Loads ProcedureSchedules where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of ProcedureSchedules which should be returned</param>
  ProcedureSchedule[] SearchProcedureSchedules(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new ProcedureSchedule and returns its primary identifier (or null on failure). </summary>
  /// <param name="procedureSchedule"> ProcedureSchedule containing the new values </param>
  bool AddNewProcedureSchedule(ProcedureSchedule procedureSchedule);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ProcedureSchedule addressed by the primary identifier fields within the given ProcedureSchedule. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="procedureSchedule"> ProcedureSchedule containing the new values (the primary identifier fields within the given ProcedureSchedule will be used to address the target record) </param>
  bool UpdateProcedureSchedule(ProcedureSchedule procedureSchedule);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ProcedureSchedule addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="procedureScheduleId"> Represents the primary identity of a ProcedureSchedule </param>
  /// <param name="procedureSchedule"> ProcedureSchedule containing the new values (the primary identifier fields within the given ProcedureSchedule will be ignored) </param>
  bool UpdateProcedureScheduleByProcedureScheduleId(Guid procedureScheduleId, ProcedureSchedule procedureSchedule);

  /// <summary> Deletes a specific ProcedureSchedule addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="procedureScheduleId"> Represents the primary identity of a ProcedureSchedule </param>
  bool DeleteProcedureScheduleByProcedureScheduleId(Guid procedureScheduleId);

}

/// <summary> Provides CRUD access to stored DataRecordingTasks (based on schema version '1.3.0') </summary>
public partial interface IDataRecordingTaskRepository {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding DataRecordingTasks.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific DataRecordingTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="dataRecordingName"> Represents the primary identity of a DataRecordingTask </param>
  DataRecordingTask GetDataRecordingTaskByDataRecordingName(String dataRecordingName);

  /// <summary> Loads DataRecordingTasks. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of DataRecordingTasks which should be returned </param>
  DataRecordingTask[] GetDataRecordingTasks(int page = 1, int pageSize = 20);

  /// <summary> Loads DataRecordingTasks where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of DataRecordingTasks which should be returned</param>
  DataRecordingTask[] SearchDataRecordingTasks(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new DataRecordingTask and returns its primary identifier (or null on failure). </summary>
  /// <param name="dataRecordingTask"> DataRecordingTask containing the new values </param>
  bool AddNewDataRecordingTask(DataRecordingTask dataRecordingTask);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DataRecordingTask addressed by the primary identifier fields within the given DataRecordingTask. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="dataRecordingTask"> DataRecordingTask containing the new values (the primary identifier fields within the given DataRecordingTask will be used to address the target record) </param>
  bool UpdateDataRecordingTask(DataRecordingTask dataRecordingTask);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DataRecordingTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="dataRecordingName"> Represents the primary identity of a DataRecordingTask </param>
  /// <param name="dataRecordingTask"> DataRecordingTask containing the new values (the primary identifier fields within the given DataRecordingTask will be ignored) </param>
  bool UpdateDataRecordingTaskByDataRecordingName(String dataRecordingName, DataRecordingTask dataRecordingTask);

  /// <summary> Deletes a specific DataRecordingTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="dataRecordingName"> Represents the primary identity of a DataRecordingTask </param>
  bool DeleteDataRecordingTaskByDataRecordingName(String dataRecordingName);

}

/// <summary> Provides CRUD access to stored InducedDataRecordingTasks (based on schema version '1.3.0') </summary>
public partial interface IInducedDataRecordingTaskRepository {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding InducedDataRecordingTasks.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific InducedDataRecordingTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="id"> Represents the primary identity of a InducedDataRecordingTask </param>
  InducedDataRecordingTask GetInducedDataRecordingTaskById(Guid id);

  /// <summary> Loads InducedDataRecordingTasks. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of InducedDataRecordingTasks which should be returned </param>
  InducedDataRecordingTask[] GetInducedDataRecordingTasks(int page = 1, int pageSize = 20);

  /// <summary> Loads InducedDataRecordingTasks where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of InducedDataRecordingTasks which should be returned</param>
  InducedDataRecordingTask[] SearchInducedDataRecordingTasks(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new InducedDataRecordingTask and returns its primary identifier (or null on failure). </summary>
  /// <param name="inducedDataRecordingTask"> InducedDataRecordingTask containing the new values </param>
  bool AddNewInducedDataRecordingTask(InducedDataRecordingTask inducedDataRecordingTask);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedDataRecordingTask addressed by the primary identifier fields within the given InducedDataRecordingTask. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="inducedDataRecordingTask"> InducedDataRecordingTask containing the new values (the primary identifier fields within the given InducedDataRecordingTask will be used to address the target record) </param>
  bool UpdateInducedDataRecordingTask(InducedDataRecordingTask inducedDataRecordingTask);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedDataRecordingTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedDataRecordingTask </param>
  /// <param name="inducedDataRecordingTask"> InducedDataRecordingTask containing the new values (the primary identifier fields within the given InducedDataRecordingTask will be ignored) </param>
  bool UpdateInducedDataRecordingTaskById(Guid id, InducedDataRecordingTask inducedDataRecordingTask);

  /// <summary> Deletes a specific InducedDataRecordingTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedDataRecordingTask </param>
  bool DeleteInducedDataRecordingTaskById(Guid id);

}

/// <summary> Provides CRUD access to stored DrugAppliymentTasks (based on schema version '1.3.0') </summary>
public partial interface IDrugApplymentTaskRepository {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding DrugAppliymentTasks.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific DrugApplymentTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="drugApplymentName"> Represents the primary identity of a DrugApplymentTask </param>
  DrugApplymentTask GetDrugApplymentTaskByDrugApplymentName(String drugApplymentName);

  /// <summary> Loads DrugAppliymentTasks. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of DrugAppliymentTasks which should be returned </param>
  DrugApplymentTask[] GetDrugAppliymentTasks(int page = 1, int pageSize = 20);

  /// <summary> Loads DrugAppliymentTasks where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of DrugAppliymentTasks which should be returned</param>
  DrugApplymentTask[] SearchDrugAppliymentTasks(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new DrugApplymentTask and returns its primary identifier (or null on failure). </summary>
  /// <param name="drugApplymentTask"> DrugApplymentTask containing the new values </param>
  bool AddNewDrugApplymentTask(DrugApplymentTask drugApplymentTask);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DrugApplymentTask addressed by the primary identifier fields within the given DrugApplymentTask. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="drugApplymentTask"> DrugApplymentTask containing the new values (the primary identifier fields within the given DrugApplymentTask will be used to address the target record) </param>
  bool UpdateDrugApplymentTask(DrugApplymentTask drugApplymentTask);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DrugApplymentTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="drugApplymentName"> Represents the primary identity of a DrugApplymentTask </param>
  /// <param name="drugApplymentTask"> DrugApplymentTask containing the new values (the primary identifier fields within the given DrugApplymentTask will be ignored) </param>
  bool UpdateDrugApplymentTaskByDrugApplymentName(String drugApplymentName, DrugApplymentTask drugApplymentTask);

  /// <summary> Deletes a specific DrugApplymentTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="drugApplymentName"> Represents the primary identity of a DrugApplymentTask </param>
  bool DeleteDrugApplymentTaskByDrugApplymentName(String drugApplymentName);

}

/// <summary> Provides CRUD access to stored InducedDrugApplymentTasks (based on schema version '1.3.0') </summary>
public partial interface IInducedDrugApplymentTaskRepository {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding InducedDrugApplymentTasks.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific InducedDrugApplymentTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="id"> Represents the primary identity of a InducedDrugApplymentTask </param>
  InducedDrugApplymentTask GetInducedDrugApplymentTaskById(Guid id);

  /// <summary> Loads InducedDrugApplymentTasks. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of InducedDrugApplymentTasks which should be returned </param>
  InducedDrugApplymentTask[] GetInducedDrugApplymentTasks(int page = 1, int pageSize = 20);

  /// <summary> Loads InducedDrugApplymentTasks where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of InducedDrugApplymentTasks which should be returned</param>
  InducedDrugApplymentTask[] SearchInducedDrugApplymentTasks(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new InducedDrugApplymentTask and returns its primary identifier (or null on failure). </summary>
  /// <param name="inducedDrugApplymentTask"> InducedDrugApplymentTask containing the new values </param>
  bool AddNewInducedDrugApplymentTask(InducedDrugApplymentTask inducedDrugApplymentTask);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedDrugApplymentTask addressed by the primary identifier fields within the given InducedDrugApplymentTask. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="inducedDrugApplymentTask"> InducedDrugApplymentTask containing the new values (the primary identifier fields within the given InducedDrugApplymentTask will be used to address the target record) </param>
  bool UpdateInducedDrugApplymentTask(InducedDrugApplymentTask inducedDrugApplymentTask);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedDrugApplymentTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedDrugApplymentTask </param>
  /// <param name="inducedDrugApplymentTask"> InducedDrugApplymentTask containing the new values (the primary identifier fields within the given InducedDrugApplymentTask will be ignored) </param>
  bool UpdateInducedDrugApplymentTaskById(Guid id, InducedDrugApplymentTask inducedDrugApplymentTask);

  /// <summary> Deletes a specific InducedDrugApplymentTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedDrugApplymentTask </param>
  bool DeleteInducedDrugApplymentTaskById(Guid id);

}

/// <summary> Provides CRUD access to stored TaskSchedules (based on schema version '1.3.0') </summary>
public partial interface ITaskScheduleRepository {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding TaskSchedules.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific TaskSchedule addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="taskScheduleId"> Represents the primary identity of a TaskSchedule </param>
  TaskSchedule GetTaskScheduleByTaskScheduleId(Guid taskScheduleId);

  /// <summary> Loads TaskSchedules. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of TaskSchedules which should be returned </param>
  TaskSchedule[] GetTaskSchedules(int page = 1, int pageSize = 20);

  /// <summary> Loads TaskSchedules where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of TaskSchedules which should be returned</param>
  TaskSchedule[] SearchTaskSchedules(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new TaskSchedule and returns its primary identifier (or null on failure). </summary>
  /// <param name="taskSchedule"> TaskSchedule containing the new values </param>
  bool AddNewTaskSchedule(TaskSchedule taskSchedule);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given TaskSchedule addressed by the primary identifier fields within the given TaskSchedule. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskSchedule"> TaskSchedule containing the new values (the primary identifier fields within the given TaskSchedule will be used to address the target record) </param>
  bool UpdateTaskSchedule(TaskSchedule taskSchedule);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given TaskSchedule addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskScheduleId"> Represents the primary identity of a TaskSchedule </param>
  /// <param name="taskSchedule"> TaskSchedule containing the new values (the primary identifier fields within the given TaskSchedule will be ignored) </param>
  bool UpdateTaskScheduleByTaskScheduleId(Guid taskScheduleId, TaskSchedule taskSchedule);

  /// <summary> Deletes a specific TaskSchedule addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskScheduleId"> Represents the primary identity of a TaskSchedule </param>
  bool DeleteTaskScheduleByTaskScheduleId(Guid taskScheduleId);

}

/// <summary> Provides CRUD access to stored InducedSubProcedureSchedules (based on schema version '1.3.0') </summary>
public partial interface IInducedSubProcedureScheduleRepository {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding InducedSubProcedureSchedules.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific InducedSubProcedureSchedule addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="id"> Represents the primary identity of a InducedSubProcedureSchedule </param>
  InducedSubProcedureSchedule GetInducedSubProcedureScheduleById(Guid id);

  /// <summary> Loads InducedSubProcedureSchedules. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of InducedSubProcedureSchedules which should be returned </param>
  InducedSubProcedureSchedule[] GetInducedSubProcedureSchedules(int page = 1, int pageSize = 20);

  /// <summary> Loads InducedSubProcedureSchedules where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of InducedSubProcedureSchedules which should be returned</param>
  InducedSubProcedureSchedule[] SearchInducedSubProcedureSchedules(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new InducedSubProcedureSchedule and returns its primary identifier (or null on failure). </summary>
  /// <param name="inducedSubProcedureSchedule"> InducedSubProcedureSchedule containing the new values </param>
  bool AddNewInducedSubProcedureSchedule(InducedSubProcedureSchedule inducedSubProcedureSchedule);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedSubProcedureSchedule addressed by the primary identifier fields within the given InducedSubProcedureSchedule. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="inducedSubProcedureSchedule"> InducedSubProcedureSchedule containing the new values (the primary identifier fields within the given InducedSubProcedureSchedule will be used to address the target record) </param>
  bool UpdateInducedSubProcedureSchedule(InducedSubProcedureSchedule inducedSubProcedureSchedule);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedSubProcedureSchedule addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedSubProcedureSchedule </param>
  /// <param name="inducedSubProcedureSchedule"> InducedSubProcedureSchedule containing the new values (the primary identifier fields within the given InducedSubProcedureSchedule will be ignored) </param>
  bool UpdateInducedSubProcedureScheduleById(Guid id, InducedSubProcedureSchedule inducedSubProcedureSchedule);

  /// <summary> Deletes a specific InducedSubProcedureSchedule addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedSubProcedureSchedule </param>
  bool DeleteInducedSubProcedureScheduleById(Guid id);

}

/// <summary> Provides CRUD access to stored InducedSubTaskSchedules (based on schema version '1.3.0') </summary>
public partial interface IInducedSubTaskScheduleRepository {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding InducedSubTaskSchedules.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific InducedSubTaskSchedule addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="id"> Represents the primary identity of a InducedSubTaskSchedule </param>
  InducedSubTaskSchedule GetInducedSubTaskScheduleById(Guid id);

  /// <summary> Loads InducedSubTaskSchedules. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of InducedSubTaskSchedules which should be returned </param>
  InducedSubTaskSchedule[] GetInducedSubTaskSchedules(int page = 1, int pageSize = 20);

  /// <summary> Loads InducedSubTaskSchedules where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of InducedSubTaskSchedules which should be returned</param>
  InducedSubTaskSchedule[] SearchInducedSubTaskSchedules(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new InducedSubTaskSchedule and returns its primary identifier (or null on failure). </summary>
  /// <param name="inducedSubTaskSchedule"> InducedSubTaskSchedule containing the new values </param>
  bool AddNewInducedSubTaskSchedule(InducedSubTaskSchedule inducedSubTaskSchedule);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedSubTaskSchedule addressed by the primary identifier fields within the given InducedSubTaskSchedule. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="inducedSubTaskSchedule"> InducedSubTaskSchedule containing the new values (the primary identifier fields within the given InducedSubTaskSchedule will be used to address the target record) </param>
  bool UpdateInducedSubTaskSchedule(InducedSubTaskSchedule inducedSubTaskSchedule);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedSubTaskSchedule addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedSubTaskSchedule </param>
  /// <param name="inducedSubTaskSchedule"> InducedSubTaskSchedule containing the new values (the primary identifier fields within the given InducedSubTaskSchedule will be ignored) </param>
  bool UpdateInducedSubTaskScheduleById(Guid id, InducedSubTaskSchedule inducedSubTaskSchedule);

  /// <summary> Deletes a specific InducedSubTaskSchedule addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedSubTaskSchedule </param>
  bool DeleteInducedSubTaskScheduleById(Guid id);

}

/// <summary> Provides CRUD access to stored InducedTreatmentTasks (based on schema version '1.3.0') </summary>
public partial interface IInducedTreatmentTaskRepository {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding InducedTreatmentTasks.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific InducedTreatmentTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="id"> Represents the primary identity of a InducedTreatmentTask </param>
  InducedTreatmentTask GetInducedTreatmentTaskById(Guid id);

  /// <summary> Loads InducedTreatmentTasks. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of InducedTreatmentTasks which should be returned </param>
  InducedTreatmentTask[] GetInducedTreatmentTasks(int page = 1, int pageSize = 20);

  /// <summary> Loads InducedTreatmentTasks where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of InducedTreatmentTasks which should be returned</param>
  InducedTreatmentTask[] SearchInducedTreatmentTasks(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new InducedTreatmentTask and returns its primary identifier (or null on failure). </summary>
  /// <param name="inducedTreatmentTask"> InducedTreatmentTask containing the new values </param>
  bool AddNewInducedTreatmentTask(InducedTreatmentTask inducedTreatmentTask);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedTreatmentTask addressed by the primary identifier fields within the given InducedTreatmentTask. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="inducedTreatmentTask"> InducedTreatmentTask containing the new values (the primary identifier fields within the given InducedTreatmentTask will be used to address the target record) </param>
  bool UpdateInducedTreatmentTask(InducedTreatmentTask inducedTreatmentTask);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedTreatmentTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedTreatmentTask </param>
  /// <param name="inducedTreatmentTask"> InducedTreatmentTask containing the new values (the primary identifier fields within the given InducedTreatmentTask will be ignored) </param>
  bool UpdateInducedTreatmentTaskById(Guid id, InducedTreatmentTask inducedTreatmentTask);

  /// <summary> Deletes a specific InducedTreatmentTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedTreatmentTask </param>
  bool DeleteInducedTreatmentTaskById(Guid id);

}

/// <summary> Provides CRUD access to stored TreatmentTasks (based on schema version '1.3.0') </summary>
public partial interface ITreatmentTaskRepository {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding TreatmentTasks.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific TreatmentTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="treatmentName"> Represents the primary identity of a TreatmentTask </param>
  TreatmentTask GetTreatmentTaskByTreatmentName(String treatmentName);

  /// <summary> Loads TreatmentTasks. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of TreatmentTasks which should be returned </param>
  TreatmentTask[] GetTreatmentTasks(int page = 1, int pageSize = 20);

  /// <summary> Loads TreatmentTasks where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of TreatmentTasks which should be returned</param>
  TreatmentTask[] SearchTreatmentTasks(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new TreatmentTask and returns its primary identifier (or null on failure). </summary>
  /// <param name="treatmentTask"> TreatmentTask containing the new values </param>
  bool AddNewTreatmentTask(TreatmentTask treatmentTask);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given TreatmentTask addressed by the primary identifier fields within the given TreatmentTask. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="treatmentTask"> TreatmentTask containing the new values (the primary identifier fields within the given TreatmentTask will be used to address the target record) </param>
  bool UpdateTreatmentTask(TreatmentTask treatmentTask);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given TreatmentTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="treatmentName"> Represents the primary identity of a TreatmentTask </param>
  /// <param name="treatmentTask"> TreatmentTask containing the new values (the primary identifier fields within the given TreatmentTask will be ignored) </param>
  bool UpdateTreatmentTaskByTreatmentName(String treatmentName, TreatmentTask treatmentTask);

  /// <summary> Deletes a specific TreatmentTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="treatmentName"> Represents the primary identity of a TreatmentTask </param>
  bool DeleteTreatmentTaskByTreatmentName(String treatmentName);

}

/// <summary> Provides CRUD access to stored InducedVisitProcedures (based on schema version '1.3.0') </summary>
public partial interface IInducedVisitProcedureRepository {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding InducedVisitProcedures.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific InducedVisitProcedure addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="id"> Represents the primary identity of a InducedVisitProcedure </param>
  InducedVisitProcedure GetInducedVisitProcedureById(Guid id);

  /// <summary> Loads InducedVisitProcedures. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of InducedVisitProcedures which should be returned </param>
  InducedVisitProcedure[] GetInducedVisitProcedures(int page = 1, int pageSize = 20);

  /// <summary> Loads InducedVisitProcedures where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of InducedVisitProcedures which should be returned</param>
  InducedVisitProcedure[] SearchInducedVisitProcedures(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new InducedVisitProcedure and returns its primary identifier (or null on failure). </summary>
  /// <param name="inducedVisitProcedure"> InducedVisitProcedure containing the new values </param>
  bool AddNewInducedVisitProcedure(InducedVisitProcedure inducedVisitProcedure);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedVisitProcedure addressed by the primary identifier fields within the given InducedVisitProcedure. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="inducedVisitProcedure"> InducedVisitProcedure containing the new values (the primary identifier fields within the given InducedVisitProcedure will be used to address the target record) </param>
  bool UpdateInducedVisitProcedure(InducedVisitProcedure inducedVisitProcedure);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedVisitProcedure addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedVisitProcedure </param>
  /// <param name="inducedVisitProcedure"> InducedVisitProcedure containing the new values (the primary identifier fields within the given InducedVisitProcedure will be ignored) </param>
  bool UpdateInducedVisitProcedureById(Guid id, InducedVisitProcedure inducedVisitProcedure);

  /// <summary> Deletes a specific InducedVisitProcedure addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedVisitProcedure </param>
  bool DeleteInducedVisitProcedureById(Guid id);

}

/// <summary> Provides CRUD access to stored VisitProdecureDefinitions (based on schema version '1.3.0') </summary>
public partial interface IVisitProdecureDefinitionRepository {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding VisitProdecureDefinitions.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific VisitProdecureDefinition addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="visitProdecureName"> Represents the primary identity of a VisitProdecureDefinition </param>
  VisitProdecureDefinition GetVisitProdecureDefinitionByVisitProdecureName(String visitProdecureName);

  /// <summary> Loads VisitProdecureDefinitions. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of VisitProdecureDefinitions which should be returned </param>
  VisitProdecureDefinition[] GetVisitProdecureDefinitions(int page = 1, int pageSize = 20);

  /// <summary> Loads VisitProdecureDefinitions where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of VisitProdecureDefinitions which should be returned</param>
  VisitProdecureDefinition[] SearchVisitProdecureDefinitions(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new VisitProdecureDefinition and returns its primary identifier (or null on failure). </summary>
  /// <param name="visitProdecureDefinition"> VisitProdecureDefinition containing the new values </param>
  bool AddNewVisitProdecureDefinition(VisitProdecureDefinition visitProdecureDefinition);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given VisitProdecureDefinition addressed by the primary identifier fields within the given VisitProdecureDefinition. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="visitProdecureDefinition"> VisitProdecureDefinition containing the new values (the primary identifier fields within the given VisitProdecureDefinition will be used to address the target record) </param>
  bool UpdateVisitProdecureDefinition(VisitProdecureDefinition visitProdecureDefinition);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given VisitProdecureDefinition addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="visitProdecureName"> Represents the primary identity of a VisitProdecureDefinition </param>
  /// <param name="visitProdecureDefinition"> VisitProdecureDefinition containing the new values (the primary identifier fields within the given VisitProdecureDefinition will be ignored) </param>
  bool UpdateVisitProdecureDefinitionByVisitProdecureName(String visitProdecureName, VisitProdecureDefinition visitProdecureDefinition);

  /// <summary> Deletes a specific VisitProdecureDefinition addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="visitProdecureName"> Represents the primary identity of a VisitProdecureDefinition </param>
  bool DeleteVisitProdecureDefinitionByVisitProdecureName(String visitProdecureName);

}

/// <summary> Provides CRUD access to stored ProcedureCycleDefinitions (based on schema version '1.3.0') </summary>
public partial interface IProcedureCycleDefinitionRepository {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding ProcedureCycleDefinitions.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific ProcedureCycleDefinition addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="procedureScheduleId"> Represents the primary identity of a ProcedureCycleDefinition </param>
  ProcedureCycleDefinition GetProcedureCycleDefinitionByProcedureScheduleId(Guid procedureScheduleId);

  /// <summary> Loads ProcedureCycleDefinitions. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of ProcedureCycleDefinitions which should be returned </param>
  ProcedureCycleDefinition[] GetProcedureCycleDefinitions(int page = 1, int pageSize = 20);

  /// <summary> Loads ProcedureCycleDefinitions where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of ProcedureCycleDefinitions which should be returned</param>
  ProcedureCycleDefinition[] SearchProcedureCycleDefinitions(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new ProcedureCycleDefinition and returns its primary identifier (or null on failure). </summary>
  /// <param name="procedureCycleDefinition"> ProcedureCycleDefinition containing the new values </param>
  bool AddNewProcedureCycleDefinition(ProcedureCycleDefinition procedureCycleDefinition);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ProcedureCycleDefinition addressed by the primary identifier fields within the given ProcedureCycleDefinition. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="procedureCycleDefinition"> ProcedureCycleDefinition containing the new values (the primary identifier fields within the given ProcedureCycleDefinition will be used to address the target record) </param>
  bool UpdateProcedureCycleDefinition(ProcedureCycleDefinition procedureCycleDefinition);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ProcedureCycleDefinition addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="procedureScheduleId"> Represents the primary identity of a ProcedureCycleDefinition </param>
  /// <param name="procedureCycleDefinition"> ProcedureCycleDefinition containing the new values (the primary identifier fields within the given ProcedureCycleDefinition will be ignored) </param>
  bool UpdateProcedureCycleDefinitionByProcedureScheduleId(Guid procedureScheduleId, ProcedureCycleDefinition procedureCycleDefinition);

  /// <summary> Deletes a specific ProcedureCycleDefinition addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="procedureScheduleId"> Represents the primary identity of a ProcedureCycleDefinition </param>
  bool DeleteProcedureCycleDefinitionByProcedureScheduleId(Guid procedureScheduleId);

}

/// <summary> Provides CRUD access to stored StudyEvents (based on schema version '1.3.0') </summary>
public partial interface IStudyEventRepository {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding StudyEvents.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific StudyEvent addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="studyEventName"> Represents the primary identity of a StudyEvent </param>
  StudyEvent GetStudyEventByStudyEventName(String studyEventName);

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
  /// <param name="studyEventName"> Represents the primary identity of a StudyEvent </param>
  /// <param name="studyEvent"> StudyEvent containing the new values (the primary identifier fields within the given StudyEvent will be ignored) </param>
  bool UpdateStudyEventByStudyEventName(String studyEventName, StudyEvent studyEvent);

  /// <summary> Deletes a specific StudyEvent addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="studyEventName"> Represents the primary identity of a StudyEvent </param>
  bool DeleteStudyEventByStudyEventName(String studyEventName);

}

/// <summary> Provides CRUD access to stored TaskCycleDefinitions (based on schema version '1.3.0') </summary>
public partial interface ITaskCycleDefinitionRepository {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding TaskCycleDefinitions.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific TaskCycleDefinition addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="taskScheduleId"> Represents the primary identity of a TaskCycleDefinition </param>
  TaskCycleDefinition GetTaskCycleDefinitionByTaskScheduleId(Guid taskScheduleId);

  /// <summary> Loads TaskCycleDefinitions. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of TaskCycleDefinitions which should be returned </param>
  TaskCycleDefinition[] GetTaskCycleDefinitions(int page = 1, int pageSize = 20);

  /// <summary> Loads TaskCycleDefinitions where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of TaskCycleDefinitions which should be returned</param>
  TaskCycleDefinition[] SearchTaskCycleDefinitions(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new TaskCycleDefinition and returns its primary identifier (or null on failure). </summary>
  /// <param name="taskCycleDefinition"> TaskCycleDefinition containing the new values </param>
  bool AddNewTaskCycleDefinition(TaskCycleDefinition taskCycleDefinition);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given TaskCycleDefinition addressed by the primary identifier fields within the given TaskCycleDefinition. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskCycleDefinition"> TaskCycleDefinition containing the new values (the primary identifier fields within the given TaskCycleDefinition will be used to address the target record) </param>
  bool UpdateTaskCycleDefinition(TaskCycleDefinition taskCycleDefinition);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given TaskCycleDefinition addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskScheduleId"> Represents the primary identity of a TaskCycleDefinition </param>
  /// <param name="taskCycleDefinition"> TaskCycleDefinition containing the new values (the primary identifier fields within the given TaskCycleDefinition will be ignored) </param>
  bool UpdateTaskCycleDefinitionByTaskScheduleId(Guid taskScheduleId, TaskCycleDefinition taskCycleDefinition);

  /// <summary> Deletes a specific TaskCycleDefinition addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskScheduleId"> Represents the primary identity of a TaskCycleDefinition </param>
  bool DeleteTaskCycleDefinitionByTaskScheduleId(Guid taskScheduleId);

}

}
