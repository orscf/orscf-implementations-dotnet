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
  
  namespace InstituteRegistryService {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("instituteRegistryService")]
    public class InstituteRegistryServiceController : ControllerBase {
      
      private readonly ILogger<InstituteRegistryServiceController> _Logger;
      private readonly IInstituteRegistryService _InstituteRegistryService;
      
      public InstituteRegistryServiceController(ILogger<InstituteRegistryServiceController> logger, IInstituteRegistryService instituteRegistryService) {
        _Logger = logger;
        _InstituteRegistryService = instituteRegistryService;
      }
      
      /// <summary> GetInstituteUidByTitle </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-GetInstituteUidByTitle")]
      [HttpPost("getInstituteUidByTitle"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetInstituteUidByTitle), Description = "GetInstituteUidByTitle")]
      public GetInstituteUidByTitleResponse GetInstituteUidByTitle([FromBody][SwaggerRequestBody(Required = true)]  GetInstituteUidByTitleRequest args) {
        try {
          var response = new GetInstituteUidByTitleResponse();
          response.@return = _InstituteRegistryService.GetInstituteUidByTitle(
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
      public GetInstituteTitleByUidResponse GetInstituteTitleByUid([FromBody][SwaggerRequestBody(Required = true)]  GetInstituteTitleByUidRequest args) {
        try {
          var response = new GetInstituteTitleByUidResponse();
          response.@return = _InstituteRegistryService.GetInstituteTitleByUid(
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
      public ArchiveInstituteResponse ArchiveInstitute([FromBody][SwaggerRequestBody(Required = true)]  ArchiveInstituteRequest args) {
        try {
          var response = new ArchiveInstituteResponse();
          response.@return = _InstituteRegistryService.ArchiveInstitute(
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
      public GetInstituteInfosResponse GetInstituteInfos([FromBody][SwaggerRequestBody(Required = true)]  GetInstituteInfosRequest args) {
        try {
          var response = new GetInstituteInfosResponse();
          response.@return = _InstituteRegistryService.GetInstituteInfos(
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
      public CreateInstituteIfMissingResponse CreateInstituteIfMissing([FromBody][SwaggerRequestBody(Required = true)]  CreateInstituteIfMissingRequest args) {
        try {
          var response = new CreateInstituteIfMissingResponse();
          response.@return = _InstituteRegistryService.CreateInstituteIfMissing(
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
      public UpdateInstitueTitleResponse UpdateInstitueTitle([FromBody][SwaggerRequestBody(Required = true)]  UpdateInstitueTitleRequest args) {
        try {
          var response = new UpdateInstitueTitleResponse();
          response.@return = _InstituteRegistryService.UpdateInstitueTitle(
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
      
      /// <summary> returns the Version of the API itself, which can be used for backward compatibility within inhomogeneous infrastructures </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-GetApiVersion")]
      [HttpPost("getApiVersion"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetApiVersion), Description = "returns the Version of the API itself, which can be used for backward compatibility within inhomogeneous infrastructures")]
      public GetApiVersionResponse GetApiVersion([FromBody][SwaggerRequestBody(Required = true)]  GetApiVersionRequest args) {
        try {
          var response = new GetApiVersionResponse();
          response.@return = _InstituteRegistryService.GetApiVersion(
          
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
      [SwaggerOperation(OperationId = nameof(HasAccess), Description = "returns if the authenticated accessor of the API has the permission to use this service")]
      public HasAccessResponse HasAccess([FromBody][SwaggerRequestBody(Required = true)]  HasAccessRequest args) {
        try {
          var response = new HasAccessResponse();
          response.@return = _InstituteRegistryService.HasAccess(
          
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
  
  namespace SiteParticipationService {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("siteParticipationService")]
    public class SiteParticipationServiceController : ControllerBase {
      
      private readonly ILogger<SiteParticipationServiceController> _Logger;
      private readonly ISiteParticipationService _SiteParticipationService;
      
      public SiteParticipationServiceController(ILogger<SiteParticipationServiceController> logger, ISiteParticipationService siteParticipationService) {
        _Logger = logger;
        _SiteParticipationService = siteParticipationService;
      }
      
      /// <summary> returns the Version of the API itself, which can be used for backward compatibility within inhomogeneous infrastructures </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-GetApiVersion")]
      [HttpPost("getApiVersion"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetApiVersion), Description = "returns the Version of the API itself, which can be used for backward compatibility within inhomogeneous infrastructures")]
      public GetApiVersionResponse GetApiVersion([FromBody][SwaggerRequestBody(Required = true)]  GetApiVersionRequest args) {
        try {
          var response = new GetApiVersionResponse();
          response.@return = _SiteParticipationService.GetApiVersion(
          
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
      [SwaggerOperation(OperationId = nameof(HasAccess), Description = "returns if the authenticated accessor of the API has the permission to use this service")]
      public HasAccessResponse HasAccess([FromBody][SwaggerRequestBody(Required = true)]  HasAccessRequest args) {
        try {
          var response = new HasAccessResponse();
          response.@return = _SiteParticipationService.HasAccess(
          
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
  
  namespace StudyAccessService {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("studyAccessService")]
    public class StudyAccessServiceController : ControllerBase {
      
      private readonly ILogger<StudyAccessServiceController> _Logger;
      private readonly IStudyAccessService _StudyAccessService;
      
      public StudyAccessServiceController(ILogger<StudyAccessServiceController> logger, IStudyAccessService studyAccessService) {
        _Logger = logger;
        _StudyAccessService = studyAccessService;
      }
      
      /// <summary> Subscribes the Event when the State of a Study was changed to the given "EventQueue" which is accessable via "EventQueueService" (including http notifications) </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-SubscribeStudyStateChangedEvents")]
      [HttpPost("subscribeStudyStateChangedEvents"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(SubscribeStudyStateChangedEvents), Description = "Subscribes the Event when the State of a Study was changed to the given \"EventQueue\" which is accessable via \"EventQueueService\" (including http notifications)")]
      public SubscribeStudyStateChangedEventsResponse SubscribeStudyStateChangedEvents([FromBody][SwaggerRequestBody(Required = true)]  SubscribeStudyStateChangedEventsRequest args) {
        try {
          var response = new SubscribeStudyStateChangedEventsResponse();
          response.@return = _StudyAccessService.SubscribeStudyStateChangedEvents(
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
      public UnsubscribeStudyStateChangedEventsResponse UnsubscribeStudyStateChangedEvents([FromBody][SwaggerRequestBody(Required = true)]  UnsubscribeStudyStateChangedEventsRequest args) {
        try {
          var response = new UnsubscribeStudyStateChangedEventsResponse();
          response.@return = _StudyAccessService.UnsubscribeStudyStateChangedEvents(
          args.eventQueueId
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new UnsubscribeStudyStateChangedEventsResponse { fault = ex.Message };
        }
      }
      
      /// <summary> returns the Version of the API itself, which can be used for backward compatibility within inhomogeneous infrastructures </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-GetApiVersion")]
      [HttpPost("getApiVersion"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetApiVersion), Description = "returns the Version of the API itself, which can be used for backward compatibility within inhomogeneous infrastructures")]
      public GetApiVersionResponse GetApiVersion([FromBody][SwaggerRequestBody(Required = true)]  GetApiVersionRequest args) {
        try {
          var response = new GetApiVersionResponse();
          response.@return = _StudyAccessService.GetApiVersion(
          
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
      [SwaggerOperation(OperationId = nameof(HasAccess), Description = "returns if the authenticated accessor of the API has the permission to use this service")]
      public HasAccessResponse HasAccess([FromBody][SwaggerRequestBody(Required = true)]  HasAccessRequest args) {
        try {
          var response = new HasAccessResponse();
          response.@return = _StudyAccessService.HasAccess(
          
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
  
  namespace StudySetupService {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("studySetupService")]
    public class StudySetupServiceController : ControllerBase {
      
      private readonly ILogger<StudySetupServiceController> _Logger;
      private readonly IStudySetupService _StudySetupService;
      
      public StudySetupServiceController(ILogger<StudySetupServiceController> logger, IStudySetupService studySetupService) {
        _Logger = logger;
        _StudySetupService = studySetupService;
      }
      
      /// <summary> returns null, if there is no matching record </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-GetStudyTitleByIdentifier")]
      [HttpPost("getStudyTitleByIdentifier"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetStudyTitleByIdentifier), Description = "returns null, if there is no matching record")]
      public GetStudyTitleByIdentifierResponse GetStudyTitleByIdentifier([FromBody][SwaggerRequestBody(Required = true)]  GetStudyTitleByIdentifierRequest args) {
        try {
          var response = new GetStudyTitleByIdentifierResponse();
          response.@return = _StudySetupService.GetStudyTitleByIdentifier(
          args.studyIdentifier
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetStudyTitleByIdentifierResponse { fault = ex.Message };
        }
      }
      
      /// <summary> returns the Version of the API itself, which can be used for backward compatibility within inhomogeneous infrastructures </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [RequireBaererAuth("store-GetApiVersion")]
      [HttpPost("getApiVersion"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetApiVersion), Description = "returns the Version of the API itself, which can be used for backward compatibility within inhomogeneous infrastructures")]
      public GetApiVersionResponse GetApiVersion([FromBody][SwaggerRequestBody(Required = true)]  GetApiVersionRequest args) {
        try {
          var response = new GetApiVersionResponse();
          response.@return = _StudySetupService.GetApiVersion(
          
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
      [SwaggerOperation(OperationId = nameof(HasAccess), Description = "returns if the authenticated accessor of the API has the permission to use this service")]
      public HasAccessResponse HasAccess([FromBody][SwaggerRequestBody(Required = true)]  HasAccessRequest args) {
        try {
          var response = new HasAccessResponse();
          response.@return = _StudySetupService.HasAccess(
          
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
  
}
