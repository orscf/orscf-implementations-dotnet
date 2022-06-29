using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.Workflow.Model;

namespace MedicalResearch.Workflow {

  /// <summary> Provides an API for accessing a 'WorkflowDefinitionRepository' (WDR) 
  /// in order to manage FHIR Questionaires </summary>
  public partial interface IFhirQuestionaireSubmissionService {

    /// <summary>
    /// Imports a FHIR Questionaire into the Repository
    /// The 'questionaireIdentifyingUrl' and 'questionaireVersion'
    /// will be taken from the 'fhirContent'
    /// </summary>
    /// <param name="fhirContent"></param>
    /// <param name="wasNew">
    /// returns true, if this questionare was not already exisiting before the import
    /// </param>
    void ImportFhirQuestionaire(
      string fhirContent,
      out bool wasNew
    );

    /// <summary>
    /// Deletes a FHIR Questionaire by its given 
    /// 'questionaireIdentifyingUrl' and 'questionaireVersion'
    /// </summary>
    /// <param name="questionaireIdentifyingUrl"></param>
    /// <param name="questionaireVersion"></param>
    /// <param name="wasDeleted"></param>
    void DeleteFhirQuestionaire(
      string questionaireIdentifyingUrl,
      string questionaireVersion,
      out bool wasDeleted
    );

  }

}
