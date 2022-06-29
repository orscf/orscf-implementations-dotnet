/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.IdentityManagement.IdentityUnblinding;
using MedicalResearch.IdentityManagement.ImsApiInfo;
using MedicalResearch.IdentityManagement.Model;
using MedicalResearch.IdentityManagement.Pseudonymization;
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
      
      _IdentityUnblindingClient = new IdentityUnblindingClient(url + "identityUnblinding/", apiToken);
      _ImsApiInfoClient = new ImsApiInfoClient(url + "imsApiInfo/", apiToken);
      _PseudonymizationClient = new PseudonymizationClient(url + "pseudonymization/", apiToken);
      
    }
    
    private IdentityUnblindingClient _IdentityUnblindingClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS) </summary>
    public IIdentityUnblindingService IdentityUnblinding {
      get {
        return _IdentityUnblindingClient;
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
    
  }
  
  namespace IdentityUnblinding {
    
    /// <summary> Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS) </summary>
    internal partial class IdentityUnblindingClient : IIdentityUnblindingService {
      
      private string _Url;
      private string _ApiToken;
      
      public IdentityUnblindingClient(string url, string apiToken) {
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
          var requestWrapper = new RequestUnblindingTokenRequest {
            researchStudyName = researchStudyName,
            subjectId = subjectId,
            reason = reason,
            requestingPerson = requestingPerson
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<RequestUnblindingTokenResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> 0: not activated yet, 1=activated (can be used for 'UnblindSubject'), 2=expired/already used </summary>
      /// <param name="unblindingToken">  </param>
      public Int32 GetUnblindingTokenState(string unblindingToken) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getUnblindingTokenState";
          var requestWrapper = new GetUnblindingTokenStateRequest {
            unblindingToken = unblindingToken
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<GetUnblindingTokenStateResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
        }
      }
      
      /// <summary> (only works with an activated unblindingOtp ) </summary>
      /// <param name="researchStudyName">  </param>
      /// <param name="subjectId">  </param>
      /// <param name="unblindingToken">  </param>
      public IdentityDetails UnblindSubject(string researchStudyName, string subjectId, string unblindingToken) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "unblindSubject";
          var requestWrapper = new UnblindSubjectRequest {
            researchStudyName = researchStudyName,
            subjectId = subjectId,
            unblindingToken = unblindingToken
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<UnblindSubjectResponse>(rawResponse);
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return responseWrapper.@return;
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
      
      /// <summary> returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'Pseudonymization', 'IdentityUnblinding', </summary>
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
      
      /// <summary> GetExtendedFieldDescriptors </summary>
      /// <param name="languagePref"> Preferred language for the 'DisplayLabel' and 'InputDescription' fields of the returned descriptors. </param>
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
      
      /// <summary> GetOrCreatePseudonym </summary>
      /// <param name="researchStudyUid"> A UUID </param>
      /// <param name="givenName"> the Firstname a the paticipant (named as in the HL7 standard) </param>
      /// <param name="familyName">  </param>
      /// <param name="birthDate"> date in format 'yyyy-MM-dd' (must NOT be a partial date for this usecase!) </param>
      /// <param name="extendedFields">  </param>
      /// <param name="siteUid"> A UUID </param>
      /// <param name="pseudonym">  </param>
      /// <param name="wasCreatedNewly">  </param>
      public Boolean GetOrCreatePseudonym(Guid researchStudyUid, string givenName, string familyName, string birthDate, Dictionary<String,String> extendedFields, Guid siteUid, out string pseudonym, out bool wasCreatedNewly) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getOrCreatePseudonym";
          var requestWrapper = new GetOrCreatePseudonymRequest {
            researchStudyUid = researchStudyUid,
            givenName = givenName,
            familyName = familyName,
            birthDate = birthDate,
            extendedFields = extendedFields,
            siteUid = siteUid,
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
      /// <param name="researchStudyUid"> A UUID </param>
      /// <param name="givenName">  </param>
      /// <param name="familyName">  </param>
      /// <param name="birthDate"> date in format 'yyyy-MM-dd' (must NOT be a partial date for this usecase!) </param>
      /// <param name="extendedFields">  </param>
      /// <param name="pseudonym">  </param>
      public Boolean GetExisitingPseudonym(Guid researchStudyUid, string givenName, string familyName, string birthDate, Dictionary<String,String> extendedFields, out string pseudonym) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "getExisitingPseudonym";
          var requestWrapper = new GetExisitingPseudonymRequest {
            researchStudyUid = researchStudyUid,
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
  
}
