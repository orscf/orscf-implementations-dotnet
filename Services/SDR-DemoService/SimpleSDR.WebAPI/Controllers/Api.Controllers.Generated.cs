/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

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
  
  namespace SdrApiInfo {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("sdrApiInfo")]
    public class SdrApiInfoController : ControllerBase {
      
      private readonly ILogger<SdrApiInfoController> _Logger;
      private readonly ISdrApiInfoService _SdrApiInfo;
      
      public SdrApiInfoController(ILogger<SdrApiInfoController> logger, ISdrApiInfoService sdrApiInfo) {
        _Logger = logger;
        _SdrApiInfo = sdrApiInfo;
      }
      
      /// <summary> returns the version of the ORSCF specification which is implemented by this API, (this can be used for backward compatibility within inhomogeneous infrastructures) </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-GetApiVersion")]
      [HttpPost("getApiVersion"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetApiVersion), Description = "returns the version of the ORSCF specification which is implemented by this API, (this can be used for backward compatibility within inhomogeneous infrastructures)")]
      public GetApiVersionResponse GetApiVersion([FromBody][SwaggerRequestBody(Required = true)] GetApiVersionRequest args) {
        try {
          var response = new GetApiVersionResponse();
          response.@return = _SdrApiInfo.GetApiVersion(
            
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetApiVersionResponse { fault = ex.Message };
        }
      }
      
      /// <summary> returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'SubjectOverview', 'SubjectEnrollment', 'ParticipationStateMgmt' </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-GetCapabilities")]
      [HttpPost("getCapabilities"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetCapabilities), Description = "returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'SubjectOverview', 'SubjectEnrollment', 'ParticipationStateMgmt'")]
      public GetCapabilitiesResponse GetCapabilities([FromBody][SwaggerRequestBody(Required = true)] GetCapabilitiesRequest args) {
        try {
          var response = new GetCapabilitiesResponse();
          response.@return = _SdrApiInfo.GetCapabilities(
            
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetCapabilitiesResponse { fault = ex.Message };
        }
      }
      
      /// <summary> returns a list of available capabilities ("API:SubjectOverview") and/or data-scopes ("Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72") which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be: 0=auth needed / 1=authenticated / -1=auth expired / -2=auth invalid/disabled </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-GetPermittedAuthScopes")]
      [HttpPost("getPermittedAuthScopes"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetPermittedAuthScopes), Description = "returns a list of available capabilities (\"API:SubjectOverview\") and/or data-scopes (\"Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72\") which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be: 0=auth needed / 1=authenticated / -1=auth expired / -2=auth invalid/disabled")]
      public GetPermittedAuthScopesResponse GetPermittedAuthScopes([FromBody][SwaggerRequestBody(Required = true)] GetPermittedAuthScopesRequest args) {
        try {
          var response = new GetPermittedAuthScopesResponse();
          response.@return = _SdrApiInfo.GetPermittedAuthScopes(
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
      [RequireBaererAuth("store-GetOAuthTokenRequestUrl")]
      [HttpPost("getOAuthTokenRequestUrl"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetOAuthTokenRequestUrl), Description = "OPTIONAL: If the authentication on the current service is mapped using tokens and should provide information about the source at this point, the login URL to be called up via browser (OAuth <see href=\"https://openid.net/specs/openid-client-initiated-backchannel-authentication-core-1_0.html\">'CIBA-Flow'</see>) is returned here.")]
      public GetOAuthTokenRequestUrlResponse GetOAuthTokenRequestUrl([FromBody][SwaggerRequestBody(Required = true)] GetOAuthTokenRequestUrlRequest args) {
        try {
          var response = new GetOAuthTokenRequestUrlResponse();
          response.@return = _SdrApiInfo.GetOAuthTokenRequestUrl(
            
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetOAuthTokenRequestUrlResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
  namespace ParticipationStateMgmt {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("participationStateMgmt")]
    public class ParticipationStateMgmtController : ControllerBase {
      
      private readonly ILogger<ParticipationStateMgmtController> _Logger;
      private readonly IParticipationStateMgmtService _ParticipationStateMgmt;
      
      public ParticipationStateMgmtController(ILogger<ParticipationStateMgmtController> logger, IParticipationStateMgmtService participationStateMgmt) {
        _Logger = logger;
        _ParticipationStateMgmt = participationStateMgmt;
      }
      
    }
    
  }
  
  namespace SubjectEnrollment {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("subjectEnrollment")]
    public class SubjectEnrollmentController : ControllerBase {
      
      private readonly ILogger<SubjectEnrollmentController> _Logger;
      private readonly ISubjectEnrollmentService _SubjectEnrollment;
      
      public SubjectEnrollmentController(ILogger<SubjectEnrollmentController> logger, ISubjectEnrollmentService subjectEnrollment) {
        _Logger = logger;
        _SubjectEnrollment = subjectEnrollment;
      }
      
      /// <summary> returns the null on failure or the assigned SubjectIdentifier on success </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-EnrollIdentityAsSubject")]
      [HttpPost("enrollIdentityAsSubject"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(EnrollIdentityAsSubject), Description = "returns the null on failure or the assigned SubjectIdentifier on success")]
      public EnrollIdentityAsSubjectResponse EnrollIdentityAsSubject([FromBody][SwaggerRequestBody(Required = true)] EnrollIdentityAsSubjectRequest args) {
        try {
          var response = new EnrollIdentityAsSubjectResponse();
          response.@return = _SubjectEnrollment.EnrollIdentityAsSubject(
            args.researchStudyName,
            args.siteName,
            args.dateOfEnrollment,
            args.details,
            args.preDefinedSubjectId
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new EnrollIdentityAsSubjectResponse { fault = ex.Message };
        }
      }
      
      /// <summary> UpdateIdentityInformationBySubjectId </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-UpdateIdentityInformationBySubjectId")]
      [HttpPost("updateIdentityInformationBySubjectId"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(UpdateIdentityInformationBySubjectId), Description = "UpdateIdentityInformationBySubjectId")]
      public UpdateIdentityInformationBySubjectIdResponse UpdateIdentityInformationBySubjectId([FromBody][SwaggerRequestBody(Required = true)] UpdateIdentityInformationBySubjectIdRequest args) {
        try {
          var response = new UpdateIdentityInformationBySubjectIdResponse();
          response.@return = _SubjectEnrollment.UpdateIdentityInformationBySubjectId(
            args.researchStudyName,
            args.subjectId,
            args.newDetails,
            (args.clearUnsuppliedValues.HasValue ? args.clearUnsuppliedValues.Value : false),
            args.newSiteName
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new UpdateIdentityInformationBySubjectIdResponse { fault = ex.Message };
        }
      }
      
      /// <summary> GetSiteNameBySubjectId </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-GetSiteNameBySubjectId")]
      [HttpPost("getSiteNameBySubjectId"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetSiteNameBySubjectId), Description = "GetSiteNameBySubjectId")]
      public GetSiteNameBySubjectIdResponse GetSiteNameBySubjectId([FromBody][SwaggerRequestBody(Required = true)] GetSiteNameBySubjectIdRequest args) {
        try {
          var response = new GetSiteNameBySubjectIdResponse();
          response.@return = _SubjectEnrollment.GetSiteNameBySubjectId(
            args.researchStudyName,
            args.subjectId
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetSiteNameBySubjectIdResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
  namespace SubjectOverview {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("subjectOverview")]
    public class SubjectOverviewController : ControllerBase {
      
      private readonly ILogger<SubjectOverviewController> _Logger;
      private readonly ISubjectOverviewService _SubjectOverview;
      
      public SubjectOverviewController(ILogger<SubjectOverviewController> logger, ISubjectOverviewService subjectOverview) {
        _Logger = logger;
        _SubjectOverview = subjectOverview;
      }
      
    }
    
  }
  
}
