using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Security;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MedicalResearch.VisitData.WebAPI {
  
  [ApiController]
  [Route("dataRecordings")]
  public partial class DataRecordingsController : ControllerBase {
    
    private readonly ILogger<DataRecordingsController> _Logger;
    private readonly IDataRecordings _DataRecordings;
    
    public DataRecordingsController(ILogger<DataRecordingsController> logger, IDataRecordings dataRecordings) {
      _Logger = logger;
      _DataRecordings = dataRecordings;
    }
    
    /// <summary> Loads a specific DataRecording addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("GetDataRecordingByTaskGuid")]
    [HttpPost("getDataRecordingByTaskGuid"), Produces("application/json")]
    public GetDataRecordingByTaskGuidResponse GetDataRecordingByTaskGuid([FromBody][SwaggerRequestBody(Required = true)] GetDataRecordingByTaskGuidRequest args) {
      try {
        var response = new GetDataRecordingByTaskGuidResponse();
        response.@return = _DataRecordings.GetDataRecordingByTaskGuid(
        args.taskGuid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetDataRecordingByTaskGuidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads DataRecordings. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("GetDataRecordings")]
    [HttpPost("getDataRecordings"), Produces("application/json")]
    public GetDataRecordingsResponse GetDataRecordings([FromBody][SwaggerRequestBody(Required = true)] GetDataRecordingsRequest args) {
      try {
        var response = new GetDataRecordingsResponse();
        response.@return = _DataRecordings.GetDataRecordings(
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetDataRecordingsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads DataRecordings where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("SearchDataRecordings")]
    [HttpPost("searchDataRecordings"), Produces("application/json")]
    public SearchDataRecordingsResponse SearchDataRecordings([FromBody][SwaggerRequestBody(Required = true)] SearchDataRecordingsRequest args) {
      try {
        var response = new SearchDataRecordingsResponse();
        response.@return = _DataRecordings.SearchDataRecordings(
        args.filterExpression,
        args.sortingExpression,
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchDataRecordingsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new DataRecording and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("AddNewDataRecording")]
    [HttpPost("addNewDataRecording"), Produces("application/json")]
    public AddNewDataRecordingResponse AddNewDataRecording([FromBody][SwaggerRequestBody(Required = true)] AddNewDataRecordingRequest args) {
      try {
        var response = new AddNewDataRecordingResponse();
        response.@return = _DataRecordings.AddNewDataRecording(
        args.dataRecording
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewDataRecordingResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DataRecording addressed by the primary identifier fields within the given DataRecording. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("UpdateDataRecording")]
    [HttpPost("updateDataRecording"), Produces("application/json")]
    public UpdateDataRecordingResponse UpdateDataRecording([FromBody][SwaggerRequestBody(Required = true)] UpdateDataRecordingRequest args) {
      try {
        var response = new UpdateDataRecordingResponse();
        response.@return = _DataRecordings.UpdateDataRecording(
        args.dataRecording
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateDataRecordingResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DataRecording addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("UpdateDataRecordingByTaskGuid")]
    [HttpPost("updateDataRecordingByTaskGuid"), Produces("application/json")]
    public UpdateDataRecordingByTaskGuidResponse UpdateDataRecordingByTaskGuid([FromBody][SwaggerRequestBody(Required = true)] UpdateDataRecordingByTaskGuidRequest args) {
      try {
        var response = new UpdateDataRecordingByTaskGuidResponse();
        response.@return = _DataRecordings.UpdateDataRecordingByTaskGuid(
        args.taskGuid,
        args.dataRecording
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateDataRecordingByTaskGuidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific DataRecording addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("DeleteDataRecordingByTaskGuid")]
    [HttpPost("deleteDataRecordingByTaskGuid"), Produces("application/json")]
    public DeleteDataRecordingByTaskGuidResponse DeleteDataRecordingByTaskGuid([FromBody][SwaggerRequestBody(Required = true)] DeleteDataRecordingByTaskGuidRequest args) {
      try {
        var response = new DeleteDataRecordingByTaskGuidResponse();
        response.@return = _DataRecordings.DeleteDataRecordingByTaskGuid(
        args.taskGuid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteDataRecordingByTaskGuidResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [Route("visits")]
  public partial class VisitsController : ControllerBase {
    
    private readonly ILogger<VisitsController> _Logger;
    private readonly IVisits _Visits;
    
    public VisitsController(ILogger<VisitsController> logger, IVisits visits) {
      _Logger = logger;
      _Visits = visits;
    }
    
    /// <summary> Loads a specific Visit addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("GetVisitByVisitGuid")]
    [HttpPost("getVisitByVisitGuid"), Produces("application/json")]
    public GetVisitByVisitGuidResponse GetVisitByVisitGuid([FromBody][SwaggerRequestBody(Required = true)] GetVisitByVisitGuidRequest args) {
      try {
        var response = new GetVisitByVisitGuidResponse();
        response.@return = _Visits.GetVisitByVisitGuid(
        args.visitGuid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetVisitByVisitGuidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads Visits. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("GetVisits")]
    [HttpPost("getVisits"), Produces("application/json")]
    public GetVisitsResponse GetVisits([FromBody][SwaggerRequestBody(Required = true)] GetVisitsRequest args) {
      try {
        var response = new GetVisitsResponse();
        response.@return = _Visits.GetVisits(
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetVisitsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads Visits where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("SearchVisits")]
    [HttpPost("searchVisits"), Produces("application/json")]
    public SearchVisitsResponse SearchVisits([FromBody][SwaggerRequestBody(Required = true)] SearchVisitsRequest args) {
      try {
        var response = new SearchVisitsResponse();
        response.@return = _Visits.SearchVisits(
        args.filterExpression,
        args.sortingExpression,
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchVisitsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new Visit and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("AddNewVisit")]
    [HttpPost("addNewVisit"), Produces("application/json")]
    public AddNewVisitResponse AddNewVisit([FromBody][SwaggerRequestBody(Required = true)] AddNewVisitRequest args) {
      try {
        var response = new AddNewVisitResponse();
        response.@return = _Visits.AddNewVisit(
        args.visit
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewVisitResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Visit addressed by the primary identifier fields within the given Visit. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("UpdateVisit")]
    [HttpPost("updateVisit"), Produces("application/json")]
    public UpdateVisitResponse UpdateVisit([FromBody][SwaggerRequestBody(Required = true)] UpdateVisitRequest args) {
      try {
        var response = new UpdateVisitResponse();
        response.@return = _Visits.UpdateVisit(
        args.visit
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateVisitResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Visit addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("UpdateVisitByVisitGuid")]
    [HttpPost("updateVisitByVisitGuid"), Produces("application/json")]
    public UpdateVisitByVisitGuidResponse UpdateVisitByVisitGuid([FromBody][SwaggerRequestBody(Required = true)] UpdateVisitByVisitGuidRequest args) {
      try {
        var response = new UpdateVisitByVisitGuidResponse();
        response.@return = _Visits.UpdateVisitByVisitGuid(
        args.visitGuid,
        args.visit
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateVisitByVisitGuidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific Visit addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("DeleteVisitByVisitGuid")]
    [HttpPost("deleteVisitByVisitGuid"), Produces("application/json")]
    public DeleteVisitByVisitGuidResponse DeleteVisitByVisitGuid([FromBody][SwaggerRequestBody(Required = true)] DeleteVisitByVisitGuidRequest args) {
      try {
        var response = new DeleteVisitByVisitGuidResponse();
        response.@return = _Visits.DeleteVisitByVisitGuid(
        args.visitGuid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteVisitByVisitGuidResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [Route("drugApplyments")]
  public partial class DrugApplymentsController : ControllerBase {
    
    private readonly ILogger<DrugApplymentsController> _Logger;
    private readonly IDrugApplyments _DrugApplyments;
    
    public DrugApplymentsController(ILogger<DrugApplymentsController> logger, IDrugApplyments drugApplyments) {
      _Logger = logger;
      _DrugApplyments = drugApplyments;
    }
    
    /// <summary> Loads a specific DrugApplyment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("GetDrugApplymentByTaskGuid")]
    [HttpPost("getDrugApplymentByTaskGuid"), Produces("application/json")]
    public GetDrugApplymentByTaskGuidResponse GetDrugApplymentByTaskGuid([FromBody][SwaggerRequestBody(Required = true)] GetDrugApplymentByTaskGuidRequest args) {
      try {
        var response = new GetDrugApplymentByTaskGuidResponse();
        response.@return = _DrugApplyments.GetDrugApplymentByTaskGuid(
        args.taskGuid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetDrugApplymentByTaskGuidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads DrugApplyments. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("GetDrugApplyments")]
    [HttpPost("getDrugApplyments"), Produces("application/json")]
    public GetDrugApplymentsResponse GetDrugApplyments([FromBody][SwaggerRequestBody(Required = true)] GetDrugApplymentsRequest args) {
      try {
        var response = new GetDrugApplymentsResponse();
        response.@return = _DrugApplyments.GetDrugApplyments(
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetDrugApplymentsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads DrugApplyments where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("SearchDrugApplyments")]
    [HttpPost("searchDrugApplyments"), Produces("application/json")]
    public SearchDrugApplymentsResponse SearchDrugApplyments([FromBody][SwaggerRequestBody(Required = true)] SearchDrugApplymentsRequest args) {
      try {
        var response = new SearchDrugApplymentsResponse();
        response.@return = _DrugApplyments.SearchDrugApplyments(
        args.filterExpression,
        args.sortingExpression,
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchDrugApplymentsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new DrugApplyment and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("AddNewDrugApplyment")]
    [HttpPost("addNewDrugApplyment"), Produces("application/json")]
    public AddNewDrugApplymentResponse AddNewDrugApplyment([FromBody][SwaggerRequestBody(Required = true)] AddNewDrugApplymentRequest args) {
      try {
        var response = new AddNewDrugApplymentResponse();
        response.@return = _DrugApplyments.AddNewDrugApplyment(
        args.drugApplyment
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewDrugApplymentResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DrugApplyment addressed by the primary identifier fields within the given DrugApplyment. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("UpdateDrugApplyment")]
    [HttpPost("updateDrugApplyment"), Produces("application/json")]
    public UpdateDrugApplymentResponse UpdateDrugApplyment([FromBody][SwaggerRequestBody(Required = true)] UpdateDrugApplymentRequest args) {
      try {
        var response = new UpdateDrugApplymentResponse();
        response.@return = _DrugApplyments.UpdateDrugApplyment(
        args.drugApplyment
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateDrugApplymentResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DrugApplyment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("UpdateDrugApplymentByTaskGuid")]
    [HttpPost("updateDrugApplymentByTaskGuid"), Produces("application/json")]
    public UpdateDrugApplymentByTaskGuidResponse UpdateDrugApplymentByTaskGuid([FromBody][SwaggerRequestBody(Required = true)] UpdateDrugApplymentByTaskGuidRequest args) {
      try {
        var response = new UpdateDrugApplymentByTaskGuidResponse();
        response.@return = _DrugApplyments.UpdateDrugApplymentByTaskGuid(
        args.taskGuid,
        args.drugApplyment
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateDrugApplymentByTaskGuidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific DrugApplyment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("DeleteDrugApplymentByTaskGuid")]
    [HttpPost("deleteDrugApplymentByTaskGuid"), Produces("application/json")]
    public DeleteDrugApplymentByTaskGuidResponse DeleteDrugApplymentByTaskGuid([FromBody][SwaggerRequestBody(Required = true)] DeleteDrugApplymentByTaskGuidRequest args) {
      try {
        var response = new DeleteDrugApplymentByTaskGuidResponse();
        response.@return = _DrugApplyments.DeleteDrugApplymentByTaskGuid(
        args.taskGuid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteDrugApplymentByTaskGuidResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [Route("studyEvents")]
  public partial class StudyEventsController : ControllerBase {
    
    private readonly ILogger<StudyEventsController> _Logger;
    private readonly IStudyEvents _StudyEvents;
    
    public StudyEventsController(ILogger<StudyEventsController> logger, IStudyEvents studyEvents) {
      _Logger = logger;
      _StudyEvents = studyEvents;
    }
    
    /// <summary> Loads a specific StudyEvent addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("GetStudyEventByEventGuid")]
    [HttpPost("getStudyEventByEventGuid"), Produces("application/json")]
    public GetStudyEventByEventGuidResponse GetStudyEventByEventGuid([FromBody][SwaggerRequestBody(Required = true)] GetStudyEventByEventGuidRequest args) {
      try {
        var response = new GetStudyEventByEventGuidResponse();
        response.@return = _StudyEvents.GetStudyEventByEventGuid(
        args.eventGuid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetStudyEventByEventGuidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads StudyEvents. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("GetStudyEvents")]
    [HttpPost("getStudyEvents"), Produces("application/json")]
    public GetStudyEventsResponse GetStudyEvents([FromBody][SwaggerRequestBody(Required = true)] GetStudyEventsRequest args) {
      try {
        var response = new GetStudyEventsResponse();
        response.@return = _StudyEvents.GetStudyEvents(
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetStudyEventsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads StudyEvents where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("SearchStudyEvents")]
    [HttpPost("searchStudyEvents"), Produces("application/json")]
    public SearchStudyEventsResponse SearchStudyEvents([FromBody][SwaggerRequestBody(Required = true)] SearchStudyEventsRequest args) {
      try {
        var response = new SearchStudyEventsResponse();
        response.@return = _StudyEvents.SearchStudyEvents(
        args.filterExpression,
        args.sortingExpression,
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchStudyEventsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new StudyEvent and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("AddNewStudyEvent")]
    [HttpPost("addNewStudyEvent"), Produces("application/json")]
    public AddNewStudyEventResponse AddNewStudyEvent([FromBody][SwaggerRequestBody(Required = true)] AddNewStudyEventRequest args) {
      try {
        var response = new AddNewStudyEventResponse();
        response.@return = _StudyEvents.AddNewStudyEvent(
        args.studyEvent
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewStudyEventResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyEvent addressed by the primary identifier fields within the given StudyEvent. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("UpdateStudyEvent")]
    [HttpPost("updateStudyEvent"), Produces("application/json")]
    public UpdateStudyEventResponse UpdateStudyEvent([FromBody][SwaggerRequestBody(Required = true)] UpdateStudyEventRequest args) {
      try {
        var response = new UpdateStudyEventResponse();
        response.@return = _StudyEvents.UpdateStudyEvent(
        args.studyEvent
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateStudyEventResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyEvent addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("UpdateStudyEventByEventGuid")]
    [HttpPost("updateStudyEventByEventGuid"), Produces("application/json")]
    public UpdateStudyEventByEventGuidResponse UpdateStudyEventByEventGuid([FromBody][SwaggerRequestBody(Required = true)] UpdateStudyEventByEventGuidRequest args) {
      try {
        var response = new UpdateStudyEventByEventGuidResponse();
        response.@return = _StudyEvents.UpdateStudyEventByEventGuid(
        args.eventGuid,
        args.studyEvent
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateStudyEventByEventGuidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific StudyEvent addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("DeleteStudyEventByEventGuid")]
    [HttpPost("deleteStudyEventByEventGuid"), Produces("application/json")]
    public DeleteStudyEventByEventGuidResponse DeleteStudyEventByEventGuid([FromBody][SwaggerRequestBody(Required = true)] DeleteStudyEventByEventGuidRequest args) {
      try {
        var response = new DeleteStudyEventByEventGuidResponse();
        response.@return = _StudyEvents.DeleteStudyEventByEventGuid(
        args.eventGuid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteStudyEventByEventGuidResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [Route("studyExecutionScopes")]
  public partial class StudyExecutionScopesController : ControllerBase {
    
    private readonly ILogger<StudyExecutionScopesController> _Logger;
    private readonly IStudyExecutionScopes _StudyExecutionScopes;
    
    public StudyExecutionScopesController(ILogger<StudyExecutionScopesController> logger, IStudyExecutionScopes studyExecutionScopes) {
      _Logger = logger;
      _StudyExecutionScopes = studyExecutionScopes;
    }
    
    /// <summary> Loads a specific StudyExecutionScope addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("GetStudyExecutionScopeByStudyExecutionIdentifier")]
    [HttpPost("getStudyExecutionScopeByStudyExecutionIdentifier"), Produces("application/json")]
    public GetStudyExecutionScopeByStudyExecutionIdentifierResponse GetStudyExecutionScopeByStudyExecutionIdentifier([FromBody][SwaggerRequestBody(Required = true)] GetStudyExecutionScopeByStudyExecutionIdentifierRequest args) {
      try {
        var response = new GetStudyExecutionScopeByStudyExecutionIdentifierResponse();
        response.@return = _StudyExecutionScopes.GetStudyExecutionScopeByStudyExecutionIdentifier(
        args.studyExecutionIdentifier
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetStudyExecutionScopeByStudyExecutionIdentifierResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads StudyExecutionScopes. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("GetStudyExecutionScopes")]
    [HttpPost("getStudyExecutionScopes"), Produces("application/json")]
    public GetStudyExecutionScopesResponse GetStudyExecutionScopes([FromBody][SwaggerRequestBody(Required = true)] GetStudyExecutionScopesRequest args) {
      try {
        var response = new GetStudyExecutionScopesResponse();
        response.@return = _StudyExecutionScopes.GetStudyExecutionScopes(
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetStudyExecutionScopesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads StudyExecutionScopes where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("SearchStudyExecutionScopes")]
    [HttpPost("searchStudyExecutionScopes"), Produces("application/json")]
    public SearchStudyExecutionScopesResponse SearchStudyExecutionScopes([FromBody][SwaggerRequestBody(Required = true)] SearchStudyExecutionScopesRequest args) {
      try {
        var response = new SearchStudyExecutionScopesResponse();
        response.@return = _StudyExecutionScopes.SearchStudyExecutionScopes(
        args.filterExpression,
        args.sortingExpression,
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchStudyExecutionScopesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new StudyExecutionScope and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("AddNewStudyExecutionScope")]
    [HttpPost("addNewStudyExecutionScope"), Produces("application/json")]
    public AddNewStudyExecutionScopeResponse AddNewStudyExecutionScope([FromBody][SwaggerRequestBody(Required = true)] AddNewStudyExecutionScopeRequest args) {
      try {
        var response = new AddNewStudyExecutionScopeResponse();
        response.@return = _StudyExecutionScopes.AddNewStudyExecutionScope(
        args.studyExecutionScope
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewStudyExecutionScopeResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyExecutionScope addressed by the primary identifier fields within the given StudyExecutionScope. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("UpdateStudyExecutionScope")]
    [HttpPost("updateStudyExecutionScope"), Produces("application/json")]
    public UpdateStudyExecutionScopeResponse UpdateStudyExecutionScope([FromBody][SwaggerRequestBody(Required = true)] UpdateStudyExecutionScopeRequest args) {
      try {
        var response = new UpdateStudyExecutionScopeResponse();
        response.@return = _StudyExecutionScopes.UpdateStudyExecutionScope(
        args.studyExecutionScope
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateStudyExecutionScopeResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyExecutionScope addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("UpdateStudyExecutionScopeByStudyExecutionIdentifier")]
    [HttpPost("updateStudyExecutionScopeByStudyExecutionIdentifier"), Produces("application/json")]
    public UpdateStudyExecutionScopeByStudyExecutionIdentifierResponse UpdateStudyExecutionScopeByStudyExecutionIdentifier([FromBody][SwaggerRequestBody(Required = true)] UpdateStudyExecutionScopeByStudyExecutionIdentifierRequest args) {
      try {
        var response = new UpdateStudyExecutionScopeByStudyExecutionIdentifierResponse();
        response.@return = _StudyExecutionScopes.UpdateStudyExecutionScopeByStudyExecutionIdentifier(
        args.studyExecutionIdentifier,
        args.studyExecutionScope
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateStudyExecutionScopeByStudyExecutionIdentifierResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific StudyExecutionScope addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("DeleteStudyExecutionScopeByStudyExecutionIdentifier")]
    [HttpPost("deleteStudyExecutionScopeByStudyExecutionIdentifier"), Produces("application/json")]
    public DeleteStudyExecutionScopeByStudyExecutionIdentifierResponse DeleteStudyExecutionScopeByStudyExecutionIdentifier([FromBody][SwaggerRequestBody(Required = true)] DeleteStudyExecutionScopeByStudyExecutionIdentifierRequest args) {
      try {
        var response = new DeleteStudyExecutionScopeByStudyExecutionIdentifierResponse();
        response.@return = _StudyExecutionScopes.DeleteStudyExecutionScopeByStudyExecutionIdentifier(
        args.studyExecutionIdentifier
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteStudyExecutionScopeByStudyExecutionIdentifierResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [Route("treatments")]
  public partial class TreatmentsController : ControllerBase {
    
    private readonly ILogger<TreatmentsController> _Logger;
    private readonly ITreatments _Treatments;
    
    public TreatmentsController(ILogger<TreatmentsController> logger, ITreatments treatments) {
      _Logger = logger;
      _Treatments = treatments;
    }
    
    /// <summary> Loads a specific Treatment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("GetTreatmentByTaskGuid")]
    [HttpPost("getTreatmentByTaskGuid"), Produces("application/json")]
    public GetTreatmentByTaskGuidResponse GetTreatmentByTaskGuid([FromBody][SwaggerRequestBody(Required = true)] GetTreatmentByTaskGuidRequest args) {
      try {
        var response = new GetTreatmentByTaskGuidResponse();
        response.@return = _Treatments.GetTreatmentByTaskGuid(
        args.taskGuid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetTreatmentByTaskGuidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads Treatments. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("GetTreatments")]
    [HttpPost("getTreatments"), Produces("application/json")]
    public GetTreatmentsResponse GetTreatments([FromBody][SwaggerRequestBody(Required = true)] GetTreatmentsRequest args) {
      try {
        var response = new GetTreatmentsResponse();
        response.@return = _Treatments.GetTreatments(
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetTreatmentsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads Treatments where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("SearchTreatments")]
    [HttpPost("searchTreatments"), Produces("application/json")]
    public SearchTreatmentsResponse SearchTreatments([FromBody][SwaggerRequestBody(Required = true)] SearchTreatmentsRequest args) {
      try {
        var response = new SearchTreatmentsResponse();
        response.@return = _Treatments.SearchTreatments(
        args.filterExpression,
        args.sortingExpression,
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchTreatmentsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new Treatment and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("AddNewTreatment")]
    [HttpPost("addNewTreatment"), Produces("application/json")]
    public AddNewTreatmentResponse AddNewTreatment([FromBody][SwaggerRequestBody(Required = true)] AddNewTreatmentRequest args) {
      try {
        var response = new AddNewTreatmentResponse();
        response.@return = _Treatments.AddNewTreatment(
        args.treatment
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewTreatmentResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Treatment addressed by the primary identifier fields within the given Treatment. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("UpdateTreatment")]
    [HttpPost("updateTreatment"), Produces("application/json")]
    public UpdateTreatmentResponse UpdateTreatment([FromBody][SwaggerRequestBody(Required = true)] UpdateTreatmentRequest args) {
      try {
        var response = new UpdateTreatmentResponse();
        response.@return = _Treatments.UpdateTreatment(
        args.treatment
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateTreatmentResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Treatment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("UpdateTreatmentByTaskGuid")]
    [HttpPost("updateTreatmentByTaskGuid"), Produces("application/json")]
    public UpdateTreatmentByTaskGuidResponse UpdateTreatmentByTaskGuid([FromBody][SwaggerRequestBody(Required = true)] UpdateTreatmentByTaskGuidRequest args) {
      try {
        var response = new UpdateTreatmentByTaskGuidResponse();
        response.@return = _Treatments.UpdateTreatmentByTaskGuid(
        args.taskGuid,
        args.treatment
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateTreatmentByTaskGuidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific Treatment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("DeleteTreatmentByTaskGuid")]
    [HttpPost("deleteTreatmentByTaskGuid"), Produces("application/json")]
    public DeleteTreatmentByTaskGuidResponse DeleteTreatmentByTaskGuid([FromBody][SwaggerRequestBody(Required = true)] DeleteTreatmentByTaskGuidRequest args) {
      try {
        var response = new DeleteTreatmentByTaskGuidResponse();
        response.@return = _Treatments.DeleteTreatmentByTaskGuid(
        args.taskGuid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteTreatmentByTaskGuidResponse { fault = ex.Message };
      }
    }
    
  }
  
}
