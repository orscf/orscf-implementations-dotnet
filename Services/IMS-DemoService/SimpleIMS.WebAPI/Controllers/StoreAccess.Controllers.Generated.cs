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
  public partial class AdditionalSubjectParticipationIdentifiersController : ControllerBase {
    
    private readonly ILogger<AdditionalSubjectParticipationIdentifiersController> _Logger;
    private readonly IAdditionalSubjectParticipationIdentifiers _AdditionalSubjectParticipationIdentifiers;
    
    public AdditionalSubjectParticipationIdentifiersController(ILogger<AdditionalSubjectParticipationIdentifiersController> logger, IAdditionalSubjectParticipationIdentifiers additionalSubjectParticipationIdentifiers) {
      _Logger = logger;
      _AdditionalSubjectParticipationIdentifiers = additionalSubjectParticipationIdentifiers;
    }
    
    /// <summary> Loads a specific AdditionalSubjectParticipationIdentifier addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity")]
    [HttpPost("getAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity"), Produces("application/json")]
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
    [RequireBaererAuth("store-GetAdditionalSubjectParticipationIdentifiers")]
    [HttpPost("getAdditionalSubjectParticipationIdentifiers"), Produces("application/json")]
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
    [RequireBaererAuth("store-SearchAdditionalSubjectParticipationIdentifiers")]
    [HttpPost("searchAdditionalSubjectParticipationIdentifiers"), Produces("application/json")]
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
    [RequireBaererAuth("store-AddNewAdditionalSubjectParticipationIdentifier")]
    [HttpPost("addNewAdditionalSubjectParticipationIdentifier"), Produces("application/json")]
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
    [RequireBaererAuth("store-UpdateAdditionalSubjectParticipationIdentifier")]
    [HttpPost("updateAdditionalSubjectParticipationIdentifier"), Produces("application/json")]
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
    [RequireBaererAuth("store-UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity")]
    [HttpPost("updateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity"), Produces("application/json")]
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
    [RequireBaererAuth("store-DeleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity")]
    [HttpPost("deleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity"), Produces("application/json")]
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
  public partial class SubjectParticipationsController : ControllerBase {
    
    private readonly ILogger<SubjectParticipationsController> _Logger;
    private readonly ISubjectParticipations _SubjectParticipations;
    
    public SubjectParticipationsController(ILogger<SubjectParticipationsController> logger, ISubjectParticipations subjectParticipations) {
      _Logger = logger;
      _SubjectParticipations = subjectParticipations;
    }
    
    /// <summary> Loads a specific SubjectParticipation addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetSubjectParticipationByParticipantIdentifier")]
    [HttpPost("getSubjectParticipationByParticipantIdentifier"), Produces("application/json")]
    public GetSubjectParticipationByParticipantIdentifierResponse GetSubjectParticipationByParticipantIdentifier([FromBody][SwaggerRequestBody(Required = true)] GetSubjectParticipationByParticipantIdentifierRequest args) {
      try {
        var response = new GetSubjectParticipationByParticipantIdentifierResponse();
        response.@return = _SubjectParticipations.GetSubjectParticipationByParticipantIdentifier(
        args.participantIdentifier
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetSubjectParticipationByParticipantIdentifierResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads SubjectParticipations. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetSubjectParticipations")]
    [HttpPost("getSubjectParticipations"), Produces("application/json")]
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
    [RequireBaererAuth("store-SearchSubjectParticipations")]
    [HttpPost("searchSubjectParticipations"), Produces("application/json")]
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
    [RequireBaererAuth("store-AddNewSubjectParticipation")]
    [HttpPost("addNewSubjectParticipation"), Produces("application/json")]
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
    [RequireBaererAuth("store-UpdateSubjectParticipation")]
    [HttpPost("updateSubjectParticipation"), Produces("application/json")]
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
    [RequireBaererAuth("store-UpdateSubjectParticipationByParticipantIdentifier")]
    [HttpPost("updateSubjectParticipationByParticipantIdentifier"), Produces("application/json")]
    public UpdateSubjectParticipationByParticipantIdentifierResponse UpdateSubjectParticipationByParticipantIdentifier([FromBody][SwaggerRequestBody(Required = true)] UpdateSubjectParticipationByParticipantIdentifierRequest args) {
      try {
        var response = new UpdateSubjectParticipationByParticipantIdentifierResponse();
        response.@return = _SubjectParticipations.UpdateSubjectParticipationByParticipantIdentifier(
        args.participantIdentifier,
        args.subjectParticipation
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateSubjectParticipationByParticipantIdentifierResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific SubjectParticipation addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-DeleteSubjectParticipationByParticipantIdentifier")]
    [HttpPost("deleteSubjectParticipationByParticipantIdentifier"), Produces("application/json")]
    public DeleteSubjectParticipationByParticipantIdentifierResponse DeleteSubjectParticipationByParticipantIdentifier([FromBody][SwaggerRequestBody(Required = true)] DeleteSubjectParticipationByParticipantIdentifierRequest args) {
      try {
        var response = new DeleteSubjectParticipationByParticipantIdentifierResponse();
        response.@return = _SubjectParticipations.DeleteSubjectParticipationByParticipantIdentifier(
        args.participantIdentifier
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteSubjectParticipationByParticipantIdentifierResponse { fault = ex.Message };
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
  public partial class StudyScopesController : ControllerBase {
    
    private readonly ILogger<StudyScopesController> _Logger;
    private readonly IStudyScopes _StudyScopes;
    
    public StudyScopesController(ILogger<StudyScopesController> logger, IStudyScopes studyScopes) {
      _Logger = logger;
      _StudyScopes = studyScopes;
    }
    
    /// <summary> Loads a specific StudyScope addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetStudyScopeByStudyScopeIdentity")]
    [HttpPost("getStudyScopeByStudyScopeIdentity"), Produces("application/json")]
    public GetStudyScopeByStudyScopeIdentityResponse GetStudyScopeByStudyScopeIdentity([FromBody][SwaggerRequestBody(Required = true)] GetStudyScopeByStudyScopeIdentityRequest args) {
      try {
        var response = new GetStudyScopeByStudyScopeIdentityResponse();
        response.@return = _StudyScopes.GetStudyScopeByStudyScopeIdentity(
        args.studyScopeIdentity
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetStudyScopeByStudyScopeIdentityResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads StudyScopes. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetStudyScopes")]
    [HttpPost("getStudyScopes"), Produces("application/json")]
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
    [RequireBaererAuth("store-SearchStudyScopes")]
    [HttpPost("searchStudyScopes"), Produces("application/json")]
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
    [RequireBaererAuth("store-AddNewStudyScope")]
    [HttpPost("addNewStudyScope"), Produces("application/json")]
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
    [RequireBaererAuth("store-UpdateStudyScope")]
    [HttpPost("updateStudyScope"), Produces("application/json")]
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
    [RequireBaererAuth("store-UpdateStudyScopeByStudyScopeIdentity")]
    [HttpPost("updateStudyScopeByStudyScopeIdentity"), Produces("application/json")]
    public UpdateStudyScopeByStudyScopeIdentityResponse UpdateStudyScopeByStudyScopeIdentity([FromBody][SwaggerRequestBody(Required = true)] UpdateStudyScopeByStudyScopeIdentityRequest args) {
      try {
        var response = new UpdateStudyScopeByStudyScopeIdentityResponse();
        response.@return = _StudyScopes.UpdateStudyScopeByStudyScopeIdentity(
        args.studyScopeIdentity,
        args.studyScope
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateStudyScopeByStudyScopeIdentityResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific StudyScope addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-DeleteStudyScopeByStudyScopeIdentity")]
    [HttpPost("deleteStudyScopeByStudyScopeIdentity"), Produces("application/json")]
    public DeleteStudyScopeByStudyScopeIdentityResponse DeleteStudyScopeByStudyScopeIdentity([FromBody][SwaggerRequestBody(Required = true)] DeleteStudyScopeByStudyScopeIdentityRequest args) {
      try {
        var response = new DeleteStudyScopeByStudyScopeIdentityResponse();
        response.@return = _StudyScopes.DeleteStudyScopeByStudyScopeIdentity(
        args.studyScopeIdentity
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteStudyScopeByStudyScopeIdentityResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/subjectAddresses")]
  public partial class SubjectAddressesController : ControllerBase {
    
    private readonly ILogger<SubjectAddressesController> _Logger;
    private readonly ISubjectAddresses _SubjectAddresses;
    
    public SubjectAddressesController(ILogger<SubjectAddressesController> logger, ISubjectAddresses subjectAddresses) {
      _Logger = logger;
      _SubjectAddresses = subjectAddresses;
    }
    
    /// <summary> Loads a specific SubjectAddress addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetSubjectAddressByInternalRecordId")]
    [HttpPost("getSubjectAddressByInternalRecordId"), Produces("application/json")]
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
    [RequireBaererAuth("store-GetSubjectAddresses")]
    [HttpPost("getSubjectAddresses"), Produces("application/json")]
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
    [RequireBaererAuth("store-SearchSubjectAddresses")]
    [HttpPost("searchSubjectAddresses"), Produces("application/json")]
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
    [RequireBaererAuth("store-AddNewSubjectAddress")]
    [HttpPost("addNewSubjectAddress"), Produces("application/json")]
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
    [RequireBaererAuth("store-UpdateSubjectAddress")]
    [HttpPost("updateSubjectAddress"), Produces("application/json")]
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
    [RequireBaererAuth("store-UpdateSubjectAddressByInternalRecordId")]
    [HttpPost("updateSubjectAddressByInternalRecordId"), Produces("application/json")]
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
    [RequireBaererAuth("store-DeleteSubjectAddressByInternalRecordId")]
    [HttpPost("deleteSubjectAddressByInternalRecordId"), Produces("application/json")]
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
  public partial class SubjectIdentitiesController : ControllerBase {
    
    private readonly ILogger<SubjectIdentitiesController> _Logger;
    private readonly ISubjectIdentities _SubjectIdentities;
    
    public SubjectIdentitiesController(ILogger<SubjectIdentitiesController> logger, ISubjectIdentities subjectIdentities) {
      _Logger = logger;
      _SubjectIdentities = subjectIdentities;
    }
    
    /// <summary> Loads a specific SubjectIdentity addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetSubjectIdentityByRecordId")]
    [HttpPost("getSubjectIdentityByRecordId"), Produces("application/json")]
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
    [RequireBaererAuth("store-GetSubjectIdentities")]
    [HttpPost("getSubjectIdentities"), Produces("application/json")]
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
    [RequireBaererAuth("store-SearchSubjectIdentities")]
    [HttpPost("searchSubjectIdentities"), Produces("application/json")]
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
    [RequireBaererAuth("store-AddNewSubjectIdentity")]
    [HttpPost("addNewSubjectIdentity"), Produces("application/json")]
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
    [RequireBaererAuth("store-UpdateSubjectIdentity")]
    [HttpPost("updateSubjectIdentity"), Produces("application/json")]
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
    [RequireBaererAuth("store-UpdateSubjectIdentityByRecordId")]
    [HttpPost("updateSubjectIdentityByRecordId"), Produces("application/json")]
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
    [RequireBaererAuth("store-DeleteSubjectIdentityByRecordId")]
    [HttpPost("deleteSubjectIdentityByRecordId"), Produces("application/json")]
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
