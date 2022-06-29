/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalResearch.BillingData {
  
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
  /// 'ExecutorBilling', 'SponsorBilling'
  /// </summary>
  public class GetCapabilitiesRequest {
    
  }
  
  /// <summary>
  /// Contains results from calling 'GetCapabilities'.
  /// Method: returns a list of API-features (there are several 'services' for different use cases, described by ORSCF)
  /// supported by this implementation. The following values are possible:
  /// 'ExecutorBilling', 'SponsorBilling'
  /// </summary>
  public class GetCapabilitiesResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'GetCapabilities' (String[]) </summary>
    public string[] @return { get; set; } = null;
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetPermittedAuthScopes'.
  /// Method: returns a list of available capabilities ("API:ExecutorBilling") and/or
  /// data-scopes ("Site:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72")
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
  /// Method: returns a list of available capabilities ("API:ExecutorBilling") and/or
  /// data-scopes ("Site:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72")
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
