/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.IdentityManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalResearch.IdentityManagement {
  
  /// <summary>
  /// Contains arguments for calling 'GrantClearanceForUnblinding'.
  /// </summary>
  public class GrantClearanceForUnblindingRequest {
    
    /// <summary> Required Argument for 'GrantClearanceForUnblinding' (string) </summary>
    [Required]
    public string unblindingToken { get; set; }
    
    /// <summary> Required Argument for 'GrantClearanceForUnblinding' (string[]) </summary>
    [Required]
    public string[] pseudonymsToUnblind { get; set; }
    
    /// <summary> Required Argument for 'GrantClearanceForUnblinding' (DateTime) </summary>
    [Required]
    public DateTime grantedUnitl { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'GrantClearanceForUnblinding'.
  /// </summary>
  public class GrantClearanceForUnblindingResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'HasClearanceForUnblinding'.
  /// Method: Returns:
  /// 1: if clearance granted /
  /// 0: if no realtime response is possible (delayed approval)
  /// -1: if a new unblindingToken is required (because the current has expired or has been repressed) /
  /// -2: if the access is denied for addressed scope of data
  /// </summary>
  public class HasClearanceForUnblindingRequest {
    
    /// <summary> Required Argument for 'HasClearanceForUnblinding' (string) </summary>
    [Required]
    public string unblindingToken { get; set; }
    
    /// <summary> Required Argument for 'HasClearanceForUnblinding' (string[]) </summary>
    [Required]
    public string[] pseudonymsToUnblind { get; set; }
    
    /// <summary> Required Argument for 'HasClearanceForUnblinding' (Dictionary(String,String)): an optional container that can contain for example the ipadress or JWT token of the accessor or some MFA related information </summary>
    [Required]
    public Dictionary<String,String> accessRelatedDetails { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'HasClearanceForUnblinding'.
  /// Method: Returns:
  /// 1: if clearance granted /
  /// 0: if no realtime response is possible (delayed approval)
  /// -1: if a new unblindingToken is required (because the current has expired or has been repressed) /
  /// -2: if the access is denied for addressed scope of data
  /// </summary>
  public class HasClearanceForUnblindingResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'HasClearanceForUnblinding' (Int32) </summary>
    public Int32 @return { get; set; } = 0;
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'EvaluateAge'.
  /// Method: Calculates the age (only the integer Year) of several persons for a given date.
  /// This is supporting the very common usecase to evaluate inclusion criteria for research studies where the date of birth is not present alongside of the medical data.
  /// It allows for minimalist access disclosing the date of birth information (as happening when unblinding).
  /// </summary>
  public class EvaluateAgeRequest {
    
    /// <summary> Required Argument for 'EvaluateAge' (DateTime) </summary>
    [Required]
    public DateTime momentOfValuation { get; set; }
    
    /// <summary> Required Argument for 'EvaluateAge' (string[]) </summary>
    [Required]
    public string[] pseudonymesToEvaluate { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'EvaluateAge'.
  /// Method: Calculates the age (only the integer Year) of several persons for a given date.
  /// This is supporting the very common usecase to evaluate inclusion criteria for research studies where the date of birth is not present alongside of the medical data.
  /// It allows for minimalist access disclosing the date of birth information (as happening when unblinding).
  /// </summary>
  public class EvaluateAgeResponse {
    
    /// <summary> Out-Argument of 'EvaluateAge' (Int32[]): Returns an array with the same amount of fields as the given 'pseudonymesToEvaluate'-array. If it was not possible to evalute the age beacuse of not present data, then the corresponding array-field will contain a value of -1! </summary>
    [Required]
    public Int32[] ages { get; set; }
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
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
    public string @return { get; set; } = null;
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetCapabilities'.
  /// Method: returns a list of API-features (there are several 'services' for different use cases, described by ORSCF)
  /// supported by this implementation. The following values are possible:
  /// 'ImsApiInfo',
  /// 'Pseudonymization',
  /// 'AgeEvaluation',
  /// 'Unblinding',
  /// 'UnblindingClearanceAwaiter'  (backend workflow for "PASSIVE-APPROVAL"),
  /// 'UnblindingClearanceGranting' (backend workflow for "ACTIVE-APPROVAL")
  /// </summary>
  public class GetCapabilitiesRequest {
    
  }
  
  /// <summary>
  /// Contains results from calling 'GetCapabilities'.
  /// Method: returns a list of API-features (there are several 'services' for different use cases, described by ORSCF)
  /// supported by this implementation. The following values are possible:
  /// 'ImsApiInfo',
  /// 'Pseudonymization',
  /// 'AgeEvaluation',
  /// 'Unblinding',
  /// 'UnblindingClearanceAwaiter'  (backend workflow for "PASSIVE-APPROVAL"),
  /// 'UnblindingClearanceGranting' (backend workflow for "ACTIVE-APPROVAL")
  /// </summary>
  public class GetCapabilitiesResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'GetCapabilities' (String[]) </summary>
    public string[] @return { get; set; } = null;
    
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
  
  /// <summary>
  /// Contains arguments for calling 'GetExtendedFieldDescriptors'.
  /// </summary>
  public class GetExtendedFieldDescriptorsRequest {
    
    /// <summary> Optional Argument for 'GetExtendedFieldDescriptors' (string): Preferred language for the 'DisplayLabel' and 'InputDescription' fields of the returned descriptors. ONLY RELEVANT FOR THE UI! </summary>
    public string languagePref { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'GetExtendedFieldDescriptors'.
  /// </summary>
  public class GetExtendedFieldDescriptorsResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'GetExtendedFieldDescriptors' (ExtendedFieldDescriptor[]) </summary>
    public ExtendedFieldDescriptor[] @return { get; set; } = null;
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetOrCreatePseudonym'.
  /// </summary>
  public class GetOrCreatePseudonymRequest {
    
    /// <summary> Required Argument for 'GetOrCreatePseudonym' (string): the Firstname a person (named as in the HL7 standard) </summary>
    [Required]
    public string givenName { get; set; }
    
    /// <summary> Required Argument for 'GetOrCreatePseudonym' (string) </summary>
    [Required]
    public string familyName { get; set; }
    
    /// <summary> Required Argument for 'GetOrCreatePseudonym' (string): date in format 'yyyy-MM-dd' (must NOT be a partial date for this usecase!) </summary>
    [Required]
    public string birthDate { get; set; }
    
    /// <summary> Required Argument for 'GetOrCreatePseudonym' (Dictionary(String,String)): additional values for each 'extendedField' that is mandatory within (and specific to) the current IMS-System. To retrieve the declarations for such fields call 'GetExtendedFieldDescriptors' </summary>
    [Required]
    public Dictionary<String,String> extendedFields { get; set; }
    
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
    public bool @return { get; set; } = false;
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetExisitingPseudonym'.
  /// </summary>
  public class GetExisitingPseudonymRequest {
    
    /// <summary> Required Argument for 'GetExisitingPseudonym' (string) </summary>
    [Required]
    public string givenName { get; set; }
    
    /// <summary> Required Argument for 'GetExisitingPseudonym' (string) </summary>
    [Required]
    public string familyName { get; set; }
    
    /// <summary> Required Argument for 'GetExisitingPseudonym' (string): date in format 'yyyy-MM-dd' (must NOT be a partial date for this usecase!) </summary>
    [Required]
    public string birthDate { get; set; }
    
    /// <summary> Required Argument for 'GetExisitingPseudonym' (Dictionary(String,String)): additional values for each 'extendedField' that is mandatory within (and specific to) the current IMS-System. To retrieve the declarations for such fields call 'GetExtendedFieldDescriptors' </summary>
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
    public bool @return { get; set; } = false;
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'RequestUnblindingToken'.
  /// Method: Returns:
  /// 1: if clearance granted (token can be DIRECTLY used to call 'TryUnblind') /
  /// 0: if no realtime response is possible (delayed approval is outstanding)
  /// -1: if a new unblindingToken is required (because the current has expired or has been repressed) /
  /// -2: if the access is denied for addressed scope of data
  /// </summary>
  public class RequestUnblindingTokenRequest {
    
    /// <summary> Required Argument for 'RequestUnblindingToken' (string[]) </summary>
    [Required]
    public string[] pseudonymsToUnblind { get; set; }
    
    /// <summary> Required Argument for 'RequestUnblindingToken' (string) </summary>
    [Required]
    public string requestReason { get; set; }
    
    /// <summary> Required Argument for 'RequestUnblindingToken' (string) </summary>
    [Required]
    public string requestBy { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'RequestUnblindingToken'.
  /// Method: Returns:
  /// 1: if clearance granted (token can be DIRECTLY used to call 'TryUnblind') /
  /// 0: if no realtime response is possible (delayed approval is outstanding)
  /// -1: if a new unblindingToken is required (because the current has expired or has been repressed) /
  /// -2: if the access is denied for addressed scope of data
  /// </summary>
  public class RequestUnblindingTokenResponse {
    
    /// <summary> Out-Argument of 'RequestUnblindingToken' (string) </summary>
    [Required]
    public string unblindingToken { get; set; }
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'RequestUnblindingToken' (Int32) </summary>
    public Int32 @return { get; set; } = 0;
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'TryUnblind'.
  /// Method: Returns:
  /// 1: on SUCCESS (unblindedIdentities should contain data) /
  /// 0: if no realtime response is possible (delayed approval is outstanding)
  /// -1: if a new unblindingToken is required (because the current has expired or has been repressed) /
  /// -2: if the access is denied for addressed scope of data
  /// </summary>
  public class TryUnblindRequest {
    
    /// <summary> Required Argument for 'TryUnblind' (string) </summary>
    [Required]
    public string unblindingToken { get; set; }
    
    /// <summary> Required Argument for 'TryUnblind' (string[]) </summary>
    [Required]
    public string[] pseudonymsToUnblind { get; set; }
    
    /// <summary> Required Argument for 'TryUnblind' (IdentityDetails[]) </summary>
    [Required]
    public IdentityDetails[] unblindedIdentities { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'TryUnblind'.
  /// Method: Returns:
  /// 1: on SUCCESS (unblindedIdentities should contain data) /
  /// 0: if no realtime response is possible (delayed approval is outstanding)
  /// -1: if a new unblindingToken is required (because the current has expired or has been repressed) /
  /// -2: if the access is denied for addressed scope of data
  /// </summary>
  public class TryUnblindResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'TryUnblind' (Int32) </summary>
    public Int32 @return { get; set; } = 0;
    
  }
  
}
