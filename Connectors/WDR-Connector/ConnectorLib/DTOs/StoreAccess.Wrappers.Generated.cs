using MedicalResearch.Workflow.Model;
using MedicalResearch.Workflow.StoreAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalResearch.Workflow.StoreAccess {
  
  /// <summary>
  /// Contains arguments for calling 'GetResearchStudyDefinitionByResearchStudyDefinitionIdentity'.
  /// Method: Loads a specific ResearchStudyDefinition addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetResearchStudyDefinitionByResearchStudyDefinitionIdentityRequest {
  
    /// <summary> Required Argument for 'GetResearchStudyDefinitionByResearchStudyDefinitionIdentity' (ResearchStudyDefinitionIdentity): Composite Key, which represents the primary identity of a ResearchStudyDefinition </summary>
    [Required]
    public ResearchStudyDefinitionIdentity researchStudyDefinitionIdentity { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetResearchStudyDefinitionByResearchStudyDefinitionIdentity'.
  /// Method: Loads a specific ResearchStudyDefinition addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetResearchStudyDefinitionByResearchStudyDefinitionIdentityResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetResearchStudyDefinitionByResearchStudyDefinitionIdentity' (ResearchStudyDefinition) </summary>
    public ResearchStudyDefinition @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetResearchStudyDefinitions'.
  /// Method: Loads ResearchStudyDefinitions.
  /// </summary>
  public class GetResearchStudyDefinitionsRequest {
  
    /// <summary> Optional Argument for 'GetResearchStudyDefinitions' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'GetResearchStudyDefinitions' (Int32?): Max count of ResearchStudyDefinitions which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetResearchStudyDefinitions'.
  /// Method: Loads ResearchStudyDefinitions.
  /// </summary>
  public class GetResearchStudyDefinitionsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetResearchStudyDefinitions' (ResearchStudyDefinition[]) </summary>
    public ResearchStudyDefinition[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchResearchStudyDefinitions'.
  /// Method: Loads ResearchStudyDefinitions where values matching to the given filterExpression
  /// </summary>
  public class SearchResearchStudyDefinitionsRequest {
  
    /// <summary> Required Argument for 'SearchResearchStudyDefinitions' (String): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public String filterExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchResearchStudyDefinitions' (String): one or more property names which are used as sort order (before pagination) </summary>
    public String sortingExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchResearchStudyDefinitions' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'SearchResearchStudyDefinitions' (Int32?): Max count of ResearchStudyDefinitions which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'SearchResearchStudyDefinitions'.
  /// Method: Loads ResearchStudyDefinitions where values matching to the given filterExpression
  /// </summary>
  public class SearchResearchStudyDefinitionsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'SearchResearchStudyDefinitions' (ResearchStudyDefinition[]) </summary>
    public ResearchStudyDefinition[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewResearchStudyDefinition'.
  /// Method: Adds a new ResearchStudyDefinition and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewResearchStudyDefinitionRequest {
  
    /// <summary> Required Argument for 'AddNewResearchStudyDefinition' (ResearchStudyDefinition): ResearchStudyDefinition containing the new values </summary>
    [Required]
    public ResearchStudyDefinition researchStudyDefinition { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewResearchStudyDefinition'.
  /// Method: Adds a new ResearchStudyDefinition and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewResearchStudyDefinitionResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'AddNewResearchStudyDefinition' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateResearchStudyDefinition'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given ResearchStudyDefinition addressed by the primary identifier fields within the given ResearchStudyDefinition. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateResearchStudyDefinitionRequest {
  
    /// <summary> Required Argument for 'UpdateResearchStudyDefinition' (ResearchStudyDefinition): ResearchStudyDefinition containing the new values (the primary identifier fields within the given ResearchStudyDefinition will be used to address the target record) </summary>
    [Required]
    public ResearchStudyDefinition researchStudyDefinition { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateResearchStudyDefinition'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given ResearchStudyDefinition addressed by the primary identifier fields within the given ResearchStudyDefinition. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateResearchStudyDefinitionResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateResearchStudyDefinition' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentity'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given ResearchStudyDefinition addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentityRequest {
  
    /// <summary> Required Argument for 'UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentity' (ResearchStudyDefinitionIdentity): Composite Key, which represents the primary identity of a ResearchStudyDefinition </summary>
    [Required]
    public ResearchStudyDefinitionIdentity researchStudyDefinitionIdentity { get; set; }
  
    /// <summary> Required Argument for 'UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentity' (ResearchStudyDefinition): ResearchStudyDefinition containing the new values (the primary identifier fields within the given ResearchStudyDefinition will be ignored) </summary>
    [Required]
    public ResearchStudyDefinition researchStudyDefinition { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentity'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given ResearchStudyDefinition addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentityResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentity' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteResearchStudyDefinitionByResearchStudyDefinitionIdentity'.
  /// Method: Deletes a specific ResearchStudyDefinition addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteResearchStudyDefinitionByResearchStudyDefinitionIdentityRequest {
  
    /// <summary> Required Argument for 'DeleteResearchStudyDefinitionByResearchStudyDefinitionIdentity' (ResearchStudyDefinitionIdentity): Composite Key, which represents the primary identity of a ResearchStudyDefinition </summary>
    [Required]
    public ResearchStudyDefinitionIdentity researchStudyDefinitionIdentity { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteResearchStudyDefinitionByResearchStudyDefinitionIdentity'.
  /// Method: Deletes a specific ResearchStudyDefinition addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteResearchStudyDefinitionByResearchStudyDefinitionIdentityResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'DeleteResearchStudyDefinitionByResearchStudyDefinitionIdentity' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
}
