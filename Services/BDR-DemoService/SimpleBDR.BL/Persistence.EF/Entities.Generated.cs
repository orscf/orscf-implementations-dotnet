using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using MedicalResearch.BillingData.Model;

namespace MedicalResearch.BillingData.Persistence {

public class BillableTaskEntity {

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

  [Principal]
  public virtual BillableVisitEntity BillableVisit { get; set; }

#region Mapping

  internal static Expression<Func<BillableTask, BillableTaskEntity>> BillableTaskEntitySelector = ((BillableTask src) => new BillableTaskEntity {
    TaskGuid = src.TaskGuid,
    VisitGuid = src.VisitGuid,
    TaskName = src.TaskName,
    TaskExecutionTitle = src.TaskExecutionTitle,
  });

  internal static Expression<Func<BillableTaskEntity, BillableTask>> BillableTaskSelector = ((BillableTaskEntity src) => new BillableTask {
    TaskGuid = src.TaskGuid,
    VisitGuid = src.VisitGuid,
    TaskName = src.TaskName,
    TaskExecutionTitle = src.TaskExecutionTitle,
  });

  internal void CopyContentFrom(BillableTask source, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(source.TaskGuid, this.TaskGuid)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(TaskGuid))){
        this.TaskGuid = source.TaskGuid;
      }
    }
    if(!Equals(source.VisitGuid, this.VisitGuid)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(VisitGuid))){
        this.VisitGuid = source.VisitGuid;
      }
    }
    if(!Equals(source.TaskName, this.TaskName)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(TaskName))){
        this.TaskName = source.TaskName;
      }
    }
    if(!Equals(source.TaskExecutionTitle, this.TaskExecutionTitle)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(TaskExecutionTitle))){
        this.TaskExecutionTitle = source.TaskExecutionTitle;
      }
    }
  }

  internal void CopyContentTo(BillableTask target, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(target.TaskGuid, this.TaskGuid)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(TaskGuid))){
        target.TaskGuid = this.TaskGuid;
      }
    }
    if(!Equals(target.VisitGuid, this.VisitGuid)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(VisitGuid))){
        target.VisitGuid = this.VisitGuid;
      }
    }
    if(!Equals(target.TaskName, this.TaskName)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(TaskName))){
        target.TaskName = this.TaskName;
      }
    }
    if(!Equals(target.TaskExecutionTitle, this.TaskExecutionTitle)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(TaskExecutionTitle))){
        target.TaskExecutionTitle = this.TaskExecutionTitle;
      }
    }
  }

#endregion

}

public class BillableVisitEntity {

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
  public String VisitProcedureName { get; set; }

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

  [Dependent]
  public virtual ObservableCollection<BillableTaskEntity> BillableTasks { get; set; } = new ObservableCollection<BillableTaskEntity>();

  [Principal]
  public virtual StudyExecutionScopeEntity StudyExecution { get; set; }

  [Lookup]
  public virtual BillingDemandEntity AssignedBillingDemand { get; set; }

  [Lookup]
  public virtual InvoiceEntity AssignedInvoice { get; set; }

#region Mapping

  internal static Expression<Func<BillableVisit, BillableVisitEntity>> BillableVisitEntitySelector = ((BillableVisit src) => new BillableVisitEntity {
    VisitGuid = src.VisitGuid,
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    ParticipantIdentifier = src.ParticipantIdentifier,
    VisitProcedureName = src.VisitProcedureName,
    VisitExecutionTitle = src.VisitExecutionTitle,
    BillingDemandId = src.BillingDemandId,
    InvoiceId = src.InvoiceId,
    ExecutionEndDateUtc = src.ExecutionEndDateUtc,
    SponsorValidationDateUtc = src.SponsorValidationDateUtc,
    ExecutorValidationDateUtc = src.ExecutorValidationDateUtc,
  });

