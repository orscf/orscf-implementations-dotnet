using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace MedicalResearch.VisitData.Persistence {

public class DataRecordingEntity {

  /// <summary> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
  [FixedAfterCreation, Required]
  public Guid TaskGuid { get; set; } = Guid.NewGuid();

  /// <summary> the guid of the visit in which this task was executed </summary>
  [Required]
  public Guid VisitGuid { get; set; }

  /// <summary> unique invariant name of ths task-procedure as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
  [Required]
  public String DataRecordingName { get; set; }

  /// <summary> title of the task execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
  [Required]
  public String TaskExecutionTitle { get; set; }

  /// <summary> the estimated date when the visit is scheduled *this field is optional </summary>
  public Nullable<DateTime> ScheduledDateTimeUtc { get; set; }

  /// <summary> the real time, when the data was recorded *this field is optional </summary>
  public Nullable<DateTime> ExecutionDateTimeUtc { get; set; }

  /// <summary> 0=Unscheduled / 1=Sheduled / 2=Executed / 3=AbortDuringExecution / 4=Skipped / 5=Removed </summary>
  [Required]
  public Int32 ExecutionState { get; set; }

  /// <summary> schema-url of the data which were stored inside of the 'RecordedData' field </summary>
  [Required]
  public String DataSchemaUrl { get; set; }

  /// <summary> RAW data, in the schema as defined at the 'DataSchemaUrl' </summary>
  [Required]
  public String RecordedData { get; set; }

  /// <summary> additional notes regarding this dedcated execution (supplied by the execution person) *this field is optional (use null as value) </summary>
  public String NotesRegardingOutcome { get; set; }

  /// <summary> optional structure (in JSON-format) containing additional metadata regarding this record, which can be used by 'StudyExecutionSystems' to extend the schema </summary>
  [Required]
  public String ExtendedMetaData { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String ExecutingPerson { get; set; }

  [Principal]
  public virtual VisitEntity Visit { get; set; }

#region Mapping

  internal static Expression<Func<DataRecording, DataRecordingEntity>> DataRecordingEntitySelector = ((DataRecording src) => new DataRecordingEntity {
    TaskGuid = src.TaskGuid,
    VisitGuid = src.VisitGuid,
    DataRecordingName = src.DataRecordingName,
    TaskExecutionTitle = src.TaskExecutionTitle,
    ScheduledDateTimeUtc = src.ScheduledDateTimeUtc,
    ExecutionDateTimeUtc = src.ExecutionDateTimeUtc,
    ExecutionState = src.ExecutionState,
    DataSchemaUrl = src.DataSchemaUrl,
    RecordedData = src.RecordedData,
    NotesRegardingOutcome = src.NotesRegardingOutcome,
    ExtendedMetaData = src.ExtendedMetaData,
    ExecutingPerson = src.ExecutingPerson,
  });

  internal static Expression<Func<DataRecordingEntity, DataRecording>> DataRecordingSelector = ((DataRecordingEntity src) => new DataRecording {
    TaskGuid = src.TaskGuid,
    VisitGuid = src.VisitGuid,
    DataRecordingName = src.DataRecordingName,
    TaskExecutionTitle = src.TaskExecutionTitle,
    ScheduledDateTimeUtc = src.ScheduledDateTimeUtc,
    ExecutionDateTimeUtc = src.ExecutionDateTimeUtc,
    ExecutionState = src.ExecutionState,
    DataSchemaUrl = src.DataSchemaUrl,
    RecordedData = src.RecordedData,
    NotesRegardingOutcome = src.NotesRegardingOutcome,
    ExtendedMetaData = src.ExtendedMetaData,
    ExecutingPerson = src.ExecutingPerson,
  });

  internal void CopyContentFrom(DataRecording source, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(source.TaskGuid, this.TaskGuid)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(TaskGuid))){
        this.TaskGuid = source.TaskGuid;
      }
    }
    this.VisitGuid = source.VisitGuid;
    this.DataRecordingName = source.DataRecordingName;
    this.TaskExecutionTitle = source.TaskExecutionTitle;
    this.ScheduledDateTimeUtc = source.ScheduledDateTimeUtc;
    this.ExecutionDateTimeUtc = source.ExecutionDateTimeUtc;
    this.ExecutionState = source.ExecutionState;
    this.DataSchemaUrl = source.DataSchemaUrl;
    this.RecordedData = source.RecordedData;
    this.NotesRegardingOutcome = source.NotesRegardingOutcome;
    this.ExtendedMetaData = source.ExtendedMetaData;
    this.ExecutingPerson = source.ExecutingPerson;
  }

  internal void CopyContentTo(DataRecording target, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(target.TaskGuid, this.TaskGuid)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(TaskGuid))){
        target.TaskGuid = this.TaskGuid;
      }
    }
    target.VisitGuid = this.VisitGuid;
    target.DataRecordingName = this.DataRecordingName;
    target.TaskExecutionTitle = this.TaskExecutionTitle;
    target.ScheduledDateTimeUtc = this.ScheduledDateTimeUtc;
    target.ExecutionDateTimeUtc = this.ExecutionDateTimeUtc;
    target.ExecutionState = this.ExecutionState;
    target.DataSchemaUrl = this.DataSchemaUrl;
    target.RecordedData = this.RecordedData;
    target.NotesRegardingOutcome = this.NotesRegardingOutcome;
    target.ExtendedMetaData = this.ExtendedMetaData;
    target.ExecutingPerson = this.ExecutingPerson;
  }

