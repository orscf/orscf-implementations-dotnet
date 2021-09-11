using MedicalResearch.Workflow.Persistence;
using System;

namespace MedicalResearch.Workflow.RepositoryService {

#region Arms

public class GetArmByArmIdentityRequest {
  /// <summary> Composite Key, which represents the primary identity of a Arm </summary>
  public ArmIdentity armIdentity { get; set; }
}
public class GetArmByArmIdentityResponse {
  /// <summary> the method-result of the executed operation </summary>
  public Arm @return { get; set; }
}

public class GetArmsRequest {
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of Arms which should be returned </summary>
  public int pageSize { get; set; } = 20;
}
public class GetArmsResponse {
  /// <summary> the method-result of the executed operation </summary>
  public Arm[] @return { get; set; }
}

public class SearchArmsRequest {
  /// <summary> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
  public String filterExpression { get; set; }
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of Arms which should be returned </summary>
  public int pageSize { get; set; } = 20;
  /// <summary> one or more property names which are used as sort order (before pagination) </summary>
  public String sort { get; set; } = null;
}
public class SearchArmsResponse {
  /// <summary> the method-result of the executed operation </summary>
  public Arm[] @return { get; set; }
}

public class AddNewArmRequest {
  /// <summary> Arm containing the new values </summary>
  public Arm arm { get; set; }
}
public class AddNewArmResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateArmRequest {
  /// <summary> Arm containing the new values (the primary identifier fields within the given Arm will be used to address the target record) </summary>
  public Arm arm { get; set; }
}
public class UpdateArmResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateArmByArmIdentityRequest {
  /// <summary> Composite Key, which represents the primary identity of a Arm </summary>
  public ArmIdentity armIdentity { get; set; }
  /// <summary> Arm containing the new values (the primary identifier fields within the given Arm will be ignored) </summary>
  public Arm arm { get; set; }
}
public class UpdateArmByArmIdentityResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class DeleteArmByArmIdentityRequest {
  /// <summary> Composite Key, which represents the primary identity of a Arm </summary>
  public ArmIdentity armIdentity { get; set; }
}
public class DeleteArmByArmIdentityResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

#endregion

#region ResearchStudies

public class GetResearchStudyByResearchStudyIdentityRequest {
  /// <summary> Composite Key, which represents the primary identity of a ResearchStudy </summary>
  public ResearchStudyIdentity researchStudyIdentity { get; set; }
}
public class GetResearchStudyByResearchStudyIdentityResponse {
  /// <summary> the method-result of the executed operation </summary>
  public ResearchStudy @return { get; set; }
}

public class GetResearchStudiesRequest {
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of ResearchStudies which should be returned </summary>
  public int pageSize { get; set; } = 20;
}
public class GetResearchStudiesResponse {
  /// <summary> the method-result of the executed operation </summary>
  public ResearchStudy[] @return { get; set; }
}

public class SearchResearchStudiesRequest {
  /// <summary> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
  public String filterExpression { get; set; }
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of ResearchStudies which should be returned </summary>
  public int pageSize { get; set; } = 20;
  /// <summary> one or more property names which are used as sort order (before pagination) </summary>
  public String sort { get; set; } = null;
}
public class SearchResearchStudiesResponse {
  /// <summary> the method-result of the executed operation </summary>
  public ResearchStudy[] @return { get; set; }
}

public class AddNewResearchStudyRequest {
  /// <summary> ResearchStudy containing the new values </summary>
  public ResearchStudy researchStudy { get; set; }
}
public class AddNewResearchStudyResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateResearchStudyRequest {
  /// <summary> ResearchStudy containing the new values (the primary identifier fields within the given ResearchStudy will be used to address the target record) </summary>
  public ResearchStudy researchStudy { get; set; }
}
public class UpdateResearchStudyResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateResearchStudyByResearchStudyIdentityRequest {
  /// <summary> Composite Key, which represents the primary identity of a ResearchStudy </summary>
  public ResearchStudyIdentity researchStudyIdentity { get; set; }
  /// <summary> ResearchStudy containing the new values (the primary identifier fields within the given ResearchStudy will be ignored) </summary>
  public ResearchStudy researchStudy { get; set; }
}
public class UpdateResearchStudyByResearchStudyIdentityResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class DeleteResearchStudyByResearchStudyIdentityRequest {
  /// <summary> Composite Key, which represents the primary identity of a ResearchStudy </summary>
  public ResearchStudyIdentity researchStudyIdentity { get; set; }
}
public class DeleteResearchStudyByResearchStudyIdentityResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

#endregion

#region ProcedureSchedules

public class GetProcedureScheduleByProcedureScheduleIdRequest {
  /// <summary> Represents the primary identity of a ProcedureSchedule </summary>
  public Guid procedureScheduleId { get; set; }
}
public class GetProcedureScheduleByProcedureScheduleIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public ProcedureSchedule @return { get; set; }
}

public class GetProcedureSchedulesRequest {
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of ProcedureSchedules which should be returned </summary>
  public int pageSize { get; set; } = 20;
}
public class GetProcedureSchedulesResponse {
  /// <summary> the method-result of the executed operation </summary>
  public ProcedureSchedule[] @return { get; set; }
}

