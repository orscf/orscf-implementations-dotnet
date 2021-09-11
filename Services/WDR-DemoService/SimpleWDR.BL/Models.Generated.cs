using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace MedicalResearch.Workflow {

public class Arm {

  /// <summary> *this field has a max length of 50 </summary>
  [MaxLength(50), Required]
  public String StudyArmName { get; set; }

  /// <summary> *this field has a max length of 100 </summary>
  [MaxLength(100), Required]
  public String StudyWorkflowName { get; set; }

  /// <summary> *this field has a max length of 20 </summary>
  [MaxLength(20), Required]
  public String StudyWorkflowVersion { get; set; }

  /// <summary> the ProcedureSchedule which is representing the primary-/entry-workflow (estimated visits) for participants of this arm *this field is optional </summary>
  public Nullable<Guid> RootProcedureScheduleId { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Decimal> BillablePriceOnFailedInclusion { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Decimal> BillablePriceOnSuccessfullInclusion { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Decimal> BillablePriceOnAbortedParticipation { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Decimal> BillablePriceOnCompletedParticipation { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String ArmSpecificDocumentationUrl { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String InclusionCriteria { get; set; }

  /// <summary> defines, that the arm is part of a SubStudy which is addressed by a UniqueName or a path expressen *this field is optional (use null as value) </summary>
  public String Substudy { get; set; }

}

public class ResearchStudy {

  /// <summary> the official invariant name of the study as given by the sponsor *this field has a max length of 100 </summary>
  [MaxLength(100), Required]
  public String StudyWorkflowName { get; set; }

  /// <summary> This value follows the rules of 'Semantic Versioning' (https://semver.org) and needs to be updated exactly and only on transition to DraftState.Released! If the previously DraftState was 'DraftNewFix', then the 3. number must be increased at this time! If the previously DraftState was 'DraftNewMinor', then the 2. number must be increased, and the 3. number must be set to 0 at this time! If the previously DraftState was 'DraftNewMajor', then the 1. number must be increased, and the 2.+3. number must be set to 0 at this time! *this field has a max length of 20 </summary>
  [MaxLength(20), Required]
  public String StudyWorkflowVersion { get; set; }

  [Required]
  public String OfficialLabel { get; set; }

  [Required]
  public String DefinitionOwner { get; set; }

  [Required]
  public String DocumentationUrl { get; set; }

  [Required]
  public String LogoImage { get; set; }

  [Required]
  public String Description { get; set; }

  /// <summary> IT MUST NOT be updated on every change during Draft! Format: the Author, which is starting the new Draft (Alphanumeric, in PascalCase without blanks or other Symbols) + the current UTC-Time when setting the value (in ISO8601 format) separated by a Pipe "|" Sample: "MaxMustermann|2020-06-15T13:45:30.0000000Z". </summary>
  [Required]
  public String VersionIdentity { get; set; }

  [Required]
  public DateTime LastChangeUtc { get; set; }

  /// <summary> 0=Released / 1=DraftNewFix / 2=DraftNewMinor / 3=DraftNewMajor </summary>
  [Required]
  public Int32 DraftState { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String BillingCurrency { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Decimal> BillablePriceForGeneralPreparation { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String StudyDocumentationUrl { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String CaseReportFormUrl { get; set; }

}

public class ProcedureSchedule {

  [Required]
  public Guid ProcedureScheduleId { get; set; } = Guid.NewGuid();

  /// <summary> *this field has a max length of 100 </summary>
  [MaxLength(100), Required]
  public String StudyWorkflowName { get; set; }

  /// <summary> *this field has a max length of 20 </summary>
  [MaxLength(20), Required]
  public String StudyWorkflowVersion { get; set; }

  [Required]
  public String Title { get; set; }

  [Required]
  public String MaxSkipsBeforeLost { get; set; }

  [Required]
  public String MaxSubsequentSkipsBeforeLost { get; set; }

  [Required]
  public String MaxLostsBeforeLtfuAbort { get; set; }

  [Required]
  public String MaxSubsequentLostsBeforeLtfuAbort { get; set; }

  [Required]
  public String EventOnLtfuAbort { get; set; }

  [Required]
  public String EventOnCycleEnded { get; set; }

  [Required]
  public String EventOnAllCyclesEnded { get; set; }

  [Required]
  public String InducingEvents { get; set; }

  [Required]
  public String AbortCausingEvents { get; set; }

}

public class DataRecordingTask {

  /// <summary> *this field has a max length of 50 </summary>
  [MaxLength(50), Required]
  public String DataRecordingName { get; set; }

  /// <summary> *this field has a max length of 100 </summary>
  [MaxLength(100), Required]
  public String StudyWorkflowName { get; set; }

  /// <summary> *this field has a max length of 20 </summary>
  [MaxLength(20), Required]
  public String StudyWorkflowVersion { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Decimal> BillablePriceOnCompletedExecution { get; set; }

  [Required]
  public String ShortDescription { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String TaskSpecificDocumentationUrl { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String ImportantNotices { get; set; }

  /// <summary> schema-url of the data which have to be recorded </summary>
  [Required]
  public String DataSchemaUrl { get; set; }

  /// <summary> RAW data, in the schema as defined at the 'DataSchemaUrl' *this field is optional (use null as value) </summary>
  public String DefaultData { get; set; }

}

public class InducedDataRecordingTask {

  [Required]
  public Guid Id { get; set; } = Guid.NewGuid();

  [Required]
  public Guid TaskScheduleId { get; set; }

  /// <summary> *this field has a max length of 50 </summary>
  [MaxLength(50), Required]
  public String InducedDataRecordingName { get; set; }

  /// <summary> estimated scheduling time relative to the scheduling date of the parent TaskSchedule </summary>
  [Required]
  public Int32 Offset { get; set; }

  /// <summary> 'h'=Hours / 'm'=Minutes / 's'=Seconds </summary>
  [Required]
  public String OffsetUnit { get; set; }

  /// <summary> defines an additional variability RELATIVE to the estimated scheduling time (which is calculated from the offset), in this case the EARLIEST possible time. </summary>
  [Required]
  public String SchedulingVariabilityBefore { get; set; }

  /// <summary> defines an additional variability RELATIVE to the estimated scheduling time (which is calculated from the offset), in this case the LATEST possible time. </summary>
  [Required]
  public String SchedulingVariabilityAfter { get; set; }

  /// <summary> 'h'=Hours / 'm'=Minutes / 's'=Seconds </summary>
  [Required]
  public String SchedulingVariabilityUnit { get; set; }

  /// <summary> the title for the induced execution, like 'Measurement X', which is usually defined by the study protocol. if multiple inducements are possible (for example when using cycles), the title should to contain a placeholder (example: '{vt} - Measurement X') to prevent from duplicate execution titles. </summary>
  [Required]
  public String InducedTaskExecutionTitle { get; set; }

  /// <summary> defines, if the study protocol tolerates this execution to be 'skipped' (if not, a missed execution is treated as 'lost' and can cause the exclusion of the participant) </summary>
  [Required]
  public Boolean Skipable { get; set; }

  [Required]
  public String EventOnSkip { get; set; }

  [Required]
  public String EventOnLost { get; set; }

}

public class DrugApplymentTask {

  /// <summary> *this field has a max length of 50 </summary>
  [MaxLength(50), Required]
  public String DrugApplymentName { get; set; }

  /// <summary> *this field has a max length of 100 </summary>
  [MaxLength(100), Required]
  public String StudyWorkflowName { get; set; }

  /// <summary> *this field has a max length of 20 </summary>
  [MaxLength(20), Required]
  public String StudyWorkflowVersion { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Decimal> BillablePriceOnCompletedExecution { get; set; }

  [Required]
  public String ShortDescription { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String TaskSpecificDocumentationUrl { get; set; }

  [Required]
  public String DrugName { get; set; }

  [Required]
  public Decimal DrugDoseMgPerUnitMg { get; set; }

  [Required]
  public Decimal UnitsToApply { get; set; }

  [Required]
  public String ApplymentRoute { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String ImportantNotices { get; set; }

}

public class InducedDrugApplymentTask {

  [Required]
  public Guid Id { get; set; } = Guid.NewGuid();

  [Required]
  public Guid TaskScheduleId { get; set; }

  /// <summary> *this field has a max length of 50 </summary>
  [MaxLength(50), Required]
  public String InducedDrugApplymentName { get; set; }

  /// <summary> estimated scheduling time relative to the scheduling date of the parent TaskSchedule </summary>
  [Required]
  public Int32 Offset { get; set; }

  /// <summary> 'h'=Hours / 'm'=Minutes / 's'=Seconds </summary>
  [Required]
  public String OffsetUnit { get; set; }

  /// <summary> defines an additional variability RELATIVE to the estimated scheduling time (which is calculated from the offset), in this case the EARLIEST possible time. </summary>
  [Required]
  public String SchedulingVariabilityBefore { get; set; }

  /// <summary> defines an additional variability RELATIVE to the estimated scheduling time (which is calculated from the offset), in this case the LATEST possible time. </summary>
  [Required]
  public String SchedulingVariabilityAfter { get; set; }

  /// <summary> 'h'=Hours / 'm'=Minutes / 's'=Seconds </summary>
  [Required]
  public String SchedulingVariabilityUnit { get; set; }

  /// <summary> the title for the induced execution, like 'Measurement X', which is usually defined by the study protocol. if multiple inducements are possible (for example when using cycles), the title should to contain a placeholder (example: '{vt} - Measurement X') to prevent from duplicate execution titles. </summary>
  [Required]
  public String InducedTaskExecutionTitle { get; set; }

  /// <summary> defines, if the study protocol tolerates this execution to be 'skipped' (if not, a missed execution is treated as 'lost' and can cause the exclusion of the participant) </summary>
  [Required]
  public Boolean Skipable { get; set; }

  [Required]
  public String EventOnSkip { get; set; }

  [Required]
  public String EventOnLost { get; set; }

}

public class TaskSchedule {

  [Required]
  public Guid TaskScheduleId { get; set; } = Guid.NewGuid();

  /// <summary> *this field has a max length of 100 </summary>
  [MaxLength(100), Required]
  public String StudyWorkflowName { get; set; }

  /// <summary> *this field has a max length of 20 </summary>
  [MaxLength(20), Required]
  public String StudyWorkflowVersion { get; set; }

  [Required]
  public String Title { get; set; }

  [Required]
  public String MaxSkipsBeforeLost { get; set; }

  [Required]
  public String MaxSubsequentSkipsBeforeLost { get; set; }

  [Required]
  public String MaxLostsBeforeLtfuAbort { get; set; }

  [Required]
  public String MaxSubsequentLostsBeforeLtfuAbort { get; set; }

  [Required]
  public String EventOnLtfuAbort { get; set; }

  [Required]
  public String EventOnCycleEnded { get; set; }

  [Required]
  public String EventOnAllCyclesEnded { get; set; }

  [Required]
  public String InducingEvents { get; set; }

  [Required]
  public String AbortCausingEvents { get; set; }

}

public class InducedSubProcedureSchedule {

  [Required]
  public Guid Id { get; set; } = Guid.NewGuid();

  [Required]
  public Guid ParentProcedureScheduleId { get; set; }

  [Required]
  public Guid InducedProcedureScheduleId { get; set; }

  /// <summary> estimated scheduling date relative to the scheduling date of the parent ProcedureSchedule </summary>
  [Required]
  public Int32 Offset { get; set; }

  /// <summary> 'M'=Months / 'W'=Weeks / 'D'=Days </summary>
  [Required]
  public String OffsetUnit { get; set; }

  /// <summary> defines an additional variability RELATIVE to the estimated scheduling date (which is calculated from the offset), in this case the EARLIEST possible date. </summary>
  [Required]
  public String SchedulingVariabilityBefore { get; set; }

  /// <summary> defines an additional variability RELATIVE to the estimated scheduling date (which is calculated from the offset), in this case the LATEST possible date. </summary>
  [Required]
  public String SchedulingVariabilityAfter { get; set; }

  /// <summary> 'M'=Months / 'W'=Weeks / 'D'=Days </summary>
  [Required]
  public String SchedulingVariabilityUnit { get; set; }

  [Required]
  public Boolean SharedSkipCounters { get; set; }

  [Required]
  public Boolean SharedLostCounters { get; set; }

}

public class InducedSubTaskSchedule {

  [Required]
  public Guid Id { get; set; } = Guid.NewGuid();

  [Required]
  public Guid ParentTaskScheduleId { get; set; }

  [Required]
  public Guid InducedTaskScheduleId { get; set; }

  /// <summary> estimated scheduling time relative to the scheduling date of the parent ProcedureSchedule </summary>
  [Required]
  public Int32 Offset { get; set; }

  /// <summary> 'h'=Hours / 'm'=Minutes / 's'=Seconds </summary>
  [Required]
  public String OffsetUnit { get; set; }

  /// <summary> defines an additional variability RELATIVE to the estimated scheduling time (which is calculated from the offset), in this case the EARLIEST possible time. </summary>
  [Required]
  public String SchedulingVariabilityBefore { get; set; }

  /// <summary> defines an additional variability RELATIVE to the estimated scheduling time (which is calculated from the offset), in this case the LATEST possible time. </summary>
  [Required]
  public String SchedulingVariabilityAfter { get; set; }

  /// <summary> 'h'=Hours / 'm'=Minutes / 's'=Seconds </summary>
  [Required]
  public String SchedulingVariabilityUnit { get; set; }

  [Required]
  public Boolean SharedSkipCounters { get; set; }

  [Required]
  public Boolean SharedLostCounters { get; set; }

}

public class InducedTreatmentTask {

  [Required]
  public Guid Id { get; set; } = Guid.NewGuid();

  [Required]
  public Guid TaskScheduleId { get; set; }

  /// <summary> *this field has a max length of 50 </summary>
  [MaxLength(50), Required]
  public String InducedTreatmentName { get; set; }

  /// <summary> estimated scheduling time relative to the scheduling date of the parent TaskSchedule </summary>
  [Required]
  public Int32 Offset { get; set; }

  /// <summary> 'h'=Hours / 'm'=Minutes / 's'=Seconds </summary>
  [Required]
  public String OffsetUnit { get; set; }

  /// <summary> defines an additional variability RELATIVE to the estimated scheduling time (which is calculated from the offset), in this case the EARLIEST possible time. </summary>
  [Required]
  public String SchedulingVariabilityBefore { get; set; }

  /// <summary> defines an additional variability RELATIVE to the estimated scheduling time (which is calculated from the offset), in this case the LATEST possible time. </summary>
  [Required]
  public String SchedulingVariabilityAfter { get; set; }

  /// <summary> 'h'=Hours / 'm'=Minutes / 's'=Seconds </summary>
  [Required]
  public String SchedulingVariabilityUnit { get; set; }

  /// <summary> the title for the induced execution, like 'Measurement X', which is usually defined by the study protocol. if multiple inducements are possible (for example when using cycles), the title should to contain a placeholder (example: '{vt} - Measurement X') to prevent from duplicate execution titles. </summary>
  [Required]
  public String InducedTaskExecutionTitle { get; set; }

  /// <summary> defines, if the study protocol tolerates this execution to be 'skipped' (if not, a missed execution is treated as 'lost' and can cause the exclusion of the participant) </summary>
  [Required]
  public Boolean Skipable { get; set; }

  [Required]
  public String EventOnSkip { get; set; }

  [Required]
  public String EventOnLost { get; set; }

}

public class TreatmentTask {

  /// <summary> *this field has a max length of 50 </summary>
  [MaxLength(50), Required]
  public String TreatmentName { get; set; }

  /// <summary> *this field has a max length of 100 </summary>
  [MaxLength(100), Required]
  public String StudyWorkflowName { get; set; }

  /// <summary> *this field has a max length of 20 </summary>
  [MaxLength(20), Required]
  public String StudyWorkflowVersion { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Decimal> BillablePriceOnCompletedExecution { get; set; }

  [Required]
  public String ShortDescription { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String TaskSpecificDocumentationUrl { get; set; }

  [Required]
  public String TreatmentDescription { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String ImportantNotices { get; set; }

}

public class InducedVisitProcedure {

  [Required]
  public Guid Id { get; set; } = Guid.NewGuid();

  [Required]
  public Guid ProcedureScheduleId { get; set; }

  /// <summary> estimated scheduling date relative to the scheduling date of the parent ProcedureSchedule </summary>
  [Required]
  public Int32 Offset { get; set; }

  /// <summary> 'M'=Months / 'W'=Weeks / 'D'=Days </summary>
  [Required]
  public String OffsetUnit { get; set; }

  /// <summary> defines an additional variability RELATIVE to the estimated scheduling date (which is calculated from the offset), in this case the EARLIEST possible date. </summary>
  [Required]
  public String SchedulingVariabilityBefore { get; set; }

  /// <summary> defines an additional variability RELATIVE to the estimated scheduling date (which is calculated from the offset), in this case the LATEST possible date. </summary>
  [Required]
  public String SchedulingVariabilityAfter { get; set; }

  /// <summary> 'M'=Months / 'W'=Weeks / 'D'=Days </summary>
  [Required]
  public String SchedulingVariabilityUnit { get; set; }

  /// <summary> *this field has a max length of 50 </summary>
  [MaxLength(50), Required]
  public String InducedVisitProdecureName { get; set; }

  /// <summary> the title for the induced execution, like 'V0', which is usually defined by the study protocol. if multiple inducements are possible (for example when using cycles), the title should to contain a placeholder (example: 'C{cs}-V0') to prevent from duplicate execution titles. </summary>
  [Required]
  public String InducedVisitExecutionTitle { get; set; }

  /// <summary> defines, if the study protocol tolerates this execution to be 'skipped' (if not, a missed execution is treated as 'lost' and can cause the exclusion of the participant) </summary>
  [Required]
  public Boolean Skipable { get; set; }

  [Required]
  public String EventOnSkip { get; set; }

  [Required]
  public String EventOnLost { get; set; }

}

public class VisitProdecureDefinition {

  /// <summary> *this field has a max length of 50 </summary>
  [MaxLength(50), Required]
  public String VisitProdecureName { get; set; }

  /// <summary> *this field has a max length of 100 </summary>
  [MaxLength(100), Required]
  public String StudyWorkflowName { get; set; }

  /// <summary> *this field has a max length of 20 </summary>
  [MaxLength(20), Required]
  public String StudyWorkflowVersion { get; set; }

  /// <summary> the TaskSchedule which is representing the primary-/entry-workflow (estimated tasks) when executing this visit *this field is optional </summary>
  public Nullable<Guid> RootTaskScheduleId { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Decimal> BillablePriceOnAbortedExecution { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Decimal> BillablePriceOnCompletedExecution { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String VisitSpecificDocumentationUrl { get; set; }

}

public class ProcedureCycleDefinition {

  [Required]
  public Guid ProcedureScheduleId { get; set; } = Guid.NewGuid();

  /// <summary> 1=EstimatedParent (related to the inducing date of the parent ProcedureSchedule) / 2=LastEstimatedInducement (related to the ESTIMATED scheduling date of the last inducement within the parent ProcedureSchedule) / 3=LastExecutedInducement  (related to the REAL EXECUTION date of the last inducement within the parent ProcedureSchedule) </summary>
  [Required]
  public Int32 ReschedulingBase { get; set; }

  /// <summary> estimated scheduling date relative to the ReschedulingBase </summary>
  [Required]
  public String ReschedulingOffset { get; set; }

  /// <summary> 'M'=Months / 'W'=Weeks / 'D'=Days </summary>
  [Required]
  public String ReschedulingOffsetUnit { get; set; }

  /// <summary> number of cycles (of null for a infinite number of cycles) *this field is optional </summary>
  public Nullable<Int32> CycleLimit { get; set; }

  [Required]
  public Boolean SharedSkipCounters { get; set; }

  [Required]
  public Boolean SharedLostCounters { get; set; }

}

public class StudyEvent {

  /// <summary> *this field has a max length of 50 </summary>
  [MaxLength(50), Required]
  public String StudyEventName { get; set; }

  /// <summary> *this field has a max length of 100 </summary>
  [MaxLength(100), Required]
  public String StudyWorkflowName { get; set; }

  /// <summary> *this field has a max length of 20 </summary>
  [MaxLength(20), Required]
  public String StudyWorkflowVersion { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Int32> MaxOccourrencesBeforeExclusion { get; set; }

  [Required]
  public Boolean AllowManualTrigger { get; set; }

  [Required]
  public String Description { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String EvenSpecificDocumentationUrl { get; set; }

}

public class TaskCycleDefinition {

  [Required]
  public Guid TaskScheduleId { get; set; } = Guid.NewGuid();

  /// <summary> 1=EstimatedParent (related to the inducing time of the parent TaskSchedule) / 2=LastEstimatedInducement (related to the ESTIMATED scheduling time of the last inducement within the parent TaskSchedule) / 3=LastExecutedInducement  (related to the REAL EXECUTION time of the last inducement within the parent TaskSchedule) </summary>
  [Required]
  public String ReschedulingBase { get; set; }

  /// <summary> estimated scheduling time relative to the ReschedulingBase </summary>
  [Required]
  public String ReschedulingOffset { get; set; }

  /// <summary> 'h'=Hours / 'm'=Minutes / 's'=Seconds </summary>
  [Required]
  public String ReschedulingOffsetUnit { get; set; }

  /// <summary> number of cycles (of null for a infinite number of cycles) *this field is optional </summary>
  public Nullable<Int32> CycleLimit { get; set; }

  [Required]
  public Boolean SharedSkipCounters { get; set; }

  [Required]
  public Boolean SharedLostCounters { get; set; }

}

}
