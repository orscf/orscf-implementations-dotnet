/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.Workflow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Security;
using Security.AccessTokenHandling;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MedicalResearch.Workflow.WebAPI {
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "ApiV1")]
  [Route("fhirQuestionaireConsume")]
  public partial class FhirQuestionaireConsumeController : ControllerBase {
    
    private readonly ILogger<FhirQuestionaireConsumeController> _Logger;
    private readonly IFhirQuestionaireConsumeService _FhirQuestionaireConsume;
    
    public FhirQuestionaireConsumeController(ILogger<FhirQuestionaireConsumeController> logger, IFhirQuestionaireConsumeService fhirQuestionaireConsume) {
      _Logger = logger;
      _FhirQuestionaireConsume = fhirQuestionaireConsume;
    }
    
    /// <summary> Lists all FHIR Questionaires </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("FhirQuestionaireConsume")]
    [HttpPost("searchFhirQuestionaires"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchFhirQuestionaires), Description = "Lists all FHIR Questionaires")]
    public SearchFhirQuestionairesResponse SearchFhirQuestionaires([FromBody][SwaggerRequestBody(Required = true)] SearchFhirQuestionairesRequest args) {
      try {
        var response = new SearchFhirQuestionairesResponse();
        _FhirQuestionaireConsume.SearchFhirQuestionaires(
          out var resultBuffer
        );
        response.result = resultBuffer;
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchFhirQuestionairesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Exports a FHIR Questionaire by its given 'questionaireIdentifyingUrl' and 'questionaireVersion' </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("FhirQuestionaireConsume")]
    [HttpPost("exportFhirQuestionaire"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(ExportFhirQuestionaire), Description = "Exports a FHIR Questionaire by its given 'questionaireIdentifyingUrl' and 'questionaireVersion'")]
    public ExportFhirQuestionaireResponse ExportFhirQuestionaire([FromBody][SwaggerRequestBody(Required = true)] ExportFhirQuestionaireRequest args) {
      try {
        var response = new ExportFhirQuestionaireResponse();
        _FhirQuestionaireConsume.ExportFhirQuestionaire(
          args.questionaireIdentifyingUrl,
          args.questionaireVersion,
          out var wasFoundBuffer,
          out var fhirContentBuffer
        );
        response.wasFound = wasFoundBuffer;
        response.fhirContent = fhirContentBuffer;
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new ExportFhirQuestionaireResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "ApiV1")]
  [Route("fhirQuestionaireSubmission")]
  public partial class FhirQuestionaireSubmissionController : ControllerBase {
    
    private readonly ILogger<FhirQuestionaireSubmissionController> _Logger;
    private readonly IFhirQuestionaireSubmissionService _FhirQuestionaireSubmission;
    
    public FhirQuestionaireSubmissionController(ILogger<FhirQuestionaireSubmissionController> logger, IFhirQuestionaireSubmissionService fhirQuestionaireSubmission) {
      _Logger = logger;
      _FhirQuestionaireSubmission = fhirQuestionaireSubmission;
    }
    
    /// <summary> Imports a FHIR Questionaire into the Repository The 'questionaireIdentifyingUrl' and 'questionaireVersion' will be taken from the 'fhirContent' </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("FhirQuestionaireSubmission")]
    [HttpPost("importFhirQuestionaire"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(ImportFhirQuestionaire), Description = "Imports a FHIR Questionaire into the Repository The 'questionaireIdentifyingUrl' and 'questionaireVersion' will be taken from the 'fhirContent'")]
    public ImportFhirQuestionaireResponse ImportFhirQuestionaire([FromBody][SwaggerRequestBody(Required = true)] ImportFhirQuestionaireRequest args) {
      try {
        var response = new ImportFhirQuestionaireResponse();
        _FhirQuestionaireSubmission.ImportFhirQuestionaire(
          args.fhirContent,
          out var wasNewBuffer
        );
        response.wasNew = wasNewBuffer;
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new ImportFhirQuestionaireResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a FHIR Questionaire by its given 'questionaireIdentifyingUrl' and 'questionaireVersion' </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("FhirQuestionaireSubmission")]
    [HttpPost("deleteFhirQuestionaire"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteFhirQuestionaire), Description = "Deletes a FHIR Questionaire by its given 'questionaireIdentifyingUrl' and 'questionaireVersion'")]
    public DeleteFhirQuestionaireResponse DeleteFhirQuestionaire([FromBody][SwaggerRequestBody(Required = true)] DeleteFhirQuestionaireRequest args) {
      try {
        var response = new DeleteFhirQuestionaireResponse();
        _FhirQuestionaireSubmission.DeleteFhirQuestionaire(
          args.questionaireIdentifyingUrl,
          args.questionaireVersion,
          out var wasDeletedBuffer
        );
        response.wasDeleted = wasDeletedBuffer;
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteFhirQuestionaireResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "ApiV1")]
  [Route("wdrApiInfo")]
  public partial class WdrApiInfoController : ControllerBase {
    
    private readonly ILogger<WdrApiInfoController> _Logger;
    private readonly IWdrApiInfoService _WdrApiInfo;
    
    public WdrApiInfoController(ILogger<WdrApiInfoController> logger, IWdrApiInfoService wdrApiInfo) {
      _Logger = logger;
      _WdrApiInfo = wdrApiInfo;
    }
    
    /// <summary> returns the version of the ORSCF specification which is implemented by this API, (this can be used for backward compatibility within inhomogeneous infrastructures) </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("WdrApiInfo")]
    [HttpPost("getApiVersion"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetApiVersion), Description = "returns the version of the ORSCF specification which is implemented by this API, (this can be used for backward compatibility within inhomogeneous infrastructures)")]
    public GetApiVersionResponse GetApiVersion([FromBody][SwaggerRequestBody(Required = true)] GetApiVersionRequest args) {
      try {
        var response = new GetApiVersionResponse();
        response.@return = _WdrApiInfo.GetApiVersion(
          
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetApiVersionResponse { fault = ex.Message };
      }
    }
    
    /// <summary> returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'WorkflowConsume', 'WorkflowSubmission', 'FhirQuestionaireConsume', 'FhirQuestionaireSubmission' </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("WdrApiInfo")]
    [HttpPost("getCapabilities"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetCapabilities), Description = "returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'WorkflowConsume', 'WorkflowSubmission', 'FhirQuestionaireConsume', 'FhirQuestionaireSubmission'")]
    public GetCapabilitiesResponse GetCapabilities([FromBody][SwaggerRequestBody(Required = true)] GetCapabilitiesRequest args) {
      try {
        var response = new GetCapabilitiesResponse();
        response.@return = _WdrApiInfo.GetCapabilities(
          
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetCapabilitiesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> returns a list of available capabilities ("API:WorkflowConsume") and/or data-scopes ("Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72") which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be: 0=auth needed / 1=authenticated / -1=auth expired / -2=auth invalid/disabled </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("WdrApiInfo")]
    [HttpPost("getPermittedAuthScopes"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetPermittedAuthScopes), Description = "returns a list of available capabilities (\"API:WorkflowConsume\") and/or data-scopes (\"Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72\") which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be: 0=auth needed / 1=authenticated / -1=auth expired / -2=auth invalid/disabled")]
    public GetPermittedAuthScopesResponse GetPermittedAuthScopes([FromBody][SwaggerRequestBody(Required = true)] GetPermittedAuthScopesRequest args) {
      try {
        var response = new GetPermittedAuthScopesResponse();
        response.@return = _WdrApiInfo.GetPermittedAuthScopes(
          out var authStateBuffer
        );
        response.authState = authStateBuffer;
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetPermittedAuthScopesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> OPTIONAL: If the authentication on the current service is mapped using tokens and should provide information about the source at this point, the login URL to be called up via browser (OAuth <see href="https://openid.net/specs/openid-client-initiated-backchannel-authentication-core-1_0.html">'CIBA-Flow'</see>) is returned here. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("WdrApiInfo")]
    [HttpPost("getOAuthTokenRequestUrl"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetOAuthTokenRequestUrl), Description = "OPTIONAL: If the authentication on the current service is mapped using tokens and should provide information about the source at this point, the login URL to be called up via browser (OAuth <see href=\"https://openid.net/specs/openid-client-initiated-backchannel-authentication-core-1_0.html\">'CIBA-Flow'</see>) is returned here.")]
    public GetOAuthTokenRequestUrlResponse GetOAuthTokenRequestUrl([FromBody][SwaggerRequestBody(Required = true)] GetOAuthTokenRequestUrlRequest args) {
      try {
        var response = new GetOAuthTokenRequestUrlResponse();
        response.@return = _WdrApiInfo.GetOAuthTokenRequestUrl(
          
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetOAuthTokenRequestUrlResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "ApiV1")]
  [Route("workflowConsume")]
  public partial class WorkflowConsumeController : ControllerBase {
    
    private readonly ILogger<WorkflowConsumeController> _Logger;
    private readonly IWorkflowConsumeService _WorkflowConsume;
    
    public WorkflowConsumeController(ILogger<WorkflowConsumeController> logger, IWorkflowConsumeService workflowConsume) {
      _Logger = logger;
      _WorkflowConsume = workflowConsume;
    }
    
    /// <summary> Lists all ORSCF 'ResearchStudyDefinitions' </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("WorkflowConsume")]
    [HttpPost("searchWorkflowDefinitions"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchWorkflowDefinitions), Description = "Lists all ORSCF 'ResearchStudyDefinitions'")]
    public SearchWorkflowDefinitionsResponse SearchWorkflowDefinitions([FromBody][SwaggerRequestBody(Required = true)] SearchWorkflowDefinitionsRequest args) {
      try {
        var response = new SearchWorkflowDefinitionsResponse();
        _WorkflowConsume.SearchWorkflowDefinitions(
          out var resultBuffer
        );
        response.result = resultBuffer;
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchWorkflowDefinitionsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Exports a ORSCF 'ResearchStudyDefinition' by its given 'workflowDefinitionName' and 'workflowVersion' </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("WorkflowConsume")]
    [HttpPost("exportWorkflowDefinition"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(ExportWorkflowDefinition), Description = "Exports a ORSCF 'ResearchStudyDefinition' by its given 'workflowDefinitionName' and 'workflowVersion'")]
    public ExportWorkflowDefinitionResponse ExportWorkflowDefinition([FromBody][SwaggerRequestBody(Required = true)] ExportWorkflowDefinitionRequest args) {
      try {
        var response = new ExportWorkflowDefinitionResponse();
        _WorkflowConsume.ExportWorkflowDefinition(
          args.workflowDefinitionName,
          args.workflowVersion,
          out var wasFoundBuffer,
          out var resultBuffer
        );
        response.wasFound = wasFoundBuffer;
        response.result = resultBuffer;
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new ExportWorkflowDefinitionResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "ApiV1")]
  [Route("workflowSubmission")]
  public partial class WorkflowSubmissionController : ControllerBase {
    
    private readonly ILogger<WorkflowSubmissionController> _Logger;
    private readonly IWorkflowSubmissionService _WorkflowSubmission;
    
    public WorkflowSubmissionController(ILogger<WorkflowSubmissionController> logger, IWorkflowSubmissionService workflowSubmission) {
      _Logger = logger;
      _WorkflowSubmission = workflowSubmission;
    }
    
    /// <summary> Imports a ORSCF 'ResearchStudyDefinition' into the Repository The 'workflowDefinitionName' and 'workflowVersion' will be taken from the definition itself </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("WorkflowSubmission")]
    [HttpPost("importWorkflowDefinition"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(ImportWorkflowDefinition), Description = "Imports a ORSCF 'ResearchStudyDefinition' into the Repository The 'workflowDefinitionName' and 'workflowVersion' will be taken from the definition itself")]
    public ImportWorkflowDefinitionResponse ImportWorkflowDefinition([FromBody][SwaggerRequestBody(Required = true)] ImportWorkflowDefinitionRequest args) {
      try {
        var response = new ImportWorkflowDefinitionResponse();
        _WorkflowSubmission.ImportWorkflowDefinition(
          args.workflowDefinition,
          out var wasNewBuffer
        );
        response.wasNew = wasNewBuffer;
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new ImportWorkflowDefinitionResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a ORSCF 'ResearchStudyDefinition' by its given 'workflowDefinitionName' and 'workflowVersion' </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("WorkflowSubmission")]
    [HttpPost("deleteWorkflowDefinition"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteWorkflowDefinition), Description = "Deletes a ORSCF 'ResearchStudyDefinition' by its given 'workflowDefinitionName' and 'workflowVersion'")]
    public DeleteWorkflowDefinitionResponse DeleteWorkflowDefinition([FromBody][SwaggerRequestBody(Required = true)] DeleteWorkflowDefinitionRequest args) {
      try {
        var response = new DeleteWorkflowDefinitionResponse();
        _WorkflowSubmission.DeleteWorkflowDefinition(
          args.workflowDefinitionName,
          args.workflowVersion,
          out var wasDeletedBuffer
        );
        response.wasDeleted = wasDeletedBuffer;
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteWorkflowDefinitionResponse { fault = ex.Message };
      }
    }
    
  }
  
}