public class SearchProcedureSchedulesRequest {
  /// <summary> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
  public String filterExpression { get; set; }
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of ProcedureSchedules which should be returned </summary>
  public int pageSize { get; set; } = 20;
  /// <summary> one or more property names which are used as sort order (before pagination) </summary>
  public String sort { get; set; } = null;
}
public class SearchProcedureSchedulesResponse {
  /// <summary> the method-result of the executed operation </summary>
  public ProcedureSchedule[] @return { get; set; }
}

public class AddNewProcedureScheduleRequest {
  /// <summary> ProcedureSchedule containing the new values </summary>
  public ProcedureSchedule procedureSchedule { get; set; }
}
public class AddNewProcedureScheduleResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateProcedureScheduleRequest {
  /// <summary> ProcedureSchedule containing the new values (the primary identifier fields within the given ProcedureSchedule will be used to address the target record) </summary>
  public ProcedureSchedule procedureSchedule { get; set; }
}
public class UpdateProcedureScheduleResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateProcedureScheduleByProcedureScheduleIdRequest {
  /// <summary> Represents the primary identity of a ProcedureSchedule </summary>
  public Guid procedureScheduleId { get; set; }
  /// <summary> ProcedureSchedule containing the new values (the primary identifier fields within the given ProcedureSchedule will be ignored) </summary>
  public ProcedureSchedule procedureSchedule { get; set; }
}
public class UpdateProcedureScheduleByProcedureScheduleIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class DeleteProcedureScheduleByProcedureScheduleIdRequest {
  /// <summary> Represents the primary identity of a ProcedureSchedule </summary>
  public Guid procedureScheduleId { get; set; }
}
public class DeleteProcedureScheduleByProcedureScheduleIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

#endregion

#region DataRecordingTasks

public class GetDataRecordingTaskByDataRecordingNameRequest {
  /// <summary> Represents the primary identity of a DataRecordingTask </summary>
  public String dataRecordingName { get; set; }
}
public class GetDataRecordingTaskByDataRecordingNameResponse {
  /// <summary> the method-result of the executed operation </summary>
  public DataRecordingTask @return { get; set; }
}

public class GetDataRecordingTasksRequest {
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of DataRecordingTasks which should be returned </summary>
  public int pageSize { get; set; } = 20;
}
public class GetDataRecordingTasksResponse {
  /// <summary> the method-result of the executed operation </summary>
  public DataRecordingTask[] @return { get; set; }
}

public class SearchDataRecordingTasksRequest {
  /// <summary> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
  public String filterExpression { get; set; }
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of DataRecordingTasks which should be returned </summary>
  public int pageSize { get; set; } = 20;
  /// <summary> one or more property names which are used as sort order (before pagination) </summary>
  public String sort { get; set; } = null;
}
public class SearchDataRecordingTasksResponse {
  /// <summary> the method-result of the executed operation </summary>
  public DataRecordingTask[] @return { get; set; }
}

public class AddNewDataRecordingTaskRequest {
  /// <summary> DataRecordingTask containing the new values </summary>
  public DataRecordingTask dataRecordingTask { get; set; }
}
public class AddNewDataRecordingTaskResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateDataRecordingTaskRequest {
  /// <summary> DataRecordingTask containing the new values (the primary identifier fields within the given DataRecordingTask will be used to address the target record) </summary>
  public DataRecordingTask dataRecordingTask { get; set; }
}
public class UpdateDataRecordingTaskResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateDataRecordingTaskByDataRecordingNameRequest {
  /// <summary> Represents the primary identity of a DataRecordingTask </summary>
  public String dataRecordingName { get; set; }
  /// <summary> DataRecordingTask containing the new values (the primary identifier fields within the given DataRecordingTask will be ignored) </summary>
  public DataRecordingTask dataRecordingTask { get; set; }
}
public class UpdateDataRecordingTaskByDataRecordingNameResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class DeleteDataRecordingTaskByDataRecordingNameRequest {
  /// <summary> Represents the primary identity of a DataRecordingTask </summary>
  public String dataRecordingName { get; set; }
}
public class DeleteDataRecordingTaskByDataRecordingNameResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

#endregion

#region InducedDataRecordingTasks

public class GetInducedDataRecordingTaskByIdRequest {
  /// <summary> Represents the primary identity of a InducedDataRecordingTask </summary>
  public Guid id { get; set; }
}
public class GetInducedDataRecordingTaskByIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public InducedDataRecordingTask @return { get; set; }
}

public class GetInducedDataRecordingTasksRequest {
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of InducedDataRecordingTasks which should be returned </summary>
  public int pageSize { get; set; } = 20;
}
public class GetInducedDataRecordingTasksResponse {
  /// <summary> the method-result of the executed operation </summary>
  public InducedDataRecordingTask[] @return { get; set; }
}

public class SearchInducedDataRecordingTasksRequest {
  /// <summary> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
  public String filterExpression { get; set; }
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of InducedDataRecordingTasks which should be returned </summary>
  public int pageSize { get; set; } = 20;
  /// <summary> one or more property names which are used as sort order (before pagination) </summary>
  public String sort { get; set; } = null;
}
public class SearchInducedDataRecordingTasksResponse {
  /// <summary> the method-result of the executed operation </summary>
  public InducedDataRecordingTask[] @return { get; set; }
}

