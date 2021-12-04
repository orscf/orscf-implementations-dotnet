/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.StudyManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalResearch.StudyManagement {
  
  namespace InstituteRegistry {
  
  /// <summary>
  /// Contains arguments for calling 'GetInstituteUidByTitle'.
  /// </summary>
  public class GetInstituteUidByTitleRequest {
  
    /// <summary> Required Argument for 'GetInstituteUidByTitle' (String) </summary>
    [Required]
    public String instituteTitle { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetInstituteUidByTitle'.
  /// </summary>
  public class GetInstituteUidByTitleResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetInstituteUidByTitle' (Guid) </summary>
    public Guid @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetInstituteTitleByUid'.
  /// </summary>
  public class GetInstituteTitleByUidRequest {
  
    /// <summary> Required Argument for 'GetInstituteTitleByUid' (Guid) </summary>
    [Required]
    public Guid instituteUid { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetInstituteTitleByUid'.
  /// </summary>
  public class GetInstituteTitleByUidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetInstituteTitleByUid' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'ArchiveInstitute'.
  /// </summary>
  public class ArchiveInstituteRequest {
  
    /// <summary> Required Argument for 'ArchiveInstitute' (Guid) </summary>
    [Required]
    public Guid instituteUid { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'ArchiveInstitute'.
  /// </summary>
  public class ArchiveInstituteResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'ArchiveInstitute' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetInstituteInfos'.
  /// </summary>
  public class GetInstituteInfosRequest {
  
    /// <summary> Required Argument for 'GetInstituteInfos' (Guid) </summary>
    [Required]
    public Guid instituteUid { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetInstituteInfos'.
  /// </summary>
  public class GetInstituteInfosResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetInstituteInfos' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'CreateInstituteIfMissing'.
  /// Method: ensures, that an institute with the given Uid exists
  ///   and returns true, if it has been newly created
  /// </summary>
  public class CreateInstituteIfMissingRequest {
  
    /// <summary> Required Argument for 'CreateInstituteIfMissing' (Guid) </summary>
    [Required]
    public Guid instituteUid { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'CreateInstituteIfMissing'.
  /// Method: ensures, that an institute with the given Uid exists
  ///   and returns true, if it has been newly created
  /// </summary>
  public class CreateInstituteIfMissingResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'CreateInstituteIfMissing' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateInstitueTitle'.
  /// Method: updated the title of the the institute or returns false,
  ///   if there is no record for the given instituteUid
  /// </summary>
  public class UpdateInstitueTitleRequest {
  
    /// <summary> Required Argument for 'UpdateInstitueTitle' (Guid) </summary>
    [Required]
    public Guid instituteUid { get; set; }
  
    /// <summary> Required Argument for 'UpdateInstitueTitle' (String) </summary>
    [Required]
    public String newTitle { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateInstitueTitle'.
  /// Method: updated the title of the the institute or returns false,
  ///   if there is no record for the given instituteUid
  /// </summary>
  public class UpdateInstitueTitleResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateInstitueTitle' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetApiVersion'.
  /// Method: returns the Version of the API itself, which can be used for
  ///   backward compatibility within inhomogeneous infrastructures
  /// </summary>
  public class GetApiVersionRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetApiVersion'.
  /// Method: returns the Version of the API itself, which can be used for
  ///   backward compatibility within inhomogeneous infrastructures
  /// </summary>
  public class GetApiVersionResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetApiVersion' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'HasAccess'.
  /// Method: returns if the authenticated accessor of the
  ///   API has the permission to use this service
  /// </summary>
  public class HasAccessRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'HasAccess'.
  /// Method: returns if the authenticated accessor of the
  ///   API has the permission to use this service
  /// </summary>
  public class HasAccessResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'HasAccess' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  }
  
  namespace SiteParticipation {
  
  /// <summary>
  /// Contains arguments for calling 'GetApiVersion'.
  /// Method: returns the Version of the API itself, which can be used for
  ///   backward compatibility within inhomogeneous infrastructures
  /// </summary>
  public class GetApiVersionRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetApiVersion'.
  /// Method: returns the Version of the API itself, which can be used for
  ///   backward compatibility within inhomogeneous infrastructures
  /// </summary>
  public class GetApiVersionResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetApiVersion' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'HasAccess'.
  /// Method: returns if the authenticated accessor of the
  ///   API has the permission to use this service
  /// </summary>
  public class HasAccessRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'HasAccess'.
  /// Method: returns if the authenticated accessor of the
  ///   API has the permission to use this service
  /// </summary>
  public class HasAccessResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'HasAccess' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  }
  
  namespace StudyAccess {
  
  /// <summary>
  /// Contains arguments for calling 'SubscribeStudyStateChangedEvents'.
  /// Method: Subscribes the Event when the State of a Study was changed
  ///   to the given "EventQueue" which is accessable via "EventQueueService"
  ///   (including http notifications)
  /// </summary>
  public class SubscribeStudyStateChangedEventsRequest {
  
    /// <summary> Required Argument for 'SubscribeStudyStateChangedEvents' (Guid) </summary>
    [Required]
    public Guid eventQueueId { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'SubscribeStudyStateChangedEvents'.
  /// Method: Subscribes the Event when the State of a Study was changed
  ///   to the given "EventQueue" which is accessable via "EventQueueService"
  ///   (including http notifications)
  /// </summary>
  public class SubscribeStudyStateChangedEventsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'SubscribeStudyStateChangedEvents' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UnsubscribeStudyStateChangedEvents'.
  /// Method: Unsubscribes the Event when the State of a Study was changed
  ///   for the given "EventQueue"
  /// </summary>
  public class UnsubscribeStudyStateChangedEventsRequest {
  
    /// <summary> Required Argument for 'UnsubscribeStudyStateChangedEvents' (Guid) </summary>
    [Required]
    public Guid eventQueueId { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UnsubscribeStudyStateChangedEvents'.
  /// Method: Unsubscribes the Event when the State of a Study was changed
  ///   for the given "EventQueue"
  /// </summary>
  public class UnsubscribeStudyStateChangedEventsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UnsubscribeStudyStateChangedEvents' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetApiVersion'.
  /// Method: returns the Version of the API itself, which can be used for
  ///   backward compatibility within inhomogeneous infrastructures
  /// </summary>
  public class GetApiVersionRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetApiVersion'.
  /// Method: returns the Version of the API itself, which can be used for
  ///   backward compatibility within inhomogeneous infrastructures
  /// </summary>
  public class GetApiVersionResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetApiVersion' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'HasAccess'.
  /// Method: returns if the authenticated accessor of the
  ///   API has the permission to use this service
  /// </summary>
  public class HasAccessRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'HasAccess'.
  /// Method: returns if the authenticated accessor of the
  ///   API has the permission to use this service
  /// </summary>
  public class HasAccessResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'HasAccess' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  }
  
  namespace StudySetup {
  
  /// <summary>
  /// Contains arguments for calling 'GetStudyTitleByIdentifier'.
  /// Method: returns null, if there is no matching record
  /// </summary>
  public class GetStudyTitleByIdentifierRequest {
  
    /// <summary> Required Argument for 'GetStudyTitleByIdentifier' (String) </summary>
    [Required]
    public String studyIdentifier { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetStudyTitleByIdentifier'.
  /// Method: returns null, if there is no matching record
  /// </summary>
  public class GetStudyTitleByIdentifierResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetStudyTitleByIdentifier' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetApiVersion'.
  /// Method: returns the Version of the API itself, which can be used for
  ///   backward compatibility within inhomogeneous infrastructures
  /// </summary>
  public class GetApiVersionRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetApiVersion'.
  /// Method: returns the Version of the API itself, which can be used for
  ///   backward compatibility within inhomogeneous infrastructures
  /// </summary>
  public class GetApiVersionResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetApiVersion' (String) </summary>
    public String @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'HasAccess'.
  /// Method: returns if the authenticated accessor of the
  ///   API has the permission to use this service
  /// </summary>
  public class HasAccessRequest {
  
  }
  
  /// <summary>
  /// Contains results from calling 'HasAccess'.
  /// Method: returns if the authenticated accessor of the
  ///   API has the permission to use this service
  /// </summary>
  public class HasAccessResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'HasAccess' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  }
  
}
