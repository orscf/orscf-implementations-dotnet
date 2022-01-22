/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.VisitData.StoreAccess;
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
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/dataRecordings")]
  public class DataRecordingsController : ControllerBase {
    
    private readonly ILogger<DataRecordingsController> _Logger;
    private readonly IDataRecordings _DataRecordings;
    
    public DataRecordingsController(ILogger<DataRecordingsController> logger, IDataRecordings dataRecordings) {
      _Logger = logger;
      _DataRecordings = dataRecordings;
    }
    
    /// <summary> Loads a specific DataRecording addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-GetDataRecordingByTaskGuid")]
    [HttpPost("getDataRecordingByTaskGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetDataRecordingByTaskGuid), Description = "Loads a specific DataRecording addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
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
    [EvaluateBearerToken("store-GetDataRecordings")]
    [HttpPost("getDataRecordings"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetDataRecordings), Description = "Loads DataRecordings.")]
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
    [EvaluateBearerToken("store-SearchDataRecordings")]
    [HttpPost("searchDataRecordings"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchDataRecordings), Description = "Loads DataRecordings where values matching to the given filterExpression")]
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
    [EvaluateBearerToken("store-AddNewDataRecording")]
    [HttpPost("addNewDataRecording"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewDataRecording), Description = "Adds a new DataRecording and returns its primary identifier (or null on failure).")]
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
    [EvaluateBearerToken("store-UpdateDataRecording")]
    [HttpPost("updateDataRecording"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateDataRecording), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given DataRecording addressed by the primary identifier fields within the given DataRecording. Returns false on failure or if no target record was found, otherwise true.")]
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
    [EvaluateBearerToken("store-UpdateDataRecordingByTaskGuid")]
    [HttpPost("updateDataRecordingByTaskGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateDataRecordingByTaskGuid), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given DataRecording addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
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
    [EvaluateBearerToken("store-DeleteDataRecordingByTaskGuid")]
    [HttpPost("deleteDataRecordingByTaskGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteDataRecordingByTaskGuid), Description = "Deletes a specific DataRecording addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
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
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/visits")]
  public class VisitsController : ControllerBase {
    
    private readonly ILogger<VisitsController> _Logger;
    private readonly IVisits _Visits;
    
    public VisitsController(ILogger<VisitsController> logger, IVisits visits) {
      _Logger = logger;
      _Visits = visits;
    }
    
    /// <summary> Loads a specific Visit addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-GetVisitByVisitGuid")]
    [HttpPost("getVisitByVisitGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetVisitByVisitGuid), Description = "Loads a specific Visit addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
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
    [EvaluateBearerToken("store-GetVisits")]
    [HttpPost("getVisits"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetVisits), Description = "Loads Visits.")]
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
    [EvaluateBearerToken("store-SearchVisits")]
    [HttpPost("searchVisits"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchVisits), Description = "Loads Visits where values matching to the given filterExpression")]
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
    [EvaluateBearerToken("store-AddNewVisit")]
    [HttpPost("addNewVisit"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewVisit), Description = "Adds a new Visit and returns its primary identifier (or null on failure).")]
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
    [EvaluateBearerToken("store-UpdateVisit")]
    [HttpPost("updateVisit"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateVisit), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given Visit addressed by the primary identifier fields within the given Visit. Returns false on failure or if no target record was found, otherwise true.")]
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
    [EvaluateBearerToken("store-UpdateVisitByVisitGuid")]
    [HttpPost("updateVisitByVisitGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateVisitByVisitGuid), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given Visit addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
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
    [EvaluateBearerToken("store-DeleteVisitByVisitGuid")]
    [HttpPost("deleteVisitByVisitGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteVisitByVisitGuid), Description = "Deletes a specific Visit addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
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
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/drugApplyments")]
  public class DrugApplymentsController : ControllerBase {
    
    private readonly ILogger<DrugApplymentsController> _Logger;
    private readonly IDrugApplyments _DrugApplyments;
    
    public DrugApplymentsController(ILogger<DrugApplymentsController> logger, IDrugApplyments drugApplyments) {
      _Logger = logger;
      _DrugApplyments = drugApplyments;
    }
    
    /// <summary> Loads a specific DrugApplyment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-GetDrugApplymentByTaskGuid")]
    [HttpPost("getDrugApplymentByTaskGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetDrugApplymentByTaskGuid), Description = "Loads a specific DrugApplyment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
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
    [EvaluateBearerToken("store-GetDrugApplyments")]
    [HttpPost("getDrugApplyments"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetDrugApplyments), Description = "Loads DrugApplyments.")]
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
    [EvaluateBearerToken("store-SearchDrugApplyments")]
    [HttpPost("searchDrugApplyments"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchDrugApplyments), Description = "Loads DrugApplyments where values matching to the given filterExpression")]
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
    [EvaluateBearerToken("store-AddNewDrugApplyment")]
    [HttpPost("addNewDrugApplyment"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewDrugApplyment), Description = "Adds a new DrugApplyment and returns its primary identifier (or null on failure).")]
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
    [EvaluateBearerToken("store-UpdateDrugApplyment")]
    [HttpPost("updateDrugApplyment"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateDrugApplyment), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given DrugApplyment addressed by the primary identifier fields within the given DrugApplyment. Returns false on failure or if no target record was found, otherwise true.")]
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
    [EvaluateBearerToken("store-UpdateDrugApplymentByTaskGuid")]
    [HttpPost("updateDrugApplymentByTaskGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateDrugApplymentByTaskGuid), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given DrugApplyment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
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
    [EvaluateBearerToken("store-DeleteDrugApplymentByTaskGuid")]
    [HttpPost("deleteDrugApplymentByTaskGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteDrugApplymentByTaskGuid), Description = "Deletes a specific DrugApplyment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
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
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/studyEvents")]
  public class StudyEventsController : ControllerBase {
    
    private readonly ILogger<StudyEventsController> _Logger;
    private readonly IStudyEvents _StudyEvents;
    
    public StudyEventsController(ILogger<StudyEventsController> logger, IStudyEvents studyEvents) {
      _Logger = logger;
      _StudyEvents = studyEvents;
    }
    
    /// <summary> Loads a specific StudyEvent addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-GetStudyEventByEventGuid")]
    [HttpPost("getStudyEventByEventGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetStudyEventByEventGuid), Description = "Loads a specific StudyEvent addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
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
    [EvaluateBearerToken("store-GetStudyEvents")]
    [HttpPost("getStudyEvents"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetStudyEvents), Description = "Loads StudyEvents.")]
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
    [EvaluateBearerToken("store-SearchStudyEvents")]
    [HttpPost("searchStudyEvents"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchStudyEvents), Description = "Loads StudyEvents where values matching to the given filterExpression")]
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
    [EvaluateBearerToken("store-AddNewStudyEvent")]
    [HttpPost("addNewStudyEvent"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewStudyEvent), Description = "Adds a new StudyEvent and returns its primary identifier (or null on failure).")]
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
    [EvaluateBearerToken("store-UpdateStudyEvent")]
    [HttpPost("updateStudyEvent"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateStudyEvent), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given StudyEvent addressed by the primary identifier fields within the given StudyEvent. Returns false on failure or if no target record was found, otherwise true.")]
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
    [EvaluateBearerToken("store-UpdateStudyEventByEventGuid")]
    [HttpPost("updateStudyEventByEventGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateStudyEventByEventGuid), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given StudyEvent addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
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
    [EvaluateBearerToken("store-DeleteStudyEventByEventGuid")]
    [HttpPost("deleteStudyEventByEventGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteStudyEventByEventGuid), Description = "Deletes a specific StudyEvent addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
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
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/studyExecutionScopes")]
  public class StudyExecutionScopesController : ControllerBase {
    
    private readonly ILogger<StudyExecutionScopesController> _Logger;
    private readonly IStudyExecutionScopes _StudyExecutionScopes;
    
    public StudyExecutionScopesController(ILogger<StudyExecutionScopesController> logger, IStudyExecutionScopes studyExecutionScopes) {
      _Logger = logger;
      _StudyExecutionScopes = studyExecutionScopes;
    }
    
    /// <summary> Loads a specific StudyExecutionScope addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-GetStudyExecutionScopeByStudyExecutionIdentifier")]
    [HttpPost("getStudyExecutionScopeByStudyExecutionIdentifier"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetStudyExecutionScopeByStudyExecutionIdentifier), Description = "Loads a specific StudyExecutionScope addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
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
    [EvaluateBearerToken("store-GetStudyExecutionScopes")]
    [HttpPost("getStudyExecutionScopes"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetStudyExecutionScopes), Description = "Loads StudyExecutionScopes.")]
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
    [EvaluateBearerToken("store-SearchStudyExecutionScopes")]
    [HttpPost("searchStudyExecutionScopes"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchStudyExecutionScopes), Description = "Loads StudyExecutionScopes where values matching to the given filterExpression")]
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
    [EvaluateBearerToken("store-AddNewStudyExecutionScope")]
    [HttpPost("addNewStudyExecutionScope"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewStudyExecutionScope), Description = "Adds a new StudyExecutionScope and returns its primary identifier (or null on failure).")]
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
    [EvaluateBearerToken("store-UpdateStudyExecutionScope")]
    [HttpPost("updateStudyExecutionScope"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateStudyExecutionScope), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given StudyExecutionScope addressed by the primary identifier fields within the given StudyExecutionScope. Returns false on failure or if no target record was found, otherwise true.")]
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
    [EvaluateBearerToken("store-UpdateStudyExecutionScopeByStudyExecutionIdentifier")]
    [HttpPost("updateStudyExecutionScopeByStudyExecutionIdentifier"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateStudyExecutionScopeByStudyExecutionIdentifier), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given StudyExecutionScope addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
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
    [EvaluateBearerToken("store-DeleteStudyExecutionScopeByStudyExecutionIdentifier")]
    [HttpPost("deleteStudyExecutionScopeByStudyExecutionIdentifier"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteStudyExecutionScopeByStudyExecutionIdentifier), Description = "Deletes a specific StudyExecutionScope addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
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
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/treatments")]
  public class TreatmentsController : ControllerBase {
    
    private readonly ILogger<TreatmentsController> _Logger;
    private readonly ITreatments _Treatments;
    
    public TreatmentsController(ILogger<TreatmentsController> logger, ITreatments treatments) {
      _Logger = logger;
      _Treatments = treatments;
    }
    
    /// <summary> Loads a specific Treatment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-GetTreatmentByTaskGuid")]
    [HttpPost("getTreatmentByTaskGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetTreatmentByTaskGuid), Description = "Loads a specific Treatment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
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
    [EvaluateBearerToken("store-GetTreatments")]
    [HttpPost("getTreatments"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetTreatments), Description = "Loads Treatments.")]
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
    [EvaluateBearerToken("store-SearchTreatments")]
    [HttpPost("searchTreatments"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchTreatments), Description = "Loads Treatments where values matching to the given filterExpression")]
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
    [EvaluateBearerToken("store-AddNewTreatment")]
    [HttpPost("addNewTreatment"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewTreatment), Description = "Adds a new Treatment and returns its primary identifier (or null on failure).")]
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
    [EvaluateBearerToken("store-UpdateTreatment")]
    [HttpPost("updateTreatment"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateTreatment), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given Treatment addressed by the primary identifier fields within the given Treatment. Returns false on failure or if no target record was found, otherwise true.")]
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
    [EvaluateBearerToken("store-UpdateTreatmentByTaskGuid")]
    [HttpPost("updateTreatmentByTaskGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateTreatmentByTaskGuid), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given Treatment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
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
    [EvaluateBearerToken("store-DeleteTreatmentByTaskGuid")]
    [HttpPost("deleteTreatmentByTaskGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteTreatmentByTaskGuid), Description = "Deletes a specific Treatment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
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