public class AddNewInducedDataRecordingTaskRequest {
  /// <summary> InducedDataRecordingTask containing the new values </summary>
  public InducedDataRecordingTask inducedDataRecordingTask { get; set; }
}
public class AddNewInducedDataRecordingTaskResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateInducedDataRecordingTaskRequest {
  /// <summary> InducedDataRecordingTask containing the new values (the primary identifier fields within the given InducedDataRecordingTask will be used to address the target record) </summary>
  public InducedDataRecordingTask inducedDataRecordingTask { get; set; }
}
public class UpdateInducedDataRecordingTaskResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateInducedDataRecordingTaskByIdRequest {
  /// <summary> Represents the primary identity of a InducedDataRecordingTask </summary>
  public Guid id { get; set; }
  /// <summary> InducedDataRecordingTask containing the new values (the primary identifier fields within the given InducedDataRecordingTask will be ignored) </summary>
  public InducedDataRecordingTask inducedDataRecordingTask { get; set; }
}
public class UpdateInducedDataRecordingTaskByIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class DeleteInducedDataRecordingTaskByIdRequest {
  /// <summary> Represents the primary identity of a InducedDataRecordingTask </summary>
  public Guid id { get; set; }
}
public class DeleteInducedDataRecordingTaskByIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

#endregion

#region DrugAppliymentTasks

public class GetDrugApplymentTaskByDrugApplymentNameRequest {
  /// <summary> Represents the primary identity of a DrugApplymentTask </summary>
  public String drugApplymentName { get; set; }
}
public class GetDrugApplymentTaskByDrugApplymentNameResponse {
  /// <summary> the method-result of the executed operation </summary>
  public DrugApplymentTask @return { get; set; }
}

public class GetDrugAppliymentTasksRequest {
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of DrugAppliymentTasks which should be returned </summary>
  public int pageSize { get; set; } = 20;
}
public class GetDrugAppliymentTasksResponse {
  /// <summary> the method-result of the executed operation </summary>
  public DrugApplymentTask[] @return { get; set; }
}

public class SearchDrugAppliymentTasksRequest {
  /// <summary> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
  public String filterExpression { get; set; }
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of DrugAppliymentTasks which should be returned </summary>
  public int pageSize { get; set; } = 20;
  /// <summary> one or more property names which are used as sort order (before pagination) </summary>
  public String sort { get; set; } = null;
}
public class SearchDrugAppliymentTasksResponse {
  /// <summary> the method-result of the executed operation </summary>
  public DrugApplymentTask[] @return { get; set; }
}

public class AddNewDrugApplymentTaskRequest {
  /// <summary> DrugApplymentTask containing the new values </summary>
  public DrugApplymentTask drugApplymentTask { get; set; }
}
public class AddNewDrugApplymentTaskResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateDrugApplymentTaskRequest {
  /// <summary> DrugApplymentTask containing the new values (the primary identifier fields within the given DrugApplymentTask will be used to address the target record) </summary>
  public DrugApplymentTask drugApplymentTask { get; set; }
}
public class UpdateDrugApplymentTaskResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateDrugApplymentTaskByDrugApplymentNameRequest {
  /// <summary> Represents the primary identity of a DrugApplymentTask </summary>
  public String drugApplymentName { get; set; }
  /// <summary> DrugApplymentTask containing the new values (the primary identifier fields within the given DrugApplymentTask will be ignored) </summary>
  public DrugApplymentTask drugApplymentTask { get; set; }
}
public class UpdateDrugApplymentTaskByDrugApplymentNameResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class DeleteDrugApplymentTaskByDrugApplymentNameRequest {
  /// <summary> Represents the primary identity of a DrugApplymentTask </summary>
  public String drugApplymentName { get; set; }
}
public class DeleteDrugApplymentTaskByDrugApplymentNameResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

#endregion

#region InducedDrugApplymentTasks

public class GetInducedDrugApplymentTaskByIdRequest {
  /// <summary> Represents the primary identity of a InducedDrugApplymentTask </summary>
  public Guid id { get; set; }
}
public class GetInducedDrugApplymentTaskByIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public InducedDrugApplymentTask @return { get; set; }
}

public class GetInducedDrugApplymentTasksRequest {
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of InducedDrugApplymentTasks which should be returned </summary>
  public int pageSize { get; set; } = 20;
}
public class GetInducedDrugApplymentTasksResponse {
  /// <summary> the method-result of the executed operation </summary>
  public InducedDrugApplymentTask[] @return { get; set; }
}

public class SearchInducedDrugApplymentTasksRequest {
  /// <summary> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
  public String filterExpression { get; set; }
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of InducedDrugApplymentTasks which should be returned </summary>
  public int pageSize { get; set; } = 20;
  /// <summary> one or more property names which are used as sort order (before pagination) </summary>
  public String sort { get; set; } = null;
}
public class SearchInducedDrugApplymentTasksResponse {
  /// <summary> the method-result of the executed operation </summary>
  public InducedDrugApplymentTask[] @return { get; set; }
}

