/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.VisitData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Security;
using Security.AccessTokenHandling;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MedicalResearch.VisitData.WebAPI {
  
  namespace VdrApiInfo {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("vdrApiInfo")]
    public partial class VdrApiInfoController : ControllerBase {
      
      private readonly ILogger<VdrApiInfoController> _Logger;
      private readonly IVdrApiInfoService _VdrApiInfo;
      
      public VdrApiInfoController(ILogger<VdrApiInfoController> logger, IVdrApiInfoService vdrApiInfo) {
        _Logger = logger;
        _VdrApiInfo = vdrApiInfo;
      }
      
      /// <summary> returns the version of the ORSCF specification which is implemented by this API, (this can be used for backward compatibility within inhomogeneous infrastructures) </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VdrApiInfo")]
      [HttpPost("getApiVersion"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetApiVersion), Description = "returns the version of the ORSCF specification which is implemented by this API, (this can be used for backward compatibility within inhomogeneous infrastructures)")]
      public GetApiVersionResponse GetApiVersion([FromBody][SwaggerRequestBody(Required = true)] GetApiVersionRequest args) {
        try {
          var response = new GetApiVersionResponse();
          response.@return = _VdrApiInfo.GetApiVersion(
            
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetApiVersionResponse { fault = ex.Message };
        }
      }
      
      /// <summary> returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'VdrEventSubscription', 'VisitConsume', 'VisitSubmission', 'VisitHL7Export', 'VisitHL7Import', 'DataRecordingSubmission' </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VdrApiInfo")]
      [HttpPost("getCapabilities"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetCapabilities), Description = "returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'VdrEventSubscription', 'VisitConsume', 'VisitSubmission', 'VisitHL7Export', 'VisitHL7Import', 'DataRecordingSubmission'")]
      public GetCapabilitiesResponse GetCapabilities([FromBody][SwaggerRequestBody(Required = true)] GetCapabilitiesRequest args) {
        try {
          var response = new GetCapabilitiesResponse();
          response.@return = _VdrApiInfo.GetCapabilities(
            
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetCapabilitiesResponse { fault = ex.Message };
        }
      }
      
      /// <summary> returns a list of available capabilities ("API:VisitDataConsume") and/or data-scopes ("Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72") which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be: 0=auth needed / 1=authenticated / -1=auth expired / -2=auth invalid/disabled </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VdrApiInfo")]
      [HttpPost("getPermittedAuthScopes"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetPermittedAuthScopes), Description = "returns a list of available capabilities (\"API:VisitDataConsume\") and/or data-scopes (\"Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72\") which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be: 0=auth needed / 1=authenticated / -1=auth expired / -2=auth invalid/disabled")]
      public GetPermittedAuthScopesResponse GetPermittedAuthScopes([FromBody][SwaggerRequestBody(Required = true)] GetPermittedAuthScopesRequest args) {
        try {
          var response = new GetPermittedAuthScopesResponse();
          response.@return = _VdrApiInfo.GetPermittedAuthScopes(
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
      [EvaluateBearerToken("VdrApiInfo")]
      [HttpPost("getOAuthTokenRequestUrl"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetOAuthTokenRequestUrl), Description = "OPTIONAL: If the authentication on the current service is mapped using tokens and should provide information about the source at this point, the login URL to be called up via browser (OAuth <see href=\"https://openid.net/specs/openid-client-initiated-backchannel-authentication-core-1_0.html\">'CIBA-Flow'</see>) is returned here.")]
      public GetOAuthTokenRequestUrlResponse GetOAuthTokenRequestUrl([FromBody][SwaggerRequestBody(Required = true)] GetOAuthTokenRequestUrlRequest args) {
        try {
          var response = new GetOAuthTokenRequestUrlResponse();
          response.@return = _VdrApiInfo.GetOAuthTokenRequestUrl(
            
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
  
  namespace VdrEventSubscription {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("vdrEventSubscription")]
    public partial class VdrEventSubscriptionController : ControllerBase {
      
      private readonly ILogger<VdrEventSubscriptionController> _Logger;
      private readonly IVdrEventSubscriptionService _VdrEventSubscription;
      
      public VdrEventSubscriptionController(ILogger<VdrEventSubscriptionController> logger, IVdrEventSubscriptionService vdrEventSubscription) {
        _Logger = logger;
        _VdrEventSubscription = vdrEventSubscription;
      }
      
      /// <summary> Creates a subscription for changes which are affecting Visits. On success, a 'SubscriptionUid' will be returned and a call will be made to the given subscriberUrl + '/ConfirmAsSubscriber'. After the subscription has been confirmed, the requested events will be pushed to subscriberUrl + '/NoticeChangedVisits' (NOTICE: the receiving methods also are documented here, because this service itself can act as subscriber) </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VdrEventSubscription")]
      [HttpPost("subscribeForChangedVisits"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(SubscribeForChangedVisits), Description = "Creates a subscription for changes which are affecting Visits. On success, a 'SubscriptionUid' will be returned and a call will be made to the given subscriberUrl + '/ConfirmAsSubscriber'. After the subscription has been confirmed, the requested events will be pushed to subscriberUrl + '/NoticeChangedVisits' (NOTICE: the receiving methods also are documented here, because this service itself can act as subscriber)")]
      public SubscribeForChangedVisitsResponse SubscribeForChangedVisits([FromBody][SwaggerRequestBody(Required = true)] SubscribeForChangedVisitsRequest args) {
        try {
          var response = new SubscribeForChangedVisitsResponse();
          response.@return = _VdrEventSubscription.SubscribeForChangedVisits(
            args.subscriberUrl,
            args.filter
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new SubscribeForChangedVisitsResponse { fault = ex.Message };
        }
      }
      
      /// <summary> Receives notifications about changes which are affecting Visits. IMPORTANT: this method is dedicated to the usecase, when this service itself acts as a subscriber! So this can be called by an foreign service during the setup of a subscription, which was previously requested from here. The opposite case: any client subscribing to events from here, must provide its own http endpoint that has such a method! </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VdrEventSubscription")]
      [HttpPost("noticeChangedVisits"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(NoticeChangedVisits), Description = "Receives notifications about changes which are affecting Visits. IMPORTANT: this method is dedicated to the usecase, when this service itself acts as a subscriber! So this can be called by an foreign service during the setup of a subscription, which was previously requested from here. The opposite case: any client subscribing to events from here, must provide its own http endpoint that has such a method!")]
      public NoticeChangedVisitsResponse NoticeChangedVisits([FromBody][SwaggerRequestBody(Required = true)] NoticeChangedVisitsRequest args) {
        try {
          var response = new NoticeChangedVisitsResponse();
          _VdrEventSubscription.NoticeChangedVisits(
            args.eventUid,
            args.eventSignature,
            args.subscriptionUid,
            args.publisherUrl,
            args.createdRecords,
            args.modifiedRecords,
            args.archivedRecords,
            out var terminateSubscriptionBuffer
          );
          response.terminateSubscription = terminateSubscriptionBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new NoticeChangedVisitsResponse { fault = ex.Message };
        }
      }
      
      /// <summary> Confirms a Subscription. IMPORTANT: this method is dedicated to the usecase, when this service itself acts as a subscriber! So this can be called by an foreign service during the setup of a subscription, which was previously requested from here. The opposite case: any client subscribing to events from here, must provide its own http endpoint that has such a method! </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VdrEventSubscription")]
      [HttpPost("confirmAsSubscriber"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(ConfirmAsSubscriber), Description = "Confirms a Subscription. IMPORTANT: this method is dedicated to the usecase, when this service itself acts as a subscriber! So this can be called by an foreign service during the setup of a subscription, which was previously requested from here. The opposite case: any client subscribing to events from here, must provide its own http endpoint that has such a method!")]
      public ConfirmAsSubscriberResponse ConfirmAsSubscriber([FromBody][SwaggerRequestBody(Required = true)] ConfirmAsSubscriberRequest args) {
        try {
          var response = new ConfirmAsSubscriberResponse();
          _VdrEventSubscription.ConfirmAsSubscriber(
            args.publisherUrl,
            args.subscriptionUid,
            out var secretBuffer
          );
          response.secret = secretBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new ConfirmAsSubscriberResponse { fault = ex.Message };
        }
      }
      
      /// <summary> Terminates a subscription (on publisher side) and returns a boolean, which indicates success. </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VdrEventSubscription")]
      [HttpPost("terminateSubscription"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(TerminateSubscription), Description = "Terminates a subscription (on publisher side) and returns a boolean, which indicates success.")]
      public TerminateSubscriptionResponse TerminateSubscription([FromBody][SwaggerRequestBody(Required = true)] TerminateSubscriptionRequest args) {
        try {
          var response = new TerminateSubscriptionResponse();
          response.@return = _VdrEventSubscription.TerminateSubscription(
            args.subscriptionUid,
            args.secret
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new TerminateSubscriptionResponse { fault = ex.Message };
        }
      }
      
      /// <summary> Returns an array of subscriptionUid's. This method helps subscribers to evaluate whether current subscriptions are still active. </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VdrEventSubscription")]
      [HttpPost("getSubsriptionsBySubscriberUrl"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetSubsriptionsBySubscriberUrl), Description = "Returns an array of subscriptionUid's. This method helps subscribers to evaluate whether current subscriptions are still active.")]
      public GetSubsriptionsBySubscriberUrlResponse GetSubsriptionsBySubscriberUrl([FromBody][SwaggerRequestBody(Required = true)] GetSubsriptionsBySubscriberUrlRequest args) {
        try {
          var response = new GetSubsriptionsBySubscriberUrlResponse();
          response.@return = _VdrEventSubscription.GetSubsriptionsBySubscriberUrl(
            args.subscriberUrl,
            args.secret
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetSubsriptionsBySubscriberUrlResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
  namespace DataEnrollment {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("dataEnrollment")]
    public partial class DataEnrollmentController : ControllerBase {
      
      private readonly ILogger<DataEnrollmentController> _Logger;
      private readonly IDataEnrollmentService _DataEnrollment;
      
      public DataEnrollmentController(ILogger<DataEnrollmentController> logger, IDataEnrollmentService dataEnrollment) {
        _Logger = logger;
        _DataEnrollment = dataEnrollment;
      }
      
      /// <summary> Enrolls recorded data to be stored as 'DataRecording'-Record related to a explicitly addressed Visit inside of this repository. This goes ahead with an validation process for each enrollment, therefore a dataEnrollmentUid will be returned which can be used to query the state of this process via 'GetValidationState'. </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("DataEnrollment")]
      [HttpPost("enrollDataForVisitExplicit"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(EnrollDataForVisitExplicit), Description = "Enrolls recorded data to be stored as 'DataRecording'-Record related to a explicitly addressed Visit inside of this repository. This goes ahead with an validation process for each enrollment, therefore a dataEnrollmentUid will be returned which can be used to query the state of this process via 'GetValidationState'.")]
      public EnrollDataForVisitExplicitResponse EnrollDataForVisitExplicit([FromBody][SwaggerRequestBody(Required = true)] EnrollDataForVisitExplicitRequest args) {
        try {
          var response = new EnrollDataForVisitExplicitResponse();
          response.@return = _DataEnrollment.EnrollDataForVisitExplicit(
            args.targetvisitUid,
            args.taskExecutionTitle,
            args.executionDateTimeUtc,
            args.dataSchemaKind,
            args.dataSchemaUrl,
            args.dataSchemaVersion,
            args.dataLanguage,
            args.recordedData
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new EnrollDataForVisitExplicitResponse { fault = ex.Message };
        }
      }
      
      /// <summary> Enrolls recorded data to be stored as 'DataRecording'-Record related to a visit inside of this repository (which is implicitely resolved using the given 'visitExecutionTitle' and 'subjectIdentifier') . This goes ahead with an validation process for each enrollment, therefore a dataEnrollmentUid will be returned which can be used to query the state of this process via 'GetValidationState'. </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("DataEnrollment")]
      [HttpPost("enrollDataForVisitImplicit"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(EnrollDataForVisitImplicit), Description = "Enrolls recorded data to be stored as 'DataRecording'-Record related to a visit inside of this repository (which is implicitely resolved using the given 'visitExecutionTitle' and 'subjectIdentifier') . This goes ahead with an validation process for each enrollment, therefore a dataEnrollmentUid will be returned which can be used to query the state of this process via 'GetValidationState'.")]
      public EnrollDataForVisitImplicitResponse EnrollDataForVisitImplicit([FromBody][SwaggerRequestBody(Required = true)] EnrollDataForVisitImplicitRequest args) {
        try {
          var response = new EnrollDataForVisitImplicitResponse();
          response.@return = _DataEnrollment.EnrollDataForVisitImplicit(
            args.studyUid,
            args.subjectIdentifier,
            args.visitExecutionTitle,
            args.taskExecutionTitle,
            args.executionDateTimeUtc,
            args.dataSchemaKind,
            args.dataSchemaUrl,
            args.dataSchemaVersion,
            args.dataLanguage,
            args.recordedData
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new EnrollDataForVisitImplicitResponse { fault = ex.Message };
        }
      }
      
      /// <summary> Providing the current validation state for a given data enrollment process </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("DataEnrollment")]
      [HttpPost("getValidationState"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetValidationState), Description = "Providing the current validation state for a given data enrollment process")]
      public GetValidationStateResponse GetValidationState([FromBody][SwaggerRequestBody(Required = true)] GetValidationStateRequest args) {
        try {
          var response = new GetValidationStateResponse();
          response.@return = _DataEnrollment.GetValidationState(
            args.dataEnrollmentUid
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetValidationStateResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
  namespace DataRecordingSubmission {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("dataRecordingSubmission")]
    public partial class DataRecordingSubmissionController : ControllerBase {
      
      private readonly ILogger<DataRecordingSubmissionController> _Logger;
      private readonly IDataRecordingSubmissionService _DataRecordingSubmission;
      
      public DataRecordingSubmissionController(ILogger<DataRecordingSubmissionController> logger, IDataRecordingSubmissionService dataRecordingSubmission) {
        _Logger = logger;
        _DataRecordingSubmission = dataRecordingSubmission;
      }
      
      /// <summary> ImportDataRecordings </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("DataRecordingSubmission")]
      [HttpPost("importDataRecordings"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(ImportDataRecordings), Description = "ImportDataRecordings")]
      public ImportDataRecordingsResponse ImportDataRecordings([FromBody][SwaggerRequestBody(Required = true)] ImportDataRecordingsRequest args) {
        try {
          var response = new ImportDataRecordingsResponse();
          _DataRecordingSubmission.ImportDataRecordings(
            args.dataRecordings,
            out var createdDataRecordingUidsBuffer,
            out var updatedDataRecordingUidsBuffer
          );
          response.createdDataRecordingUids = createdDataRecordingUidsBuffer;
          response.updatedDataRecordingUids = updatedDataRecordingUidsBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new ImportDataRecordingsResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
  namespace VisitConsume {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("visitConsume")]
    public partial class VisitConsumeController : ControllerBase {
      
      private readonly ILogger<VisitConsumeController> _Logger;
      private readonly IVisitConsumeService _VisitConsume;
      
      public VisitConsumeController(ILogger<VisitConsumeController> logger, IVisitConsumeService visitConsume) {
        _Logger = logger;
        _VisitConsume = visitConsume;
      }
      
      /// <summary> Searches Visits by a given 'filter' (if provided), sorts the results by the given 'sortingField' (if provided) and returns an array of VisitUids for the matching records. </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VisitConsume")]
      [HttpPost("searchVisits"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(SearchVisits), Description = "Searches Visits by a given 'filter' (if provided), sorts the results by the given 'sortingField' (if provided) and returns an array of VisitUids for the matching records.")]
      public SearchVisitsResponse SearchVisits([FromBody][SwaggerRequestBody(Required = true)] SearchVisitsRequest args) {
        try {
          var response = new SearchVisitsResponse();
          _VisitConsume.SearchVisits(
            out var resultBuffer,
            args.sortingField,
            (args.sortDescending.HasValue ? args.sortDescending.Value : false),
            args.filter,
            (args.includeArchivedRecords.HasValue ? args.includeArchivedRecords.Value : false),
            (args.limitResults.HasValue ? args.limitResults.Value : 0)
          );
          response.result = resultBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new SearchVisitsResponse { fault = ex.Message };
        }
      }
      
      /// <summary> Searches Visits which have been modified after(or at) the given 'minTimestampUtc', matching to the given 'filter' (if provided). The result is sorted descenting by the timestamp of the modification (latest first) and will include archived records. </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VisitConsume")]
      [HttpPost("searchChangedVisits"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(SearchChangedVisits), Description = "Searches Visits which have been modified after(or at) the given 'minTimestampUtc', matching to the given 'filter' (if provided). The result is sorted descenting by the timestamp of the modification (latest first) and will include archived records.")]
      public SearchChangedVisitsResponse SearchChangedVisits([FromBody][SwaggerRequestBody(Required = true)] SearchChangedVisitsRequest args) {
        try {
          var response = new SearchChangedVisitsResponse();
          _VisitConsume.SearchChangedVisits(
            args.minTimestampUtc,
            out var latestTimestampUtcBuffer,
            out var createdRecordsBuffer,
            out var modifiedRecordsBuffer,
            out var archivedRecordsBuffer,
            args.filter
          );
          response.latestTimestampUtc = latestTimestampUtcBuffer;
          response.createdRecords = createdRecordsBuffer;
          response.modifiedRecords = modifiedRecordsBuffer;
          response.archivedRecords = archivedRecordsBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new SearchChangedVisitsResponse { fault = ex.Message };
        }
      }
      
      /// <summary> GetCustomFieldDescriptorsForVisit </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VisitConsume")]
      [HttpPost("getCustomFieldDescriptorsForVisit"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetCustomFieldDescriptorsForVisit), Description = "GetCustomFieldDescriptorsForVisit")]
      public GetCustomFieldDescriptorsForVisitResponse GetCustomFieldDescriptorsForVisit([FromBody][SwaggerRequestBody(Required = true)] GetCustomFieldDescriptorsForVisitRequest args) {
        try {
          var response = new GetCustomFieldDescriptorsForVisitResponse();
          response.@return = _VisitConsume.GetCustomFieldDescriptorsForVisit(
            args.languagePref
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetCustomFieldDescriptorsForVisitResponse { fault = ex.Message };
        }
      }
      
      /// <summary> Checks the existence of 'Visits' for a given list of visitUids </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VisitConsume")]
      [HttpPost("checkVisitExisitence"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(CheckVisitExisitence), Description = "Checks the existence of 'Visits' for a given list of visitUids")]
      public CheckVisitExisitenceResponse CheckVisitExisitence([FromBody][SwaggerRequestBody(Required = true)] CheckVisitExisitenceRequest args) {
        try {
          var response = new CheckVisitExisitenceResponse();
          _VisitConsume.CheckVisitExisitence(
            args.visitUids,
            out var unavailableVisitUidsBuffer,
            out var availableVisitUidsBuffer
          );
          response.unavailableVisitUids = unavailableVisitUidsBuffer;
          response.availableVisitUids = availableVisitUidsBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new CheckVisitExisitenceResponse { fault = ex.Message };
        }
      }
      
      /// <summary> loads the requested visits and returns lightweight json objects (without childs), which are optimized to be displayed as table (the most common UI use case). This models containig a combination of: essential fieds from the record, calculated fields (numbers of child records), custom fields (choosen by the service) </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VisitConsume")]
      [HttpPost("getVisitFields"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetVisitFields), Description = "loads the requested visits and returns lightweight json objects (without childs), which are optimized to be displayed as table (the most common UI use case). This models containig a combination of: essential fieds from the record, calculated fields (numbers of child records), custom fields (choosen by the service)")]
      public GetVisitFieldsResponse GetVisitFields([FromBody][SwaggerRequestBody(Required = true)] GetVisitFieldsRequest args) {
        try {
          var response = new GetVisitFieldsResponse();
          _VisitConsume.GetVisitFields(
            args.visitUids,
            out var unavailableVisitUidsBuffer,
            out var resultBuffer
          );
          response.unavailableVisitUids = unavailableVisitUidsBuffer;
          response.result = resultBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetVisitFieldsResponse { fault = ex.Message };
        }
      }
      
      /// <summary> exports full 'VisitStructures' </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VisitConsume")]
      [HttpPost("exportVisits"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(ExportVisits), Description = "exports full 'VisitStructures'")]
      public ExportVisitsResponse ExportVisits([FromBody][SwaggerRequestBody(Required = true)] ExportVisitsRequest args) {
        try {
          var response = new ExportVisitsResponse();
          _VisitConsume.ExportVisits(
            args.visitUids,
            out var unavailableVisitUidsBuffer,
            out var resultBuffer
          );
          response.unavailableVisitUids = unavailableVisitUidsBuffer;
          response.result = resultBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new ExportVisitsResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
  namespace VisitHL7Export {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("visitHL7Export")]
    public partial class VisitHL7ExportController : ControllerBase {
      
      private readonly ILogger<VisitHL7ExportController> _Logger;
      private readonly IVisitHL7ExportService _VisitHL7Export;
      
      public VisitHL7ExportController(ILogger<VisitHL7ExportController> logger, IVisitHL7ExportService visitHL7Export) {
        _Logger = logger;
        _VisitHL7Export = visitHL7Export;
      }
      
      /// <summary> Exports a structure containing HL7/FHIR-Ressources (JSON only) and the essential fields which are required to qualify a ORSCF record. </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VisitHL7Export")]
      [HttpPost("exportVisitFhirRessources"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(ExportVisitFhirRessources), Description = "Exports a structure containing HL7/FHIR-Ressources (JSON only) and the essential fields which are required to qualify a ORSCF record.")]
      public ExportVisitFhirRessourcesResponse ExportVisitFhirRessources([FromBody][SwaggerRequestBody(Required = true)] ExportVisitFhirRessourcesRequest args) {
        try {
          var response = new ExportVisitFhirRessourcesResponse();
          response.@return = _VisitHL7Export.ExportVisitFhirRessources(
            args.visitUid,
            out var visitFhirRessourcesBuffer
          );
          response.visitFhirRessources = visitFhirRessourcesBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new ExportVisitFhirRessourcesResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
  namespace VisitHL7Import {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("visitHL7Import")]
    public partial class VisitHL7ImportController : ControllerBase {
      
      private readonly ILogger<VisitHL7ImportController> _Logger;
      private readonly IVisitHL7ImportService _VisitHL7Import;
      
      public VisitHL7ImportController(ILogger<VisitHL7ImportController> logger, IVisitHL7ImportService visitHL7Import) {
        _Logger = logger;
        _VisitHL7Import = visitHL7Import;
      }
      
      /// <summary> Exports a structure containing HL7/FHIR-Ressources (JSON only) and the essential fields which are required to qualify a ORSCF record. </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VisitHL7Import")]
      [HttpPost("importVisitFhirRessources"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(ImportVisitFhirRessources), Description = "Exports a structure containing HL7/FHIR-Ressources (JSON only) and the essential fields which are required to qualify a ORSCF record.")]
      public ImportVisitFhirRessourcesResponse ImportVisitFhirRessources([FromBody][SwaggerRequestBody(Required = true)] ImportVisitFhirRessourcesRequest args) {
        try {
          var response = new ImportVisitFhirRessourcesResponse();
          _VisitHL7Import.ImportVisitFhirRessources(
            args.visitFhirRessources,
            out var createdVisitUidsBuffer,
            out var updatedVisitUidsBuffer
          );
          response.createdVisitUids = createdVisitUidsBuffer;
          response.updatedVisitUids = updatedVisitUidsBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new ImportVisitFhirRessourcesResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
  namespace VisitSubmission {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("visitSubmission")]
    public partial class VisitSubmissionController : ControllerBase {
      
      private readonly ILogger<VisitSubmissionController> _Logger;
      private readonly IVisitSubmissionService _VisitSubmission;
      
      public VisitSubmissionController(ILogger<VisitSubmissionController> logger, IVisitSubmissionService visitSubmission) {
        _Logger = logger;
        _VisitSubmission = visitSubmission;
      }
      
      /// <summary> ArchiveVisits </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VisitSubmission")]
      [HttpPost("archiveVisits"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(ArchiveVisits), Description = "ArchiveVisits")]
      public ArchiveVisitsResponse ArchiveVisits([FromBody][SwaggerRequestBody(Required = true)] ArchiveVisitsRequest args) {
        try {
          var response = new ArchiveVisitsResponse();
          _VisitSubmission.ArchiveVisits(
            args.visitUids,
            out var archivedVisitUidsBuffer
          );
          response.archivedVisitUids = archivedVisitUidsBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new ArchiveVisitsResponse { fault = ex.Message };
        }
      }
      
      /// <summary> UnarchiveVisits </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VisitSubmission")]
      [HttpPost("unarchiveVisits"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(UnarchiveVisits), Description = "UnarchiveVisits")]
      public UnarchiveVisitsResponse UnarchiveVisits([FromBody][SwaggerRequestBody(Required = true)] UnarchiveVisitsRequest args) {
        try {
          var response = new UnarchiveVisitsResponse();
          _VisitSubmission.UnarchiveVisits(
            args.visitUids,
            out var unarchivedVisitUidsBuffer
          );
          response.unarchivedVisitUids = unarchivedVisitUidsBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new UnarchiveVisitsResponse { fault = ex.Message };
        }
      }
      
      /// <summary> ApplyVisitMutations </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VisitSubmission")]
      [HttpPost("applyVisitMutations"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(ApplyVisitMutations), Description = "ApplyVisitMutations")]
      public ApplyVisitMutationsResponse ApplyVisitMutations([FromBody][SwaggerRequestBody(Required = true)] ApplyVisitMutationsRequest args) {
        try {
          var response = new ApplyVisitMutationsResponse();
          _VisitSubmission.ApplyVisitMutations(
            args.mutationsByVisitUid,
            out var updatedVisitUidsBuffer
          );
          response.updatedVisitUids = updatedVisitUidsBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new ApplyVisitMutationsResponse { fault = ex.Message };
        }
      }
      
      /// <summary> ApplyVisitBatchMutation </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VisitSubmission")]
      [HttpPost("applyVisitBatchMutation"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(ApplyVisitBatchMutation), Description = "ApplyVisitBatchMutation")]
      public ApplyVisitBatchMutationResponse ApplyVisitBatchMutation([FromBody][SwaggerRequestBody(Required = true)] ApplyVisitBatchMutationRequest args) {
        try {
          var response = new ApplyVisitBatchMutationResponse();
          _VisitSubmission.ApplyVisitBatchMutation(
            args.visitUids,
            args.mutation,
            out var updatedVisitUidsBuffer
          );
          response.updatedVisitUids = updatedVisitUidsBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new ApplyVisitBatchMutationResponse { fault = ex.Message };
        }
      }
      
      /// <summary> ImportVisits </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("VisitSubmission")]
      [HttpPost("importVisits"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(ImportVisits), Description = "ImportVisits")]
      public ImportVisitsResponse ImportVisits([FromBody][SwaggerRequestBody(Required = true)] ImportVisitsRequest args) {
        try {
          var response = new ImportVisitsResponse();
          _VisitSubmission.ImportVisits(
            args.visits,
            out var createdVisitUidsBuffer,
            out var updatedVisitUidsBuffer
          );
          response.createdVisitUids = createdVisitUidsBuffer;
          response.updatedVisitUids = updatedVisitUidsBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new ImportVisitsResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
}
