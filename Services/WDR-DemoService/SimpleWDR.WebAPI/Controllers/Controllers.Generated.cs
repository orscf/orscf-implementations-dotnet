using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Security;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Data.AccessControl;
using System.Linq;
using System.Net;

namespace MedicalResearch.Workflow.RepositoryService {

[ApiController]
[Route("arms")]
public partial class ArmsController : ControllerBase {

  public const String SchemaVersion = "1.3.0";

  private readonly ILogger<ArmsController> _logger;
  private readonly MedicalResearch.Workflow.Persistence.IArmRepository _Repo;

  public ArmsController(ILogger<ArmsController> logger) {
    _logger = logger;
    _Repo = new MedicalResearch.Workflow.Persistence.EF.ArmStore();
  }

  /// <summary> Loads a specific Arm addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-arm")]
  [HttpPost("getByArmIdentity"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetArmByArmIdentity), Description = nameof(GetArmByArmIdentity))]
  public GetArmByArmIdentityResponse GetArmByArmIdentity([FromBody][SwaggerRequestBody(Required=true)] GetArmByArmIdentityRequest args){
    try {
      return new GetArmByArmIdentityResponse { @return = _Repo.GetArmByArmIdentity(args.armIdentity)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetArmByArmIdentityResponse { @return = null};
    }
  }

  /// <summary> Loads Arms. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-arm")]
  [HttpPost("getAll"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetArms), Description = nameof(GetArms))]
  public GetArmsResponse GetArms([FromBody][SwaggerRequestBody(Required=true)] GetArmsRequest args){
    try {
      return new GetArmsResponse { @return = _Repo.GetArms(args.page, args.pageSize) }; 
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetArmsResponse { @return = null};
    }
  }

  /// <summary> Loads Arms where values matching to the given filterExpression</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-arm")]
  [HttpPost("search"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(SearchArms), Description = nameof(SearchArms))]
  public SearchArmsResponse SearchArms([FromBody][SwaggerRequestBody(Required=true)] SearchArmsRequest args){
    try {
      return new SearchArmsResponse { @return = _Repo.SearchArms(args.filterExpression, args.sort, args.page, args.pageSize) };
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new SearchArmsResponse { @return = null};
    }
  }

