using MedicalResearch.Workflow.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace MedicalResearch.Workflow.StoreAccess {

/// <summary> Provides CRUD access to stored ResearchStudyDefinitions (based on schema version '1.4.2') </summary>
public partial interface IResearchStudyDefinitions {

  //// <summary> Returns an info object, which specifies the possible operations (accessor specific permissions) regarding ResearchStudyDefinitions.</summary>
  //AccessSpecs GetAccessSpecs();

  /// <summary> Loads a specific ResearchStudyDefinition addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="researchStudyDefinitionIdentity"> Composite Key, which represents the primary identity of a ResearchStudyDefinition </param>
  ResearchStudyDefinition GetResearchStudyDefinitionByResearchStudyDefinitionIdentity(ResearchStudyDefinitionIdentity researchStudyDefinitionIdentity);

  /// <summary> Loads ResearchStudyDefinitions. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of ResearchStudyDefinitions which should be returned </param>
  ResearchStudyDefinition[] GetResearchStudyDefinitions(int page = 1, int pageSize = 20);

  /// <summary> Loads ResearchStudyDefinitions where values matching to the given filterExpression</summary>
    /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of ResearchStudyDefinitions which should be returned</param>
  ResearchStudyDefinition[] SearchResearchStudyDefinitions(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20);

  /// <summary> Adds a new ResearchStudyDefinition and returns its primary identifier (or null on failure). </summary>
  /// <param name="researchStudyDefinition"> ResearchStudyDefinition containing the new values </param>
  bool AddNewResearchStudyDefinition(ResearchStudyDefinition researchStudyDefinition);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ResearchStudyDefinition addressed by the primary identifier fields within the given ResearchStudyDefinition. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="researchStudyDefinition"> ResearchStudyDefinition containing the new values (the primary identifier fields within the given ResearchStudyDefinition will be used to address the target record) </param>
  bool UpdateResearchStudyDefinition(ResearchStudyDefinition researchStudyDefinition);

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ResearchStudyDefinition addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="researchStudyDefinitionIdentity"> Composite Key, which represents the primary identity of a ResearchStudyDefinition </param>
  /// <param name="researchStudyDefinition"> ResearchStudyDefinition containing the new values (the primary identifier fields within the given ResearchStudyDefinition will be ignored) </param>
  bool UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentity(ResearchStudyDefinitionIdentity researchStudyDefinitionIdentity, ResearchStudyDefinition researchStudyDefinition);

  /// <summary> Deletes a specific ResearchStudyDefinition addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="researchStudyDefinitionIdentity"> Composite Key, which represents the primary identity of a ResearchStudyDefinition </param>
  bool DeleteResearchStudyDefinitionByResearchStudyDefinitionIdentity(ResearchStudyDefinitionIdentity researchStudyDefinitionIdentity);

}

/// <summary> Composite Key, which represents the primary identity of a ResearchStudyDefinition </summary>
public class ResearchStudyDefinitionIdentity {
  /// <summary> the official invariant name of the study as given by the sponsor </summary>
  public String StudyWorkflowName;
  /// <summary> This value follows the rules of 'Semantic Versioning' (https://semver.org) and needs to be updated exactly and only on transition to DraftState.Released! If the previously DraftState was 'DraftNewFix', then the 3. number must be increased at this time! If the previously DraftState was 'DraftNewMinor', then the 2. number must be increased, and the 3. number must be set to 0 at this time! If the previously DraftState was 'DraftNewMajor', then the 1. number must be increased, and the 2.+3. number must be set to 0 at this time! </summary>
  public String StudyWorkflowVersion;
}

}
