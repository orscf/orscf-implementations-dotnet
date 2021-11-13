using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using MedicalResearch.Workflow;
using MedicalResearch.Workflow.Persistence;
using MedicalResearch.Workflow.Model;
using MedicalResearch.Workflow.StoreAccess;

namespace MedicalResearch.Workflow.Persistence {

public class ArmEntity {

  /// <summary> Name of the Arm - INVARIANT! because it is used to generate Identifers for induced executions! *this field has a max length of 50 </summary>
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

  /// <summary> comma sparated list of Sub-Study names which are allowed to be executed for this arm
  ///  *this field is optional (use null as value) </summary>
  public String AllowedSubstudies { get; set; }

  [Principal]
  public virtual ResearchStudyDefinitionEntity ResearchStudy { get; set; }

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
    AllowedSubstudies = src.AllowedSubstudies,
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
    AllowedSubstudies = src.AllowedSubstudies,
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
    this.AllowedSubstudies = source.AllowedSubstudies;
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
    target.AllowedSubstudies = this.AllowedSubstudies;
  }

#endregion

}

public class ResearchStudyDefinitionEntity {

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

  /// <summary> Logo in base64 *this field is optional (use null as value) </summary>
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
  public virtual ObservableCollection<DataRecordingTaskDefinitionEntity> DataRecordingTasks { get; set; } = new ObservableCollection<DataRecordingTaskDefinitionEntity>();

  [Dependent]
  public virtual ObservableCollection<DrugApplymentTaskDefinitionEntity> DrugApplymentTasks { get; set; } = new ObservableCollection<DrugApplymentTaskDefinitionEntity>();

  [Dependent]
  public virtual ObservableCollection<ProcedureDefinitionEntity> ProcedureDefinitions { get; set; } = new ObservableCollection<ProcedureDefinitionEntity>();

  [Dependent]
  public virtual ObservableCollection<ProcedureScheduleEntity> ProcedureSchedules { get; set; } = new ObservableCollection<ProcedureScheduleEntity>();

  [Dependent]
  public virtual ObservableCollection<TreatmentTaskDefinitionEntity> TreatmentTasks { get; set; } = new ObservableCollection<TreatmentTaskDefinitionEntity>();

  [Dependent]
  public virtual ObservableCollection<TaskScheduleEntity> TaskSchedules { get; set; } = new ObservableCollection<TaskScheduleEntity>();

  [Dependent]
  public virtual ObservableCollection<StudyEventEntity> Events { get; set; } = new ObservableCollection<StudyEventEntity>();

  [Dependent]
  public virtual ObservableCollection<SubStudyEntity> SubStudies { get; set; } = new ObservableCollection<SubStudyEntity>();

#region Mapping

