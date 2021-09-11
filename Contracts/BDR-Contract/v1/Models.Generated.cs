using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace MedicalResearch.BillingData.Model {

public class BillableTask {

  /// <summary> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
  [FixedAfterCreation, Required]
  public Guid TaskGuid { get; set; } = Guid.NewGuid();

  /// <summary> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
  [FixedAfterCreation, Required]
  public Guid VisitGuid { get; set; }

  /// <summary> unique invariant name of ths task-procedure as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
  [FixedAfterCreation, Required]
  public String TaskName { get; set; }

  /// <summary> title of the task execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
  [FixedAfterCreation, Required]
  public String TaskExecutionTitle { get; set; }

}

public class BillableVisit {

  /// <summary> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
  [Required]
  public Guid VisitGuid { get; set; } = Guid.NewGuid();

  /// <summary> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </summary>
  [Required]
  public Guid StudyExecutionIdentifier { get; set; }

  /// <summary> identity of the patient which can be a randomization or screening number (the exact semantic is defined per study) *this field has a max length of 50 </summary>
  [MaxLength(50), Required]
  public String ParticipantIdentifier { get; set; }

  /// <summary> unique invariant name of the visit-procedure as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
  [Required]
  public String VisitProdecureName { get; set; }

  /// <summary> title of the visit execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
  [Required]
  public String VisitExecutionTitle { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Guid> BillingDemandId { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Guid> InvoiceId { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> ExecutionEndDateUtc { get; set; }

  /// <summary> indicates, that the visit is ready to get assigned to a 'BillingDemand' (usually this state is managed by the sponsor) This can only be set after there is a valid 'ExecutionEndDateUtc' *this field is optional </summary>
  public Nullable<DateTime> SponsorValidationDateUtc { get; set; }

  /// <summary> indicates, that the visit is ready to get assigned to a 'Invoice' (usually this state is managed by the executor) This can only be set after either the 'SponsorValidationDateUtc' is set (and there is a Demand) nor the states are only managed by the executor, so that the demand-part is completely skipped. *this field is optional </summary>
  public Nullable<DateTime> ExecutorValidationDateUtc { get; set; }

}

public class StudyExecutionScope {

  /// <summary> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </summary>
  [FixedAfterCreation, Required]
  public Guid StudyExecutionIdentifier { get; set; } = Guid.NewGuid();

  /// <summary> the institute which is executing the study (this should be an invariant technical representation of the company name or a guid) </summary>
  [FixedAfterCreation, Required]
  public String ExecutingInstituteIdentifier { get; set; }

  /// <summary> the official invariant name of the study as given by the sponsor *this field has a max length of 100 </summary>
  [FixedAfterCreation, MaxLength(100), Required]
  public String StudyWorkflowName { get; set; }

  /// <summary> version of the workflow *this field has a max length of 20 </summary>
  [FixedAfterCreation, MaxLength(20), Required]
  public String StudyWorkflowVersion { get; set; }

  /// <summary> optional structure (in JSON-format) containing additional metadata regarding this record, which can be used by 'StudyExecutionSystems' to extend the schema *this field is optional (use null as value) </summary>
  public String ExtendedMetaData { get; set; }

}

/// <summary> created by the sponsor </summary>
public class BillingDemand {

  [Required]
  public Guid Id { get; set; } = Guid.NewGuid();

  [Required]
  public String OfficialNumber { get; set; }

  [Required]
  public Guid StudyExecutionIdentifier { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> TransmissionDateUtc { get; set; }

  [Required]
  public DateTime CreationDateUtc { get; set; }

  [Required]
  public String CreatedByPerson { get; set; }

}

/// <summary> created by the executor-company </summary>
public class Invoice {

  [FixedAfterCreation, Required]
  public Guid Id { get; set; } = Guid.NewGuid();

  /// <summary> the invoice number </summary>
  [FixedAfterCreation, Required]
  public String OfficialNumber { get; set; }

  [FixedAfterCreation, Required]
  public Guid StudyExecutionIdentifier { get; set; }

  [FixedAfterCreation, Required]
  public DateTime OffcialInvoiceDate { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> TransmissionDateUtc { get; set; }

  [Required]
  public DateTime CreationDateUtc { get; set; }

  [Required]
  public String CreatedByPerson { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> PaymentSubmittedDateUtc { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> PaymentReceivedDateUtc { get; set; }

}

}
