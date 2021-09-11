using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace MedicalResearch.Workflow.Persistence {

public class ArmEntity {

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

  [Principal]
  public virtual ResearchStudyEntity ResearchStudy { get; set; }

  /// <summary> the ProcedureSchedule which is representing the primary-/entry-workflow (estimated visits) for participants of this arm </summary>
  [Lookup]
  public virtual ProcedureScheduleEntity RootProcedureSchedule { get; set; }

#region Mapping

  internal static Expression<Func<Arm, ArmEntity>> ArmEntitySelector = ((Arm src) => new ArmEntity {
    StudyArmName = src.StudyArmName,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    RootProcedureScheduleId = src.RootProcedureScheduleId,
    BillablePriceOnFailedInclusion = src.BillablePriceOnFailedInclusion,
    BillablePriceOnSuccessfullInclusion = src.BillablePriceOnSuccessfullInclusion,
    BillablePriceOnAbortedParticipation = src.BillablePriceOnAbortedParticipation,
    BillablePriceOnCompletedParticipation = src.BillablePriceOnCompletedParticipation,
    ArmSpecificDocumentationUrl = src.ArmSpecificDocumentationUrl,
    InclusionCriteria = src.InclusionCriteria,
    Substudy = src.Substudy,
  });

  internal static Expression<Func<ArmEntity, Arm>> ArmSelector = ((ArmEntity src) => new Arm {
    StudyArmName = src.StudyArmName,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    RootProcedureScheduleId = src.RootProcedureScheduleId,
    BillablePriceOnFailedInclusion = src.BillablePriceOnFailedInclusion,
    BillablePriceOnSuccessfullInclusion = src.BillablePriceOnSuccessfullInclusion,
    BillablePriceOnAbortedParticipation = src.BillablePriceOnAbortedParticipation,
    BillablePriceOnCompletedParticipation = src.BillablePriceOnCompletedParticipation,
    ArmSpecificDocumentationUrl = src.ArmSpecificDocumentationUrl,
    InclusionCriteria = src.InclusionCriteria,
    Substudy = src.Substudy,
  });

  internal void CopyContentFrom(Arm source, Func<String,bool> onFixedValueChangingCallback = null){
    this.StudyArmName = source.StudyArmName;
    this.StudyWorkflowName = source.StudyWorkflowName;
    this.StudyWorkflowVersion = source.StudyWorkflowVersion;
    this.RootProcedureScheduleId = source.RootProcedureScheduleId;
    this.BillablePriceOnFailedInclusion = source.BillablePriceOnFailedInclusion;
    this.BillablePriceOnSuccessfullInclusion = source.BillablePriceOnSuccessfullInclusion;
    this.BillablePriceOnAbortedParticipation = source.BillablePriceOnAbortedParticipation;
    this.BillablePriceOnCompletedParticipation = source.BillablePriceOnCompletedParticipation;
    this.ArmSpecificDocumentationUrl = source.ArmSpecificDocumentationUrl;
    this.InclusionCriteria = source.InclusionCriteria;
    this.Substudy = source.Substudy;
  }

  internal void CopyContentTo(Arm target, Func<String,bool> onFixedValueChangingCallback = null){
    target.StudyArmName = this.StudyArmName;
    target.StudyWorkflowName = this.StudyWorkflowName;
    target.StudyWorkflowVersion = this.StudyWorkflowVersion;
    target.RootProcedureScheduleId = this.RootProcedureScheduleId;
    target.BillablePriceOnFailedInclusion = this.BillablePriceOnFailedInclusion;
    target.BillablePriceOnSuccessfullInclusion = this.BillablePriceOnSuccessfullInclusion;
    target.BillablePriceOnAbortedParticipation = this.BillablePriceOnAbortedParticipation;
    target.BillablePriceOnCompletedParticipation = this.BillablePriceOnCompletedParticipation;
    target.ArmSpecificDocumentationUrl = this.ArmSpecificDocumentationUrl;
    target.InclusionCriteria = this.InclusionCriteria;
    target.Substudy = this.Substudy;
  }

#endregion

}

public class ResearchStudyEntity {

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

  [Dependent]
  public virtual ObservableCollection<ArmEntity> Arms { get; set; } = new ObservableCollection<ArmEntity>();

  [Dependent]
  public virtual ObservableCollection<DataRecordingTaskEntity> DataRecordingTasks { get; set; } = new ObservableCollection<DataRecordingTaskEntity>();

  [Dependent]
  public virtual ObservableCollection<DrugApplymentTaskEntity> DrugApplymentTasks { get; set; } = new ObservableCollection<DrugApplymentTaskEntity>();

  [Dependent]
  public virtual ObservableCollection<ProcedureScheduleEntity> ProcedureSchedules { get; set; } = new ObservableCollection<ProcedureScheduleEntity>();

  [Dependent]
  public virtual ObservableCollection<TreatmentTaskEntity> TreatmentTasks { get; set; } = new ObservableCollection<TreatmentTaskEntity>();

  [Dependent]
  public virtual ObservableCollection<TaskScheduleEntity> TaskSchedules { get; set; } = new ObservableCollection<TaskScheduleEntity>();

  [Dependent]
  public virtual ObservableCollection<VisitProdecureDefinitionEntity> VisitProdecureDefinitions { get; set; } = new ObservableCollection<VisitProdecureDefinitionEntity>();

  [Dependent]
  public virtual ObservableCollection<StudyEventEntity> Events { get; set; } = new ObservableCollection<StudyEventEntity>();

#region Mapping

  internal static Expression<Func<ResearchStudy, ResearchStudyEntity>> ResearchStudyEntitySelector = ((ResearchStudy src) => new ResearchStudyEntity {
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    OfficialLabel = src.OfficialLabel,
    DefinitionOwner = src.DefinitionOwner,
    DocumentationUrl = src.DocumentationUrl,
    LogoImage = src.LogoImage,
    Description = src.Description,
    VersionIdentity = src.VersionIdentity,
    LastChangeUtc = src.LastChangeUtc,
    DraftState = src.DraftState,
    BillingCurrency = src.BillingCurrency,
    BillablePriceForGeneralPreparation = src.BillablePriceForGeneralPreparation,
    StudyDocumentationUrl = src.StudyDocumentationUrl,
    CaseReportFormUrl = src.CaseReportFormUrl,
  });

  internal static Expression<Func<ResearchStudyEntity, ResearchStudy>> ResearchStudySelector = ((ResearchStudyEntity src) => new ResearchStudy {
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    OfficialLabel = src.OfficialLabel,
    DefinitionOwner = src.DefinitionOwner,
    DocumentationUrl = src.DocumentationUrl,
    LogoImage = src.LogoImage,
    Description = src.Description,
    VersionIdentity = src.VersionIdentity,
    LastChangeUtc = src.LastChangeUtc,
    DraftState = src.DraftState,
    BillingCurrency = src.BillingCurrency,
    BillablePriceForGeneralPreparation = src.BillablePriceForGeneralPreparation,
    StudyDocumentationUrl = src.StudyDocumentationUrl,
    CaseReportFormUrl = src.CaseReportFormUrl,
  });

  internal void CopyContentFrom(ResearchStudy source, Func<String,bool> onFixedValueChangingCallback = null){
    this.StudyWorkflowName = source.StudyWorkflowName;
    this.StudyWorkflowVersion = source.StudyWorkflowVersion;
    this.OfficialLabel = source.OfficialLabel;
    this.DefinitionOwner = source.DefinitionOwner;
    this.DocumentationUrl = source.DocumentationUrl;
    this.LogoImage = source.LogoImage;
    this.Description = source.Description;
    this.VersionIdentity = source.VersionIdentity;
    this.LastChangeUtc = source.LastChangeUtc;
    this.DraftState = source.DraftState;
    this.BillingCurrency = source.BillingCurrency;
    this.BillablePriceForGeneralPreparation = source.BillablePriceForGeneralPreparation;
    this.StudyDocumentationUrl = source.StudyDocumentationUrl;
    this.CaseReportFormUrl = source.CaseReportFormUrl;
  }

  internal void CopyContentTo(ResearchStudy target, Func<String,bool> onFixedValueChangingCallback = null){
    target.StudyWorkflowName = this.StudyWorkflowName;
    target.StudyWorkflowVersion = this.StudyWorkflowVersion;
    target.OfficialLabel = this.OfficialLabel;
    target.DefinitionOwner = this.DefinitionOwner;
    target.DocumentationUrl = this.DocumentationUrl;
    target.LogoImage = this.LogoImage;
    target.Description = this.Description;
    target.VersionIdentity = this.VersionIdentity;
    target.LastChangeUtc = this.LastChangeUtc;
    target.DraftState = this.DraftState;
    target.BillingCurrency = this.BillingCurrency;
    target.BillablePriceForGeneralPreparation = this.BillablePriceForGeneralPreparation;
    target.StudyDocumentationUrl = this.StudyDocumentationUrl;
    target.CaseReportFormUrl = this.CaseReportFormUrl;
  }

#endregion

}

public class ProcedureScheduleEntity {

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

  /// <summary> the ProcedureSchedule which is representing the primary-/entry-workflow (estimated visits) for participants of this arm </summary>
  [Referer]
  public virtual ObservableCollection<ArmEntity> EntryArms { get; set; } = new ObservableCollection<ArmEntity>();

  [Dependent]
  public virtual ObservableCollection<InducedSubProcedureScheduleEntity> InducedSubProcedureSchedules { get; set; } = new ObservableCollection<InducedSubProcedureScheduleEntity>();

  [Referer]
  public virtual ObservableCollection<InducedSubProcedureScheduleEntity> InducingSubProcedureSchedules { get; set; } = new ObservableCollection<InducedSubProcedureScheduleEntity>();

  [Dependent]
  public virtual ObservableCollection<InducedVisitProcedureEntity> InducedProcedures { get; set; } = new ObservableCollection<InducedVisitProcedureEntity>();

  [Dependent]
  public virtual ProcedureCycleDefinitionEntity CycleDefinition { get; set; }

  [Principal]
  public virtual ResearchStudyEntity ResearchStudy { get; set; }

#region Mapping

  internal static Expression<Func<ProcedureSchedule, ProcedureScheduleEntity>> ProcedureScheduleEntitySelector = ((ProcedureSchedule src) => new ProcedureScheduleEntity {
    ProcedureScheduleId = src.ProcedureScheduleId,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    Title = src.Title,
    MaxSkipsBeforeLost = src.MaxSkipsBeforeLost,
    MaxSubsequentSkipsBeforeLost = src.MaxSubsequentSkipsBeforeLost,
    MaxLostsBeforeLtfuAbort = src.MaxLostsBeforeLtfuAbort,
    MaxSubsequentLostsBeforeLtfuAbort = src.MaxSubsequentLostsBeforeLtfuAbort,
    EventOnLtfuAbort = src.EventOnLtfuAbort,
    EventOnCycleEnded = src.EventOnCycleEnded,
    EventOnAllCyclesEnded = src.EventOnAllCyclesEnded,
    InducingEvents = src.InducingEvents,
    AbortCausingEvents = src.AbortCausingEvents,
  });

  internal static Expression<Func<ProcedureScheduleEntity, ProcedureSchedule>> ProcedureScheduleSelector = ((ProcedureScheduleEntity src) => new ProcedureSchedule {
    ProcedureScheduleId = src.ProcedureScheduleId,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    Title = src.Title,
    MaxSkipsBeforeLost = src.MaxSkipsBeforeLost,
    MaxSubsequentSkipsBeforeLost = src.MaxSubsequentSkipsBeforeLost,
    MaxLostsBeforeLtfuAbort = src.MaxLostsBeforeLtfuAbort,
    MaxSubsequentLostsBeforeLtfuAbort = src.MaxSubsequentLostsBeforeLtfuAbort,
    EventOnLtfuAbort = src.EventOnLtfuAbort,
    EventOnCycleEnded = src.EventOnCycleEnded,
    EventOnAllCyclesEnded = src.EventOnAllCyclesEnded,
    InducingEvents = src.InducingEvents,
    AbortCausingEvents = src.AbortCausingEvents,
  });

  internal void CopyContentFrom(ProcedureSchedule source, Func<String,bool> onFixedValueChangingCallback = null){
    this.ProcedureScheduleId = source.ProcedureScheduleId;
    this.StudyWorkflowName = source.StudyWorkflowName;
    this.StudyWorkflowVersion = source.StudyWorkflowVersion;
    this.Title = source.Title;
    this.MaxSkipsBeforeLost = source.MaxSkipsBeforeLost;
    this.MaxSubsequentSkipsBeforeLost = source.MaxSubsequentSkipsBeforeLost;
    this.MaxLostsBeforeLtfuAbort = source.MaxLostsBeforeLtfuAbort;
    this.MaxSubsequentLostsBeforeLtfuAbort = source.MaxSubsequentLostsBeforeLtfuAbort;
    this.EventOnLtfuAbort = source.EventOnLtfuAbort;
    this.EventOnCycleEnded = source.EventOnCycleEnded;
    this.EventOnAllCyclesEnded = source.EventOnAllCyclesEnded;
    this.InducingEvents = source.InducingEvents;
    this.AbortCausingEvents = source.AbortCausingEvents;
  }

  internal void CopyContentTo(ProcedureSchedule target, Func<String,bool> onFixedValueChangingCallback = null){
    target.ProcedureScheduleId = this.ProcedureScheduleId;
    target.StudyWorkflowName = this.StudyWorkflowName;
    target.StudyWorkflowVersion = this.StudyWorkflowVersion;
    target.Title = this.Title;
    target.MaxSkipsBeforeLost = this.MaxSkipsBeforeLost;
    target.MaxSubsequentSkipsBeforeLost = this.MaxSubsequentSkipsBeforeLost;
    target.MaxLostsBeforeLtfuAbort = this.MaxLostsBeforeLtfuAbort;
    target.MaxSubsequentLostsBeforeLtfuAbort = this.MaxSubsequentLostsBeforeLtfuAbort;
    target.EventOnLtfuAbort = this.EventOnLtfuAbort;
    target.EventOnCycleEnded = this.EventOnCycleEnded;
    target.EventOnAllCyclesEnded = this.EventOnAllCyclesEnded;
    target.InducingEvents = this.InducingEvents;
    target.AbortCausingEvents = this.AbortCausingEvents;
  }

#endregion

}

public class DataRecordingTaskEntity {

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

  [Referer]
  public virtual ObservableCollection<InducedDataRecordingTaskEntity> Inducements { get; set; } = new ObservableCollection<InducedDataRecordingTaskEntity>();

  [Principal]
  public virtual ResearchStudyEntity ResearchStudy { get; set; }

#region Mapping

  internal static Expression<Func<DataRecordingTask, DataRecordingTaskEntity>> DataRecordingTaskEntitySelector = ((DataRecordingTask src) => new DataRecordingTaskEntity {
    DataRecordingName = src.DataRecordingName,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    BillablePriceOnCompletedExecution = src.BillablePriceOnCompletedExecution,
    ShortDescription = src.ShortDescription,
    TaskSpecificDocumentationUrl = src.TaskSpecificDocumentationUrl,
    ImportantNotices = src.ImportantNotices,
    DataSchemaUrl = src.DataSchemaUrl,
    DefaultData = src.DefaultData,
  });

  internal static Expression<Func<DataRecordingTaskEntity, DataRecordingTask>> DataRecordingTaskSelector = ((DataRecordingTaskEntity src) => new DataRecordingTask {
    DataRecordingName = src.DataRecordingName,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    BillablePriceOnCompletedExecution = src.BillablePriceOnCompletedExecution,
    ShortDescription = src.ShortDescription,
    TaskSpecificDocumentationUrl = src.TaskSpecificDocumentationUrl,
    ImportantNotices = src.ImportantNotices,
    DataSchemaUrl = src.DataSchemaUrl,
    DefaultData = src.DefaultData,
  });

  internal void CopyContentFrom(DataRecordingTask source, Func<String,bool> onFixedValueChangingCallback = null){
    this.DataRecordingName = source.DataRecordingName;
    this.StudyWorkflowName = source.StudyWorkflowName;
    this.StudyWorkflowVersion = source.StudyWorkflowVersion;
    this.BillablePriceOnCompletedExecution = source.BillablePriceOnCompletedExecution;
    this.ShortDescription = source.ShortDescription;
    this.TaskSpecificDocumentationUrl = source.TaskSpecificDocumentationUrl;
    this.ImportantNotices = source.ImportantNotices;
    this.DataSchemaUrl = source.DataSchemaUrl;
    this.DefaultData = source.DefaultData;
  }

  internal void CopyContentTo(DataRecordingTask target, Func<String,bool> onFixedValueChangingCallback = null){
    target.DataRecordingName = this.DataRecordingName;
    target.StudyWorkflowName = this.StudyWorkflowName;
    target.StudyWorkflowVersion = this.StudyWorkflowVersion;
    target.BillablePriceOnCompletedExecution = this.BillablePriceOnCompletedExecution;
    target.ShortDescription = this.ShortDescription;
    target.TaskSpecificDocumentationUrl = this.TaskSpecificDocumentationUrl;
    target.ImportantNotices = this.ImportantNotices;
    target.DataSchemaUrl = this.DataSchemaUrl;
    target.DefaultData = this.DefaultData;
  }

#endregion

}

public class InducedDataRecordingTaskEntity {

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

  [Lookup]
  public virtual DataRecordingTaskEntity InducedTask { get; set; }

  [Principal]
  public virtual TaskScheduleEntity TaskSchedule { get; set; }

#region Mapping

  internal static Expression<Func<InducedDataRecordingTask, InducedDataRecordingTaskEntity>> InducedDataRecordingTaskEntitySelector = ((InducedDataRecordingTask src) => new InducedDataRecordingTaskEntity {
    Id = src.Id,
    TaskScheduleId = src.TaskScheduleId,
    InducedDataRecordingName = src.InducedDataRecordingName,
    Offset = src.Offset,
    OffsetUnit = src.OffsetUnit,
    SchedulingVariabilityBefore = src.SchedulingVariabilityBefore,
    SchedulingVariabilityAfter = src.SchedulingVariabilityAfter,
    SchedulingVariabilityUnit = src.SchedulingVariabilityUnit,
    InducedTaskExecutionTitle = src.InducedTaskExecutionTitle,
    Skipable = src.Skipable,
    EventOnSkip = src.EventOnSkip,
    EventOnLost = src.EventOnLost,
  });

  internal static Expression<Func<InducedDataRecordingTaskEntity, InducedDataRecordingTask>> InducedDataRecordingTaskSelector = ((InducedDataRecordingTaskEntity src) => new InducedDataRecordingTask {
    Id = src.Id,
    TaskScheduleId = src.TaskScheduleId,
    InducedDataRecordingName = src.InducedDataRecordingName,
    Offset = src.Offset,
    OffsetUnit = src.OffsetUnit,
    SchedulingVariabilityBefore = src.SchedulingVariabilityBefore,
    SchedulingVariabilityAfter = src.SchedulingVariabilityAfter,
    SchedulingVariabilityUnit = src.SchedulingVariabilityUnit,
    InducedTaskExecutionTitle = src.InducedTaskExecutionTitle,
    Skipable = src.Skipable,
    EventOnSkip = src.EventOnSkip,
    EventOnLost = src.EventOnLost,
  });

  internal void CopyContentFrom(InducedDataRecordingTask source, Func<String,bool> onFixedValueChangingCallback = null){
    this.Id = source.Id;
    this.TaskScheduleId = source.TaskScheduleId;
    this.InducedDataRecordingName = source.InducedDataRecordingName;
    this.Offset = source.Offset;
    this.OffsetUnit = source.OffsetUnit;
    this.SchedulingVariabilityBefore = source.SchedulingVariabilityBefore;
    this.SchedulingVariabilityAfter = source.SchedulingVariabilityAfter;
    this.SchedulingVariabilityUnit = source.SchedulingVariabilityUnit;
    this.InducedTaskExecutionTitle = source.InducedTaskExecutionTitle;
    this.Skipable = source.Skipable;
    this.EventOnSkip = source.EventOnSkip;
    this.EventOnLost = source.EventOnLost;
  }

  internal void CopyContentTo(InducedDataRecordingTask target, Func<String,bool> onFixedValueChangingCallback = null){
    target.Id = this.Id;
    target.TaskScheduleId = this.TaskScheduleId;
    target.InducedDataRecordingName = this.InducedDataRecordingName;
    target.Offset = this.Offset;
    target.OffsetUnit = this.OffsetUnit;
    target.SchedulingVariabilityBefore = this.SchedulingVariabilityBefore;
    target.SchedulingVariabilityAfter = this.SchedulingVariabilityAfter;
    target.SchedulingVariabilityUnit = this.SchedulingVariabilityUnit;
    target.InducedTaskExecutionTitle = this.InducedTaskExecutionTitle;
    target.Skipable = this.Skipable;
    target.EventOnSkip = this.EventOnSkip;
    target.EventOnLost = this.EventOnLost;
  }

#endregion

}

public class DrugApplymentTaskEntity {

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

  [Referer]
  public virtual ObservableCollection<InducedDrugApplymentTaskEntity> Inducements { get; set; } = new ObservableCollection<InducedDrugApplymentTaskEntity>();

  [Principal]
  public virtual ResearchStudyEntity ResearchStudy { get; set; }

#region Mapping

  internal static Expression<Func<DrugApplymentTask, DrugApplymentTaskEntity>> DrugApplymentTaskEntitySelector = ((DrugApplymentTask src) => new DrugApplymentTaskEntity {
    DrugApplymentName = src.DrugApplymentName,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    BillablePriceOnCompletedExecution = src.BillablePriceOnCompletedExecution,
    ShortDescription = src.ShortDescription,
    TaskSpecificDocumentationUrl = src.TaskSpecificDocumentationUrl,
    DrugName = src.DrugName,
    DrugDoseMgPerUnitMg = src.DrugDoseMgPerUnitMg,
    UnitsToApply = src.UnitsToApply,
    ApplymentRoute = src.ApplymentRoute,
    ImportantNotices = src.ImportantNotices,
  });

  internal static Expression<Func<DrugApplymentTaskEntity, DrugApplymentTask>> DrugApplymentTaskSelector = ((DrugApplymentTaskEntity src) => new DrugApplymentTask {
    DrugApplymentName = src.DrugApplymentName,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    BillablePriceOnCompletedExecution = src.BillablePriceOnCompletedExecution,
    ShortDescription = src.ShortDescription,
    TaskSpecificDocumentationUrl = src.TaskSpecificDocumentationUrl,
    DrugName = src.DrugName,
    DrugDoseMgPerUnitMg = src.DrugDoseMgPerUnitMg,
    UnitsToApply = src.UnitsToApply,
    ApplymentRoute = src.ApplymentRoute,
    ImportantNotices = src.ImportantNotices,
  });

  internal void CopyContentFrom(DrugApplymentTask source, Func<String,bool> onFixedValueChangingCallback = null){
    this.DrugApplymentName = source.DrugApplymentName;
    this.StudyWorkflowName = source.StudyWorkflowName;
    this.StudyWorkflowVersion = source.StudyWorkflowVersion;
    this.BillablePriceOnCompletedExecution = source.BillablePriceOnCompletedExecution;
    this.ShortDescription = source.ShortDescription;
    this.TaskSpecificDocumentationUrl = source.TaskSpecificDocumentationUrl;
    this.DrugName = source.DrugName;
    this.DrugDoseMgPerUnitMg = source.DrugDoseMgPerUnitMg;
    this.UnitsToApply = source.UnitsToApply;
    this.ApplymentRoute = source.ApplymentRoute;
    this.ImportantNotices = source.ImportantNotices;
  }

  internal void CopyContentTo(DrugApplymentTask target, Func<String,bool> onFixedValueChangingCallback = null){
    target.DrugApplymentName = this.DrugApplymentName;
    target.StudyWorkflowName = this.StudyWorkflowName;
    target.StudyWorkflowVersion = this.StudyWorkflowVersion;
    target.BillablePriceOnCompletedExecution = this.BillablePriceOnCompletedExecution;
    target.ShortDescription = this.ShortDescription;
    target.TaskSpecificDocumentationUrl = this.TaskSpecificDocumentationUrl;
    target.DrugName = this.DrugName;
    target.DrugDoseMgPerUnitMg = this.DrugDoseMgPerUnitMg;
    target.UnitsToApply = this.UnitsToApply;
    target.ApplymentRoute = this.ApplymentRoute;
    target.ImportantNotices = this.ImportantNotices;
  }

#endregion

}

public class InducedDrugApplymentTaskEntity {

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

  [Lookup]
  public virtual DrugApplymentTaskEntity InducedTask { get; set; }

  [Principal]
  public virtual TaskScheduleEntity TaskSchedule { get; set; }

#region Mapping

  internal static Expression<Func<InducedDrugApplymentTask, InducedDrugApplymentTaskEntity>> InducedDrugApplymentTaskEntitySelector = ((InducedDrugApplymentTask src) => new InducedDrugApplymentTaskEntity {
    Id = src.Id,
    TaskScheduleId = src.TaskScheduleId,
    InducedDrugApplymentName = src.InducedDrugApplymentName,
    Offset = src.Offset,
    OffsetUnit = src.OffsetUnit,
    SchedulingVariabilityBefore = src.SchedulingVariabilityBefore,
    SchedulingVariabilityAfter = src.SchedulingVariabilityAfter,
    SchedulingVariabilityUnit = src.SchedulingVariabilityUnit,
    InducedTaskExecutionTitle = src.InducedTaskExecutionTitle,
    Skipable = src.Skipable,
    EventOnSkip = src.EventOnSkip,
    EventOnLost = src.EventOnLost,
  });

  internal static Expression<Func<InducedDrugApplymentTaskEntity, InducedDrugApplymentTask>> InducedDrugApplymentTaskSelector = ((InducedDrugApplymentTaskEntity src) => new InducedDrugApplymentTask {
    Id = src.Id,
    TaskScheduleId = src.TaskScheduleId,
    InducedDrugApplymentName = src.InducedDrugApplymentName,
    Offset = src.Offset,
    OffsetUnit = src.OffsetUnit,
    SchedulingVariabilityBefore = src.SchedulingVariabilityBefore,
    SchedulingVariabilityAfter = src.SchedulingVariabilityAfter,
    SchedulingVariabilityUnit = src.SchedulingVariabilityUnit,
    InducedTaskExecutionTitle = src.InducedTaskExecutionTitle,
    Skipable = src.Skipable,
    EventOnSkip = src.EventOnSkip,
    EventOnLost = src.EventOnLost,
  });

  internal void CopyContentFrom(InducedDrugApplymentTask source, Func<String,bool> onFixedValueChangingCallback = null){
    this.Id = source.Id;
    this.TaskScheduleId = source.TaskScheduleId;
    this.InducedDrugApplymentName = source.InducedDrugApplymentName;
    this.Offset = source.Offset;
    this.OffsetUnit = source.OffsetUnit;
    this.SchedulingVariabilityBefore = source.SchedulingVariabilityBefore;
    this.SchedulingVariabilityAfter = source.SchedulingVariabilityAfter;
    this.SchedulingVariabilityUnit = source.SchedulingVariabilityUnit;
    this.InducedTaskExecutionTitle = source.InducedTaskExecutionTitle;
    this.Skipable = source.Skipable;
    this.EventOnSkip = source.EventOnSkip;
    this.EventOnLost = source.EventOnLost;
  }

  internal void CopyContentTo(InducedDrugApplymentTask target, Func<String,bool> onFixedValueChangingCallback = null){
    target.Id = this.Id;
    target.TaskScheduleId = this.TaskScheduleId;
    target.InducedDrugApplymentName = this.InducedDrugApplymentName;
    target.Offset = this.Offset;
    target.OffsetUnit = this.OffsetUnit;
    target.SchedulingVariabilityBefore = this.SchedulingVariabilityBefore;
    target.SchedulingVariabilityAfter = this.SchedulingVariabilityAfter;
    target.SchedulingVariabilityUnit = this.SchedulingVariabilityUnit;
    target.InducedTaskExecutionTitle = this.InducedTaskExecutionTitle;
    target.Skipable = this.Skipable;
    target.EventOnSkip = this.EventOnSkip;
    target.EventOnLost = this.EventOnLost;
  }

#endregion

}

public class TaskScheduleEntity {

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

  [Dependent]
  public virtual ObservableCollection<InducedDataRecordingTaskEntity> InducedDataRecordingTasks { get; set; } = new ObservableCollection<InducedDataRecordingTaskEntity>();

  [Dependent]
  public virtual ObservableCollection<InducedDrugApplymentTaskEntity> InducedDrugApplymentTasks { get; set; } = new ObservableCollection<InducedDrugApplymentTaskEntity>();

  [Dependent]
  public virtual ObservableCollection<InducedSubTaskScheduleEntity> InducedSubTaskSchedules { get; set; } = new ObservableCollection<InducedSubTaskScheduleEntity>();

  [Referer]
  public virtual ObservableCollection<InducedSubTaskScheduleEntity> InducingTaskSchedules { get; set; } = new ObservableCollection<InducedSubTaskScheduleEntity>();

  [Dependent]
  public virtual ObservableCollection<InducedTreatmentTaskEntity> InducedTreatmentTasks { get; set; } = new ObservableCollection<InducedTreatmentTaskEntity>();

  [Principal]
  public virtual ResearchStudyEntity ResearchStudy { get; set; }

  [Dependent]
  public virtual TaskCycleDefinitionEntity CycleDefinition { get; set; }

  /// <summary> the TaskSchedule which is representing the primary-/entry-workflow (estimated tasks) when executing this visit </summary>
  [Referer]
  public virtual ObservableCollection<VisitProdecureDefinitionEntity> EntryVisitProdecureDefinitions { get; set; } = new ObservableCollection<VisitProdecureDefinitionEntity>();

#region Mapping

  internal static Expression<Func<TaskSchedule, TaskScheduleEntity>> TaskScheduleEntitySelector = ((TaskSchedule src) => new TaskScheduleEntity {
    TaskScheduleId = src.TaskScheduleId,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    Title = src.Title,
    MaxSkipsBeforeLost = src.MaxSkipsBeforeLost,
    MaxSubsequentSkipsBeforeLost = src.MaxSubsequentSkipsBeforeLost,
    MaxLostsBeforeLtfuAbort = src.MaxLostsBeforeLtfuAbort,
    MaxSubsequentLostsBeforeLtfuAbort = src.MaxSubsequentLostsBeforeLtfuAbort,
    EventOnLtfuAbort = src.EventOnLtfuAbort,
    EventOnCycleEnded = src.EventOnCycleEnded,
    EventOnAllCyclesEnded = src.EventOnAllCyclesEnded,
    InducingEvents = src.InducingEvents,
    AbortCausingEvents = src.AbortCausingEvents,
  });

  internal static Expression<Func<TaskScheduleEntity, TaskSchedule>> TaskScheduleSelector = ((TaskScheduleEntity src) => new TaskSchedule {
    TaskScheduleId = src.TaskScheduleId,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    Title = src.Title,
    MaxSkipsBeforeLost = src.MaxSkipsBeforeLost,
    MaxSubsequentSkipsBeforeLost = src.MaxSubsequentSkipsBeforeLost,
    MaxLostsBeforeLtfuAbort = src.MaxLostsBeforeLtfuAbort,
    MaxSubsequentLostsBeforeLtfuAbort = src.MaxSubsequentLostsBeforeLtfuAbort,
    EventOnLtfuAbort = src.EventOnLtfuAbort,
    EventOnCycleEnded = src.EventOnCycleEnded,
    EventOnAllCyclesEnded = src.EventOnAllCyclesEnded,
    InducingEvents = src.InducingEvents,
    AbortCausingEvents = src.AbortCausingEvents,
  });

  internal void CopyContentFrom(TaskSchedule source, Func<String,bool> onFixedValueChangingCallback = null){
    this.TaskScheduleId = source.TaskScheduleId;
    this.StudyWorkflowName = source.StudyWorkflowName;
    this.StudyWorkflowVersion = source.StudyWorkflowVersion;
    this.Title = source.Title;
    this.MaxSkipsBeforeLost = source.MaxSkipsBeforeLost;
    this.MaxSubsequentSkipsBeforeLost = source.MaxSubsequentSkipsBeforeLost;
    this.MaxLostsBeforeLtfuAbort = source.MaxLostsBeforeLtfuAbort;
    this.MaxSubsequentLostsBeforeLtfuAbort = source.MaxSubsequentLostsBeforeLtfuAbort;
    this.EventOnLtfuAbort = source.EventOnLtfuAbort;
    this.EventOnCycleEnded = source.EventOnCycleEnded;
    this.EventOnAllCyclesEnded = source.EventOnAllCyclesEnded;
    this.InducingEvents = source.InducingEvents;
    this.AbortCausingEvents = source.AbortCausingEvents;
  }

  internal void CopyContentTo(TaskSchedule target, Func<String,bool> onFixedValueChangingCallback = null){
    target.TaskScheduleId = this.TaskScheduleId;
    target.StudyWorkflowName = this.StudyWorkflowName;
    target.StudyWorkflowVersion = this.StudyWorkflowVersion;
    target.Title = this.Title;
    target.MaxSkipsBeforeLost = this.MaxSkipsBeforeLost;
    target.MaxSubsequentSkipsBeforeLost = this.MaxSubsequentSkipsBeforeLost;
    target.MaxLostsBeforeLtfuAbort = this.MaxLostsBeforeLtfuAbort;
    target.MaxSubsequentLostsBeforeLtfuAbort = this.MaxSubsequentLostsBeforeLtfuAbort;
    target.EventOnLtfuAbort = this.EventOnLtfuAbort;
    target.EventOnCycleEnded = this.EventOnCycleEnded;
    target.EventOnAllCyclesEnded = this.EventOnAllCyclesEnded;
    target.InducingEvents = this.InducingEvents;
    target.AbortCausingEvents = this.AbortCausingEvents;
  }

#endregion

}

public class InducedSubProcedureScheduleEntity {

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

  [Principal]
  public virtual ProcedureScheduleEntity ParentProcedureSchedule { get; set; }

  [Lookup]
  public virtual ProcedureScheduleEntity InducedProcedureSchedule { get; set; }

#region Mapping

  internal static Expression<Func<InducedSubProcedureSchedule, InducedSubProcedureScheduleEntity>> InducedSubProcedureScheduleEntitySelector = ((InducedSubProcedureSchedule src) => new InducedSubProcedureScheduleEntity {
    Id = src.Id,
    ParentProcedureScheduleId = src.ParentProcedureScheduleId,
    InducedProcedureScheduleId = src.InducedProcedureScheduleId,
    Offset = src.Offset,
    OffsetUnit = src.OffsetUnit,
    SchedulingVariabilityBefore = src.SchedulingVariabilityBefore,
    SchedulingVariabilityAfter = src.SchedulingVariabilityAfter,
    SchedulingVariabilityUnit = src.SchedulingVariabilityUnit,
    SharedSkipCounters = src.SharedSkipCounters,
    SharedLostCounters = src.SharedLostCounters,
  });

  internal static Expression<Func<InducedSubProcedureScheduleEntity, InducedSubProcedureSchedule>> InducedSubProcedureScheduleSelector = ((InducedSubProcedureScheduleEntity src) => new InducedSubProcedureSchedule {
    Id = src.Id,
    ParentProcedureScheduleId = src.ParentProcedureScheduleId,
    InducedProcedureScheduleId = src.InducedProcedureScheduleId,
    Offset = src.Offset,
    OffsetUnit = src.OffsetUnit,
    SchedulingVariabilityBefore = src.SchedulingVariabilityBefore,
    SchedulingVariabilityAfter = src.SchedulingVariabilityAfter,
    SchedulingVariabilityUnit = src.SchedulingVariabilityUnit,
    SharedSkipCounters = src.SharedSkipCounters,
    SharedLostCounters = src.SharedLostCounters,
  });

  internal void CopyContentFrom(InducedSubProcedureSchedule source, Func<String,bool> onFixedValueChangingCallback = null){
    this.Id = source.Id;
    this.ParentProcedureScheduleId = source.ParentProcedureScheduleId;
    this.InducedProcedureScheduleId = source.InducedProcedureScheduleId;
    this.Offset = source.Offset;
    this.OffsetUnit = source.OffsetUnit;
    this.SchedulingVariabilityBefore = source.SchedulingVariabilityBefore;
    this.SchedulingVariabilityAfter = source.SchedulingVariabilityAfter;
    this.SchedulingVariabilityUnit = source.SchedulingVariabilityUnit;
    this.SharedSkipCounters = source.SharedSkipCounters;
    this.SharedLostCounters = source.SharedLostCounters;
  }

  internal void CopyContentTo(InducedSubProcedureSchedule target, Func<String,bool> onFixedValueChangingCallback = null){
    target.Id = this.Id;
    target.ParentProcedureScheduleId = this.ParentProcedureScheduleId;
    target.InducedProcedureScheduleId = this.InducedProcedureScheduleId;
    target.Offset = this.Offset;
    target.OffsetUnit = this.OffsetUnit;
    target.SchedulingVariabilityBefore = this.SchedulingVariabilityBefore;
    target.SchedulingVariabilityAfter = this.SchedulingVariabilityAfter;
    target.SchedulingVariabilityUnit = this.SchedulingVariabilityUnit;
    target.SharedSkipCounters = this.SharedSkipCounters;
    target.SharedLostCounters = this.SharedLostCounters;
  }

#endregion

}

public class InducedSubTaskScheduleEntity {

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

  [Principal]
  public virtual TaskScheduleEntity ParentTaskSchedule { get; set; }

  [Lookup]
  public virtual TaskScheduleEntity InducedTaskSchedule { get; set; }

#region Mapping

  internal static Expression<Func<InducedSubTaskSchedule, InducedSubTaskScheduleEntity>> InducedSubTaskScheduleEntitySelector = ((InducedSubTaskSchedule src) => new InducedSubTaskScheduleEntity {
    Id = src.Id,
    ParentTaskScheduleId = src.ParentTaskScheduleId,
    InducedTaskScheduleId = src.InducedTaskScheduleId,
    Offset = src.Offset,
    OffsetUnit = src.OffsetUnit,
    SchedulingVariabilityBefore = src.SchedulingVariabilityBefore,
    SchedulingVariabilityAfter = src.SchedulingVariabilityAfter,
    SchedulingVariabilityUnit = src.SchedulingVariabilityUnit,
    SharedSkipCounters = src.SharedSkipCounters,
    SharedLostCounters = src.SharedLostCounters,
  });

  internal static Expression<Func<InducedSubTaskScheduleEntity, InducedSubTaskSchedule>> InducedSubTaskScheduleSelector = ((InducedSubTaskScheduleEntity src) => new InducedSubTaskSchedule {
    Id = src.Id,
    ParentTaskScheduleId = src.ParentTaskScheduleId,
    InducedTaskScheduleId = src.InducedTaskScheduleId,
    Offset = src.Offset,
    OffsetUnit = src.OffsetUnit,
    SchedulingVariabilityBefore = src.SchedulingVariabilityBefore,
    SchedulingVariabilityAfter = src.SchedulingVariabilityAfter,
    SchedulingVariabilityUnit = src.SchedulingVariabilityUnit,
    SharedSkipCounters = src.SharedSkipCounters,
    SharedLostCounters = src.SharedLostCounters,
  });

  internal void CopyContentFrom(InducedSubTaskSchedule source, Func<String,bool> onFixedValueChangingCallback = null){
    this.Id = source.Id;
    this.ParentTaskScheduleId = source.ParentTaskScheduleId;
    this.InducedTaskScheduleId = source.InducedTaskScheduleId;
    this.Offset = source.Offset;
    this.OffsetUnit = source.OffsetUnit;
    this.SchedulingVariabilityBefore = source.SchedulingVariabilityBefore;
    this.SchedulingVariabilityAfter = source.SchedulingVariabilityAfter;
    this.SchedulingVariabilityUnit = source.SchedulingVariabilityUnit;
    this.SharedSkipCounters = source.SharedSkipCounters;
    this.SharedLostCounters = source.SharedLostCounters;
  }

  internal void CopyContentTo(InducedSubTaskSchedule target, Func<String,bool> onFixedValueChangingCallback = null){
    target.Id = this.Id;
    target.ParentTaskScheduleId = this.ParentTaskScheduleId;
    target.InducedTaskScheduleId = this.InducedTaskScheduleId;
    target.Offset = this.Offset;
    target.OffsetUnit = this.OffsetUnit;
    target.SchedulingVariabilityBefore = this.SchedulingVariabilityBefore;
    target.SchedulingVariabilityAfter = this.SchedulingVariabilityAfter;
    target.SchedulingVariabilityUnit = this.SchedulingVariabilityUnit;
    target.SharedSkipCounters = this.SharedSkipCounters;
    target.SharedLostCounters = this.SharedLostCounters;
  }

#endregion

}

public class InducedTreatmentTaskEntity {

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

  [Principal]
  public virtual TaskScheduleEntity TaskSchedule { get; set; }

  [Lookup]
  public virtual TreatmentTaskEntity InducedTask { get; set; }

#region Mapping

  internal static Expression<Func<InducedTreatmentTask, InducedTreatmentTaskEntity>> InducedTreatmentTaskEntitySelector = ((InducedTreatmentTask src) => new InducedTreatmentTaskEntity {
    Id = src.Id,
    TaskScheduleId = src.TaskScheduleId,
    InducedTreatmentName = src.InducedTreatmentName,
    Offset = src.Offset,
    OffsetUnit = src.OffsetUnit,
    SchedulingVariabilityBefore = src.SchedulingVariabilityBefore,
    SchedulingVariabilityAfter = src.SchedulingVariabilityAfter,
    SchedulingVariabilityUnit = src.SchedulingVariabilityUnit,
    InducedTaskExecutionTitle = src.InducedTaskExecutionTitle,
    Skipable = src.Skipable,
    EventOnSkip = src.EventOnSkip,
    EventOnLost = src.EventOnLost,
  });

  internal static Expression<Func<InducedTreatmentTaskEntity, InducedTreatmentTask>> InducedTreatmentTaskSelector = ((InducedTreatmentTaskEntity src) => new InducedTreatmentTask {
    Id = src.Id,
    TaskScheduleId = src.TaskScheduleId,
    InducedTreatmentName = src.InducedTreatmentName,
    Offset = src.Offset,
    OffsetUnit = src.OffsetUnit,
    SchedulingVariabilityBefore = src.SchedulingVariabilityBefore,
    SchedulingVariabilityAfter = src.SchedulingVariabilityAfter,
    SchedulingVariabilityUnit = src.SchedulingVariabilityUnit,
    InducedTaskExecutionTitle = src.InducedTaskExecutionTitle,
    Skipable = src.Skipable,
    EventOnSkip = src.EventOnSkip,
    EventOnLost = src.EventOnLost,
  });

  internal void CopyContentFrom(InducedTreatmentTask source, Func<String,bool> onFixedValueChangingCallback = null){
    this.Id = source.Id;
    this.TaskScheduleId = source.TaskScheduleId;
    this.InducedTreatmentName = source.InducedTreatmentName;
    this.Offset = source.Offset;
    this.OffsetUnit = source.OffsetUnit;
    this.SchedulingVariabilityBefore = source.SchedulingVariabilityBefore;
    this.SchedulingVariabilityAfter = source.SchedulingVariabilityAfter;
    this.SchedulingVariabilityUnit = source.SchedulingVariabilityUnit;
    this.InducedTaskExecutionTitle = source.InducedTaskExecutionTitle;
    this.Skipable = source.Skipable;
    this.EventOnSkip = source.EventOnSkip;
    this.EventOnLost = source.EventOnLost;
  }

  internal void CopyContentTo(InducedTreatmentTask target, Func<String,bool> onFixedValueChangingCallback = null){
    target.Id = this.Id;
    target.TaskScheduleId = this.TaskScheduleId;
    target.InducedTreatmentName = this.InducedTreatmentName;
    target.Offset = this.Offset;
    target.OffsetUnit = this.OffsetUnit;
    target.SchedulingVariabilityBefore = this.SchedulingVariabilityBefore;
    target.SchedulingVariabilityAfter = this.SchedulingVariabilityAfter;
    target.SchedulingVariabilityUnit = this.SchedulingVariabilityUnit;
    target.InducedTaskExecutionTitle = this.InducedTaskExecutionTitle;
    target.Skipable = this.Skipable;
    target.EventOnSkip = this.EventOnSkip;
    target.EventOnLost = this.EventOnLost;
  }

#endregion

}

public class TreatmentTaskEntity {

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

  [Referer]
  public virtual ObservableCollection<InducedTreatmentTaskEntity> Inducements { get; set; } = new ObservableCollection<InducedTreatmentTaskEntity>();

  [Principal]
  public virtual ResearchStudyEntity ResearchStudy { get; set; }

#region Mapping

  internal static Expression<Func<TreatmentTask, TreatmentTaskEntity>> TreatmentTaskEntitySelector = ((TreatmentTask src) => new TreatmentTaskEntity {
    TreatmentName = src.TreatmentName,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    BillablePriceOnCompletedExecution = src.BillablePriceOnCompletedExecution,
    ShortDescription = src.ShortDescription,
    TaskSpecificDocumentationUrl = src.TaskSpecificDocumentationUrl,
    TreatmentDescription = src.TreatmentDescription,
    ImportantNotices = src.ImportantNotices,
  });

  internal static Expression<Func<TreatmentTaskEntity, TreatmentTask>> TreatmentTaskSelector = ((TreatmentTaskEntity src) => new TreatmentTask {
    TreatmentName = src.TreatmentName,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    BillablePriceOnCompletedExecution = src.BillablePriceOnCompletedExecution,
    ShortDescription = src.ShortDescription,
    TaskSpecificDocumentationUrl = src.TaskSpecificDocumentationUrl,
    TreatmentDescription = src.TreatmentDescription,
    ImportantNotices = src.ImportantNotices,
  });

  internal void CopyContentFrom(TreatmentTask source, Func<String,bool> onFixedValueChangingCallback = null){
    this.TreatmentName = source.TreatmentName;
    this.StudyWorkflowName = source.StudyWorkflowName;
    this.StudyWorkflowVersion = source.StudyWorkflowVersion;
    this.BillablePriceOnCompletedExecution = source.BillablePriceOnCompletedExecution;
    this.ShortDescription = source.ShortDescription;
    this.TaskSpecificDocumentationUrl = source.TaskSpecificDocumentationUrl;
    this.TreatmentDescription = source.TreatmentDescription;
    this.ImportantNotices = source.ImportantNotices;
  }

  internal void CopyContentTo(TreatmentTask target, Func<String,bool> onFixedValueChangingCallback = null){
    target.TreatmentName = this.TreatmentName;
    target.StudyWorkflowName = this.StudyWorkflowName;
    target.StudyWorkflowVersion = this.StudyWorkflowVersion;
    target.BillablePriceOnCompletedExecution = this.BillablePriceOnCompletedExecution;
    target.ShortDescription = this.ShortDescription;
    target.TaskSpecificDocumentationUrl = this.TaskSpecificDocumentationUrl;
    target.TreatmentDescription = this.TreatmentDescription;
    target.ImportantNotices = this.ImportantNotices;
  }

#endregion

}

public class InducedVisitProcedureEntity {

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

  [Principal]
  public virtual ProcedureScheduleEntity ProcedureSchedule { get; set; }

  [Lookup]
  public virtual VisitProdecureDefinitionEntity InducedVisitProdecure { get; set; }

#region Mapping

  internal static Expression<Func<InducedVisitProcedure, InducedVisitProcedureEntity>> InducedVisitProcedureEntitySelector = ((InducedVisitProcedure src) => new InducedVisitProcedureEntity {
    Id = src.Id,
    ProcedureScheduleId = src.ProcedureScheduleId,
    Offset = src.Offset,
    OffsetUnit = src.OffsetUnit,
    SchedulingVariabilityBefore = src.SchedulingVariabilityBefore,
    SchedulingVariabilityAfter = src.SchedulingVariabilityAfter,
    SchedulingVariabilityUnit = src.SchedulingVariabilityUnit,
    InducedVisitProdecureName = src.InducedVisitProdecureName,
    InducedVisitExecutionTitle = src.InducedVisitExecutionTitle,
    Skipable = src.Skipable,
    EventOnSkip = src.EventOnSkip,
    EventOnLost = src.EventOnLost,
  });

  internal static Expression<Func<InducedVisitProcedureEntity, InducedVisitProcedure>> InducedVisitProcedureSelector = ((InducedVisitProcedureEntity src) => new InducedVisitProcedure {
    Id = src.Id,
    ProcedureScheduleId = src.ProcedureScheduleId,
    Offset = src.Offset,
    OffsetUnit = src.OffsetUnit,
    SchedulingVariabilityBefore = src.SchedulingVariabilityBefore,
    SchedulingVariabilityAfter = src.SchedulingVariabilityAfter,
    SchedulingVariabilityUnit = src.SchedulingVariabilityUnit,
    InducedVisitProdecureName = src.InducedVisitProdecureName,
    InducedVisitExecutionTitle = src.InducedVisitExecutionTitle,
    Skipable = src.Skipable,
    EventOnSkip = src.EventOnSkip,
    EventOnLost = src.EventOnLost,
  });

  internal void CopyContentFrom(InducedVisitProcedure source, Func<String,bool> onFixedValueChangingCallback = null){
    this.Id = source.Id;
    this.ProcedureScheduleId = source.ProcedureScheduleId;
    this.Offset = source.Offset;
    this.OffsetUnit = source.OffsetUnit;
    this.SchedulingVariabilityBefore = source.SchedulingVariabilityBefore;
    this.SchedulingVariabilityAfter = source.SchedulingVariabilityAfter;
    this.SchedulingVariabilityUnit = source.SchedulingVariabilityUnit;
    this.InducedVisitProdecureName = source.InducedVisitProdecureName;
    this.InducedVisitExecutionTitle = source.InducedVisitExecutionTitle;
    this.Skipable = source.Skipable;
    this.EventOnSkip = source.EventOnSkip;
    this.EventOnLost = source.EventOnLost;
  }

  internal void CopyContentTo(InducedVisitProcedure target, Func<String,bool> onFixedValueChangingCallback = null){
    target.Id = this.Id;
    target.ProcedureScheduleId = this.ProcedureScheduleId;
    target.Offset = this.Offset;
    target.OffsetUnit = this.OffsetUnit;
    target.SchedulingVariabilityBefore = this.SchedulingVariabilityBefore;
    target.SchedulingVariabilityAfter = this.SchedulingVariabilityAfter;
    target.SchedulingVariabilityUnit = this.SchedulingVariabilityUnit;
    target.InducedVisitProdecureName = this.InducedVisitProdecureName;
    target.InducedVisitExecutionTitle = this.InducedVisitExecutionTitle;
    target.Skipable = this.Skipable;
    target.EventOnSkip = this.EventOnSkip;
    target.EventOnLost = this.EventOnLost;
  }

#endregion

}

public class VisitProdecureDefinitionEntity {

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

  [Referer]
  public virtual ObservableCollection<InducedVisitProcedureEntity> Inducements { get; set; } = new ObservableCollection<InducedVisitProcedureEntity>();

  [Principal]
  public virtual ResearchStudyEntity ResearchStudy { get; set; }

  /// <summary> the TaskSchedule which is representing the primary-/entry-workflow (estimated tasks) when executing this visit </summary>
  [Lookup]
  public virtual TaskScheduleEntity RootTaskSchedule { get; set; }

#region Mapping

  internal static Expression<Func<VisitProdecureDefinition, VisitProdecureDefinitionEntity>> VisitProdecureDefinitionEntitySelector = ((VisitProdecureDefinition src) => new VisitProdecureDefinitionEntity {
    VisitProdecureName = src.VisitProdecureName,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    RootTaskScheduleId = src.RootTaskScheduleId,
    BillablePriceOnAbortedExecution = src.BillablePriceOnAbortedExecution,
    BillablePriceOnCompletedExecution = src.BillablePriceOnCompletedExecution,
    VisitSpecificDocumentationUrl = src.VisitSpecificDocumentationUrl,
  });

  internal static Expression<Func<VisitProdecureDefinitionEntity, VisitProdecureDefinition>> VisitProdecureDefinitionSelector = ((VisitProdecureDefinitionEntity src) => new VisitProdecureDefinition {
    VisitProdecureName = src.VisitProdecureName,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    RootTaskScheduleId = src.RootTaskScheduleId,
    BillablePriceOnAbortedExecution = src.BillablePriceOnAbortedExecution,
    BillablePriceOnCompletedExecution = src.BillablePriceOnCompletedExecution,
    VisitSpecificDocumentationUrl = src.VisitSpecificDocumentationUrl,
  });

  internal void CopyContentFrom(VisitProdecureDefinition source, Func<String,bool> onFixedValueChangingCallback = null){
    this.VisitProdecureName = source.VisitProdecureName;
    this.StudyWorkflowName = source.StudyWorkflowName;
    this.StudyWorkflowVersion = source.StudyWorkflowVersion;
    this.RootTaskScheduleId = source.RootTaskScheduleId;
    this.BillablePriceOnAbortedExecution = source.BillablePriceOnAbortedExecution;
    this.BillablePriceOnCompletedExecution = source.BillablePriceOnCompletedExecution;
    this.VisitSpecificDocumentationUrl = source.VisitSpecificDocumentationUrl;
  }

  internal void CopyContentTo(VisitProdecureDefinition target, Func<String,bool> onFixedValueChangingCallback = null){
    target.VisitProdecureName = this.VisitProdecureName;
    target.StudyWorkflowName = this.StudyWorkflowName;
    target.StudyWorkflowVersion = this.StudyWorkflowVersion;
    target.RootTaskScheduleId = this.RootTaskScheduleId;
    target.BillablePriceOnAbortedExecution = this.BillablePriceOnAbortedExecution;
    target.BillablePriceOnCompletedExecution = this.BillablePriceOnCompletedExecution;
    target.VisitSpecificDocumentationUrl = this.VisitSpecificDocumentationUrl;
  }

#endregion

}

public class ProcedureCycleDefinitionEntity {

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

  [Principal]
  public virtual ProcedureScheduleEntity ProcedureSchedule { get; set; }

#region Mapping

  internal static Expression<Func<ProcedureCycleDefinition, ProcedureCycleDefinitionEntity>> ProcedureCycleDefinitionEntitySelector = ((ProcedureCycleDefinition src) => new ProcedureCycleDefinitionEntity {
    ProcedureScheduleId = src.ProcedureScheduleId,
    ReschedulingBase = src.ReschedulingBase,
    ReschedulingOffset = src.ReschedulingOffset,
    ReschedulingOffsetUnit = src.ReschedulingOffsetUnit,
    CycleLimit = src.CycleLimit,
    SharedSkipCounters = src.SharedSkipCounters,
    SharedLostCounters = src.SharedLostCounters,
  });

  internal static Expression<Func<ProcedureCycleDefinitionEntity, ProcedureCycleDefinition>> ProcedureCycleDefinitionSelector = ((ProcedureCycleDefinitionEntity src) => new ProcedureCycleDefinition {
    ProcedureScheduleId = src.ProcedureScheduleId,
    ReschedulingBase = src.ReschedulingBase,
    ReschedulingOffset = src.ReschedulingOffset,
    ReschedulingOffsetUnit = src.ReschedulingOffsetUnit,
    CycleLimit = src.CycleLimit,
    SharedSkipCounters = src.SharedSkipCounters,
    SharedLostCounters = src.SharedLostCounters,
  });

  internal void CopyContentFrom(ProcedureCycleDefinition source, Func<String,bool> onFixedValueChangingCallback = null){
    this.ProcedureScheduleId = source.ProcedureScheduleId;
    this.ReschedulingBase = source.ReschedulingBase;
    this.ReschedulingOffset = source.ReschedulingOffset;
    this.ReschedulingOffsetUnit = source.ReschedulingOffsetUnit;
    this.CycleLimit = source.CycleLimit;
    this.SharedSkipCounters = source.SharedSkipCounters;
    this.SharedLostCounters = source.SharedLostCounters;
  }

  internal void CopyContentTo(ProcedureCycleDefinition target, Func<String,bool> onFixedValueChangingCallback = null){
    target.ProcedureScheduleId = this.ProcedureScheduleId;
    target.ReschedulingBase = this.ReschedulingBase;
    target.ReschedulingOffset = this.ReschedulingOffset;
    target.ReschedulingOffsetUnit = this.ReschedulingOffsetUnit;
    target.CycleLimit = this.CycleLimit;
    target.SharedSkipCounters = this.SharedSkipCounters;
    target.SharedLostCounters = this.SharedLostCounters;
  }

#endregion

}

public class StudyEventEntity {

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

  [Principal]
  public virtual ResearchStudyEntity ResearchStudy { get; set; }

#region Mapping

  internal static Expression<Func<StudyEvent, StudyEventEntity>> StudyEventEntitySelector = ((StudyEvent src) => new StudyEventEntity {
    StudyEventName = src.StudyEventName,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    MaxOccourrencesBeforeExclusion = src.MaxOccourrencesBeforeExclusion,
    AllowManualTrigger = src.AllowManualTrigger,
    Description = src.Description,
    EvenSpecificDocumentationUrl = src.EvenSpecificDocumentationUrl,
  });

  internal static Expression<Func<StudyEventEntity, StudyEvent>> StudyEventSelector = ((StudyEventEntity src) => new StudyEvent {
    StudyEventName = src.StudyEventName,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    MaxOccourrencesBeforeExclusion = src.MaxOccourrencesBeforeExclusion,
    AllowManualTrigger = src.AllowManualTrigger,
    Description = src.Description,
    EvenSpecificDocumentationUrl = src.EvenSpecificDocumentationUrl,
  });

  internal void CopyContentFrom(StudyEvent source, Func<String,bool> onFixedValueChangingCallback = null){
    this.StudyEventName = source.StudyEventName;
    this.StudyWorkflowName = source.StudyWorkflowName;
    this.StudyWorkflowVersion = source.StudyWorkflowVersion;
    this.MaxOccourrencesBeforeExclusion = source.MaxOccourrencesBeforeExclusion;
    this.AllowManualTrigger = source.AllowManualTrigger;
    this.Description = source.Description;
    this.EvenSpecificDocumentationUrl = source.EvenSpecificDocumentationUrl;
  }

  internal void CopyContentTo(StudyEvent target, Func<String,bool> onFixedValueChangingCallback = null){
    target.StudyEventName = this.StudyEventName;
    target.StudyWorkflowName = this.StudyWorkflowName;
    target.StudyWorkflowVersion = this.StudyWorkflowVersion;
    target.MaxOccourrencesBeforeExclusion = this.MaxOccourrencesBeforeExclusion;
    target.AllowManualTrigger = this.AllowManualTrigger;
    target.Description = this.Description;
    target.EvenSpecificDocumentationUrl = this.EvenSpecificDocumentationUrl;
  }

#endregion

}

public class TaskCycleDefinitionEntity {

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

  [Principal]
  public virtual TaskScheduleEntity TaskSchedule { get; set; }

#region Mapping

  internal static Expression<Func<TaskCycleDefinition, TaskCycleDefinitionEntity>> TaskCycleDefinitionEntitySelector = ((TaskCycleDefinition src) => new TaskCycleDefinitionEntity {
    TaskScheduleId = src.TaskScheduleId,
    ReschedulingBase = src.ReschedulingBase,
    ReschedulingOffset = src.ReschedulingOffset,
    ReschedulingOffsetUnit = src.ReschedulingOffsetUnit,
    CycleLimit = src.CycleLimit,
    SharedSkipCounters = src.SharedSkipCounters,
    SharedLostCounters = src.SharedLostCounters,
  });

  internal static Expression<Func<TaskCycleDefinitionEntity, TaskCycleDefinition>> TaskCycleDefinitionSelector = ((TaskCycleDefinitionEntity src) => new TaskCycleDefinition {
    TaskScheduleId = src.TaskScheduleId,
    ReschedulingBase = src.ReschedulingBase,
    ReschedulingOffset = src.ReschedulingOffset,
    ReschedulingOffsetUnit = src.ReschedulingOffsetUnit,
    CycleLimit = src.CycleLimit,
    SharedSkipCounters = src.SharedSkipCounters,
    SharedLostCounters = src.SharedLostCounters,
  });

  internal void CopyContentFrom(TaskCycleDefinition source, Func<String,bool> onFixedValueChangingCallback = null){
    this.TaskScheduleId = source.TaskScheduleId;
    this.ReschedulingBase = source.ReschedulingBase;
    this.ReschedulingOffset = source.ReschedulingOffset;
    this.ReschedulingOffsetUnit = source.ReschedulingOffsetUnit;
    this.CycleLimit = source.CycleLimit;
    this.SharedSkipCounters = source.SharedSkipCounters;
    this.SharedLostCounters = source.SharedLostCounters;
  }

  internal void CopyContentTo(TaskCycleDefinition target, Func<String,bool> onFixedValueChangingCallback = null){
    target.TaskScheduleId = this.TaskScheduleId;
    target.ReschedulingBase = this.ReschedulingBase;
    target.ReschedulingOffset = this.ReschedulingOffset;
    target.ReschedulingOffsetUnit = this.ReschedulingOffsetUnit;
    target.CycleLimit = this.CycleLimit;
    target.SharedSkipCounters = this.SharedSkipCounters;
    target.SharedLostCounters = this.SharedLostCounters;
  }

#endregion

}

}