public class AddNewInducedDrugApplymentTaskRequest {
  /// <summary> InducedDrugApplymentTask containing the new values </summary>
  public InducedDrugApplymentTask inducedDrugApplymentTask { get; set; }
}
public class AddNewInducedDrugApplymentTaskResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateInducedDrugApplymentTaskRequest {
  /// <summary> InducedDrugApplymentTask containing the new values (the primary identifier fields within the given InducedDrugApplymentTask will be used to address the target record) </summary>
  public InducedDrugApplymentTask inducedDrugApplymentTask { get; set; }
}
public class UpdateInducedDrugApplymentTaskResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateInducedDrugApplymentTaskByIdRequest {
  /// <summary> Represents the primary identity of a InducedDrugApplymentTask </summary>
  public Guid id { get; set; }
  /// <summary> InducedDrugApplymentTask containing the new values (the primary identifier fields within the given InducedDrugApplymentTask will be ignored) </summary>
  public InducedDrugApplymentTask inducedDrugApplymentTask { get; set; }
}
public class UpdateInducedDrugApplymentTaskByIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class DeleteInducedDrugApplymentTaskByIdRequest {
  /// <summary> Represents the primary identity of a InducedDrugApplymentTask </summary>
  public Guid id { get; set; }
}
public class DeleteInducedDrugApplymentTaskByIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

#endregion

#region TaskSchedules

public class GetTaskScheduleByTaskScheduleIdRequest {
  /// <summary> Represents the primary identity of a TaskSchedule </summary>
  public Guid taskScheduleId { get; set; }
}
public class GetTaskScheduleByTaskScheduleIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public TaskSchedule @return { get; set; }
}

public class GetTaskSchedulesRequest {
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of TaskSchedules which should be returned </summary>
  public int pageSize { get; set; } = 20;
}
public class GetTaskSchedulesResponse {
  /// <summary> the method-result of the executed operation </summary>
  public TaskSchedule[] @return { get; set; }
}

public class SearchTaskSchedulesRequest {
  /// <summary> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
  public String filterExpression { get; set; }
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of TaskSchedules which should be returned </summary>
  public int pageSize { get; set; } = 20;
  /// <summary> one or more property names which are used as sort order (before pagination) </summary>
  public String sort { get; set; } = null;
}
public class SearchTaskSchedulesResponse {
  /// <summary> the method-result of the executed operation </summary>
  public TaskSchedule[] @return { get; set; }
}

public class AddNewTaskScheduleRequest {
  /// <summary> TaskSchedule containing the new values </summary>
  public TaskSchedule taskSchedule { get; set; }
}
public class AddNewTaskScheduleResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateTaskScheduleRequest {
  /// <summary> TaskSchedule containing the new values (the primary identifier fields within the given TaskSchedule will be used to address the target record) </summary>
  public TaskSchedule taskSchedule { get; set; }
}
public class UpdateTaskScheduleResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateTaskScheduleByTaskScheduleIdRequest {
  /// <summary> Represents the primary identity of a TaskSchedule </summary>
  public Guid taskScheduleId { get; set; }
  /// <summary> TaskSchedule containing the new values (the primary identifier fields within the given TaskSchedule will be ignored) </summary>
  public TaskSchedule taskSchedule { get; set; }
}
public class UpdateTaskScheduleByTaskScheduleIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class DeleteTaskScheduleByTaskScheduleIdRequest {
  /// <summary> Represents the primary identity of a TaskSchedule </summary>
  public Guid taskScheduleId { get; set; }
}
public class DeleteTaskScheduleByTaskScheduleIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

#endregion

#region InducedSubProcedureSchedules

public class GetInducedSubProcedureScheduleByIdRequest {
  /// <summary> Represents the primary identity of a InducedSubProcedureSchedule </summary>
  public Guid id { get; set; }
}
public class GetInducedSubProcedureScheduleByIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public InducedSubProcedureSchedule @return { get; set; }
}

public class GetInducedSubProcedureSchedulesRequest {
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of InducedSubProcedureSchedules which should be returned </summary>
  public int pageSize { get; set; } = 20;
}
public class GetInducedSubProcedureSchedulesResponse {
  /// <summary> the method-result of the executed operation </summary>
  public InducedSubProcedureSchedule[] @return { get; set; }
}

public class SearchInducedSubProcedureSchedulesRequest {
  /// <summary> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
  public String filterExpression { get; set; }
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of InducedSubProcedureSchedules which should be returned </summary>
  public int pageSize { get; set; } = 20;
  /// <summary> one or more property names which are used as sort order (before pagination) </summary>
  public String sort { get; set; } = null;
}
public class SearchInducedSubProcedureSchedulesResponse {
  /// <summary> the method-result of the executed operation </summary>
  public InducedSubProcedureSchedule[] @return { get; set; }
}

