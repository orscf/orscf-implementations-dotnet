using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.Workflow.Model;

namespace MedicalResearch.Workflow {

  /// <summary> Provides an API for accessing a 'WorkflowDefinitionRepository' (WDR) 
  /// in order to consume FHIR Questionaires </summary>
  public partial interface IFhirQuestionaireConsumeService {

    /// <summary>
    /// Lists all FHIR Questionaires
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    void SearchFhirQuestionaires(
      out QuestionaireMetaRecord[] result
    );

    /// <summary>
    /// Exports a FHIR Questionaire by its given 
    /// 'questionaireIdentifyingUrl' and 'questionaireVersion'
    /// </summary>
    /// <param name="questionaireIdentifyingUrl"></param>
    /// <param name="questionaireVersion"></param>
    /// <param name="wasFound"></param>
    /// <param name="fhirContent"></param>
    void ExportFhirQuestionaire(
      string questionaireIdentifyingUrl,
      string questionaireVersion,
      out bool wasFound,
      out string fhirContent
    );

  }

}
