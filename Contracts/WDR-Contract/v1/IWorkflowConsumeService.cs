using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.Workflow.Model;

namespace MedicalResearch.Workflow {

  /// <summary> Provides an workflow-level API for interating with a  'WorkflowDefinitionRepository' (WDR) </summary>
  public partial interface IWorkflowConsumeService {


    //Name, version, owner    ListWorkflowDefintions(
    //  string workflowDefinitionName,
    //  string workflowVersion
    //);

    //non-draft

    ResearchStudyDefinition GetWorkflowDefintion(
      string workflowDefinitionName,
      string workflowVersion
    );









  }

}
