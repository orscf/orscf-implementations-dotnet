using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace MedicalResearch.StudyManagement.Model {

public class Institute {

  [Required]
  public Guid InstituteUid { get; set; } = Guid.NewGuid();

  [Required]
  public String InstituteTitle { get; set; }

  [Required]
  public Boolean IsArchived { get; set; }

}

/// <summary> entity, which relates to <see href="https://www.hl7.org/fhir/researchstudy.html">HL7.ResearchStudy</see> </summary>
public class ResearchStudy {

  /// <summary> *this field has a max length of 250 </summary>
  [MaxLength(250), Required]
  public String StudyIdentifier { get; set; }

  [Required]
  public String StudyTitle { get; set; }

  [Required]
  public Guid SponsoringInstituteUid { get; set; }

  [Required]
  public String StudyWorkflowName { get; set; }

  [Required]
  public String StudyWorkflowVersion { get; set; }

  /// <summary> AS DECLARED BY <see href="https://www.hl7.org/fhir/valueset-research-study-phase.html">HL7.ResearchStudyPhase</see>:
  /// n-a | early-phase-1 | phase-1 | phase-1-phase-2 | phase-2 | phase-2-phase-3 | phase-3 | phase-4 *this field is optional (use null as value) </summary>
  public String Phase { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String LKP { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> StartDate { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> TerminationDate { get; set; }

  /// <summary> A title which informs about the sematic of the SubjectIdentifer (which concrete value is used): "Randomization-Number", "Screening-Number", ... </summary>
  [Required]
  public String SubjectIdentifierTitle { get; set; }

  /// <summary> Url of the API Endpoint which provides access to the 'IdentityManagementSystem' for this study (following the ORSCF-Standard) *this field is optional (use null as value) </summary>
  public String ImsApiUrl { get; set; }

  /// <summary> Url of the API Endpoint which provides access to the 'VisitDataRepository' for this study (following the ORSCF-Standard) *this field is optional (use null as value) </summary>
  public String VdrApiUrl { get; set; }

  /// <summary> Url of the API Endpoint which provides access to the 'BillingDataRepository' for this study (following the ORSCF-Standard) *this field is optional (use null as value) </summary>
  public String BdrApiUrl { get; set; }

  /// <summary> Url of the API Endpoint which provides access to the 'WorkflowDefinitionRepository' for this study (following the ORSCF-Standard) *this field is optional (use null as value) </summary>
  public String WdrApiUrl { get; set; }

  /// <summary> AS DECLARED BY <see href="https://www.hl7.org/fhir/valueset-research-study-status.html">HL7.ResearchStudyStatus</see>:
  /// active | administratively-completed | approved | closed-to-accrual | closed-to-accrual-and-intervention | completed | disapproved | in-review | temporarily-closed-to-accrual | temporarily-closed-to-accrual-and-intervention | withdrawn </summary>
  [Required]
  public String Status { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String TerminatedReason { get; set; }

  [Required]
  public Boolean IsArchived { get; set; }

}

public class Site {

  /// <summary> *this field has a max length of 250 </summary>
  [MaxLength(250), Required]
  public String SiteIdentifier { get; set; }

  [Required]
  public Guid RepresentingInstituteUid { get; set; }

  /// <summary> *this field has a max length of 250 </summary>
  [MaxLength(250), Required]
  public String StudyIdentifier { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> EnrollmentDate { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> TerminationDate { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String TerminatedReason { get; set; }

  [Required]
  public String SiteTitle { get; set; }

  /// <summary> AS DECLARED BY HL7 </summary>
  [Required]
  public String Status { get; set; }

}

/// <summary> entity, which relates to <see href="https://www.hl7.org/fhir/researchsubject.html">HL7.ResearchSubject</see> </summary>
public class Subject {

  /// <summary> *this field has a max length of 250 </summary>
  [MaxLength(250), Required]
  public String CandidateIdentifier { get; set; }

  /// <summary> *this field has a max length of 250 </summary>
  [MaxLength(250), Required]
  public String ActualSiteIdentifier { get; set; }

  /// <summary> *this field has a max length of 250 </summary>
  [MaxLength(250), Required]
  public String StudyIdentifier { get; set; }

  /// <summary> *this field has a max length of 250 </summary>
  [MaxLength(250), Required]
  public String EnrollingSiteIdentifier { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> EnrollmentDate { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> TerminationDate { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String TerminatedReason { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String SubjectIdentifier { get; set; }

  /// <summary> AS DECLARED BY <see href="https://www.hl7.org/fhir/valueset-research-subject-status.html">HL7.ResearchSubjectStatus</see>:
  /// candidate | eligible | follow-up | ineligible | not-registered | off-study | on-study | on-study-intervention | on-study-observation | pending-on-study | potential-candidate | screening | withdrawn </summary>
  [Required]
  public String Status { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String CustomDisplayTitle { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String SiteSpecificPatientIdentifier { get; set; }

}

}
