using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.Workflow.Model;

namespace MedicalResearch.Workflow {

  /// <summary> Provides an API for accessing a 'WorkflowDefinitionRepository' (WDR) 
  /// in order to consume ORSCF 'ResearchStudyDefinitions' </summary>
  public partial interface IWorkflowConsumeService {

    /// <summary>
    /// Lists all ORSCF 'ResearchStudyDefinitions'
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    void SearchWorkflowDefinitions(
      out ResearchStudyDefinitionMetaRecord[] result
    );

    /// <summary>
    /// Exports a ORSCF 'ResearchStudyDefinition' by its given 
    /// 'workflowDefinitionName' and 'workflowVersion'
    /// </summary>
    /// <param name="workflowDefinitionName"></param>
    /// <param name="workflowVersion"></param>
    /// <param name="wasFound"></param>
    /// <param name="result"></param>
    void ExportWorkflowDefinition(
      string workflowDefinitionName,
      string workflowVersion,
      out bool wasFound,
      out ResearchStudyDefinition result
    );

  }

}
