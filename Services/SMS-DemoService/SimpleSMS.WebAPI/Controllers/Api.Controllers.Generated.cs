/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.StudyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Security;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MedicalResearch.StudyManagement.WebAPI {
  
  namespace InstituteMgmt {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("instituteMgmt")]
    public partial class InstituteMgmtController : ControllerBase {
      
      private readonly ILogger<InstituteMgmtController> _Logger;
      private readonly IInstituteMgmtService _InstituteMgmt;
      
      public InstituteMgmtController(ILogger<InstituteMgmtController> logger, IInstituteMgmtService instituteMgmt) {
        _Logger = logger;
        _InstituteMgmt = instituteMgmt;
      }
      
      /// <summary> GetInstituteUidByTitle </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-GetInstituteUidByTitle")]
      [HttpPost("getInstituteUidByTitle"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetInstituteUidByTitle), Description = "GetInstituteUidByTitle")]
      public GetInstituteUidByTitleResponse GetInstituteUidByTitle([FromBody][SwaggerRequestBody(Required = true)] GetInstituteUidByTitleRequest args) {
        try {
          var response = new GetInstituteUidByTitleResponse();
          response.@return = _InstituteMgmt.GetInstituteUidByTitle(
            args.instituteTitle
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetInstituteUidByTitleResponse { fault = ex.Message };
        }
      }
      
      /// <summary> GetInstituteTitleByUid </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-GetInstituteTitleByUid")]
      [HttpPost("getInstituteTitleByUid"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetInstituteTitleByUid), Description = "GetInstituteTitleByUid")]
      public GetInstituteTitleByUidResponse GetInstituteTitleByUid([FromBody][SwaggerRequestBody(Required = true)] GetInstituteTitleByUidRequest args) {
        try {
          var response = new GetInstituteTitleByUidResponse();
          response.@return = _InstituteMgmt.GetInstituteTitleByUid(
            args.instituteUid
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetInstituteTitleByUidResponse { fault = ex.Message };
        }
      }
      
      /// <summary> ArchiveInstitute </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-ArchiveInstitute")]
      [HttpPost("archiveInstitute"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(ArchiveInstitute), Description = "ArchiveInstitute")]
      public ArchiveInstituteResponse ArchiveInstitute([FromBody][SwaggerRequestBody(Required = true)] ArchiveInstituteRequest args) {
        try {
          var response = new ArchiveInstituteResponse();
          response.@return = _InstituteMgmt.ArchiveInstitute(
            args.instituteUid
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new ArchiveInstituteResponse { fault = ex.Message };
        }
      }
      
      /// <summary> GetInstituteInfos </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-GetInstituteInfos")]
      [HttpPost("getInstituteInfos"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetInstituteInfos), Description = "GetInstituteInfos")]
      public GetInstituteInfosResponse GetInstituteInfos([FromBody][SwaggerRequestBody(Required = true)] GetInstituteInfosRequest args) {
        try {
          var response = new GetInstituteInfosResponse();
          response.@return = _InstituteMgmt.GetInstituteInfos(
            args.instituteUid
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetInstituteInfosResponse { fault = ex.Message };
        }
      }
      
      /// <summary> ensures, that an institute with the given Uid exists and returns true, if it has been newly created </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-CreateInstituteIfMissing")]
      [HttpPost("createInstituteIfMissing"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(CreateInstituteIfMissing), Description = "ensures, that an institute with the given Uid exists and returns true, if it has been newly created")]
      public CreateInstituteIfMissingResponse CreateInstituteIfMissing([FromBody][SwaggerRequestBody(Required = true)] CreateInstituteIfMissingRequest args) {
        try {
          var response = new CreateInstituteIfMissingResponse();
          response.@return = _InstituteMgmt.CreateInstituteIfMissing(
            args.instituteUid
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new CreateInstituteIfMissingResponse { fault = ex.Message };
        }
      }
      
      /// <summary> updated the title of the the institute or returns false, if there is no record for the given instituteUid </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-UpdateInstitueTitle")]
      [HttpPost("updateInstitueTitle"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(UpdateInstitueTitle), Description = "updated the title of the the institute or returns false, if there is no record for the given instituteUid")]
      public UpdateInstitueTitleResponse UpdateInstitueTitle([FromBody][SwaggerRequestBody(Required = true)] UpdateInstitueTitleRequest args) {
        try {
          var response = new UpdateInstitueTitleResponse();
          response.@return = _InstituteMgmt.UpdateInstitueTitle(
            args.instituteUid,
            args.newTitle
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new UpdateInstitueTitleResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
  namespace SiteParticipation {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("siteParticipation")]
    public partial class SiteParticipationController : ControllerBase {
      
      private readonly ILogger<SiteParticipationController> _Logger;
      private readonly ISiteParticipationService _SiteParticipation;
      
      public SiteParticipationController(ILogger<SiteParticipationController> logger, ISiteParticipationService siteParticipation) {
        _Logger = logger;
        _SiteParticipation = siteParticipation;
      }
      
    }
    
  }
  
  namespace SmsApiInfo {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("smsApiInfo")]
    public partial class SmsApiInfoController : ControllerBase {
      
      private readonly ILogger<SmsApiInfoController> _Logger;
      private readonly ISmsApiInfoService _SmsApiInfo;
      
      public SmsApiInfoController(ILogger<SmsApiInfoController> logger, ISmsApiInfoService smsApiInfo) {
        _Logger = logger;
        _SmsApiInfo = smsApiInfo;
      }
      
      /// <summary> returns the version of the ORSCF specification which is implemented by this API, (this can be used for backward compatibility within inhomogeneous infrastructures) </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-GetApiVersion")]
      [HttpPost("getApiVersion"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetApiVersion), Description = "returns the version of the ORSCF specification which is implemented by this API, (this can be used for backward compatibility within inhomogeneous infrastructures)")]
      public GetApiVersionResponse GetApiVersion([FromBody][SwaggerRequestBody(Required = true)] GetApiVersionRequest args) {
        try {
          var response = new GetApiVersionResponse();
          response.@return = _SmsApiInfo.GetApiVersion(
            
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetApiVersionResponse { fault = ex.Message };
        }
      }
      
      /// <summary> returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'InstituteMgmt', 'StudySetup', 'StudyAccess', 'SiteParticipation' </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-GetCapabilities")]
      [HttpPost("getCapabilities"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetCapabilities), Description = "returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'InstituteMgmt', 'StudySetup', 'StudyAccess', 'SiteParticipation'")]
      public GetCapabilitiesResponse GetCapabilities([FromBody][SwaggerRequestBody(Required = true)] GetCapabilitiesRequest args) {
        try {
          var response = new GetCapabilitiesResponse();
          response.@return = _SmsApiInfo.GetCapabilities(
            
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetCapabilitiesResponse { fault = ex.Message };
        }
      }
      
      /// <summary> returns a list of available capabilities ("API:StudyAccess") and/or data-scopes ("Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72") which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be: 0=auth needed / 1=authenticated / -1=auth expired / -2=auth invalid/disabled </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-GetPermittedAuthScopes")]
      [HttpPost("getPermittedAuthScopes"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetPermittedAuthScopes), Description = "returns a list of available capabilities (\"API:StudyAccess\") and/or data-scopes (\"Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72\") which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be: 0=auth needed / 1=authenticated / -1=auth expired / -2=auth invalid/disabled")]
      public GetPermittedAuthScopesResponse GetPermittedAuthScopes([FromBody][SwaggerRequestBody(Required = true)] GetPermittedAuthScopesRequest args) {
        try {
          var response = new GetPermittedAuthScopesResponse();
          response.@return = _SmsApiInfo.GetPermittedAuthScopes(
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
          response.@return = _SmsApiInfo.GetOAuthTokenRequestUrl(
            
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
  
  namespace StudyAccess {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("studyAccess")]
    public partial class StudyAccessController : ControllerBase {
      
      private readonly ILogger<StudyAccessController> _Logger;
      private readonly IStudyAccessService _StudyAccess;
      
      public StudyAccessController(ILogger<StudyAccessController> logger, IStudyAccessService studyAccess) {
        _Logger = logger;
        _StudyAccess = studyAccess;
      }
      
      /// <summary> Subscribes the Event when the State of a Study was changed to the given "EventQueue" which is accessable via "EventQueueService" (including http notifications) </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-SubscribeStudyStateChangedEvents")]
      [HttpPost("subscribeStudyStateChangedEvents"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(SubscribeStudyStateChangedEvents), Description = "Subscribes the Event when the State of a Study was changed to the given \"EventQueue\" which is accessable via \"EventQueueService\" (including http notifications)")]
      public SubscribeStudyStateChangedEventsResponse SubscribeStudyStateChangedEvents([FromBody][SwaggerRequestBody(Required = true)] SubscribeStudyStateChangedEventsRequest args) {
        try {
          var response = new SubscribeStudyStateChangedEventsResponse();
          response.@return = _StudyAccess.SubscribeStudyStateChangedEvents(
            args.eventQueueId
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new SubscribeStudyStateChangedEventsResponse { fault = ex.Message };
        }
      }
      
      /// <summary> Unsubscribes the Event when the State of a Study was changed for the given "EventQueue" </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-UnsubscribeStudyStateChangedEvents")]
      [HttpPost("unsubscribeStudyStateChangedEvents"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(UnsubscribeStudyStateChangedEvents), Description = "Unsubscribes the Event when the State of a Study was changed for the given \"EventQueue\"")]
      public UnsubscribeStudyStateChangedEventsResponse UnsubscribeStudyStateChangedEvents([FromBody][SwaggerRequestBody(Required = true)] UnsubscribeStudyStateChangedEventsRequest args) {
        try {
          var response = new UnsubscribeStudyStateChangedEventsResponse();
          response.@return = _StudyAccess.UnsubscribeStudyStateChangedEvents(
            args.eventQueueId
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new UnsubscribeStudyStateChangedEventsResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
  namespace StudySetup {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("studySetup")]
    public partial class StudySetupController : ControllerBase {
      
      private readonly ILogger<StudySetupController> _Logger;
      private readonly IStudySetupService _StudySetup;
      
      public StudySetupController(ILogger<StudySetupController> logger, IStudySetupService studySetup) {
        _Logger = logger;
        _StudySetup = studySetup;
      }
      
      /// <summary> returns null, if there is no matching record </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-GetStudyTitleByIdentifier")]
      [HttpPost("getStudyTitleByIdentifier"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetStudyTitleByIdentifier), Description = "returns null, if there is no matching record")]
      public GetStudyTitleByIdentifierResponse GetStudyTitleByIdentifier([FromBody][SwaggerRequestBody(Required = true)] GetStudyTitleByIdentifierRequest args) {
        try {
          var response = new GetStudyTitleByIdentifierResponse();
          response.@return = _StudySetup.GetStudyTitleByIdentifier(
            args.studyIdentifier
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetStudyTitleByIdentifierResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
}
