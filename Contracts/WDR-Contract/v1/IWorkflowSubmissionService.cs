using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.Workflow.Model;

namespace MedicalResearch.Workflow {

  /// <summary> Provides an API for accessing a 'WorkflowDefinitionRepository' (WDR) 
  /// in order to manage ORSCF 'ResearchStudyDefinitions' </summary>
  public partial interface IWorkflowSubmissionService {

    /// <summary>
    /// Imports a ORSCF 'ResearchStudyDefinition' into the Repository
    /// The 'workflowDefinitionName' and 'workflowVersion'
    /// will be taken from the definition itself
    /// </summary>
    /// <param name="workflowDefinition"></param>
    /// <param name="wasNew">
    /// returns true, if this questionare was not already exisiting before the import
    /// </param>
    void ImportWorkflowDefinition(
      ResearchStudyDefinition workflowDefinition,
      out bool wasNew
    );

    /// <summary>
    /// Deletes a ORSCF 'ResearchStudyDefinition' by its given 
    /// 'workflowDefinitionName' and 'workflowVersion'
    /// </summary>
    /// <param name="workflowDefinitionName"></param>
    /// <param name="workflowVersion"></param>
    /// <param name="wasDeleted"></param>
    void DeleteWorkflowDefinition(
      string workflowDefinitionName,
      string workflowVersion,
      out bool wasDeleted
    );

  }

}