#endregion

}

public class VisitEntity {

  /// <summary> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
  [FixedAfterCreation, Required]
  public Guid VisitGuid { get; set; } = Guid.NewGuid();

  /// <summary> identity of the patient which can be a randomization or screening number (the exact semantic is defined per study) *this field has a max length of 50 </summary>
  [FixedAfterCreation, MaxLength(50), Required]
  public String ParticipantIdentifier { get; set; }

  /// <summary> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </summary>
  [Required]
  public Guid StudyExecutionIdentifier { get; set; }

  /// <summary> unique invariant name of the visit-procedure as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
  [Required]
  public String VisitProdecureName { get; set; }

  /// <summary> unique title of the visit execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
  [Required]
  public String VisitExecutionTitle { get; set; }

  /// <summary> the estimated date when the visit is scheduled for execution *this field is optional </summary>
  public Nullable<DateTime> ScheduledDateUtc { get; set; }

  /// <summary> the real date, when the visits was executed *this field is optional </summary>
  public Nullable<DateTime> ExecutionDateUtc { get; set; }

  /// <summary> 0=Unscheduled / 1=Sheduled / 2=Executed / 3=AbortDuringExecution / 4=Skipped / 5=Removed </summary>
  [Required]
  public Int32 ExecutionState { get; set; }

