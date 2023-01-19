/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.IdentityManagement.AgeEvaluation;
using MedicalResearch.IdentityManagement.ImsApiInfo;
using MedicalResearch.IdentityManagement.Model;
using MedicalResearch.IdentityManagement.Pseudonymization;
using MedicalResearch.IdentityManagement.Unblinding;
using MedicalResearch.IdentityManagement.UnblindingClearanceAwaiter;
using MedicalResearch.IdentityManagement.UnblindingClearanceGranting;
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
      
      _UnblindingClearanceAwaiterClient = new UnblindingClearanceAwaiterClient(url + "unblindingClearanceAwaiter/", apiToken);
      _UnblindingClearanceGrantingClient = new UnblindingClearanceGrantingClient(url + "unblindingClearanceGranting/", apiToken);
      _AgeEvaluationClient = new AgeEvaluationClient(url + "ageEvaluation/", apiToken);
      _ImsApiInfoClient = new ImsApiInfoClient(url + "imsApiInfo/", apiToken);
      _PseudonymizationClient = new PseudonymizationClient(url + "pseudonymization/", apiToken);
      _UnblindingClient = new UnblindingClient(url + "unblinding/", apiToken);
      
    }
    
    private UnblindingClearanceAwaiterClient _UnblindingClearanceAwaiterClient = null;
    /// <summary> Following the "PASSIVE-APPROVAL" Workflow, this endpoint is directly implemented on the IMS! "PASSIVE-APPROVAL" is based on the idea, that clearances have to be (pre-)delivered by a foreign master system ('push' principle) </summary>
    public IUnblindingClearanceAwaiterService UnblindingClearanceAwaiter {
      get {
        return _UnblindingClearanceAwaiterClient;
      }
    }
    
    private UnblindingClearanceGrantingClient _UnblindingClearanceGrantingClient = null;
    /// <summary> Following the "ACTIVE-APPROVAL" Workflow, this endpoint is usually implemented on a FOREIGN system, that should be queried by an IMS! "ACTIVE-APPROVAL" is based on the idea, that clearances have to be requested on demand from a foreign master system  ('pull' principle) </summary>
    public IUnblindingClearanceGrantingService UnblindingClearanceGranting {
      get {
        return _UnblindingClearanceGrantingClient;
      }
    }
    
    private AgeEvaluationClient _AgeEvaluationClient = null;
    public IAgeEvaluationService AgeEvaluation {
      get {
        return _AgeEvaluationClient;
      }
    }
    
    private ImsApiInfoClient _ImsApiInfoClient = null;
    /// <summary> Provides interoperability information for the current implementation </summary>
    public IImsApiInfoService ImsApiInfo {
      get {
        return _ImsApiInfoClient;
      }
    }
    
    private PseudonymizationClient _PseudonymizationClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS) </summary>
    public IPseudonymizationService Pseudonymization {
      get {
        return _PseudonymizationClient;
      }
    }
    
    private UnblindingClient _UnblindingClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS) </summary>
    public IUnblindingService Unblinding {
      get {
        return _UnblindingClient;
      }
    }
    
  }
  
  namespace UnblindingClearanceAwaiter {
    
    /// <summary> Following the "PASSIVE-APPROVAL" Workflow, this endpoint is directly implemented on the IMS! "PASSIVE-APPROVAL" is based on the idea, that clearances have to be (pre-)delivered by a foreign master system ('push' principle) </summary>
    internal partial class UnblindingClearanceAwaiterClient : IUnblindingClearanceAwaiterService {
      
      private string _Url;
      private string _ApiToken;
      
      public UnblindingClearanceAwaiterClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> GrantClearanceForUnblinding </summary>
      /// <param name="unblindingToken">  </param>
      /// <param name="pseudonymsToUnblind">  </param>
      /// <param name="grantedUnitl">  </param>
      public void GrantClearanceForUnblinding(string unblindingToken, string[] pseudonymsToUnblind, DateTime grantedUnitl) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "grantClearanceForUnblinding";
          var requestWrapper = new GrantClearanceForUnblindingRequest {
            unblindingToken = unblindingToken,
            pseudonymsToUnblind = pseudonymsToUnblind,
            grantedUnitl = grantedUnitl
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GrantClearanceForUnblindingResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
    }
    
  }
  
  namespace UnblindingClearanceGranting {
    
    /// <summary> Following the "ACTIVE-APPROVAL" Workflow, this endpoint is usually implemented on a FOREIGN system, that should be queried by an IMS! "ACTIVE-APPROVAL" is based on the idea, that clearances have to be requested on demand from a foreign master system  ('pull' principle) </summary>
    internal partial class UnblindingClearanceGrantingClient : IUnblindingClearanceGrantingService {
      
      private string _Url;
      private string _ApiToken;
      
      public UnblindingClearanceGrantingClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> Returns: 1: if clearance granted / 0: if no realtime response is possible (delayed approval) -1: if a new unblindingToken is required (because the current has expired or has been repressed) / -2: if the access is denied for addressed scope of data </summary>
      /// <param name="unblindingToken">  </param>
      /// <param name="pseudonymsToUnblind">  </param>
      /// <param name="accessRelatedDetails"> an optional container that can contain for example the ipadress or JWT token of the accessor or some MFA related information </param>
      public Int32 HasClearanceForUnblinding(string unblindingToken, string[] pseudonymsToUnblind, Dictionary<String,String> accessRelatedDetails) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "hasClearanceForUnblinding";
          var requestWrapper = new HasClearanceForUnblindingRequest {
            unblindingToken = unblindingToken,
            pseudonymsToUnblind = pseudonymsToUnblind,
            accessRelatedDetails = accessRelatedDetails
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<HasClearanceForUnblindingResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
    }
    
  }
  
  namespace AgeEvaluation {
    
    internal partial class AgeEvaluationClient : IAgeEvaluationService {
      
      private string _Url;
      private string _ApiToken;
      
      public AgeEvaluationClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> Calculates the age (only the integer Year) of several persons for a given date. This is supporting the very common usecase to evaluate inclusion criteria for research studies where the date of birth is not present alongside of the medical data. It allows for minimalist access disclosing the date of birth information (as happening when unblinding). </summary>
      /// <param name="momentOfValuation">  </param>
      /// <param name="pseudonymesToEvaluate">  </param>
      /// <param name="ages"> Returns an array with the same amount of fields as the given 'pseudonymesToEvaluate'-array. If it was not possible to evalute the age beacuse of not present data, then the corresponding array-field will contain a value of -1! </param>
      public void EvaluateAge(DateTime momentOfValuation, string[] pseudonymesToEvaluate, out Int32[] ages) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "evaluateAge";
          var requestWrapper = new EvaluateAgeRequest {
            momentOfValuation = momentOfValuation,
            pseudonymesToEvaluate = pseudonymesToEvaluate,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<EvaluateAgeResponse>(rawResponse);
          ages = responseWrapper.ages;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
    }
    
  }
  
  namespace ImsApiInfo {
    
    /// <summary> Provides interoperability information for the current implementation </summary>
    internal partial class ImsApiInfoClient : IImsApiInfoService {
      
      private string _Url;
      private string _ApiToken;
      
      public ImsApiInfoClient(string url, string apiToken) {
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
          var requestWrapper = new GetApiVersionRequest {
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetApiVersionResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'ImsApiInfo', 'Pseudonymization', 'AgeEvaluation', 'Unblinding', 'UnblindingClearanceAwaiter'  (backend workflow for "PASSIVE-APPROVAL"), 'UnblindingClearanceGranting' (backend workflow for "ACTIVE-APPROVAL") </summary>
      public String[] GetCapabilities() {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getCapabilities";
          var requestWrapper = new GetCapabilitiesRequest {
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetCapabilitiesResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> returns a list of available capabilities ("API:Pseudonymization") and/or data-scopes ("Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72") which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be: 0=auth needed / 1=authenticated / -1=auth expired / -2=auth invalid/disabled </summary>
      /// <param name="authState">  </param>
      public String[] GetPermittedAuthScopes(out Int32 authState) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getPermittedAuthScopes";
          var requestWrapper = new GetPermittedAuthScopesRequest {
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetPermittedAuthScopesResponse>(rawResponse);
          authState = responseWrapper.authState;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> OPTIONAL: If the authentication on the current service is mapped using tokens and should provide information about the source at this point, the login URL to be called up via browser (OAuth <see href="https://openid.net/specs/openid-client-initiated-backchannel-authentication-core-1_0.html">'CIBA-Flow'</see>) is returned here. </summary>
      public String GetOAuthTokenRequestUrl() {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getOAuthTokenRequestUrl";
          var requestWrapper = new GetOAuthTokenRequestUrlRequest {
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetOAuthTokenRequestUrlResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> GetExtendedFieldDescriptors </summary>
      /// <param name="languagePref"> Preferred language for the 'DisplayLabel' and 'InputDescription' fields of the returned descriptors. ONLY RELEVANT FOR THE UI! </param>
      public ExtendedFieldDescriptor[] GetExtendedFieldDescriptors(string languagePref = "EN") {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getExtendedFieldDescriptors";
          var requestWrapper = new GetExtendedFieldDescriptorsRequest {
            languagePref = languagePref
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetExtendedFieldDescriptorsResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
    }
    
  }
  
  namespace Pseudonymization {
    
    /// <summary> Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS) </summary>
    internal partial class PseudonymizationClient : IPseudonymizationService {
      
      private string _Url;
      private string _ApiToken;
      
      public PseudonymizationClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> GetOrCreatePseudonym </summary>
      /// <param name="givenName"> the Firstname a person (named as in the HL7 standard) </param>
      /// <param name="familyName">  </param>
      /// <param name="birthDate"> date in format 'yyyy-MM-dd' (must NOT be a partial date for this usecase!) </param>
      /// <param name="extendedFields"> additional values for each 'extendedField' that is mandatory within (and specific to) the current IMS-System. To retrieve the declarations for such fields call 'GetExtendedFieldDescriptors' </param>
      /// <param name="pseudonym">  </param>
      /// <param name="wasCreatedNewly">  </param>
      public Boolean GetOrCreatePseudonym(string givenName, string familyName, string birthDate, Dictionary<String,String> extendedFields, out string pseudonym, out bool wasCreatedNewly) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getOrCreatePseudonym";
          var requestWrapper = new GetOrCreatePseudonymRequest {
            givenName = givenName,
            familyName = familyName,
            birthDate = birthDate,
            extendedFields = extendedFields,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetOrCreatePseudonymResponse>(rawResponse);
          pseudonym = responseWrapper.pseudonym;
          wasCreatedNewly = responseWrapper.wasCreatedNewly;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> GetExisitingPseudonym </summary>
      /// <param name="givenName">  </param>
      /// <param name="familyName">  </param>
      /// <param name="birthDate"> date in format 'yyyy-MM-dd' (must NOT be a partial date for this usecase!) </param>
      /// <param name="extendedFields"> additional values for each 'extendedField' that is mandatory within (and specific to) the current IMS-System. To retrieve the declarations for such fields call 'GetExtendedFieldDescriptors' </param>
      /// <param name="pseudonym">  </param>
      public Boolean GetExisitingPseudonym(string givenName, string familyName, string birthDate, Dictionary<String,String> extendedFields, out string pseudonym) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getExisitingPseudonym";
          var requestWrapper = new GetExisitingPseudonymRequest {
            givenName = givenName,
            familyName = familyName,
            birthDate = birthDate,
            extendedFields = extendedFields,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetExisitingPseudonymResponse>(rawResponse);
          pseudonym = responseWrapper.pseudonym;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
    }
    
  }
  
  namespace Unblinding {
    
    /// <summary> Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS) </summary>
    internal partial class UnblindingClient : IUnblindingService {
      
      private string _Url;
      private string _ApiToken;
      
      public UnblindingClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> Returns: 1: if clearance granted (token can be DIRECTLY used to call 'TryUnblind') / 0: if no realtime response is possible (delayed approval is outstanding) -1: if a new unblindingToken is required (because the current has expired or has been repressed) / -2: if the access is denied for addressed scope of data </summary>
      /// <param name="pseudonymsToUnblind">  </param>
      /// <param name="requestReason">  </param>
      /// <param name="requestBy">  </param>
      /// <param name="unblindingToken">  </param>
      public Int32 RequestUnblindingToken(string[] pseudonymsToUnblind, string requestReason, string requestBy, out string unblindingToken) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "requestUnblindingToken";
          var requestWrapper = new RequestUnblindingTokenRequest {
            pseudonymsToUnblind = pseudonymsToUnblind,
            requestReason = requestReason,
            requestBy = requestBy,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<RequestUnblindingTokenResponse>(rawResponse);
          unblindingToken = responseWrapper.unblindingToken;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> Returns: 1: on SUCCESS (unblindedIdentities should contain data) / 0: if no realtime response is possible (delayed approval is outstanding) -1: if a new unblindingToken is required (because the current has expired or has been repressed) / -2: if the access is denied for addressed scope of data </summary>
      /// <param name="unblindingToken">  </param>
      /// <param name="pseudonymsToUnblind">  </param>
      /// <param name="unblindedIdentities">  </param>
      public Int32 TryUnblind(string unblindingToken, string[] pseudonymsToUnblind, IdentityDetails[] unblindedIdentities) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "tryUnblind";
          var requestWrapper = new TryUnblindRequest {
            unblindingToken = unblindingToken,
            pseudonymsToUnblind = pseudonymsToUnblind,
            unblindedIdentities = unblindedIdentities
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<TryUnblindResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
    }
    
  }
  
}
