/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.IdentityManagement.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace MedicalResearch.IdentityManagement {
  
  public partial class ImsApiConnector {
    
    public ImsApiConnector(string url, string apiToken) {
      
      if (!url.EndsWith("/")) {
        url = url + "/";
      }
      
      _IdentityUnblindingServiceClient = new IdentityUnblindingServiceClient(url + "identityUnblindingService/", apiToken);
      _ImsApiInfoServiceClient = new ImsApiInfoServiceClient(url + "imsApiInfoService/", apiToken);
      _PseudonymizationServiceClient = new PseudonymizationServiceClient(url + "pseudonymizationService/", apiToken);
      
    }
    
    private IdentityUnblindingServiceClient _IdentityUnblindingServiceClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS) </summary>
    public IIdentityUnblindingService IdentityUnblindingService {
      get {
        return _IdentityUnblindingServiceClient;
      }
    }
    
    private ImsApiInfoServiceClient _ImsApiInfoServiceClient = null;
    /// <summary> Provides interoperability information for the current implementation </summary>
    public IImsApiInfoService ImsApiInfoService {
      get {
        return _ImsApiInfoServiceClient;
      }
    }
    
    private PseudonymizationServiceClient _PseudonymizationServiceClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS) </summary>
    public IPseudonymizationService PseudonymizationService {
      get {
        return _PseudonymizationServiceClient;
      }
    }
    
  }
  
  /// <summary> Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS) </summary>
  internal partial class IdentityUnblindingServiceClient : IIdentityUnblindingService {
    
    private string _Url;
    private string _ApiToken;
    
    public IdentityUnblindingServiceClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> returns an unblindingToken which is not activated </summary>
    /// <param name="researchStudyName">  </param>
    /// <param name="subjectId">  </param>
    /// <param name="reason">  </param>
    /// <param name="requestingPerson">  </param>
    public String RequestUnblindingToken(string researchStudyName, string subjectId, string reason, string requestingPerson) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "requestUnblindingToken";
        var args = new RequestUnblindingTokenRequest {
          researchStudyName = researchStudyName,
          subjectId = subjectId,
          reason = reason,
          requestingPerson = requestingPerson
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<RequestUnblindingTokenResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> 0: not activated yet, 1=activated (can be used for 'UnblindSubject'), 2=expired/already used </summary>
    /// <param name="unblindingToken">  </param>
    public Int32 GetUnblindingTokenState(string unblindingToken) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getUnblindingTokenState";
        var args = new GetUnblindingTokenStateRequest {
          unblindingToken = unblindingToken
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetUnblindingTokenStateResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> (only works with an activated unblindingOtp ) </summary>
    /// <param name="researchStudyName">  </param>
    /// <param name="subjectId">  </param>
    /// <param name="unblindingToken">  </param>
    public IdentityDetails UnblindSubject(string researchStudyName, string subjectId, string unblindingToken) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "unblindSubject";
        var args = new UnblindSubjectRequest {
          researchStudyName = researchStudyName,
          subjectId = subjectId,
          unblindingToken = unblindingToken
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UnblindSubjectResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides interoperability information for the current implementation </summary>
  internal partial class ImsApiInfoServiceClient : IImsApiInfoService {
    
    private string _Url;
    private string _ApiToken;
    
    public ImsApiInfoServiceClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> returns the version of the ORSCF specification which is implemented by this API, (this can be used for backward compatibility within inhomogeneous infrastructures) </summary>
    public String GetApiVersion() {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getApiVersion";
        var args = new GetApiVersionRequest {
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetApiVersionResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'Pseudonymization', 'IdentityUnblinding', </summary>
    public String[] GetCapabilities() {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getCapabilities";
        var args = new GetCapabilitiesRequest {
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetCapabilitiesResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> returns a list of available capabilities ("API:Pseudonymization") and/or data-scopes ("Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72") which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be: 0=auth needed / 1=authenticated / -1=auth expired / -2=auth invalid/disabled </summary>
    /// <param name="authState">  </param>
    public String[] GetPermittedAuthScopes(out Int32 authState) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getPermittedAuthScopes";
        var args = new GetPermittedAuthScopesRequest {
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetPermittedAuthScopesResponse>(rawResponse);
        authState = result.authState;
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> OPTIONAL: If the authentication on the current service is mapped using tokens and should provide information about the source at this point, the login URL to be called up via browser (OAuth <see href="https://openid.net/specs/openid-client-initiated-backchannel-authentication-core-1_0.html">'CIBA-Flow'</see>) is returned here. </summary>
    public String GetOAuthTokenRequestUrl() {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getOAuthTokenRequestUrl";
        var args = new GetOAuthTokenRequestUrlRequest {
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetOAuthTokenRequestUrlResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
  /// <summary> Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS) </summary>
  internal partial class PseudonymizationServiceClient : IPseudonymizationService {
    
    private string _Url;
    private string _ApiToken;
    
    public PseudonymizationServiceClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> GetExtendedFieldDescriptors </summary>
    /// <param name="languagePref"> Preferred language for the 'DisplayLabel' and 'InputDescription' fields of the returned descriptors. </param>
    public ExtendedFieldDescriptor[] GetExtendedFieldDescriptors(string languagePref = "EN") {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getExtendedFieldDescriptors";
        var args = new GetExtendedFieldDescriptorsRequest {
          languagePref = languagePref
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetExtendedFieldDescriptorsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> GetOrCreatePseudonym </summary>
    /// <param name="researchStudyUid"> A UUID </param>
    /// <param name="givenName"> the Firstname a the paticipant (named as in the HL7 standard) </param>
    /// <param name="familyName">  </param>
    /// <param name="birthDate"> date in format 'yyyy-MM-dd' (must NOT be a partial date for this usecase!) </param>
    /// <param name="extendedFields">  </param>
    /// <param name="siteUid"> A UUID </param>
    /// <param name="pseudonym">  </param>
    /// <param name="wasCreatedNewly">  </param>
    public Boolean GetOrCreatePseudonym(Guid researchStudyUid, string givenName, string familyName, string birthDate, Dictionary<string, string> extendedFields, Guid siteUid, out string pseudonym, out bool wasCreatedNewly) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getOrCreatePseudonym";
        var args = new GetOrCreatePseudonymRequest {
          researchStudyUid = researchStudyUid,
          givenName = givenName,
          familyName = familyName,
          birthDate = birthDate,
          extendedFields = extendedFields,
          siteUid = siteUid,
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetOrCreatePseudonymResponse>(rawResponse);
        pseudonym = result.pseudonym;
        wasCreatedNewly = result.wasCreatedNewly;
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> GetExisitingPseudonym </summary>
    /// <param name="researchStudyUid"> A UUID </param>
    /// <param name="givenName">  </param>
    /// <param name="familyName">  </param>
    /// <param name="birthDate"> date in format 'yyyy-MM-dd' (must NOT be a partial date for this usecase!) </param>
    /// <param name="extendedFields">  </param>
    /// <param name="pseudonym">  </param>
    public Boolean GetExisitingPseudonym(Guid researchStudyUid, string givenName, string familyName, string birthDate, Dictionary<string, string> extendedFields, out string pseudonym) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getExisitingPseudonym";
        var args = new GetExisitingPseudonymRequest {
          researchStudyUid = researchStudyUid,
          givenName = givenName,
          familyName = familyName,
          birthDate = birthDate,
          extendedFields = extendedFields,
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetExisitingPseudonymResponse>(rawResponse);
        pseudonym = result.pseudonym;
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
}
