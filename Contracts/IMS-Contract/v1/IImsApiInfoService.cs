using MedicalResearch.IdentityManagement.Model;
using System;

namespace MedicalResearch.IdentityManagement {

  public static class ImsCapabilities {

    public const string ImsApiInfo = "ImsApiInfo";
    public const string Pseudonymization = "Pseudonymization";
    public const string AgeEvaluation = "AgeEvaluation";
    public const string Unblinding = "Unblinding";
    public const string UnblindingClearanceAwaiter = "UnblindingClearanceAwaiter";
    public const string UnblindingClearanceGranting = "UnblindingClearanceGranting";

  }

  /// <summary> Provides interoperability information for the current implementation </summary>
  public partial interface IImsApiInfoService {

    /// <summary>
    /// returns the version of the ORSCF specification which is implemented by this API,
    /// (this can be used for backward compatibility within inhomogeneous infrastructures)
    /// </summary>
    string GetApiVersion();

    /// <summary>
    /// returns a list of API-features (there are several 'services' for different use cases, described by ORSCF)
    /// supported by this implementation. The following values are possible: 
    /// 'ImsApiInfo',
    /// 'Pseudonymization',
    /// 'AgeEvaluation',
    /// 'Unblinding',
    /// 'UnblindingClearanceAwaiter'  (backend workflow for "PASSIVE-APPROVAL"),
    /// 'UnblindingClearanceGranting' (backend workflow for "ACTIVE-APPROVAL")
    /// </summary>
    string[] GetCapabilities();

    /// <summary>
    /// returns a list of available capabilities ("API:Pseudonymization") and/or
    /// data-scopes ("Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72")
    /// which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be:
    ///  0=auth needed /
    ///  1=authenticated /
    /// -1=auth expired /
    /// -2=auth invalid/disabled
    /// </summary>
    string[] GetPermittedAuthScopes(out int authState);

    /// <summary>
    /// OPTIONAL: If the authentication on the current service is mapped
    /// using tokens and should provide information about the source at this point,
    /// the login URL to be called up via browser (OAuth <see href="https://openid.net/specs/openid-client-initiated-backchannel-authentication-core-1_0.html">'CIBA-Flow'</see>) is returned here.
    /// </summary>
    string GetOAuthTokenRequestUrl();

    /// <summary> 
    /// </summary>
    /// <param name="languagePref">
    ///   Preferred language for the 'DisplayLabel' and 'InputDescription' fields of the returned descriptors.
    ///   ONLY RELEVANT FOR THE UI!
    /// </param>
    /// <returns></returns>
    ExtendedFieldDescriptor[] GetExtendedFieldDescriptors(
      string languagePref = "EN"
    );

  }

}