  /// <summary> optional structure (in JSON-format) containing additional metadata regarding this record, which can be used by 'StudyExecutionSystems' to extend the schema *this field is optional (use null as value) </summary>
  public String ExtendedMetaData { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String ExecutingPerson { get; set; }

  [Dependent]
  public virtual ObservableCollection<DataRecordingEntity> DataRecordings { get; set; } = new ObservableCollection<DataRecordingEntity>();

  [Dependent]
  public virtual ObservableCollection<DrugApplymentEntity> DrugApplyments { get; set; } = new ObservableCollection<DrugApplymentEntity>();

  [Lookup]
  public virtual StudyExecutionScopeEntity StudyExecution { get; set; }

  [Dependent]
  public virtual ObservableCollection<TreatmentEntity> Treatments { get; set; } = new ObservableCollection<TreatmentEntity>();

#region Mapping

  internal static Expression<Func<Visit, VisitEntity>> VisitEntitySelector = ((Visit src) => new VisitEntity {
    VisitGuid = src.VisitGuid,
    ParticipantIdentifier = src.ParticipantIdentifier,
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    VisitProdecureName = src.VisitProdecureName,
    VisitExecutionTitle = src.VisitExecutionTitle,
    ScheduledDateUtc = src.ScheduledDateUtc,
    ExecutionDateUtc = src.ExecutionDateUtc,
    ExecutionState = src.ExecutionState,
    ExtendedMetaData = src.ExtendedMetaData,
    ExecutingPerson = src.ExecutingPerson,
  });

  internal static Expression<Func<VisitEntity, Visit>> VisitSelector = ((VisitEntity src) => new Visit {
    VisitGuid = src.VisitGuid,
    ParticipantIdentifier = src.ParticipantIdentifier,
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    VisitProdecureName = src.VisitProdecureName,
    VisitExecutionTitle = src.VisitExecutionTitle,
    ScheduledDateUtc = src.ScheduledDateUtc,
    ExecutionDateUtc = src.ExecutionDateUtc,
    ExecutionState = src.ExecutionState,
    ExtendedMetaData = src.ExtendedMetaData,
    ExecutingPerson = src.ExecutingPerson,
  });

  internal void CopyContentFrom(Visit source, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(source.VisitGuid, this.VisitGuid)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(VisitGuid))){
        this.VisitGuid = source.VisitGuid;
      }
    }
    if(!Equals(source.ParticipantIdentifier, this.ParticipantIdentifier)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(ParticipantIdentifier))){
        this.ParticipantIdentifier = source.ParticipantIdentifier;
      }
    }
    this.StudyExecutionIdentifier = source.StudyExecutionIdentifier;
    this.VisitProdecureName = source.VisitProdecureName;
    this.VisitExecutionTitle = source.VisitExecutionTitle;
    this.ScheduledDateUtc = source.ScheduledDateUtc;
    this.ExecutionDateUtc = source.ExecutionDateUtc;
    this.ExecutionState = source.ExecutionState;
    this.ExtendedMetaData = source.ExtendedMetaData;
    this.ExecutingPerson = source.ExecutingPerson;
  }

  internal void CopyContentTo(Visit target, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(target.VisitGuid, this.VisitGuid)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(VisitGuid))){
        target.VisitGuid = this.VisitGuid;
      }
    }
    if(!Equals(target.ParticipantIdentifier, this.ParticipantIdentifier)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(ParticipantIdentifier))){
        target.ParticipantIdentifier = this.ParticipantIdentifier;
      }
    }
    target.StudyExecutionIdentifier = this.StudyExecutionIdentifier;
    target.VisitProdecureName = this.VisitProdecureName;
    target.VisitExecutionTitle = this.VisitExecutionTitle;
    target.ScheduledDateUtc = this.ScheduledDateUtc;
    target.ExecutionDateUtc = this.ExecutionDateUtc;
    target.ExecutionState = this.ExecutionState;
    target.ExtendedMetaData = this.ExtendedMetaData;
    target.ExecutingPerson = this.ExecutingPerson;
  }

#endregion

}

public class DrugApplymentEntity {

  /// <summary> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
  [FixedAfterCreation, Required]
  public Guid TaskGuid { get; set; } = Guid.NewGuid();

  /// <summary> the guid of the visit in which this task was executed </summary>
  [Required]
  public Guid VisitGuid { get; set; }

  /// <summary> unique invariant name of the study itself as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
  [Required]
  public String DrugApplymentName { get; set; }

  /// <summary> title of the task execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
  [Required]
  public String TaskExecutionTitle { get; set; }

  /// <summary> the estimated time when the drug applyment is scheduled *this field is optional </summary>
  public Nullable<DateTime> ScheduledDateTimeUtc { get; set; }

  /// <summary> the real date, when the visits was executed *this field is optional </summary>
  public Nullable<DateTime> ExecutionDateTimeUtc { get; set; }

  /// <summary> 0=Unscheduled / 1=Sheduled / 2=Executed / 3=AbortDuringExecution / 4=Skipped / 5=Removed </summary>
  [Required]
  public Int32 ExecutionState { get; set; }

  /// <summary> name of the drug </summary>
  [Required]
  public String DrugName { get; set; }

  /// <summary> dose (mg) which is inside of one unit </summary>
  [Required]
  public Decimal DrugDoseMgPerUnitMg { get; set; }

  /// <summary> amount of applied units </summary>
  [Required]
  public Decimal AppliedUnits { get; set; }

  /// <summary> additional notes regarding this dedcated execution (supplied by the execution person) *this field is optional (use null as value) </summary>
  public String NotesRegardingOutcome { get; set; }

