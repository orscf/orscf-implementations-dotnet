/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.SubjectData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Security;
using Security.AccessTokenHandling;
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
    public partial class SdrApiInfoController : ControllerBase {
      
      private readonly ILogger<SdrApiInfoController> _Logger;
      private readonly ISdrApiInfoService _SdrApiInfo;
      
      public SdrApiInfoController(ILogger<SdrApiInfoController> logger, ISdrApiInfoService sdrApiInfo) {
        _Logger = logger;
        _SdrApiInfo = sdrApiInfo;
      }
      
      /// <summary> returns the version of the ORSCF specification which is implemented by this API, (this can be used for backward compatibility within inhomogeneous infrastructures) </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("SdrApiInfo")]
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
      
      /// <summary> returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'SdrEventSubscription', 'SubjectConsume', 'SubjectSubmission', 'SubjectHL7Export' 'SubjectHL7Import' </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("SdrApiInfo")]
      [HttpPost("getCapabilities"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetCapabilities), Description = "returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'SdrEventSubscription', 'SubjectConsume', 'SubjectSubmission', 'SubjectHL7Export' 'SubjectHL7Import'")]
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
      [EvaluateBearerToken("SdrApiInfo")]
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
      [EvaluateBearerToken("SdrApiInfo")]
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
  
  namespace SdrEventSubscription {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("sdrEventSubscription")]
    public partial class SdrEventSubscriptionController : ControllerBase {
      
      private readonly ILogger<SdrEventSubscriptionController> _Logger;
      private readonly ISdrEventSubscriptionService _SdrEventSubscription;
      
      public SdrEventSubscriptionController(ILogger<SdrEventSubscriptionController> logger, ISdrEventSubscriptionService sdrEventSubscription) {
        _Logger = logger;
        _SdrEventSubscription = sdrEventSubscription;
      }
      
      /// <summary> Creates a subscription for changes which are affecting Subjects. On success, a 'SubscriptionUid' will be returned and a call will be made to the given subscriberUrl + '/ConfirmAsSubscriber'. After the subscription has been confirmed, the requested events will be pushed to subscriberUrl + '/NoticeChangedSubjects' (NOTICE: the receiving methods also are documented here, because this service itself can act as subscriber) </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("SdrEventSubscription")]
      [HttpPost("subscribeForChangedSubjects"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(SubscribeForChangedSubjects), Description = "Creates a subscription for changes which are affecting Subjects. On success, a 'SubscriptionUid' will be returned and a call will be made to the given subscriberUrl + '/ConfirmAsSubscriber'. After the subscription has been confirmed, the requested events will be pushed to subscriberUrl + '/NoticeChangedSubjects' (NOTICE: the receiving methods also are documented here, because this service itself can act as subscriber)")]
      public SubscribeForChangedSubjectsResponse SubscribeForChangedSubjects([FromBody][SwaggerRequestBody(Required = true)] SubscribeForChangedSubjectsRequest args) {
        try {
          var response = new SubscribeForChangedSubjectsResponse();
          response.@return = _SdrEventSubscription.SubscribeForChangedSubjects(
            args.subscriberUrl,
            args.filter
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new SubscribeForChangedSubjectsResponse { fault = ex.Message };
        }
      }
      
      /// <summary> Receives notifications about changes which are affecting Subjects. IMPORTANT: this method is dedicated to the usecase, when this service itself acts as a subscriber! So this can be called by an foreign service during the setup of a subscription, which was previously requested from here. The opposite case: any client subscribing to events from here, must provide its own http endpoint that has such a method! </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("SdrEventSubscription")]
      [HttpPost("noticeChangedSubjects"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(NoticeChangedSubjects), Description = "Receives notifications about changes which are affecting Subjects. IMPORTANT: this method is dedicated to the usecase, when this service itself acts as a subscriber! So this can be called by an foreign service during the setup of a subscription, which was previously requested from here. The opposite case: any client subscribing to events from here, must provide its own http endpoint that has such a method!")]
      public NoticeChangedSubjectsResponse NoticeChangedSubjects([FromBody][SwaggerRequestBody(Required = true)] NoticeChangedSubjectsRequest args) {
        try {
          var response = new NoticeChangedSubjectsResponse();
          _SdrEventSubscription.NoticeChangedSubjects(
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
          return new NoticeChangedSubjectsResponse { fault = ex.Message };
        }
      }
      
      /// <summary> Confirms a Subscription. IMPORTANT: this method is dedicated to the usecase, when this service itself acts as a subscriber! So this can be called by an foreign service during the setup of a subscription, which was previously requested from here. The opposite case: any client subscribing to events from here, must provide its own http endpoint that has such a method! </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("SdrEventSubscription")]
      [HttpPost("confirmAsSubscriber"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(ConfirmAsSubscriber), Description = "Confirms a Subscription. IMPORTANT: this method is dedicated to the usecase, when this service itself acts as a subscriber! So this can be called by an foreign service during the setup of a subscription, which was previously requested from here. The opposite case: any client subscribing to events from here, must provide its own http endpoint that has such a method!")]
      public ConfirmAsSubscriberResponse ConfirmAsSubscriber([FromBody][SwaggerRequestBody(Required = true)] ConfirmAsSubscriberRequest args) {
        try {
          var response = new ConfirmAsSubscriberResponse();
          _SdrEventSubscription.ConfirmAsSubscriber(
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
      [EvaluateBearerToken("SdrEventSubscription")]
      [HttpPost("terminateSubscription"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(TerminateSubscription), Description = "Terminates a subscription (on publisher side) and returns a boolean, which indicates success.")]
      public TerminateSubscriptionResponse TerminateSubscription([FromBody][SwaggerRequestBody(Required = true)] TerminateSubscriptionRequest args) {
        try {
          var response = new TerminateSubscriptionResponse();
          response.@return = _SdrEventSubscription.TerminateSubscription(
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
      [EvaluateBearerToken("SdrEventSubscription")]
      [HttpPost("getSubsriptionsBySubscriberUrl"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetSubsriptionsBySubscriberUrl), Description = "Returns an array of subscriptionUid's. This method helps subscribers to evaluate whether current subscriptions are still active.")]
      public GetSubsriptionsBySubscriberUrlResponse GetSubsriptionsBySubscriberUrl([FromBody][SwaggerRequestBody(Required = true)] GetSubsriptionsBySubscriberUrlRequest args) {
        try {
          var response = new GetSubsriptionsBySubscriberUrlResponse();
          response.@return = _SdrEventSubscription.GetSubsriptionsBySubscriberUrl(
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
  
  namespace SubjectConsume {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("subjectConsume")]
    public partial class SubjectConsumeController : ControllerBase {
      
      private readonly ILogger<SubjectConsumeController> _Logger;
      private readonly ISubjectConsumeService _SubjectConsume;
      
      public SubjectConsumeController(ILogger<SubjectConsumeController> logger, ISubjectConsumeService subjectConsume) {
        _Logger = logger;
        _SubjectConsume = subjectConsume;
      }
      
      /// <summary> Searches Subjects by a given 'filter' (if provided), sorts the results by the given 'sortingField' (if provided) and returns an array of SubjectUids for the matching records. </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("SubjectConsume")]
      [HttpPost("searchSubjects"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(SearchSubjects), Description = "Searches Subjects by a given 'filter' (if provided), sorts the results by the given 'sortingField' (if provided) and returns an array of SubjectUids for the matching records.")]
      public SearchSubjectsResponse SearchSubjects([FromBody][SwaggerRequestBody(Required = true)] SearchSubjectsRequest args) {
        try {
          var response = new SearchSubjectsResponse();
          _SubjectConsume.SearchSubjects(
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
          return new SearchSubjectsResponse { fault = ex.Message };
        }
      }
      
      /// <summary> Searches Subjects which have been modified after(or at) the given 'minTimestampUtc', matching to the given 'filter' (if provided). The result is sorted descenting by the timestamp of the modification (latest first) and will include archived records. </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("SubjectConsume")]
      [HttpPost("searchChangedSubjects"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(SearchChangedSubjects), Description = "Searches Subjects which have been modified after(or at) the given 'minTimestampUtc', matching to the given 'filter' (if provided). The result is sorted descenting by the timestamp of the modification (latest first) and will include archived records.")]
      public SearchChangedSubjectsResponse SearchChangedSubjects([FromBody][SwaggerRequestBody(Required = true)] SearchChangedSubjectsRequest args) {
        try {
          var response = new SearchChangedSubjectsResponse();
          _SubjectConsume.SearchChangedSubjects(
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
          return new SearchChangedSubjectsResponse { fault = ex.Message };
        }
      }
      
      /// <summary> GetCustomFieldDescriptorsForSubject </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("SubjectConsume")]
      [HttpPost("getCustomFieldDescriptorsForSubject"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetCustomFieldDescriptorsForSubject), Description = "GetCustomFieldDescriptorsForSubject")]
      public GetCustomFieldDescriptorsForSubjectResponse GetCustomFieldDescriptorsForSubject([FromBody][SwaggerRequestBody(Required = true)] GetCustomFieldDescriptorsForSubjectRequest args) {
        try {
          var response = new GetCustomFieldDescriptorsForSubjectResponse();
          response.@return = _SubjectConsume.GetCustomFieldDescriptorsForSubject(
            args.languagePref
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetCustomFieldDescriptorsForSubjectResponse { fault = ex.Message };
        }
      }
      
      /// <summary> Checks the existence of 'Subjects' for a given list of subjectUids </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("SubjectConsume")]
      [HttpPost("checkSubjectExisitence"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(CheckSubjectExisitence), Description = "Checks the existence of 'Subjects' for a given list of subjectUids")]
      public CheckSubjectExisitenceResponse CheckSubjectExisitence([FromBody][SwaggerRequestBody(Required = true)] CheckSubjectExisitenceRequest args) {
        try {
          var response = new CheckSubjectExisitenceResponse();
          _SubjectConsume.CheckSubjectExisitence(
            args.subjectUids,
            out var unavailableSubjectUidsBuffer,
            out var availableSubjectUidsBuffer
          );
          response.unavailableSubjectUids = unavailableSubjectUidsBuffer;
          response.availableSubjectUids = availableSubjectUidsBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new CheckSubjectExisitenceResponse { fault = ex.Message };
        }
      }
      
      /// <summary> loads the requested Subjects and returns lightweight json objects (without childs), which are optimized to be displayed as table (the most common UI use case). This models containig a combination of: essential fieds from the record, calculated fields (numbers of child records), custom fields (choosen by the service) </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("SubjectConsume")]
      [HttpPost("getSubjectFields"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetSubjectFields), Description = "loads the requested Subjects and returns lightweight json objects (without childs), which are optimized to be displayed as table (the most common UI use case). This models containig a combination of: essential fieds from the record, calculated fields (numbers of child records), custom fields (choosen by the service)")]
      public GetSubjectFieldsResponse GetSubjectFields([FromBody][SwaggerRequestBody(Required = true)] GetSubjectFieldsRequest args) {
        try {
          var response = new GetSubjectFieldsResponse();
          _SubjectConsume.GetSubjectFields(
            args.subjectUids,
            out var unavailableSubjectUidsBuffer,
            out var resultBuffer
          );
          response.unavailableSubjectUids = unavailableSubjectUidsBuffer;
          response.result = resultBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetSubjectFieldsResponse { fault = ex.Message };
        }
      }
      
      /// <summary> exports full 'SubjectStructures' </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("SubjectConsume")]
      [HttpPost("exportSubjects"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(ExportSubjects), Description = "exports full 'SubjectStructures'")]
      public ExportSubjectsResponse ExportSubjects([FromBody][SwaggerRequestBody(Required = true)] ExportSubjectsRequest args) {
        try {
          var response = new ExportSubjectsResponse();
          _SubjectConsume.ExportSubjects(
            args.subjectUids,
            out var unavailableSubjectUidsBuffer,
            out var resultBuffer
          );
          response.unavailableSubjectUids = unavailableSubjectUidsBuffer;
          response.result = resultBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new ExportSubjectsResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
  namespace SubjectHL7Export {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("subjectHL7Export")]
    public partial class SubjectHL7ExportController : ControllerBase {
      
      private readonly ILogger<SubjectHL7ExportController> _Logger;
      private readonly ISubjectHL7ExportService _SubjectHL7Export;
      
      public SubjectHL7ExportController(ILogger<SubjectHL7ExportController> logger, ISubjectHL7ExportService subjectHL7Export) {
        _Logger = logger;
        _SubjectHL7Export = subjectHL7Export;
      }
      
      /// <summary> Exports a structure containing HL7/FHIR-Ressources (JSON only) and the essential fields which are required to qualify a ORSCF record. </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("SubjectHL7Export")]
      [HttpPost("exportSubjectFhirRessources"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(ExportSubjectFhirRessources), Description = "Exports a structure containing HL7/FHIR-Ressources (JSON only) and the essential fields which are required to qualify a ORSCF record.")]
      public ExportSubjectFhirRessourcesResponse ExportSubjectFhirRessources([FromBody][SwaggerRequestBody(Required = true)] ExportSubjectFhirRessourcesRequest args) {
        try {
          var response = new ExportSubjectFhirRessourcesResponse();
          response.@return = _SubjectHL7Export.ExportSubjectFhirRessources(
            args.subjectUid,
            out var subjectFhirRessourcesBuffer
          );
          response.subjectFhirRessources = subjectFhirRessourcesBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new ExportSubjectFhirRessourcesResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
  namespace SubjectHL7Import {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("subjectHL7Import")]
    public partial class SubjectHL7ImportController : ControllerBase {
      
      private readonly ILogger<SubjectHL7ImportController> _Logger;
      private readonly ISubjectHL7ImportService _SubjectHL7Import;
      
      public SubjectHL7ImportController(ILogger<SubjectHL7ImportController> logger, ISubjectHL7ImportService subjectHL7Import) {
        _Logger = logger;
        _SubjectHL7Import = subjectHL7Import;
      }
      
      /// <summary> Exports a structure containing HL7/FHIR-Ressources (JSON only) and the essential fields which are required to qualify a ORSCF record. </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("SubjectHL7Import")]
      [HttpPost("importSubjectFhirRessources"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(ImportSubjectFhirRessources), Description = "Exports a structure containing HL7/FHIR-Ressources (JSON only) and the essential fields which are required to qualify a ORSCF record.")]
      public ImportSubjectFhirRessourcesResponse ImportSubjectFhirRessources([FromBody][SwaggerRequestBody(Required = true)] ImportSubjectFhirRessourcesRequest args) {
        try {
          var response = new ImportSubjectFhirRessourcesResponse();
          _SubjectHL7Import.ImportSubjectFhirRessources(
            args.subjectFhirRessources,
            out var createdSubjectUidsBuffer,
            out var updatedSubjectUidsBuffer
          );
          response.createdSubjectUids = createdSubjectUidsBuffer;
          response.updatedSubjectUids = updatedSubjectUidsBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new ImportSubjectFhirRessourcesResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
  namespace SubjectSubmission {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("subjectSubmission")]
    public partial class SubjectSubmissionController : ControllerBase {
      
      private readonly ILogger<SubjectSubmissionController> _Logger;
      private readonly ISubjectSubmissionService _SubjectSubmission;
      
      public SubjectSubmissionController(ILogger<SubjectSubmissionController> logger, ISubjectSubmissionService subjectSubmission) {
        _Logger = logger;
        _SubjectSubmission = subjectSubmission;
      }
      
      /// <summary> ArchiveSubjects </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("SubjectSubmission")]
      [HttpPost("archiveSubjects"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(ArchiveSubjects), Description = "ArchiveSubjects")]
      public ArchiveSubjectsResponse ArchiveSubjects([FromBody][SwaggerRequestBody(Required = true)] ArchiveSubjectsRequest args) {
        try {
          var response = new ArchiveSubjectsResponse();
          _SubjectSubmission.ArchiveSubjects(
            args.subjectUids,
            out var archivedSubjectUidsBuffer
          );
          response.archivedSubjectUids = archivedSubjectUidsBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new ArchiveSubjectsResponse { fault = ex.Message };
        }
      }
      
      /// <summary> UnarchiveSubjects </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("SubjectSubmission")]
      [HttpPost("unarchiveSubjects"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(UnarchiveSubjects), Description = "UnarchiveSubjects")]
      public UnarchiveSubjectsResponse UnarchiveSubjects([FromBody][SwaggerRequestBody(Required = true)] UnarchiveSubjectsRequest args) {
        try {
          var response = new UnarchiveSubjectsResponse();
          _SubjectSubmission.UnarchiveSubjects(
            args.subjectUids,
            out var unarchivedSubjectUidsBuffer
          );
          response.unarchivedSubjectUids = unarchivedSubjectUidsBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new UnarchiveSubjectsResponse { fault = ex.Message };
        }
      }
      
      /// <summary> ApplySubjectMutations </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("SubjectSubmission")]
      [HttpPost("applySubjectMutations"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(ApplySubjectMutations), Description = "ApplySubjectMutations")]
      public ApplySubjectMutationsResponse ApplySubjectMutations([FromBody][SwaggerRequestBody(Required = true)] ApplySubjectMutationsRequest args) {
        try {
          var response = new ApplySubjectMutationsResponse();
          _SubjectSubmission.ApplySubjectMutations(
            args.mutationsBySubjecttUid,
            out var updatedSubjectUidsBuffer
          );
          response.updatedSubjectUids = updatedSubjectUidsBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new ApplySubjectMutationsResponse { fault = ex.Message };
        }
      }
      
      /// <summary> ApplySubjectBatchMutation </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("SubjectSubmission")]
      [HttpPost("applySubjectBatchMutation"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(ApplySubjectBatchMutation), Description = "ApplySubjectBatchMutation")]
      public ApplySubjectBatchMutationResponse ApplySubjectBatchMutation([FromBody][SwaggerRequestBody(Required = true)] ApplySubjectBatchMutationRequest args) {
        try {
          var response = new ApplySubjectBatchMutationResponse();
          _SubjectSubmission.ApplySubjectBatchMutation(
            args.subjectUids,
            args.mutation,
            out var updatedSubjectUidsBuffer
          );
          response.updatedSubjectUids = updatedSubjectUidsBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new ApplySubjectBatchMutationResponse { fault = ex.Message };
        }
      }
      
      /// <summary> ImportSubjects </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("SubjectSubmission")]
      [HttpPost("importSubjects"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(ImportSubjects), Description = "ImportSubjects")]
      public ImportSubjectsResponse ImportSubjects([FromBody][SwaggerRequestBody(Required = true)] ImportSubjectsRequest args) {
        try {
          var response = new ImportSubjectsResponse();
          _SubjectSubmission.ImportSubjects(
            args.subjects,
            out var createdSubjectUidsBuffer,
            out var updatedSubjectUidsBuffer
          );
          response.createdSubjectUids = createdSubjectUidsBuffer;
          response.updatedSubjectUids = updatedSubjectUidsBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new ImportSubjectsResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
}