  internal static Expression<Func<ResearchStudyDefinition, ResearchStudyDefinitionEntity>> ResearchStudyDefinitionEntitySelector = ((ResearchStudyDefinition src) => new ResearchStudyDefinitionEntity {
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

  internal static Expression<Func<ResearchStudyDefinitionEntity, ResearchStudyDefinition>> ResearchStudyDefinitionSelector = ((ResearchStudyDefinitionEntity src) => new ResearchStudyDefinition {
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

  internal void CopyContentFrom(ResearchStudyDefinition source, Func<String,bool> onFixedValueChangingCallback = null){
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

  internal void CopyContentTo(ResearchStudyDefinition target, Func<String,bool> onFixedValueChangingCallback = null){
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

  /// <summary> Name of the Workflow which is represented by this schedule - INVARIANT! because it is used to generate Identifers for induced executions! </summary>
  [Required]
  public String ScheduleWorkflowName { get; set; }

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
  public virtual ObservableCollection<InducedProcedureEntity> InducedProcedures { get; set; } = new ObservableCollection<InducedProcedureEntity>();

  [Dependent]
  public virtual ObservableCollection<InducedSubProcedureScheduleEntity> InducedSubProcedureSchedules { get; set; } = new ObservableCollection<InducedSubProcedureScheduleEntity>();

  [Referer]
  public virtual ObservableCollection<InducedSubProcedureScheduleEntity> InducingSubProcedureSchedules { get; set; } = new ObservableCollection<InducedSubProcedureScheduleEntity>();

  [Dependent]
  public virtual ProcedureCycleDefinitionEntity CycleDefinition { get; set; }

  [Principal]
  public virtual ResearchStudyDefinitionEntity ResearchStudy { get; set; }

#region Mapping

  internal static Expression<Func<ProcedureSchedule, ProcedureScheduleEntity>> ProcedureScheduleEntitySelector = ((ProcedureSchedule src) => new ProcedureScheduleEntity {
    ProcedureScheduleId = src.ProcedureScheduleId,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    ScheduleWorkflowName = src.ScheduleWorkflowName,
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
    ScheduleWorkflowName = src.ScheduleWorkflowName,
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
    this.ScheduleWorkflowName = source.ScheduleWorkflowName;
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
    target.ScheduleWorkflowName = this.ScheduleWorkflowName;
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

public class DataRecordingTaskDefinitionEntity {

  /// <summary> Name of the Definition - INVARIANT! because it is used to generate Identifers for induced executions! *this field has a max length of 50 </summary>
  [MaxLength(50), Required]
  public String TaskDefinitionName { get; set; }

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
  public virtual ResearchStudyDefinitionEntity ResearchStudy { get; set; }

#region Mapping

  internal static Expression<Func<DataRecordingTaskDefinition, DataRecordingTaskDefinitionEntity>> DataRecordingTaskDefinitionEntitySelector = ((DataRecordingTaskDefinition src) => new DataRecordingTaskDefinitionEntity {
    TaskDefinitionName = src.TaskDefinitionName,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    BillablePriceOnCompletedExecution = src.BillablePriceOnCompletedExecution,
    ShortDescription = src.ShortDescription,
    TaskSpecificDocumentationUrl = src.TaskSpecificDocumentationUrl,
    ImportantNotices = src.ImportantNotices,
    DataSchemaUrl = src.DataSchemaUrl,
    DefaultData = src.DefaultData,
  });

  internal static Expression<Func<DataRecordingTaskDefinitionEntity, DataRecordingTaskDefinition>> DataRecordingTaskDefinitionSelector = ((DataRecordingTaskDefinitionEntity src) => new DataRecordingTaskDefinition {
    TaskDefinitionName = src.TaskDefinitionName,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    BillablePriceOnCompletedExecution = src.BillablePriceOnCompletedExecution,
    ShortDescription = src.ShortDescription,
    TaskSpecificDocumentationUrl = src.TaskSpecificDocumentationUrl,
    ImportantNotices = src.ImportantNotices,
    DataSchemaUrl = src.DataSchemaUrl,
    DefaultData = src.DefaultData,
  });

  internal void CopyContentFrom(DataRecordingTaskDefinition source, Func<String,bool> onFixedValueChangingCallback = null){
    this.TaskDefinitionName = source.TaskDefinitionName;
    this.StudyWorkflowName = source.StudyWorkflowName;
    this.StudyWorkflowVersion = source.StudyWorkflowVersion;
    this.BillablePriceOnCompletedExecution = source.BillablePriceOnCompletedExecution;
    this.ShortDescription = source.ShortDescription;
    this.TaskSpecificDocumentationUrl = source.TaskSpecificDocumentationUrl;
    this.ImportantNotices = source.ImportantNotices;
    this.DataSchemaUrl = source.DataSchemaUrl;
    this.DefaultData = source.DefaultData;
  }

  internal void CopyContentTo(DataRecordingTaskDefinition target, Func<String,bool> onFixedValueChangingCallback = null){
    target.TaskDefinitionName = this.TaskDefinitionName;
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
  public String TaskDefinitionName { get; set; }

  /// <summary> estimated scheduling time relative to the scheduling date of the parent TaskSchedule </summary>
  [Required]
  public Int32 SchedulingOffset { get; set; }

  /// <summary> 'h'=Hours / 'm'=Minutes / 's'=Seconds </summary>
  [Required]
  public String SchedulingOffsetUnit { get; set; }

  /// <summary> defines an additional variability RELATIVE to the estimated scheduling time (which is calculated from the offset), in this case the EARLIEST possible time. </summary>
  [Required]
  public String SchedulingVariabilityBefore { get; set; }

  /// <summary> defines an additional variability RELATIVE to the estimated scheduling time (which is calculated from the offset), in this case the LATEST possible time. </summary>
  [Required]
  public String SchedulingVariabilityAfter { get; set; }

  /// <summary> 'h'=Hours / 'm'=Minutes / 's'=Seconds </summary>
  [Required]
  public String SchedulingVariabilityUnit { get; set; }

  /// <summary> the name for the induced execution, like 'Measurement X', which is usually defined by the study protocol. if multiple inducements are possible (for example when using cycles), the title should to contain a placeholder (example: '{vt} - Measurement X') to prevent from duplicate execution names. </summary>
  [Required]
  public String UniqueExecutionName { get; set; }

  /// <summary> defines, if the study protocol tolerates this execution to be 'skipped' (if not, a missed execution is treated as 'lost' and can cause the exclusion of the participant) </summary>
  [Required]
  public Boolean Skipable { get; set; }

  [Required]
  public String EventOnSkip { get; set; }

  [Required]
  public String EventOnLost { get; set; }

  /// <summary> The Position (1..x) of this inducement within the parent schedule. This value is relevant for addressing predecessors as fixpoint for the offest-calculation. Within one schedule there can only be one inducement for each position! The 0 is reserved for addressing the parent schedule itself and must not be used as well as negative values! </summary>
  [Required]
  public Int32 Position { get; set; }

  /// <summary> 0=InducementOfScheduleOrCycle: when the start of the parent Schedule (for the current cycle) was induced / -1=InducementOfPredessessor: when the direct predecessor task or subschedule (based on the 'Position') within the current schedule was induced / 1..x: when the predecessor at the Position within the current schedule, ADRESSED by the given value, was induced 
  /// *items of sub-schedules are not relevant - when addressing a sub-schedule as predecessor, then only its entry will be used
  /// *this behaviour can be concretized via 'SchedulingByEstimate' </summary>
  [Required]
  public Int32 SchedulingOffsetFixpoint { get; set; }

  /// <summary> If set to true, the offset calculation will be based on the ESTIMATED completion of the predecessor (see 'Fixpoint'). Otherwise, when set to false, the offset calculation will be based on the REAL completion (if recorded execution data is available during calculation) of the predecessor. *this will not evaluated, when the 'Fixpoint' is set to 0! </summary>
  [Required]
  public Boolean SchedulingByEstimate { get; set; }

  /// <summary> The name of a Sub-Study for which this Task should be induced or empty when its part of the current Arms regular workflow *this field is optional (use null as value) </summary>
  public String DedicatedToSubstudy { get; set; }

  /// <summary> Number, which can be used via Placeholder {#} within the UniqueExecutionName and which will automatically increase when using cycles or sub-schedules </summary>
  [Required]
  public Int32 TaskNumber { get; set; }

  [Lookup]
  public virtual DataRecordingTaskDefinitionEntity InducedTask { get; set; }

  [Principal]
  public virtual TaskScheduleEntity TaskSchedule { get; set; }

#region Mapping

  internal static Expression<Func<InducedDataRecordingTask, InducedDataRecordingTaskEntity>> InducedDataRecordingTaskEntitySelector = ((InducedDataRecordingTask src) => new InducedDataRecordingTaskEntity {
    Id = src.Id,
    TaskScheduleId = src.TaskScheduleId,
    TaskDefinitionName = src.TaskDefinitionName,
    SchedulingOffset = src.SchedulingOffset,
    SchedulingOffsetUnit = src.SchedulingOffsetUnit,
    SchedulingVariabilityBefore = src.SchedulingVariabilityBefore,
    SchedulingVariabilityAfter = src.SchedulingVariabilityAfter,
    SchedulingVariabilityUnit = src.SchedulingVariabilityUnit,
    UniqueExecutionName = src.UniqueExecutionName,
    Skipable = src.Skipable,
    EventOnSkip = src.EventOnSkip,
    EventOnLost = src.EventOnLost,
    Position = src.Position,
    SchedulingOffsetFixpoint = src.SchedulingOffsetFixpoint,
    SchedulingByEstimate = src.SchedulingByEstimate,
    DedicatedToSubstudy = src.DedicatedToSubstudy,
    TaskNumber = src.TaskNumber,
  });

  internal static Expression<Func<InducedDataRecordingTaskEntity, InducedDataRecordingTask>> InducedDataRecordingTaskSelector = ((InducedDataRecordingTaskEntity src) => new InducedDataRecordingTask {
    Id = src.Id,
    TaskScheduleId = src.TaskScheduleId,
    TaskDefinitionName = src.TaskDefinitionName,
    SchedulingOffset = src.SchedulingOffset,
    SchedulingOffsetUnit = src.SchedulingOffsetUnit,
    SchedulingVariabilityBefore = src.SchedulingVariabilityBefore,
    SchedulingVariabilityAfter = src.SchedulingVariabilityAfter,
    SchedulingVariabilityUnit = src.SchedulingVariabilityUnit,
    UniqueExecutionName = src.UniqueExecutionName,
    Skipable = src.Skipable,
    EventOnSkip = src.EventOnSkip,
    EventOnLost = src.EventOnLost,
    Position = src.Position,
    SchedulingOffsetFixpoint = src.SchedulingOffsetFixpoint,
    SchedulingByEstimate = src.SchedulingByEstimate,
    DedicatedToSubstudy = src.DedicatedToSubstudy,
    TaskNumber = src.TaskNumber,
  });

  internal void CopyContentFrom(InducedDataRecordingTask source, Func<String,bool> onFixedValueChangingCallback = null){
    this.Id = source.Id;
    this.TaskScheduleId = source.TaskScheduleId;
    this.TaskDefinitionName = source.TaskDefinitionName;
    this.SchedulingOffset = source.SchedulingOffset;
    this.SchedulingOffsetUnit = source.SchedulingOffsetUnit;
    this.SchedulingVariabilityBefore = source.SchedulingVariabilityBefore;
    this.SchedulingVariabilityAfter = source.SchedulingVariabilityAfter;
    this.SchedulingVariabilityUnit = source.SchedulingVariabilityUnit;
    this.UniqueExecutionName = source.UniqueExecutionName;
    this.Skipable = source.Skipable;
    this.EventOnSkip = source.EventOnSkip;
    this.EventOnLost = source.EventOnLost;
    this.Position = source.Position;
    this.SchedulingOffsetFixpoint = source.SchedulingOffsetFixpoint;
    this.SchedulingByEstimate = source.SchedulingByEstimate;
    this.DedicatedToSubstudy = source.DedicatedToSubstudy;
    this.TaskNumber = source.TaskNumber;
  }

  internal void CopyContentTo(InducedDataRecordingTask target, Func<String,bool> onFixedValueChangingCallback = null){
    target.Id = this.Id;
    target.TaskScheduleId = this.TaskScheduleId;
    target.TaskDefinitionName = this.TaskDefinitionName;
    target.SchedulingOffset = this.SchedulingOffset;
    target.SchedulingOffsetUnit = this.SchedulingOffsetUnit;
    target.SchedulingVariabilityBefore = this.SchedulingVariabilityBefore;
    target.SchedulingVariabilityAfter = this.SchedulingVariabilityAfter;
    target.SchedulingVariabilityUnit = this.SchedulingVariabilityUnit;
    target.UniqueExecutionName = this.UniqueExecutionName;
    target.Skipable = this.Skipable;
    target.EventOnSkip = this.EventOnSkip;
    target.EventOnLost = this.EventOnLost;
    target.Position = this.Position;
    target.SchedulingOffsetFixpoint = this.SchedulingOffsetFixpoint;
    target.SchedulingByEstimate = this.SchedulingByEstimate;
    target.DedicatedToSubstudy = this.DedicatedToSubstudy;
    target.TaskNumber = this.TaskNumber;
  }

#endregion

}

public class DrugApplymentTaskDefinitionEntity {

  /// <summary> Name of the Definition - INVARIANT! because it is used to generate Identifers for induced executions! *this field has a max length of 50 </summary>
  [MaxLength(50), Required]
  public String TaskDefinitionName { get; set; }

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
  public virtual ResearchStudyDefinitionEntity ResearchStudy { get; set; }

#region Mapping

  internal static Expression<Func<DrugApplymentTaskDefinition, DrugApplymentTaskDefinitionEntity>> DrugApplymentTaskDefinitionEntitySelector = ((DrugApplymentTaskDefinition src) => new DrugApplymentTaskDefinitionEntity {
    TaskDefinitionName = src.TaskDefinitionName,
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

  internal static Expression<Func<DrugApplymentTaskDefinitionEntity, DrugApplymentTaskDefinition>> DrugApplymentTaskDefinitionSelector = ((DrugApplymentTaskDefinitionEntity src) => new DrugApplymentTaskDefinition {
    TaskDefinitionName = src.TaskDefinitionName,
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

  internal void CopyContentFrom(DrugApplymentTaskDefinition source, Func<String,bool> onFixedValueChangingCallback = null){
    this.TaskDefinitionName = source.TaskDefinitionName;
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

  internal void CopyContentTo(DrugApplymentTaskDefinition target, Func<String,bool> onFixedValueChangingCallback = null){
    target.TaskDefinitionName = this.TaskDefinitionName;
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
  public String TaskDefinitionName { get; set; }

  /// <summary> estimated scheduling time relative to the scheduling date of the parent TaskSchedule </summary>
  [Required]
  public Int32 SchedulingOffset { get; set; }

  /// <summary> 'h'=Hours / 'm'=Minutes / 's'=Seconds </summary>
  [Required]
  public String SchedulingOffsetUnit { get; set; }

  /// <summary> defines an additional variability RELATIVE to the estimated scheduling time (which is calculated from the offset), in this case the EARLIEST possible time. </summary>
  [Required]
  public Int32 SchedulingVariabilityBefore { get; set; }

  /// <summary> defines an additional variability RELATIVE to the estimated scheduling time (which is calculated from the offset), in this case the LATEST possible time. </summary>
  [Required]
  public Int32 SchedulingVariabilityAfter { get; set; }

  /// <summary> 'h'=Hours / 'm'=Minutes / 's'=Seconds </summary>
  [Required]
  public String SchedulingVariabilityUnit { get; set; }

  /// <summary> the name for the induced execution, like 'Measurement X', which is usually defined by the study protocol. if multiple inducements are possible (for example when using cycles), the title should to contain a placeholder (example: '{vt} - Measurement X') to prevent from duplicate execution names. </summary>
  [Required]
  public String UniqueExecutionName { get; set; }

  /// <summary> defines, if the study protocol tolerates this execution to be 'skipped' (if not, a missed execution is treated as 'lost' and can cause the exclusion of the participant) </summary>
  [Required]
  public Boolean Skipable { get; set; }

  [Required]
  public String EventOnSkip { get; set; }

  [Required]
  public String EventOnLost { get; set; }

  /// <summary> The Position (1..x) of this inducement within the parent schedule. This value is relevant for addressing predecessors as fixpoint for the offest-calculation. Within one schedule there can only be one inducement for each position! The 0 is reserved for addressing the parent schedule itself and must not be used as well as negative values! </summary>
  [Required]
  public Int32 Position { get; set; }

  /// <summary> 0=InducementOfScheduleOrCycle: when the start of the parent Schedule (for the current cycle) was induced / -1=InducementOfPredessessor: when the direct predecessor task or subschedule (based on the 'Position') within the current schedule was induced / 1..x: when the predecessor at the Position within the current schedule, ADRESSED by the given value, was induced 
  /// *items of sub-schedules are not relevant - when addressing a sub-schedule as predecessor, then only its entry will be used
  /// *this behaviour can be concretized via 'SchedulingByEstimate' </summary>
  [Required]
  public Int32 SchedulingOffsetFixpoint { get; set; }

  /// <summary> If set to true, the offset calculation will be based on the ESTIMATED completion of the predecessor (see 'Fixpoint'). Otherwise, when set to false, the offset calculation will be based on the REAL completion (if recorded execution data is available during calculation) of the predecessor. *this will not evaluated, when the 'Fixpoint' is set to 0! </summary>
  [Required]
  public Boolean SchedulingByEstimate { get; set; }

  /// <summary> The name of a Sub-Study for which this Task should be induced or empty when its part of the current Arms regular workflow *this field is optional (use null as value) </summary>
  public String DedicatedToSubstudy { get; set; }

  /// <summary> Number, which can be used via Placeholder {#} within the UniqueExecutionName and which will automatically increase when using cycles or sub-schedules </summary>
  [Required]
  public Int32 TaskNumber { get; set; }

  [Lookup]
  public virtual DrugApplymentTaskDefinitionEntity InducedTask { get; set; }

  [Principal]
  public virtual TaskScheduleEntity TaskSchedule { get; set; }

#region Mapping

  internal static Expression<Func<InducedDrugApplymentTask, InducedDrugApplymentTaskEntity>> InducedDrugApplymentTaskEntitySelector = ((InducedDrugApplymentTask src) => new InducedDrugApplymentTaskEntity {
    Id = src.Id,
    TaskScheduleId = src.TaskScheduleId,
    TaskDefinitionName = src.TaskDefinitionName,
    SchedulingOffset = src.SchedulingOffset,
    SchedulingOffsetUnit = src.SchedulingOffsetUnit,
    SchedulingVariabilityBefore = src.SchedulingVariabilityBefore,
    SchedulingVariabilityAfter = src.SchedulingVariabilityAfter,
    SchedulingVariabilityUnit = src.SchedulingVariabilityUnit,
    UniqueExecutionName = src.UniqueExecutionName,
    Skipable = src.Skipable,
    EventOnSkip = src.EventOnSkip,
    EventOnLost = src.EventOnLost,
    Position = src.Position,
    SchedulingOffsetFixpoint = src.SchedulingOffsetFixpoint,
    SchedulingByEstimate = src.SchedulingByEstimate,
    DedicatedToSubstudy = src.DedicatedToSubstudy,
    TaskNumber = src.TaskNumber,
  });

  internal static Expression<Func<InducedDrugApplymentTaskEntity, InducedDrugApplymentTask>> InducedDrugApplymentTaskSelector = ((InducedDrugApplymentTaskEntity src) => new InducedDrugApplymentTask {
    Id = src.Id,
    TaskScheduleId = src.TaskScheduleId,
    TaskDefinitionName = src.TaskDefinitionName,
    SchedulingOffset = src.SchedulingOffset,
    SchedulingOffsetUnit = src.SchedulingOffsetUnit,
    SchedulingVariabilityBefore = src.SchedulingVariabilityBefore,
    SchedulingVariabilityAfter = src.SchedulingVariabilityAfter,
    SchedulingVariabilityUnit = src.SchedulingVariabilityUnit,
    UniqueExecutionName = src.UniqueExecutionName,
    Skipable = src.Skipable,
    EventOnSkip = src.EventOnSkip,
    EventOnLost = src.EventOnLost,
    Position = src.Position,
    SchedulingOffsetFixpoint = src.SchedulingOffsetFixpoint,
    SchedulingByEstimate = src.SchedulingByEstimate,
    DedicatedToSubstudy = src.DedicatedToSubstudy,
    TaskNumber = src.TaskNumber,
  });

  internal void CopyContentFrom(InducedDrugApplymentTask source, Func<String,bool> onFixedValueChangingCallback = null){
    this.Id = source.Id;
    this.TaskScheduleId = source.TaskScheduleId;
    this.TaskDefinitionName = source.TaskDefinitionName;
    this.SchedulingOffset = source.SchedulingOffset;
    this.SchedulingOffsetUnit = source.SchedulingOffsetUnit;
    this.SchedulingVariabilityBefore = source.SchedulingVariabilityBefore;
    this.SchedulingVariabilityAfter = source.SchedulingVariabilityAfter;
    this.SchedulingVariabilityUnit = source.SchedulingVariabilityUnit;
    this.UniqueExecutionName = source.UniqueExecutionName;
    this.Skipable = source.Skipable;
    this.EventOnSkip = source.EventOnSkip;
    this.EventOnLost = source.EventOnLost;
    this.Position = source.Position;
    this.SchedulingOffsetFixpoint = source.SchedulingOffsetFixpoint;
    this.SchedulingByEstimate = source.SchedulingByEstimate;
    this.DedicatedToSubstudy = source.DedicatedToSubstudy;
    this.TaskNumber = source.TaskNumber;
  }

  internal void CopyContentTo(InducedDrugApplymentTask target, Func<String,bool> onFixedValueChangingCallback = null){
    target.Id = this.Id;
    target.TaskScheduleId = this.TaskScheduleId;
    target.TaskDefinitionName = this.TaskDefinitionName;
    target.SchedulingOffset = this.SchedulingOffset;
    target.SchedulingOffsetUnit = this.SchedulingOffsetUnit;
    target.SchedulingVariabilityBefore = this.SchedulingVariabilityBefore;
    target.SchedulingVariabilityAfter = this.SchedulingVariabilityAfter;
    target.SchedulingVariabilityUnit = this.SchedulingVariabilityUnit;
    target.UniqueExecutionName = this.UniqueExecutionName;
    target.Skipable = this.Skipable;
    target.EventOnSkip = this.EventOnSkip;
    target.EventOnLost = this.EventOnLost;
    target.Position = this.Position;
    target.SchedulingOffsetFixpoint = this.SchedulingOffsetFixpoint;
    target.SchedulingByEstimate = this.SchedulingByEstimate;
    target.DedicatedToSubstudy = this.DedicatedToSubstudy;
    target.TaskNumber = this.TaskNumber;
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

  /// <summary> Name of the Workflow which is represented by this schedule - INVARIANT! because it is used to generate Identifers for induced executions! </summary>
  [Required]
  public String ScheduleWorkflowName { get; set; }

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

  /// <summary> the TaskSchedule which is representing the primary-/entry-workflow (estimated tasks) when executing this visit </summary>
  [Referer]
  public virtual ObservableCollection<ProcedureDefinitionEntity> EntryProdecureDefinitions { get; set; } = new ObservableCollection<ProcedureDefinitionEntity>();

  [Principal]
  public virtual ResearchStudyDefinitionEntity ResearchStudy { get; set; }

  [Dependent]
  public virtual TaskCycleDefinitionEntity CycleDefinition { get; set; }

#region Mapping

  internal static Expression<Func<TaskSchedule, TaskScheduleEntity>> TaskScheduleEntitySelector = ((TaskSchedule src) => new TaskScheduleEntity {
    TaskScheduleId = src.TaskScheduleId,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    ScheduleWorkflowName = src.ScheduleWorkflowName,
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
    ScheduleWorkflowName = src.ScheduleWorkflowName,
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
    this.ScheduleWorkflowName = source.ScheduleWorkflowName;
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
    target.ScheduleWorkflowName = this.ScheduleWorkflowName;
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

public class InducedProcedureEntity {

  [Required]
  public Guid Id { get; set; } = Guid.NewGuid();

  [Required]
  public Guid ProcedureScheduleId { get; set; }

  /// <summary> estimated scheduling date relative to the scheduling date of the parent ProcedureSchedule </summary>
  [Required]
  public Int32 SchedulingOffset { get; set; }

  /// <summary> 'M'=Months / 'W'=Weeks / 'D'=Days </summary>
  [Required]
  public String SchedulingOffsetUnit { get; set; }

  /// <summary> defines an additional variability RELATIVE to the estimated scheduling date (which is calculated from the offset), in this case the EARLIEST possible date. </summary>
  [Required]
  public Int32 SchedulingVariabilityBefore { get; set; }

  /// <summary> defines an additional variability RELATIVE to the estimated scheduling date (which is calculated from the offset), in this case the LATEST possible date. </summary>
  [Required]
  public Int32 SchedulingVariabilityAfter { get; set; }

  /// <summary> 'M'=Months / 'W'=Weeks / 'D'=Days </summary>
  [Required]
  public String SchedulingVariabilityUnit { get; set; }

  /// <summary> *this field has a max length of 50 </summary>
  [MaxLength(50), Required]
  public String ProdecureDefinitionName { get; set; }

  /// <summary> the name for the induced execution (=VISIT), like 'V0', which is usually defined by the study protocol. if multiple inducements are possible (for example when using cycles), the title should to contain a placeholder (example: 'C{cy}-V0') to prevent from duplicate execution names. </summary>
  [Required]
  public String UniqueExecutionName { get; set; }

  /// <summary> defines, if the study protocol tolerates this execution to be 'skipped' (if not, a missed execution is treated as 'lost' and can cause the exclusion of the participant) </summary>
  [Required]
  public Boolean Skipable { get; set; }

  [Required]
  public String EventOnSkip { get; set; }

  [Required]
  public String EventOnLost { get; set; }

  /// <summary> The Position (1..x) of this inducement within the parent schedule. This value is relevant for addressing predecessors as fixpoint for the offest-calculation. Within one schedule there can only be one inducement for each position! The 0 is reserved for addressing the parent schedule itself and must not be used as well as negative values! </summary>
  [Required]
  public Int32 Position { get; set; }

  /// <summary> 0=InducementOfScheduleOrCycle: when the start of the parent Schedule (for the current cycle) was induced / -1=InducementOfPredessessor: when the direct predecessor procedure or subschedule (based on the 'Position') within the current schedule was induced / 1..x: when the predecessor at the Position within the current schedule, ADRESSED by the given value, was induced 
  /// *items of sub-schedules are not relevant - when addressing a sub-schedule as predecessor, then only its entry will be used
  /// *this behaviour can be concretized via 'SchedulingByEstimate' </summary>
  [Required]
  public Int32 SchedulingOffsetFixpoint { get; set; }

  /// <summary> If set to true, the offset calculation will be based on the ESTIMATED completion of the predecessor (see 'Fixpoint'). Otherwise, when set to false, the offset calculation will be based on the REAL completion (if recorded execution data is available during calculation) of the predecessor. *this will not evaluated, when the 'Fixpoint' is set to 0! </summary>
  [Required]
  public Boolean SchedulingByEstimate { get; set; }

  /// <summary> The name of a Sub-Study for which this procedure should be induced or empty when its part of the current Arms regular workflow  *this field is optional (use null as value) </summary>
  public String DedicatedToSubstudy { get; set; }

  /// <summary> Number, which can be used via Placeholder {#} within the UniqueExecutionName and which will automatically increase when using cycles or sub-schedules </summary>
  [Required]
  public Int32 VisitNumber { get; set; }

  [Principal]
  public virtual ProcedureScheduleEntity ProcedureSchedule { get; set; }

  [Lookup]
  public virtual ProcedureDefinitionEntity InducedVisitProdecure { get; set; }

#region Mapping

  internal static Expression<Func<InducedProcedure, InducedProcedureEntity>> InducedProcedureEntitySelector = ((InducedProcedure src) => new InducedProcedureEntity {
    Id = src.Id,
    ProcedureScheduleId = src.ProcedureScheduleId,
    SchedulingOffset = src.SchedulingOffset,
    SchedulingOffsetUnit = src.SchedulingOffsetUnit,
    SchedulingVariabilityBefore = src.SchedulingVariabilityBefore,
    SchedulingVariabilityAfter = src.SchedulingVariabilityAfter,
    SchedulingVariabilityUnit = src.SchedulingVariabilityUnit,
    ProdecureDefinitionName = src.ProdecureDefinitionName,
    UniqueExecutionName = src.UniqueExecutionName,
    Skipable = src.Skipable,
    EventOnSkip = src.EventOnSkip,
    EventOnLost = src.EventOnLost,
    Position = src.Position,
    SchedulingOffsetFixpoint = src.SchedulingOffsetFixpoint,
    SchedulingByEstimate = src.SchedulingByEstimate,
    DedicatedToSubstudy = src.DedicatedToSubstudy,
    VisitNumber = src.VisitNumber,
  });

  internal static Expression<Func<InducedProcedureEntity, InducedProcedure>> InducedProcedureSelector = ((InducedProcedureEntity src) => new InducedProcedure {
    Id = src.Id,
    ProcedureScheduleId = src.ProcedureScheduleId,
    SchedulingOffset = src.SchedulingOffset,
    SchedulingOffsetUnit = src.SchedulingOffsetUnit,
    SchedulingVariabilityBefore = src.SchedulingVariabilityBefore,
    SchedulingVariabilityAfter = src.SchedulingVariabilityAfter,
    SchedulingVariabilityUnit = src.SchedulingVariabilityUnit,
    ProdecureDefinitionName = src.ProdecureDefinitionName,
    UniqueExecutionName = src.UniqueExecutionName,
    Skipable = src.Skipable,
    EventOnSkip = src.EventOnSkip,
    EventOnLost = src.EventOnLost,
    Position = src.Position,
    SchedulingOffsetFixpoint = src.SchedulingOffsetFixpoint,
    SchedulingByEstimate = src.SchedulingByEstimate,
    DedicatedToSubstudy = src.DedicatedToSubstudy,
    VisitNumber = src.VisitNumber,
  });

  internal void CopyContentFrom(InducedProcedure source, Func<String,bool> onFixedValueChangingCallback = null){
    this.Id = source.Id;
    this.ProcedureScheduleId = source.ProcedureScheduleId;
    this.SchedulingOffset = source.SchedulingOffset;
    this.SchedulingOffsetUnit = source.SchedulingOffsetUnit;
    this.SchedulingVariabilityBefore = source.SchedulingVariabilityBefore;
    this.SchedulingVariabilityAfter = source.SchedulingVariabilityAfter;
    this.SchedulingVariabilityUnit = source.SchedulingVariabilityUnit;
    this.ProdecureDefinitionName = source.ProdecureDefinitionName;
    this.UniqueExecutionName = source.UniqueExecutionName;
    this.Skipable = source.Skipable;
    this.EventOnSkip = source.EventOnSkip;
    this.EventOnLost = source.EventOnLost;
    this.Position = source.Position;
    this.SchedulingOffsetFixpoint = source.SchedulingOffsetFixpoint;
    this.SchedulingByEstimate = source.SchedulingByEstimate;
    this.DedicatedToSubstudy = source.DedicatedToSubstudy;
    this.VisitNumber = source.VisitNumber;
  }

  internal void CopyContentTo(InducedProcedure target, Func<String,bool> onFixedValueChangingCallback = null){
    target.Id = this.Id;
    target.ProcedureScheduleId = this.ProcedureScheduleId;
    target.SchedulingOffset = this.SchedulingOffset;
    target.SchedulingOffsetUnit = this.SchedulingOffsetUnit;
    target.SchedulingVariabilityBefore = this.SchedulingVariabilityBefore;
    target.SchedulingVariabilityAfter = this.SchedulingVariabilityAfter;
    target.SchedulingVariabilityUnit = this.SchedulingVariabilityUnit;
    target.ProdecureDefinitionName = this.ProdecureDefinitionName;
    target.UniqueExecutionName = this.UniqueExecutionName;
    target.Skipable = this.Skipable;
    target.EventOnSkip = this.EventOnSkip;
    target.EventOnLost = this.EventOnLost;
    target.Position = this.Position;
    target.SchedulingOffsetFixpoint = this.SchedulingOffsetFixpoint;
    target.SchedulingByEstimate = this.SchedulingByEstimate;
    target.DedicatedToSubstudy = this.DedicatedToSubstudy;
    target.VisitNumber = this.VisitNumber;
  }

#endregion

}

public class ProcedureDefinitionEntity {

  /// <summary> Name of the Definition - INVARIANT! because it is used to generate Identifers for induced executions! *this field has a max length of 50 </summary>
  [MaxLength(50), Required]
  public String ProdecureDefinitionName { get; set; }

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
  public virtual ObservableCollection<InducedProcedureEntity> Inducements { get; set; } = new ObservableCollection<InducedProcedureEntity>();

  [Principal]
  public virtual ResearchStudyDefinitionEntity ResearchStudy { get; set; }

  /// <summary> the TaskSchedule which is representing the primary-/entry-workflow (estimated tasks) when executing this visit </summary>
  [Lookup]
  public virtual TaskScheduleEntity RootTaskSchedule { get; set; }

#region Mapping

  internal static Expression<Func<ProcedureDefinition, ProcedureDefinitionEntity>> ProcedureDefinitionEntitySelector = ((ProcedureDefinition src) => new ProcedureDefinitionEntity {
    ProdecureDefinitionName = src.ProdecureDefinitionName,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    RootTaskScheduleId = src.RootTaskScheduleId,
    BillablePriceOnAbortedExecution = src.BillablePriceOnAbortedExecution,
    BillablePriceOnCompletedExecution = src.BillablePriceOnCompletedExecution,
    VisitSpecificDocumentationUrl = src.VisitSpecificDocumentationUrl,
  });

  internal static Expression<Func<ProcedureDefinitionEntity, ProcedureDefinition>> ProcedureDefinitionSelector = ((ProcedureDefinitionEntity src) => new ProcedureDefinition {
    ProdecureDefinitionName = src.ProdecureDefinitionName,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    RootTaskScheduleId = src.RootTaskScheduleId,
    BillablePriceOnAbortedExecution = src.BillablePriceOnAbortedExecution,
    BillablePriceOnCompletedExecution = src.BillablePriceOnCompletedExecution,
    VisitSpecificDocumentationUrl = src.VisitSpecificDocumentationUrl,
  });

  internal void CopyContentFrom(ProcedureDefinition source, Func<String,bool> onFixedValueChangingCallback = null){
    this.ProdecureDefinitionName = source.ProdecureDefinitionName;
    this.StudyWorkflowName = source.StudyWorkflowName;
    this.StudyWorkflowVersion = source.StudyWorkflowVersion;
    this.RootTaskScheduleId = source.RootTaskScheduleId;
    this.BillablePriceOnAbortedExecution = source.BillablePriceOnAbortedExecution;
    this.BillablePriceOnCompletedExecution = source.BillablePriceOnCompletedExecution;
    this.VisitSpecificDocumentationUrl = source.VisitSpecificDocumentationUrl;
  }

  internal void CopyContentTo(ProcedureDefinition target, Func<String,bool> onFixedValueChangingCallback = null){
    target.ProdecureDefinitionName = this.ProdecureDefinitionName;
    target.StudyWorkflowName = this.StudyWorkflowName;
    target.StudyWorkflowVersion = this.StudyWorkflowVersion;
    target.RootTaskScheduleId = this.RootTaskScheduleId;
    target.BillablePriceOnAbortedExecution = this.BillablePriceOnAbortedExecution;
    target.BillablePriceOnCompletedExecution = this.BillablePriceOnCompletedExecution;
    target.VisitSpecificDocumentationUrl = this.VisitSpecificDocumentationUrl;
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
  public Int32 SchedulingOffset { get; set; }

  /// <summary> 'M'=Months / 'W'=Weeks / 'D'=Days </summary>
  [Required]
  public String SchedulingOffsetUnit { get; set; }

  [Required]
  public Boolean SharedSkipCounters { get; set; }

  [Required]
  public Boolean SharedLostCounters { get; set; }

  /// <summary> The Position (1..x) of this inducement within the parent schedule. This value is relevant for addressing predecessors as fixpoint for the offest-calculation. Within one schedule there can only be one inducement for each position! The 0 is reserved for addressing the parent schedule itself and must not be used as well as negative values! </summary>
  [Required]
  public Int32 Position { get; set; }

  /// <summary> 0=InducementOfScheduleOrCycle: when the start of the parent Schedule (for the current cycle) was induced / -1=InducementOfPredessessor: when the direct predecessor procedure or subschedule (based on the 'Position') within the current schedule was induced / 1..x: when the predecessor at the Position within the current schedule, ADRESSED by the given value, was induced 
  /// *items of sub-schedules are not relevant - when addressing a sub-schedule as predecessor, then only its entry will be used
  /// *this behaviour can be concretized via 'SchedulingByEstimate' </summary>
  [Required]
  public Int32 SchedulingOffsetFixpoint { get; set; }

  /// <summary> If set to true, the offset calculation will be based on the ESTIMATED completion of the predecessor (see 'Fixpoint'). Otherwise, when set to false, the offset calculation will be based on the REAL completion (if recorded execution data is available during calculation) of the predecessor. *this will not evaluated, when the 'Fixpoint' is set to 0! </summary>
  [Required]
  public Boolean SchedulingByEstimate { get; set; }

  /// <summary> The name of a Sub-Study for which this schedule should be induced or empty when its part of the current Arms regular workflow  *this field is optional (use null as value) </summary>
  public String DedicatedToSubstudy { get; set; }

  [Required]
  public Int32 IncreaseVisitNumberBase { get; set; }

  [Required]
  public Boolean InheritVisitNumberBase { get; set; }

  [Principal]
  public virtual ProcedureScheduleEntity ParentProcedureSchedule { get; set; }

  [Lookup]
  public virtual ProcedureScheduleEntity InducedProcedureSchedule { get; set; }

#region Mapping

  internal static Expression<Func<InducedSubProcedureSchedule, InducedSubProcedureScheduleEntity>> InducedSubProcedureScheduleEntitySelector = ((InducedSubProcedureSchedule src) => new InducedSubProcedureScheduleEntity {
    Id = src.Id,
    ParentProcedureScheduleId = src.ParentProcedureScheduleId,
    InducedProcedureScheduleId = src.InducedProcedureScheduleId,
    SchedulingOffset = src.SchedulingOffset,
    SchedulingOffsetUnit = src.SchedulingOffsetUnit,
    SharedSkipCounters = src.SharedSkipCounters,
    SharedLostCounters = src.SharedLostCounters,
    Position = src.Position,
    SchedulingOffsetFixpoint = src.SchedulingOffsetFixpoint,
    SchedulingByEstimate = src.SchedulingByEstimate,
    DedicatedToSubstudy = src.DedicatedToSubstudy,
    IncreaseVisitNumberBase = src.IncreaseVisitNumberBase,
    InheritVisitNumberBase = src.InheritVisitNumberBase,
  });

  internal static Expression<Func<InducedSubProcedureScheduleEntity, InducedSubProcedureSchedule>> InducedSubProcedureScheduleSelector = ((InducedSubProcedureScheduleEntity src) => new InducedSubProcedureSchedule {
    Id = src.Id,
    ParentProcedureScheduleId = src.ParentProcedureScheduleId,
    InducedProcedureScheduleId = src.InducedProcedureScheduleId,
    SchedulingOffset = src.SchedulingOffset,
    SchedulingOffsetUnit = src.SchedulingOffsetUnit,
    SharedSkipCounters = src.SharedSkipCounters,
    SharedLostCounters = src.SharedLostCounters,
    Position = src.Position,
    SchedulingOffsetFixpoint = src.SchedulingOffsetFixpoint,
    SchedulingByEstimate = src.SchedulingByEstimate,
    DedicatedToSubstudy = src.DedicatedToSubstudy,
    IncreaseVisitNumberBase = src.IncreaseVisitNumberBase,
    InheritVisitNumberBase = src.InheritVisitNumberBase,
  });

  internal void CopyContentFrom(InducedSubProcedureSchedule source, Func<String,bool> onFixedValueChangingCallback = null){
    this.Id = source.Id;
    this.ParentProcedureScheduleId = source.ParentProcedureScheduleId;
    this.InducedProcedureScheduleId = source.InducedProcedureScheduleId;
    this.SchedulingOffset = source.SchedulingOffset;
    this.SchedulingOffsetUnit = source.SchedulingOffsetUnit;
    this.SharedSkipCounters = source.SharedSkipCounters;
    this.SharedLostCounters = source.SharedLostCounters;
    this.Position = source.Position;
    this.SchedulingOffsetFixpoint = source.SchedulingOffsetFixpoint;
    this.SchedulingByEstimate = source.SchedulingByEstimate;
    this.DedicatedToSubstudy = source.DedicatedToSubstudy;
    this.IncreaseVisitNumberBase = source.IncreaseVisitNumberBase;
    this.InheritVisitNumberBase = source.InheritVisitNumberBase;
  }

  internal void CopyContentTo(InducedSubProcedureSchedule target, Func<String,bool> onFixedValueChangingCallback = null){
    target.Id = this.Id;
    target.ParentProcedureScheduleId = this.ParentProcedureScheduleId;
    target.InducedProcedureScheduleId = this.InducedProcedureScheduleId;
    target.SchedulingOffset = this.SchedulingOffset;
    target.SchedulingOffsetUnit = this.SchedulingOffsetUnit;
    target.SharedSkipCounters = this.SharedSkipCounters;
    target.SharedLostCounters = this.SharedLostCounters;
    target.Position = this.Position;
    target.SchedulingOffsetFixpoint = this.SchedulingOffsetFixpoint;
    target.SchedulingByEstimate = this.SchedulingByEstimate;
    target.DedicatedToSubstudy = this.DedicatedToSubstudy;
    target.IncreaseVisitNumberBase = this.IncreaseVisitNumberBase;
    target.InheritVisitNumberBase = this.InheritVisitNumberBase;
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
  public Int32 SchedulingOffset { get; set; }

  /// <summary> 'h'=Hours / 'm'=Minutes / 's'=Seconds </summary>
  [Required]
  public String SchedulingOffsetUnit { get; set; }

  [Required]
  public Boolean SharedSkipCounters { get; set; }

  [Required]
  public Boolean SharedLostCounters { get; set; }

  /// <summary> The Position (1..x) of this inducement within the parent schedule. This value is relevant for addressing predecessors as fixpoint for the offest-calculation. Within one schedule there can only be one inducement for each position! The 0 is reserved for addressing the parent schedule itself and must not be used as well as negative values! </summary>
  [Required]
  public Int32 Position { get; set; }

  /// <summary> 0=InducementOfScheduleOrCycle: when the start of the parent Schedule (for the current cycle) was induced / -1=InducementOfPredessessor: when the direct predecessor task or subschedule (based on the 'Position') within the current schedule was induced / 1..x: when the predecessor at the Position within the current schedule, ADRESSED by the given value, was induced 
  /// *items of sub-schedules are not relevant - when addressing a sub-schedule as predecessor, then only its entry will be used
  /// *this behaviour can be concretized via 'SchedulingByEstimate' </summary>
  [Required]
  public Int32 SchedulingOffsetFixpoint { get; set; }

  /// <summary> If set to true, the offset calculation will be based on the ESTIMATED completion of the predecessor (see 'Fixpoint'). Otherwise, when set to false, the offset calculation will be based on the REAL completion (if recorded execution data is available during calculation) of the predecessor. *this will not evaluated, when the 'Fixpoint' is set to 0! </summary>
  [Required]
  public Boolean SchedulingByEstimate { get; set; }

  /// <summary> The name of a Sub-Study for which this schedule should be induced or empty when its part of the current Arms regular workflow  *this field is optional (use null as value) </summary>
  public String DedicatedToSubstudy { get; set; }

  [Required]
  public Int32 IncreaseVisitNumberBase { get; set; }

  [Required]
  public Boolean InheritVisitNumberBase { get; set; }

  [Principal]
  public virtual TaskScheduleEntity ParentTaskSchedule { get; set; }

  [Lookup]
  public virtual TaskScheduleEntity InducedTaskSchedule { get; set; }

#region Mapping

  internal static Expression<Func<InducedSubTaskSchedule, InducedSubTaskScheduleEntity>> InducedSubTaskScheduleEntitySelector = ((InducedSubTaskSchedule src) => new InducedSubTaskScheduleEntity {
    Id = src.Id,
    ParentTaskScheduleId = src.ParentTaskScheduleId,
    InducedTaskScheduleId = src.InducedTaskScheduleId,
    SchedulingOffset = src.SchedulingOffset,
    SchedulingOffsetUnit = src.SchedulingOffsetUnit,
    SharedSkipCounters = src.SharedSkipCounters,
    SharedLostCounters = src.SharedLostCounters,
    Position = src.Position,
    SchedulingOffsetFixpoint = src.SchedulingOffsetFixpoint,
    SchedulingByEstimate = src.SchedulingByEstimate,
    DedicatedToSubstudy = src.DedicatedToSubstudy,
    IncreaseVisitNumberBase = src.IncreaseVisitNumberBase,
    InheritVisitNumberBase = src.InheritVisitNumberBase,
  });

  internal static Expression<Func<InducedSubTaskScheduleEntity, InducedSubTaskSchedule>> InducedSubTaskScheduleSelector = ((InducedSubTaskScheduleEntity src) => new InducedSubTaskSchedule {
    Id = src.Id,
    ParentTaskScheduleId = src.ParentTaskScheduleId,
    InducedTaskScheduleId = src.InducedTaskScheduleId,
    SchedulingOffset = src.SchedulingOffset,
    SchedulingOffsetUnit = src.SchedulingOffsetUnit,
    SharedSkipCounters = src.SharedSkipCounters,
    SharedLostCounters = src.SharedLostCounters,
    Position = src.Position,
    SchedulingOffsetFixpoint = src.SchedulingOffsetFixpoint,
    SchedulingByEstimate = src.SchedulingByEstimate,
    DedicatedToSubstudy = src.DedicatedToSubstudy,
    IncreaseVisitNumberBase = src.IncreaseVisitNumberBase,
    InheritVisitNumberBase = src.InheritVisitNumberBase,
  });

  internal void CopyContentFrom(InducedSubTaskSchedule source, Func<String,bool> onFixedValueChangingCallback = null){
    this.Id = source.Id;
    this.ParentTaskScheduleId = source.ParentTaskScheduleId;
    this.InducedTaskScheduleId = source.InducedTaskScheduleId;
    this.SchedulingOffset = source.SchedulingOffset;
    this.SchedulingOffsetUnit = source.SchedulingOffsetUnit;
    this.SharedSkipCounters = source.SharedSkipCounters;
    this.SharedLostCounters = source.SharedLostCounters;
    this.Position = source.Position;
    this.SchedulingOffsetFixpoint = source.SchedulingOffsetFixpoint;
    this.SchedulingByEstimate = source.SchedulingByEstimate;
    this.DedicatedToSubstudy = source.DedicatedToSubstudy;
    this.IncreaseVisitNumberBase = source.IncreaseVisitNumberBase;
    this.InheritVisitNumberBase = source.InheritVisitNumberBase;
  }

  internal void CopyContentTo(InducedSubTaskSchedule target, Func<String,bool> onFixedValueChangingCallback = null){
    target.Id = this.Id;
    target.ParentTaskScheduleId = this.ParentTaskScheduleId;
    target.InducedTaskScheduleId = this.InducedTaskScheduleId;
    target.SchedulingOffset = this.SchedulingOffset;
    target.SchedulingOffsetUnit = this.SchedulingOffsetUnit;
    target.SharedSkipCounters = this.SharedSkipCounters;
    target.SharedLostCounters = this.SharedLostCounters;
    target.Position = this.Position;
    target.SchedulingOffsetFixpoint = this.SchedulingOffsetFixpoint;
    target.SchedulingByEstimate = this.SchedulingByEstimate;
    target.DedicatedToSubstudy = this.DedicatedToSubstudy;
    target.IncreaseVisitNumberBase = this.IncreaseVisitNumberBase;
    target.InheritVisitNumberBase = this.InheritVisitNumberBase;
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
  public String TaskDefinitionName { get; set; }

  /// <summary> estimated scheduling time relative to the scheduling date of the parent TaskSchedule </summary>
  [Required]
  public Int32 SchedulingOffset { get; set; }

  /// <summary> 'h'=Hours / 'm'=Minutes / 's'=Seconds </summary>
  [Required]
  public String SchedulingOffsetUnit { get; set; }

  /// <summary> defines an additional variability RELATIVE to the estimated scheduling time (which is calculated from the offset), in this case the EARLIEST possible time. </summary>
  [Required]
  public String SchedulingVariabilityBefore { get; set; }

  /// <summary> defines an additional variability RELATIVE to the estimated scheduling time (which is calculated from the offset), in this case the LATEST possible time. </summary>
  [Required]
  public String SchedulingVariabilityAfter { get; set; }

  /// <summary> 'h'=Hours / 'm'=Minutes / 's'=Seconds </summary>
  [Required]
  public String SchedulingVariabilityUnit { get; set; }

  /// <summary> the name for the induced execution, like 'Measurement X', which is usually defined by the study protocol. if multiple inducements are possible (for example when using cycles), the title should to contain a placeholder (example: '{vt} - Measurement X') to prevent from duplicate execution names. </summary>
  [Required]
  public String UniqueExecutionName { get; set; }

  /// <summary> defines, if the study protocol tolerates this execution to be 'skipped' (if not, a missed execution is treated as 'lost' and can cause the exclusion of the participant) </summary>
  [Required]
  public Boolean Skipable { get; set; }

  [Required]
  public String EventOnSkip { get; set; }

  [Required]
  public String EventOnLost { get; set; }

  /// <summary> The Position (1..x) of this inducement within the parent schedule. This value is relevant for addressing predecessors as fixpoint for the offest-calculation. Within one schedule there can only be one inducement for each position! The 0 is reserved for addressing the parent schedule itself and must not be used as well as negative values! </summary>
  [Required]
  public Int32 Position { get; set; }

  /// <summary> 0=InducementOfScheduleOrCycle: when the start of the parent Schedule (for the current cycle) was induced / -1=InducementOfPredessessor: when the direct predecessor task or subschedule (based on the 'Position') within the current schedule was induced / 1..x: when the predecessor at the Position within the current schedule, ADRESSED by the given value, was induced 
  /// *items of sub-schedules are not relevant - when addressing a sub-schedule as predecessor, then only its entry will be used
  /// *this behaviour can be concretized via 'SchedulingByEstimate' </summary>
  [Required]
  public Int32 SchedulingOffsetFixpoint { get; set; }

  /// <summary> If set to true, the offset calculation will be based on the ESTIMATED completion of the predecessor (see 'Fixpoint'). Otherwise, when set to false, the offset calculation will be based on the REAL completion (if recorded execution data is available during calculation) of the predecessor. *this will not evaluated, when the 'Fixpoint' is set to 0! </summary>
  [Required]
  public Boolean SchedulingByEstimate { get; set; }

  /// <summary> The name of a Sub-Study for which this Task should be induced or empty when its part of the current Arms regular workflow *this field is optional (use null as value) </summary>
  public String DedicatedToSubstudy { get; set; }

  /// <summary> Number, which can be used via Placeholder {#} within the UniqueExecutionName and which will automatically increase when using cycles or sub-schedules </summary>
  [Required]
  public Int32 TaskNumber { get; set; }

  [Principal]
  public virtual TaskScheduleEntity TaskSchedule { get; set; }

  [Lookup]
  public virtual TreatmentTaskDefinitionEntity InducedTask { get; set; }

#region Mapping

  internal static Expression<Func<InducedTreatmentTask, InducedTreatmentTaskEntity>> InducedTreatmentTaskEntitySelector = ((InducedTreatmentTask src) => new InducedTreatmentTaskEntity {
    Id = src.Id,
    TaskScheduleId = src.TaskScheduleId,
    TaskDefinitionName = src.TaskDefinitionName,
    SchedulingOffset = src.SchedulingOffset,
    SchedulingOffsetUnit = src.SchedulingOffsetUnit,
    SchedulingVariabilityBefore = src.SchedulingVariabilityBefore,
    SchedulingVariabilityAfter = src.SchedulingVariabilityAfter,
    SchedulingVariabilityUnit = src.SchedulingVariabilityUnit,
    UniqueExecutionName = src.UniqueExecutionName,
    Skipable = src.Skipable,
    EventOnSkip = src.EventOnSkip,
    EventOnLost = src.EventOnLost,
    Position = src.Position,
    SchedulingOffsetFixpoint = src.SchedulingOffsetFixpoint,
    SchedulingByEstimate = src.SchedulingByEstimate,
    DedicatedToSubstudy = src.DedicatedToSubstudy,
    TaskNumber = src.TaskNumber,
  });

  internal static Expression<Func<InducedTreatmentTaskEntity, InducedTreatmentTask>> InducedTreatmentTaskSelector = ((InducedTreatmentTaskEntity src) => new InducedTreatmentTask {
    Id = src.Id,
    TaskScheduleId = src.TaskScheduleId,
    TaskDefinitionName = src.TaskDefinitionName,
    SchedulingOffset = src.SchedulingOffset,
    SchedulingOffsetUnit = src.SchedulingOffsetUnit,
    SchedulingVariabilityBefore = src.SchedulingVariabilityBefore,
    SchedulingVariabilityAfter = src.SchedulingVariabilityAfter,
    SchedulingVariabilityUnit = src.SchedulingVariabilityUnit,
    UniqueExecutionName = src.UniqueExecutionName,
    Skipable = src.Skipable,
    EventOnSkip = src.EventOnSkip,
    EventOnLost = src.EventOnLost,
    Position = src.Position,
    SchedulingOffsetFixpoint = src.SchedulingOffsetFixpoint,
    SchedulingByEstimate = src.SchedulingByEstimate,
    DedicatedToSubstudy = src.DedicatedToSubstudy,
    TaskNumber = src.TaskNumber,
  });

  internal void CopyContentFrom(InducedTreatmentTask source, Func<String,bool> onFixedValueChangingCallback = null){
    this.Id = source.Id;
    this.TaskScheduleId = source.TaskScheduleId;
    this.TaskDefinitionName = source.TaskDefinitionName;
    this.SchedulingOffset = source.SchedulingOffset;
    this.SchedulingOffsetUnit = source.SchedulingOffsetUnit;
    this.SchedulingVariabilityBefore = source.SchedulingVariabilityBefore;
    this.SchedulingVariabilityAfter = source.SchedulingVariabilityAfter;
    this.SchedulingVariabilityUnit = source.SchedulingVariabilityUnit;
    this.UniqueExecutionName = source.UniqueExecutionName;
    this.Skipable = source.Skipable;
    this.EventOnSkip = source.EventOnSkip;
    this.EventOnLost = source.EventOnLost;
    this.Position = source.Position;
    this.SchedulingOffsetFixpoint = source.SchedulingOffsetFixpoint;
    this.SchedulingByEstimate = source.SchedulingByEstimate;
    this.DedicatedToSubstudy = source.DedicatedToSubstudy;
    this.TaskNumber = source.TaskNumber;
  }

  internal void CopyContentTo(InducedTreatmentTask target, Func<String,bool> onFixedValueChangingCallback = null){
    target.Id = this.Id;
    target.TaskScheduleId = this.TaskScheduleId;
    target.TaskDefinitionName = this.TaskDefinitionName;
    target.SchedulingOffset = this.SchedulingOffset;
    target.SchedulingOffsetUnit = this.SchedulingOffsetUnit;
    target.SchedulingVariabilityBefore = this.SchedulingVariabilityBefore;
    target.SchedulingVariabilityAfter = this.SchedulingVariabilityAfter;
    target.SchedulingVariabilityUnit = this.SchedulingVariabilityUnit;
    target.UniqueExecutionName = this.UniqueExecutionName;
    target.Skipable = this.Skipable;
    target.EventOnSkip = this.EventOnSkip;
    target.EventOnLost = this.EventOnLost;
    target.Position = this.Position;
    target.SchedulingOffsetFixpoint = this.SchedulingOffsetFixpoint;
    target.SchedulingByEstimate = this.SchedulingByEstimate;
    target.DedicatedToSubstudy = this.DedicatedToSubstudy;
    target.TaskNumber = this.TaskNumber;
  }

#endregion

}

public class TreatmentTaskDefinitionEntity {

  /// <summary> Name of the Definition - INVARIANT! because it is used to generate Identifers for induced executions! *this field has a max length of 50 </summary>
  [MaxLength(50), Required]
  public String TaskDefinitionName { get; set; }

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
  public virtual ResearchStudyDefinitionEntity ResearchStudy { get; set; }

#region Mapping

  internal static Expression<Func<TreatmentTaskDefinition, TreatmentTaskDefinitionEntity>> TreatmentTaskDefinitionEntitySelector = ((TreatmentTaskDefinition src) => new TreatmentTaskDefinitionEntity {
    TaskDefinitionName = src.TaskDefinitionName,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    BillablePriceOnCompletedExecution = src.BillablePriceOnCompletedExecution,
    ShortDescription = src.ShortDescription,
    TaskSpecificDocumentationUrl = src.TaskSpecificDocumentationUrl,
    TreatmentDescription = src.TreatmentDescription,
    ImportantNotices = src.ImportantNotices,
  });

  internal static Expression<Func<TreatmentTaskDefinitionEntity, TreatmentTaskDefinition>> TreatmentTaskDefinitionSelector = ((TreatmentTaskDefinitionEntity src) => new TreatmentTaskDefinition {
    TaskDefinitionName = src.TaskDefinitionName,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    BillablePriceOnCompletedExecution = src.BillablePriceOnCompletedExecution,
    ShortDescription = src.ShortDescription,
    TaskSpecificDocumentationUrl = src.TaskSpecificDocumentationUrl,
    TreatmentDescription = src.TreatmentDescription,
    ImportantNotices = src.ImportantNotices,
  });

  internal void CopyContentFrom(TreatmentTaskDefinition source, Func<String,bool> onFixedValueChangingCallback = null){
    this.TaskDefinitionName = source.TaskDefinitionName;
    this.StudyWorkflowName = source.StudyWorkflowName;
    this.StudyWorkflowVersion = source.StudyWorkflowVersion;
    this.BillablePriceOnCompletedExecution = source.BillablePriceOnCompletedExecution;
    this.ShortDescription = source.ShortDescription;
    this.TaskSpecificDocumentationUrl = source.TaskSpecificDocumentationUrl;
    this.TreatmentDescription = source.TreatmentDescription;
    this.ImportantNotices = source.ImportantNotices;
  }

  internal void CopyContentTo(TreatmentTaskDefinition target, Func<String,bool> onFixedValueChangingCallback = null){
    target.TaskDefinitionName = this.TaskDefinitionName;
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

public class ProcedureCycleDefinitionEntity {

  [Required]
  public Guid ProcedureScheduleId { get; set; } = Guid.NewGuid();

  /// <summary> 0=InducementOfScheduleOrCycle: when the start of the last cycle was induced / -1=InducementOfPredessessor: when the last procedure or subschedule (based on the 'Position') of the previous cycle was induced.
  /// *items of sub-schedules are not relevant - when addressing a sub-schedule as predecessor, then only its entry will be used
  /// *this behaviour can be concretized via 'ReschedulingByEstimate' </summary>
  [Required]
  public Int32 ReschedulingOffsetFixpoint { get; set; }

  /// <summary> estimated scheduling date relative to the ReschedulingBase </summary>
  [Required]
  public Int32 ReschedulingOffset { get; set; }

  /// <summary> 'M'=Months / 'W'=Weeks / 'D'=Days </summary>
  [Required]
  public String ReschedulingOffsetUnit { get; set; }

  /// <summary> number of cycles (of null for a infinite number of cycles) *this field is optional </summary>
  public Nullable<Int32> CycleLimit { get; set; }

  [Required]
  public Boolean SharedSkipCounters { get; set; }

  [Required]
  public Boolean SharedLostCounters { get; set; }

  /// <summary> If set to true, the offset calculation will be based on the ESTIMATED completion of the predecessor (see 'Fixpoint'). Otherwise, when set to false, the offset calculation will be based on the REAL completion (if recorded execution data is available during calculation) of the predecessor. *this will not evaluated, when the 'Fixpoint' is set to 0! </summary>
  [Required]
  public Boolean ReschedulingByEstimate { get; set; }

  /// <summary> -1: automatic, based on the usage of visit numbers within the schedule </summary>
  [Required]
  public Int32 IncreaseVisitNumberBasePerCycle { get; set; }

  [Principal]
  public virtual ProcedureScheduleEntity ProcedureSchedule { get; set; }

#region Mapping

  internal static Expression<Func<ProcedureCycleDefinition, ProcedureCycleDefinitionEntity>> ProcedureCycleDefinitionEntitySelector = ((ProcedureCycleDefinition src) => new ProcedureCycleDefinitionEntity {
    ProcedureScheduleId = src.ProcedureScheduleId,
    ReschedulingOffsetFixpoint = src.ReschedulingOffsetFixpoint,
    ReschedulingOffset = src.ReschedulingOffset,
    ReschedulingOffsetUnit = src.ReschedulingOffsetUnit,
    CycleLimit = src.CycleLimit,
    SharedSkipCounters = src.SharedSkipCounters,
    SharedLostCounters = src.SharedLostCounters,
    ReschedulingByEstimate = src.ReschedulingByEstimate,
    IncreaseVisitNumberBasePerCycle = src.IncreaseVisitNumberBasePerCycle,
  });

  internal static Expression<Func<ProcedureCycleDefinitionEntity, ProcedureCycleDefinition>> ProcedureCycleDefinitionSelector = ((ProcedureCycleDefinitionEntity src) => new ProcedureCycleDefinition {
    ProcedureScheduleId = src.ProcedureScheduleId,
    ReschedulingOffsetFixpoint = src.ReschedulingOffsetFixpoint,
    ReschedulingOffset = src.ReschedulingOffset,
    ReschedulingOffsetUnit = src.ReschedulingOffsetUnit,
    CycleLimit = src.CycleLimit,
    SharedSkipCounters = src.SharedSkipCounters,
    SharedLostCounters = src.SharedLostCounters,
    ReschedulingByEstimate = src.ReschedulingByEstimate,
    IncreaseVisitNumberBasePerCycle = src.IncreaseVisitNumberBasePerCycle,
  });

  internal void CopyContentFrom(ProcedureCycleDefinition source, Func<String,bool> onFixedValueChangingCallback = null){
    this.ProcedureScheduleId = source.ProcedureScheduleId;
    this.ReschedulingOffsetFixpoint = source.ReschedulingOffsetFixpoint;
    this.ReschedulingOffset = source.ReschedulingOffset;
    this.ReschedulingOffsetUnit = source.ReschedulingOffsetUnit;
    this.CycleLimit = source.CycleLimit;
    this.SharedSkipCounters = source.SharedSkipCounters;
    this.SharedLostCounters = source.SharedLostCounters;
    this.ReschedulingByEstimate = source.ReschedulingByEstimate;
    this.IncreaseVisitNumberBasePerCycle = source.IncreaseVisitNumberBasePerCycle;
  }

  internal void CopyContentTo(ProcedureCycleDefinition target, Func<String,bool> onFixedValueChangingCallback = null){
    target.ProcedureScheduleId = this.ProcedureScheduleId;
    target.ReschedulingOffsetFixpoint = this.ReschedulingOffsetFixpoint;
    target.ReschedulingOffset = this.ReschedulingOffset;
    target.ReschedulingOffsetUnit = this.ReschedulingOffsetUnit;
    target.CycleLimit = this.CycleLimit;
    target.SharedSkipCounters = this.SharedSkipCounters;
    target.SharedLostCounters = this.SharedLostCounters;
    target.ReschedulingByEstimate = this.ReschedulingByEstimate;
    target.IncreaseVisitNumberBasePerCycle = this.IncreaseVisitNumberBasePerCycle;
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
  public virtual ResearchStudyDefinitionEntity ResearchStudy { get; set; }

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

public class SubStudyEntity {

  /// <summary> *this field has a max length of 50 </summary>
  [MaxLength(50), Required]
  public String SubStudyName { get; set; }

  /// <summary> *this field has a max length of 100 </summary>
  [MaxLength(100), Required]
  public String StudyWorkflowName { get; set; }

  /// <summary> *this field has a max length of 20 </summary>
  [MaxLength(20), Required]
  public String StudyWorkflowVersion { get; set; }

  [Principal]
  public virtual ResearchStudyDefinitionEntity ResearchStudyDefinition { get; set; }

#region Mapping

  internal static Expression<Func<SubStudy, SubStudyEntity>> SubStudyEntitySelector = ((SubStudy src) => new SubStudyEntity {
    SubStudyName = src.SubStudyName,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
  });

  internal static Expression<Func<SubStudyEntity, SubStudy>> SubStudySelector = ((SubStudyEntity src) => new SubStudy {
    SubStudyName = src.SubStudyName,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
  });

  internal void CopyContentFrom(SubStudy source, Func<String,bool> onFixedValueChangingCallback = null){
    this.SubStudyName = source.SubStudyName;
    this.StudyWorkflowName = source.StudyWorkflowName;
    this.StudyWorkflowVersion = source.StudyWorkflowVersion;
  }

  internal void CopyContentTo(SubStudy target, Func<String,bool> onFixedValueChangingCallback = null){
    target.SubStudyName = this.SubStudyName;
    target.StudyWorkflowName = this.StudyWorkflowName;
    target.StudyWorkflowVersion = this.StudyWorkflowVersion;
  }

#endregion

}

public class TaskCycleDefinitionEntity {

  [Required]
  public Guid TaskScheduleId { get; set; } = Guid.NewGuid();

  /// <summary> 0=InducementOfScheduleOrCycle: when the start of the last cycle was induced / -1=InducementOfPredessessor: when the last task or subschedule (based on the 'Position') of the previous cycle was induced.
  /// *items of sub-schedules are not relevant - when addressing a sub-schedule as predecessor, then only its entry will be used
  /// *this behaviour can be concretized via 'ReschedulingByEstimate' </summary>
  [Required]
  public Int32 ReschedulingOffsetFixpoint { get; set; }

  /// <summary> estimated scheduling time relative to the ReschedulingBase </summary>
  [Required]
  public Int32 ReschedulingOffset { get; set; }

  /// <summary> 'h'=Hours / 'm'=Minutes / 's'=Seconds </summary>
  [Required]
  public String ReschedulingOffsetUnit { get; set; }

  /// <summary> number of cycles (of null for a infinite number of cycles) *this field is optional </summary>
  public Nullable<Int32> CycleLimit { get; set; }

  [Required]
  public Boolean SharedSkipCounters { get; set; }

  [Required]
  public Boolean SharedLostCounters { get; set; }

  /// <summary> If set to true, the offset calculation will be based on the ESTIMATED completion of the predecessor (see 'Fixpoint'). Otherwise, when set to false, the offset calculation will be based on the REAL completion (if recorded execution data is available during calculation) of the predecessor. *this will not evaluated, when the 'Fixpoint' is set to 0! </summary>
  [Required]
  public Boolean ReschedulingByEstimate { get; set; }

  /// <summary> -1: automatic, based on the usage of task numbers within the schedule </summary>
  [Required]
  public Int32 IncreaseTaskNumberBasePerCycle { get; set; }

  [Principal]
  public virtual TaskScheduleEntity TaskSchedule { get; set; }

#region Mapping

  internal static Expression<Func<TaskCycleDefinition, TaskCycleDefinitionEntity>> TaskCycleDefinitionEntitySelector = ((TaskCycleDefinition src) => new TaskCycleDefinitionEntity {
    TaskScheduleId = src.TaskScheduleId,
    ReschedulingOffsetFixpoint = src.ReschedulingOffsetFixpoint,
    ReschedulingOffset = src.ReschedulingOffset,
    ReschedulingOffsetUnit = src.ReschedulingOffsetUnit,
    CycleLimit = src.CycleLimit,
    SharedSkipCounters = src.SharedSkipCounters,
    SharedLostCounters = src.SharedLostCounters,
    ReschedulingByEstimate = src.ReschedulingByEstimate,
    IncreaseTaskNumberBasePerCycle = src.IncreaseTaskNumberBasePerCycle,
  });

  internal static Expression<Func<TaskCycleDefinitionEntity, TaskCycleDefinition>> TaskCycleDefinitionSelector = ((TaskCycleDefinitionEntity src) => new TaskCycleDefinition {
    TaskScheduleId = src.TaskScheduleId,
    ReschedulingOffsetFixpoint = src.ReschedulingOffsetFixpoint,
    ReschedulingOffset = src.ReschedulingOffset,
    ReschedulingOffsetUnit = src.ReschedulingOffsetUnit,
    CycleLimit = src.CycleLimit,
    SharedSkipCounters = src.SharedSkipCounters,
    SharedLostCounters = src.SharedLostCounters,
    ReschedulingByEstimate = src.ReschedulingByEstimate,
    IncreaseTaskNumberBasePerCycle = src.IncreaseTaskNumberBasePerCycle,
  });

  internal void CopyContentFrom(TaskCycleDefinition source, Func<String,bool> onFixedValueChangingCallback = null){
    this.TaskScheduleId = source.TaskScheduleId;
    this.ReschedulingOffsetFixpoint = source.ReschedulingOffsetFixpoint;
    this.ReschedulingOffset = source.ReschedulingOffset;
    this.ReschedulingOffsetUnit = source.ReschedulingOffsetUnit;
    this.CycleLimit = source.CycleLimit;
    this.SharedSkipCounters = source.SharedSkipCounters;
    this.SharedLostCounters = source.SharedLostCounters;
    this.ReschedulingByEstimate = source.ReschedulingByEstimate;
    this.IncreaseTaskNumberBasePerCycle = source.IncreaseTaskNumberBasePerCycle;
  }

  internal void CopyContentTo(TaskCycleDefinition target, Func<String,bool> onFixedValueChangingCallback = null){
    target.TaskScheduleId = this.TaskScheduleId;
    target.ReschedulingOffsetFixpoint = this.ReschedulingOffsetFixpoint;
    target.ReschedulingOffset = this.ReschedulingOffset;
    target.ReschedulingOffsetUnit = this.ReschedulingOffsetUnit;
    target.CycleLimit = this.CycleLimit;
    target.SharedSkipCounters = this.SharedSkipCounters;
    target.SharedLostCounters = this.SharedLostCounters;
    target.ReschedulingByEstimate = this.ReschedulingByEstimate;
    target.IncreaseTaskNumberBasePerCycle = this.IncreaseTaskNumberBasePerCycle;
  }

#endregion

}

}