  /// <summary> optional structure (in JSON-format) containing additional metadata regarding this record, which can be used by 'StudyExecutionSystems' to extend the schema </summary>
  [Required]
  public String ExtendedMetaData { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String ExecutingPerson { get; set; }

  [Principal]
  public virtual VisitEntity Visit { get; set; }

#region Mapping

  internal static Expression<Func<DrugApplyment, DrugApplymentEntity>> DrugApplymentEntitySelector = ((DrugApplyment src) => new DrugApplymentEntity {
    TaskGuid = src.TaskGuid,
    VisitGuid = src.VisitGuid,
    DrugApplymentName = src.DrugApplymentName,
    TaskExecutionTitle = src.TaskExecutionTitle,
    ScheduledDateTimeUtc = src.ScheduledDateTimeUtc,
    ExecutionDateTimeUtc = src.ExecutionDateTimeUtc,
    ExecutionState = src.ExecutionState,
    DrugName = src.DrugName,
    DrugDoseMgPerUnitMg = src.DrugDoseMgPerUnitMg,
    AppliedUnits = src.AppliedUnits,
    NotesRegardingOutcome = src.NotesRegardingOutcome,
    ExtendedMetaData = src.ExtendedMetaData,
    ExecutingPerson = src.ExecutingPerson,
  });

  internal static Expression<Func<DrugApplymentEntity, DrugApplyment>> DrugApplymentSelector = ((DrugApplymentEntity src) => new DrugApplyment {
    TaskGuid = src.TaskGuid,
    VisitGuid = src.VisitGuid,
    DrugApplymentName = src.DrugApplymentName,
    TaskExecutionTitle = src.TaskExecutionTitle,
    ScheduledDateTimeUtc = src.ScheduledDateTimeUtc,
    ExecutionDateTimeUtc = src.ExecutionDateTimeUtc,
    ExecutionState = src.ExecutionState,
    DrugName = src.DrugName,
    DrugDoseMgPerUnitMg = src.DrugDoseMgPerUnitMg,
    AppliedUnits = src.AppliedUnits,
    NotesRegardingOutcome = src.NotesRegardingOutcome,
    ExtendedMetaData = src.ExtendedMetaData,
    ExecutingPerson = src.ExecutingPerson,
  });

  internal void CopyContentFrom(DrugApplyment source, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(source.TaskGuid, this.TaskGuid)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(TaskGuid))){
        this.TaskGuid = source.TaskGuid;
      }
    }
    this.VisitGuid = source.VisitGuid;
    this.DrugApplymentName = source.DrugApplymentName;
    this.TaskExecutionTitle = source.TaskExecutionTitle;
    this.ScheduledDateTimeUtc = source.ScheduledDateTimeUtc;
    this.ExecutionDateTimeUtc = source.ExecutionDateTimeUtc;
    this.ExecutionState = source.ExecutionState;
    this.DrugName = source.DrugName;
    this.DrugDoseMgPerUnitMg = source.DrugDoseMgPerUnitMg;
    this.AppliedUnits = source.AppliedUnits;
    this.NotesRegardingOutcome = source.NotesRegardingOutcome;
    this.ExtendedMetaData = source.ExtendedMetaData;
    this.ExecutingPerson = source.ExecutingPerson;
  }

  internal void CopyContentTo(DrugApplyment target, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(target.TaskGuid, this.TaskGuid)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(TaskGuid))){
        target.TaskGuid = this.TaskGuid;
      }
    }
    target.VisitGuid = this.VisitGuid;
    target.DrugApplymentName = this.DrugApplymentName;
    target.TaskExecutionTitle = this.TaskExecutionTitle;
    target.ScheduledDateTimeUtc = this.ScheduledDateTimeUtc;
    target.ExecutionDateTimeUtc = this.ExecutionDateTimeUtc;
    target.ExecutionState = this.ExecutionState;
    target.DrugName = this.DrugName;
    target.DrugDoseMgPerUnitMg = this.DrugDoseMgPerUnitMg;
    target.AppliedUnits = this.AppliedUnits;
    target.NotesRegardingOutcome = this.NotesRegardingOutcome;
    target.ExtendedMetaData = this.ExtendedMetaData;
    target.ExecutingPerson = this.ExecutingPerson;
  }

#endregion

}

public class StudyEventEntity {

