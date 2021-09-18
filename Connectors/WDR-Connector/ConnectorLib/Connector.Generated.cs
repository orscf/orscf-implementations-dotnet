﻿using MedicalResearch.Workflow.Model;
using MedicalResearch.Workflow.StoreAccess;
using MedicalResearch.Workflow.WebAPI.DTOs;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MedicalResearch.Workflow.WebAPI {
  
  public partial class WdrConnector {
    
    public WdrConnector(string url, string apiToken) {
      
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
        var args = new GetResearchStudyDefinitionByResearchStudyDefinitionIdentityRequest {
          researchStudyDefinitionIdentity = researchStudyDefinitionIdentity
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetResearchStudyDefinitionByResearchStudyDefinitionIdentityResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads ResearchStudyDefinitions. </summary>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of ResearchStudyDefinitions which should be returned </param>
    public ResearchStudyDefinition[] GetResearchStudyDefinitions(Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "getResearchStudyDefinitions";
        var args = new GetResearchStudyDefinitionsRequest {
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<GetResearchStudyDefinitionsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Loads ResearchStudyDefinitions where values matching to the given filterExpression </summary>
    /// <param name="filterExpression"> a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </param>
    /// <param name="sortingExpression"> one or more property names which are used as sort order (before pagination) </param>
    /// <param name="page"> Number of the page, which should be returned </param>
    /// <param name="pageSize"> Max count of ResearchStudyDefinitions which should be returned </param>
    public ResearchStudyDefinition[] SearchResearchStudyDefinitions(String filterExpression, String sortingExpression = null, Int32 page = 1, Int32 pageSize = 20) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "searchResearchStudyDefinitions";
        var args = new SearchResearchStudyDefinitionsRequest {
          filterExpression = filterExpression,
          sortingExpression = sortingExpression,
          page = page,
          pageSize = pageSize
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<SearchResearchStudyDefinitionsResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Adds a new ResearchStudyDefinition and returns its primary identifier (or null on failure). </summary>
    /// <param name="researchStudyDefinition"> ResearchStudyDefinition containing the new values </param>
    public Boolean AddNewResearchStudyDefinition(ResearchStudyDefinition researchStudyDefinition) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "addNewResearchStudyDefinition";
        var args = new AddNewResearchStudyDefinitionRequest {
          researchStudyDefinition = researchStudyDefinition
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<AddNewResearchStudyDefinitionResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ResearchStudyDefinition addressed by the primary identifier fields within the given ResearchStudyDefinition. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="researchStudyDefinition"> ResearchStudyDefinition containing the new values (the primary identifier fields within the given ResearchStudyDefinition will be used to address the target record) </param>
    public Boolean UpdateResearchStudyDefinition(ResearchStudyDefinition researchStudyDefinition) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateResearchStudyDefinition";
        var args = new UpdateResearchStudyDefinitionRequest {
          researchStudyDefinition = researchStudyDefinition
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateResearchStudyDefinitionResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ResearchStudyDefinition addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="researchStudyDefinitionIdentity"> Composite Key, which represents the primary identity of a ResearchStudyDefinition </param>
    /// <param name="researchStudyDefinition"> ResearchStudyDefinition containing the new values (the primary identifier fields within the given ResearchStudyDefinition will be ignored) </param>
    public Boolean UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentity(ResearchStudyDefinitionIdentity researchStudyDefinitionIdentity, ResearchStudyDefinition researchStudyDefinition) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "updateResearchStudyDefinitionByResearchStudyDefinitionIdentity";
        var args = new UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentityRequest {
          researchStudyDefinitionIdentity = researchStudyDefinitionIdentity,
          researchStudyDefinition = researchStudyDefinition
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentityResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
    /// <summary> Deletes a specific ResearchStudyDefinition addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="researchStudyDefinitionIdentity"> Composite Key, which represents the primary identity of a ResearchStudyDefinition </param>
    public Boolean DeleteResearchStudyDefinitionByResearchStudyDefinitionIdentity(ResearchStudyDefinitionIdentity researchStudyDefinitionIdentity) {
      using (var webClient = this.CreateWebClient()) {
        string url = _Url + "deleteResearchStudyDefinitionByResearchStudyDefinitionIdentity";
        var args = new DeleteResearchStudyDefinitionByResearchStudyDefinitionIdentityRequest {
          researchStudyDefinitionIdentity = researchStudyDefinitionIdentity
        };
        string rawRequest = JsonConvert.SerializeObject(args);
        string rawResponse = webClient.UploadString(url, rawRequest);
        var result = JsonConvert.DeserializeObject<DeleteResearchStudyDefinitionByResearchStudyDefinitionIdentityResponse>(rawResponse);
        if(result.fault != null){
          throw new Exception(result.fault);
        }
        return result.@return;
      }
    }
    
  }
  
}