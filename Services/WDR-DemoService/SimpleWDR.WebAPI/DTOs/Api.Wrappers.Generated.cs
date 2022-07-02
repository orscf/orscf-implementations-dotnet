/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.Workflow.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalResearch.Workflow {
  
  /// <summary>
  /// Contains arguments for calling 'SearchFhirQuestionaires'.
  /// Method: Lists all FHIR Questionaires
  /// </summary>
  public class SearchFhirQuestionairesRequest {
    
  }
  
  /// <summary>
  /// Contains results from calling 'SearchFhirQuestionaires'.
  /// Method: Lists all FHIR Questionaires
  /// </summary>
  public class SearchFhirQuestionairesResponse {
    
    /// <summary> Out-Argument of 'SearchFhirQuestionaires' (QuestionaireMetaRecord[]) </summary>
    [Required]
    public QuestionaireMetaRecord[] result { get; set; }
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'ExportFhirQuestionaire'.
  /// Method: Exports a FHIR Questionaire by its given
  /// 'questionaireIdentifyingUrl' and 'questionaireVersion'
  /// </summary>
  public class ExportFhirQuestionaireRequest {
    
    /// <summary> Required Argument for 'ExportFhirQuestionaire' (string) </summary>
    [Required]
    public string questionaireIdentifyingUrl { get; set; }
    
    /// <summary> Required Argument for 'ExportFhirQuestionaire' (string) </summary>
    [Required]
    public string questionaireVersion { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'ExportFhirQuestionaire'.
  /// Method: Exports a FHIR Questionaire by its given
  /// 'questionaireIdentifyingUrl' and 'questionaireVersion'
  /// </summary>
  public class ExportFhirQuestionaireResponse {
    
    /// <summary> Out-Argument of 'ExportFhirQuestionaire' (bool) </summary>
    [Required]
    public bool wasFound { get; set; }
    
    /// <summary> Out-Argument of 'ExportFhirQuestionaire' (string) </summary>
    [Required]
    public string fhirContent { get; set; }
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'ImportFhirQuestionaire'.
  /// Method: Imports a FHIR Questionaire into the Repository
  /// The 'questionaireIdentifyingUrl' and 'questionaireVersion'
  /// will be taken from the 'fhirContent'
  /// </summary>
  public class ImportFhirQuestionaireRequest {
    
    /// <summary> Required Argument for 'ImportFhirQuestionaire' (string) </summary>
    [Required]
    public string fhirContent { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'ImportFhirQuestionaire'.
  /// Method: Imports a FHIR Questionaire into the Repository
  /// The 'questionaireIdentifyingUrl' and 'questionaireVersion'
  /// will be taken from the 'fhirContent'
  /// </summary>
  public class ImportFhirQuestionaireResponse {
    
    /// <summary> Out-Argument of 'ImportFhirQuestionaire' (bool): returns true, if this questionare was not already exisiting before the import </summary>
    [Required]
    public bool wasNew { get; set; }
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteFhirQuestionaire'.
  /// Method: Deletes a FHIR Questionaire by its given
  /// 'questionaireIdentifyingUrl' and 'questionaireVersion'
  /// </summary>
  public class DeleteFhirQuestionaireRequest {
    
    /// <summary> Required Argument for 'DeleteFhirQuestionaire' (string) </summary>
    [Required]
    public string questionaireIdentifyingUrl { get; set; }
    
    /// <summary> Required Argument for 'DeleteFhirQuestionaire' (string) </summary>
    [Required]
    public string questionaireVersion { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteFhirQuestionaire'.
  /// Method: Deletes a FHIR Questionaire by its given
  /// 'questionaireIdentifyingUrl' and 'questionaireVersion'
  /// </summary>
  public class DeleteFhirQuestionaireResponse {
    
    /// <summary> Out-Argument of 'DeleteFhirQuestionaire' (bool) </summary>
    [Required]
    public bool wasDeleted { get; set; }
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
  }
  
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
    public string @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetCapabilities'.
  /// Method: returns a list of API-features (there are several 'services' for different use cases, described by ORSCF)
  /// supported by this implementation. The following values are possible:
  /// 'WorkflowConsume', 'WorkflowSubmission', 'FhirQuestionaireConsume', 'FhirQuestionaireSubmission'
  /// </summary>
  public class GetCapabilitiesRequest {
    
  }
  
  /// <summary>
  /// Contains results from calling 'GetCapabilities'.
  /// Method: returns a list of API-features (there are several 'services' for different use cases, described by ORSCF)
  /// supported by this implementation. The following values are possible:
  /// 'WorkflowConsume', 'WorkflowSubmission', 'FhirQuestionaireConsume', 'FhirQuestionaireSubmission'
  /// </summary>
  public class GetCapabilitiesResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'GetCapabilities' (String[]) </summary>
    public string[] @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetPermittedAuthScopes'.
  /// Method: returns a list of available capabilities ("API:WorkflowConsume") and/or
  /// data-scopes ("Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72")
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
  /// Method: returns a list of available capabilities ("API:WorkflowConsume") and/or
  /// data-scopes ("Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72")
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
    public string[] @return { get; set; }
    
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
    public string @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchWorkflowDefinitions'.
  /// Method: Lists all ORSCF 'ResearchStudyDefinitions'
  /// </summary>
  public class SearchWorkflowDefinitionsRequest {
    
  }
  
  /// <summary>
  /// Contains results from calling 'SearchWorkflowDefinitions'.
  /// Method: Lists all ORSCF 'ResearchStudyDefinitions'
  /// </summary>
  public class SearchWorkflowDefinitionsResponse {
    
    /// <summary> Out-Argument of 'SearchWorkflowDefinitions' (ResearchStudyDefinitionMetaRecord[]) </summary>
    [Required]
    public ResearchStudyDefinitionMetaRecord[] result { get; set; }
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'ExportWorkflowDefinition'.
  /// Method: Exports a ORSCF 'ResearchStudyDefinition' by its given
  /// 'workflowDefinitionName' and 'workflowVersion'
  /// </summary>
  public class ExportWorkflowDefinitionRequest {
    
    /// <summary> Required Argument for 'ExportWorkflowDefinition' (string) </summary>
    [Required]
    public string workflowDefinitionName { get; set; }
    
    /// <summary> Required Argument for 'ExportWorkflowDefinition' (string) </summary>
    [Required]
    public string workflowVersion { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'ExportWorkflowDefinition'.
  /// Method: Exports a ORSCF 'ResearchStudyDefinition' by its given
  /// 'workflowDefinitionName' and 'workflowVersion'
  /// </summary>
  public class ExportWorkflowDefinitionResponse {
    
    /// <summary> Out-Argument of 'ExportWorkflowDefinition' (bool) </summary>
    [Required]
    public bool wasFound { get; set; }
    
    /// <summary> Out-Argument of 'ExportWorkflowDefinition' (ResearchStudyDefinition) </summary>
    [Required]
    public ResearchStudyDefinition result { get; set; }
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'ImportWorkflowDefinition'.
  /// Method: Imports a ORSCF 'ResearchStudyDefinition' into the Repository
  /// The 'workflowDefinitionName' and 'workflowVersion'
  /// will be taken from the definition itself
  /// </summary>
  public class ImportWorkflowDefinitionRequest {
    
    /// <summary> Required Argument for 'ImportWorkflowDefinition' (ResearchStudyDefinition) </summary>
    [Required]
    public ResearchStudyDefinition workflowDefinition { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'ImportWorkflowDefinition'.
  /// Method: Imports a ORSCF 'ResearchStudyDefinition' into the Repository
  /// The 'workflowDefinitionName' and 'workflowVersion'
  /// will be taken from the definition itself
  /// </summary>
  public class ImportWorkflowDefinitionResponse {
    
    /// <summary> Out-Argument of 'ImportWorkflowDefinition' (bool): returns true, if this questionare was not already exisiting before the import </summary>
    [Required]
    public bool wasNew { get; set; }
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteWorkflowDefinition'.
  /// Method: Deletes a ORSCF 'ResearchStudyDefinition' by its given
  /// 'workflowDefinitionName' and 'workflowVersion'
  /// </summary>
  public class DeleteWorkflowDefinitionRequest {
    
    /// <summary> Required Argument for 'DeleteWorkflowDefinition' (string) </summary>
    [Required]
    public string workflowDefinitionName { get; set; }
    
    /// <summary> Required Argument for 'DeleteWorkflowDefinition' (string) </summary>
    [Required]
    public string workflowVersion { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteWorkflowDefinition'.
  /// Method: Deletes a ORSCF 'ResearchStudyDefinition' by its given
  /// 'workflowDefinitionName' and 'workflowVersion'
  /// </summary>
  public class DeleteWorkflowDefinitionResponse {
    
    /// <summary> Out-Argument of 'DeleteWorkflowDefinition' (bool) </summary>
    [Required]
    public bool wasDeleted { get; set; }
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
  }
  
}
