/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.Workflow.Model;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MedicalResearch.Workflow.StoreAccess {
  
  public partial class WdrStoreConnector {
    
    public WdrStoreConnector(string url, string apiToken) {
      
      if (!url.EndsWith("/")) {
        url = url + "/";
      }
      
      _ResearchStudyDefinitionsClient = new ResearchStudyDefinitionsClient(url + "researchStudyDefinitions/", apiToken);
      
    }
    
    private ResearchStudyDefinitionsClient _ResearchStudyDefinitionsClient = null;
    /// <summary> Provides CRUD access to stored ResearchStudyDefinitions (based on schema version '1.5.0') </summary>
    public IResearchStudyDefinitions ResearchStudyDefinitions {
      get {
        return _ResearchStudyDefinitionsClient;
      }
    }
    
  }
  
  /// <summary> Provides CRUD access to stored ResearchStudyDefinitions (based on schema version '1.5.0') </summary>
  internal partial class ResearchStudyDefinitionsClient : IResearchStudyDefinitions {
    
    private string _Url;
    private string _ApiToken;
    
    public ResearchStudyDefinitionsClient(string url, string apiToken) {
      _Url = url;
      _ApiToken = apiToken;
    }
    
    private WebClient CreateWebClient() {
      var wc = new WebClient();
      wc.Headers.Set("Authorization", _ApiToken);
      wc.Headers.Set("Content-Type", "application/json");
      return wc;
    }
    
    /// <summary> Loads a specific ResearchStudyDefinition addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="researchStudyDefinitionIdentity"> Composite Key, which represents the primary identity of a ResearchStudyDefinition </param>
    public ResearchStudyDefinition GetResearchStudyDefinitionByResearchStudyDefinitionIdentity(ResearchStudyDefinitionIdentity researchStudyDefinitionIdentity) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getResearchStudyDefinitionByResearchStudyDefinitionIdentity";
        var requestWrapper = new GetResearchStudyDefinitionByResearchStudyDefinitionIdentityRequest {
          researchStudyDefinitionIdentity = researchStudyDefinitionIdentity
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<GetResearchStudyDefinitionByResearchStudyDefinitionIdentityResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Loads ResearchStudyDefinitions. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of ResearchStudyDefinitions which should be returned </param>
    public ResearchStudyDefinition[] GetResearchStudyDefinitions(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getResearchStudyDefinitions";
        var requestWrapper = new GetResearchStudyDefinitionsRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<GetResearchStudyDefinitionsResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Loads ResearchStudyDefinitions where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of ResearchStudyDefinitions which should be returned </param>
    public ResearchStudyDefinition[] SearchResearchStudyDefinitions(string filterExpression, string sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchResearchStudyDefinitions";
        var requestWrapper = new SearchResearchStudyDefinitionsRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<SearchResearchStudyDefinitionsResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Adds a new ResearchStudyDefinition and returns its primary identifier (or null on failure). </summary>
    /// <param name="researchStudyDefinition"> ResearchStudyDefinition containing the new values </param>
    public Boolean AddNewResearchStudyDefinition(ResearchStudyDefinition researchStudyDefinition) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewResearchStudyDefinition";
        var requestWrapper = new AddNewResearchStudyDefinitionRequest {
          researchStudyDefinition = researchStudyDefinition
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<AddNewResearchStudyDefinitionResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ResearchStudyDefinition addressed by the primary identifier fields within the given ResearchStudyDefinition. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="researchStudyDefinition"> ResearchStudyDefinition containing the new values (the primary identifier fields within the given ResearchStudyDefinition will be used to address the target record) </param>
    public Boolean UpdateResearchStudyDefinition(ResearchStudyDefinition researchStudyDefinition) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateResearchStudyDefinition";
        var requestWrapper = new UpdateResearchStudyDefinitionRequest {
          researchStudyDefinition = researchStudyDefinition
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<UpdateResearchStudyDefinitionResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ResearchStudyDefinition addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="researchStudyDefinitionIdentity"> Composite Key, which represents the primary identity of a ResearchStudyDefinition </param>
    /// <param name="researchStudyDefinition"> ResearchStudyDefinition containing the new values (the primary identifier fields within the given ResearchStudyDefinition will be ignored) </param>
    public Boolean UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentity(ResearchStudyDefinitionIdentity researchStudyDefinitionIdentity, ResearchStudyDefinition researchStudyDefinition) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateResearchStudyDefinitionByResearchStudyDefinitionIdentity";
        var requestWrapper = new UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentityRequest {
          researchStudyDefinitionIdentity = researchStudyDefinitionIdentity,
          researchStudyDefinition = researchStudyDefinition
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentityResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
    /// <summary> Deletes a specific ResearchStudyDefinition addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="researchStudyDefinitionIdentity"> Composite Key, which represents the primary identity of a ResearchStudyDefinition </param>
    public Boolean DeleteResearchStudyDefinitionByResearchStudyDefinitionIdentity(ResearchStudyDefinitionIdentity researchStudyDefinitionIdentity) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteResearchStudyDefinitionByResearchStudyDefinitionIdentity";
        var requestWrapper = new DeleteResearchStudyDefinitionByResearchStudyDefinitionIdentityRequest {
          researchStudyDefinitionIdentity = researchStudyDefinitionIdentity
        };
        string rawRequest = JsonConvert.SerializeObject(requestWrapper);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var responseWrapper = JsonConvert.DeserializeObject<DeleteResearchStudyDefinitionByResearchStudyDefinitionIdentityResponse>(rawResponse);
        if(responseWrapper.fault != null){
          throw new Exception(responseWrapper.fault);
        }
        return responseWrapper.@return;
      }
    }
    
  }
  
}