public class AddNewInducedSubProcedureScheduleRequest {
  /// <summary> InducedSubProcedureSchedule containing the new values </summary>
  public InducedSubProcedureSchedule inducedSubProcedureSchedule { get; set; }
}
public class AddNewInducedSubProcedureScheduleResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateInducedSubProcedureScheduleRequest {
  /// <summary> InducedSubProcedureSchedule containing the new values (the primary identifier fields within the given InducedSubProcedureSchedule will be used to address the target record) </summary>
  public InducedSubProcedureSchedule inducedSubProcedureSchedule { get; set; }
}
public class UpdateInducedSubProcedureScheduleResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateInducedSubProcedureScheduleByIdRequest {
  /// <summary> Represents the primary identity of a InducedSubProcedureSchedule </summary>
  public Guid id { get; set; }
  /// <summary> InducedSubProcedureSchedule containing the new values (the primary identifier fields within the given InducedSubProcedureSchedule will be ignored) </summary>
  public InducedSubProcedureSchedule inducedSubProcedureSchedule { get; set; }
}
public class UpdateInducedSubProcedureScheduleByIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class DeleteInducedSubProcedureScheduleByIdRequest {
  /// <summary> Represents the primary identity of a InducedSubProcedureSchedule </summary>
  public Guid id { get; set; }
}
public class DeleteInducedSubProcedureScheduleByIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

#endregion

#region InducedSubTaskSchedules

public class GetInducedSubTaskScheduleByIdRequest {
  /// <summary> Represents the primary identity of a InducedSubTaskSchedule </summary>
  public Guid id { get; set; }
}
public class GetInducedSubTaskScheduleByIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public InducedSubTaskSchedule @return { get; set; }
}

public class GetInducedSubTaskSchedulesRequest {
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of InducedSubTaskSchedules which should be returned </summary>
  public int pageSize { get; set; } = 20;
}
public class GetInducedSubTaskSchedulesResponse {
  /// <summary> the method-result of the executed operation </summary>
  public InducedSubTaskSchedule[] @return { get; set; }
}

public class SearchInducedSubTaskSchedulesRequest {
  /// <summary> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
  public String filterExpression { get; set; }
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of InducedSubTaskSchedules which should be returned </summary>
  public int pageSize { get; set; } = 20;
  /// <summary> one or more property names which are used as sort order (before pagination) </summary>
  public String sort { get; set; } = null;
}
public class SearchInducedSubTaskSchedulesResponse {
  /// <summary> the method-result of the executed operation </summary>
  public InducedSubTaskSchedule[] @return { get; set; }
}

public class AddNewInducedSubTaskScheduleRequest {
  /// <summary> InducedSubTaskSchedule containing the new values </summary>
  public InducedSubTaskSchedule inducedSubTaskSchedule { get; set; }
}
public class AddNewInducedSubTaskScheduleResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateInducedSubTaskScheduleRequest {
  /// <summary> InducedSubTaskSchedule containing the new values (the primary identifier fields within the given InducedSubTaskSchedule will be used to address the target record) </summary>
  public InducedSubTaskSchedule inducedSubTaskSchedule { get; set; }
}
public class UpdateInducedSubTaskScheduleResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateInducedSubTaskScheduleByIdRequest {
  /// <summary> Represents the primary identity of a InducedSubTaskSchedule </summary>
  public Guid id { get; set; }
  /// <summary> InducedSubTaskSchedule containing the new values (the primary identifier fields within the given InducedSubTaskSchedule will be ignored) </summary>
  public InducedSubTaskSchedule inducedSubTaskSchedule { get; set; }
}
public class UpdateInducedSubTaskScheduleByIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class DeleteInducedSubTaskScheduleByIdRequest {
  /// <summary> Represents the primary identity of a InducedSubTaskSchedule </summary>
  public Guid id { get; set; }
}
public class DeleteInducedSubTaskScheduleByIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

#endregion

#region InducedTreatmentTasks

public class GetInducedTreatmentTaskByIdRequest {
  /// <summary> Represents the primary identity of a InducedTreatmentTask </summary>
  public Guid id { get; set; }
}
public class GetInducedTreatmentTaskByIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public InducedTreatmentTask @return { get; set; }
}

public class GetInducedTreatmentTasksRequest {
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of InducedTreatmentTasks which should be returned </summary>
  public int pageSize { get; set; } = 20;
}
public class GetInducedTreatmentTasksResponse {
  /// <summary> the method-result of the executed operation </summary>
  public InducedTreatmentTask[] @return { get; set; }
}

public class SearchInducedTreatmentTasksRequest {
  /// <summary> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
  public String filterExpression { get; set; }
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of InducedTreatmentTasks which should be returned </summary>
  public int pageSize { get; set; } = 20;
  /// <summary> one or more property names which are used as sort order (before pagination) </summary>
  public String sort { get; set; } = null;
}
public class SearchInducedTreatmentTasksResponse {
  /// <summary> the method-result of the executed operation </summary>
  public InducedTreatmentTask[] @return { get; set; }
}

