using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace MedicalResearch.IdentityManagement.Model {

public class AdditionalSubjectParticipationIdentifier {

  /// <summary> *this field has a max length of 50 </summary>
  [FixedAfterCreation, MaxLength(50), Required]
  public String ParticipantIdentifier { get; set; }

  /// <summary> *this field has a max length of 30 </summary>
  [FixedAfterCreation, MaxLength(30), Required]
  public String IdentifierName { get; set; }

  [Required]
  public String IdentifierValue { get; set; }

}

public class SubjectParticipation {

  /// <summary> identity of the patient which can be a randomization or screening number (the exact semantic is defined per study) *this field has a max length of 50 </summary>
  [MaxLength(50), Required]
  public String ParticipantIdentifier { get; set; }

  /// <summary> *this field has a max length of 100 </summary>
  [MaxLength(100), Required]
  public String StudyWorkflowName { get; set; }

  /// <summary> *this field has a max length of 20 </summary>
  [MaxLength(20), Required]
  public String StudyWorkflowVersion { get; set; }

  [Required]
  public DateTime CreationDateUtc { get; set; }

  [Required]
  public Guid CreatedForStudyExecutionIdentifier { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Guid> SubjectIdentityRecordId { get; set; }

}

public class StudyExecutionScope {

  /// <summary> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </summary>
  [Required]
  public Guid StudyExecutionIdentifier { get; set; } = Guid.NewGuid();

  /// <summary> the institute which is executing the study (this should be an invariant technical representation of the company name or a guid) </summary>
  [Required]
  public String ExecutingInstituteIdentifier { get; set; }

  /// <summary> *this field has a max length of 100 </summary>
  [MaxLength(100), Required]
  public String StudyWorkflowName { get; set; }

  /// <summary> *this field has a max length of 20 </summary>
  [MaxLength(20), Required]
  public String StudyWorkflowVersion { get; set; }

}

public class StudyScope {

  /// <summary> the official invariant name of the study as given by the sponsor *this field has a max length of 100 </summary>
  [FixedAfterCreation, MaxLength(100), Required]
  public String StudyWorkflowName { get; set; }

  /// <summary> version of the workflow *this field has a max length of 20 </summary>
  [FixedAfterCreation, MaxLength(20), Required]
  public String StudyWorkflowVersion { get; set; }

  /// <summary> for example "Screening-Number" or "Randomization-Number" </summary>
  [Required]
  public String ParticipantIdentifierSemantic { get; set; }

}

public class SubjectAddress {

  [Required]
  public Guid InternalRecordId { get; set; } = Guid.NewGuid();

  [Required]
  public String Street { get; set; }

  [Required]
  public String HouseNumber { get; set; }

  [Required]
  public String PostCode { get; set; }

  [Required]
  public String City { get; set; }

  [Required]
  public String State { get; set; }

  [Required]
  public String Country { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String PhoneNumber { get; set; }

}

public class SubjectIdentity {

  [Required]
  public Guid RecordId { get; set; } = Guid.NewGuid();

  /// <summary> *this field is optional (use null as value) </summary>
  public String FirstName { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String LastName { get; set; }

  /// <summary> 0=Male / 1=Female / 2=Other *this field is optional </summary>
  public Nullable<Int32> Gender { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> DateOfBirth { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> DateOfDeath { get; set; }

  /// <summary> can be used to specify the full salutation including all academic grades by a string containing the placeholders: "{G}"=Gender {F}="FirstName" {L}="LastName". If not specified, a generic fallback can be used *this field is optional (use null as value) </summary>
  public String FullNamePattern { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String Language { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String Notes { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String Email { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String MobileNumber { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Guid> ResidentAddressId { get; set; }

}

}