  /// <summary> a global unique id of a concrete study-event occurrence which is usually originated at the primary CRF or study management system ('SMS') </summary>
  [Required]
  public Guid EventGuid { get; set; } = Guid.NewGuid();

  /// <summary> identity of the patient which can be a randomization or screening number (the exact semantic is defined per study) </summary>
  [Required]
  public String ParticipantIdentifier { get; set; }

  /// <summary> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </summary>
  [Required]
  public Guid StudyExecutionIdentifier { get; set; }

  /// <summary> unique invariant name of the event as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
  [Required]
  public String StudyEventName { get; set; }

  /// <summary> optional structure (in JSON-format) containing additional metadata regarding this record, which can be used by 'StudyExecutionSystems' to extend the schema *this field is optional (use null as value) </summary>
  public String ExtendedMetaData { get; set; }

  [Required]
  public DateTime OccourrenceDateTimeUtc { get; set; }

  [Required]
  public String CauseInfo { get; set; }

  /// <summary> additional notes (supplied by the execution person) *this field is optional (use null as value) </summary>
  public String AdditionalNotes { get; set; }

  [Lookup]
  public virtual StudyExecutionScopeEntity StudyExecution { get; set; }

#region Mapping

  internal static Expression<Func<StudyEvent, StudyEventEntity>> StudyEventEntitySelector = ((StudyEvent src) => new StudyEventEntity {
    EventGuid = src.EventGuid,
    ParticipantIdentifier = src.ParticipantIdentifier,
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    StudyEventName = src.StudyEventName,
    ExtendedMetaData = src.ExtendedMetaData,
    OccourrenceDateTimeUtc = src.OccourrenceDateTimeUtc,
    CauseInfo = src.CauseInfo,
    AdditionalNotes = src.AdditionalNotes,
  });

  internal static Expression<Func<StudyEventEntity, StudyEvent>> StudyEventSelector = ((StudyEventEntity src) => new StudyEvent {
    EventGuid = src.EventGuid,
    ParticipantIdentifier = src.ParticipantIdentifier,
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    StudyEventName = src.StudyEventName,
    ExtendedMetaData = src.ExtendedMetaData,
    OccourrenceDateTimeUtc = src.OccourrenceDateTimeUtc,
    CauseInfo = src.CauseInfo,
    AdditionalNotes = src.AdditionalNotes,
  });

  internal void CopyContentFrom(StudyEvent source, Func<String,bool> onFixedValueChangingCallback = null){
    this.EventGuid = source.EventGuid;
    this.ParticipantIdentifier = source.ParticipantIdentifier;
    this.StudyExecutionIdentifier = source.StudyExecutionIdentifier;
    this.StudyEventName = source.StudyEventName;
    this.ExtendedMetaData = source.ExtendedMetaData;
    this.OccourrenceDateTimeUtc = source.OccourrenceDateTimeUtc;
    this.CauseInfo = source.CauseInfo;
    this.AdditionalNotes = source.AdditionalNotes;
  }