  /// <summary> Adds a new Arm and returns success. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("add-arm")]
  [HttpPost("addNew"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(AddNewArm), Description = nameof(AddNewArm))]
  public AddNewArmResponse AddNewArm([FromBody][SwaggerRequestBody(Required=true)] AddNewArmRequest args){
    try {
      return new AddNewArmResponse { @return = _Repo.AddNewArm(args.arm)};  
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new AddNewArmResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Arm addressed by the primary identifier fields within the given Arm. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-arm")]
  [HttpPost("update"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateArm), Description = nameof(UpdateArm))]
  public UpdateArmResponse UpdateArm([FromBody][SwaggerRequestBody(Required=true)] UpdateArmRequest args){
    try {
      return new UpdateArmResponse { @return = _Repo.UpdateArm(args.arm)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateArmResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Arm addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-arm")]
  [HttpPost("updateByArmIdentity"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateArmByArmIdentity), Description = nameof(UpdateArmByArmIdentity))]
  public UpdateArmByArmIdentityResponse UpdateArmByArmIdentity([FromBody][SwaggerRequestBody(Required=true)] UpdateArmByArmIdentityRequest args){
    try {
      return new UpdateArmByArmIdentityResponse { @return = _Repo.UpdateArmByArmIdentity(args.armIdentity, args.arm)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateArmByArmIdentityResponse { @return = false};
    }
  }

  /// <summary> Deletes a specific Arm addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("delete-arm")]
  [HttpPost("deleteByArmIdentity"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(DeleteArmByArmIdentity), Description = nameof(DeleteArmByArmIdentity))]
  public DeleteArmByArmIdentityResponse DeleteArmByArmIdentity([FromBody][SwaggerRequestBody(Required=true)] DeleteArmByArmIdentityRequest args){
    try {
      return new DeleteArmByArmIdentityResponse { @return = _Repo.DeleteArmByArmIdentity(args.armIdentity)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new DeleteArmByArmIdentityResponse { @return = false};
    }
  }

}

[ApiController]
[Route("researchStudies")]
public partial class ResearchStudiesController : ControllerBase {

  public const String SchemaVersion = "1.3.0";

  private readonly ILogger<ResearchStudiesController> _logger;
  private readonly MedicalResearch.Workflow.Persistence.IResearchStudyRepository _Repo;

  public ResearchStudiesController(ILogger<ResearchStudiesController> logger) {
    _logger = logger;
    _Repo = new MedicalResearch.Workflow.Persistence.EF.ResearchStudyStore();
  }

  /// <summary> Loads a specific ResearchStudy addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-researchstudy")]
  [HttpPost("getByResearchStudyIdentity"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetResearchStudyByResearchStudyIdentity), Description = nameof(GetResearchStudyByResearchStudyIdentity))]
  public GetResearchStudyByResearchStudyIdentityResponse GetResearchStudyByResearchStudyIdentity([FromBody][SwaggerRequestBody(Required=true)] GetResearchStudyByResearchStudyIdentityRequest args){
    try {
      return new GetResearchStudyByResearchStudyIdentityResponse { @return = _Repo.GetResearchStudyByResearchStudyIdentity(args.researchStudyIdentity)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetResearchStudyByResearchStudyIdentityResponse { @return = null};
    }
  }

  /// <summary> Loads ResearchStudies. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-researchstudy")]
  [HttpPost("getAll"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetResearchStudies), Description = nameof(GetResearchStudies))]
  public GetResearchStudiesResponse GetResearchStudies([FromBody][SwaggerRequestBody(Required=true)] GetResearchStudiesRequest args){
    try {
      return new GetResearchStudiesResponse { @return = _Repo.GetResearchStudies(args.page, args.pageSize) }; 
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetResearchStudiesResponse { @return = null};
    }
  }

  /// <summary> Loads ResearchStudies where values matching to the given filterExpression</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-researchstudy")]
  [HttpPost("search"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(SearchResearchStudies), Description = nameof(SearchResearchStudies))]
  public SearchResearchStudiesResponse SearchResearchStudies([FromBody][SwaggerRequestBody(Required=true)] SearchResearchStudiesRequest args){
    try {
      return new SearchResearchStudiesResponse { @return = _Repo.SearchResearchStudies(args.filterExpression, args.sort, args.page, args.pageSize) };
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new SearchResearchStudiesResponse { @return = null};
    }
  }

  /// <summary> Adds a new ResearchStudy and returns success. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("add-researchstudy")]
  [HttpPost("addNew"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(AddNewResearchStudy), Description = nameof(AddNewResearchStudy))]
  public AddNewResearchStudyResponse AddNewResearchStudy([FromBody][SwaggerRequestBody(Required=true)] AddNewResearchStudyRequest args){
    try {
      return new AddNewResearchStudyResponse { @return = _Repo.AddNewResearchStudy(args.researchStudy)};  
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new AddNewResearchStudyResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ResearchStudy addressed by the primary identifier fields within the given ResearchStudy. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-researchstudy")]
  [HttpPost("update"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateResearchStudy), Description = nameof(UpdateResearchStudy))]
  public UpdateResearchStudyResponse UpdateResearchStudy([FromBody][SwaggerRequestBody(Required=true)] UpdateResearchStudyRequest args){
    try {
      return new UpdateResearchStudyResponse { @return = _Repo.UpdateResearchStudy(args.researchStudy)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateResearchStudyResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ResearchStudy addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-researchstudy")]
  [HttpPost("updateByResearchStudyIdentity"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateResearchStudyByResearchStudyIdentity), Description = nameof(UpdateResearchStudyByResearchStudyIdentity))]
  public UpdateResearchStudyByResearchStudyIdentityResponse UpdateResearchStudyByResearchStudyIdentity([FromBody][SwaggerRequestBody(Required=true)] UpdateResearchStudyByResearchStudyIdentityRequest args){
    try {
      return new UpdateResearchStudyByResearchStudyIdentityResponse { @return = _Repo.UpdateResearchStudyByResearchStudyIdentity(args.researchStudyIdentity, args.researchStudy)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateResearchStudyByResearchStudyIdentityResponse { @return = false};
    }
  }

  /// <summary> Deletes a specific ResearchStudy addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("delete-researchstudy")]
  [HttpPost("deleteByResearchStudyIdentity"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(DeleteResearchStudyByResearchStudyIdentity), Description = nameof(DeleteResearchStudyByResearchStudyIdentity))]
  public DeleteResearchStudyByResearchStudyIdentityResponse DeleteResearchStudyByResearchStudyIdentity([FromBody][SwaggerRequestBody(Required=true)] DeleteResearchStudyByResearchStudyIdentityRequest args){
    try {
      return new DeleteResearchStudyByResearchStudyIdentityResponse { @return = _Repo.DeleteResearchStudyByResearchStudyIdentity(args.researchStudyIdentity)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new DeleteResearchStudyByResearchStudyIdentityResponse { @return = false};
    }
  }

}

[ApiController]
[Route("procedureSchedules")]
public partial class ProcedureSchedulesController : ControllerBase {

  public const String SchemaVersion = "1.3.0";

  private readonly ILogger<ProcedureSchedulesController> _logger;
  private readonly MedicalResearch.Workflow.Persistence.IProcedureScheduleRepository _Repo;

  public ProcedureSchedulesController(ILogger<ProcedureSchedulesController> logger) {
    _logger = logger;
    _Repo = new MedicalResearch.Workflow.Persistence.EF.ProcedureScheduleStore();
  }

  /// <summary> Loads a specific ProcedureSchedule addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-procedureschedule")]
  [HttpPost("getByProcedureScheduleId"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetProcedureScheduleByProcedureScheduleId), Description = nameof(GetProcedureScheduleByProcedureScheduleId))]
  public GetProcedureScheduleByProcedureScheduleIdResponse GetProcedureScheduleByProcedureScheduleId([FromBody][SwaggerRequestBody(Required=true)] GetProcedureScheduleByProcedureScheduleIdRequest args){
    try {
      return new GetProcedureScheduleByProcedureScheduleIdResponse { @return = _Repo.GetProcedureScheduleByProcedureScheduleId(args.procedureScheduleId)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetProcedureScheduleByProcedureScheduleIdResponse { @return = null};
    }
  }

  /// <summary> Loads ProcedureSchedules. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-procedureschedule")]
  [HttpPost("getAll"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetProcedureSchedules), Description = nameof(GetProcedureSchedules))]
  public GetProcedureSchedulesResponse GetProcedureSchedules([FromBody][SwaggerRequestBody(Required=true)] GetProcedureSchedulesRequest args){
    try {
      return new GetProcedureSchedulesResponse { @return = _Repo.GetProcedureSchedules(args.page, args.pageSize) }; 
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetProcedureSchedulesResponse { @return = null};
    }
  }

  /// <summary> Loads ProcedureSchedules where values matching to the given filterExpression</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-procedureschedule")]
  [HttpPost("search"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(SearchProcedureSchedules), Description = nameof(SearchProcedureSchedules))]
  public SearchProcedureSchedulesResponse SearchProcedureSchedules([FromBody][SwaggerRequestBody(Required=true)] SearchProcedureSchedulesRequest args){
    try {
      return new SearchProcedureSchedulesResponse { @return = _Repo.SearchProcedureSchedules(args.filterExpression, args.sort, args.page, args.pageSize) };
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new SearchProcedureSchedulesResponse { @return = null};
    }
  }

  /// <summary> Adds a new ProcedureSchedule and returns success. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("add-procedureschedule")]
  [HttpPost("addNew"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(AddNewProcedureSchedule), Description = nameof(AddNewProcedureSchedule))]
  public AddNewProcedureScheduleResponse AddNewProcedureSchedule([FromBody][SwaggerRequestBody(Required=true)] AddNewProcedureScheduleRequest args){
    try {
      return new AddNewProcedureScheduleResponse { @return = _Repo.AddNewProcedureSchedule(args.procedureSchedule)};  
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new AddNewProcedureScheduleResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ProcedureSchedule addressed by the primary identifier fields within the given ProcedureSchedule. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-procedureschedule")]
  [HttpPost("update"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateProcedureSchedule), Description = nameof(UpdateProcedureSchedule))]
  public UpdateProcedureScheduleResponse UpdateProcedureSchedule([FromBody][SwaggerRequestBody(Required=true)] UpdateProcedureScheduleRequest args){
    try {
      return new UpdateProcedureScheduleResponse { @return = _Repo.UpdateProcedureSchedule(args.procedureSchedule)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateProcedureScheduleResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ProcedureSchedule addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-procedureschedule")]
  [HttpPost("updateByProcedureScheduleId"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateProcedureScheduleByProcedureScheduleId), Description = nameof(UpdateProcedureScheduleByProcedureScheduleId))]
  public UpdateProcedureScheduleByProcedureScheduleIdResponse UpdateProcedureScheduleByProcedureScheduleId([FromBody][SwaggerRequestBody(Required=true)] UpdateProcedureScheduleByProcedureScheduleIdRequest args){
    try {
      return new UpdateProcedureScheduleByProcedureScheduleIdResponse { @return = _Repo.UpdateProcedureScheduleByProcedureScheduleId(args.procedureScheduleId, args.procedureSchedule)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateProcedureScheduleByProcedureScheduleIdResponse { @return = false};
    }
  }

  /// <summary> Deletes a specific ProcedureSchedule addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("delete-procedureschedule")]
  [HttpPost("deleteByProcedureScheduleId"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(DeleteProcedureScheduleByProcedureScheduleId), Description = nameof(DeleteProcedureScheduleByProcedureScheduleId))]
  public DeleteProcedureScheduleByProcedureScheduleIdResponse DeleteProcedureScheduleByProcedureScheduleId([FromBody][SwaggerRequestBody(Required=true)] DeleteProcedureScheduleByProcedureScheduleIdRequest args){
    try {
      return new DeleteProcedureScheduleByProcedureScheduleIdResponse { @return = _Repo.DeleteProcedureScheduleByProcedureScheduleId(args.procedureScheduleId)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new DeleteProcedureScheduleByProcedureScheduleIdResponse { @return = false};
    }
  }

}

[ApiController]
[Route("dataRecordingTasks")]
public partial class DataRecordingTasksController : ControllerBase {

  public const String SchemaVersion = "1.3.0";

  private readonly ILogger<DataRecordingTasksController> _logger;
  private readonly MedicalResearch.Workflow.Persistence.IDataRecordingTaskRepository _Repo;

  public DataRecordingTasksController(ILogger<DataRecordingTasksController> logger) {
    _logger = logger;
    _Repo = new MedicalResearch.Workflow.Persistence.EF.DataRecordingTaskStore();
  }

  /// <summary> Loads a specific DataRecordingTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-datarecordingtask")]
  [HttpPost("getByDataRecordingName"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetDataRecordingTaskByDataRecordingName), Description = nameof(GetDataRecordingTaskByDataRecordingName))]
  public GetDataRecordingTaskByDataRecordingNameResponse GetDataRecordingTaskByDataRecordingName([FromBody][SwaggerRequestBody(Required=true)] GetDataRecordingTaskByDataRecordingNameRequest args){
    try {
      return new GetDataRecordingTaskByDataRecordingNameResponse { @return = _Repo.GetDataRecordingTaskByDataRecordingName(args.dataRecordingName)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetDataRecordingTaskByDataRecordingNameResponse { @return = null};
    }
  }

  /// <summary> Loads DataRecordingTasks. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-datarecordingtask")]
  [HttpPost("getAll"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetDataRecordingTasks), Description = nameof(GetDataRecordingTasks))]
  public GetDataRecordingTasksResponse GetDataRecordingTasks([FromBody][SwaggerRequestBody(Required=true)] GetDataRecordingTasksRequest args){
    try {
      return new GetDataRecordingTasksResponse { @return = _Repo.GetDataRecordingTasks(args.page, args.pageSize) }; 
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetDataRecordingTasksResponse { @return = null};
    }
  }

  /// <summary> Loads DataRecordingTasks where values matching to the given filterExpression</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-datarecordingtask")]
  [HttpPost("search"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(SearchDataRecordingTasks), Description = nameof(SearchDataRecordingTasks))]
  public SearchDataRecordingTasksResponse SearchDataRecordingTasks([FromBody][SwaggerRequestBody(Required=true)] SearchDataRecordingTasksRequest args){
    try {
      return new SearchDataRecordingTasksResponse { @return = _Repo.SearchDataRecordingTasks(args.filterExpression, args.sort, args.page, args.pageSize) };
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new SearchDataRecordingTasksResponse { @return = null};
    }
  }

  /// <summary> Adds a new DataRecordingTask and returns success. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("add-datarecordingtask")]
  [HttpPost("addNew"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(AddNewDataRecordingTask), Description = nameof(AddNewDataRecordingTask))]
  public AddNewDataRecordingTaskResponse AddNewDataRecordingTask([FromBody][SwaggerRequestBody(Required=true)] AddNewDataRecordingTaskRequest args){
    try {
      return new AddNewDataRecordingTaskResponse { @return = _Repo.AddNewDataRecordingTask(args.dataRecordingTask)};  
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new AddNewDataRecordingTaskResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DataRecordingTask addressed by the primary identifier fields within the given DataRecordingTask. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-datarecordingtask")]
  [HttpPost("update"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateDataRecordingTask), Description = nameof(UpdateDataRecordingTask))]
  public UpdateDataRecordingTaskResponse UpdateDataRecordingTask([FromBody][SwaggerRequestBody(Required=true)] UpdateDataRecordingTaskRequest args){
    try {
      return new UpdateDataRecordingTaskResponse { @return = _Repo.UpdateDataRecordingTask(args.dataRecordingTask)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateDataRecordingTaskResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DataRecordingTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-datarecordingtask")]
  [HttpPost("updateByDataRecordingName"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateDataRecordingTaskByDataRecordingName), Description = nameof(UpdateDataRecordingTaskByDataRecordingName))]
  public UpdateDataRecordingTaskByDataRecordingNameResponse UpdateDataRecordingTaskByDataRecordingName([FromBody][SwaggerRequestBody(Required=true)] UpdateDataRecordingTaskByDataRecordingNameRequest args){
    try {
      return new UpdateDataRecordingTaskByDataRecordingNameResponse { @return = _Repo.UpdateDataRecordingTaskByDataRecordingName(args.dataRecordingName, args.dataRecordingTask)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateDataRecordingTaskByDataRecordingNameResponse { @return = false};
    }
  }

  /// <summary> Deletes a specific DataRecordingTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("delete-datarecordingtask")]
  [HttpPost("deleteByDataRecordingName"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(DeleteDataRecordingTaskByDataRecordingName), Description = nameof(DeleteDataRecordingTaskByDataRecordingName))]
  public DeleteDataRecordingTaskByDataRecordingNameResponse DeleteDataRecordingTaskByDataRecordingName([FromBody][SwaggerRequestBody(Required=true)] DeleteDataRecordingTaskByDataRecordingNameRequest args){
    try {
      return new DeleteDataRecordingTaskByDataRecordingNameResponse { @return = _Repo.DeleteDataRecordingTaskByDataRecordingName(args.dataRecordingName)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new DeleteDataRecordingTaskByDataRecordingNameResponse { @return = false};
    }
  }

}

[ApiController]
[Route("inducedDataRecordingTasks")]
public partial class InducedDataRecordingTasksController : ControllerBase {

  public const String SchemaVersion = "1.3.0";

  private readonly ILogger<InducedDataRecordingTasksController> _logger;
  private readonly MedicalResearch.Workflow.Persistence.IInducedDataRecordingTaskRepository _Repo;

  public InducedDataRecordingTasksController(ILogger<InducedDataRecordingTasksController> logger) {
    _logger = logger;
    _Repo = new MedicalResearch.Workflow.Persistence.EF.InducedDataRecordingTaskStore();
  }

  /// <summary> Loads a specific InducedDataRecordingTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-induceddatarecordingtask")]
  [HttpPost("getById"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetInducedDataRecordingTaskById), Description = nameof(GetInducedDataRecordingTaskById))]
  public GetInducedDataRecordingTaskByIdResponse GetInducedDataRecordingTaskById([FromBody][SwaggerRequestBody(Required=true)] GetInducedDataRecordingTaskByIdRequest args){
    try {
      return new GetInducedDataRecordingTaskByIdResponse { @return = _Repo.GetInducedDataRecordingTaskById(args.id)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetInducedDataRecordingTaskByIdResponse { @return = null};
    }
  }

  /// <summary> Loads InducedDataRecordingTasks. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-induceddatarecordingtask")]
  [HttpPost("getAll"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetInducedDataRecordingTasks), Description = nameof(GetInducedDataRecordingTasks))]
  public GetInducedDataRecordingTasksResponse GetInducedDataRecordingTasks([FromBody][SwaggerRequestBody(Required=true)] GetInducedDataRecordingTasksRequest args){
    try {
      return new GetInducedDataRecordingTasksResponse { @return = _Repo.GetInducedDataRecordingTasks(args.page, args.pageSize) }; 
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetInducedDataRecordingTasksResponse { @return = null};
    }
  }

  /// <summary> Loads InducedDataRecordingTasks where values matching to the given filterExpression</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-induceddatarecordingtask")]
  [HttpPost("search"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(SearchInducedDataRecordingTasks), Description = nameof(SearchInducedDataRecordingTasks))]
  public SearchInducedDataRecordingTasksResponse SearchInducedDataRecordingTasks([FromBody][SwaggerRequestBody(Required=true)] SearchInducedDataRecordingTasksRequest args){
    try {
      return new SearchInducedDataRecordingTasksResponse { @return = _Repo.SearchInducedDataRecordingTasks(args.filterExpression, args.sort, args.page, args.pageSize) };
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new SearchInducedDataRecordingTasksResponse { @return = null};
    }
  }

  /// <summary> Adds a new InducedDataRecordingTask and returns success. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("add-induceddatarecordingtask")]
  [HttpPost("addNew"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(AddNewInducedDataRecordingTask), Description = nameof(AddNewInducedDataRecordingTask))]
  public AddNewInducedDataRecordingTaskResponse AddNewInducedDataRecordingTask([FromBody][SwaggerRequestBody(Required=true)] AddNewInducedDataRecordingTaskRequest args){
    try {
      return new AddNewInducedDataRecordingTaskResponse { @return = _Repo.AddNewInducedDataRecordingTask(args.inducedDataRecordingTask)};  
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new AddNewInducedDataRecordingTaskResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedDataRecordingTask addressed by the primary identifier fields within the given InducedDataRecordingTask. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-induceddatarecordingtask")]
  [HttpPost("update"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateInducedDataRecordingTask), Description = nameof(UpdateInducedDataRecordingTask))]
  public UpdateInducedDataRecordingTaskResponse UpdateInducedDataRecordingTask([FromBody][SwaggerRequestBody(Required=true)] UpdateInducedDataRecordingTaskRequest args){
    try {
      return new UpdateInducedDataRecordingTaskResponse { @return = _Repo.UpdateInducedDataRecordingTask(args.inducedDataRecordingTask)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateInducedDataRecordingTaskResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedDataRecordingTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-induceddatarecordingtask")]
  [HttpPost("updateById"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateInducedDataRecordingTaskById), Description = nameof(UpdateInducedDataRecordingTaskById))]
  public UpdateInducedDataRecordingTaskByIdResponse UpdateInducedDataRecordingTaskById([FromBody][SwaggerRequestBody(Required=true)] UpdateInducedDataRecordingTaskByIdRequest args){
    try {
      return new UpdateInducedDataRecordingTaskByIdResponse { @return = _Repo.UpdateInducedDataRecordingTaskById(args.id, args.inducedDataRecordingTask)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateInducedDataRecordingTaskByIdResponse { @return = false};
    }
  }

  /// <summary> Deletes a specific InducedDataRecordingTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("delete-induceddatarecordingtask")]
  [HttpPost("deleteById"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(DeleteInducedDataRecordingTaskById), Description = nameof(DeleteInducedDataRecordingTaskById))]
  public DeleteInducedDataRecordingTaskByIdResponse DeleteInducedDataRecordingTaskById([FromBody][SwaggerRequestBody(Required=true)] DeleteInducedDataRecordingTaskByIdRequest args){
    try {
      return new DeleteInducedDataRecordingTaskByIdResponse { @return = _Repo.DeleteInducedDataRecordingTaskById(args.id)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new DeleteInducedDataRecordingTaskByIdResponse { @return = false};
    }
  }

}

[ApiController]
[Route("drugAppliymentTasks")]
public partial class DrugAppliymentTasksController : ControllerBase {

  public const String SchemaVersion = "1.3.0";

  private readonly ILogger<DrugAppliymentTasksController> _logger;
  private readonly MedicalResearch.Workflow.Persistence.IDrugApplymentTaskRepository _Repo;

  public DrugAppliymentTasksController(ILogger<DrugAppliymentTasksController> logger) {
    _logger = logger;
    _Repo = new MedicalResearch.Workflow.Persistence.EF.DrugApplymentTaskStore();
  }

  /// <summary> Loads a specific DrugApplymentTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-drugapplymenttask")]
  [HttpPost("getByDrugApplymentName"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetDrugApplymentTaskByDrugApplymentName), Description = nameof(GetDrugApplymentTaskByDrugApplymentName))]
  public GetDrugApplymentTaskByDrugApplymentNameResponse GetDrugApplymentTaskByDrugApplymentName([FromBody][SwaggerRequestBody(Required=true)] GetDrugApplymentTaskByDrugApplymentNameRequest args){
    try {
      return new GetDrugApplymentTaskByDrugApplymentNameResponse { @return = _Repo.GetDrugApplymentTaskByDrugApplymentName(args.drugApplymentName)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetDrugApplymentTaskByDrugApplymentNameResponse { @return = null};
    }
  }

  /// <summary> Loads DrugAppliymentTasks. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-drugapplymenttask")]
  [HttpPost("getAll"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetDrugAppliymentTasks), Description = nameof(GetDrugAppliymentTasks))]
  public GetDrugAppliymentTasksResponse GetDrugAppliymentTasks([FromBody][SwaggerRequestBody(Required=true)] GetDrugAppliymentTasksRequest args){
    try {
      return new GetDrugAppliymentTasksResponse { @return = _Repo.GetDrugAppliymentTasks(args.page, args.pageSize) }; 
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetDrugAppliymentTasksResponse { @return = null};
    }
  }

  /// <summary> Loads DrugAppliymentTasks where values matching to the given filterExpression</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-drugapplymenttask")]
  [HttpPost("search"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(SearchDrugAppliymentTasks), Description = nameof(SearchDrugAppliymentTasks))]
  public SearchDrugAppliymentTasksResponse SearchDrugAppliymentTasks([FromBody][SwaggerRequestBody(Required=true)] SearchDrugAppliymentTasksRequest args){
    try {
      return new SearchDrugAppliymentTasksResponse { @return = _Repo.SearchDrugAppliymentTasks(args.filterExpression, args.sort, args.page, args.pageSize) };
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new SearchDrugAppliymentTasksResponse { @return = null};
    }
  }

  /// <summary> Adds a new DrugApplymentTask and returns success. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("add-drugapplymenttask")]
  [HttpPost("addNew"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(AddNewDrugApplymentTask), Description = nameof(AddNewDrugApplymentTask))]
  public AddNewDrugApplymentTaskResponse AddNewDrugApplymentTask([FromBody][SwaggerRequestBody(Required=true)] AddNewDrugApplymentTaskRequest args){
    try {
      return new AddNewDrugApplymentTaskResponse { @return = _Repo.AddNewDrugApplymentTask(args.drugApplymentTask)};  
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new AddNewDrugApplymentTaskResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DrugApplymentTask addressed by the primary identifier fields within the given DrugApplymentTask. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-drugapplymenttask")]
  [HttpPost("update"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateDrugApplymentTask), Description = nameof(UpdateDrugApplymentTask))]
  public UpdateDrugApplymentTaskResponse UpdateDrugApplymentTask([FromBody][SwaggerRequestBody(Required=true)] UpdateDrugApplymentTaskRequest args){
    try {
      return new UpdateDrugApplymentTaskResponse { @return = _Repo.UpdateDrugApplymentTask(args.drugApplymentTask)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateDrugApplymentTaskResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DrugApplymentTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-drugapplymenttask")]
  [HttpPost("updateByDrugApplymentName"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateDrugApplymentTaskByDrugApplymentName), Description = nameof(UpdateDrugApplymentTaskByDrugApplymentName))]
  public UpdateDrugApplymentTaskByDrugApplymentNameResponse UpdateDrugApplymentTaskByDrugApplymentName([FromBody][SwaggerRequestBody(Required=true)] UpdateDrugApplymentTaskByDrugApplymentNameRequest args){
    try {
      return new UpdateDrugApplymentTaskByDrugApplymentNameResponse { @return = _Repo.UpdateDrugApplymentTaskByDrugApplymentName(args.drugApplymentName, args.drugApplymentTask)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateDrugApplymentTaskByDrugApplymentNameResponse { @return = false};
    }
  }

  /// <summary> Deletes a specific DrugApplymentTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("delete-drugapplymenttask")]
  [HttpPost("deleteByDrugApplymentName"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(DeleteDrugApplymentTaskByDrugApplymentName), Description = nameof(DeleteDrugApplymentTaskByDrugApplymentName))]
  public DeleteDrugApplymentTaskByDrugApplymentNameResponse DeleteDrugApplymentTaskByDrugApplymentName([FromBody][SwaggerRequestBody(Required=true)] DeleteDrugApplymentTaskByDrugApplymentNameRequest args){
    try {
      return new DeleteDrugApplymentTaskByDrugApplymentNameResponse { @return = _Repo.DeleteDrugApplymentTaskByDrugApplymentName(args.drugApplymentName)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new DeleteDrugApplymentTaskByDrugApplymentNameResponse { @return = false};
    }
  }

}

[ApiController]
[Route("inducedDrugApplymentTasks")]
public partial class InducedDrugApplymentTasksController : ControllerBase {

  public const String SchemaVersion = "1.3.0";

  private readonly ILogger<InducedDrugApplymentTasksController> _logger;
  private readonly MedicalResearch.Workflow.Persistence.IInducedDrugApplymentTaskRepository _Repo;

  public InducedDrugApplymentTasksController(ILogger<InducedDrugApplymentTasksController> logger) {
    _logger = logger;
    _Repo = new MedicalResearch.Workflow.Persistence.EF.InducedDrugApplymentTaskStore();
  }

  /// <summary> Loads a specific InducedDrugApplymentTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-induceddrugapplymenttask")]
  [HttpPost("getById"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetInducedDrugApplymentTaskById), Description = nameof(GetInducedDrugApplymentTaskById))]
  public GetInducedDrugApplymentTaskByIdResponse GetInducedDrugApplymentTaskById([FromBody][SwaggerRequestBody(Required=true)] GetInducedDrugApplymentTaskByIdRequest args){
    try {
      return new GetInducedDrugApplymentTaskByIdResponse { @return = _Repo.GetInducedDrugApplymentTaskById(args.id)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetInducedDrugApplymentTaskByIdResponse { @return = null};
    }
  }

  /// <summary> Loads InducedDrugApplymentTasks. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-induceddrugapplymenttask")]
  [HttpPost("getAll"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetInducedDrugApplymentTasks), Description = nameof(GetInducedDrugApplymentTasks))]
  public GetInducedDrugApplymentTasksResponse GetInducedDrugApplymentTasks([FromBody][SwaggerRequestBody(Required=true)] GetInducedDrugApplymentTasksRequest args){
    try {
      return new GetInducedDrugApplymentTasksResponse { @return = _Repo.GetInducedDrugApplymentTasks(args.page, args.pageSize) }; 
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetInducedDrugApplymentTasksResponse { @return = null};
    }
  }

  /// <summary> Loads InducedDrugApplymentTasks where values matching to the given filterExpression</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-induceddrugapplymenttask")]
  [HttpPost("search"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(SearchInducedDrugApplymentTasks), Description = nameof(SearchInducedDrugApplymentTasks))]
  public SearchInducedDrugApplymentTasksResponse SearchInducedDrugApplymentTasks([FromBody][SwaggerRequestBody(Required=true)] SearchInducedDrugApplymentTasksRequest args){
    try {
      return new SearchInducedDrugApplymentTasksResponse { @return = _Repo.SearchInducedDrugApplymentTasks(args.filterExpression, args.sort, args.page, args.pageSize) };
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new SearchInducedDrugApplymentTasksResponse { @return = null};
    }
  }

  /// <summary> Adds a new InducedDrugApplymentTask and returns success. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("add-induceddrugapplymenttask")]
  [HttpPost("addNew"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(AddNewInducedDrugApplymentTask), Description = nameof(AddNewInducedDrugApplymentTask))]
  public AddNewInducedDrugApplymentTaskResponse AddNewInducedDrugApplymentTask([FromBody][SwaggerRequestBody(Required=true)] AddNewInducedDrugApplymentTaskRequest args){
    try {
      return new AddNewInducedDrugApplymentTaskResponse { @return = _Repo.AddNewInducedDrugApplymentTask(args.inducedDrugApplymentTask)};  
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new AddNewInducedDrugApplymentTaskResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedDrugApplymentTask addressed by the primary identifier fields within the given InducedDrugApplymentTask. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-induceddrugapplymenttask")]
  [HttpPost("update"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateInducedDrugApplymentTask), Description = nameof(UpdateInducedDrugApplymentTask))]
  public UpdateInducedDrugApplymentTaskResponse UpdateInducedDrugApplymentTask([FromBody][SwaggerRequestBody(Required=true)] UpdateInducedDrugApplymentTaskRequest args){
    try {
      return new UpdateInducedDrugApplymentTaskResponse { @return = _Repo.UpdateInducedDrugApplymentTask(args.inducedDrugApplymentTask)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateInducedDrugApplymentTaskResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedDrugApplymentTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-induceddrugapplymenttask")]
  [HttpPost("updateById"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateInducedDrugApplymentTaskById), Description = nameof(UpdateInducedDrugApplymentTaskById))]
  public UpdateInducedDrugApplymentTaskByIdResponse UpdateInducedDrugApplymentTaskById([FromBody][SwaggerRequestBody(Required=true)] UpdateInducedDrugApplymentTaskByIdRequest args){
    try {
      return new UpdateInducedDrugApplymentTaskByIdResponse { @return = _Repo.UpdateInducedDrugApplymentTaskById(args.id, args.inducedDrugApplymentTask)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateInducedDrugApplymentTaskByIdResponse { @return = false};
    }
  }

  /// <summary> Deletes a specific InducedDrugApplymentTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("delete-induceddrugapplymenttask")]
  [HttpPost("deleteById"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(DeleteInducedDrugApplymentTaskById), Description = nameof(DeleteInducedDrugApplymentTaskById))]
  public DeleteInducedDrugApplymentTaskByIdResponse DeleteInducedDrugApplymentTaskById([FromBody][SwaggerRequestBody(Required=true)] DeleteInducedDrugApplymentTaskByIdRequest args){
    try {
      return new DeleteInducedDrugApplymentTaskByIdResponse { @return = _Repo.DeleteInducedDrugApplymentTaskById(args.id)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new DeleteInducedDrugApplymentTaskByIdResponse { @return = false};
    }
  }

}

[ApiController]
[Route("taskSchedules")]
public partial class TaskSchedulesController : ControllerBase {

  public const String SchemaVersion = "1.3.0";

  private readonly ILogger<TaskSchedulesController> _logger;
  private readonly MedicalResearch.Workflow.Persistence.ITaskScheduleRepository _Repo;

  public TaskSchedulesController(ILogger<TaskSchedulesController> logger) {
    _logger = logger;
    _Repo = new MedicalResearch.Workflow.Persistence.EF.TaskScheduleStore();
  }

  /// <summary> Loads a specific TaskSchedule addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-taskschedule")]
  [HttpPost("getByTaskScheduleId"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetTaskScheduleByTaskScheduleId), Description = nameof(GetTaskScheduleByTaskScheduleId))]
  public GetTaskScheduleByTaskScheduleIdResponse GetTaskScheduleByTaskScheduleId([FromBody][SwaggerRequestBody(Required=true)] GetTaskScheduleByTaskScheduleIdRequest args){
    try {
      return new GetTaskScheduleByTaskScheduleIdResponse { @return = _Repo.GetTaskScheduleByTaskScheduleId(args.taskScheduleId)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetTaskScheduleByTaskScheduleIdResponse { @return = null};
    }
  }

  /// <summary> Loads TaskSchedules. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-taskschedule")]
  [HttpPost("getAll"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetTaskSchedules), Description = nameof(GetTaskSchedules))]
  public GetTaskSchedulesResponse GetTaskSchedules([FromBody][SwaggerRequestBody(Required=true)] GetTaskSchedulesRequest args){
    try {
      return new GetTaskSchedulesResponse { @return = _Repo.GetTaskSchedules(args.page, args.pageSize) }; 
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetTaskSchedulesResponse { @return = null};
    }
  }

  /// <summary> Loads TaskSchedules where values matching to the given filterExpression</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-taskschedule")]
  [HttpPost("search"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(SearchTaskSchedules), Description = nameof(SearchTaskSchedules))]
  public SearchTaskSchedulesResponse SearchTaskSchedules([FromBody][SwaggerRequestBody(Required=true)] SearchTaskSchedulesRequest args){
    try {
      return new SearchTaskSchedulesResponse { @return = _Repo.SearchTaskSchedules(args.filterExpression, args.sort, args.page, args.pageSize) };
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new SearchTaskSchedulesResponse { @return = null};
    }
  }

  /// <summary> Adds a new TaskSchedule and returns success. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("add-taskschedule")]
  [HttpPost("addNew"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(AddNewTaskSchedule), Description = nameof(AddNewTaskSchedule))]
  public AddNewTaskScheduleResponse AddNewTaskSchedule([FromBody][SwaggerRequestBody(Required=true)] AddNewTaskScheduleRequest args){
    try {
      return new AddNewTaskScheduleResponse { @return = _Repo.AddNewTaskSchedule(args.taskSchedule)};  
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new AddNewTaskScheduleResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given TaskSchedule addressed by the primary identifier fields within the given TaskSchedule. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-taskschedule")]
  [HttpPost("update"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateTaskSchedule), Description = nameof(UpdateTaskSchedule))]
  public UpdateTaskScheduleResponse UpdateTaskSchedule([FromBody][SwaggerRequestBody(Required=true)] UpdateTaskScheduleRequest args){
    try {
      return new UpdateTaskScheduleResponse { @return = _Repo.UpdateTaskSchedule(args.taskSchedule)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateTaskScheduleResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given TaskSchedule addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-taskschedule")]
  [HttpPost("updateByTaskScheduleId"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateTaskScheduleByTaskScheduleId), Description = nameof(UpdateTaskScheduleByTaskScheduleId))]
  public UpdateTaskScheduleByTaskScheduleIdResponse UpdateTaskScheduleByTaskScheduleId([FromBody][SwaggerRequestBody(Required=true)] UpdateTaskScheduleByTaskScheduleIdRequest args){
    try {
      return new UpdateTaskScheduleByTaskScheduleIdResponse { @return = _Repo.UpdateTaskScheduleByTaskScheduleId(args.taskScheduleId, args.taskSchedule)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateTaskScheduleByTaskScheduleIdResponse { @return = false};
    }
  }

  /// <summary> Deletes a specific TaskSchedule addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("delete-taskschedule")]
  [HttpPost("deleteByTaskScheduleId"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(DeleteTaskScheduleByTaskScheduleId), Description = nameof(DeleteTaskScheduleByTaskScheduleId))]
  public DeleteTaskScheduleByTaskScheduleIdResponse DeleteTaskScheduleByTaskScheduleId([FromBody][SwaggerRequestBody(Required=true)] DeleteTaskScheduleByTaskScheduleIdRequest args){
    try {
      return new DeleteTaskScheduleByTaskScheduleIdResponse { @return = _Repo.DeleteTaskScheduleByTaskScheduleId(args.taskScheduleId)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new DeleteTaskScheduleByTaskScheduleIdResponse { @return = false};
    }
  }

}

[ApiController]
[Route("inducedSubProcedureSchedules")]
public partial class InducedSubProcedureSchedulesController : ControllerBase {

  public const String SchemaVersion = "1.3.0";

  private readonly ILogger<InducedSubProcedureSchedulesController> _logger;
  private readonly MedicalResearch.Workflow.Persistence.IInducedSubProcedureScheduleRepository _Repo;

  public InducedSubProcedureSchedulesController(ILogger<InducedSubProcedureSchedulesController> logger) {
    _logger = logger;
    _Repo = new MedicalResearch.Workflow.Persistence.EF.InducedSubProcedureScheduleStore();
  }

  /// <summary> Loads a specific InducedSubProcedureSchedule addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-inducedsubprocedureschedule")]
  [HttpPost("getById"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetInducedSubProcedureScheduleById), Description = nameof(GetInducedSubProcedureScheduleById))]
  public GetInducedSubProcedureScheduleByIdResponse GetInducedSubProcedureScheduleById([FromBody][SwaggerRequestBody(Required=true)] GetInducedSubProcedureScheduleByIdRequest args){
    try {
      return new GetInducedSubProcedureScheduleByIdResponse { @return = _Repo.GetInducedSubProcedureScheduleById(args.id)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetInducedSubProcedureScheduleByIdResponse { @return = null};
    }
  }

  /// <summary> Loads InducedSubProcedureSchedules. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-inducedsubprocedureschedule")]
  [HttpPost("getAll"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetInducedSubProcedureSchedules), Description = nameof(GetInducedSubProcedureSchedules))]
  public GetInducedSubProcedureSchedulesResponse GetInducedSubProcedureSchedules([FromBody][SwaggerRequestBody(Required=true)] GetInducedSubProcedureSchedulesRequest args){
    try {
      return new GetInducedSubProcedureSchedulesResponse { @return = _Repo.GetInducedSubProcedureSchedules(args.page, args.pageSize) }; 
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetInducedSubProcedureSchedulesResponse { @return = null};
    }
  }

  /// <summary> Loads InducedSubProcedureSchedules where values matching to the given filterExpression</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-inducedsubprocedureschedule")]
  [HttpPost("search"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(SearchInducedSubProcedureSchedules), Description = nameof(SearchInducedSubProcedureSchedules))]
  public SearchInducedSubProcedureSchedulesResponse SearchInducedSubProcedureSchedules([FromBody][SwaggerRequestBody(Required=true)] SearchInducedSubProcedureSchedulesRequest args){
    try {
      return new SearchInducedSubProcedureSchedulesResponse { @return = _Repo.SearchInducedSubProcedureSchedules(args.filterExpression, args.sort, args.page, args.pageSize) };
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new SearchInducedSubProcedureSchedulesResponse { @return = null};
    }
  }

  /// <summary> Adds a new InducedSubProcedureSchedule and returns success. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("add-inducedsubprocedureschedule")]
  [HttpPost("addNew"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(AddNewInducedSubProcedureSchedule), Description = nameof(AddNewInducedSubProcedureSchedule))]
  public AddNewInducedSubProcedureScheduleResponse AddNewInducedSubProcedureSchedule([FromBody][SwaggerRequestBody(Required=true)] AddNewInducedSubProcedureScheduleRequest args){
    try {
      return new AddNewInducedSubProcedureScheduleResponse { @return = _Repo.AddNewInducedSubProcedureSchedule(args.inducedSubProcedureSchedule)};  
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new AddNewInducedSubProcedureScheduleResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedSubProcedureSchedule addressed by the primary identifier fields within the given InducedSubProcedureSchedule. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-inducedsubprocedureschedule")]
  [HttpPost("update"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateInducedSubProcedureSchedule), Description = nameof(UpdateInducedSubProcedureSchedule))]
  public UpdateInducedSubProcedureScheduleResponse UpdateInducedSubProcedureSchedule([FromBody][SwaggerRequestBody(Required=true)] UpdateInducedSubProcedureScheduleRequest args){
    try {
      return new UpdateInducedSubProcedureScheduleResponse { @return = _Repo.UpdateInducedSubProcedureSchedule(args.inducedSubProcedureSchedule)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateInducedSubProcedureScheduleResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedSubProcedureSchedule addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-inducedsubprocedureschedule")]
  [HttpPost("updateById"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateInducedSubProcedureScheduleById), Description = nameof(UpdateInducedSubProcedureScheduleById))]
  public UpdateInducedSubProcedureScheduleByIdResponse UpdateInducedSubProcedureScheduleById([FromBody][SwaggerRequestBody(Required=true)] UpdateInducedSubProcedureScheduleByIdRequest args){
    try {
      return new UpdateInducedSubProcedureScheduleByIdResponse { @return = _Repo.UpdateInducedSubProcedureScheduleById(args.id, args.inducedSubProcedureSchedule)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateInducedSubProcedureScheduleByIdResponse { @return = false};
    }
  }

  /// <summary> Deletes a specific InducedSubProcedureSchedule addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("delete-inducedsubprocedureschedule")]
  [HttpPost("deleteById"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(DeleteInducedSubProcedureScheduleById), Description = nameof(DeleteInducedSubProcedureScheduleById))]
  public DeleteInducedSubProcedureScheduleByIdResponse DeleteInducedSubProcedureScheduleById([FromBody][SwaggerRequestBody(Required=true)] DeleteInducedSubProcedureScheduleByIdRequest args){
    try {
      return new DeleteInducedSubProcedureScheduleByIdResponse { @return = _Repo.DeleteInducedSubProcedureScheduleById(args.id)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new DeleteInducedSubProcedureScheduleByIdResponse { @return = false};
    }
  }

}

[ApiController]
[Route("inducedSubTaskSchedules")]
public partial class InducedSubTaskSchedulesController : ControllerBase {

  public const String SchemaVersion = "1.3.0";

  private readonly ILogger<InducedSubTaskSchedulesController> _logger;
  private readonly MedicalResearch.Workflow.Persistence.IInducedSubTaskScheduleRepository _Repo;

  public InducedSubTaskSchedulesController(ILogger<InducedSubTaskSchedulesController> logger) {
    _logger = logger;
    _Repo = new MedicalResearch.Workflow.Persistence.EF.InducedSubTaskScheduleStore();
  }

  /// <summary> Loads a specific InducedSubTaskSchedule addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-inducedsubtaskschedule")]
  [HttpPost("getById"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetInducedSubTaskScheduleById), Description = nameof(GetInducedSubTaskScheduleById))]
  public GetInducedSubTaskScheduleByIdResponse GetInducedSubTaskScheduleById([FromBody][SwaggerRequestBody(Required=true)] GetInducedSubTaskScheduleByIdRequest args){
    try {
      return new GetInducedSubTaskScheduleByIdResponse { @return = _Repo.GetInducedSubTaskScheduleById(args.id)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetInducedSubTaskScheduleByIdResponse { @return = null};
    }
  }

  /// <summary> Loads InducedSubTaskSchedules. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-inducedsubtaskschedule")]
  [HttpPost("getAll"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetInducedSubTaskSchedules), Description = nameof(GetInducedSubTaskSchedules))]
  public GetInducedSubTaskSchedulesResponse GetInducedSubTaskSchedules([FromBody][SwaggerRequestBody(Required=true)] GetInducedSubTaskSchedulesRequest args){
    try {
      return new GetInducedSubTaskSchedulesResponse { @return = _Repo.GetInducedSubTaskSchedules(args.page, args.pageSize) }; 
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetInducedSubTaskSchedulesResponse { @return = null};
    }
  }

  /// <summary> Loads InducedSubTaskSchedules where values matching to the given filterExpression</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-inducedsubtaskschedule")]
  [HttpPost("search"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(SearchInducedSubTaskSchedules), Description = nameof(SearchInducedSubTaskSchedules))]
  public SearchInducedSubTaskSchedulesResponse SearchInducedSubTaskSchedules([FromBody][SwaggerRequestBody(Required=true)] SearchInducedSubTaskSchedulesRequest args){
    try {
      return new SearchInducedSubTaskSchedulesResponse { @return = _Repo.SearchInducedSubTaskSchedules(args.filterExpression, args.sort, args.page, args.pageSize) };
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new SearchInducedSubTaskSchedulesResponse { @return = null};
    }
  }

  /// <summary> Adds a new InducedSubTaskSchedule and returns success. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("add-inducedsubtaskschedule")]
  [HttpPost("addNew"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(AddNewInducedSubTaskSchedule), Description = nameof(AddNewInducedSubTaskSchedule))]
  public AddNewInducedSubTaskScheduleResponse AddNewInducedSubTaskSchedule([FromBody][SwaggerRequestBody(Required=true)] AddNewInducedSubTaskScheduleRequest args){
    try {
      return new AddNewInducedSubTaskScheduleResponse { @return = _Repo.AddNewInducedSubTaskSchedule(args.inducedSubTaskSchedule)};  
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new AddNewInducedSubTaskScheduleResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedSubTaskSchedule addressed by the primary identifier fields within the given InducedSubTaskSchedule. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-inducedsubtaskschedule")]
  [HttpPost("update"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateInducedSubTaskSchedule), Description = nameof(UpdateInducedSubTaskSchedule))]
  public UpdateInducedSubTaskScheduleResponse UpdateInducedSubTaskSchedule([FromBody][SwaggerRequestBody(Required=true)] UpdateInducedSubTaskScheduleRequest args){
    try {
      return new UpdateInducedSubTaskScheduleResponse { @return = _Repo.UpdateInducedSubTaskSchedule(args.inducedSubTaskSchedule)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateInducedSubTaskScheduleResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedSubTaskSchedule addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-inducedsubtaskschedule")]
  [HttpPost("updateById"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateInducedSubTaskScheduleById), Description = nameof(UpdateInducedSubTaskScheduleById))]
  public UpdateInducedSubTaskScheduleByIdResponse UpdateInducedSubTaskScheduleById([FromBody][SwaggerRequestBody(Required=true)] UpdateInducedSubTaskScheduleByIdRequest args){
    try {
      return new UpdateInducedSubTaskScheduleByIdResponse { @return = _Repo.UpdateInducedSubTaskScheduleById(args.id, args.inducedSubTaskSchedule)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateInducedSubTaskScheduleByIdResponse { @return = false};
    }
  }

  /// <summary> Deletes a specific InducedSubTaskSchedule addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("delete-inducedsubtaskschedule")]
  [HttpPost("deleteById"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(DeleteInducedSubTaskScheduleById), Description = nameof(DeleteInducedSubTaskScheduleById))]
  public DeleteInducedSubTaskScheduleByIdResponse DeleteInducedSubTaskScheduleById([FromBody][SwaggerRequestBody(Required=true)] DeleteInducedSubTaskScheduleByIdRequest args){
    try {
      return new DeleteInducedSubTaskScheduleByIdResponse { @return = _Repo.DeleteInducedSubTaskScheduleById(args.id)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new DeleteInducedSubTaskScheduleByIdResponse { @return = false};
    }
  }

}

[ApiController]
[Route("inducedTreatmentTasks")]
public partial class InducedTreatmentTasksController : ControllerBase {

  public const String SchemaVersion = "1.3.0";

  private readonly ILogger<InducedTreatmentTasksController> _logger;
  private readonly MedicalResearch.Workflow.Persistence.IInducedTreatmentTaskRepository _Repo;

  public InducedTreatmentTasksController(ILogger<InducedTreatmentTasksController> logger) {
    _logger = logger;
    _Repo = new MedicalResearch.Workflow.Persistence.EF.InducedTreatmentTaskStore();
  }

  /// <summary> Loads a specific InducedTreatmentTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-inducedtreatmenttask")]
  [HttpPost("getById"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetInducedTreatmentTaskById), Description = nameof(GetInducedTreatmentTaskById))]
  public GetInducedTreatmentTaskByIdResponse GetInducedTreatmentTaskById([FromBody][SwaggerRequestBody(Required=true)] GetInducedTreatmentTaskByIdRequest args){
    try {
      return new GetInducedTreatmentTaskByIdResponse { @return = _Repo.GetInducedTreatmentTaskById(args.id)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetInducedTreatmentTaskByIdResponse { @return = null};
    }
  }

  /// <summary> Loads InducedTreatmentTasks. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-inducedtreatmenttask")]
  [HttpPost("getAll"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetInducedTreatmentTasks), Description = nameof(GetInducedTreatmentTasks))]
  public GetInducedTreatmentTasksResponse GetInducedTreatmentTasks([FromBody][SwaggerRequestBody(Required=true)] GetInducedTreatmentTasksRequest args){
    try {
      return new GetInducedTreatmentTasksResponse { @return = _Repo.GetInducedTreatmentTasks(args.page, args.pageSize) }; 
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetInducedTreatmentTasksResponse { @return = null};
    }
  }

  /// <summary> Loads InducedTreatmentTasks where values matching to the given filterExpression</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-inducedtreatmenttask")]
  [HttpPost("search"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(SearchInducedTreatmentTasks), Description = nameof(SearchInducedTreatmentTasks))]
  public SearchInducedTreatmentTasksResponse SearchInducedTreatmentTasks([FromBody][SwaggerRequestBody(Required=true)] SearchInducedTreatmentTasksRequest args){
    try {
      return new SearchInducedTreatmentTasksResponse { @return = _Repo.SearchInducedTreatmentTasks(args.filterExpression, args.sort, args.page, args.pageSize) };
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new SearchInducedTreatmentTasksResponse { @return = null};
    }
  }

  /// <summary> Adds a new InducedTreatmentTask and returns success. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("add-inducedtreatmenttask")]
  [HttpPost("addNew"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(AddNewInducedTreatmentTask), Description = nameof(AddNewInducedTreatmentTask))]
  public AddNewInducedTreatmentTaskResponse AddNewInducedTreatmentTask([FromBody][SwaggerRequestBody(Required=true)] AddNewInducedTreatmentTaskRequest args){
    try {
      return new AddNewInducedTreatmentTaskResponse { @return = _Repo.AddNewInducedTreatmentTask(args.inducedTreatmentTask)};  
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new AddNewInducedTreatmentTaskResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedTreatmentTask addressed by the primary identifier fields within the given InducedTreatmentTask. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-inducedtreatmenttask")]
  [HttpPost("update"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateInducedTreatmentTask), Description = nameof(UpdateInducedTreatmentTask))]
  public UpdateInducedTreatmentTaskResponse UpdateInducedTreatmentTask([FromBody][SwaggerRequestBody(Required=true)] UpdateInducedTreatmentTaskRequest args){
    try {
      return new UpdateInducedTreatmentTaskResponse { @return = _Repo.UpdateInducedTreatmentTask(args.inducedTreatmentTask)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateInducedTreatmentTaskResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedTreatmentTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-inducedtreatmenttask")]
  [HttpPost("updateById"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateInducedTreatmentTaskById), Description = nameof(UpdateInducedTreatmentTaskById))]
  public UpdateInducedTreatmentTaskByIdResponse UpdateInducedTreatmentTaskById([FromBody][SwaggerRequestBody(Required=true)] UpdateInducedTreatmentTaskByIdRequest args){
    try {
      return new UpdateInducedTreatmentTaskByIdResponse { @return = _Repo.UpdateInducedTreatmentTaskById(args.id, args.inducedTreatmentTask)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateInducedTreatmentTaskByIdResponse { @return = false};
    }
  }

  /// <summary> Deletes a specific InducedTreatmentTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("delete-inducedtreatmenttask")]
  [HttpPost("deleteById"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(DeleteInducedTreatmentTaskById), Description = nameof(DeleteInducedTreatmentTaskById))]
  public DeleteInducedTreatmentTaskByIdResponse DeleteInducedTreatmentTaskById([FromBody][SwaggerRequestBody(Required=true)] DeleteInducedTreatmentTaskByIdRequest args){
    try {
      return new DeleteInducedTreatmentTaskByIdResponse { @return = _Repo.DeleteInducedTreatmentTaskById(args.id)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new DeleteInducedTreatmentTaskByIdResponse { @return = false};
    }
  }

}

[ApiController]
[Route("treatmentTasks")]
public partial class TreatmentTasksController : ControllerBase {

  public const String SchemaVersion = "1.3.0";

  private readonly ILogger<TreatmentTasksController> _logger;
  private readonly MedicalResearch.Workflow.Persistence.ITreatmentTaskRepository _Repo;

  public TreatmentTasksController(ILogger<TreatmentTasksController> logger) {
    _logger = logger;
    _Repo = new MedicalResearch.Workflow.Persistence.EF.TreatmentTaskStore();
  }

  /// <summary> Loads a specific TreatmentTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-treatmenttask")]
  [HttpPost("getByTreatmentName"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetTreatmentTaskByTreatmentName), Description = nameof(GetTreatmentTaskByTreatmentName))]
  public GetTreatmentTaskByTreatmentNameResponse GetTreatmentTaskByTreatmentName([FromBody][SwaggerRequestBody(Required=true)] GetTreatmentTaskByTreatmentNameRequest args){
    try {
      return new GetTreatmentTaskByTreatmentNameResponse { @return = _Repo.GetTreatmentTaskByTreatmentName(args.treatmentName)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetTreatmentTaskByTreatmentNameResponse { @return = null};
    }
  }

  /// <summary> Loads TreatmentTasks. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-treatmenttask")]
  [HttpPost("getAll"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetTreatmentTasks), Description = nameof(GetTreatmentTasks))]
  public GetTreatmentTasksResponse GetTreatmentTasks([FromBody][SwaggerRequestBody(Required=true)] GetTreatmentTasksRequest args){
    try {
      return new GetTreatmentTasksResponse { @return = _Repo.GetTreatmentTasks(args.page, args.pageSize) }; 
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetTreatmentTasksResponse { @return = null};
    }
  }

  /// <summary> Loads TreatmentTasks where values matching to the given filterExpression</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-treatmenttask")]
  [HttpPost("search"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(SearchTreatmentTasks), Description = nameof(SearchTreatmentTasks))]
  public SearchTreatmentTasksResponse SearchTreatmentTasks([FromBody][SwaggerRequestBody(Required=true)] SearchTreatmentTasksRequest args){
    try {
      return new SearchTreatmentTasksResponse { @return = _Repo.SearchTreatmentTasks(args.filterExpression, args.sort, args.page, args.pageSize) };
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new SearchTreatmentTasksResponse { @return = null};
    }
  }

  /// <summary> Adds a new TreatmentTask and returns success. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("add-treatmenttask")]
  [HttpPost("addNew"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(AddNewTreatmentTask), Description = nameof(AddNewTreatmentTask))]
  public AddNewTreatmentTaskResponse AddNewTreatmentTask([FromBody][SwaggerRequestBody(Required=true)] AddNewTreatmentTaskRequest args){
    try {
      return new AddNewTreatmentTaskResponse { @return = _Repo.AddNewTreatmentTask(args.treatmentTask)};  
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new AddNewTreatmentTaskResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given TreatmentTask addressed by the primary identifier fields within the given TreatmentTask. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-treatmenttask")]
  [HttpPost("update"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateTreatmentTask), Description = nameof(UpdateTreatmentTask))]
  public UpdateTreatmentTaskResponse UpdateTreatmentTask([FromBody][SwaggerRequestBody(Required=true)] UpdateTreatmentTaskRequest args){
    try {
      return new UpdateTreatmentTaskResponse { @return = _Repo.UpdateTreatmentTask(args.treatmentTask)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateTreatmentTaskResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given TreatmentTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-treatmenttask")]
  [HttpPost("updateByTreatmentName"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateTreatmentTaskByTreatmentName), Description = nameof(UpdateTreatmentTaskByTreatmentName))]
  public UpdateTreatmentTaskByTreatmentNameResponse UpdateTreatmentTaskByTreatmentName([FromBody][SwaggerRequestBody(Required=true)] UpdateTreatmentTaskByTreatmentNameRequest args){
    try {
      return new UpdateTreatmentTaskByTreatmentNameResponse { @return = _Repo.UpdateTreatmentTaskByTreatmentName(args.treatmentName, args.treatmentTask)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateTreatmentTaskByTreatmentNameResponse { @return = false};
    }
  }

  /// <summary> Deletes a specific TreatmentTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("delete-treatmenttask")]
  [HttpPost("deleteByTreatmentName"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(DeleteTreatmentTaskByTreatmentName), Description = nameof(DeleteTreatmentTaskByTreatmentName))]
  public DeleteTreatmentTaskByTreatmentNameResponse DeleteTreatmentTaskByTreatmentName([FromBody][SwaggerRequestBody(Required=true)] DeleteTreatmentTaskByTreatmentNameRequest args){
    try {
      return new DeleteTreatmentTaskByTreatmentNameResponse { @return = _Repo.DeleteTreatmentTaskByTreatmentName(args.treatmentName)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new DeleteTreatmentTaskByTreatmentNameResponse { @return = false};
    }
  }

}

[ApiController]
[Route("inducedVisitProcedures")]
public partial class InducedVisitProceduresController : ControllerBase {

  public const String SchemaVersion = "1.3.0";

  private readonly ILogger<InducedVisitProceduresController> _logger;
  private readonly MedicalResearch.Workflow.Persistence.IInducedVisitProcedureRepository _Repo;

  public InducedVisitProceduresController(ILogger<InducedVisitProceduresController> logger) {
    _logger = logger;
    _Repo = new MedicalResearch.Workflow.Persistence.EF.InducedVisitProcedureStore();
  }

  /// <summary> Loads a specific InducedVisitProcedure addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-inducedvisitprocedure")]
  [HttpPost("getById"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetInducedVisitProcedureById), Description = nameof(GetInducedVisitProcedureById))]
  public GetInducedVisitProcedureByIdResponse GetInducedVisitProcedureById([FromBody][SwaggerRequestBody(Required=true)] GetInducedVisitProcedureByIdRequest args){
    try {
      return new GetInducedVisitProcedureByIdResponse { @return = _Repo.GetInducedVisitProcedureById(args.id)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetInducedVisitProcedureByIdResponse { @return = null};
    }
  }

  /// <summary> Loads InducedVisitProcedures. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-inducedvisitprocedure")]
  [HttpPost("getAll"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetInducedVisitProcedures), Description = nameof(GetInducedVisitProcedures))]
  public GetInducedVisitProceduresResponse GetInducedVisitProcedures([FromBody][SwaggerRequestBody(Required=true)] GetInducedVisitProceduresRequest args){
    try {
      return new GetInducedVisitProceduresResponse { @return = _Repo.GetInducedVisitProcedures(args.page, args.pageSize) }; 
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetInducedVisitProceduresResponse { @return = null};
    }
  }

  /// <summary> Loads InducedVisitProcedures where values matching to the given filterExpression</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-inducedvisitprocedure")]
  [HttpPost("search"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(SearchInducedVisitProcedures), Description = nameof(SearchInducedVisitProcedures))]
  public SearchInducedVisitProceduresResponse SearchInducedVisitProcedures([FromBody][SwaggerRequestBody(Required=true)] SearchInducedVisitProceduresRequest args){
    try {
      return new SearchInducedVisitProceduresResponse { @return = _Repo.SearchInducedVisitProcedures(args.filterExpression, args.sort, args.page, args.pageSize) };
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new SearchInducedVisitProceduresResponse { @return = null};
    }
  }

  /// <summary> Adds a new InducedVisitProcedure and returns success. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("add-inducedvisitprocedure")]
  [HttpPost("addNew"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(AddNewInducedVisitProcedure), Description = nameof(AddNewInducedVisitProcedure))]
  public AddNewInducedVisitProcedureResponse AddNewInducedVisitProcedure([FromBody][SwaggerRequestBody(Required=true)] AddNewInducedVisitProcedureRequest args){
    try {
      return new AddNewInducedVisitProcedureResponse { @return = _Repo.AddNewInducedVisitProcedure(args.inducedVisitProcedure)};  
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new AddNewInducedVisitProcedureResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedVisitProcedure addressed by the primary identifier fields within the given InducedVisitProcedure. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-inducedvisitprocedure")]
  [HttpPost("update"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateInducedVisitProcedure), Description = nameof(UpdateInducedVisitProcedure))]
  public UpdateInducedVisitProcedureResponse UpdateInducedVisitProcedure([FromBody][SwaggerRequestBody(Required=true)] UpdateInducedVisitProcedureRequest args){
    try {
      return new UpdateInducedVisitProcedureResponse { @return = _Repo.UpdateInducedVisitProcedure(args.inducedVisitProcedure)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateInducedVisitProcedureResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedVisitProcedure addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-inducedvisitprocedure")]
  [HttpPost("updateById"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateInducedVisitProcedureById), Description = nameof(UpdateInducedVisitProcedureById))]
  public UpdateInducedVisitProcedureByIdResponse UpdateInducedVisitProcedureById([FromBody][SwaggerRequestBody(Required=true)] UpdateInducedVisitProcedureByIdRequest args){
    try {
      return new UpdateInducedVisitProcedureByIdResponse { @return = _Repo.UpdateInducedVisitProcedureById(args.id, args.inducedVisitProcedure)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateInducedVisitProcedureByIdResponse { @return = false};
    }
  }

  /// <summary> Deletes a specific InducedVisitProcedure addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("delete-inducedvisitprocedure")]
  [HttpPost("deleteById"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(DeleteInducedVisitProcedureById), Description = nameof(DeleteInducedVisitProcedureById))]
  public DeleteInducedVisitProcedureByIdResponse DeleteInducedVisitProcedureById([FromBody][SwaggerRequestBody(Required=true)] DeleteInducedVisitProcedureByIdRequest args){
    try {
      return new DeleteInducedVisitProcedureByIdResponse { @return = _Repo.DeleteInducedVisitProcedureById(args.id)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new DeleteInducedVisitProcedureByIdResponse { @return = false};
    }
  }

}

[ApiController]
[Route("visitProdecureDefinitions")]
public partial class VisitProdecureDefinitionsController : ControllerBase {

  public const String SchemaVersion = "1.3.0";

  private readonly ILogger<VisitProdecureDefinitionsController> _logger;
  private readonly MedicalResearch.Workflow.Persistence.IVisitProdecureDefinitionRepository _Repo;

  public VisitProdecureDefinitionsController(ILogger<VisitProdecureDefinitionsController> logger) {
    _logger = logger;
    _Repo = new MedicalResearch.Workflow.Persistence.EF.VisitProdecureDefinitionStore();
  }

  /// <summary> Loads a specific VisitProdecureDefinition addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-visitprodecuredefinition")]
  [HttpPost("getByVisitProdecureName"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetVisitProdecureDefinitionByVisitProdecureName), Description = nameof(GetVisitProdecureDefinitionByVisitProdecureName))]
  public GetVisitProdecureDefinitionByVisitProdecureNameResponse GetVisitProdecureDefinitionByVisitProdecureName([FromBody][SwaggerRequestBody(Required=true)] GetVisitProdecureDefinitionByVisitProdecureNameRequest args){
    try {
      return new GetVisitProdecureDefinitionByVisitProdecureNameResponse { @return = _Repo.GetVisitProdecureDefinitionByVisitProdecureName(args.visitProdecureName)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetVisitProdecureDefinitionByVisitProdecureNameResponse { @return = null};
    }
  }

  /// <summary> Loads VisitProdecureDefinitions. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-visitprodecuredefinition")]
  [HttpPost("getAll"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetVisitProdecureDefinitions), Description = nameof(GetVisitProdecureDefinitions))]
  public GetVisitProdecureDefinitionsResponse GetVisitProdecureDefinitions([FromBody][SwaggerRequestBody(Required=true)] GetVisitProdecureDefinitionsRequest args){
    try {
      return new GetVisitProdecureDefinitionsResponse { @return = _Repo.GetVisitProdecureDefinitions(args.page, args.pageSize) }; 
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetVisitProdecureDefinitionsResponse { @return = null};
    }
  }

  /// <summary> Loads VisitProdecureDefinitions where values matching to the given filterExpression</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-visitprodecuredefinition")]
  [HttpPost("search"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(SearchVisitProdecureDefinitions), Description = nameof(SearchVisitProdecureDefinitions))]
  public SearchVisitProdecureDefinitionsResponse SearchVisitProdecureDefinitions([FromBody][SwaggerRequestBody(Required=true)] SearchVisitProdecureDefinitionsRequest args){
    try {
      return new SearchVisitProdecureDefinitionsResponse { @return = _Repo.SearchVisitProdecureDefinitions(args.filterExpression, args.sort, args.page, args.pageSize) };
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new SearchVisitProdecureDefinitionsResponse { @return = null};
    }
  }

  /// <summary> Adds a new VisitProdecureDefinition and returns success. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("add-visitprodecuredefinition")]
  [HttpPost("addNew"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(AddNewVisitProdecureDefinition), Description = nameof(AddNewVisitProdecureDefinition))]
  public AddNewVisitProdecureDefinitionResponse AddNewVisitProdecureDefinition([FromBody][SwaggerRequestBody(Required=true)] AddNewVisitProdecureDefinitionRequest args){
    try {
      return new AddNewVisitProdecureDefinitionResponse { @return = _Repo.AddNewVisitProdecureDefinition(args.visitProdecureDefinition)};  
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new AddNewVisitProdecureDefinitionResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given VisitProdecureDefinition addressed by the primary identifier fields within the given VisitProdecureDefinition. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-visitprodecuredefinition")]
  [HttpPost("update"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateVisitProdecureDefinition), Description = nameof(UpdateVisitProdecureDefinition))]
  public UpdateVisitProdecureDefinitionResponse UpdateVisitProdecureDefinition([FromBody][SwaggerRequestBody(Required=true)] UpdateVisitProdecureDefinitionRequest args){
    try {
      return new UpdateVisitProdecureDefinitionResponse { @return = _Repo.UpdateVisitProdecureDefinition(args.visitProdecureDefinition)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateVisitProdecureDefinitionResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given VisitProdecureDefinition addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-visitprodecuredefinition")]
  [HttpPost("updateByVisitProdecureName"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateVisitProdecureDefinitionByVisitProdecureName), Description = nameof(UpdateVisitProdecureDefinitionByVisitProdecureName))]
  public UpdateVisitProdecureDefinitionByVisitProdecureNameResponse UpdateVisitProdecureDefinitionByVisitProdecureName([FromBody][SwaggerRequestBody(Required=true)] UpdateVisitProdecureDefinitionByVisitProdecureNameRequest args){
    try {
      return new UpdateVisitProdecureDefinitionByVisitProdecureNameResponse { @return = _Repo.UpdateVisitProdecureDefinitionByVisitProdecureName(args.visitProdecureName, args.visitProdecureDefinition)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateVisitProdecureDefinitionByVisitProdecureNameResponse { @return = false};
    }
  }

  /// <summary> Deletes a specific VisitProdecureDefinition addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("delete-visitprodecuredefinition")]
  [HttpPost("deleteByVisitProdecureName"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(DeleteVisitProdecureDefinitionByVisitProdecureName), Description = nameof(DeleteVisitProdecureDefinitionByVisitProdecureName))]
  public DeleteVisitProdecureDefinitionByVisitProdecureNameResponse DeleteVisitProdecureDefinitionByVisitProdecureName([FromBody][SwaggerRequestBody(Required=true)] DeleteVisitProdecureDefinitionByVisitProdecureNameRequest args){
    try {
      return new DeleteVisitProdecureDefinitionByVisitProdecureNameResponse { @return = _Repo.DeleteVisitProdecureDefinitionByVisitProdecureName(args.visitProdecureName)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new DeleteVisitProdecureDefinitionByVisitProdecureNameResponse { @return = false};
    }
  }

}

[ApiController]
[Route("procedureCycleDefinitions")]
public partial class ProcedureCycleDefinitionsController : ControllerBase {

  public const String SchemaVersion = "1.3.0";

  private readonly ILogger<ProcedureCycleDefinitionsController> _logger;
  private readonly MedicalResearch.Workflow.Persistence.IProcedureCycleDefinitionRepository _Repo;

  public ProcedureCycleDefinitionsController(ILogger<ProcedureCycleDefinitionsController> logger) {
    _logger = logger;
    _Repo = new MedicalResearch.Workflow.Persistence.EF.ProcedureCycleDefinitionStore();
  }

  /// <summary> Loads a specific ProcedureCycleDefinition addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-procedurecycledefinition")]
  [HttpPost("getByProcedureScheduleId"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetProcedureCycleDefinitionByProcedureScheduleId), Description = nameof(GetProcedureCycleDefinitionByProcedureScheduleId))]
  public GetProcedureCycleDefinitionByProcedureScheduleIdResponse GetProcedureCycleDefinitionByProcedureScheduleId([FromBody][SwaggerRequestBody(Required=true)] GetProcedureCycleDefinitionByProcedureScheduleIdRequest args){
    try {
      return new GetProcedureCycleDefinitionByProcedureScheduleIdResponse { @return = _Repo.GetProcedureCycleDefinitionByProcedureScheduleId(args.procedureScheduleId)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetProcedureCycleDefinitionByProcedureScheduleIdResponse { @return = null};
    }
  }

  /// <summary> Loads ProcedureCycleDefinitions. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-procedurecycledefinition")]
  [HttpPost("getAll"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetProcedureCycleDefinitions), Description = nameof(GetProcedureCycleDefinitions))]
  public GetProcedureCycleDefinitionsResponse GetProcedureCycleDefinitions([FromBody][SwaggerRequestBody(Required=true)] GetProcedureCycleDefinitionsRequest args){
    try {
      return new GetProcedureCycleDefinitionsResponse { @return = _Repo.GetProcedureCycleDefinitions(args.page, args.pageSize) }; 
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetProcedureCycleDefinitionsResponse { @return = null};
    }
  }

  /// <summary> Loads ProcedureCycleDefinitions where values matching to the given filterExpression</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-procedurecycledefinition")]
  [HttpPost("search"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(SearchProcedureCycleDefinitions), Description = nameof(SearchProcedureCycleDefinitions))]
  public SearchProcedureCycleDefinitionsResponse SearchProcedureCycleDefinitions([FromBody][SwaggerRequestBody(Required=true)] SearchProcedureCycleDefinitionsRequest args){
    try {
      return new SearchProcedureCycleDefinitionsResponse { @return = _Repo.SearchProcedureCycleDefinitions(args.filterExpression, args.sort, args.page, args.pageSize) };
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new SearchProcedureCycleDefinitionsResponse { @return = null};
    }
  }

  /// <summary> Adds a new ProcedureCycleDefinition and returns success. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("add-procedurecycledefinition")]
  [HttpPost("addNew"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(AddNewProcedureCycleDefinition), Description = nameof(AddNewProcedureCycleDefinition))]
  public AddNewProcedureCycleDefinitionResponse AddNewProcedureCycleDefinition([FromBody][SwaggerRequestBody(Required=true)] AddNewProcedureCycleDefinitionRequest args){
    try {
      return new AddNewProcedureCycleDefinitionResponse { @return = _Repo.AddNewProcedureCycleDefinition(args.procedureCycleDefinition)};  
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new AddNewProcedureCycleDefinitionResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ProcedureCycleDefinition addressed by the primary identifier fields within the given ProcedureCycleDefinition. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-procedurecycledefinition")]
  [HttpPost("update"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateProcedureCycleDefinition), Description = nameof(UpdateProcedureCycleDefinition))]
  public UpdateProcedureCycleDefinitionResponse UpdateProcedureCycleDefinition([FromBody][SwaggerRequestBody(Required=true)] UpdateProcedureCycleDefinitionRequest args){
    try {
      return new UpdateProcedureCycleDefinitionResponse { @return = _Repo.UpdateProcedureCycleDefinition(args.procedureCycleDefinition)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateProcedureCycleDefinitionResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ProcedureCycleDefinition addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-procedurecycledefinition")]
  [HttpPost("updateByProcedureScheduleId"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateProcedureCycleDefinitionByProcedureScheduleId), Description = nameof(UpdateProcedureCycleDefinitionByProcedureScheduleId))]
  public UpdateProcedureCycleDefinitionByProcedureScheduleIdResponse UpdateProcedureCycleDefinitionByProcedureScheduleId([FromBody][SwaggerRequestBody(Required=true)] UpdateProcedureCycleDefinitionByProcedureScheduleIdRequest args){
    try {
      return new UpdateProcedureCycleDefinitionByProcedureScheduleIdResponse { @return = _Repo.UpdateProcedureCycleDefinitionByProcedureScheduleId(args.procedureScheduleId, args.procedureCycleDefinition)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateProcedureCycleDefinitionByProcedureScheduleIdResponse { @return = false};
    }
  }

  /// <summary> Deletes a specific ProcedureCycleDefinition addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("delete-procedurecycledefinition")]
  [HttpPost("deleteByProcedureScheduleId"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(DeleteProcedureCycleDefinitionByProcedureScheduleId), Description = nameof(DeleteProcedureCycleDefinitionByProcedureScheduleId))]
  public DeleteProcedureCycleDefinitionByProcedureScheduleIdResponse DeleteProcedureCycleDefinitionByProcedureScheduleId([FromBody][SwaggerRequestBody(Required=true)] DeleteProcedureCycleDefinitionByProcedureScheduleIdRequest args){
    try {
      return new DeleteProcedureCycleDefinitionByProcedureScheduleIdResponse { @return = _Repo.DeleteProcedureCycleDefinitionByProcedureScheduleId(args.procedureScheduleId)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new DeleteProcedureCycleDefinitionByProcedureScheduleIdResponse { @return = false};
    }
  }

}

[ApiController]
[Route("studyEvents")]
public partial class StudyEventsController : ControllerBase {

  public const String SchemaVersion = "1.3.0";

  private readonly ILogger<StudyEventsController> _logger;
  private readonly MedicalResearch.Workflow.Persistence.IStudyEventRepository _Repo;

  public StudyEventsController(ILogger<StudyEventsController> logger) {
    _logger = logger;
    _Repo = new MedicalResearch.Workflow.Persistence.EF.StudyEventStore();
  }

  /// <summary> Loads a specific StudyEvent addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-studyevent")]
  [HttpPost("getByStudyEventName"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetStudyEventByStudyEventName), Description = nameof(GetStudyEventByStudyEventName))]
  public GetStudyEventByStudyEventNameResponse GetStudyEventByStudyEventName([FromBody][SwaggerRequestBody(Required=true)] GetStudyEventByStudyEventNameRequest args){
    try {
      return new GetStudyEventByStudyEventNameResponse { @return = _Repo.GetStudyEventByStudyEventName(args.studyEventName)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetStudyEventByStudyEventNameResponse { @return = null};
    }
  }

  /// <summary> Loads StudyEvents. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-studyevent")]
  [HttpPost("getAll"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetStudyEvents), Description = nameof(GetStudyEvents))]
  public GetStudyEventsResponse GetStudyEvents([FromBody][SwaggerRequestBody(Required=true)] GetStudyEventsRequest args){
    try {
      return new GetStudyEventsResponse { @return = _Repo.GetStudyEvents(args.page, args.pageSize) }; 
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetStudyEventsResponse { @return = null};
    }
  }

  /// <summary> Loads StudyEvents where values matching to the given filterExpression</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-studyevent")]
  [HttpPost("search"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(SearchStudyEvents), Description = nameof(SearchStudyEvents))]
  public SearchStudyEventsResponse SearchStudyEvents([FromBody][SwaggerRequestBody(Required=true)] SearchStudyEventsRequest args){
    try {
      return new SearchStudyEventsResponse { @return = _Repo.SearchStudyEvents(args.filterExpression, args.sort, args.page, args.pageSize) };
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new SearchStudyEventsResponse { @return = null};
    }
  }

  /// <summary> Adds a new StudyEvent and returns success. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("add-studyevent")]
  [HttpPost("addNew"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(AddNewStudyEvent), Description = nameof(AddNewStudyEvent))]
  public AddNewStudyEventResponse AddNewStudyEvent([FromBody][SwaggerRequestBody(Required=true)] AddNewStudyEventRequest args){
    try {
      return new AddNewStudyEventResponse { @return = _Repo.AddNewStudyEvent(args.studyEvent)};  
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new AddNewStudyEventResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyEvent addressed by the primary identifier fields within the given StudyEvent. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-studyevent")]
  [HttpPost("update"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateStudyEvent), Description = nameof(UpdateStudyEvent))]
  public UpdateStudyEventResponse UpdateStudyEvent([FromBody][SwaggerRequestBody(Required=true)] UpdateStudyEventRequest args){
    try {
      return new UpdateStudyEventResponse { @return = _Repo.UpdateStudyEvent(args.studyEvent)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateStudyEventResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyEvent addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-studyevent")]
  [HttpPost("updateByStudyEventName"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateStudyEventByStudyEventName), Description = nameof(UpdateStudyEventByStudyEventName))]
  public UpdateStudyEventByStudyEventNameResponse UpdateStudyEventByStudyEventName([FromBody][SwaggerRequestBody(Required=true)] UpdateStudyEventByStudyEventNameRequest args){
    try {
      return new UpdateStudyEventByStudyEventNameResponse { @return = _Repo.UpdateStudyEventByStudyEventName(args.studyEventName, args.studyEvent)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateStudyEventByStudyEventNameResponse { @return = false};
    }
  }

  /// <summary> Deletes a specific StudyEvent addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("delete-studyevent")]
  [HttpPost("deleteByStudyEventName"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(DeleteStudyEventByStudyEventName), Description = nameof(DeleteStudyEventByStudyEventName))]
  public DeleteStudyEventByStudyEventNameResponse DeleteStudyEventByStudyEventName([FromBody][SwaggerRequestBody(Required=true)] DeleteStudyEventByStudyEventNameRequest args){
    try {
      return new DeleteStudyEventByStudyEventNameResponse { @return = _Repo.DeleteStudyEventByStudyEventName(args.studyEventName)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new DeleteStudyEventByStudyEventNameResponse { @return = false};
    }
  }

}

[ApiController]
[Route("taskCycleDefinitions")]
public partial class TaskCycleDefinitionsController : ControllerBase {

  public const String SchemaVersion = "1.3.0";

  private readonly ILogger<TaskCycleDefinitionsController> _logger;
  private readonly MedicalResearch.Workflow.Persistence.ITaskCycleDefinitionRepository _Repo;

  public TaskCycleDefinitionsController(ILogger<TaskCycleDefinitionsController> logger) {
    _logger = logger;
    _Repo = new MedicalResearch.Workflow.Persistence.EF.TaskCycleDefinitionStore();
  }

  /// <summary> Loads a specific TaskCycleDefinition addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-taskcycledefinition")]
  [HttpPost("getByTaskScheduleId"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetTaskCycleDefinitionByTaskScheduleId), Description = nameof(GetTaskCycleDefinitionByTaskScheduleId))]
  public GetTaskCycleDefinitionByTaskScheduleIdResponse GetTaskCycleDefinitionByTaskScheduleId([FromBody][SwaggerRequestBody(Required=true)] GetTaskCycleDefinitionByTaskScheduleIdRequest args){
    try {
      return new GetTaskCycleDefinitionByTaskScheduleIdResponse { @return = _Repo.GetTaskCycleDefinitionByTaskScheduleId(args.taskScheduleId)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetTaskCycleDefinitionByTaskScheduleIdResponse { @return = null};
    }
  }

  /// <summary> Loads TaskCycleDefinitions. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-taskcycledefinition")]
  [HttpPost("getAll"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(GetTaskCycleDefinitions), Description = nameof(GetTaskCycleDefinitions))]
  public GetTaskCycleDefinitionsResponse GetTaskCycleDefinitions([FromBody][SwaggerRequestBody(Required=true)] GetTaskCycleDefinitionsRequest args){
    try {
      return new GetTaskCycleDefinitionsResponse { @return = _Repo.GetTaskCycleDefinitions(args.page, args.pageSize) }; 
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new GetTaskCycleDefinitionsResponse { @return = null};
    }
  }

  /// <summary> Loads TaskCycleDefinitions where values matching to the given filterExpression</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("read-taskcycledefinition")]
  [HttpPost("search"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(SearchTaskCycleDefinitions), Description = nameof(SearchTaskCycleDefinitions))]
  public SearchTaskCycleDefinitionsResponse SearchTaskCycleDefinitions([FromBody][SwaggerRequestBody(Required=true)] SearchTaskCycleDefinitionsRequest args){
    try {
      return new SearchTaskCycleDefinitionsResponse { @return = _Repo.SearchTaskCycleDefinitions(args.filterExpression, args.sort, args.page, args.pageSize) };
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new SearchTaskCycleDefinitionsResponse { @return = null};
    }
  }

  /// <summary> Adds a new TaskCycleDefinition and returns success. </summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("add-taskcycledefinition")]
  [HttpPost("addNew"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(AddNewTaskCycleDefinition), Description = nameof(AddNewTaskCycleDefinition))]
  public AddNewTaskCycleDefinitionResponse AddNewTaskCycleDefinition([FromBody][SwaggerRequestBody(Required=true)] AddNewTaskCycleDefinitionRequest args){
    try {
      return new AddNewTaskCycleDefinitionResponse { @return = _Repo.AddNewTaskCycleDefinition(args.taskCycleDefinition)};  
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new AddNewTaskCycleDefinitionResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given TaskCycleDefinition addressed by the primary identifier fields within the given TaskCycleDefinition. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-taskcycledefinition")]
  [HttpPost("update"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateTaskCycleDefinition), Description = nameof(UpdateTaskCycleDefinition))]
  public UpdateTaskCycleDefinitionResponse UpdateTaskCycleDefinition([FromBody][SwaggerRequestBody(Required=true)] UpdateTaskCycleDefinitionRequest args){
    try {
      return new UpdateTaskCycleDefinitionResponse { @return = _Repo.UpdateTaskCycleDefinition(args.taskCycleDefinition)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateTaskCycleDefinitionResponse { @return = false};
    }
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given TaskCycleDefinition addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("update-taskcycledefinition")]
  [HttpPost("updateByTaskScheduleId"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(UpdateTaskCycleDefinitionByTaskScheduleId), Description = nameof(UpdateTaskCycleDefinitionByTaskScheduleId))]
  public UpdateTaskCycleDefinitionByTaskScheduleIdResponse UpdateTaskCycleDefinitionByTaskScheduleId([FromBody][SwaggerRequestBody(Required=true)] UpdateTaskCycleDefinitionByTaskScheduleIdRequest args){
    try {
      return new UpdateTaskCycleDefinitionByTaskScheduleIdResponse { @return = _Repo.UpdateTaskCycleDefinitionByTaskScheduleId(args.taskScheduleId, args.taskCycleDefinition)};   
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new UpdateTaskCycleDefinitionByTaskScheduleIdResponse { @return = false};
    }
  }

  /// <summary> Deletes a specific TaskCycleDefinition addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="args"> request capsle containing the method arguments </param>
  [RequireBaererAuth("delete-taskcycledefinition")]
  [HttpPost("deleteByTaskScheduleId"), Produces("application/json")]
  [SwaggerOperation(OperationId = nameof(DeleteTaskCycleDefinitionByTaskScheduleId), Description = nameof(DeleteTaskCycleDefinitionByTaskScheduleId))]
  public DeleteTaskCycleDefinitionByTaskScheduleIdResponse DeleteTaskCycleDefinitionByTaskScheduleId([FromBody][SwaggerRequestBody(Required=true)] DeleteTaskCycleDefinitionByTaskScheduleIdRequest args){
    try {
      return new DeleteTaskCycleDefinitionByTaskScheduleIdResponse { @return = _Repo.DeleteTaskCycleDefinitionByTaskScheduleId(args.taskScheduleId)};
    }
    catch (Exception ex) {
      _logger.LogCritical(ex, ex.Message);
      return new DeleteTaskCycleDefinitionByTaskScheduleIdResponse { @return = false};
    }
  }

}

}