  internal static Expression<Func<BillableVisitEntity, BillableVisit>> BillableVisitSelector = ((BillableVisitEntity src) => new BillableVisit {
    VisitGuid = src.VisitGuid,
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    ParticipantIdentifier = src.ParticipantIdentifier,
    VisitProcedureName = src.VisitProcedureName,
    VisitExecutionTitle = src.VisitExecutionTitle,
    BillingDemandId = src.BillingDemandId,
    InvoiceId = src.InvoiceId,
    ExecutionEndDateUtc = src.ExecutionEndDateUtc,
    SponsorValidationDateUtc = src.SponsorValidationDateUtc,
    ExecutorValidationDateUtc = src.ExecutorValidationDateUtc,
  });

  internal void CopyContentFrom(BillableVisit source, Func<String,bool> onFixedValueChangingCallback = null){
    this.VisitGuid = source.VisitGuid;
    this.StudyExecutionIdentifier = source.StudyExecutionIdentifier;
    this.ParticipantIdentifier = source.ParticipantIdentifier;
    this.VisitProcedureName = source.VisitProcedureName;
    this.VisitExecutionTitle = source.VisitExecutionTitle;
    this.BillingDemandId = source.BillingDemandId;
    this.InvoiceId = source.InvoiceId;
    this.ExecutionEndDateUtc = source.ExecutionEndDateUtc;
    this.SponsorValidationDateUtc = source.SponsorValidationDateUtc;
    this.ExecutorValidationDateUtc = source.ExecutorValidationDateUtc;
  }

  internal void CopyContentTo(BillableVisit target, Func<String,bool> onFixedValueChangingCallback = null){
    target.VisitGuid = this.VisitGuid;
    target.StudyExecutionIdentifier = this.StudyExecutionIdentifier;
    target.ParticipantIdentifier = this.ParticipantIdentifier;
    target.VisitProcedureName = this.VisitProcedureName;
    target.VisitExecutionTitle = this.VisitExecutionTitle;
    target.BillingDemandId = this.BillingDemandId;
    target.InvoiceId = this.InvoiceId;
    target.ExecutionEndDateUtc = this.ExecutionEndDateUtc;
    target.SponsorValidationDateUtc = this.SponsorValidationDateUtc;
    target.ExecutorValidationDateUtc = this.ExecutorValidationDateUtc;
  }

#endregion

}

public class StudyExecutionScopeEntity {

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

  [Dependent]
  public virtual ObservableCollection<BillableVisitEntity> BillableVisits { get; set; } = new ObservableCollection<BillableVisitEntity>();

  [Dependent]
  public virtual ObservableCollection<BillingDemandEntity> BillingDemands { get; set; } = new ObservableCollection<BillingDemandEntity>();

  [Dependent]
  public virtual ObservableCollection<InvoiceEntity> Invoices { get; set; } = new ObservableCollection<InvoiceEntity>();

#region Mapping

  internal static Expression<Func<StudyExecutionScope, StudyExecutionScopeEntity>> StudyExecutionScopeEntitySelector = ((StudyExecutionScope src) => new StudyExecutionScopeEntity {
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    ExecutingInstituteIdentifier = src.ExecutingInstituteIdentifier,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    ExtendedMetaData = src.ExtendedMetaData,
  });

  internal static Expression<Func<StudyExecutionScopeEntity, StudyExecutionScope>> StudyExecutionScopeSelector = ((StudyExecutionScopeEntity src) => new StudyExecutionScope {
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    ExecutingInstituteIdentifier = src.ExecutingInstituteIdentifier,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    ExtendedMetaData = src.ExtendedMetaData,
  });