public class AddNewInducedTreatmentTaskRequest {
  /// <summary> InducedTreatmentTask containing the new values </summary>
  public InducedTreatmentTask inducedTreatmentTask { get; set; }
}
public class AddNewInducedTreatmentTaskResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateInducedTreatmentTaskRequest {
  /// <summary> InducedTreatmentTask containing the new values (the primary identifier fields within the given InducedTreatmentTask will be used to address the target record) </summary>
  public InducedTreatmentTask inducedTreatmentTask { get; set; }
}
public class UpdateInducedTreatmentTaskResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateInducedTreatmentTaskByIdRequest {
  /// <summary> Represents the primary identity of a InducedTreatmentTask </summary>
  public Guid id { get; set; }
  /// <summary> InducedTreatmentTask containing the new values (the primary identifier fields within the given InducedTreatmentTask will be ignored) </summary>
  public InducedTreatmentTask inducedTreatmentTask { get; set; }
}
public class UpdateInducedTreatmentTaskByIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class DeleteInducedTreatmentTaskByIdRequest {
  /// <summary> Represents the primary identity of a InducedTreatmentTask </summary>
  public Guid id { get; set; }
}
public class DeleteInducedTreatmentTaskByIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

#endregion

#region TreatmentTasks

public class GetTreatmentTaskByTreatmentNameRequest {
  /// <summary> Represents the primary identity of a TreatmentTask </summary>
  public String treatmentName { get; set; }
}
public class GetTreatmentTaskByTreatmentNameResponse {
  /// <summary> the method-result of the executed operation </summary>
  public TreatmentTask @return { get; set; }
}

public class GetTreatmentTasksRequest {
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of TreatmentTasks which should be returned </summary>
  public int pageSize { get; set; } = 20;
}
public class GetTreatmentTasksResponse {
  /// <summary> the method-result of the executed operation </summary>
  public TreatmentTask[] @return { get; set; }
}

public class SearchTreatmentTasksRequest {
  /// <summary> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
  public String filterExpression { get; set; }
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of TreatmentTasks which should be returned </summary>
  public int pageSize { get; set; } = 20;
  /// <summary> one or more property names which are used as sort order (before pagination) </summary>
  public String sort { get; set; } = null;
}
public class SearchTreatmentTasksResponse {
  /// <summary> the method-result of the executed operation </summary>
  public TreatmentTask[] @return { get; set; }
}

public class AddNewTreatmentTaskRequest {
  /// <summary> TreatmentTask containing the new values </summary>
  public TreatmentTask treatmentTask { get; set; }
}
public class AddNewTreatmentTaskResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateTreatmentTaskRequest {
  /// <summary> TreatmentTask containing the new values (the primary identifier fields within the given TreatmentTask will be used to address the target record) </summary>
  public TreatmentTask treatmentTask { get; set; }
}
public class UpdateTreatmentTaskResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateTreatmentTaskByTreatmentNameRequest {
  /// <summary> Represents the primary identity of a TreatmentTask </summary>
  public String treatmentName { get; set; }
  /// <summary> TreatmentTask containing the new values (the primary identifier fields within the given TreatmentTask will be ignored) </summary>
  public TreatmentTask treatmentTask { get; set; }
}
public class UpdateTreatmentTaskByTreatmentNameResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class DeleteTreatmentTaskByTreatmentNameRequest {
  /// <summary> Represents the primary identity of a TreatmentTask </summary>
  public String treatmentName { get; set; }
}
public class DeleteTreatmentTaskByTreatmentNameResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

#endregion

#region InducedVisitProcedures

public class GetInducedVisitProcedureByIdRequest {
  /// <summary> Represents the primary identity of a InducedVisitProcedure </summary>
  public Guid id { get; set; }
}
public class GetInducedVisitProcedureByIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public InducedVisitProcedure @return { get; set; }
}

public class GetInducedVisitProceduresRequest {
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of InducedVisitProcedures which should be returned </summary>
  public int pageSize { get; set; } = 20;
}
public class GetInducedVisitProceduresResponse {
  /// <summary> the method-result of the executed operation </summary>
  public InducedVisitProcedure[] @return { get; set; }
}

public class SearchInducedVisitProceduresRequest {
  /// <summary> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
  public String filterExpression { get; set; }
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of InducedVisitProcedures which should be returned </summary>
  public int pageSize { get; set; } = 20;
  /// <summary> one or more property names which are used as sort order (before pagination) </summary>
  public String sort { get; set; } = null;
}
public class SearchInducedVisitProceduresResponse {
  /// <summary> the method-result of the executed operation </summary>
  public InducedVisitProcedure[] @return { get; set; }
}

public class AddNewInducedVisitProcedureRequest {
  /// <summary> InducedVisitProcedure containing the new values </summary>
  public InducedVisitProcedure inducedVisitProcedure { get; set; }
}
public class AddNewInducedVisitProcedureResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateInducedVisitProcedureRequest {
  /// <summary> InducedVisitProcedure containing the new values (the primary identifier fields within the given InducedVisitProcedure will be used to address the target record) </summary>
  public InducedVisitProcedure inducedVisitProcedure { get; set; }
}
public class UpdateInducedVisitProcedureResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateInducedVisitProcedureByIdRequest {
  /// <summary> Represents the primary identity of a InducedVisitProcedure </summary>
  public Guid id { get; set; }
  /// <summary> InducedVisitProcedure containing the new values (the primary identifier fields within the given InducedVisitProcedure will be ignored) </summary>
  public InducedVisitProcedure inducedVisitProcedure { get; set; }
}
public class UpdateInducedVisitProcedureByIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class DeleteInducedVisitProcedureByIdRequest {
  /// <summary> Represents the primary identity of a InducedVisitProcedure </summary>
  public Guid id { get; set; }
}
public class DeleteInducedVisitProcedureByIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

