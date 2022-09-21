/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.SubjectData.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalResearch.SubjectData.WebAPI {
  
  namespace SdrApiInfo {
    
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
    /// 'SdrEventSubscription',
    /// 'SubjectConsume',
    /// 'SubjectSubmission',
    /// 'SubjectHL7Export'
    /// 'SubjectHL7Import'
    /// </summary>
    public class GetCapabilitiesRequest {
      
    }
    
    /// <summary>
    /// Contains results from calling 'GetCapabilities'.
    /// Method: returns a list of API-features (there are several 'services' for different use cases, described by ORSCF)
    /// supported by this implementation. The following values are possible:
    /// 'SdrEventSubscription',
    /// 'SubjectConsume',
    /// 'SubjectSubmission',
    /// 'SubjectHL7Export'
    /// 'SubjectHL7Import'
    /// </summary>
    public class GetCapabilitiesResponse {
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'GetCapabilities' (String[]) </summary>
      public string[] @return { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'GetPermittedAuthScopes'.
    /// Method: returns a list of available capabilities ("API:SubjectOverview") and/or
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
    /// Method: returns a list of available capabilities ("API:SubjectOverview") and/or
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
  
  namespace SdrEventSubscription {
    
    /// <summary>
    /// Contains arguments for calling 'SubscribeForChangedSubjects'.
    /// Method: Creates a subscription for changes which are affecting Subjects.
    /// On success, a 'SubscriptionUid' will be returned and a call will be made to the given
    /// subscriberUrl + '/ConfirmAsSubscriber'. After the subscription
    /// has been confirmed, the requested events will be pushed to
    /// subscriberUrl + '/NoticeChangedSubjects'
    /// (NOTICE: the receiving methods also are documented here, because this service itself can act as subscriber)
    /// </summary>
    public class SubscribeForChangedSubjectsRequest {
      
      /// <summary> Required Argument for 'SubscribeForChangedSubjects' (string): the root-url of the subscriber which needs to provide at least the methods '/ConfirmAsSubscriber' and '/NoticeChangedSubjects' </summary>
      [Required]
      public string subscriberUrl { get; set; }
      
      /// <summary> Optional Argument for 'SubscribeForChangedSubjects' (SubjectFilter): if provided, the subscription will only publish events for records matching to the given filter </summary>
      public SubjectFilter filter { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'SubscribeForChangedSubjects'.
    /// Method: Creates a subscription for changes which are affecting Subjects.
    /// On success, a 'SubscriptionUid' will be returned and a call will be made to the given
    /// subscriberUrl + '/ConfirmAsSubscriber'. After the subscription
    /// has been confirmed, the requested events will be pushed to
    /// subscriberUrl + '/NoticeChangedSubjects'
    /// (NOTICE: the receiving methods also are documented here, because this service itself can act as subscriber)
    /// </summary>
    public class SubscribeForChangedSubjectsResponse {
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'SubscribeForChangedSubjects' (Guid) </summary>
      public Guid @return { get; set; } = Guid.Empty;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'NoticeChangedSubjects'.
    /// Method: Receives notifications about changes which are affecting Subjects.
    /// IMPORTANT: this method is dedicated to the usecase, when this service itself acts as a subscriber!
    /// So this can be called by an foreign service during the setup of a subscription, which was previously
    /// requested from here.
    /// The opposite case: any client subscribing to events from here,
    /// must provide its own http endpoint that has such a method!
    /// </summary>
    public class NoticeChangedSubjectsRequest {
      
      /// <summary> Required Argument for 'NoticeChangedSubjects' (Guid): a UUID which identifies the current event message </summary>
      [Required]
      public Guid eventUid { get; set; }
      
      /// <summary> Required Argument for 'NoticeChangedSubjects' (string): a SHA256 Hash of SubscriptionSecret + EventUid (in lower string representation, without '-' characters!) Sample: SHA256('ThEs3Cr3T'+'c997dfb1c445fea84afe995307713b59') = 'a320ef5b0f563e8dcb16d759961739977afc98b90628d9dc3be519fb20701490' </summary>
      [Required]
      public string eventSignature { get; set; }
      
      /// <summary> Required Argument for 'NoticeChangedSubjects' (Guid): a UUID which identifies the subscription for which this event is published </summary>
      [Required]
      public Guid subscriptionUid { get; set; }
      
      /// <summary> Required Argument for 'NoticeChangedSubjects' (string): root-URL of the VDR-Service which is publishing this event </summary>
      [Required]
      public string publisherUrl { get; set; }
      
      /// <summary> Required Argument for 'NoticeChangedSubjects' (SubjectMetaRecord[]): an array, which contains one element per changed record </summary>
      [Required]
      public SubjectMetaRecord[] createdRecords { get; set; }
      
      /// <summary> Required Argument for 'NoticeChangedSubjects' (SubjectMetaRecord[]): an array, which contains one element per modified record </summary>
      [Required]
      public SubjectMetaRecord[] modifiedRecords { get; set; }
      
      /// <summary> Required Argument for 'NoticeChangedSubjects' (SubjectMetaRecord[]): an array, which contains one element per archived record </summary>
      [Required]
      public SubjectMetaRecord[] archivedRecords { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'NoticeChangedSubjects'.
    /// Method: Receives notifications about changes which are affecting Subjects.
    /// IMPORTANT: this method is dedicated to the usecase, when this service itself acts as a subscriber!
    /// So this can be called by an foreign service during the setup of a subscription, which was previously
    /// requested from here.
    /// The opposite case: any client subscribing to events from here,
    /// must provide its own http endpoint that has such a method!
    /// </summary>
    public class NoticeChangedSubjectsResponse {
      
      /// <summary> Out-Argument of 'NoticeChangedSubjects' (bool): an array, which contains one element per changed record </summary>
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
  
  namespace SubjectConsume {
    
    /// <summary>
    /// Contains arguments for calling 'SearchSubjects'.
    /// Method: Searches Subjects by a given 'filter' (if provided),
    /// sorts the results by the given 'sortingField' (if provided) and
    /// returns an array of SubjectUids for the matching records.
    /// </summary>
    public class SearchSubjectsRequest {
      
      /// <summary> Optional Argument for 'SearchSubjects' (string): A fieldname, which should be used to sort the result (can also be a 'CustomField'). If not provided, the result will be sorted by the creation date of the records </summary>
      public string sortingField { get; set; }
      
      /// <summary> Optional Argument for 'SearchSubjects' (bool?): toggles the sorting direction </summary>
      public bool? sortDescending { get; set; } = null;
      
      /// <summary> Optional Argument for 'SearchSubjects' (SubjectFilter): values by field name (can also be a 'CustomField') which will used as AND-linked filter </summary>
      public SubjectFilter filter { get; set; }
      
      /// <summary> Optional Argument for 'SearchSubjects' (bool?): includes archived records in the result </summary>
      public bool? includeArchivedRecords { get; set; } = null;
      
      /// <summary> Optional Argument for 'SearchSubjects' (Int32?): a value greather than zero will represent a maximum count of results, that sould be returned </summary>
      public Int32? limitResults { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains results from calling 'SearchSubjects'.
    /// Method: Searches Subjects by a given 'filter' (if provided),
    /// sorts the results by the given 'sortingField' (if provided) and
    /// returns an array of SubjectUids for the matching records.
    /// </summary>
    public class SearchSubjectsResponse {
      
      /// <summary> Out-Argument of 'SearchSubjects' (SubjectMetaRecord[]) </summary>
      [Required]
      public SubjectMetaRecord[] result { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'SearchChangedSubjects'.
    /// Method: Searches Subjects which have been modified after(or at) the given 'minTimestampUtc',
    /// matching to the given 'filter' (if provided).
    /// The result is sorted descenting by the timestamp of the modification (latest first) and will
    /// include archived records.
    /// </summary>
    public class SearchChangedSubjectsRequest {
      
      /// <summary> Required Argument for 'SearchChangedSubjects' (Int64): start of the timespan to search (as UNIX-Timestamp) </summary>
      [Required]
      public Int64 minTimestampUtc { get; set; }
      
      /// <summary> Optional Argument for 'SearchChangedSubjects' (SubjectFilter): values by field name (can also be a 'CustomField') which will used as AND-linked filter </summary>
      public SubjectFilter filter { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'SearchChangedSubjects'.
    /// Method: Searches Subjects which have been modified after(or at) the given 'minTimestampUtc',
    /// matching to the given 'filter' (if provided).
    /// The result is sorted descenting by the timestamp of the modification (latest first) and will
    /// include archived records.
    /// </summary>
    public class SearchChangedSubjectsResponse {
      
      /// <summary> Out-Argument of 'SearchChangedSubjects' (Int64): the exact timestamp of the search (as UNIX-Timestamp) </summary>
      [Required]
      public Int64 latestTimestampUtc { get; set; }
      
      /// <summary> Out-Argument of 'SearchChangedSubjects' (SubjectMetaRecord[]) </summary>
      [Required]
      public SubjectMetaRecord[] createdRecords { get; set; }
      
      /// <summary> Out-Argument of 'SearchChangedSubjects' (SubjectMetaRecord[]) </summary>
      [Required]
      public SubjectMetaRecord[] modifiedRecords { get; set; }
      
      /// <summary> Out-Argument of 'SearchChangedSubjects' (SubjectMetaRecord[]) </summary>
      [Required]
      public SubjectMetaRecord[] archivedRecords { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'GetCustomFieldDescriptorsForSubject'.
    /// </summary>
    public class GetCustomFieldDescriptorsForSubjectRequest {
      
      /// <summary> Optional Argument for 'GetCustomFieldDescriptorsForSubject' (string): Preferred language for the 'DisplayLabel' and 'InputDescription' fields of the returned descriptors. The default is 'EN'. </summary>
      public string languagePref { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'GetCustomFieldDescriptorsForSubject'.
    /// </summary>
    public class GetCustomFieldDescriptorsForSubjectResponse {
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'GetCustomFieldDescriptorsForSubject' (CustomFieldDescriptor[]) </summary>
      public CustomFieldDescriptor[] @return { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'CheckSubjectExisitence'.
    /// Method: Checks the existence of 'Subjects' for a given list of subjectUids
    /// </summary>
    public class CheckSubjectExisitenceRequest {
      
      /// <summary> Required Argument for 'CheckSubjectExisitence' (Guid[]) </summary>
      [Required]
      public Guid[] subjectUids { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'CheckSubjectExisitence'.
    /// Method: Checks the existence of 'Subjects' for a given list of subjectUids
    /// </summary>
    public class CheckSubjectExisitenceResponse {
      
      /// <summary> Out-Argument of 'CheckSubjectExisitence' (Guid[]) </summary>
      [Required]
      public Guid[] unavailableSubjectUids { get; set; }
      
      /// <summary> Out-Argument of 'CheckSubjectExisitence' (Guid[]) </summary>
      [Required]
      public Guid[] availableSubjectUids { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'GetSubjectFields'.
    /// Method: loads the requested Subjects and returns lightweight json objects (without childs),
    /// which are optimized to be displayed as table (the most common UI use case).
    /// This models containig a combination of:
    /// essential fieds from the record,
    /// calculated fields (numbers of child records),
    /// custom fields (choosen by the service)
    /// </summary>
    public class GetSubjectFieldsRequest {
      
      /// <summary> Required Argument for 'GetSubjectFields' (Guid[]) </summary>
      [Required]
      public Guid[] subjectUids { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'GetSubjectFields'.
    /// Method: loads the requested Subjects and returns lightweight json objects (without childs),
    /// which are optimized to be displayed as table (the most common UI use case).
    /// This models containig a combination of:
    /// essential fieds from the record,
    /// calculated fields (numbers of child records),
    /// custom fields (choosen by the service)
    /// </summary>
    public class GetSubjectFieldsResponse {
      
      /// <summary> Out-Argument of 'GetSubjectFields' (Guid[]) </summary>
      [Required]
      public Guid[] unavailableSubjectUids { get; set; }
      
      /// <summary> Out-Argument of 'GetSubjectFields' (SubjectFields[]) </summary>
      [Required]
      public SubjectFields[] result { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'ExportSubjects'.
    /// Method: exports full 'SubjectStructures'
    /// </summary>
    public class ExportSubjectsRequest {
      
      /// <summary> Required Argument for 'ExportSubjects' (Guid[]) </summary>
      [Required]
      public Guid[] subjectUids { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'ExportSubjects'.
    /// Method: exports full 'SubjectStructures'
    /// </summary>
    public class ExportSubjectsResponse {
      
      /// <summary> Out-Argument of 'ExportSubjects' (Guid[]) </summary>
      [Required]
      public Guid[] unavailableSubjectUids { get; set; }
      
      /// <summary> Out-Argument of 'ExportSubjects' (SubjectStructure[]) </summary>
      [Required]
      public SubjectStructure[] result { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
  }
  
  namespace SubjectHL7Export {
    
    /// <summary>
    /// Contains arguments for calling 'ExportSubjectFhirRessources'.
    /// Method: Exports a structure containing HL7/FHIR-Ressources (JSON only) and
    /// the essential fields which are required to qualify a ORSCF record.
    /// </summary>
    public class ExportSubjectFhirRessourcesRequest {
      
      /// <summary> Required Argument for 'ExportSubjectFhirRessources' (Guid) </summary>
      [Required]
      public Guid subjectUid { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'ExportSubjectFhirRessources'.
    /// Method: Exports a structure containing HL7/FHIR-Ressources (JSON only) and
    /// the essential fields which are required to qualify a ORSCF record.
    /// </summary>
    public class ExportSubjectFhirRessourcesResponse {
      
      /// <summary> Out-Argument of 'ExportSubjectFhirRessources' (SubjectFhirRessourceContainer[]) </summary>
      [Required]
      public SubjectFhirRessourceContainer[] subjectFhirRessources { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'ExportSubjectFhirRessources' (Boolean) </summary>
      public bool @return { get; set; } = false;
      
    }
    
  }
  
  namespace SubjectHL7Import {
    
    /// <summary>
    /// Contains arguments for calling 'ImportSubjectFhirRessources'.
    /// Method: Exports a structure containing HL7/FHIR-Ressources (JSON only) and
    /// the essential fields which are required to qualify a ORSCF record.
    /// </summary>
    public class ImportSubjectFhirRessourcesRequest {
      
      /// <summary> Required Argument for 'ImportSubjectFhirRessources' (SubjectFhirRessourceContainer[]): A structure containing HL7/FHIR-Ressources (JSON only) and the essential fields which are required to qualify a ORSCF record. </summary>
      [Required]
      public SubjectFhirRessourceContainer[] subjectFhirRessources { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'ImportSubjectFhirRessources'.
    /// Method: Exports a structure containing HL7/FHIR-Ressources (JSON only) and
    /// the essential fields which are required to qualify a ORSCF record.
    /// </summary>
    public class ImportSubjectFhirRessourcesResponse {
      
      /// <summary> Out-Argument of 'ImportSubjectFhirRessources' (Guid[]) </summary>
      [Required]
      public Guid[] createdSubjectUids { get; set; }
      
      /// <summary> Out-Argument of 'ImportSubjectFhirRessources' (Guid[]) </summary>
      [Required]
      public Guid[] updatedSubjectUids { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
  }
  
  namespace SubjectSubmission {
    
    /// <summary>
    /// Contains arguments for calling 'ArchiveSubjects'.
    /// </summary>
    public class ArchiveSubjectsRequest {
      
      /// <summary> Required Argument for 'ArchiveSubjects' (Guid[]) </summary>
      [Required]
      public Guid[] subjectUids { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'ArchiveSubjects'.
    /// </summary>
    public class ArchiveSubjectsResponse {
      
      /// <summary> Out-Argument of 'ArchiveSubjects' (Guid[]): also including the Uids of already archived records </summary>
      [Required]
      public Guid[] archivedSubjectUids { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'UnarchiveSubjects'.
    /// </summary>
    public class UnarchiveSubjectsRequest {
      
      /// <summary> Required Argument for 'UnarchiveSubjects' (Guid[]) </summary>
      [Required]
      public Guid[] subjectUids { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'UnarchiveSubjects'.
    /// </summary>
    public class UnarchiveSubjectsResponse {
      
      /// <summary> Out-Argument of 'UnarchiveSubjects' (Guid[]) </summary>
      [Required]
      public Guid[] unarchivedSubjectUids { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'ApplySubjectMutations'.
    /// </summary>
    public class ApplySubjectMutationsRequest {
      
      /// <summary> Required Argument for 'ApplySubjectMutations' (Dictionary(Guid, SubjectMutation)) </summary>
      [Required]
      public Dictionary<Guid, SubjectMutation> mutationsBySubjecttUid { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'ApplySubjectMutations'.
    /// </summary>
    public class ApplySubjectMutationsResponse {
      
      /// <summary> Out-Argument of 'ApplySubjectMutations' (Guid[]) </summary>
      [Required]
      public Guid[] updatedSubjectUids { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'ApplySubjectBatchMutation'.
    /// </summary>
    public class ApplySubjectBatchMutationRequest {
      
      /// <summary> Required Argument for 'ApplySubjectBatchMutation' (Guid[]) </summary>
      [Required]
      public Guid[] subjectUids { get; set; }
      
      /// <summary> Required Argument for 'ApplySubjectBatchMutation' (BatchableSubjectMutation) </summary>
      [Required]
      public BatchableSubjectMutation mutation { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'ApplySubjectBatchMutation'.
    /// </summary>
    public class ApplySubjectBatchMutationResponse {
      
      /// <summary> Out-Argument of 'ApplySubjectBatchMutation' (Guid[]) </summary>
      [Required]
      public Guid[] updatedSubjectUids { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'ImportSubjects'.
    /// </summary>
    public class ImportSubjectsRequest {
      
      /// <summary> Required Argument for 'ImportSubjects' (SubjectStructure[]) </summary>
      [Required]
      public SubjectStructure[] subjects { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'ImportSubjects'.
    /// </summary>
    public class ImportSubjectsResponse {
      
      /// <summary> Out-Argument of 'ImportSubjects' (Guid[]) </summary>
      [Required]
      public Guid[] createdSubjectUids { get; set; }
      
      /// <summary> Out-Argument of 'ImportSubjects' (Guid[]) </summary>
      [Required]
      public Guid[] updatedSubjectUids { get; set; }
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
    }
    
  }
  
}