  internal void CopyContentFrom(StudyExecutionScope source, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(source.StudyExecutionIdentifier, this.StudyExecutionIdentifier)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(StudyExecutionIdentifier))){
        this.StudyExecutionIdentifier = source.StudyExecutionIdentifier;
      }
    }
    if(!Equals(source.ExecutingInstituteIdentifier, this.ExecutingInstituteIdentifier)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(ExecutingInstituteIdentifier))){
        this.ExecutingInstituteIdentifier = source.ExecutingInstituteIdentifier;
      }
    }
    if(!Equals(source.StudyWorkflowName, this.StudyWorkflowName)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(StudyWorkflowName))){
        this.StudyWorkflowName = source.StudyWorkflowName;
      }
    }
    if(!Equals(source.StudyWorkflowVersion, this.StudyWorkflowVersion)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(StudyWorkflowVersion))){
        this.StudyWorkflowVersion = source.StudyWorkflowVersion;
      }
    }
    this.ExtendedMetaData = source.ExtendedMetaData;
  }

  internal void CopyContentTo(StudyExecutionScope target, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(target.StudyExecutionIdentifier, this.StudyExecutionIdentifier)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(StudyExecutionIdentifier))){
        target.StudyExecutionIdentifier = this.StudyExecutionIdentifier;
      }
    }
    if(!Equals(target.ExecutingInstituteIdentifier, this.ExecutingInstituteIdentifier)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(ExecutingInstituteIdentifier))){
        target.ExecutingInstituteIdentifier = this.ExecutingInstituteIdentifier;
      }
    }
    if(!Equals(target.StudyWorkflowName, this.StudyWorkflowName)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(StudyWorkflowName))){
        target.StudyWorkflowName = this.StudyWorkflowName;
      }
    }
    if(!Equals(target.StudyWorkflowVersion, this.StudyWorkflowVersion)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(StudyWorkflowVersion))){
        target.StudyWorkflowVersion = this.StudyWorkflowVersion;
      }
    }
    target.ExtendedMetaData = this.ExtendedMetaData;
  }

#endregion

}

/// <summary> created by the sponsor </summary>
public class BillingDemandEntity {

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

  [Referer]
  public virtual ObservableCollection<BillableVisitEntity> AssignedVisits { get; set; } = new ObservableCollection<BillableVisitEntity>();

  [Principal]
  public virtual StudyExecutionScopeEntity StudyExecution { get; set; }

#region Mapping

  internal static Expression<Func<BillingDemand, BillingDemandEntity>> BillingDemandEntitySelector = ((BillingDemand src) => new BillingDemandEntity {
    Id = src.Id,
    OfficialNumber = src.OfficialNumber,
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    TransmissionDateUtc = src.TransmissionDateUtc,
    CreationDateUtc = src.CreationDateUtc,
    CreatedByPerson = src.CreatedByPerson,
  });

  internal static Expression<Func<BillingDemandEntity, BillingDemand>> BillingDemandSelector = ((BillingDemandEntity src) => new BillingDemand {
    Id = src.Id,
    OfficialNumber = src.OfficialNumber,
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    TransmissionDateUtc = src.TransmissionDateUtc,
    CreationDateUtc = src.CreationDateUtc,
    CreatedByPerson = src.CreatedByPerson,
  });

  internal void CopyContentFrom(BillingDemand source, Func<String,bool> onFixedValueChangingCallback = null){
    this.Id = source.Id;
    this.OfficialNumber = source.OfficialNumber;
    this.StudyExecutionIdentifier = source.StudyExecutionIdentifier;
    this.TransmissionDateUtc = source.TransmissionDateUtc;
    this.CreationDateUtc = source.CreationDateUtc;
    this.CreatedByPerson = source.CreatedByPerson;
  }

  internal void CopyContentTo(BillingDemand target, Func<String,bool> onFixedValueChangingCallback = null){
    target.Id = this.Id;
    target.OfficialNumber = this.OfficialNumber;
    target.StudyExecutionIdentifier = this.StudyExecutionIdentifier;
    target.TransmissionDateUtc = this.TransmissionDateUtc;
    target.CreationDateUtc = this.CreationDateUtc;
    target.CreatedByPerson = this.CreatedByPerson;
  }

#endregion

}