#endregion

#region VisitProdecureDefinitions

public class GetVisitProdecureDefinitionByVisitProdecureNameRequest {
  /// <summary> Represents the primary identity of a VisitProdecureDefinition </summary>
  public String visitProdecureName { get; set; }
}
public class GetVisitProdecureDefinitionByVisitProdecureNameResponse {
  /// <summary> the method-result of the executed operation </summary>
  public VisitProdecureDefinition @return { get; set; }
}

public class GetVisitProdecureDefinitionsRequest {
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of VisitProdecureDefinitions which should be returned </summary>
  public int pageSize { get; set; } = 20;
}
public class GetVisitProdecureDefinitionsResponse {
  /// <summary> the method-result of the executed operation </summary>
  public VisitProdecureDefinition[] @return { get; set; }
}

public class SearchVisitProdecureDefinitionsRequest {
  /// <summary> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
  public String filterExpression { get; set; }
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of VisitProdecureDefinitions which should be returned </summary>
  public int pageSize { get; set; } = 20;
  /// <summary> one or more property names which are used as sort order (before pagination) </summary>
  public String sort { get; set; } = null;
}
public class SearchVisitProdecureDefinitionsResponse {
  /// <summary> the method-result of the executed operation </summary>
  public VisitProdecureDefinition[] @return { get; set; }
}

public class AddNewVisitProdecureDefinitionRequest {
  /// <summary> VisitProdecureDefinition containing the new values </summary>
  public VisitProdecureDefinition visitProdecureDefinition { get; set; }
}
public class AddNewVisitProdecureDefinitionResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateVisitProdecureDefinitionRequest {
  /// <summary> VisitProdecureDefinition containing the new values (the primary identifier fields within the given VisitProdecureDefinition will be used to address the target record) </summary>
  public VisitProdecureDefinition visitProdecureDefinition { get; set; }
}
public class UpdateVisitProdecureDefinitionResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateVisitProdecureDefinitionByVisitProdecureNameRequest {
  /// <summary> Represents the primary identity of a VisitProdecureDefinition </summary>
  public String visitProdecureName { get; set; }
  /// <summary> VisitProdecureDefinition containing the new values (the primary identifier fields within the given VisitProdecureDefinition will be ignored) </summary>
  public VisitProdecureDefinition visitProdecureDefinition { get; set; }
}
public class UpdateVisitProdecureDefinitionByVisitProdecureNameResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class DeleteVisitProdecureDefinitionByVisitProdecureNameRequest {
  /// <summary> Represents the primary identity of a VisitProdecureDefinition </summary>
  public String visitProdecureName { get; set; }
}
public class DeleteVisitProdecureDefinitionByVisitProdecureNameResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

#endregion

#region ProcedureCycleDefinitions

public class GetProcedureCycleDefinitionByProcedureScheduleIdRequest {
  /// <summary> Represents the primary identity of a ProcedureCycleDefinition </summary>
  public Guid procedureScheduleId { get; set; }
}
public class GetProcedureCycleDefinitionByProcedureScheduleIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public ProcedureCycleDefinition @return { get; set; }
}

public class GetProcedureCycleDefinitionsRequest {
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of ProcedureCycleDefinitions which should be returned </summary>
  public int pageSize { get; set; } = 20;
}
public class GetProcedureCycleDefinitionsResponse {
  /// <summary> the method-result of the executed operation </summary>
  public ProcedureCycleDefinition[] @return { get; set; }
}

public class SearchProcedureCycleDefinitionsRequest {
  /// <summary> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
  public String filterExpression { get; set; }
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of ProcedureCycleDefinitions which should be returned </summary>
  public int pageSize { get; set; } = 20;
  /// <summary> one or more property names which are used as sort order (before pagination) </summary>
  public String sort { get; set; } = null;
}
public class SearchProcedureCycleDefinitionsResponse {
  /// <summary> the method-result of the executed operation </summary>
  public ProcedureCycleDefinition[] @return { get; set; }
}

public class AddNewProcedureCycleDefinitionRequest {
  /// <summary> ProcedureCycleDefinition containing the new values </summary>
  public ProcedureCycleDefinition procedureCycleDefinition { get; set; }
}
public class AddNewProcedureCycleDefinitionResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateProcedureCycleDefinitionRequest {
  /// <summary> ProcedureCycleDefinition containing the new values (the primary identifier fields within the given ProcedureCycleDefinition will be used to address the target record) </summary>
  public ProcedureCycleDefinition procedureCycleDefinition { get; set; }
}
public class UpdateProcedureCycleDefinitionResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateProcedureCycleDefinitionByProcedureScheduleIdRequest {
  /// <summary> Represents the primary identity of a ProcedureCycleDefinition </summary>
  public Guid procedureScheduleId { get; set; }
  /// <summary> ProcedureCycleDefinition containing the new values (the primary identifier fields within the given ProcedureCycleDefinition will be ignored) </summary>
  public ProcedureCycleDefinition procedureCycleDefinition { get; set; }
}
public class UpdateProcedureCycleDefinitionByProcedureScheduleIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class DeleteProcedureCycleDefinitionByProcedureScheduleIdRequest {
  /// <summary> Represents the primary identity of a ProcedureCycleDefinition </summary>
  public Guid procedureScheduleId { get; set; }
}
public class DeleteProcedureCycleDefinitionByProcedureScheduleIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

