using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using H7 = Hl7.Fhir.Model;

namespace MedicalResearch.Workflow.Model {

  public abstract class QuestionaireMetaRecord {

    [Required]
    public string QuestionaireUrl { get; set; } = "";

    [Required]
    public string QuestionaireVersion { get; set; } = "";

  }

  public abstract class ResearchStudyDefinitionMetaRecord {

    /// <summary> the official invariant name of the study as given by the sponsor *this field has a max length of 100 </summary>
    [MaxLength(100), Required]
    public String StudyWorkflowName { get; set; }

    /// <summary> This value follows the rules of 'Semantic Versioning' (https://semver.org) and needs to be updated exactly and only on transition to DraftState.Released! If the previously DraftState was 'DraftNewFix', then the 3. number must be increased at this time! If the previously DraftState was 'DraftNewMinor', then the 2. number must be increased, and the 3. number must be set to 0 at this time! If the previously DraftState was 'DraftNewMajor', then the 1. number must be increased, and the 2.+3. number must be set to 0 at this time! *this field has a max length of 20 </summary>
    [MaxLength(20), Required]
    public String StudyWorkflowVersion { get; set; }

    [Required]
    public String OfficialLabel { get; set; }

  }

}
