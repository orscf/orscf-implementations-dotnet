using System;

namespace MedicalResearch.VisitData {

  public static class VdrCapabilities {

    public const string VdrEventSubscription = "VdrEventSubscription";

    public const string VisitConsume = "VisitConsume";
    public const string VisitSubmission = "VisitSubmission";
    public const string VisitHL7Export = "VisitHL7Export";
    public const string VisitHL7Import = "VisitHL7Import";




    //public const string DataRecordingConsume = "DataRecordingConsume";
    public const string DataRecordingSubmission = "DataRecordingSubmission";
    public const string DataEnrollment = "DataEnrollment";
    //public const string DataRecordingHL7Export = "DataRecordingHL7Export";
    //public const string DataRecordingHL7Import = "DataRecordingHL7Import";

  }

  /// <summary> Provides interoperability information for the current implementation </summary>
  public partial interface IVdrApiInfoService {

    /// <summary>
    /// returns the version of the ORSCF specification which is implemented by this API,
    /// (this can be used for backward compatibility within inhomogeneous infrastructures)
    /// </summary>
    string GetApiVersion();

    /// <summary>
    /// returns a list of API-features (there are several 'services' for different use cases, described by ORSCF)
    /// supported by this implementation. The following values are possible:
    /// 'VdrEventSubscription', 
    /// 'VisitConsume', 
    /// 'VisitSubmission', 
    /// 'VisitHL7Export', 
    /// 'VisitHL7Import',
    /// 'DataRecordingSubmission'
    /// </summary>
    string[] GetCapabilities();

    /// <summary>
    /// returns a list of available capabilities ("API:VisitDataConsume") and/or
    /// data-scopes ("Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72")
    /// which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be:
    ///  0=auth needed /
    ///  1=authenticated /
    /// -1=auth expired /
    /// -2=auth invalid/disabled
    /// </summary>
    /// <param name="authState"></param>
    /// <returns></returns>
    string[] GetPermittedAuthScopes(out int authState);

    /// <summary>
    /// OPTIONAL: If the authentication on the current service is mapped
    /// using tokens and should provide information about the source at this point,
    /// the login URL to be called up via browser (OAuth <see href="https://openid.net/specs/openid-client-initiated-backchannel-authentication-core-1_0.html">'CIBA-Flow'</see>) is returned here.
    /// </summary>
    string GetOAuthTokenRequestUrl();

  }

}