#endregion

#region StudyEvents

public class GetStudyEventByStudyEventNameRequest {
  /// <summary> Represents the primary identity of a StudyEvent </summary>
  public String studyEventName { get; set; }
}
public class GetStudyEventByStudyEventNameResponse {
  /// <summary> the method-result of the executed operation </summary>
  public StudyEvent @return { get; set; }
}

public class GetStudyEventsRequest {
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of StudyEvents which should be returned </summary>
  public int pageSize { get; set; } = 20;
}
public class GetStudyEventsResponse {
  /// <summary> the method-result of the executed operation </summary>
  public StudyEvent[] @return { get; set; }
}

public class SearchStudyEventsRequest {
  /// <summary> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
  public String filterExpression { get; set; }
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of StudyEvents which should be returned </summary>
  public int pageSize { get; set; } = 20;
  /// <summary> one or more property names which are used as sort order (before pagination) </summary>
  public String sort { get; set; } = null;
}
public class SearchStudyEventsResponse {
  /// <summary> the method-result of the executed operation </summary>
  public StudyEvent[] @return { get; set; }
}

public class AddNewStudyEventRequest {
  /// <summary> StudyEvent containing the new values </summary>
  public StudyEvent studyEvent { get; set; }
}
public class AddNewStudyEventResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateStudyEventRequest {
  /// <summary> StudyEvent containing the new values (the primary identifier fields within the given StudyEvent will be used to address the target record) </summary>
  public StudyEvent studyEvent { get; set; }
}
public class UpdateStudyEventResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateStudyEventByStudyEventNameRequest {
  /// <summary> Represents the primary identity of a StudyEvent </summary>
  public String studyEventName { get; set; }
  /// <summary> StudyEvent containing the new values (the primary identifier fields within the given StudyEvent will be ignored) </summary>
  public StudyEvent studyEvent { get; set; }
}
public class UpdateStudyEventByStudyEventNameResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class DeleteStudyEventByStudyEventNameRequest {
  /// <summary> Represents the primary identity of a StudyEvent </summary>
  public String studyEventName { get; set; }
}
public class DeleteStudyEventByStudyEventNameResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

#endregion

#region TaskCycleDefinitions

public class GetTaskCycleDefinitionByTaskScheduleIdRequest {
  /// <summary> Represents the primary identity of a TaskCycleDefinition </summary>
  public Guid taskScheduleId { get; set; }
}
public class GetTaskCycleDefinitionByTaskScheduleIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public TaskCycleDefinition @return { get; set; }
}

public class GetTaskCycleDefinitionsRequest {
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of TaskCycleDefinitions which should be returned </summary>
  public int pageSize { get; set; } = 20;
}
public class GetTaskCycleDefinitionsResponse {
  /// <summary> the method-result of the executed operation </summary>
  public TaskCycleDefinition[] @return { get; set; }
}

public class SearchTaskCycleDefinitionsRequest {
  /// <summary> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
  public String filterExpression { get; set; }
  /// <summary> Number of the page, which should be returned </summary>
  public int page { get; set; } = 1;
  /// <summary> Max count of TaskCycleDefinitions which should be returned </summary>
  public int pageSize { get; set; } = 20;
  /// <summary> one or more property names which are used as sort order (before pagination) </summary>
  public String sort { get; set; } = null;
}
public class SearchTaskCycleDefinitionsResponse {
  /// <summary> the method-result of the executed operation </summary>
  public TaskCycleDefinition[] @return { get; set; }
}

public class AddNewTaskCycleDefinitionRequest {
  /// <summary> TaskCycleDefinition containing the new values </summary>
  public TaskCycleDefinition taskCycleDefinition { get; set; }
}
public class AddNewTaskCycleDefinitionResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateTaskCycleDefinitionRequest {
  /// <summary> TaskCycleDefinition containing the new values (the primary identifier fields within the given TaskCycleDefinition will be used to address the target record) </summary>
  public TaskCycleDefinition taskCycleDefinition { get; set; }
}
public class UpdateTaskCycleDefinitionResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class UpdateTaskCycleDefinitionByTaskScheduleIdRequest {
  /// <summary> Represents the primary identity of a TaskCycleDefinition </summary>
  public Guid taskScheduleId { get; set; }
  /// <summary> TaskCycleDefinition containing the new values (the primary identifier fields within the given TaskCycleDefinition will be ignored) </summary>
  public TaskCycleDefinition taskCycleDefinition { get; set; }
}
public class UpdateTaskCycleDefinitionByTaskScheduleIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

public class DeleteTaskCycleDefinitionByTaskScheduleIdRequest {
  /// <summary> Represents the primary identity of a TaskCycleDefinition </summary>
  public Guid taskScheduleId { get; set; }
}
public class DeleteTaskCycleDefinitionByTaskScheduleIdResponse {
  /// <summary> the method-result of the executed operation </summary>
  public bool @return { get; set; }
}

#endregion

}