  internal void CopyContentTo(StudyEvent target, Func<String,bool> onFixedValueChangingCallback = null){
    target.EventGuid = this.EventGuid;
    target.ParticipantIdentifier = this.ParticipantIdentifier;
    target.StudyExecutionIdentifier = this.StudyExecutionIdentifier;
    target.StudyEventName = this.StudyEventName;
    target.ExtendedMetaData = this.ExtendedMetaData;
    target.OccourrenceDateTimeUtc = this.OccourrenceDateTimeUtc;
    target.CauseInfo = this.CauseInfo;
    target.AdditionalNotes = this.AdditionalNotes;
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

  [Referer]
  public virtual ObservableCollection<StudyEventEntity> Events { get; set; } = new ObservableCollection<StudyEventEntity>();

  [Referer]
  public virtual ObservableCollection<VisitEntity> Visits { get; set; } = new ObservableCollection<VisitEntity>();

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

public class TreatmentEntity {

  /// <summary> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
  [FixedAfterCreation, Required]
  public Guid TaskGuid { get; set; } = Guid.NewGuid();

  /// <summary> the guid of the visit in which this task was executed </summary>
  [Required]
  public Guid VisitGuid { get; set; }

  /// <summary> unique invariant name of ths task-procedure as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
  [Required]
  public String TreatmentName { get; set; }

  /// <summary> title of the task execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
  [Required]
  public String TaskExecutionTitle { get; set; }

  /// <summary> the estimated time when the treatment is scheduled *this field is optional </summary>
  public Nullable<DateTime> ScheduledDateTimeUtc { get; set; }

  /// <summary> the real time, when the treatment was executed *this field is optional </summary>
  public Nullable<DateTime> ExecutionDateTimeUtc { get; set; }

  /// <summary> 0=Unscheduled / 1=Sheduled / 2=Executed / 3=AbortDuringExecution / 4=Skipped / 5=Removed </summary>
  [Required]
  public Int32 ExecutionState { get; set; }

  /// <summary> additional notes regarding this dedcated execution (supplied by the execution person) *this field is optional (use null as value) </summary>
  public String NotesRegardingOutcome { get; set; }

  /// <summary> optional structure of additional metadata regarding this record in JSON-format, which can be used by study execution systems to extend the schema </summary>
  [Required]
  public String ExtendedMetaData { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String ExecutingPerson { get; set; }

  [Principal]
  public virtual VisitEntity Visit { get; set; }

#region Mapping

  internal static Expression<Func<Treatment, TreatmentEntity>> TreatmentEntitySelector = ((Treatment src) => new TreatmentEntity {
    TaskGuid = src.TaskGuid,
    VisitGuid = src.VisitGuid,
    TreatmentName = src.TreatmentName,
    TaskExecutionTitle = src.TaskExecutionTitle,
    ScheduledDateTimeUtc = src.ScheduledDateTimeUtc,
    ExecutionDateTimeUtc = src.ExecutionDateTimeUtc,
    ExecutionState = src.ExecutionState,
    NotesRegardingOutcome = src.NotesRegardingOutcome,
    ExtendedMetaData = src.ExtendedMetaData,
    ExecutingPerson = src.ExecutingPerson,
  });

  internal static Expression<Func<TreatmentEntity, Treatment>> TreatmentSelector = ((TreatmentEntity src) => new Treatment {
    TaskGuid = src.TaskGuid,
    VisitGuid = src.VisitGuid,
    TreatmentName = src.TreatmentName,
    TaskExecutionTitle = src.TaskExecutionTitle,
    ScheduledDateTimeUtc = src.ScheduledDateTimeUtc,
    ExecutionDateTimeUtc = src.ExecutionDateTimeUtc,
    ExecutionState = src.ExecutionState,
    NotesRegardingOutcome = src.NotesRegardingOutcome,
    ExtendedMetaData = src.ExtendedMetaData,
    ExecutingPerson = src.ExecutingPerson,
  });

  internal void CopyContentFrom(Treatment source, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(source.TaskGuid, this.TaskGuid)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(TaskGuid))){
        this.TaskGuid = source.TaskGuid;
      }
    }
    this.VisitGuid = source.VisitGuid;
    this.TreatmentName = source.TreatmentName;
    this.TaskExecutionTitle = source.TaskExecutionTitle;
    this.ScheduledDateTimeUtc = source.ScheduledDateTimeUtc;
    this.ExecutionDateTimeUtc = source.ExecutionDateTimeUtc;
    this.ExecutionState = source.ExecutionState;
    this.NotesRegardingOutcome = source.NotesRegardingOutcome;
    this.ExtendedMetaData = source.ExtendedMetaData;
    this.ExecutingPerson = source.ExecutingPerson;
  }

  internal void CopyContentTo(Treatment target, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(target.TaskGuid, this.TaskGuid)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(TaskGuid))){
        target.TaskGuid = this.TaskGuid;
      }
    }
    target.VisitGuid = this.VisitGuid;
    target.TreatmentName = this.TreatmentName;
    target.TaskExecutionTitle = this.TaskExecutionTitle;
    target.ScheduledDateTimeUtc = this.ScheduledDateTimeUtc;
    target.ExecutionDateTimeUtc = this.ExecutionDateTimeUtc;
    target.ExecutionState = this.ExecutionState;
    target.NotesRegardingOutcome = this.NotesRegardingOutcome;
    target.ExtendedMetaData = this.ExtendedMetaData;
    target.ExecutingPerson = this.ExecutingPerson;
  }

#endregion

}

}
