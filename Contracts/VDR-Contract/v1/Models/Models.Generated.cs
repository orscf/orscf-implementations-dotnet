using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace MedicalResearch.VisitData.Model {

public class DataRecording {

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

}

public partial class Visit {

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

}

public class DrugApplyment {

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

}

public class StudyEvent {

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

public class Treatment {

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

}

}
