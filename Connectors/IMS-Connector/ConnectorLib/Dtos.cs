/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.IdentityManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalResearch.IdentityManagement {
  
  /// <summary>
  /// Contains arguments for calling 'RequestUnblindingToken'.
  /// Method: returns an unblindingToken which is not activated
  /// </summary>
  public class RequestUnblindingTokenRequest {
    
    /// <summary> Required Argument for 'RequestUnblindingToken' (string) </summary>
    [Required]
    public string researchStudyName { get; set; }
    
    /// <summary> Required Argument for 'RequestUnblindingToken' (string) </summary>
    [Required]
    public string subjectId { get; set; }
    
    /// <summary> Required Argument for 'RequestUnblindingToken' (string) </summary>
    [Required]
    public string reason { get; set; }
    
    /// <summary> Required Argument for 'RequestUnblindingToken' (string) </summary>
    [Required]
    public string requestingPerson { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'RequestUnblindingToken'.
  /// Method: returns an unblindingToken which is not activated
  /// </summary>
  public class RequestUnblindingTokenResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'RequestUnblindingToken' (String) </summary>
    public string @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetUnblindingTokenState'.
  /// Method: 0: not activated yet, 1=activated (can be used for 'UnblindSubject'), 2=expired/already used
  /// </summary>
  public class GetUnblindingTokenStateRequest {
    
    /// <summary> Required Argument for 'GetUnblindingTokenState' (string) </summary>
    [Required]
    public string unblindingToken { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'GetUnblindingTokenState'.
  /// Method: 0: not activated yet, 1=activated (can be used for 'UnblindSubject'), 2=expired/already used
  /// </summary>
  public class GetUnblindingTokenStateResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'GetUnblindingTokenState' (Int32) </summary>
    public Int32 @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'UnblindSubject'.
  /// Method: (only works with an activated unblindingOtp )
  /// </summary>
  public class UnblindSubjectRequest {
    
    /// <summary> Required Argument for 'UnblindSubject' (string) </summary>
    [Required]
    public string researchStudyName { get; set; }
    
    /// <summary> Required Argument for 'UnblindSubject' (string) </summary>
    [Required]
    public string subjectId { get; set; }
    
    /// <summary> Required Argument for 'UnblindSubject' (string) </summary>
    [Required]
    public string unblindingToken { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'UnblindSubject'.
  /// Method: (only works with an activated unblindingOtp )
  /// </summary>
  public class UnblindSubjectResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'UnblindSubject' (IdentityDetails) </summary>
    public IdentityDetails @return { get; set; }
    
  }
  
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
    public string @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetCapabilities'.
  /// Method: returns a list of API-features (there are several 'services' for different use cases, described by ORSCF)
  /// supported by this implementation. The following values are possible:
  /// 'Pseudonymization', 'IdentityUnblinding',
  /// </summary>
  public class GetCapabilitiesRequest {
    
  }
  
  /// <summary>
  /// Contains results from calling 'GetCapabilities'.
  /// Method: returns a list of API-features (there are several 'services' for different use cases, described by ORSCF)
  /// supported by this implementation. The following values are possible:
  /// 'Pseudonymization', 'IdentityUnblinding',
  /// </summary>
  public class GetCapabilitiesResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'GetCapabilities' (String[]) </summary>
    public string[] @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetPermittedAuthScopes'.
  /// Method: returns a list of available capabilities ("API:Pseudonymization") and/or
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
  /// Method: returns a list of available capabilities ("API:Pseudonymization") and/or
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
    public string[] @return { get; set; }
    
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
    public string @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetExtendedFieldDescriptors'.
  /// </summary>
  public class GetExtendedFieldDescriptorsRequest {
    
    /// <summary> Optional Argument for 'GetExtendedFieldDescriptors' (string): Preferred language for the 'DisplayLabel' and 'InputDescription' fields of the returned descriptors. </summary>
    public string languagePref { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'GetExtendedFieldDescriptors'.
  /// </summary>
  public class GetExtendedFieldDescriptorsResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'GetExtendedFieldDescriptors' (ExtendedFieldDescriptor[]) </summary>
    public ExtendedFieldDescriptor[] @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetOrCreatePseudonym'.
  /// </summary>
  public class GetOrCreatePseudonymRequest {
    
    /// <summary> Required Argument for 'GetOrCreatePseudonym' (Guid): A UUID </summary>
    [Required]
    public Guid researchStudyUid { get; set; }
    
    /// <summary> Required Argument for 'GetOrCreatePseudonym' (string): the Firstname a the paticipant (named as in the HL7 standard) </summary>
    [Required]
    public string givenName { get; set; }
    
    /// <summary> Required Argument for 'GetOrCreatePseudonym' (string) </summary>
    [Required]
    public string familyName { get; set; }
    
    /// <summary> Required Argument for 'GetOrCreatePseudonym' (string): date in format 'yyyy-MM-dd' (must NOT be a partial date for this usecase!) </summary>
    [Required]
    public string birthDate { get; set; }
    
    /// <summary> Required Argument for 'GetOrCreatePseudonym' (Dictionary(String,String)) </summary>
    [Required]
    public Dictionary<String,String> extendedFields { get; set; }
    
    /// <summary> Required Argument for 'GetOrCreatePseudonym' (Guid): A UUID </summary>
    [Required]
    public Guid siteUid { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'GetOrCreatePseudonym'.
  /// </summary>
  public class GetOrCreatePseudonymResponse {
    
    /// <summary> Out-Argument of 'GetOrCreatePseudonym' (string) </summary>
    [Required]
    public string pseudonym { get; set; }
    
    /// <summary> Out-Argument of 'GetOrCreatePseudonym' (bool) </summary>
    [Required]
    public bool wasCreatedNewly { get; set; }
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'GetOrCreatePseudonym' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetExisitingPseudonym'.
  /// </summary>
  public class GetExisitingPseudonymRequest {
    
    /// <summary> Required Argument for 'GetExisitingPseudonym' (Guid): A UUID </summary>
    [Required]
    public Guid researchStudyUid { get; set; }
    
    /// <summary> Required Argument for 'GetExisitingPseudonym' (string) </summary>
    [Required]
    public string givenName { get; set; }
    
    /// <summary> Required Argument for 'GetExisitingPseudonym' (string) </summary>
    [Required]
    public string familyName { get; set; }
    
    /// <summary> Required Argument for 'GetExisitingPseudonym' (string): date in format 'yyyy-MM-dd' (must NOT be a partial date for this usecase!) </summary>
    [Required]
    public string birthDate { get; set; }
    
    /// <summary> Required Argument for 'GetExisitingPseudonym' (Dictionary(String,String)) </summary>
    [Required]
    public Dictionary<String,String> extendedFields { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'GetExisitingPseudonym'.
  /// </summary>
  public class GetExisitingPseudonymResponse {
    
    /// <summary> Out-Argument of 'GetExisitingPseudonym' (string) </summary>
    [Required]
    public string pseudonym { get; set; }
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'GetExisitingPseudonym' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
}
