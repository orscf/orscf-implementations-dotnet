using MedicalResearch.SubjectData;
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
  [ApiExplorerSettings(GroupName = "ApiV1")]
  [Route("subjectParticipationService")]
  public partial class SubjectParticipationServiceController : ControllerBase {
    
    private readonly ILogger<SubjectParticipationServiceController> _Logger;
    private readonly ISubjectParticipationService _SubjectParticipationService;
    
    public SubjectParticipationServiceController(ILogger<SubjectParticipationServiceController> logger, ISubjectParticipationService subjectParticipationService) {
      _Logger = logger;
      _SubjectParticipationService = subjectParticipationService;
    }
    
    /// <summary> returns the Version of the API itself, which can be used for backward compatibility within inhomogeneous infrastructures </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetApiVersion")]
    [HttpPost("getApiVersion"), Produces("application/json")]
    public GetApiVersionResponse GetApiVersion([FromBody][SwaggerRequestBody(Required = true)] GetApiVersionRequest args) {
      try {
        var response = new GetApiVersionResponse();
        response.@return = _SubjectParticipationService.GetApiVersion(
        
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetApiVersionResponse { fault = ex.Message };
      }
    }
    
    /// <summary> returns if the authenticated accessor of the API has the permission to use this service </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-HasAccess")]
    [HttpPost("hasAccess"), Produces("application/json")]
    public HasAccessResponse HasAccess([FromBody][SwaggerRequestBody(Required = true)] HasAccessRequest args) {
      try {
        var response = new HasAccessResponse();
        response.@return = _SubjectParticipationService.HasAccess(
        
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new HasAccessResponse { fault = ex.Message };
      }
    }
    
  }
  
}
