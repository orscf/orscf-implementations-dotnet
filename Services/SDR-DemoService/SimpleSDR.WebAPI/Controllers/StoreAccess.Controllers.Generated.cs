/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.SubjectData.StoreAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Security;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MedicalResearch.SubjectData.WebAPI {
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/subjects")]
  public class SubjectsController : ControllerBase {
    
    private readonly ILogger<SubjectsController> _Logger;
    private readonly ISubjects _Subjects;
    
    public SubjectsController(ILogger<SubjectsController> logger, ISubjects subjects) {
      _Logger = logger;
      _Subjects = subjects;
    }
    
    /// <summary> Loads a specific Subject addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetSubjectBySubjectUid")]
    [HttpPost("getSubjectBySubjectUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetSubjectBySubjectUid), Description = "Loads a specific Subject addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetSubjectBySubjectUidResponse GetSubjectBySubjectUid([FromBody][SwaggerRequestBody(Required = true)] GetSubjectBySubjectUidRequest args) {
      try {
        var response = new GetSubjectBySubjectUidResponse();
        response.@return = _Subjects.GetSubjectBySubjectUid(
          args.subjectUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetSubjectBySubjectUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads Subjects. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetSubjects")]
    [HttpPost("getSubjects"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetSubjects), Description = "Loads Subjects.")]
    public GetSubjectsResponse GetSubjects([FromBody][SwaggerRequestBody(Required = true)] GetSubjectsRequest args) {
      try {
        var response = new GetSubjectsResponse();
        response.@return = _Subjects.GetSubjects(
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetSubjectsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads Subjects where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-SearchSubjects")]
    [HttpPost("searchSubjects"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchSubjects), Description = "Loads Subjects where values matching to the given filterExpression")]
    public SearchSubjectsResponse SearchSubjects([FromBody][SwaggerRequestBody(Required = true)] SearchSubjectsRequest args) {
      try {
        var response = new SearchSubjectsResponse();
        response.@return = _Subjects.SearchSubjects(
          args.filterExpression,
          args.sortingExpression,
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchSubjectsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new Subject and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-AddNewSubject")]
    [HttpPost("addNewSubject"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewSubject), Description = "Adds a new Subject and returns its primary identifier (or null on failure).")]
    public AddNewSubjectResponse AddNewSubject([FromBody][SwaggerRequestBody(Required = true)] AddNewSubjectRequest args) {
      try {
        var response = new AddNewSubjectResponse();
        response.@return = _Subjects.AddNewSubject(
          args.subject
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewSubjectResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Subject addressed by the primary identifier fields within the given Subject. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateSubject")]
    [HttpPost("updateSubject"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateSubject), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given Subject addressed by the primary identifier fields within the given Subject. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateSubjectResponse UpdateSubject([FromBody][SwaggerRequestBody(Required = true)] UpdateSubjectRequest args) {
      try {
        var response = new UpdateSubjectResponse();
        response.@return = _Subjects.UpdateSubject(
          args.subject
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateSubjectResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Subject addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateSubjectBySubjectUid")]
    [HttpPost("updateSubjectBySubjectUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateSubjectBySubjectUid), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given Subject addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateSubjectBySubjectUidResponse UpdateSubjectBySubjectUid([FromBody][SwaggerRequestBody(Required = true)] UpdateSubjectBySubjectUidRequest args) {
      try {
        var response = new UpdateSubjectBySubjectUidResponse();
        response.@return = _Subjects.UpdateSubjectBySubjectUid(
          args.subjectUid,
          args.subject
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateSubjectBySubjectUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific Subject addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-DeleteSubjectBySubjectUid")]
    [HttpPost("deleteSubjectBySubjectUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteSubjectBySubjectUid), Description = "Deletes a specific Subject addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteSubjectBySubjectUidResponse DeleteSubjectBySubjectUid([FromBody][SwaggerRequestBody(Required = true)] DeleteSubjectBySubjectUidRequest args) {
      try {
        var response = new DeleteSubjectBySubjectUidResponse();
        response.@return = _Subjects.DeleteSubjectBySubjectUid(
          args.subjectUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteSubjectBySubjectUidResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/subjectSiteAssignments")]
  public class SubjectSiteAssignmentsController : ControllerBase {
    
    private readonly ILogger<SubjectSiteAssignmentsController> _Logger;
    private readonly ISubjectSiteAssignments _SubjectSiteAssignments;
    
    public SubjectSiteAssignmentsController(ILogger<SubjectSiteAssignmentsController> logger, ISubjectSiteAssignments subjectSiteAssignments) {
      _Logger = logger;
      _SubjectSiteAssignments = subjectSiteAssignments;
    }
    
    /// <summary> Loads a specific SubjectSiteAssignment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetSubjectSiteAssignmentBySubjectSiteAssignmentUid")]
    [HttpPost("getSubjectSiteAssignmentBySubjectSiteAssignmentUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetSubjectSiteAssignmentBySubjectSiteAssignmentUid), Description = "Loads a specific SubjectSiteAssignment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetSubjectSiteAssignmentBySubjectSiteAssignmentUidResponse GetSubjectSiteAssignmentBySubjectSiteAssignmentUid([FromBody][SwaggerRequestBody(Required = true)] GetSubjectSiteAssignmentBySubjectSiteAssignmentUidRequest args) {
      try {
        var response = new GetSubjectSiteAssignmentBySubjectSiteAssignmentUidResponse();
        response.@return = _SubjectSiteAssignments.GetSubjectSiteAssignmentBySubjectSiteAssignmentUid(
          args.subjectSiteAssignmentUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetSubjectSiteAssignmentBySubjectSiteAssignmentUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads SubjectSiteAssignments. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetSubjectSiteAssignments")]
    [HttpPost("getSubjectSiteAssignments"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetSubjectSiteAssignments), Description = "Loads SubjectSiteAssignments.")]
    public GetSubjectSiteAssignmentsResponse GetSubjectSiteAssignments([FromBody][SwaggerRequestBody(Required = true)] GetSubjectSiteAssignmentsRequest args) {
      try {
        var response = new GetSubjectSiteAssignmentsResponse();
        response.@return = _SubjectSiteAssignments.GetSubjectSiteAssignments(
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetSubjectSiteAssignmentsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads SubjectSiteAssignments where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-SearchSubjectSiteAssignments")]
    [HttpPost("searchSubjectSiteAssignments"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchSubjectSiteAssignments), Description = "Loads SubjectSiteAssignments where values matching to the given filterExpression")]
    public SearchSubjectSiteAssignmentsResponse SearchSubjectSiteAssignments([FromBody][SwaggerRequestBody(Required = true)] SearchSubjectSiteAssignmentsRequest args) {
      try {
        var response = new SearchSubjectSiteAssignmentsResponse();
        response.@return = _SubjectSiteAssignments.SearchSubjectSiteAssignments(
          args.filterExpression,
          args.sortingExpression,
          (args.page.HasValue ? args.page.Value : 1),
          (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchSubjectSiteAssignmentsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new SubjectSiteAssignment and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-AddNewSubjectSiteAssignment")]
    [HttpPost("addNewSubjectSiteAssignment"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewSubjectSiteAssignment), Description = "Adds a new SubjectSiteAssignment and returns its primary identifier (or null on failure).")]
    public AddNewSubjectSiteAssignmentResponse AddNewSubjectSiteAssignment([FromBody][SwaggerRequestBody(Required = true)] AddNewSubjectSiteAssignmentRequest args) {
      try {
        var response = new AddNewSubjectSiteAssignmentResponse();
        response.@return = _SubjectSiteAssignments.AddNewSubjectSiteAssignment(
          args.subjectSiteAssignment
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewSubjectSiteAssignmentResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectSiteAssignment addressed by the primary identifier fields within the given SubjectSiteAssignment. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateSubjectSiteAssignment")]
    [HttpPost("updateSubjectSiteAssignment"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateSubjectSiteAssignment), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given SubjectSiteAssignment addressed by the primary identifier fields within the given SubjectSiteAssignment. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateSubjectSiteAssignmentResponse UpdateSubjectSiteAssignment([FromBody][SwaggerRequestBody(Required = true)] UpdateSubjectSiteAssignmentRequest args) {
      try {
        var response = new UpdateSubjectSiteAssignmentResponse();
        response.@return = _SubjectSiteAssignments.UpdateSubjectSiteAssignment(
          args.subjectSiteAssignment
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateSubjectSiteAssignmentResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectSiteAssignment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateSubjectSiteAssignmentBySubjectSiteAssignmentUid")]
    [HttpPost("updateSubjectSiteAssignmentBySubjectSiteAssignmentUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateSubjectSiteAssignmentBySubjectSiteAssignmentUid), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given SubjectSiteAssignment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateSubjectSiteAssignmentBySubjectSiteAssignmentUidResponse UpdateSubjectSiteAssignmentBySubjectSiteAssignmentUid([FromBody][SwaggerRequestBody(Required = true)] UpdateSubjectSiteAssignmentBySubjectSiteAssignmentUidRequest args) {
      try {
        var response = new UpdateSubjectSiteAssignmentBySubjectSiteAssignmentUidResponse();
        response.@return = _SubjectSiteAssignments.UpdateSubjectSiteAssignmentBySubjectSiteAssignmentUid(
          args.subjectSiteAssignmentUid,
          args.subjectSiteAssignment
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateSubjectSiteAssignmentBySubjectSiteAssignmentUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific SubjectSiteAssignment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-DeleteSubjectSiteAssignmentBySubjectSiteAssignmentUid")]
    [HttpPost("deleteSubjectSiteAssignmentBySubjectSiteAssignmentUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteSubjectSiteAssignmentBySubjectSiteAssignmentUid), Description = "Deletes a specific SubjectSiteAssignment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteSubjectSiteAssignmentBySubjectSiteAssignmentUidResponse DeleteSubjectSiteAssignmentBySubjectSiteAssignmentUid([FromBody][SwaggerRequestBody(Required = true)] DeleteSubjectSiteAssignmentBySubjectSiteAssignmentUidRequest args) {
      try {
        var response = new DeleteSubjectSiteAssignmentBySubjectSiteAssignmentUidResponse();
        response.@return = _SubjectSiteAssignments.DeleteSubjectSiteAssignmentBySubjectSiteAssignmentUid(
          args.subjectSiteAssignmentUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteSubjectSiteAssignmentBySubjectSiteAssignmentUidResponse { fault = ex.Message };
      }
    }
    
  }
  
}
