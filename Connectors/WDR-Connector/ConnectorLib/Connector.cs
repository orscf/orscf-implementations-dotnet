/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.Workflow.FhirQuestionaireConsume;
using MedicalResearch.Workflow.FhirQuestionaireSubmission;
using MedicalResearch.Workflow.Model;
using MedicalResearch.Workflow.WdrApiInfo;
using MedicalResearch.Workflow.WorkflowConsume;
using MedicalResearch.Workflow.WorkflowSubmission;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MedicalResearch.Workflow {
  
  public partial class WdrApiConnector {
    
    public WdrApiConnector(string url, string apiToken) {
      
      if (!url.EndsWith("/")) {
        url = url + "/";
      }
      
      _FhirQuestionaireConsumeClient = new FhirQuestionaireConsumeClient(url + "fhirQuestionaireConsume/", apiToken);
      _FhirQuestionaireSubmissionClient = new FhirQuestionaireSubmissionClient(url + "fhirQuestionaireSubmission/", apiToken);
      _WdrApiInfoClient = new WdrApiInfoClient(url + "wdrApiInfo/", apiToken);
      _WorkflowConsumeClient = new WorkflowConsumeClient(url + "workflowConsume/", apiToken);
      _WorkflowSubmissionClient = new WorkflowSubmissionClient(url + "workflowSubmission/", apiToken);
      
    }
    
    private FhirQuestionaireConsumeClient _FhirQuestionaireConsumeClient = null;
    /// <summary> Provides an API for accessing a 'WorkflowDefinitionRepository' (WDR) in order to consume FHIR Questionaires </summary>
    public IFhirQuestionaireConsumeService FhirQuestionaireConsume {
      get {
        return _FhirQuestionaireConsumeClient;
      }
    }
    
    private FhirQuestionaireSubmissionClient _FhirQuestionaireSubmissionClient = null;
    /// <summary> Provides an API for accessing a 'WorkflowDefinitionRepository' (WDR) in order to manage FHIR Questionaires </summary>
    public IFhirQuestionaireSubmissionService FhirQuestionaireSubmission {
      get {
        return _FhirQuestionaireSubmissionClient;
      }
    }
    
    private WdrApiInfoClient _WdrApiInfoClient = null;
    /// <summary> Provides interoperability information for the current implementation </summary>
    public IWdrApiInfoService WdrApiInfo {
      get {
        return _WdrApiInfoClient;
      }
    }
    
    private WorkflowConsumeClient _WorkflowConsumeClient = null;
    /// <summary> Provides an API for accessing a 'WorkflowDefinitionRepository' (WDR) in order to consume ORSCF 'ResearchStudyDefinitions' </summary>
    public IWorkflowConsumeService WorkflowConsume {
      get {
        return _WorkflowConsumeClient;
      }
    }
    
    private WorkflowSubmissionClient _WorkflowSubmissionClient = null;
    /// <summary> Provides an API for accessing a 'WorkflowDefinitionRepository' (WDR) in order to manage ORSCF 'ResearchStudyDefinitions' </summary>
    public IWorkflowSubmissionService WorkflowSubmission {
      get {
        return _WorkflowSubmissionClient;
      }
    }
    
  }
  
  namespace FhirQuestionaireConsume {
    
    /// <summary> Provides an API for accessing a 'WorkflowDefinitionRepository' (WDR) in order to consume FHIR Questionaires </summary>
    internal partial class FhirQuestionaireConsumeClient : IFhirQuestionaireConsumeService {
      
      private string _Url;
      private string _ApiToken;
      
      public FhirQuestionaireConsumeClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> Lists all FHIR Questionaires </summary>
      /// <param name="result">  </param>
      public void SearchFhirQuestionaires(out QuestionaireMetaRecord[] result) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "searchFhirQuestionaires";
          var requestWrapper = new SearchFhirQuestionairesRequest {
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<SearchFhirQuestionairesResponse>(rawResponse);
          result = responseWrapper.result;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> Exports a FHIR Questionaire by its given 'questionaireIdentifyingUrl' and 'questionaireVersion' </summary>
      /// <param name="questionaireIdentifyingUrl">  </param>
      /// <param name="questionaireVersion">  </param>
      /// <param name="wasFound">  </param>
      /// <param name="fhirContent">  </param>
      public void ExportFhirQuestionaire(string questionaireIdentifyingUrl, string questionaireVersion, out bool wasFound, out string fhirContent) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "exportFhirQuestionaire";
          var requestWrapper = new ExportFhirQuestionaireRequest {
            questionaireIdentifyingUrl = questionaireIdentifyingUrl,
            questionaireVersion = questionaireVersion,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ExportFhirQuestionaireResponse>(rawResponse);
          wasFound = responseWrapper.wasFound;
          fhirContent = responseWrapper.fhirContent;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
    }
    
  }
  
  namespace FhirQuestionaireSubmission {
    
    /// <summary> Provides an API for accessing a 'WorkflowDefinitionRepository' (WDR) in order to manage FHIR Questionaires </summary>
    internal partial class FhirQuestionaireSubmissionClient : IFhirQuestionaireSubmissionService {
      
      private string _Url;
      private string _ApiToken;
      
      public FhirQuestionaireSubmissionClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> Imports a FHIR Questionaire into the Repository The 'questionaireIdentifyingUrl' and 'questionaireVersion' will be taken from the 'fhirContent' </summary>
      /// <param name="fhirContent">  </param>
      /// <param name="wasNew"> returns true, if this questionare was not already exisiting before the import </param>
      public void ImportFhirQuestionaire(string fhirContent, out bool wasNew) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "importFhirQuestionaire";
          var requestWrapper = new ImportFhirQuestionaireRequest {
            fhirContent = fhirContent,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ImportFhirQuestionaireResponse>(rawResponse);
          wasNew = responseWrapper.wasNew;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> Deletes a FHIR Questionaire by its given 'questionaireIdentifyingUrl' and 'questionaireVersion' </summary>
      /// <param name="questionaireIdentifyingUrl">  </param>
      /// <param name="questionaireVersion">  </param>
      /// <param name="wasDeleted">  </param>
      public void DeleteFhirQuestionaire(string questionaireIdentifyingUrl, string questionaireVersion, out bool wasDeleted) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "deleteFhirQuestionaire";
          var requestWrapper = new DeleteFhirQuestionaireRequest {
            questionaireIdentifyingUrl = questionaireIdentifyingUrl,
            questionaireVersion = questionaireVersion,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<DeleteFhirQuestionaireResponse>(rawResponse);
          wasDeleted = responseWrapper.wasDeleted;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
    }
    
  }
  
  namespace WdrApiInfo {
    
    /// <summary> Provides interoperability information for the current implementation </summary>
    internal partial class WdrApiInfoClient : IWdrApiInfoService {
      
      private string _Url;
      private string _ApiToken;
      
      public WdrApiInfoClient(string url, string apiToken) {
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
      
      /// <summary> returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'WorkflowConsume', 'WorkflowSubmission', 'FhirQuestionaireConsume', 'FhirQuestionaireSubmission' </summary>
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
      
      /// <summary> returns a list of available capabilities ("API:WorkflowConsume") and/or data-scopes ("Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72") which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be: 0=auth needed / 1=authenticated / -1=auth expired / -2=auth invalid/disabled </summary>
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
  
  namespace WorkflowConsume {
    
    /// <summary> Provides an API for accessing a 'WorkflowDefinitionRepository' (WDR) in order to consume ORSCF 'ResearchStudyDefinitions' </summary>
    internal partial class WorkflowConsumeClient : IWorkflowConsumeService {
      
      private string _Url;
      private string _ApiToken;
      
      public WorkflowConsumeClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> Lists all ORSCF 'ResearchStudyDefinitions' </summary>
      /// <param name="result">  </param>
      public void SearchWorkflowDefinitions(out ResearchStudyDefinitionMetaRecord[] result) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "searchWorkflowDefinitions";
          var requestWrapper = new SearchWorkflowDefinitionsRequest {
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<SearchWorkflowDefinitionsResponse>(rawResponse);
          result = responseWrapper.result;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> Exports a ORSCF 'ResearchStudyDefinition' by its given 'workflowDefinitionName' and 'workflowVersion' </summary>
      /// <param name="workflowDefinitionName">  </param>
      /// <param name="workflowVersion">  </param>
      /// <param name="wasFound">  </param>
      /// <param name="result">  </param>
      public void ExportWorkflowDefinition(string workflowDefinitionName, string workflowVersion, out bool wasFound, out ResearchStudyDefinition result) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "exportWorkflowDefinition";
          var requestWrapper = new ExportWorkflowDefinitionRequest {
            workflowDefinitionName = workflowDefinitionName,
            workflowVersion = workflowVersion,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ExportWorkflowDefinitionResponse>(rawResponse);
          wasFound = responseWrapper.wasFound;
          result = responseWrapper.result;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
    }
    
  }
  
  namespace WorkflowSubmission {
    
    /// <summary> Provides an API for accessing a 'WorkflowDefinitionRepository' (WDR) in order to manage ORSCF 'ResearchStudyDefinitions' </summary>
    internal partial class WorkflowSubmissionClient : IWorkflowSubmissionService {
      
      private string _Url;
      private string _ApiToken;
      
      public WorkflowSubmissionClient(string url, string apiToken) {
        _Url = url;
        _ApiToken = apiToken;
      }
      
      private WebClient CreateWebClient() {
        var wc = new WebClient();
        wc.Headers.Set("Authorization", _ApiToken);
        wc.Headers.Set("Content-Type", "application/json");
        return wc;
      }
      
      /// <summary> Imports a ORSCF 'ResearchStudyDefinition' into the Repository The 'workflowDefinitionName' and 'workflowVersion' will be taken from the definition itself </summary>
      /// <param name="workflowDefinition">  </param>
      /// <param name="wasNew"> returns true, if this questionare was not already exisiting before the import </param>
      public void ImportWorkflowDefinition(ResearchStudyDefinition workflowDefinition, out bool wasNew) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "importWorkflowDefinition";
          var requestWrapper = new ImportWorkflowDefinitionRequest {
            workflowDefinition = workflowDefinition,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<ImportWorkflowDefinitionResponse>(rawResponse);
          wasNew = responseWrapper.wasNew;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
      /// <summary> Deletes a ORSCF 'ResearchStudyDefinition' by its given 'workflowDefinitionName' and 'workflowVersion' </summary>
      /// <param name="workflowDefinitionName">  </param>
      /// <param name="workflowVersion">  </param>
      /// <param name="wasDeleted">  </param>
      public void DeleteWorkflowDefinition(string workflowDefinitionName, string workflowVersion, out bool wasDeleted) {
        using (var webClient = this.CreateWebClient()) {
          string url = _Url + "deleteWorkflowDefinition";
          var requestWrapper = new DeleteWorkflowDefinitionRequest {
            workflowDefinitionName = workflowDefinitionName,
            workflowVersion = workflowVersion,
          };
          string rawRequest = JsonConvert.SerializeObject(requestWrapper);
          string rawResponse = webClient.UploadString(url, rawRequest);
          var responseWrapper = JsonConvert.DeserializeObject<DeleteWorkflowDefinitionResponse>(rawResponse);
          wasDeleted = responseWrapper.wasDeleted;
          if(responseWrapper.fault != null){
            throw new Exception(responseWrapper.fault);
          }
          return;
        }
      }
      
    }
    
  }
  
}
