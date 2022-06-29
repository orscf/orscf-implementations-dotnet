/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.BillingData.BdrApiInfo;
using MedicalResearch.BillingData.ExecutorBilling;
using MedicalResearch.BillingData.Model;
using MedicalResearch.BillingData.SponsorBilling;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MedicalResearch.BillingData {
  
  public partial class BdrStoreConnector {
    
    public BdrStoreConnector(string url, string apiToken) {
      
      if (!url.EndsWith("/")) {
        url = url + "/";
      }
      
      _BdrApiInfoClient = new BdrApiInfoClient(url + "bdrApiInfo/", apiToken);
      _ExecutorBillingClient = new ExecutorBillingClient(url + "executorBilling/", apiToken);
      _SponsorBillingClient = new SponsorBillingClient(url + "sponsorBilling/", apiToken);
      
    }
    
    private BdrApiInfoClient _BdrApiInfoClient = null;
    /// <summary> Provides interoperability information for the current implementation </summary>
    public IBdrApiInfoService BdrApiInfo {
      get {
        return _BdrApiInfoClient;
      }
    }
    
    private ExecutorBillingClient _ExecutorBillingClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'BillingDataRepository' (BDR) </summary>
    public IExecutorBillingService ExecutorBilling {
      get {
        return _ExecutorBillingClient;
      }
    }
    
    private SponsorBillingClient _SponsorBillingClient = null;
    /// <summary> Provides an workflow-level API for interating with a 'BillingDataRepository' (BDR) </summary>
    public ISponsorBillingService SponsorBilling {
      get {
        return _SponsorBillingClient;
      }
    }
    
  }
  
  namespace BdrApiInfo {
    
    /// <summary> Provides interoperability information for the current implementation </summary>
    internal partial class BdrApiInfoClient : IBdrApiInfoService {
      
      private string _Url;
      private string _ApiToken;
      
      public BdrApiInfoClient(string url, string apiToken) {
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
      
      /// <summary> returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'ExecutorBilling', 'SponsorBilling' </summary>
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
      
      /// <summary> returns a list of available capabilities ("API:ExecutorBilling") and/or data-scopes ("Site:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72") which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be: 0=auth needed / 1=authenticated / -1=auth expired / -2=auth invalid/disabled </summary>
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
  
  namespace ExecutorBilling {
    
    /// <summary> Provides an workflow-level API for interating with a 'BillingDataRepository' (BDR) </summary>
    internal partial class ExecutorBillingClient : IExecutorBillingService {
      
      private string _Url;
      private string _ApiToken;
      
      public ExecutorBillingClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
    }
    
  }
  
  namespace SponsorBilling {
    
    /// <summary> Provides an workflow-level API for interating with a 'BillingDataRepository' (BDR) </summary>
    internal partial class SponsorBillingClient : ISponsorBillingService {
      
      private string _Url;
      private string _ApiToken;
      
      public SponsorBillingClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
    }
    
  }
  
}
