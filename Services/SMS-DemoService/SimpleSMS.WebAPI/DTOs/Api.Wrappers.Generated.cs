/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.StudyManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalResearch.StudyManagement.WebAPI {
  
  namespace InstituteMgmt {
    
    /// <summary>
    /// Contains arguments for calling 'GetInstituteUidByTitle'.
    /// </summary>
    public class GetInstituteUidByTitleRequest {
      
      /// <summary> Required Argument for 'GetInstituteUidByTitle' (string) </summary>
      [Required]
      public string instituteTitle { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'GetInstituteUidByTitle'.
    /// </summary>
    public class GetInstituteUidByTitleResponse {
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'GetInstituteUidByTitle' (Guid) </summary>
      public Guid @return { get; set; } = Guid.Empty;
      
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
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'GetInstituteTitleByUid' (String) </summary>
      public string @return { get; set; } = null;
      
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
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'ArchiveInstitute' (String) </summary>
      public string @return { get; set; } = null;
      
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
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'GetInstituteInfos' (InstituteInfo[]) </summary>
      public InstituteInfo[] @return { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'CreateInstituteIfMissing'.
    /// Method: ensures, that an institute with the given Uid exists
    /// and returns true, if it has been newly created
    /// </summary>
    public class CreateInstituteIfMissingRequest {
      
      /// <summary> Required Argument for 'CreateInstituteIfMissing' (Guid) </summary>
      [Required]
      public Guid instituteUid { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'CreateInstituteIfMissing'.
    /// Method: ensures, that an institute with the given Uid exists
    /// and returns true, if it has been newly created
    /// </summary>
    public class CreateInstituteIfMissingResponse {
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'CreateInstituteIfMissing' (Boolean) </summary>
      public bool @return { get; set; } = false;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'UpdateInstitueTitle'.
    /// Method: updated the title of the the institute or returns false,
    /// if there is no record for the given instituteUid
    /// </summary>
    public class UpdateInstitueTitleRequest {
      
      /// <summary> Required Argument for 'UpdateInstitueTitle' (Guid) </summary>
      [Required]
      public Guid instituteUid { get; set; }
      
      /// <summary> Required Argument for 'UpdateInstitueTitle' (string) </summary>
      [Required]
      public string newTitle { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'UpdateInstitueTitle'.
    /// Method: updated the title of the the institute or returns false,
    /// if there is no record for the given instituteUid
    /// </summary>
    public class UpdateInstitueTitleResponse {
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'UpdateInstitueTitle' (Boolean) </summary>
      public bool @return { get; set; } = false;
      
    }
    
  }
  
  namespace SiteParticipation {
    
  }
  
  namespace SmsApiInfo {
    
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
    /// 'InstituteMgmt', 'StudySetup', 'StudyAccess', 'SiteParticipation'
    /// </summary>
    public class GetCapabilitiesRequest {
      
    }
    
    /// <summary>
    /// Contains results from calling 'GetCapabilities'.
    /// Method: returns a list of API-features (there are several 'services' for different use cases, described by ORSCF)
    /// supported by this implementation. The following values are possible:
    /// 'InstituteMgmt', 'StudySetup', 'StudyAccess', 'SiteParticipation'
    /// </summary>
    public class GetCapabilitiesResponse {
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'GetCapabilities' (String[]) </summary>
      public string[] @return { get; set; } = null;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'GetPermittedAuthScopes'.
    /// Method: returns a list of available capabilities ("API:StudyAccess") and/or
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
    /// Method: returns a list of available capabilities ("API:StudyAccess") and/or
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
  
  namespace StudyAccess {
    
    /// <summary>
    /// Contains arguments for calling 'SubscribeStudyStateChangedEvents'.
    /// Method: Subscribes the Event when the State of a Study was changed
    /// to the given "EventQueue" which is accessable via "EventQueueService"
    /// (including http notifications)
    /// </summary>
    public class SubscribeStudyStateChangedEventsRequest {
      
      /// <summary> Required Argument for 'SubscribeStudyStateChangedEvents' (Guid) </summary>
      [Required]
      public Guid eventQueueId { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'SubscribeStudyStateChangedEvents'.
    /// Method: Subscribes the Event when the State of a Study was changed
    /// to the given "EventQueue" which is accessable via "EventQueueService"
    /// (including http notifications)
    /// </summary>
    public class SubscribeStudyStateChangedEventsResponse {
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'SubscribeStudyStateChangedEvents' (Boolean) </summary>
      public bool @return { get; set; } = false;
      
    }
    
    /// <summary>
    /// Contains arguments for calling 'UnsubscribeStudyStateChangedEvents'.
    /// Method: Unsubscribes the Event when the State of a Study was changed
    /// for the given "EventQueue"
    /// </summary>
    public class UnsubscribeStudyStateChangedEventsRequest {
      
      /// <summary> Required Argument for 'UnsubscribeStudyStateChangedEvents' (Guid) </summary>
      [Required]
      public Guid eventQueueId { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'UnsubscribeStudyStateChangedEvents'.
    /// Method: Unsubscribes the Event when the State of a Study was changed
    /// for the given "EventQueue"
    /// </summary>
    public class UnsubscribeStudyStateChangedEventsResponse {
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'UnsubscribeStudyStateChangedEvents' (Boolean) </summary>
      public bool @return { get; set; } = false;
      
    }
    
  }
  
  namespace StudySetup {
    
    /// <summary>
    /// Contains arguments for calling 'GetStudyTitleByIdentifier'.
    /// Method: returns null, if there is no matching record
    /// </summary>
    public class GetStudyTitleByIdentifierRequest {
      
      /// <summary> Required Argument for 'GetStudyTitleByIdentifier' (string) </summary>
      [Required]
      public string studyIdentifier { get; set; }
      
    }
    
    /// <summary>
    /// Contains results from calling 'GetStudyTitleByIdentifier'.
    /// Method: returns null, if there is no matching record
    /// </summary>
    public class GetStudyTitleByIdentifierResponse {
      
      /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
      public string fault { get; set; } = null;
      
      /// <summary> Return-Value of 'GetStudyTitleByIdentifier' (String) </summary>
      public string @return { get; set; } = null;
      
    }
    
  }
  
}
