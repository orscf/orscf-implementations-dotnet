/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.IdentityManagement.StoreAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Security;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MedicalResearch.IdentityManagement.WebAPI {
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/additionalSubjectParticipationIdentifiers")]
  public class AdditionalSubjectParticipationIdentifiersController : ControllerBase {
    
    private readonly ILogger<AdditionalSubjectParticipationIdentifiersController> _Logger;
    private readonly IAdditionalSubjectParticipationIdentifiers _AdditionalSubjectParticipationIdentifiers;
    
    public AdditionalSubjectParticipationIdentifiersController(ILogger<AdditionalSubjectParticipationIdentifiersController> logger, IAdditionalSubjectParticipationIdentifiers additionalSubjectParticipationIdentifiers) {
      _Logger = logger;
      _AdditionalSubjectParticipationIdentifiers = additionalSubjectParticipationIdentifiers;
    }
    
    /// <summary> Loads a specific AdditionalSubjectParticipationIdentifier addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-GetAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity")]
    [HttpPost("getAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity), Description = "Loads a specific AdditionalSubjectParticipationIdentifier addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityResponse GetAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity([FromBody][SwaggerRequestBody(Required = true)] GetAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityRequest args) {
      try {
        var response = new GetAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityResponse();
        response.@return = _AdditionalSubjectParticipationIdentifiers.GetAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity(
          args.additionalSubjectParticipationIdentifierIdentity
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads AdditionalSubjectParticipationIdentifiers. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-GetAdditionalSubjectParticipationIdentifiers")]
    [HttpPost("getAdditionalSubjectParticipationIdentifiers"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetAdditionalSubjectParticipationIdentifiers), Description = "Loads AdditionalSubjectParticipationIdentifiers.")]
    public GetAdditionalSubjectParticipationIdentifiersResponse GetAdditionalSubjectParticipationIdentifiers([FromBody][SwaggerRequestBody(Required = true)] GetAdditionalSubjectParticipationIdentifiersRequest args) {
      try {
        var response = new GetAdditionalSubjectParticipationIdentifiersResponse();
        response.@return = _AdditionalSubjectParticipationIdentifiers.GetAdditionalSubjectParticipationIdentifiers(
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetAdditionalSubjectParticipationIdentifiersResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads AdditionalSubjectParticipationIdentifiers where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-SearchAdditionalSubjectParticipationIdentifiers")]
    [HttpPost("searchAdditionalSubjectParticipationIdentifiers"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchAdditionalSubjectParticipationIdentifiers), Description = "Loads AdditionalSubjectParticipationIdentifiers where values matching to the given filterExpression")]
    public SearchAdditionalSubjectParticipationIdentifiersResponse SearchAdditionalSubjectParticipationIdentifiers([FromBody][SwaggerRequestBody(Required = true)] SearchAdditionalSubjectParticipationIdentifiersRequest args) {
      try {
        var response = new SearchAdditionalSubjectParticipationIdentifiersResponse();
        response.@return = _AdditionalSubjectParticipationIdentifiers.SearchAdditionalSubjectParticipationIdentifiers(
          args.filterExpression,
          args.sortingExpression,
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchAdditionalSubjectParticipationIdentifiersResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new AdditionalSubjectParticipationIdentifier and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-AddNewAdditionalSubjectParticipationIdentifier")]
    [HttpPost("addNewAdditionalSubjectParticipationIdentifier"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewAdditionalSubjectParticipationIdentifier), Description = "Adds a new AdditionalSubjectParticipationIdentifier and returns its primary identifier (or null on failure).")]
    public AddNewAdditionalSubjectParticipationIdentifierResponse AddNewAdditionalSubjectParticipationIdentifier([FromBody][SwaggerRequestBody(Required = true)] AddNewAdditionalSubjectParticipationIdentifierRequest args) {
      try {
        var response = new AddNewAdditionalSubjectParticipationIdentifierResponse();
        response.@return = _AdditionalSubjectParticipationIdentifiers.AddNewAdditionalSubjectParticipationIdentifier(
          args.additionalSubjectParticipationIdentifier
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewAdditionalSubjectParticipationIdentifierResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given AdditionalSubjectParticipationIdentifier addressed by the primary identifier fields within the given AdditionalSubjectParticipationIdentifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-UpdateAdditionalSubjectParticipationIdentifier")]
    [HttpPost("updateAdditionalSubjectParticipationIdentifier"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateAdditionalSubjectParticipationIdentifier), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given AdditionalSubjectParticipationIdentifier addressed by the primary identifier fields within the given AdditionalSubjectParticipationIdentifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateAdditionalSubjectParticipationIdentifierResponse UpdateAdditionalSubjectParticipationIdentifier([FromBody][SwaggerRequestBody(Required = true)] UpdateAdditionalSubjectParticipationIdentifierRequest args) {
      try {
        var response = new UpdateAdditionalSubjectParticipationIdentifierResponse();
        response.@return = _AdditionalSubjectParticipationIdentifiers.UpdateAdditionalSubjectParticipationIdentifier(
          args.additionalSubjectParticipationIdentifier
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateAdditionalSubjectParticipationIdentifierResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given AdditionalSubjectParticipationIdentifier addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity")]
    [HttpPost("updateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given AdditionalSubjectParticipationIdentifier addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityResponse UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity([FromBody][SwaggerRequestBody(Required = true)] UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityRequest args) {
      try {
        var response = new UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityResponse();
        response.@return = _AdditionalSubjectParticipationIdentifiers.UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity(
          args.additionalSubjectParticipationIdentifierIdentity,
          args.additionalSubjectParticipationIdentifier
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific AdditionalSubjectParticipationIdentifier addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-DeleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity")]
    [HttpPost("deleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity), Description = "Deletes a specific AdditionalSubjectParticipationIdentifier addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityResponse DeleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity([FromBody][SwaggerRequestBody(Required = true)] DeleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityRequest args) {
      try {
        var response = new DeleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityResponse();
        response.@return = _AdditionalSubjectParticipationIdentifiers.DeleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity(
          args.additionalSubjectParticipationIdentifierIdentity
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/subjectParticipations")]
  public class SubjectParticipationsController : ControllerBase {
    
    private readonly ILogger<SubjectParticipationsController> _Logger;
    private readonly ISubjectParticipations _SubjectParticipations;
    
    public SubjectParticipationsController(ILogger<SubjectParticipationsController> logger, ISubjectParticipations subjectParticipations) {
      _Logger = logger;
      _SubjectParticipations = subjectParticipations;
    }
    
    /// <summary> Loads a specific SubjectParticipation addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-GetSubjectParticipationBySubjectParticipationIdentity")]
    [HttpPost("getSubjectParticipationBySubjectParticipationIdentity"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetSubjectParticipationBySubjectParticipationIdentity), Description = "Loads a specific SubjectParticipation addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetSubjectParticipationBySubjectParticipationIdentityResponse GetSubjectParticipationBySubjectParticipationIdentity([FromBody][SwaggerRequestBody(Required = true)] GetSubjectParticipationBySubjectParticipationIdentityRequest args) {
      try {
        var response = new GetSubjectParticipationBySubjectParticipationIdentityResponse();
        response.@return = _SubjectParticipations.GetSubjectParticipationBySubjectParticipationIdentity(
          args.subjectParticipationIdentity
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetSubjectParticipationBySubjectParticipationIdentityResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads SubjectParticipations. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-GetSubjectParticipations")]
    [HttpPost("getSubjectParticipations"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetSubjectParticipations), Description = "Loads SubjectParticipations.")]
    public GetSubjectParticipationsResponse GetSubjectParticipations([FromBody][SwaggerRequestBody(Required = true)] GetSubjectParticipationsRequest args) {
      try {
        var response = new GetSubjectParticipationsResponse();
        response.@return = _SubjectParticipations.GetSubjectParticipations(
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetSubjectParticipationsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads SubjectParticipations where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-SearchSubjectParticipations")]
    [HttpPost("searchSubjectParticipations"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchSubjectParticipations), Description = "Loads SubjectParticipations where values matching to the given filterExpression")]
    public SearchSubjectParticipationsResponse SearchSubjectParticipations([FromBody][SwaggerRequestBody(Required = true)] SearchSubjectParticipationsRequest args) {
      try {
        var response = new SearchSubjectParticipationsResponse();
        response.@return = _SubjectParticipations.SearchSubjectParticipations(
          args.filterExpression,
          args.sortingExpression,
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchSubjectParticipationsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new SubjectParticipation and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-AddNewSubjectParticipation")]
    [HttpPost("addNewSubjectParticipation"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewSubjectParticipation), Description = "Adds a new SubjectParticipation and returns its primary identifier (or null on failure).")]
    public AddNewSubjectParticipationResponse AddNewSubjectParticipation([FromBody][SwaggerRequestBody(Required = true)] AddNewSubjectParticipationRequest args) {
      try {
        var response = new AddNewSubjectParticipationResponse();
        response.@return = _SubjectParticipations.AddNewSubjectParticipation(
          args.subjectParticipation
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewSubjectParticipationResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectParticipation addressed by the primary identifier fields within the given SubjectParticipation. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-UpdateSubjectParticipation")]
    [HttpPost("updateSubjectParticipation"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateSubjectParticipation), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given SubjectParticipation addressed by the primary identifier fields within the given SubjectParticipation. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateSubjectParticipationResponse UpdateSubjectParticipation([FromBody][SwaggerRequestBody(Required = true)] UpdateSubjectParticipationRequest args) {
      try {
        var response = new UpdateSubjectParticipationResponse();
        response.@return = _SubjectParticipations.UpdateSubjectParticipation(
          args.subjectParticipation
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateSubjectParticipationResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectParticipation addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-UpdateSubjectParticipationBySubjectParticipationIdentity")]
    [HttpPost("updateSubjectParticipationBySubjectParticipationIdentity"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateSubjectParticipationBySubjectParticipationIdentity), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given SubjectParticipation addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateSubjectParticipationBySubjectParticipationIdentityResponse UpdateSubjectParticipationBySubjectParticipationIdentity([FromBody][SwaggerRequestBody(Required = true)] UpdateSubjectParticipationBySubjectParticipationIdentityRequest args) {
      try {
        var response = new UpdateSubjectParticipationBySubjectParticipationIdentityResponse();
        response.@return = _SubjectParticipations.UpdateSubjectParticipationBySubjectParticipationIdentity(
          args.subjectParticipationIdentity,
          args.subjectParticipation
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateSubjectParticipationBySubjectParticipationIdentityResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific SubjectParticipation addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-DeleteSubjectParticipationBySubjectParticipationIdentity")]
    [HttpPost("deleteSubjectParticipationBySubjectParticipationIdentity"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteSubjectParticipationBySubjectParticipationIdentity), Description = "Deletes a specific SubjectParticipation addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteSubjectParticipationBySubjectParticipationIdentityResponse DeleteSubjectParticipationBySubjectParticipationIdentity([FromBody][SwaggerRequestBody(Required = true)] DeleteSubjectParticipationBySubjectParticipationIdentityRequest args) {
      try {
        var response = new DeleteSubjectParticipationBySubjectParticipationIdentityResponse();
        response.@return = _SubjectParticipations.DeleteSubjectParticipationBySubjectParticipationIdentity(
          args.subjectParticipationIdentity
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteSubjectParticipationBySubjectParticipationIdentityResponse { fault = ex.Message };
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
  [Route("store/studyScopes")]
  public class StudyScopesController : ControllerBase {
    
    private readonly ILogger<StudyScopesController> _Logger;
    private readonly IStudyScopes _StudyScopes;
    
    public StudyScopesController(ILogger<StudyScopesController> logger, IStudyScopes studyScopes) {
      _Logger = logger;
      _StudyScopes = studyScopes;
    }
    
    /// <summary> Loads a specific StudyScope addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-GetStudyScopeByResearchStudyUid")]
    [HttpPost("getStudyScopeByResearchStudyUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetStudyScopeByResearchStudyUid), Description = "Loads a specific StudyScope addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetStudyScopeByResearchStudyUidResponse GetStudyScopeByResearchStudyUid([FromBody][SwaggerRequestBody(Required = true)] GetStudyScopeByResearchStudyUidRequest args) {
      try {
        var response = new GetStudyScopeByResearchStudyUidResponse();
        response.@return = _StudyScopes.GetStudyScopeByResearchStudyUid(
          args.researchStudyUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetStudyScopeByResearchStudyUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads StudyScopes. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-GetStudyScopes")]
    [HttpPost("getStudyScopes"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetStudyScopes), Description = "Loads StudyScopes.")]
    public GetStudyScopesResponse GetStudyScopes([FromBody][SwaggerRequestBody(Required = true)] GetStudyScopesRequest args) {
      try {
        var response = new GetStudyScopesResponse();
        response.@return = _StudyScopes.GetStudyScopes(
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetStudyScopesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads StudyScopes where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-SearchStudyScopes")]
    [HttpPost("searchStudyScopes"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchStudyScopes), Description = "Loads StudyScopes where values matching to the given filterExpression")]
    public SearchStudyScopesResponse SearchStudyScopes([FromBody][SwaggerRequestBody(Required = true)] SearchStudyScopesRequest args) {
      try {
        var response = new SearchStudyScopesResponse();
        response.@return = _StudyScopes.SearchStudyScopes(
          args.filterExpression,
          args.sortingExpression,
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchStudyScopesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new StudyScope and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-AddNewStudyScope")]
    [HttpPost("addNewStudyScope"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewStudyScope), Description = "Adds a new StudyScope and returns its primary identifier (or null on failure).")]
    public AddNewStudyScopeResponse AddNewStudyScope([FromBody][SwaggerRequestBody(Required = true)] AddNewStudyScopeRequest args) {
      try {
        var response = new AddNewStudyScopeResponse();
        response.@return = _StudyScopes.AddNewStudyScope(
          args.studyScope
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewStudyScopeResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyScope addressed by the primary identifier fields within the given StudyScope. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-UpdateStudyScope")]
    [HttpPost("updateStudyScope"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateStudyScope), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given StudyScope addressed by the primary identifier fields within the given StudyScope. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateStudyScopeResponse UpdateStudyScope([FromBody][SwaggerRequestBody(Required = true)] UpdateStudyScopeRequest args) {
      try {
        var response = new UpdateStudyScopeResponse();
        response.@return = _StudyScopes.UpdateStudyScope(
          args.studyScope
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateStudyScopeResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyScope addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-UpdateStudyScopeByResearchStudyUid")]
    [HttpPost("updateStudyScopeByResearchStudyUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateStudyScopeByResearchStudyUid), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given StudyScope addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateStudyScopeByResearchStudyUidResponse UpdateStudyScopeByResearchStudyUid([FromBody][SwaggerRequestBody(Required = true)] UpdateStudyScopeByResearchStudyUidRequest args) {
      try {
        var response = new UpdateStudyScopeByResearchStudyUidResponse();
        response.@return = _StudyScopes.UpdateStudyScopeByResearchStudyUid(
          args.researchStudyUid,
          args.studyScope
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateStudyScopeByResearchStudyUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific StudyScope addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-DeleteStudyScopeByResearchStudyUid")]
    [HttpPost("deleteStudyScopeByResearchStudyUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteStudyScopeByResearchStudyUid), Description = "Deletes a specific StudyScope addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteStudyScopeByResearchStudyUidResponse DeleteStudyScopeByResearchStudyUid([FromBody][SwaggerRequestBody(Required = true)] DeleteStudyScopeByResearchStudyUidRequest args) {
      try {
        var response = new DeleteStudyScopeByResearchStudyUidResponse();
        response.@return = _StudyScopes.DeleteStudyScopeByResearchStudyUid(
          args.researchStudyUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteStudyScopeByResearchStudyUidResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/subjectAddresses")]
  public class SubjectAddressesController : ControllerBase {
    
    private readonly ILogger<SubjectAddressesController> _Logger;
    private readonly ISubjectAddresses _SubjectAddresses;
    
    public SubjectAddressesController(ILogger<SubjectAddressesController> logger, ISubjectAddresses subjectAddresses) {
      _Logger = logger;
      _SubjectAddresses = subjectAddresses;
    }
    
    /// <summary> Loads a specific SubjectAddress addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-GetSubjectAddressByInternalRecordId")]
    [HttpPost("getSubjectAddressByInternalRecordId"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetSubjectAddressByInternalRecordId), Description = "Loads a specific SubjectAddress addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetSubjectAddressByInternalRecordIdResponse GetSubjectAddressByInternalRecordId([FromBody][SwaggerRequestBody(Required = true)] GetSubjectAddressByInternalRecordIdRequest args) {
      try {
        var response = new GetSubjectAddressByInternalRecordIdResponse();
        response.@return = _SubjectAddresses.GetSubjectAddressByInternalRecordId(
          args.internalRecordId
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetSubjectAddressByInternalRecordIdResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads SubjectAddresses. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-GetSubjectAddresses")]
    [HttpPost("getSubjectAddresses"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetSubjectAddresses), Description = "Loads SubjectAddresses.")]
    public GetSubjectAddressesResponse GetSubjectAddresses([FromBody][SwaggerRequestBody(Required = true)] GetSubjectAddressesRequest args) {
      try {
        var response = new GetSubjectAddressesResponse();
        response.@return = _SubjectAddresses.GetSubjectAddresses(
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetSubjectAddressesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads SubjectAddresses where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-SearchSubjectAddresses")]
    [HttpPost("searchSubjectAddresses"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchSubjectAddresses), Description = "Loads SubjectAddresses where values matching to the given filterExpression")]
    public SearchSubjectAddressesResponse SearchSubjectAddresses([FromBody][SwaggerRequestBody(Required = true)] SearchSubjectAddressesRequest args) {
      try {
        var response = new SearchSubjectAddressesResponse();
        response.@return = _SubjectAddresses.SearchSubjectAddresses(
          args.filterExpression,
          args.sortingExpression,
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchSubjectAddressesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new SubjectAddress and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-AddNewSubjectAddress")]
    [HttpPost("addNewSubjectAddress"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewSubjectAddress), Description = "Adds a new SubjectAddress and returns its primary identifier (or null on failure).")]
    public AddNewSubjectAddressResponse AddNewSubjectAddress([FromBody][SwaggerRequestBody(Required = true)] AddNewSubjectAddressRequest args) {
      try {
        var response = new AddNewSubjectAddressResponse();
        response.@return = _SubjectAddresses.AddNewSubjectAddress(
          args.subjectAddress
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewSubjectAddressResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectAddress addressed by the primary identifier fields within the given SubjectAddress. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-UpdateSubjectAddress")]
    [HttpPost("updateSubjectAddress"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateSubjectAddress), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given SubjectAddress addressed by the primary identifier fields within the given SubjectAddress. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateSubjectAddressResponse UpdateSubjectAddress([FromBody][SwaggerRequestBody(Required = true)] UpdateSubjectAddressRequest args) {
      try {
        var response = new UpdateSubjectAddressResponse();
        response.@return = _SubjectAddresses.UpdateSubjectAddress(
          args.subjectAddress
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateSubjectAddressResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectAddress addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-UpdateSubjectAddressByInternalRecordId")]
    [HttpPost("updateSubjectAddressByInternalRecordId"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateSubjectAddressByInternalRecordId), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given SubjectAddress addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateSubjectAddressByInternalRecordIdResponse UpdateSubjectAddressByInternalRecordId([FromBody][SwaggerRequestBody(Required = true)] UpdateSubjectAddressByInternalRecordIdRequest args) {
      try {
        var response = new UpdateSubjectAddressByInternalRecordIdResponse();
        response.@return = _SubjectAddresses.UpdateSubjectAddressByInternalRecordId(
          args.internalRecordId,
          args.subjectAddress
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateSubjectAddressByInternalRecordIdResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific SubjectAddress addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-DeleteSubjectAddressByInternalRecordId")]
    [HttpPost("deleteSubjectAddressByInternalRecordId"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteSubjectAddressByInternalRecordId), Description = "Deletes a specific SubjectAddress addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteSubjectAddressByInternalRecordIdResponse DeleteSubjectAddressByInternalRecordId([FromBody][SwaggerRequestBody(Required = true)] DeleteSubjectAddressByInternalRecordIdRequest args) {
      try {
        var response = new DeleteSubjectAddressByInternalRecordIdResponse();
        response.@return = _SubjectAddresses.DeleteSubjectAddressByInternalRecordId(
          args.internalRecordId
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteSubjectAddressByInternalRecordIdResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/subjectIdentities")]
  public class SubjectIdentitiesController : ControllerBase {
    
    private readonly ILogger<SubjectIdentitiesController> _Logger;
    private readonly ISubjectIdentities _SubjectIdentities;
    
    public SubjectIdentitiesController(ILogger<SubjectIdentitiesController> logger, ISubjectIdentities subjectIdentities) {
      _Logger = logger;
      _SubjectIdentities = subjectIdentities;
    }
    
    /// <summary> Loads a specific SubjectIdentity addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-GetSubjectIdentityByRecordId")]
    [HttpPost("getSubjectIdentityByRecordId"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetSubjectIdentityByRecordId), Description = "Loads a specific SubjectIdentity addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetSubjectIdentityByRecordIdResponse GetSubjectIdentityByRecordId([FromBody][SwaggerRequestBody(Required = true)] GetSubjectIdentityByRecordIdRequest args) {
      try {
        var response = new GetSubjectIdentityByRecordIdResponse();
        response.@return = _SubjectIdentities.GetSubjectIdentityByRecordId(
          args.recordId
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetSubjectIdentityByRecordIdResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads SubjectIdentities. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-GetSubjectIdentities")]
    [HttpPost("getSubjectIdentities"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetSubjectIdentities), Description = "Loads SubjectIdentities.")]
    public GetSubjectIdentitiesResponse GetSubjectIdentities([FromBody][SwaggerRequestBody(Required = true)] GetSubjectIdentitiesRequest args) {
      try {
        var response = new GetSubjectIdentitiesResponse();
        response.@return = _SubjectIdentities.GetSubjectIdentities(
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetSubjectIdentitiesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads SubjectIdentities where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-SearchSubjectIdentities")]
    [HttpPost("searchSubjectIdentities"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchSubjectIdentities), Description = "Loads SubjectIdentities where values matching to the given filterExpression")]
    public SearchSubjectIdentitiesResponse SearchSubjectIdentities([FromBody][SwaggerRequestBody(Required = true)] SearchSubjectIdentitiesRequest args) {
      try {
        var response = new SearchSubjectIdentitiesResponse();
        response.@return = _SubjectIdentities.SearchSubjectIdentities(
          args.filterExpression,
          args.sortingExpression,
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchSubjectIdentitiesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new SubjectIdentity and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-AddNewSubjectIdentity")]
    [HttpPost("addNewSubjectIdentity"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewSubjectIdentity), Description = "Adds a new SubjectIdentity and returns its primary identifier (or null on failure).")]
    public AddNewSubjectIdentityResponse AddNewSubjectIdentity([FromBody][SwaggerRequestBody(Required = true)] AddNewSubjectIdentityRequest args) {
      try {
        var response = new AddNewSubjectIdentityResponse();
        response.@return = _SubjectIdentities.AddNewSubjectIdentity(
          args.subjectIdentity
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewSubjectIdentityResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectIdentity addressed by the primary identifier fields within the given SubjectIdentity. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-UpdateSubjectIdentity")]
    [HttpPost("updateSubjectIdentity"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateSubjectIdentity), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given SubjectIdentity addressed by the primary identifier fields within the given SubjectIdentity. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateSubjectIdentityResponse UpdateSubjectIdentity([FromBody][SwaggerRequestBody(Required = true)] UpdateSubjectIdentityRequest args) {
      try {
        var response = new UpdateSubjectIdentityResponse();
        response.@return = _SubjectIdentities.UpdateSubjectIdentity(
          args.subjectIdentity
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateSubjectIdentityResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectIdentity addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-UpdateSubjectIdentityByRecordId")]
    [HttpPost("updateSubjectIdentityByRecordId"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateSubjectIdentityByRecordId), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given SubjectIdentity addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateSubjectIdentityByRecordIdResponse UpdateSubjectIdentityByRecordId([FromBody][SwaggerRequestBody(Required = true)] UpdateSubjectIdentityByRecordIdRequest args) {
      try {
        var response = new UpdateSubjectIdentityByRecordIdResponse();
        response.@return = _SubjectIdentities.UpdateSubjectIdentityByRecordId(
          args.recordId,
          args.subjectIdentity
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateSubjectIdentityByRecordIdResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific SubjectIdentity addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [EvaluateBearerToken("store-DeleteSubjectIdentityByRecordId")]
    [HttpPost("deleteSubjectIdentityByRecordId"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteSubjectIdentityByRecordId), Description = "Deletes a specific SubjectIdentity addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteSubjectIdentityByRecordIdResponse DeleteSubjectIdentityByRecordId([FromBody][SwaggerRequestBody(Required = true)] DeleteSubjectIdentityByRecordIdRequest args) {
      try {
        var response = new DeleteSubjectIdentityByRecordIdResponse();
        response.@return = _SubjectIdentities.DeleteSubjectIdentityByRecordId(
          args.recordId
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteSubjectIdentityByRecordIdResponse { fault = ex.Message };
      }
    }
    
  }
  
}