/// <summary> created by the executor-company </summary>
public class InvoiceEntity {

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

  [Referer]
  public virtual ObservableCollection<BillableVisitEntity> AssignedVisits { get; set; } = new ObservableCollection<BillableVisitEntity>();

  [Principal]
  public virtual StudyExecutionScopeEntity StudyExecution { get; set; }

#region Mapping

  internal static Expression<Func<Invoice, InvoiceEntity>> InvoiceEntitySelector = ((Invoice src) => new InvoiceEntity {
    Id = src.Id,
    OfficialNumber = src.OfficialNumber,
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    OffcialInvoiceDate = src.OffcialInvoiceDate,
    TransmissionDateUtc = src.TransmissionDateUtc,
    CreationDateUtc = src.CreationDateUtc,
    CreatedByPerson = src.CreatedByPerson,
    PaymentSubmittedDateUtc = src.PaymentSubmittedDateUtc,
    PaymentReceivedDateUtc = src.PaymentReceivedDateUtc,
  });

  internal static Expression<Func<InvoiceEntity, Invoice>> InvoiceSelector = ((InvoiceEntity src) => new Invoice {
    Id = src.Id,
    OfficialNumber = src.OfficialNumber,
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    OffcialInvoiceDate = src.OffcialInvoiceDate,
    TransmissionDateUtc = src.TransmissionDateUtc,
    CreationDateUtc = src.CreationDateUtc,
    CreatedByPerson = src.CreatedByPerson,
    PaymentSubmittedDateUtc = src.PaymentSubmittedDateUtc,
    PaymentReceivedDateUtc = src.PaymentReceivedDateUtc,
  });

  internal void CopyContentFrom(Invoice source, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(source.Id, this.Id)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(Id))){
        this.Id = source.Id;
      }
    }
    if(!Equals(source.OfficialNumber, this.OfficialNumber)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(OfficialNumber))){
        this.OfficialNumber = source.OfficialNumber;
      }
    }
    if(!Equals(source.StudyExecutionIdentifier, this.StudyExecutionIdentifier)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(StudyExecutionIdentifier))){
        this.StudyExecutionIdentifier = source.StudyExecutionIdentifier;
      }
    }
    if(!Equals(source.OffcialInvoiceDate, this.OffcialInvoiceDate)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(OffcialInvoiceDate))){
        this.OffcialInvoiceDate = source.OffcialInvoiceDate;
      }
    }
    this.TransmissionDateUtc = source.TransmissionDateUtc;
    this.CreationDateUtc = source.CreationDateUtc;
    this.CreatedByPerson = source.CreatedByPerson;
    this.PaymentSubmittedDateUtc = source.PaymentSubmittedDateUtc;
    this.PaymentReceivedDateUtc = source.PaymentReceivedDateUtc;
  }

  internal void CopyContentTo(Invoice target, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(target.Id, this.Id)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(Id))){
        target.Id = this.Id;
      }
    }
    if(!Equals(target.OfficialNumber, this.OfficialNumber)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(OfficialNumber))){
        target.OfficialNumber = this.OfficialNumber;
      }
    }
    if(!Equals(target.StudyExecutionIdentifier, this.StudyExecutionIdentifier)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(StudyExecutionIdentifier))){
        target.StudyExecutionIdentifier = this.StudyExecutionIdentifier;
      }
    }
    if(!Equals(target.OffcialInvoiceDate, this.OffcialInvoiceDate)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(OffcialInvoiceDate))){
        target.OffcialInvoiceDate = this.OffcialInvoiceDate;
      }
    }
    target.TransmissionDateUtc = this.TransmissionDateUtc;
    target.CreationDateUtc = this.CreationDateUtc;
    target.CreatedByPerson = this.CreatedByPerson;
    target.PaymentSubmittedDateUtc = this.PaymentSubmittedDateUtc;
    target.PaymentReceivedDateUtc = this.PaymentReceivedDateUtc;
  }

#endregion

}

}
