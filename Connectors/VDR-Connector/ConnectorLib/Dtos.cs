/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.VisitData.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalResearch.VisitData {
  
  namespace VdrApiInfo {
    
    /// <summary>
    /// Contains arguments for calling 'GetApiVersion'.
    /// Method: returns the version of the ORSCF specification which is implemented by this API,
    /// (this can be used for backward compatibility within inhomogeneous infrastructures)
    /// </summary>
    public class GetApiVersionRequest {
      
    }
    
    /// <summary>
    /// Contains results from calling 'GetApiVersion'.
    /// Method: returns the version of the ORSCF specification which is implemented by this API,
    /// (this can be used for backward compatibility within inhomogeneous infrastructures)
    /// </summary>
    public class GetApiVersionResponse {
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'GetApiVersion' (String) </summary>
      public string @return { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'GetCapabilities'.
    /// Method: returns a list of API-features (there are several 'services' for different use cases, described by ORSCF)
    /// supported by this implementation. The following values are possible:
    /// 'VdrEventSubscription',
    /// 'VisitConsume',
    /// 'VisitSubmission',
    /// 'VisitHL7Export',
    /// 'VisitHL7Import',
    /// 'DataRecordingSubmission'
    /// </summary>
    public class GetCapabilitiesRequest {
      
    }
    
    /// <summary>
    /// Contains results from calling 'GetCapabilities'.
    /// Method: returns a list of API-features (there are several 'services' for different use cases, described by ORSCF)
    /// supported by this implementation. The following values are possible:
    /// 'VdrEventSubscription',
    /// 'VisitConsume',
    /// 'VisitSubmission',
    /// 'VisitHL7Export',
    /// 'VisitHL7Import',
    /// 'DataRecordingSubmission'
    /// </summary>
    public class GetCapabilitiesResponse {
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'GetCapabilities' (String[]) </summary>
      public string[] @return { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'GetPermittedAuthScopes'.
    /// Method: returns a list of available capabilities ("API:VisitDataConsume") and/or
    /// data-scopes ("Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72")
    /// which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be:
    /// 0=auth needed /
    /// 1=authenticated /
    /// -1=auth expired /
    /// -2=auth invalid/disabled
    /// </summary>
    public class GetPermittedAuthScopesRequest {
      
    }
    
    /// <summary>
    /// Contains results from calling 'GetPermittedAuthScopes'.
    /// Method: returns a list of available capabilities ("API:VisitDataConsume") and/or
    /// data-scopes ("Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72")
    /// which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be:
    /// 0=auth needed /
    /// 1=authenticated /
    /// -1=auth expired /
    /// -2=auth invalid/disabled
    /// </summary>
    public class GetPermittedAuthScopesResponse {
      
      /// <summary> Out-Argument of 'GetPermittedAuthScopes' (Int32) </summary>
      [Required]
      public Int32 authState { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'GetPermittedAuthScopes' (String[]) </summary>
      public string[] @return { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'GetOAuthTokenRequestUrl'.
    /// Method: OPTIONAL: If the authentication on the current service is mapped
    /// using tokens and should provide information about the source at this point,
    /// the login URL to be called up via browser (OAuth <see href="https://openid.net/specs/openid-client-initiated-backchannel-authentication-core-1_0.html">'CIBA-Flow'</see>) is returned here.
    /// </summary>
    public class GetOAuthTokenRequestUrlRequest {
      
    }
    
    /// <summary>
    /// Contains results from calling 'GetOAuthTokenRequestUrl'.
    /// Method: OPTIONAL: If the authentication on the current service is mapped
    /// using tokens and should provide information about the source at this point,
    /// the login URL to be called up via browser (OAuth <see href="https://openid.net/specs/openid-client-initiated-backchannel-authentication-core-1_0.html">'CIBA-Flow'</see>) is returned here.
    /// </summary>
    public class GetOAuthTokenRequestUrlResponse {
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'GetOAuthTokenRequestUrl' (String) </summary>
      public string @return { get; set; } = null;
      
    }
    
  }
  
  namespace VdrEventSubscription {
    
    /// <summary>
    /// Contains arguments for calling 'SubscribeForChangedVisits'.
    /// Method: Creates a subscription for changes which are affecting Visits.
    /// On success, a 'SubscriptionUid' will be returned and a call will be made to the given
    /// subscriberUrl + '/ConfirmAsSubscriber'. After the subscription
    /// has been confirmed, the requested events will be pushed to
    /// subscriberUrl + '/NoticeChangedVisits'
    /// (NOTICE: the receiving methods also are documented here, because this service itself can act as subscriber)
    /// </summary>
    public class SubscribeForChangedVisitsRequest {
      
      /// <summary> Required Argument for 'SubscribeForChangedVisits' (string): the root-url of the subscriber which needs to provide at least the methods '/ConfirmAsSubscriber' and '/NoticeChangedVisits' </summary>
      [Required]
      public string subscriberUrl { get; set; }
      
      /// <summary> Optional Argument for 'SubscribeForChangedVisits' (VisitFilter): if provided, the subscription will only publish events for records matching to the given filter </summary>
      public VisitFilter filter { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'SubscribeForChangedVisits'.
    /// Method: Creates a subscription for changes which are affecting Visits.
    /// On success, a 'SubscriptionUid' will be returned and a call will be made to the given
    /// subscriberUrl + '/ConfirmAsSubscriber'. After the subscription
    /// has been confirmed, the requested events will be pushed to
    /// subscriberUrl + '/NoticeChangedVisits'
    /// (NOTICE: the receiving methods also are documented here, because this service itself can act as subscriber)
    /// </summary>
    public class SubscribeForChangedVisitsResponse {
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'SubscribeForChangedVisits' (Guid) </summary>
      public Guid @return { get; set; } = Guid.Empty;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'NoticeChangedVisits'.
    /// Method: Receives notifications about changes which are affecting Visits.
    /// IMPORTANT: this method is dedicated to the usecase, when this service itself acts as a subscriber!
    /// So this can be called by an foreign service during the setup of a subscription, which was previously
    /// requested from here.
    /// The opposite case: any client subscribing to events from here,
    /// must provide its own http endpoint that has such a method!
    /// </summary>
    public class NoticeChangedVisitsRequest {
      
      /// <summary> Required Argument for 'NoticeChangedVisits' (Guid): a UUID which identifies the current event message </summary>
      [Required]
      public Guid eventUid { get; set; }
      
      /// <summary> Required Argument for 'NoticeChangedVisits' (string): a SHA256 Hash of SubscriptionSecret + EventUid (in lower string representation, without '-' characters!) Sample: SHA256('ThEs3Cr3T'+'c997dfb1c445fea84afe995307713b59') = 'a320ef5b0f563e8dcb16d759961739977afc98b90628d9dc3be519fb20701490' </summary>
      [Required]
      public string eventSignature { get; set; }
      
      /// <summary> Required Argument for 'NoticeChangedVisits' (Guid): a UUID which identifies the subscription for which this event is published </summary>
      [Required]
      public Guid subscriptionUid { get; set; }
      
      /// <summary> Required Argument for 'NoticeChangedVisits' (string): root-URL of the VDR-Service which is publishing this event </summary>
      [Required]
      public string publisherUrl { get; set; }
      
      /// <summary> Required Argument for 'NoticeChangedVisits' (VisitMetaRecord[]) </summary>
      [Required]
      public VisitMetaRecord[] createdRecords { get; set; }
      
      /// <summary> Required Argument for 'NoticeChangedVisits' (VisitMetaRecord[]) </summary>
      [Required]
      public VisitMetaRecord[] modifiedRecords { get; set; }
      
      /// <summary> Required Argument for 'NoticeChangedVisits' (VisitMetaRecord[]) </summary>
      [Required]
      public VisitMetaRecord[] archivedRecords { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'NoticeChangedVisits'.
    /// Method: Receives notifications about changes which are affecting Visits.
    /// IMPORTANT: this method is dedicated to the usecase, when this service itself acts as a subscriber!
    /// So this can be called by an foreign service during the setup of a subscription, which was previously
    /// requested from here.
    /// The opposite case: any client subscribing to events from here,
    /// must provide its own http endpoint that has such a method!
    /// </summary>
    public class NoticeChangedVisitsResponse {
      
      /// <summary> Out-Argument of 'NoticeChangedVisits' (bool): an array, which contains one element per changed visit </summary>
      [Required]
      public bool terminateSubscription { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'ConfirmAsSubscriber'.
    /// Method: Confirms a Subscription.
    /// IMPORTANT: this method is dedicated to the usecase, when this service itself acts as a subscriber!
    /// So this can be called by an foreign service during the setup of a subscription, which was previously
    /// requested from here.
    /// The opposite case: any client subscribing to events from here,
    /// must provide its own http endpoint that has such a method!
    /// </summary>
    public class ConfirmAsSubscriberRequest {
      
      /// <summary> Required Argument for 'ConfirmAsSubscriber' (string): root-URL of the VDR-Service on which the subscription was requested </summary>
      [Required]
      public string publisherUrl { get; set; }
      
      /// <summary> Required Argument for 'ConfirmAsSubscriber' (Guid): the Uid of the subscription which should be confirmed </summary>
      [Required]
      public Guid subscriptionUid { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'ConfirmAsSubscriber'.
    /// Method: Confirms a Subscription.
    /// IMPORTANT: this method is dedicated to the usecase, when this service itself acts as a subscriber!
    /// So this can be called by an foreign service during the setup of a subscription, which was previously
    /// requested from here.
    /// The opposite case: any client subscribing to events from here,
    /// must provide its own http endpoint that has such a method!
    /// </summary>
    public class ConfirmAsSubscriberResponse {
      
      /// <summary> Out-Argument of 'ConfirmAsSubscriber' (string): A secret which is generated by the subscriber and used to provide additional security. It will be required for the 'TerminateSubscription' method and it is used to generate SHA256 hashes for signing the delivered event messages. The secret should: have a minimum length of 32 characters. A null or empty string has the semantics that the subscriber refuses to confirm and cancels the subscription setup. </summary>
      [Required]
      public string secret { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'TerminateSubscription'.
    /// Method: Terminates a subscription (on publisher side) and returns a boolean,
    /// which indicates success.
    /// </summary>
    public class TerminateSubscriptionRequest {
      
      /// <summary> Required Argument for 'TerminateSubscription' (Guid): the Uid of the subscription which should be terminated </summary>
      [Required]
      public Guid subscriptionUid { get; set; }
      
      /// <summary> Required Argument for 'TerminateSubscription' (string): the (same) secret, which was given by the subscriber during the subscription setup </summary>
      [Required]
      public string secret { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'TerminateSubscription'.
    /// Method: Terminates a subscription (on publisher side) and returns a boolean,
    /// which indicates success.
    /// </summary>
    public class TerminateSubscriptionResponse {
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'TerminateSubscription' (Boolean) </summary>
      public bool @return { get; set; } = false;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'GetSubsriptionsBySubscriberUrl'.
    /// Method: Returns an array of subscriptionUid's.
    /// This method helps subscribers to evaluate whether current subscriptions are still active.
    /// </summary>
    public class GetSubsriptionsBySubscriberUrlRequest {
      
      /// <summary> Required Argument for 'GetSubsriptionsBySubscriberUrl' (string) </summary>
      [Required]
      public string subscriberUrl { get; set; }
      
      /// <summary> Required Argument for 'GetSubsriptionsBySubscriberUrl' (string): the (same) secret, which was given by the subscriber during the subscription setup </summary>
      [Required]
      public string secret { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'GetSubsriptionsBySubscriberUrl'.
    /// Method: Returns an array of subscriptionUid's.
    /// This method helps subscribers to evaluate whether current subscriptions are still active.
    /// </summary>
    public class GetSubsriptionsBySubscriberUrlResponse {
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'GetSubsriptionsBySubscriberUrl' (Guid[]) </summary>
      public Guid[] @return { get; set; } = null;
      
    }
    
  }
  
  namespace DataEnrollment {
    
    /// <summary>
    /// Contains arguments for calling 'EnrollDataForVisitExplicit'.
    /// Method: Enrolls recorded data to be stored as 'DataRecording'-Record related to a explicitly addressed Visit inside of this repository.
    /// This goes ahead with an validation process for each enrollment, therefore a dataEnrollmentUid will be returned
    /// which can be used to query the state of this process via 'GetValidationState'.
    /// </summary>
    public class EnrollDataForVisitExplicitRequest {
      
      /// <summary> Required Argument for 'EnrollDataForVisitExplicit' (Guid): the ORSCF-Visit-UID to address the parent visit for which the given data should be submitted </summary>
      [Required]
      public Guid targetvisitUid { get; set; }
      
      /// <summary> Required Argument for 'EnrollDataForVisitExplicit' (string): title of the task execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
      [Required]
      public string taskExecutionTitle { get; set; }
      
      /// <summary> Required Argument for 'EnrollDataForVisitExplicit' (DateTime): the time, when the data was recorded </summary>
      [Required]
      public DateTime executionDateTimeUtc { get; set; }
      
      /// <summary> Required Argument for 'EnrollDataForVisitExplicit' (string): 'FhirQuestionaire' / 'XML' / 'CSV' / 'Custom' </summary>
      [Required]
      public string dataSchemaKind { get; set; }
      
      /// <summary> Required Argument for 'EnrollDataForVisitExplicit' (string): the schema-url of the data which were stored inside of the 'RecordedData' field </summary>
      [Required]
      public string dataSchemaUrl { get; set; }
      
      /// <summary> Required Argument for 'EnrollDataForVisitExplicit' (string): version of schema, which is addressed by the 'DataSchemaUrl' </summary>
      [Required]
      public string dataSchemaVersion { get; set; }
      
      /// <summary> Required Argument for 'EnrollDataForVisitExplicit' (string): Language of free-text information inside of the data content </summary>
      [Required]
      public string dataLanguage { get; set; }
      
      /// <summary> Required Argument for 'EnrollDataForVisitExplicit' (string): RAW data, in the schema as defined at the 'DataSchemaUrl' </summary>
      [Required]
      public string recordedData { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'EnrollDataForVisitExplicit'.
    /// Method: Enrolls recorded data to be stored as 'DataRecording'-Record related to a explicitly addressed Visit inside of this repository.
    /// This goes ahead with an validation process for each enrollment, therefore a dataEnrollmentUid will be returned
    /// which can be used to query the state of this process via 'GetValidationState'.
    /// </summary>
    public class EnrollDataForVisitExplicitResponse {
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'EnrollDataForVisitExplicit' (Guid) </summary>
      public Guid @return { get; set; } = Guid.Empty;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'EnrollDataForVisitImplicit'.
    /// Method: Enrolls recorded data to be stored as 'DataRecording'-Record related to a visit inside of this repository
    /// (which is implicitely resolved using the given 'visitExecutionTitle' and 'subjectIdentifier') .
    /// This goes ahead with an validation process for each enrollment, therefore a dataEnrollmentUid will be returned
    /// which can be used to query the state of this process via 'GetValidationState'.
    /// </summary>
    public class EnrollDataForVisitImplicitRequest {
      
      /// <summary> Required Argument for 'EnrollDataForVisitImplicit' (Guid): the ORSCF-Study-UID which is used to lookup for the target visit for which the given data should be submitted </summary>
      [Required]
      public Guid studyUid { get; set; }
      
      /// <summary> Required Argument for 'EnrollDataForVisitImplicit' (string): the study related identity of the patient (usually a pseudonym) which is used to lookup for the target visit for which the given data should be submitted </summary>
      [Required]
      public string subjectIdentifier { get; set; }
      
      /// <summary> Required Argument for 'EnrollDataForVisitImplicit' (string): unique title of the visit execution as defined in the 'StudyWorkflowDefinition' which is used to lookup for the target visit for which the given data should be submitted </summary>
      [Required]
      public string visitExecutionTitle { get; set; }
      
      /// <summary> Required Argument for 'EnrollDataForVisitImplicit' (string): title of the task execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
      [Required]
      public string taskExecutionTitle { get; set; }
      
      /// <summary> Required Argument for 'EnrollDataForVisitImplicit' (DateTime): the time, when the data was recorded </summary>
      [Required]
      public DateTime executionDateTimeUtc { get; set; }
      
      /// <summary> Required Argument for 'EnrollDataForVisitImplicit' (string): 'FhirQuestionaire' / 'XML' / 'CSV' / 'Custom' </summary>
      [Required]
      public string dataSchemaKind { get; set; }
      
      /// <summary> Required Argument for 'EnrollDataForVisitImplicit' (string): the schema-url of the data which were stored inside of the 'RecordedData' field </summary>
      [Required]
      public string dataSchemaUrl { get; set; }
      
      /// <summary> Required Argument for 'EnrollDataForVisitImplicit' (string): version of schema, which is addressed by the 'DataSchemaUrl' </summary>
      [Required]
      public string dataSchemaVersion { get; set; }
      
      /// <summary> Required Argument for 'EnrollDataForVisitImplicit' (string): Language of free-text information inside of the data content </summary>
      [Required]
      public string dataLanguage { get; set; }
      
      /// <summary> Required Argument for 'EnrollDataForVisitImplicit' (string): RAW data, in the schema as defined at the 'DataSchemaUrl' </summary>
      [Required]
      public string recordedData { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'EnrollDataForVisitImplicit'.
    /// Method: Enrolls recorded data to be stored as 'DataRecording'-Record related to a visit inside of this repository
    /// (which is implicitely resolved using the given 'visitExecutionTitle' and 'subjectIdentifier') .
    /// This goes ahead with an validation process for each enrollment, therefore a dataEnrollmentUid will be returned
    /// which can be used to query the state of this process via 'GetValidationState'.
    /// </summary>
    public class EnrollDataForVisitImplicitResponse {
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'EnrollDataForVisitImplicit' (Guid) </summary>
      public Guid @return { get; set; } = Guid.Empty;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'GetValidationState'.
    /// Method: Providing the current validation state for a given data enrollment process
    /// </summary>
    public class GetValidationStateRequest {
      
      /// <summary> Required Argument for 'GetValidationState' (Guid) </summary>
      [Required]
      public Guid dataEnrollmentUid { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'GetValidationState'.
    /// Method: Providing the current validation state for a given data enrollment process
    /// </summary>
    public class GetValidationStateResponse {
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'GetValidationState' (DataEnrollmentValidationState): Declares, which portion of the corresponding 'value' should be compared. DEFAULT (if this is undefined or null) is 'Date'(3). </summary>
      public DataEnrollmentValidationState? @return { get; set; }
      
    }
    
  }
  
  namespace DataRecordingSubmission {
    
    /// <summary>
    /// Contains arguments for calling 'ImportDataRecordings'.
    /// </summary>
    public class ImportDataRecordingsRequest {
      
      /// <summary> Required Argument for 'ImportDataRecordings' (DataRecordingStructure[]) </summary>
      [Required]
      public DataRecordingStructure[] dataRecordings { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'ImportDataRecordings'.
    /// </summary>
    public class ImportDataRecordingsResponse {
      
      /// <summary> Out-Argument of 'ImportDataRecordings' (Guid[]) </summary>
      [Required]
      public Guid[] createdDataRecordingUids { get; set; }
      
      /// <summary> Out-Argument of 'ImportDataRecordings' (Guid[]) </summary>
      [Required]
      public Guid[] updatedDataRecordingUids { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
  }
  
  namespace VisitConsume {
    
    /// <summary>
    /// Contains arguments for calling 'SearchVisits'.
    /// Method: Searches Visits by a given 'filter' (if provided),
    /// sorts the results by the given 'sortingField' (if provided) and
    /// returns an array of VisitUids for the matching records.
    /// </summary>
    public class SearchVisitsRequest {
      
      /// <summary> Optional Argument for 'SearchVisits' (string): A fieldname, which should be used to sort the result (can also be a 'CustomField'). If not provided, the result will be sorted by the creation date of the records </summary>
      public string sortingField { get; set; }
      
      /// <summary> Optional Argument for 'SearchVisits' (bool?): toggles the sorting direction </summary>
      public bool? sortDescending { get; set; } = null;
      
      /// <summary> Optional Argument for 'SearchVisits' (VisitFilter): values by field name (can also be a 'CustomField') which will used as AND-linked filter </summary>
      public VisitFilter filter { get; set; }
      
      /// <summary> Optional Argument for 'SearchVisits' (bool?): includes archived records in the result </summary>
      public bool? includeArchivedRecords { get; set; } = null;
      
      /// <summary> Optional Argument for 'SearchVisits' (Int32?): a value greather than zero will represent a maximum count of results, that sould be returned </summary>
      public Int32? limitResults { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains results from calling 'SearchVisits'.
    /// Method: Searches Visits by a given 'filter' (if provided),
    /// sorts the results by the given 'sortingField' (if provided) and
    /// returns an array of VisitUids for the matching records.
    /// </summary>
    public class SearchVisitsResponse {
      
      /// <summary> Out-Argument of 'SearchVisits' (VisitMetaRecord[]) </summary>
      [Required]
      public VisitMetaRecord[] result { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'SearchChangedVisits'.
    /// Method: Searches Visits which have been modified after(or at) the given 'minTimestampUtc',
    /// matching to the given 'filter' (if provided).
    /// The result is sorted descenting by the timestamp of the modification (latest first) and will
    /// include archived records.
    /// </summary>
    public class SearchChangedVisitsRequest {
      
      /// <summary> Required Argument for 'SearchChangedVisits' (Int64): start of the timespan to search (as UNIX-Timestamp) </summary>
      [Required]
      public Int64 minTimestampUtc { get; set; }
      
      /// <summary> Optional Argument for 'SearchChangedVisits' (VisitFilter): values by field name (can also be a 'CustomField') which will used as AND-linked filter </summary>
      public VisitFilter filter { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'SearchChangedVisits'.
    /// Method: Searches Visits which have been modified after(or at) the given 'minTimestampUtc',
    /// matching to the given 'filter' (if provided).
    /// The result is sorted descenting by the timestamp of the modification (latest first) and will
    /// include archived records.
    /// </summary>
    public class SearchChangedVisitsResponse {
      
      /// <summary> Out-Argument of 'SearchChangedVisits' (Int64): the exact timestamp of the search (as UNIX-Timestamp) </summary>
      [Required]
      public Int64 latestTimestampUtc { get; set; }
      
      /// <summary> Out-Argument of 'SearchChangedVisits' (VisitMetaRecord[]) </summary>
      [Required]
      public VisitMetaRecord[] createdRecords { get; set; }
      
      /// <summary> Out-Argument of 'SearchChangedVisits' (VisitMetaRecord[]) </summary>
      [Required]
      public VisitMetaRecord[] modifiedRecords { get; set; }
      
      /// <summary> Out-Argument of 'SearchChangedVisits' (VisitMetaRecord[]) </summary>
      [Required]
      public VisitMetaRecord[] archivedRecords { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'GetCustomFieldDescriptorsForVisit'.
    /// </summary>
    public class GetCustomFieldDescriptorsForVisitRequest {
      
      /// <summary> Optional Argument for 'GetCustomFieldDescriptorsForVisit' (string): Preferred language for the 'DisplayLabel' and 'InputDescription' fields of the returned descriptors. The default is 'EN'. </summary>
      public string languagePref { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'GetCustomFieldDescriptorsForVisit'.
    /// </summary>
    public class GetCustomFieldDescriptorsForVisitResponse {
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'GetCustomFieldDescriptorsForVisit' (CustomFieldDescriptor[]) </summary>
      public CustomFieldDescriptor[] @return { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'CheckVisitExisitence'.
    /// Method: Checks the existence of 'Visits' for a given list of visitUids
    /// </summary>
    public class CheckVisitExisitenceRequest {
      
      /// <summary> Required Argument for 'CheckVisitExisitence' (Guid[]) </summary>
      [Required]
      public Guid[] visitUids { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'CheckVisitExisitence'.
    /// Method: Checks the existence of 'Visits' for a given list of visitUids
    /// </summary>
    public class CheckVisitExisitenceResponse {
      
      /// <summary> Out-Argument of 'CheckVisitExisitence' (Guid[]) </summary>
      [Required]
      public Guid[] unavailableVisitUids { get; set; }
      
      /// <summary> Out-Argument of 'CheckVisitExisitence' (Guid[]) </summary>
      [Required]
      public Guid[] availableVisitUids { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'GetVisitFields'.
    /// Method: loads the requested visits and returns lightweight json objects (without childs),
    /// which are optimized to be displayed as table (the most common UI use case).
    /// This models containig a combination of:
    /// essential fieds from the record,
    /// calculated fields (numbers of child records),
    /// custom fields (choosen by the service)
    /// </summary>
    public class GetVisitFieldsRequest {
      
      /// <summary> Required Argument for 'GetVisitFields' (Guid[]) </summary>
      [Required]
      public Guid[] visitUids { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'GetVisitFields'.
    /// Method: loads the requested visits and returns lightweight json objects (without childs),
    /// which are optimized to be displayed as table (the most common UI use case).
    /// This models containig a combination of:
    /// essential fieds from the record,
    /// calculated fields (numbers of child records),
    /// custom fields (choosen by the service)
    /// </summary>
    public class GetVisitFieldsResponse {
      
      /// <summary> Out-Argument of 'GetVisitFields' (Guid[]) </summary>
      [Required]
      public Guid[] unavailableVisitUids { get; set; }
      
      /// <summary> Out-Argument of 'GetVisitFields' (VisitFields[]) </summary>
      [Required]
      public VisitFields[] result { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'ExportVisits'.
    /// Method: exports full 'VisitStructures'
    /// </summary>
    public class ExportVisitsRequest {
      
      /// <summary> Required Argument for 'ExportVisits' (Guid[]) </summary>
      [Required]
      public Guid[] visitUids { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'ExportVisits'.
    /// Method: exports full 'VisitStructures'
    /// </summary>
    public class ExportVisitsResponse {
      
      /// <summary> Out-Argument of 'ExportVisits' (Guid[]) </summary>
      [Required]
      public Guid[] unavailableVisitUids { get; set; }
      
      /// <summary> Out-Argument of 'ExportVisits' (VisitStructure[]) </summary>
      [Required]
      public VisitStructure[] result { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
  }
  
  namespace VisitHL7Export {
    
    /// <summary>
    /// Contains arguments for calling 'ExportVisitFhirRessources'.
    /// Method: Exports a structure containing HL7/FHIR-Ressources (JSON only) and
    /// the essential fields which are required to qualify a ORSCF record.
    /// </summary>
    public class ExportVisitFhirRessourcesRequest {
      
      /// <summary> Required Argument for 'ExportVisitFhirRessources' (Guid) </summary>
      [Required]
      public Guid visitUid { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'ExportVisitFhirRessources'.
    /// Method: Exports a structure containing HL7/FHIR-Ressources (JSON only) and
    /// the essential fields which are required to qualify a ORSCF record.
    /// </summary>
    public class ExportVisitFhirRessourcesResponse {
      
      /// <summary> Out-Argument of 'ExportVisitFhirRessources' (VisitFhirRessourceContainer[]) </summary>
      [Required]
      public VisitFhirRessourceContainer[] visitFhirRessources { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'ExportVisitFhirRessources' (Boolean) </summary>
      public bool @return { get; set; } = false;
      
    }
    
  }
  
  namespace VisitHL7Import {
    
    /// <summary>
    /// Contains arguments for calling 'ImportVisitFhirRessources'.
    /// Method: Exports a structure containing HL7/FHIR-Ressources (JSON only) and
    /// the essential fields which are required to qualify a ORSCF record.
    /// </summary>
    public class ImportVisitFhirRessourcesRequest {
      
      /// <summary> Required Argument for 'ImportVisitFhirRessources' (VisitFhirRessourceContainer[]): A structure containing HL7/FHIR-Ressources (JSON only) and the essential fields which are required to qualify a ORSCF record. </summary>
      [Required]
      public VisitFhirRessourceContainer[] visitFhirRessources { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'ImportVisitFhirRessources'.
    /// Method: Exports a structure containing HL7/FHIR-Ressources (JSON only) and
    /// the essential fields which are required to qualify a ORSCF record.
    /// </summary>
    public class ImportVisitFhirRessourcesResponse {
      
      /// <summary> Out-Argument of 'ImportVisitFhirRessources' (Guid[]) </summary>
      [Required]
      public Guid[] createdVisitUids { get; set; }
      
      /// <summary> Out-Argument of 'ImportVisitFhirRessources' (Guid[]) </summary>
      [Required]
      public Guid[] updatedVisitUids { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
  }
  
  namespace VisitSubmission {
    
    /// <summary>
    /// Contains arguments for calling 'ArchiveVisits'.
    /// </summary>
    public class ArchiveVisitsRequest {
      
      /// <summary> Required Argument for 'ArchiveVisits' (Guid[]) </summary>
      [Required]
      public Guid[] visitUids { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'ArchiveVisits'.
    /// </summary>
    public class ArchiveVisitsResponse {
      
      /// <summary> Out-Argument of 'ArchiveVisits' (Guid[]): also including the Uids of already archived records </summary>
      [Required]
      public Guid[] archivedVisitUids { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'UnarchiveVisits'.
    /// </summary>
    public class UnarchiveVisitsRequest {
      
      /// <summary> Required Argument for 'UnarchiveVisits' (Guid[]) </summary>
      [Required]
      public Guid[] visitUids { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'UnarchiveVisits'.
    /// </summary>
    public class UnarchiveVisitsResponse {
      
      /// <summary> Out-Argument of 'UnarchiveVisits' (Guid[]) </summary>
      [Required]
      public Guid[] unarchivedVisitUids { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'ApplyVisitMutations'.
    /// </summary>
    public class ApplyVisitMutationsRequest {
      
      /// <summary> Required Argument for 'ApplyVisitMutations' (Dictionary(Guid, VisitMutation)) </summary>
      [Required]
      public Dictionary<Guid, VisitMutation> mutationsByVisitUid { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'ApplyVisitMutations'.
    /// </summary>
    public class ApplyVisitMutationsResponse {
      
      /// <summary> Out-Argument of 'ApplyVisitMutations' (Guid[]) </summary>
      [Required]
      public Guid[] updatedVisitUids { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'ApplyVisitBatchMutation'.
    /// </summary>
    public class ApplyVisitBatchMutationRequest {
      
      /// <summary> Required Argument for 'ApplyVisitBatchMutation' (Guid[]) </summary>
      [Required]
      public Guid[] visitUids { get; set; }
      
      /// <summary> Required Argument for 'ApplyVisitBatchMutation' (BatchableVisitMutation) </summary>
      [Required]
      public BatchableVisitMutation mutation { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'ApplyVisitBatchMutation'.
    /// </summary>
    public class ApplyVisitBatchMutationResponse {
      
      /// <summary> Out-Argument of 'ApplyVisitBatchMutation' (Guid[]) </summary>
      [Required]
      public Guid[] updatedVisitUids { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'ImportVisits'.
    /// </summary>
    public class ImportVisitsRequest {
      
      /// <summary> Required Argument for 'ImportVisits' (VisitStructure[]) </summary>
      [Required]
      public VisitStructure[] visits { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'ImportVisits'.
    /// </summary>
    public class ImportVisitsResponse {
      
      /// <summary> Out-Argument of 'ImportVisits' (Guid[]) </summary>
      [Required]
      public Guid[] createdVisitUids { get; set; }
      
      /// <summary> Out-Argument of 'ImportVisits' (Guid[]) </summary>
      [Required]
      public Guid[] updatedVisitUids { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
  }
  
}
