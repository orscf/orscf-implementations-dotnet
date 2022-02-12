/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.BillingData.StoreAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Security;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MedicalResearch.BillingData.WebAPI {
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/billableTasks")]
  public partial class BillableTasksController : ControllerBase {
    
    private readonly ILogger<BillableTasksController> _Logger;
    private readonly IBillableTasks _BillableTasks;
    
    public BillableTasksController(ILogger<BillableTasksController> logger, IBillableTasks billableTasks) {
      _Logger = logger;
      _BillableTasks = billableTasks;
    }
    
    /// <summary> Loads a specific BillableTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetBillableTaskByTaskGuid")]
    [HttpPost("getBillableTaskByTaskGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetBillableTaskByTaskGuid), Description = "Loads a specific BillableTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetBillableTaskByTaskGuidResponse GetBillableTaskByTaskGuid([FromBody][SwaggerRequestBody(Required = true)] GetBillableTaskByTaskGuidRequest args) {
      try {
        var response = new GetBillableTaskByTaskGuidResponse();
        response.@return = _BillableTasks.GetBillableTaskByTaskGuid(
          args.taskGuid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetBillableTaskByTaskGuidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads BillableTasks. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetBillableTasks")]
    [HttpPost("getBillableTasks"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetBillableTasks), Description = "Loads BillableTasks.")]
    public GetBillableTasksResponse GetBillableTasks([FromBody][SwaggerRequestBody(Required = true)] GetBillableTasksRequest args) {
      try {
        var response = new GetBillableTasksResponse();
        response.@return = _BillableTasks.GetBillableTasks(
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetBillableTasksResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads BillableTasks where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-SearchBillableTasks")]
    [HttpPost("searchBillableTasks"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchBillableTasks), Description = "Loads BillableTasks where values matching to the given filterExpression")]
    public SearchBillableTasksResponse SearchBillableTasks([FromBody][SwaggerRequestBody(Required = true)] SearchBillableTasksRequest args) {
      try {
        var response = new SearchBillableTasksResponse();
        response.@return = _BillableTasks.SearchBillableTasks(
          args.filterExpression,
          args.sortingExpression,
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchBillableTasksResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new BillableTask and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-AddNewBillableTask")]
    [HttpPost("addNewBillableTask"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewBillableTask), Description = "Adds a new BillableTask and returns its primary identifier (or null on failure).")]
    public AddNewBillableTaskResponse AddNewBillableTask([FromBody][SwaggerRequestBody(Required = true)] AddNewBillableTaskRequest args) {
      try {
        var response = new AddNewBillableTaskResponse();
        response.@return = _BillableTasks.AddNewBillableTask(
          args.billableTask
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewBillableTaskResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillableTask addressed by the primary identifier fields within the given BillableTask. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateBillableTask")]
    [HttpPost("updateBillableTask"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateBillableTask), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given BillableTask addressed by the primary identifier fields within the given BillableTask. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateBillableTaskResponse UpdateBillableTask([FromBody][SwaggerRequestBody(Required = true)] UpdateBillableTaskRequest args) {
      try {
        var response = new UpdateBillableTaskResponse();
        response.@return = _BillableTasks.UpdateBillableTask(
          args.billableTask
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateBillableTaskResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillableTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateBillableTaskByTaskGuid")]
    [HttpPost("updateBillableTaskByTaskGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateBillableTaskByTaskGuid), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given BillableTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateBillableTaskByTaskGuidResponse UpdateBillableTaskByTaskGuid([FromBody][SwaggerRequestBody(Required = true)] UpdateBillableTaskByTaskGuidRequest args) {
      try {
        var response = new UpdateBillableTaskByTaskGuidResponse();
        response.@return = _BillableTasks.UpdateBillableTaskByTaskGuid(
          args.taskGuid,
          args.billableTask
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateBillableTaskByTaskGuidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific BillableTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-DeleteBillableTaskByTaskGuid")]
    [HttpPost("deleteBillableTaskByTaskGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteBillableTaskByTaskGuid), Description = "Deletes a specific BillableTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteBillableTaskByTaskGuidResponse DeleteBillableTaskByTaskGuid([FromBody][SwaggerRequestBody(Required = true)] DeleteBillableTaskByTaskGuidRequest args) {
      try {
        var response = new DeleteBillableTaskByTaskGuidResponse();
        response.@return = _BillableTasks.DeleteBillableTaskByTaskGuid(
          args.taskGuid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteBillableTaskByTaskGuidResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/billableVisits")]
  public partial class BillableVisitsController : ControllerBase {
    
    private readonly ILogger<BillableVisitsController> _Logger;
    private readonly IBillableVisits _BillableVisits;
    
    public BillableVisitsController(ILogger<BillableVisitsController> logger, IBillableVisits billableVisits) {
      _Logger = logger;
      _BillableVisits = billableVisits;
    }
    
    /// <summary> Loads a specific BillableVisit addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetBillableVisitByVisitGuid")]
    [HttpPost("getBillableVisitByVisitGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetBillableVisitByVisitGuid), Description = "Loads a specific BillableVisit addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetBillableVisitByVisitGuidResponse GetBillableVisitByVisitGuid([FromBody][SwaggerRequestBody(Required = true)] GetBillableVisitByVisitGuidRequest args) {
      try {
        var response = new GetBillableVisitByVisitGuidResponse();
        response.@return = _BillableVisits.GetBillableVisitByVisitGuid(
          args.visitGuid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetBillableVisitByVisitGuidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads BillableVisits. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetBillableVisits")]
    [HttpPost("getBillableVisits"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetBillableVisits), Description = "Loads BillableVisits.")]
    public GetBillableVisitsResponse GetBillableVisits([FromBody][SwaggerRequestBody(Required = true)] GetBillableVisitsRequest args) {
      try {
        var response = new GetBillableVisitsResponse();
        response.@return = _BillableVisits.GetBillableVisits(
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetBillableVisitsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads BillableVisits where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-SearchBillableVisits")]
    [HttpPost("searchBillableVisits"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchBillableVisits), Description = "Loads BillableVisits where values matching to the given filterExpression")]
    public SearchBillableVisitsResponse SearchBillableVisits([FromBody][SwaggerRequestBody(Required = true)] SearchBillableVisitsRequest args) {
      try {
        var response = new SearchBillableVisitsResponse();
        response.@return = _BillableVisits.SearchBillableVisits(
          args.filterExpression,
          args.sortingExpression,
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchBillableVisitsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new BillableVisit and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-AddNewBillableVisit")]
    [HttpPost("addNewBillableVisit"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewBillableVisit), Description = "Adds a new BillableVisit and returns its primary identifier (or null on failure).")]
    public AddNewBillableVisitResponse AddNewBillableVisit([FromBody][SwaggerRequestBody(Required = true)] AddNewBillableVisitRequest args) {
      try {
        var response = new AddNewBillableVisitResponse();
        response.@return = _BillableVisits.AddNewBillableVisit(
          args.billableVisit
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewBillableVisitResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillableVisit addressed by the primary identifier fields within the given BillableVisit. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateBillableVisit")]
    [HttpPost("updateBillableVisit"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateBillableVisit), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given BillableVisit addressed by the primary identifier fields within the given BillableVisit. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateBillableVisitResponse UpdateBillableVisit([FromBody][SwaggerRequestBody(Required = true)] UpdateBillableVisitRequest args) {
      try {
        var response = new UpdateBillableVisitResponse();
        response.@return = _BillableVisits.UpdateBillableVisit(
          args.billableVisit
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateBillableVisitResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillableVisit addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateBillableVisitByVisitGuid")]
    [HttpPost("updateBillableVisitByVisitGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateBillableVisitByVisitGuid), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given BillableVisit addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateBillableVisitByVisitGuidResponse UpdateBillableVisitByVisitGuid([FromBody][SwaggerRequestBody(Required = true)] UpdateBillableVisitByVisitGuidRequest args) {
      try {
        var response = new UpdateBillableVisitByVisitGuidResponse();
        response.@return = _BillableVisits.UpdateBillableVisitByVisitGuid(
          args.visitGuid,
          args.billableVisit
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateBillableVisitByVisitGuidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific BillableVisit addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-DeleteBillableVisitByVisitGuid")]
    [HttpPost("deleteBillableVisitByVisitGuid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteBillableVisitByVisitGuid), Description = "Deletes a specific BillableVisit addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteBillableVisitByVisitGuidResponse DeleteBillableVisitByVisitGuid([FromBody][SwaggerRequestBody(Required = true)] DeleteBillableVisitByVisitGuidRequest args) {
      try {
        var response = new DeleteBillableVisitByVisitGuidResponse();
        response.@return = _BillableVisits.DeleteBillableVisitByVisitGuid(
          args.visitGuid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteBillableVisitByVisitGuidResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/studyExecutionScopes")]
  public partial class StudyExecutionScopesController : ControllerBase {
    
    private readonly ILogger<StudyExecutionScopesController> _Logger;
    private readonly IStudyExecutionScopes _StudyExecutionScopes;
    
    public StudyExecutionScopesController(ILogger<StudyExecutionScopesController> logger, IStudyExecutionScopes studyExecutionScopes) {
      _Logger = logger;
      _StudyExecutionScopes = studyExecutionScopes;
    }
    
    /// <summary> Loads a specific StudyExecutionScope addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetStudyExecutionScopeByStudyExecutionIdentifier")]
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
    [RequireBaererAuth("store-GetStudyExecutionScopes")]
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
    [RequireBaererAuth("store-SearchStudyExecutionScopes")]
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
    [RequireBaererAuth("store-AddNewStudyExecutionScope")]
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
    [RequireBaererAuth("store-UpdateStudyExecutionScope")]
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
    [RequireBaererAuth("store-UpdateStudyExecutionScopeByStudyExecutionIdentifier")]
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
    [RequireBaererAuth("store-DeleteStudyExecutionScopeByStudyExecutionIdentifier")]
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
  [Route("store/billingDemands")]
  public partial class BillingDemandsController : ControllerBase {
    
    private readonly ILogger<BillingDemandsController> _Logger;
    private readonly IBillingDemands _BillingDemands;
    
    public BillingDemandsController(ILogger<BillingDemandsController> logger, IBillingDemands billingDemands) {
      _Logger = logger;
      _BillingDemands = billingDemands;
    }
    
    /// <summary> Loads a specific BillingDemand addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetBillingDemandById")]
    [HttpPost("getBillingDemandById"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetBillingDemandById), Description = "Loads a specific BillingDemand addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetBillingDemandByIdResponse GetBillingDemandById([FromBody][SwaggerRequestBody(Required = true)] GetBillingDemandByIdRequest args) {
      try {
        var response = new GetBillingDemandByIdResponse();
        response.@return = _BillingDemands.GetBillingDemandById(
          args.id
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetBillingDemandByIdResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads BillingDemands. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetBillingDemands")]
    [HttpPost("getBillingDemands"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetBillingDemands), Description = "Loads BillingDemands.")]
    public GetBillingDemandsResponse GetBillingDemands([FromBody][SwaggerRequestBody(Required = true)] GetBillingDemandsRequest args) {
      try {
        var response = new GetBillingDemandsResponse();
        response.@return = _BillingDemands.GetBillingDemands(
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetBillingDemandsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads BillingDemands where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-SearchBillingDemands")]
    [HttpPost("searchBillingDemands"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchBillingDemands), Description = "Loads BillingDemands where values matching to the given filterExpression")]
    public SearchBillingDemandsResponse SearchBillingDemands([FromBody][SwaggerRequestBody(Required = true)] SearchBillingDemandsRequest args) {
      try {
        var response = new SearchBillingDemandsResponse();
        response.@return = _BillingDemands.SearchBillingDemands(
          args.filterExpression,
          args.sortingExpression,
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchBillingDemandsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new BillingDemand and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-AddNewBillingDemand")]
    [HttpPost("addNewBillingDemand"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewBillingDemand), Description = "Adds a new BillingDemand and returns its primary identifier (or null on failure).")]
    public AddNewBillingDemandResponse AddNewBillingDemand([FromBody][SwaggerRequestBody(Required = true)] AddNewBillingDemandRequest args) {
      try {
        var response = new AddNewBillingDemandResponse();
        response.@return = _BillingDemands.AddNewBillingDemand(
          args.billingDemand
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewBillingDemandResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillingDemand addressed by the primary identifier fields within the given BillingDemand. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateBillingDemand")]
    [HttpPost("updateBillingDemand"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateBillingDemand), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given BillingDemand addressed by the primary identifier fields within the given BillingDemand. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateBillingDemandResponse UpdateBillingDemand([FromBody][SwaggerRequestBody(Required = true)] UpdateBillingDemandRequest args) {
      try {
        var response = new UpdateBillingDemandResponse();
        response.@return = _BillingDemands.UpdateBillingDemand(
          args.billingDemand
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateBillingDemandResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillingDemand addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateBillingDemandById")]
    [HttpPost("updateBillingDemandById"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateBillingDemandById), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given BillingDemand addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateBillingDemandByIdResponse UpdateBillingDemandById([FromBody][SwaggerRequestBody(Required = true)] UpdateBillingDemandByIdRequest args) {
      try {
        var response = new UpdateBillingDemandByIdResponse();
        response.@return = _BillingDemands.UpdateBillingDemandById(
          args.id,
          args.billingDemand
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateBillingDemandByIdResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific BillingDemand addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-DeleteBillingDemandById")]
    [HttpPost("deleteBillingDemandById"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteBillingDemandById), Description = "Deletes a specific BillingDemand addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteBillingDemandByIdResponse DeleteBillingDemandById([FromBody][SwaggerRequestBody(Required = true)] DeleteBillingDemandByIdRequest args) {
      try {
        var response = new DeleteBillingDemandByIdResponse();
        response.@return = _BillingDemands.DeleteBillingDemandById(
          args.id
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteBillingDemandByIdResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/invoices")]
  public partial class InvoicesController : ControllerBase {
    
    private readonly ILogger<InvoicesController> _Logger;
    private readonly IInvoices _Invoices;
    
    public InvoicesController(ILogger<InvoicesController> logger, IInvoices invoices) {
      _Logger = logger;
      _Invoices = invoices;
    }
    
    /// <summary> Loads a specific Invoice addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetInvoiceById")]
    [HttpPost("getInvoiceById"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetInvoiceById), Description = "Loads a specific Invoice addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetInvoiceByIdResponse GetInvoiceById([FromBody][SwaggerRequestBody(Required = true)] GetInvoiceByIdRequest args) {
      try {
        var response = new GetInvoiceByIdResponse();
        response.@return = _Invoices.GetInvoiceById(
          args.id
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetInvoiceByIdResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads Invoices. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetInvoices")]
    [HttpPost("getInvoices"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetInvoices), Description = "Loads Invoices.")]
    public GetInvoicesResponse GetInvoices([FromBody][SwaggerRequestBody(Required = true)] GetInvoicesRequest args) {
      try {
        var response = new GetInvoicesResponse();
        response.@return = _Invoices.GetInvoices(
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetInvoicesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads Invoices where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-SearchInvoices")]
    [HttpPost("searchInvoices"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchInvoices), Description = "Loads Invoices where values matching to the given filterExpression")]
    public SearchInvoicesResponse SearchInvoices([FromBody][SwaggerRequestBody(Required = true)] SearchInvoicesRequest args) {
      try {
        var response = new SearchInvoicesResponse();
        response.@return = _Invoices.SearchInvoices(
          args.filterExpression,
          args.sortingExpression,
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchInvoicesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new Invoice and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-AddNewInvoice")]
    [HttpPost("addNewInvoice"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewInvoice), Description = "Adds a new Invoice and returns its primary identifier (or null on failure).")]
    public AddNewInvoiceResponse AddNewInvoice([FromBody][SwaggerRequestBody(Required = true)] AddNewInvoiceRequest args) {
      try {
        var response = new AddNewInvoiceResponse();
        response.@return = _Invoices.AddNewInvoice(
          args.invoice
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewInvoiceResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Invoice addressed by the primary identifier fields within the given Invoice. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateInvoice")]
    [HttpPost("updateInvoice"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateInvoice), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given Invoice addressed by the primary identifier fields within the given Invoice. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateInvoiceResponse UpdateInvoice([FromBody][SwaggerRequestBody(Required = true)] UpdateInvoiceRequest args) {
      try {
        var response = new UpdateInvoiceResponse();
        response.@return = _Invoices.UpdateInvoice(
          args.invoice
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateInvoiceResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Invoice addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateInvoiceById")]
    [HttpPost("updateInvoiceById"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateInvoiceById), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given Invoice addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateInvoiceByIdResponse UpdateInvoiceById([FromBody][SwaggerRequestBody(Required = true)] UpdateInvoiceByIdRequest args) {
      try {
        var response = new UpdateInvoiceByIdResponse();
        response.@return = _Invoices.UpdateInvoiceById(
          args.id,
          args.invoice
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateInvoiceByIdResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific Invoice addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-DeleteInvoiceById")]
    [HttpPost("deleteInvoiceById"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteInvoiceById), Description = "Deletes a specific Invoice addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteInvoiceByIdResponse DeleteInvoiceById([FromBody][SwaggerRequestBody(Required = true)] DeleteInvoiceByIdRequest args) {
      try {
        var response = new DeleteInvoiceByIdResponse();
        response.@return = _Invoices.DeleteInvoiceById(
          args.id
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteInvoiceByIdResponse { fault = ex.Message };
      }
    }
    
  }
  
}
