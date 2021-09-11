# ORSCF-StudyWorkflowDefinition Schema Specification

|          | Info                                    |
|----------|-----------------------------------------|
|author:   |[ORSCF](https://www.orscf.org) ("Open Research Study Communication Formats") / T.Korn|
|license:  |[Apache-2](https://choosealicense.com/licenses/apache-2.0/)|
|version:  |1.5.0|
|timestamp:|2021-08-04 12:40|

### Contents

  * .  [ResearchStudyDefinition](#ResearchStudyDefinition)
  * ........\  [Arm](#Arm)
  * ........\  [DataRecordingTaskDefinition](#DataRecordingTaskDefinition)
  * ........\  [DrugApplymentTaskDefinition](#DrugApplymentTaskDefinition)
  * ........\  [ProcedureDefinition](#ProcedureDefinition)
  * ........\  [ProcedureSchedule](#ProcedureSchedule)
  * ................\  [InducedProcedure](#InducedProcedure)
  * ................\  [InducedSubProcedureSchedule](#InducedSubProcedureSchedule)
  * ................\  [ProcedureCycleDefinition](#ProcedureCycleDefinition)
  * ........\  [StudyEvent](#StudyEvent)
  * ........\  [SubStudy](#SubStudy)
  * ........\  [TaskSchedule](#TaskSchedule)
  * ................\  [InducedDataRecordingTask](#InducedDataRecordingTask)
  * ................\  [InducedDrugApplymentTask](#InducedDrugApplymentTask)
  * ................\  [InducedSubTaskSchedule](#InducedSubTaskSchedule)
  * ................\  [InducedTreatmentTask](#InducedTreatmentTask)
  * ................\  [TaskCycleDefinition](#TaskCycleDefinition)
  * ........\  [TreatmentTaskDefinition](#TreatmentTaskDefinition)

# Model:

![chart](./chart.png)



## ResearchStudyDefinition


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [StudyWorkflowName](#ResearchStudyDefinitionStudyWorkflowName-Field) **(PK)** | *string* (100) | YES | no |
| [StudyWorkflowVersion](#ResearchStudyDefinitionStudyWorkflowVersion-Field) **(PK)** | *string* (20) | YES | no |
| OfficialLabel | *string* | YES | no |
| DefinitionOwner | *string* | YES | no |
| DocumentationUrl | *string* | YES | no |
| [LogoImage](#ResearchStudyDefinitionLogoImage-Field) | *string* | no | no |
| Description | *string* | YES | no |
| [VersionIdentity](#ResearchStudyDefinitionVersionIdentity-Field) | *string* | YES | no |
| LastChangeUtc | *datetime* | YES | no |
| [DraftState](#ResearchStudyDefinitionDraftState-Field) | *int32* | YES | no |
| [BillingCurrency](#ResearchStudyDefinitionBillingCurrency-Field) | *string* | no | no |
| [BillablePriceForGeneralPreparation](#ResearchStudyDefinitionBillablePriceForGeneralPreparation-Field) | *decimal* | no | no |
| [StudyDocumentationUrl](#ResearchStudyDefinitionStudyDocumentationUrl-Field) | *string* | no | no |
| [CaseReportFormUrl](#ResearchStudyDefinitionCaseReportFormUrl-Field) | *string* | no | no |
#### Unique Keys
* StudyWorkflowName + StudyWorkflowVersion **(primary)**

#### ResearchStudyDefinition.**StudyWorkflowName** (Field)

the official invariant name of the study as given by the sponsor

* this field represents the identity (PK) of the record
* the maximum length of the content within this field is 100 characters.

#### ResearchStudyDefinition.**StudyWorkflowVersion** (Field)

This value follows the rules of 'Semantic Versioning' (https://semver.org) and needs to be updated exactly and only on transition to DraftState.Released! If the previously DraftState was 'DraftNewFix', then the 3. number must be increased at this time! If the previously DraftState was 'DraftNewMinor', then the 2. number must be increased, and the 3. number must be set to 0 at this time! If the previously DraftState was 'DraftNewMajor', then the 1. number must be increased, and the 2.+3. number must be set to 0 at this time!

* this field represents the identity (PK) of the record
* the maximum length of the content within this field is 20 characters.

#### ResearchStudyDefinition.**LogoImage** (Field)

Logo in base64

* this field is optional, so that '*null*' values are supported

#### ResearchStudyDefinition.**VersionIdentity** (Field)

IT MUST NOT be updated on every change during Draft! Format: the Author, which is starting the new Draft (Alphanumeric, in PascalCase without blanks or other Symbols) + the current UTC-Time when setting the value (in ISO8601 format) separated by a Pipe "|" Sample: "MaxMustermann|2020-06-15T13:45:30.0000000Z".


#### ResearchStudyDefinition.**DraftState** (Field)

0=Released / 1=DraftNewFix / 2=DraftNewMinor / 3=DraftNewMajor


#### ResearchStudyDefinition.**BillingCurrency** (Field)
* this field is optional, so that '*null*' values are supported

#### ResearchStudyDefinition.**BillablePriceForGeneralPreparation** (Field)
* this field is optional, so that '*null*' values are supported

#### ResearchStudyDefinition.**StudyDocumentationUrl** (Field)
* this field is optional, so that '*null*' values are supported

#### ResearchStudyDefinition.**CaseReportFormUrl** (Field)
* this field is optional, so that '*null*' values are supported


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [Arms](#Arms-childs-of-this-ResearchStudyDefinition) | Childs | [Arm](#Arm) | * (multiple) |
| [DataRecordingTasks](#DataRecordingTasks-childs-of-this-ResearchStudyDefinition) | Childs | [DataRecordingTaskDefinition](#DataRecordingTaskDefinition) | * (multiple) |
| [DrugApplymentTasks](#DrugApplymentTasks-childs-of-this-ResearchStudyDefinition) | Childs | [DrugApplymentTaskDefinition](#DrugApplymentTaskDefinition) | * (multiple) |
| [ProcedureDefinitions](#ProcedureDefinitions-childs-of-this-ResearchStudyDefinition) | Childs | [ProcedureDefinition](#ProcedureDefinition) | * (multiple) |
| [ProcedureSchedules](#ProcedureSchedules-childs-of-this-ResearchStudyDefinition) | Childs | [ProcedureSchedule](#ProcedureSchedule) | * (multiple) |
| [TreatmentTasks](#TreatmentTasks-childs-of-this-ResearchStudyDefinition) | Childs | [TreatmentTaskDefinition](#TreatmentTaskDefinition) | * (multiple) |
| [TaskSchedules](#TaskSchedules-childs-of-this-ResearchStudyDefinition) | Childs | [TaskSchedule](#TaskSchedule) | * (multiple) |
| [Events](#Events-childs-of-this-ResearchStudyDefinition) | Childs | [StudyEvent](#StudyEvent) | * (multiple) |
| [SubStudies](#SubStudies-childs-of-this-ResearchStudyDefinition) | Childs | [SubStudy](#SubStudy) | * (multiple) |

##### **Arms** (childs of this ResearchStudyDefinition)
Target: [Arm](#Arm)
##### **DataRecordingTasks** (childs of this ResearchStudyDefinition)
Target: [DataRecordingTaskDefinition](#DataRecordingTaskDefinition)
##### **DrugApplymentTasks** (childs of this ResearchStudyDefinition)
Target: [DrugApplymentTaskDefinition](#DrugApplymentTaskDefinition)
##### **ProcedureDefinitions** (childs of this ResearchStudyDefinition)
Target: [ProcedureDefinition](#ProcedureDefinition)
##### **ProcedureSchedules** (childs of this ResearchStudyDefinition)
Target: [ProcedureSchedule](#ProcedureSchedule)
##### **TreatmentTasks** (childs of this ResearchStudyDefinition)
Target: [TreatmentTaskDefinition](#TreatmentTaskDefinition)
##### **TaskSchedules** (childs of this ResearchStudyDefinition)
Target: [TaskSchedule](#TaskSchedule)
##### **Events** (childs of this ResearchStudyDefinition)
Target: [StudyEvent](#StudyEvent)
##### **SubStudies** (childs of this ResearchStudyDefinition)
Target: [SubStudy](#SubStudy)




## Arm


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [StudyArmName](#ArmStudyArmName-Field) **(PK)** | *string* (50) | YES | no |
| [StudyWorkflowName](#ArmStudyWorkflowName-Field) **(PK)** (FK) | *string* (100) | YES | no |
| [StudyWorkflowVersion](#ArmStudyWorkflowVersion-Field) **(PK)** (FK) | *string* (20) | YES | no |
| [RootProcedureScheduleId](#ArmRootProcedureScheduleId-Field) (FK) | *guid* | no | no |
| [BillablePriceOnFailedInclusion](#ArmBillablePriceOnFailedInclusion-Field) | *decimal* | no | no |
| [BillablePriceOnSuccessfullInclusion](#ArmBillablePriceOnSuccessfullInclusion-Field) | *decimal* | no | no |
| [BillablePriceOnAbortedParticipation](#ArmBillablePriceOnAbortedParticipation-Field) | *decimal* | no | no |
| [BillablePriceOnCompletedParticipation](#ArmBillablePriceOnCompletedParticipation-Field) | *decimal* | no | no |
| [ArmSpecificDocumentationUrl](#ArmArmSpecificDocumentationUrl-Field) | *string* | no | no |
| [InclusionCriteria](#ArmInclusionCriteria-Field) | *string* | no | no |
| [AllowedSubstudies](#ArmAllowedSubstudies-Field) | *string* | no | no |
#### Unique Keys
* StudyArmName + StudyWorkflowName + StudyWorkflowVersion **(primary)**

#### Arm.**StudyArmName** (Field)

Name of the Arm - INVARIANT! because it is used to generate Identifers for induced executions!

* this field represents the identity (PK) of the record
* the maximum length of the content within this field is 50 characters.

#### Arm.**StudyWorkflowName** (Field)
* this field represents the identity (PK) of the record
* this field is used as foreign key to address the related 'ResearchStudy'
* the maximum length of the content within this field is 100 characters.

#### Arm.**StudyWorkflowVersion** (Field)
* this field represents the identity (PK) of the record
* this field is used as foreign key to address the related 'ResearchStudy'
* the maximum length of the content within this field is 20 characters.

#### Arm.**RootProcedureScheduleId** (Field)

the ProcedureSchedule which is representing the primary-/entry-workflow (estimated visits) for participants of this arm

* this field is optional, so that '*null*' values are supported
* this field is used as foreign key to address the related 'RootProcedureSchedule'

#### Arm.**BillablePriceOnFailedInclusion** (Field)
* this field is optional, so that '*null*' values are supported

#### Arm.**BillablePriceOnSuccessfullInclusion** (Field)
* this field is optional, so that '*null*' values are supported

#### Arm.**BillablePriceOnAbortedParticipation** (Field)
* this field is optional, so that '*null*' values are supported

#### Arm.**BillablePriceOnCompletedParticipation** (Field)
* this field is optional, so that '*null*' values are supported

#### Arm.**ArmSpecificDocumentationUrl** (Field)
* this field is optional, so that '*null*' values are supported

#### Arm.**InclusionCriteria** (Field)
* this field is optional, so that '*null*' values are supported

#### Arm.**AllowedSubstudies** (Field)

comma sparated list of Sub-Study names which are allowed to be executed for this arm


* this field is optional, so that '*null*' values are supported


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [ResearchStudy](#ResearchStudy-parent-of-this-Arm) | Parent | [ResearchStudyDefinition](#ResearchStudyDefinition) | 0/1 (optional) |
| [RootProcedureSchedule](#RootProcedureSchedule-lookup-from-this-Arm) | Lookup | [ProcedureSchedule](#ProcedureSchedule) | 1 (required) |

##### **ResearchStudy** (parent of this Arm)
Target Type: [ResearchStudyDefinition](#ResearchStudyDefinition)
Addressed by: [StudyWorkflowName](#ArmStudyWorkflowName-Field) + [StudyWorkflowVersion](#ArmStudyWorkflowVersion-Field).
##### **RootProcedureSchedule** (lookup from this Arm)
Target Type: [ProcedureSchedule](#ProcedureSchedule)
Addressed by: [RootProcedureScheduleId](#ArmRootProcedureScheduleId-Field).

the ProcedureSchedule which is representing the primary-/entry-workflow (estimated visits) for participants of this arm





## DataRecordingTaskDefinition


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [TaskDefinitionName](#DataRecordingTaskDefinitionTaskDefinitionName-Field) **(PK)** | *string* (50) | YES | no |
| [StudyWorkflowName](#DataRecordingTaskDefinitionStudyWorkflowName-Field) (FK) | *string* (100) | YES | no |
| [StudyWorkflowVersion](#DataRecordingTaskDefinitionStudyWorkflowVersion-Field) (FK) | *string* (20) | YES | no |
| [BillablePriceOnCompletedExecution](#DataRecordingTaskDefinitionBillablePriceOnCompletedExecution-Field) | *decimal* | no | no |
| ShortDescription | *string* | YES | no |
| [TaskSpecificDocumentationUrl](#DataRecordingTaskDefinitionTaskSpecificDocumentationUrl-Field) | *string* | no | no |
| [ImportantNotices](#DataRecordingTaskDefinitionImportantNotices-Field) | *string* | no | no |
| [DataSchemaUrl](#DataRecordingTaskDefinitionDataSchemaUrl-Field) | *string* | YES | no |
| [DefaultData](#DataRecordingTaskDefinitionDefaultData-Field) | *string* | no | no |
#### Unique Keys
* TaskDefinitionName **(primary)**

#### DataRecordingTaskDefinition.**TaskDefinitionName** (Field)

Name of the Definition - INVARIANT! because it is used to generate Identifers for induced executions!

* this field represents the identity (PK) of the record
* the maximum length of the content within this field is 50 characters.

#### DataRecordingTaskDefinition.**StudyWorkflowName** (Field)
* this field is used as foreign key to address the related 'ResearchStudy'
* the maximum length of the content within this field is 100 characters.

#### DataRecordingTaskDefinition.**StudyWorkflowVersion** (Field)
* this field is used as foreign key to address the related 'ResearchStudy'
* the maximum length of the content within this field is 20 characters.

#### DataRecordingTaskDefinition.**BillablePriceOnCompletedExecution** (Field)
* this field is optional, so that '*null*' values are supported

#### DataRecordingTaskDefinition.**TaskSpecificDocumentationUrl** (Field)
* this field is optional, so that '*null*' values are supported

#### DataRecordingTaskDefinition.**ImportantNotices** (Field)
* this field is optional, so that '*null*' values are supported

#### DataRecordingTaskDefinition.**DataSchemaUrl** (Field)

schema-url of the data which have to be recorded


#### DataRecordingTaskDefinition.**DefaultData** (Field)

RAW data, in the schema as defined at the 'DataSchemaUrl'

* this field is optional, so that '*null*' values are supported


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [Inducements](#Inducements-refering-to-this-DataRecordingTaskDefinition) | Referers | [InducedDataRecordingTask](#InducedDataRecordingTask) | * (multiple) |
| [ResearchStudy](#ResearchStudy-parent-of-this-DataRecordingTaskDefinition) | Parent | [ResearchStudyDefinition](#ResearchStudyDefinition) | 0/1 (optional) |

##### **Inducements** (refering to this DataRecordingTaskDefinition)
Target: [InducedDataRecordingTask](#InducedDataRecordingTask)
##### **ResearchStudy** (parent of this DataRecordingTaskDefinition)
Target Type: [ResearchStudyDefinition](#ResearchStudyDefinition)
Addressed by: [StudyWorkflowName](#DataRecordingTaskDefinitionStudyWorkflowName-Field) + [StudyWorkflowVersion](#DataRecordingTaskDefinitionStudyWorkflowVersion-Field).




## DrugApplymentTaskDefinition


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [TaskDefinitionName](#DrugApplymentTaskDefinitionTaskDefinitionName-Field) **(PK)** | *string* (50) | YES | no |
| [StudyWorkflowName](#DrugApplymentTaskDefinitionStudyWorkflowName-Field) (FK) | *string* (100) | YES | no |
| [StudyWorkflowVersion](#DrugApplymentTaskDefinitionStudyWorkflowVersion-Field) (FK) | *string* (20) | YES | no |
| [BillablePriceOnCompletedExecution](#DrugApplymentTaskDefinitionBillablePriceOnCompletedExecution-Field) | *decimal* | no | no |
| ShortDescription | *string* | YES | no |
| [TaskSpecificDocumentationUrl](#DrugApplymentTaskDefinitionTaskSpecificDocumentationUrl-Field) | *string* | no | no |
| DrugName | *string* | YES | no |
| DrugDoseMgPerUnitMg | *decimal* | YES | no |
| UnitsToApply | *decimal* | YES | no |
| ApplymentRoute | *string* | YES | no |
| [ImportantNotices](#DrugApplymentTaskDefinitionImportantNotices-Field) | *string* | no | no |
#### Unique Keys
* TaskDefinitionName **(primary)**

#### DrugApplymentTaskDefinition.**TaskDefinitionName** (Field)

Name of the Definition - INVARIANT! because it is used to generate Identifers for induced executions!

* this field represents the identity (PK) of the record
* the maximum length of the content within this field is 50 characters.

#### DrugApplymentTaskDefinition.**StudyWorkflowName** (Field)
* this field is used as foreign key to address the related 'ResearchStudy'
* the maximum length of the content within this field is 100 characters.

#### DrugApplymentTaskDefinition.**StudyWorkflowVersion** (Field)
* this field is used as foreign key to address the related 'ResearchStudy'
* the maximum length of the content within this field is 20 characters.

#### DrugApplymentTaskDefinition.**BillablePriceOnCompletedExecution** (Field)
* this field is optional, so that '*null*' values are supported

#### DrugApplymentTaskDefinition.**TaskSpecificDocumentationUrl** (Field)
* this field is optional, so that '*null*' values are supported

#### DrugApplymentTaskDefinition.**ImportantNotices** (Field)
* this field is optional, so that '*null*' values are supported


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [Inducements](#Inducements-refering-to-this-DrugApplymentTaskDefinition) | Referers | [InducedDrugApplymentTask](#InducedDrugApplymentTask) | * (multiple) |
| [ResearchStudy](#ResearchStudy-parent-of-this-DrugApplymentTaskDefinition) | Parent | [ResearchStudyDefinition](#ResearchStudyDefinition) | 0/1 (optional) |

##### **Inducements** (refering to this DrugApplymentTaskDefinition)
Target: [InducedDrugApplymentTask](#InducedDrugApplymentTask)
##### **ResearchStudy** (parent of this DrugApplymentTaskDefinition)
Target Type: [ResearchStudyDefinition](#ResearchStudyDefinition)
Addressed by: [StudyWorkflowName](#DrugApplymentTaskDefinitionStudyWorkflowName-Field) + [StudyWorkflowVersion](#DrugApplymentTaskDefinitionStudyWorkflowVersion-Field).




## ProcedureDefinition


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [ProdecureDefinitionName](#ProcedureDefinitionProdecureDefinitionName-Field) **(PK)** | *string* (50) | YES | no |
| [StudyWorkflowName](#ProcedureDefinitionStudyWorkflowName-Field) (FK) | *string* (100) | YES | no |
| [StudyWorkflowVersion](#ProcedureDefinitionStudyWorkflowVersion-Field) (FK) | *string* (20) | YES | no |
| [RootTaskScheduleId](#ProcedureDefinitionRootTaskScheduleId-Field) (FK) | *guid* | no | no |
| [BillablePriceOnAbortedExecution](#ProcedureDefinitionBillablePriceOnAbortedExecution-Field) | *decimal* | no | no |
| [BillablePriceOnCompletedExecution](#ProcedureDefinitionBillablePriceOnCompletedExecution-Field) | *decimal* | no | no |
| [VisitSpecificDocumentationUrl](#ProcedureDefinitionVisitSpecificDocumentationUrl-Field) | *string* | no | no |
#### Unique Keys
* ProdecureDefinitionName **(primary)**

#### ProcedureDefinition.**ProdecureDefinitionName** (Field)

Name of the Definition - INVARIANT! because it is used to generate Identifers for induced executions!

* this field represents the identity (PK) of the record
* the maximum length of the content within this field is 50 characters.

#### ProcedureDefinition.**StudyWorkflowName** (Field)
* this field is used as foreign key to address the related 'ResearchStudy'
* the maximum length of the content within this field is 100 characters.

#### ProcedureDefinition.**StudyWorkflowVersion** (Field)
* this field is used as foreign key to address the related 'ResearchStudy'
* the maximum length of the content within this field is 20 characters.

#### ProcedureDefinition.**RootTaskScheduleId** (Field)

the TaskSchedule which is representing the primary-/entry-workflow (estimated tasks) when executing this visit

* this field is optional, so that '*null*' values are supported
* this field is used as foreign key to address the related 'RootTaskSchedule'

#### ProcedureDefinition.**BillablePriceOnAbortedExecution** (Field)
* this field is optional, so that '*null*' values are supported

#### ProcedureDefinition.**BillablePriceOnCompletedExecution** (Field)
* this field is optional, so that '*null*' values are supported

#### ProcedureDefinition.**VisitSpecificDocumentationUrl** (Field)
* this field is optional, so that '*null*' values are supported


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [Inducements](#Inducements-refering-to-this-ProcedureDefinition) | Referers | [InducedProcedure](#InducedProcedure) | * (multiple) |
| [ResearchStudy](#ResearchStudy-parent-of-this-ProcedureDefinition) | Parent | [ResearchStudyDefinition](#ResearchStudyDefinition) | 0/1 (optional) |
| [RootTaskSchedule](#RootTaskSchedule-lookup-from-this-ProcedureDefinition) | Lookup | [TaskSchedule](#TaskSchedule) | 1 (required) |

##### **Inducements** (refering to this ProcedureDefinition)
Target: [InducedProcedure](#InducedProcedure)
##### **ResearchStudy** (parent of this ProcedureDefinition)
Target Type: [ResearchStudyDefinition](#ResearchStudyDefinition)
Addressed by: [StudyWorkflowName](#ProcedureDefinitionStudyWorkflowName-Field) + [StudyWorkflowVersion](#ProcedureDefinitionStudyWorkflowVersion-Field).
##### **RootTaskSchedule** (lookup from this ProcedureDefinition)
Target Type: [TaskSchedule](#TaskSchedule)
Addressed by: [RootTaskScheduleId](#ProcedureDefinitionRootTaskScheduleId-Field).

the TaskSchedule which is representing the primary-/entry-workflow (estimated tasks) when executing this visit





## ProcedureSchedule


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [ProcedureScheduleId](#ProcedureScheduleProcedureScheduleId-Field) **(PK)** | *guid* | YES | no |
| [StudyWorkflowName](#ProcedureScheduleStudyWorkflowName-Field) (FK) | *string* (100) | YES | no |
| [StudyWorkflowVersion](#ProcedureScheduleStudyWorkflowVersion-Field) (FK) | *string* (20) | YES | no |
| [ScheduleWorkflowName](#ProcedureScheduleScheduleWorkflowName-Field) | *string* | YES | no |
| MaxSkipsBeforeLost | *string* | YES | no |
| MaxSubsequentSkipsBeforeLost | *string* | YES | no |
| MaxLostsBeforeLtfuAbort | *string* | YES | no |
| MaxSubsequentLostsBeforeLtfuAbort | *string* | YES | no |
| EventOnLtfuAbort | *string* | YES | no |
| EventOnCycleEnded | *string* | YES | no |
| EventOnAllCyclesEnded | *string* | YES | no |
| InducingEvents | *string* | YES | no |
| AbortCausingEvents | *string* | YES | no |
#### Unique Keys
* ProcedureScheduleId **(primary)**

#### ProcedureSchedule.**ProcedureScheduleId** (Field)
* this field represents the identity (PK) of the record

#### ProcedureSchedule.**StudyWorkflowName** (Field)
* this field is used as foreign key to address the related 'ResearchStudy'
* the maximum length of the content within this field is 100 characters.

#### ProcedureSchedule.**StudyWorkflowVersion** (Field)
* this field is used as foreign key to address the related 'ResearchStudy'
* the maximum length of the content within this field is 20 characters.

#### ProcedureSchedule.**ScheduleWorkflowName** (Field)

Name of the Workflow which is represented by this schedule - INVARIANT! because it is used to generate Identifers for induced executions!



### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [EntryArms](#EntryArms-refering-to-this-ProcedureSchedule) | Referers | [Arm](#Arm) | * (multiple) |
| [InducedProcedures](#InducedProcedures-childs-of-this-ProcedureSchedule) | Childs | [InducedProcedure](#InducedProcedure) | * (multiple) |
| [InducedSubProcedureSchedules](#InducedSubProcedureSchedules-childs-of-this-ProcedureSchedule) | Childs | [InducedSubProcedureSchedule](#InducedSubProcedureSchedule) | * (multiple) |
| [InducingSubProcedureSchedules](#InducingSubProcedureSchedules-refering-to-this-ProcedureSchedule) | Referers | [InducedSubProcedureSchedule](#InducedSubProcedureSchedule) | * (multiple) |
| [CycleDefinition](#CycleDefinition-child-of-this-ProcedureSchedule) | Child | [ProcedureCycleDefinition](#ProcedureCycleDefinition) | 0/1 (single) |
| [ResearchStudy](#ResearchStudy-parent-of-this-ProcedureSchedule) | Parent | [ResearchStudyDefinition](#ResearchStudyDefinition) | 0/1 (optional) |

##### **EntryArms** (refering to this ProcedureSchedule)
Target: [Arm](#Arm)
##### **InducedProcedures** (childs of this ProcedureSchedule)
Target: [InducedProcedure](#InducedProcedure)
##### **InducedSubProcedureSchedules** (childs of this ProcedureSchedule)
Target: [InducedSubProcedureSchedule](#InducedSubProcedureSchedule)
##### **InducingSubProcedureSchedules** (refering to this ProcedureSchedule)
Target: [InducedSubProcedureSchedule](#InducedSubProcedureSchedule)
##### **CycleDefinition** (child of this ProcedureSchedule)
Target: [ProcedureCycleDefinition](#ProcedureCycleDefinition)
##### **ResearchStudy** (parent of this ProcedureSchedule)
Target Type: [ResearchStudyDefinition](#ResearchStudyDefinition)
Addressed by: [StudyWorkflowName](#ProcedureScheduleStudyWorkflowName-Field) + [StudyWorkflowVersion](#ProcedureScheduleStudyWorkflowVersion-Field).




## InducedProcedure


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [Id](#InducedProcedureId-Field) **(PK)** | *guid* | YES | no |
| [ProcedureScheduleId](#InducedProcedureProcedureScheduleId-Field) (FK) | *guid* | YES | no |
| [SchedulingOffset](#InducedProcedureSchedulingOffset-Field) | *int32* | YES | no |
| [SchedulingOffsetUnit](#InducedProcedureSchedulingOffsetUnit-Field) | *string* | YES | no |
| [SchedulingVariabilityBefore](#InducedProcedureSchedulingVariabilityBefore-Field) | *int32* | YES | no |
| [SchedulingVariabilityAfter](#InducedProcedureSchedulingVariabilityAfter-Field) | *int32* | YES | no |
| [SchedulingVariabilityUnit](#InducedProcedureSchedulingVariabilityUnit-Field) | *string* | YES | no |
| [ProdecureDefinitionName](#InducedProcedureProdecureDefinitionName-Field) (FK) | *string* (50) | YES | no |
| [UniqueExecutionName](#InducedProcedureUniqueExecutionName-Field) | *string* | YES | no |
| [Skipable](#InducedProcedureSkipable-Field) | *boolean* | YES | no |
| EventOnSkip | *string* | YES | no |
| EventOnLost | *string* | YES | no |
| [Position](#InducedProcedurePosition-Field) | *int32* | YES | no |
| [SchedulingOffsetFixpoint](#InducedProcedureSchedulingOffsetFixpoint-Field) | *int32* | YES | no |
| [SchedulingByEstimate](#InducedProcedureSchedulingByEstimate-Field) | *boolean* | YES | no |
| [DedicatedToSubstudy](#InducedProcedureDedicatedToSubstudy-Field) | *string* | no | no |
| [VisitNumber](#InducedProcedureVisitNumber-Field) | *int32* | YES | no |
#### Unique Keys
* Id **(primary)**

#### InducedProcedure.**Id** (Field)
* this field represents the identity (PK) of the record

#### InducedProcedure.**ProcedureScheduleId** (Field)
* this field is used as foreign key to address the related 'ProcedureSchedule'

#### InducedProcedure.**SchedulingOffset** (Field)

estimated scheduling date relative to the scheduling date of the parent ProcedureSchedule


#### InducedProcedure.**SchedulingOffsetUnit** (Field)

'M'=Months / 'W'=Weeks / 'D'=Days


#### InducedProcedure.**SchedulingVariabilityBefore** (Field)

defines an additional variability RELATIVE to the estimated scheduling date (which is calculated from the offset), in this case the EARLIEST possible date.


#### InducedProcedure.**SchedulingVariabilityAfter** (Field)

defines an additional variability RELATIVE to the estimated scheduling date (which is calculated from the offset), in this case the LATEST possible date.


#### InducedProcedure.**SchedulingVariabilityUnit** (Field)

'M'=Months / 'W'=Weeks / 'D'=Days


#### InducedProcedure.**ProdecureDefinitionName** (Field)
* this field is used as foreign key to address the related 'InducedVisitProdecure'
* the maximum length of the content within this field is 50 characters.

#### InducedProcedure.**UniqueExecutionName** (Field)

the name for the induced execution (=VISIT), like 'V0', which is usually defined by the study protocol. if multiple inducements are possible (for example when using cycles), the title should to contain a placeholder (example: 'C{cy}-V0') to prevent from duplicate execution names.


#### InducedProcedure.**Skipable** (Field)

defines, if the study protocol tolerates this execution to be 'skipped' (if not, a missed execution is treated as 'lost' and can cause the exclusion of the participant)


#### InducedProcedure.**Position** (Field)

The Position (1..x) of this inducement within the parent schedule. This value is relevant for addressing predecessors as fixpoint for the offest-calculation. Within one schedule there can only be one inducement for each position! The 0 is reserved for addressing the parent schedule itself and must not be used as well as negative values!


#### InducedProcedure.**SchedulingOffsetFixpoint** (Field)

0=InducementOfScheduleOrCycle: when the start of the parent Schedule (for the current cycle) was induced / -1=InducementOfPredessessor: when the direct predecessor procedure or subschedule (based on the 'Position') within the current schedule was induced / 1..x: when the predecessor at the Position within the current schedule, ADRESSED by the given value, was induced 
*items of sub-schedules are not relevant - when addressing a sub-schedule as predecessor, then only its entry will be used
*this behaviour can be concretized via 'SchedulingByEstimate'


#### InducedProcedure.**SchedulingByEstimate** (Field)

If set to true, the offset calculation will be based on the ESTIMATED completion of the predecessor (see 'Fixpoint'). Otherwise, when set to false, the offset calculation will be based on the REAL completion (if recorded execution data is available during calculation) of the predecessor. *this will not evaluated, when the 'Fixpoint' is set to 0!


#### InducedProcedure.**DedicatedToSubstudy** (Field)

The name of a Sub-Study for which this procedure should be induced or empty when its part of the current Arms regular workflow 

* this field is optional, so that '*null*' values are supported

#### InducedProcedure.**VisitNumber** (Field)

Number, which can be used via Placeholder {#} within the UniqueExecutionName and which will automatically increase when using cycles or sub-schedules



### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [ProcedureSchedule](#ProcedureSchedule-parent-of-this-InducedProcedure) | Parent | [ProcedureSchedule](#ProcedureSchedule) | 0/1 (optional) |
| [InducedVisitProdecure](#InducedVisitProdecure-lookup-from-this-InducedProcedure) | Lookup | [ProcedureDefinition](#ProcedureDefinition) | 0/1 (optional) |

##### **ProcedureSchedule** (parent of this InducedProcedure)
Target Type: [ProcedureSchedule](#ProcedureSchedule)
Addressed by: [ProcedureScheduleId](#InducedProcedureProcedureScheduleId-Field).
##### **InducedVisitProdecure** (lookup from this InducedProcedure)
Target Type: [ProcedureDefinition](#ProcedureDefinition)
Addressed by: [ProdecureDefinitionName](#InducedProcedureProdecureDefinitionName-Field).




## InducedSubProcedureSchedule


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [Id](#InducedSubProcedureScheduleId-Field) **(PK)** | *guid* | YES | no |
| [ParentProcedureScheduleId](#InducedSubProcedureScheduleParentProcedureScheduleId-Field) (FK) | *guid* | YES | no |
| [InducedProcedureScheduleId](#InducedSubProcedureScheduleInducedProcedureScheduleId-Field) (FK) | *guid* | YES | no |
| [SchedulingOffset](#InducedSubProcedureScheduleSchedulingOffset-Field) | *int32* | YES | no |
| [SchedulingOffsetUnit](#InducedSubProcedureScheduleSchedulingOffsetUnit-Field) | *string* | YES | no |
| SharedSkipCounters | *boolean* | YES | no |
| SharedLostCounters | *boolean* | YES | no |
| [Position](#InducedSubProcedureSchedulePosition-Field) | *int32* | YES | no |
| [SchedulingOffsetFixpoint](#InducedSubProcedureScheduleSchedulingOffsetFixpoint-Field) | *int32* | YES | no |
| [SchedulingByEstimate](#InducedSubProcedureScheduleSchedulingByEstimate-Field) | *boolean* | YES | no |
| [DedicatedToSubstudy](#InducedSubProcedureScheduleDedicatedToSubstudy-Field) | *string* | no | no |
| IncreaseVisitNumberBase | *int32* | YES | no |
| InheritVisitNumberBase | *boolean* | YES | no |
#### Unique Keys
* Id **(primary)**

#### InducedSubProcedureSchedule.**Id** (Field)
* this field represents the identity (PK) of the record

#### InducedSubProcedureSchedule.**ParentProcedureScheduleId** (Field)
* this field is used as foreign key to address the related 'ParentProcedureSchedule'

#### InducedSubProcedureSchedule.**InducedProcedureScheduleId** (Field)
* this field is used as foreign key to address the related 'InducedProcedureSchedule'

#### InducedSubProcedureSchedule.**SchedulingOffset** (Field)

estimated scheduling date relative to the scheduling date of the parent ProcedureSchedule


#### InducedSubProcedureSchedule.**SchedulingOffsetUnit** (Field)

'M'=Months / 'W'=Weeks / 'D'=Days


#### InducedSubProcedureSchedule.**Position** (Field)

The Position (1..x) of this inducement within the parent schedule. This value is relevant for addressing predecessors as fixpoint for the offest-calculation. Within one schedule there can only be one inducement for each position! The 0 is reserved for addressing the parent schedule itself and must not be used as well as negative values!


#### InducedSubProcedureSchedule.**SchedulingOffsetFixpoint** (Field)

0=InducementOfScheduleOrCycle: when the start of the parent Schedule (for the current cycle) was induced / -1=InducementOfPredessessor: when the direct predecessor procedure or subschedule (based on the 'Position') within the current schedule was induced / 1..x: when the predecessor at the Position within the current schedule, ADRESSED by the given value, was induced 
*items of sub-schedules are not relevant - when addressing a sub-schedule as predecessor, then only its entry will be used
*this behaviour can be concretized via 'SchedulingByEstimate'


#### InducedSubProcedureSchedule.**SchedulingByEstimate** (Field)

If set to true, the offset calculation will be based on the ESTIMATED completion of the predecessor (see 'Fixpoint'). Otherwise, when set to false, the offset calculation will be based on the REAL completion (if recorded execution data is available during calculation) of the predecessor. *this will not evaluated, when the 'Fixpoint' is set to 0!


#### InducedSubProcedureSchedule.**DedicatedToSubstudy** (Field)

The name of a Sub-Study for which this schedule should be induced or empty when its part of the current Arms regular workflow 

* this field is optional, so that '*null*' values are supported


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [ParentProcedureSchedule](#ParentProcedureSchedule-parent-of-this-InducedSubProcedureSchedule) | Parent | [ProcedureSchedule](#ProcedureSchedule) | 0/1 (optional) |
| [InducedProcedureSchedule](#InducedProcedureSchedule-lookup-from-this-InducedSubProcedureSchedule) | Lookup | [ProcedureSchedule](#ProcedureSchedule) | 0/1 (optional) |

##### **ParentProcedureSchedule** (parent of this InducedSubProcedureSchedule)
Target Type: [ProcedureSchedule](#ProcedureSchedule)
Addressed by: [ParentProcedureScheduleId](#InducedSubProcedureScheduleParentProcedureScheduleId-Field).
##### **InducedProcedureSchedule** (lookup from this InducedSubProcedureSchedule)
Target Type: [ProcedureSchedule](#ProcedureSchedule)
Addressed by: [InducedProcedureScheduleId](#InducedSubProcedureScheduleInducedProcedureScheduleId-Field).




## ProcedureCycleDefinition


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [ProcedureScheduleId](#ProcedureCycleDefinitionProcedureScheduleId-Field) **(PK)** (FK) | *guid* | YES | no |
| [ReschedulingOffsetFixpoint](#ProcedureCycleDefinitionReschedulingOffsetFixpoint-Field) | *int32* | YES | no |
| [ReschedulingOffset](#ProcedureCycleDefinitionReschedulingOffset-Field) | *int32* | YES | no |
| [ReschedulingOffsetUnit](#ProcedureCycleDefinitionReschedulingOffsetUnit-Field) | *string* | YES | no |
| [CycleLimit](#ProcedureCycleDefinitionCycleLimit-Field) | *int32* | no | no |
| SharedSkipCounters | *boolean* | YES | no |
| SharedLostCounters | *boolean* | YES | no |
| [ReschedulingByEstimate](#ProcedureCycleDefinitionReschedulingByEstimate-Field) | *boolean* | YES | no |
| [IncreaseVisitNumberBasePerCycle](#ProcedureCycleDefinitionIncreaseVisitNumberBasePerCycle-Field) | *int32* | YES | no |
#### Unique Keys
* ProcedureScheduleId **(primary)**

#### ProcedureCycleDefinition.**ProcedureScheduleId** (Field)
* this field represents the identity (PK) of the record
* this field is used as foreign key to address the related 'ProcedureSchedule'

#### ProcedureCycleDefinition.**ReschedulingOffsetFixpoint** (Field)

0=InducementOfScheduleOrCycle: when the start of the last cycle was induced / -1=InducementOfPredessessor: when the last procedure or subschedule (based on the 'Position') of the previous cycle was induced.
*items of sub-schedules are not relevant - when addressing a sub-schedule as predecessor, then only its entry will be used
*this behaviour can be concretized via 'ReschedulingByEstimate'


#### ProcedureCycleDefinition.**ReschedulingOffset** (Field)

estimated scheduling date relative to the ReschedulingBase


#### ProcedureCycleDefinition.**ReschedulingOffsetUnit** (Field)

'M'=Months / 'W'=Weeks / 'D'=Days


#### ProcedureCycleDefinition.**CycleLimit** (Field)

number of cycles (of null for a infinite number of cycles)

* this field is optional, so that '*null*' values are supported

#### ProcedureCycleDefinition.**ReschedulingByEstimate** (Field)

If set to true, the offset calculation will be based on the ESTIMATED completion of the predecessor (see 'Fixpoint'). Otherwise, when set to false, the offset calculation will be based on the REAL completion (if recorded execution data is available during calculation) of the predecessor. *this will not evaluated, when the 'Fixpoint' is set to 0!


#### ProcedureCycleDefinition.**IncreaseVisitNumberBasePerCycle** (Field)

-1: automatic, based on the usage of visit numbers within the schedule



### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [ProcedureSchedule](#ProcedureSchedule-parent-of-this-ProcedureCycleDefinition) | Parent | [ProcedureSchedule](#ProcedureSchedule) | 0/1 (optional) |

##### **ProcedureSchedule** (parent of this ProcedureCycleDefinition)
Target Type: [ProcedureSchedule](#ProcedureSchedule)
Addressed by: [ProcedureScheduleId](#ProcedureCycleDefinitionProcedureScheduleId-Field).




## StudyEvent


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [StudyEventName](#StudyEventStudyEventName-Field) **(PK)** | *string* (50) | YES | no |
| [StudyWorkflowName](#StudyEventStudyWorkflowName-Field) (FK) | *string* (100) | YES | no |
| [StudyWorkflowVersion](#StudyEventStudyWorkflowVersion-Field) (FK) | *string* (20) | YES | no |
| [MaxOccourrencesBeforeExclusion](#StudyEventMaxOccourrencesBeforeExclusion-Field) | *int32* | no | no |
| AllowManualTrigger | *boolean* | YES | no |
| Description | *string* | YES | no |
| [EvenSpecificDocumentationUrl](#StudyEventEvenSpecificDocumentationUrl-Field) | *string* | no | no |
#### Unique Keys
* StudyEventName **(primary)**

#### StudyEvent.**StudyEventName** (Field)
* this field represents the identity (PK) of the record
* the maximum length of the content within this field is 50 characters.

#### StudyEvent.**StudyWorkflowName** (Field)
* this field is used as foreign key to address the related 'ResearchStudy'
* the maximum length of the content within this field is 100 characters.

#### StudyEvent.**StudyWorkflowVersion** (Field)
* this field is used as foreign key to address the related 'ResearchStudy'
* the maximum length of the content within this field is 20 characters.

#### StudyEvent.**MaxOccourrencesBeforeExclusion** (Field)
* this field is optional, so that '*null*' values are supported

#### StudyEvent.**EvenSpecificDocumentationUrl** (Field)
* this field is optional, so that '*null*' values are supported


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [ResearchStudy](#ResearchStudy-parent-of-this-StudyEvent) | Parent | [ResearchStudyDefinition](#ResearchStudyDefinition) | 0/1 (optional) |

##### **ResearchStudy** (parent of this StudyEvent)
Target Type: [ResearchStudyDefinition](#ResearchStudyDefinition)
Addressed by: [StudyWorkflowName](#StudyEventStudyWorkflowName-Field) + [StudyWorkflowVersion](#StudyEventStudyWorkflowVersion-Field).




## SubStudy


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [SubStudyName](#SubStudySubStudyName-Field) **(PK)** | *string* (50) | YES | no |
| [StudyWorkflowName](#SubStudyStudyWorkflowName-Field) (FK) | *string* (100) | YES | no |
| [StudyWorkflowVersion](#SubStudyStudyWorkflowVersion-Field) (FK) | *string* (20) | YES | no |
#### Unique Keys
* SubStudyName **(primary)**

#### SubStudy.**SubStudyName** (Field)
* this field represents the identity (PK) of the record
* the maximum length of the content within this field is 50 characters.

#### SubStudy.**StudyWorkflowName** (Field)
* this field is used as foreign key to address the related 'ResearchStudyDefinition'
* the maximum length of the content within this field is 100 characters.

#### SubStudy.**StudyWorkflowVersion** (Field)
* this field is used as foreign key to address the related 'ResearchStudyDefinition'
* the maximum length of the content within this field is 20 characters.


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [ResearchStudyDefinition](#ResearchStudyDefinition-parent-of-this-SubStudy) | Parent | [ResearchStudyDefinition](#ResearchStudyDefinition) | 0/1 (optional) |

##### **ResearchStudyDefinition** (parent of this SubStudy)
Target Type: [ResearchStudyDefinition](#ResearchStudyDefinition)
Addressed by: [StudyWorkflowName](#SubStudyStudyWorkflowName-Field) + [StudyWorkflowVersion](#SubStudyStudyWorkflowVersion-Field).




## TaskSchedule


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [TaskScheduleId](#TaskScheduleTaskScheduleId-Field) **(PK)** | *guid* | YES | no |
| [StudyWorkflowName](#TaskScheduleStudyWorkflowName-Field) (FK) | *string* (100) | YES | no |
| [StudyWorkflowVersion](#TaskScheduleStudyWorkflowVersion-Field) (FK) | *string* (20) | YES | no |
| [ScheduleWorkflowName](#TaskScheduleScheduleWorkflowName-Field) | *string* | YES | no |
| MaxSkipsBeforeLost | *string* | YES | no |
| MaxSubsequentSkipsBeforeLost | *string* | YES | no |
| MaxLostsBeforeLtfuAbort | *string* | YES | no |
| MaxSubsequentLostsBeforeLtfuAbort | *string* | YES | no |
| EventOnLtfuAbort | *string* | YES | no |
| EventOnCycleEnded | *string* | YES | no |
| EventOnAllCyclesEnded | *string* | YES | no |
| InducingEvents | *string* | YES | no |
| AbortCausingEvents | *string* | YES | no |
#### Unique Keys
* TaskScheduleId **(primary)**

#### TaskSchedule.**TaskScheduleId** (Field)
* this field represents the identity (PK) of the record

#### TaskSchedule.**StudyWorkflowName** (Field)
* this field is used as foreign key to address the related 'ResearchStudy'
* the maximum length of the content within this field is 100 characters.

#### TaskSchedule.**StudyWorkflowVersion** (Field)
* this field is used as foreign key to address the related 'ResearchStudy'
* the maximum length of the content within this field is 20 characters.

#### TaskSchedule.**ScheduleWorkflowName** (Field)

Name of the Workflow which is represented by this schedule - INVARIANT! because it is used to generate Identifers for induced executions!



### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [InducedDataRecordingTasks](#InducedDataRecordingTasks-childs-of-this-TaskSchedule) | Childs | [InducedDataRecordingTask](#InducedDataRecordingTask) | * (multiple) |
| [InducedDrugApplymentTasks](#InducedDrugApplymentTasks-childs-of-this-TaskSchedule) | Childs | [InducedDrugApplymentTask](#InducedDrugApplymentTask) | * (multiple) |
| [InducedSubTaskSchedules](#InducedSubTaskSchedules-childs-of-this-TaskSchedule) | Childs | [InducedSubTaskSchedule](#InducedSubTaskSchedule) | * (multiple) |
| [InducingTaskSchedules](#InducingTaskSchedules-refering-to-this-TaskSchedule) | Referers | [InducedSubTaskSchedule](#InducedSubTaskSchedule) | * (multiple) |
| [InducedTreatmentTasks](#InducedTreatmentTasks-childs-of-this-TaskSchedule) | Childs | [InducedTreatmentTask](#InducedTreatmentTask) | * (multiple) |
| [EntryProdecureDefinitions](#EntryProdecureDefinitions-refering-to-this-TaskSchedule) | Referers | [ProcedureDefinition](#ProcedureDefinition) | * (multiple) |
| [ResearchStudy](#ResearchStudy-parent-of-this-TaskSchedule) | Parent | [ResearchStudyDefinition](#ResearchStudyDefinition) | 0/1 (optional) |
| [CycleDefinition](#CycleDefinition-child-of-this-TaskSchedule) | Child | [TaskCycleDefinition](#TaskCycleDefinition) | 0/1 (single) |

##### **InducedDataRecordingTasks** (childs of this TaskSchedule)
Target: [InducedDataRecordingTask](#InducedDataRecordingTask)
##### **InducedDrugApplymentTasks** (childs of this TaskSchedule)
Target: [InducedDrugApplymentTask](#InducedDrugApplymentTask)
##### **InducedSubTaskSchedules** (childs of this TaskSchedule)
Target: [InducedSubTaskSchedule](#InducedSubTaskSchedule)
##### **InducingTaskSchedules** (refering to this TaskSchedule)
Target: [InducedSubTaskSchedule](#InducedSubTaskSchedule)
##### **InducedTreatmentTasks** (childs of this TaskSchedule)
Target: [InducedTreatmentTask](#InducedTreatmentTask)
##### **EntryProdecureDefinitions** (refering to this TaskSchedule)
Target: [ProcedureDefinition](#ProcedureDefinition)
##### **ResearchStudy** (parent of this TaskSchedule)
Target Type: [ResearchStudyDefinition](#ResearchStudyDefinition)
Addressed by: [StudyWorkflowName](#TaskScheduleStudyWorkflowName-Field) + [StudyWorkflowVersion](#TaskScheduleStudyWorkflowVersion-Field).
##### **CycleDefinition** (child of this TaskSchedule)
Target: [TaskCycleDefinition](#TaskCycleDefinition)




## InducedDataRecordingTask


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [Id](#InducedDataRecordingTaskId-Field) **(PK)** | *guid* | YES | no |
| [TaskScheduleId](#InducedDataRecordingTaskTaskScheduleId-Field) (FK) | *guid* | YES | no |
| [TaskDefinitionName](#InducedDataRecordingTaskTaskDefinitionName-Field) (FK) | *string* (50) | YES | no |
| [SchedulingOffset](#InducedDataRecordingTaskSchedulingOffset-Field) | *int32* | YES | no |
| [SchedulingOffsetUnit](#InducedDataRecordingTaskSchedulingOffsetUnit-Field) | *string* | YES | no |
| [SchedulingVariabilityBefore](#InducedDataRecordingTaskSchedulingVariabilityBefore-Field) | *string* | YES | no |
| [SchedulingVariabilityAfter](#InducedDataRecordingTaskSchedulingVariabilityAfter-Field) | *string* | YES | no |
| [SchedulingVariabilityUnit](#InducedDataRecordingTaskSchedulingVariabilityUnit-Field) | *string* | YES | no |
| [UniqueExecutionName](#InducedDataRecordingTaskUniqueExecutionName-Field) | *string* | YES | no |
| [Skipable](#InducedDataRecordingTaskSkipable-Field) | *boolean* | YES | no |
| EventOnSkip | *string* | YES | no |
| EventOnLost | *string* | YES | no |
| [Position](#InducedDataRecordingTaskPosition-Field) | *int32* | YES | no |
| [SchedulingOffsetFixpoint](#InducedDataRecordingTaskSchedulingOffsetFixpoint-Field) | *int32* | YES | no |
| [SchedulingByEstimate](#InducedDataRecordingTaskSchedulingByEstimate-Field) | *boolean* | YES | no |
| [DedicatedToSubstudy](#InducedDataRecordingTaskDedicatedToSubstudy-Field) | *string* | no | no |
| [TaskNumber](#InducedDataRecordingTaskTaskNumber-Field) | *int32* | YES | no |
#### Unique Keys
* Id **(primary)**

#### InducedDataRecordingTask.**Id** (Field)
* this field represents the identity (PK) of the record

#### InducedDataRecordingTask.**TaskScheduleId** (Field)
* this field is used as foreign key to address the related 'TaskSchedule'

#### InducedDataRecordingTask.**TaskDefinitionName** (Field)
* this field is used as foreign key to address the related 'InducedTask'
* the maximum length of the content within this field is 50 characters.

#### InducedDataRecordingTask.**SchedulingOffset** (Field)

estimated scheduling time relative to the scheduling date of the parent TaskSchedule


#### InducedDataRecordingTask.**SchedulingOffsetUnit** (Field)

'h'=Hours / 'm'=Minutes / 's'=Seconds


#### InducedDataRecordingTask.**SchedulingVariabilityBefore** (Field)

defines an additional variability RELATIVE to the estimated scheduling time (which is calculated from the offset), in this case the EARLIEST possible time.


#### InducedDataRecordingTask.**SchedulingVariabilityAfter** (Field)

defines an additional variability RELATIVE to the estimated scheduling time (which is calculated from the offset), in this case the LATEST possible time.


#### InducedDataRecordingTask.**SchedulingVariabilityUnit** (Field)

'h'=Hours / 'm'=Minutes / 's'=Seconds


#### InducedDataRecordingTask.**UniqueExecutionName** (Field)

the name for the induced execution, like 'Measurement X', which is usually defined by the study protocol. if multiple inducements are possible (for example when using cycles), the title should to contain a placeholder (example: '{vt} - Measurement X') to prevent from duplicate execution names.


#### InducedDataRecordingTask.**Skipable** (Field)

defines, if the study protocol tolerates this execution to be 'skipped' (if not, a missed execution is treated as 'lost' and can cause the exclusion of the participant)


#### InducedDataRecordingTask.**Position** (Field)

The Position (1..x) of this inducement within the parent schedule. This value is relevant for addressing predecessors as fixpoint for the offest-calculation. Within one schedule there can only be one inducement for each position! The 0 is reserved for addressing the parent schedule itself and must not be used as well as negative values!


#### InducedDataRecordingTask.**SchedulingOffsetFixpoint** (Field)

0=InducementOfScheduleOrCycle: when the start of the parent Schedule (for the current cycle) was induced / -1=InducementOfPredessessor: when the direct predecessor task or subschedule (based on the 'Position') within the current schedule was induced / 1..x: when the predecessor at the Position within the current schedule, ADRESSED by the given value, was induced 
*items of sub-schedules are not relevant - when addressing a sub-schedule as predecessor, then only its entry will be used
*this behaviour can be concretized via 'SchedulingByEstimate'


#### InducedDataRecordingTask.**SchedulingByEstimate** (Field)

If set to true, the offset calculation will be based on the ESTIMATED completion of the predecessor (see 'Fixpoint'). Otherwise, when set to false, the offset calculation will be based on the REAL completion (if recorded execution data is available during calculation) of the predecessor. *this will not evaluated, when the 'Fixpoint' is set to 0!


#### InducedDataRecordingTask.**DedicatedToSubstudy** (Field)

The name of a Sub-Study for which this Task should be induced or empty when its part of the current Arms regular workflow

* this field is optional, so that '*null*' values are supported

#### InducedDataRecordingTask.**TaskNumber** (Field)

Number, which can be used via Placeholder {#} within the UniqueExecutionName and which will automatically increase when using cycles or sub-schedules



### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [InducedTask](#InducedTask-lookup-from-this-InducedDataRecordingTask) | Lookup | [DataRecordingTaskDefinition](#DataRecordingTaskDefinition) | 0/1 (optional) |
| [TaskSchedule](#TaskSchedule-parent-of-this-InducedDataRecordingTask) | Parent | [TaskSchedule](#TaskSchedule) | 0/1 (optional) |

##### **InducedTask** (lookup from this InducedDataRecordingTask)
Target Type: [DataRecordingTaskDefinition](#DataRecordingTaskDefinition)
Addressed by: [TaskDefinitionName](#InducedDataRecordingTaskTaskDefinitionName-Field).
##### **TaskSchedule** (parent of this InducedDataRecordingTask)
Target Type: [TaskSchedule](#TaskSchedule)
Addressed by: [TaskScheduleId](#InducedDataRecordingTaskTaskScheduleId-Field).




## InducedDrugApplymentTask


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [Id](#InducedDrugApplymentTaskId-Field) **(PK)** | *guid* | YES | no |
| [TaskScheduleId](#InducedDrugApplymentTaskTaskScheduleId-Field) (FK) | *guid* | YES | no |
| [TaskDefinitionName](#InducedDrugApplymentTaskTaskDefinitionName-Field) (FK) | *string* (50) | YES | no |
| [SchedulingOffset](#InducedDrugApplymentTaskSchedulingOffset-Field) | *int32* | YES | no |
| [SchedulingOffsetUnit](#InducedDrugApplymentTaskSchedulingOffsetUnit-Field) | *string* | YES | no |
| [SchedulingVariabilityBefore](#InducedDrugApplymentTaskSchedulingVariabilityBefore-Field) | *int32* | YES | no |
| [SchedulingVariabilityAfter](#InducedDrugApplymentTaskSchedulingVariabilityAfter-Field) | *int32* | YES | no |
| [SchedulingVariabilityUnit](#InducedDrugApplymentTaskSchedulingVariabilityUnit-Field) | *string* | YES | no |
| [UniqueExecutionName](#InducedDrugApplymentTaskUniqueExecutionName-Field) | *string* | YES | no |
| [Skipable](#InducedDrugApplymentTaskSkipable-Field) | *boolean* | YES | no |
| EventOnSkip | *string* | YES | no |
| EventOnLost | *string* | YES | no |
| [Position](#InducedDrugApplymentTaskPosition-Field) | *int32* | YES | no |
| [SchedulingOffsetFixpoint](#InducedDrugApplymentTaskSchedulingOffsetFixpoint-Field) | *int32* | YES | no |
| [SchedulingByEstimate](#InducedDrugApplymentTaskSchedulingByEstimate-Field) | *boolean* | YES | no |
| [DedicatedToSubstudy](#InducedDrugApplymentTaskDedicatedToSubstudy-Field) | *string* | no | no |
| [TaskNumber](#InducedDrugApplymentTaskTaskNumber-Field) | *int32* | YES | no |
#### Unique Keys
* Id **(primary)**

#### InducedDrugApplymentTask.**Id** (Field)
* this field represents the identity (PK) of the record

#### InducedDrugApplymentTask.**TaskScheduleId** (Field)
* this field is used as foreign key to address the related 'TaskSchedule'

#### InducedDrugApplymentTask.**TaskDefinitionName** (Field)
* this field is used as foreign key to address the related 'InducedTask'
* the maximum length of the content within this field is 50 characters.

#### InducedDrugApplymentTask.**SchedulingOffset** (Field)

estimated scheduling time relative to the scheduling date of the parent TaskSchedule


#### InducedDrugApplymentTask.**SchedulingOffsetUnit** (Field)

'h'=Hours / 'm'=Minutes / 's'=Seconds


#### InducedDrugApplymentTask.**SchedulingVariabilityBefore** (Field)

defines an additional variability RELATIVE to the estimated scheduling time (which is calculated from the offset), in this case the EARLIEST possible time.


#### InducedDrugApplymentTask.**SchedulingVariabilityAfter** (Field)

defines an additional variability RELATIVE to the estimated scheduling time (which is calculated from the offset), in this case the LATEST possible time.


#### InducedDrugApplymentTask.**SchedulingVariabilityUnit** (Field)

'h'=Hours / 'm'=Minutes / 's'=Seconds


#### InducedDrugApplymentTask.**UniqueExecutionName** (Field)

the name for the induced execution, like 'Measurement X', which is usually defined by the study protocol. if multiple inducements are possible (for example when using cycles), the title should to contain a placeholder (example: '{vt} - Measurement X') to prevent from duplicate execution names.



#### InducedDrugApplymentTask.**Skipable** (Field)

defines, if the study protocol tolerates this execution to be 'skipped' (if not, a missed execution is treated as 'lost' and can cause the exclusion of the participant)


#### InducedDrugApplymentTask.**Position** (Field)

The Position (1..x) of this inducement within the parent schedule. This value is relevant for addressing predecessors as fixpoint for the offest-calculation. Within one schedule there can only be one inducement for each position! The 0 is reserved for addressing the parent schedule itself and must not be used as well as negative values!


#### InducedDrugApplymentTask.**SchedulingOffsetFixpoint** (Field)

0=InducementOfScheduleOrCycle: when the start of the parent Schedule (for the current cycle) was induced / -1=InducementOfPredessessor: when the direct predecessor task or subschedule (based on the 'Position') within the current schedule was induced / 1..x: when the predecessor at the Position within the current schedule, ADRESSED by the given value, was induced 
*items of sub-schedules are not relevant - when addressing a sub-schedule as predecessor, then only its entry will be used
*this behaviour can be concretized via 'SchedulingByEstimate'


#### InducedDrugApplymentTask.**SchedulingByEstimate** (Field)

If set to true, the offset calculation will be based on the ESTIMATED completion of the predecessor (see 'Fixpoint'). Otherwise, when set to false, the offset calculation will be based on the REAL completion (if recorded execution data is available during calculation) of the predecessor. *this will not evaluated, when the 'Fixpoint' is set to 0!


#### InducedDrugApplymentTask.**DedicatedToSubstudy** (Field)

The name of a Sub-Study for which this Task should be induced or empty when its part of the current Arms regular workflow

* this field is optional, so that '*null*' values are supported

#### InducedDrugApplymentTask.**TaskNumber** (Field)

Number, which can be used via Placeholder {#} within the UniqueExecutionName and which will automatically increase when using cycles or sub-schedules



### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [InducedTask](#InducedTask-lookup-from-this-InducedDrugApplymentTask) | Lookup | [DrugApplymentTaskDefinition](#DrugApplymentTaskDefinition) | 0/1 (optional) |
| [TaskSchedule](#TaskSchedule-parent-of-this-InducedDrugApplymentTask) | Parent | [TaskSchedule](#TaskSchedule) | 0/1 (optional) |

##### **InducedTask** (lookup from this InducedDrugApplymentTask)
Target Type: [DrugApplymentTaskDefinition](#DrugApplymentTaskDefinition)
Addressed by: [TaskDefinitionName](#InducedDrugApplymentTaskTaskDefinitionName-Field).
##### **TaskSchedule** (parent of this InducedDrugApplymentTask)
Target Type: [TaskSchedule](#TaskSchedule)
Addressed by: [TaskScheduleId](#InducedDrugApplymentTaskTaskScheduleId-Field).




## InducedSubTaskSchedule


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [Id](#InducedSubTaskScheduleId-Field) **(PK)** | *guid* | YES | no |
| [ParentTaskScheduleId](#InducedSubTaskScheduleParentTaskScheduleId-Field) (FK) | *guid* | YES | no |
| [InducedTaskScheduleId](#InducedSubTaskScheduleInducedTaskScheduleId-Field) (FK) | *guid* | YES | no |
| [SchedulingOffset](#InducedSubTaskScheduleSchedulingOffset-Field) | *int32* | YES | no |
| [SchedulingOffsetUnit](#InducedSubTaskScheduleSchedulingOffsetUnit-Field) | *string* | YES | no |
| SharedSkipCounters | *boolean* | YES | no |
| SharedLostCounters | *boolean* | YES | no |
| [Position](#InducedSubTaskSchedulePosition-Field) | *int32* | YES | no |
| [SchedulingOffsetFixpoint](#InducedSubTaskScheduleSchedulingOffsetFixpoint-Field) | *int32* | YES | no |
| [SchedulingByEstimate](#InducedSubTaskScheduleSchedulingByEstimate-Field) | *boolean* | YES | no |
| [DedicatedToSubstudy](#InducedSubTaskScheduleDedicatedToSubstudy-Field) | *string* | no | no |
| IncreaseVisitNumberBase | *int32* | YES | no |
| InheritVisitNumberBase | *boolean* | YES | no |
#### Unique Keys
* Id **(primary)**

#### InducedSubTaskSchedule.**Id** (Field)
* this field represents the identity (PK) of the record

#### InducedSubTaskSchedule.**ParentTaskScheduleId** (Field)
* this field is used as foreign key to address the related 'ParentTaskSchedule'

#### InducedSubTaskSchedule.**InducedTaskScheduleId** (Field)
* this field is used as foreign key to address the related 'InducedTaskSchedule'

#### InducedSubTaskSchedule.**SchedulingOffset** (Field)

estimated scheduling time relative to the scheduling date of the parent ProcedureSchedule


#### InducedSubTaskSchedule.**SchedulingOffsetUnit** (Field)

'h'=Hours / 'm'=Minutes / 's'=Seconds


#### InducedSubTaskSchedule.**Position** (Field)

The Position (1..x) of this inducement within the parent schedule. This value is relevant for addressing predecessors as fixpoint for the offest-calculation. Within one schedule there can only be one inducement for each position! The 0 is reserved for addressing the parent schedule itself and must not be used as well as negative values!


#### InducedSubTaskSchedule.**SchedulingOffsetFixpoint** (Field)

0=InducementOfScheduleOrCycle: when the start of the parent Schedule (for the current cycle) was induced / -1=InducementOfPredessessor: when the direct predecessor task or subschedule (based on the 'Position') within the current schedule was induced / 1..x: when the predecessor at the Position within the current schedule, ADRESSED by the given value, was induced 
*items of sub-schedules are not relevant - when addressing a sub-schedule as predecessor, then only its entry will be used
*this behaviour can be concretized via 'SchedulingByEstimate'


#### InducedSubTaskSchedule.**SchedulingByEstimate** (Field)

If set to true, the offset calculation will be based on the ESTIMATED completion of the predecessor (see 'Fixpoint'). Otherwise, when set to false, the offset calculation will be based on the REAL completion (if recorded execution data is available during calculation) of the predecessor. *this will not evaluated, when the 'Fixpoint' is set to 0!


#### InducedSubTaskSchedule.**DedicatedToSubstudy** (Field)

The name of a Sub-Study for which this schedule should be induced or empty when its part of the current Arms regular workflow 

* this field is optional, so that '*null*' values are supported


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [ParentTaskSchedule](#ParentTaskSchedule-parent-of-this-InducedSubTaskSchedule) | Parent | [TaskSchedule](#TaskSchedule) | 0/1 (optional) |
| [InducedTaskSchedule](#InducedTaskSchedule-lookup-from-this-InducedSubTaskSchedule) | Lookup | [TaskSchedule](#TaskSchedule) | 0/1 (optional) |

##### **ParentTaskSchedule** (parent of this InducedSubTaskSchedule)
Target Type: [TaskSchedule](#TaskSchedule)
Addressed by: [ParentTaskScheduleId](#InducedSubTaskScheduleParentTaskScheduleId-Field).
##### **InducedTaskSchedule** (lookup from this InducedSubTaskSchedule)
Target Type: [TaskSchedule](#TaskSchedule)
Addressed by: [InducedTaskScheduleId](#InducedSubTaskScheduleInducedTaskScheduleId-Field).




## InducedTreatmentTask


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [Id](#InducedTreatmentTaskId-Field) **(PK)** | *guid* | YES | no |
| [TaskScheduleId](#InducedTreatmentTaskTaskScheduleId-Field) (FK) | *guid* | YES | no |
| [TaskDefinitionName](#InducedTreatmentTaskTaskDefinitionName-Field) (FK) | *string* (50) | YES | no |
| [SchedulingOffset](#InducedTreatmentTaskSchedulingOffset-Field) | *int32* | YES | no |
| [SchedulingOffsetUnit](#InducedTreatmentTaskSchedulingOffsetUnit-Field) | *string* | YES | no |
| [SchedulingVariabilityBefore](#InducedTreatmentTaskSchedulingVariabilityBefore-Field) | *string* | YES | no |
| [SchedulingVariabilityAfter](#InducedTreatmentTaskSchedulingVariabilityAfter-Field) | *string* | YES | no |
| [SchedulingVariabilityUnit](#InducedTreatmentTaskSchedulingVariabilityUnit-Field) | *string* | YES | no |
| [UniqueExecutionName](#InducedTreatmentTaskUniqueExecutionName-Field) | *string* | YES | no |
| [Skipable](#InducedTreatmentTaskSkipable-Field) | *boolean* | YES | no |
| EventOnSkip | *string* | YES | no |
| EventOnLost | *string* | YES | no |
| [Position](#InducedTreatmentTaskPosition-Field) | *int32* | YES | no |
| [SchedulingOffsetFixpoint](#InducedTreatmentTaskSchedulingOffsetFixpoint-Field) | *int32* | YES | no |
| [SchedulingByEstimate](#InducedTreatmentTaskSchedulingByEstimate-Field) | *boolean* | YES | no |
| [DedicatedToSubstudy](#InducedTreatmentTaskDedicatedToSubstudy-Field) | *string* | no | no |
| [TaskNumber](#InducedTreatmentTaskTaskNumber-Field) | *int32* | YES | no |
#### Unique Keys
* Id **(primary)**

#### InducedTreatmentTask.**Id** (Field)
* this field represents the identity (PK) of the record

#### InducedTreatmentTask.**TaskScheduleId** (Field)
* this field is used as foreign key to address the related 'TaskSchedule'

#### InducedTreatmentTask.**TaskDefinitionName** (Field)
* this field is used as foreign key to address the related 'InducedTask'
* the maximum length of the content within this field is 50 characters.

#### InducedTreatmentTask.**SchedulingOffset** (Field)

estimated scheduling time relative to the scheduling date of the parent TaskSchedule


#### InducedTreatmentTask.**SchedulingOffsetUnit** (Field)

'h'=Hours / 'm'=Minutes / 's'=Seconds


#### InducedTreatmentTask.**SchedulingVariabilityBefore** (Field)

defines an additional variability RELATIVE to the estimated scheduling time (which is calculated from the offset), in this case the EARLIEST possible time.


#### InducedTreatmentTask.**SchedulingVariabilityAfter** (Field)

defines an additional variability RELATIVE to the estimated scheduling time (which is calculated from the offset), in this case the LATEST possible time.


#### InducedTreatmentTask.**SchedulingVariabilityUnit** (Field)

'h'=Hours / 'm'=Minutes / 's'=Seconds


#### InducedTreatmentTask.**UniqueExecutionName** (Field)

the name for the induced execution, like 'Measurement X', which is usually defined by the study protocol. if multiple inducements are possible (for example when using cycles), the title should to contain a placeholder (example: '{vt} - Measurement X') to prevent from duplicate execution names.


#### InducedTreatmentTask.**Skipable** (Field)

defines, if the study protocol tolerates this execution to be 'skipped' (if not, a missed execution is treated as 'lost' and can cause the exclusion of the participant)


#### InducedTreatmentTask.**Position** (Field)

The Position (1..x) of this inducement within the parent schedule. This value is relevant for addressing predecessors as fixpoint for the offest-calculation. Within one schedule there can only be one inducement for each position! The 0 is reserved for addressing the parent schedule itself and must not be used as well as negative values!


#### InducedTreatmentTask.**SchedulingOffsetFixpoint** (Field)

0=InducementOfScheduleOrCycle: when the start of the parent Schedule (for the current cycle) was induced / -1=InducementOfPredessessor: when the direct predecessor task or subschedule (based on the 'Position') within the current schedule was induced / 1..x: when the predecessor at the Position within the current schedule, ADRESSED by the given value, was induced 
*items of sub-schedules are not relevant - when addressing a sub-schedule as predecessor, then only its entry will be used
*this behaviour can be concretized via 'SchedulingByEstimate'


#### InducedTreatmentTask.**SchedulingByEstimate** (Field)

If set to true, the offset calculation will be based on the ESTIMATED completion of the predecessor (see 'Fixpoint'). Otherwise, when set to false, the offset calculation will be based on the REAL completion (if recorded execution data is available during calculation) of the predecessor. *this will not evaluated, when the 'Fixpoint' is set to 0!


#### InducedTreatmentTask.**DedicatedToSubstudy** (Field)

The name of a Sub-Study for which this Task should be induced or empty when its part of the current Arms regular workflow

* this field is optional, so that '*null*' values are supported

#### InducedTreatmentTask.**TaskNumber** (Field)

Number, which can be used via Placeholder {#} within the UniqueExecutionName and which will automatically increase when using cycles or sub-schedules



### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [TaskSchedule](#TaskSchedule-parent-of-this-InducedTreatmentTask) | Parent | [TaskSchedule](#TaskSchedule) | 0/1 (optional) |
| [InducedTask](#InducedTask-lookup-from-this-InducedTreatmentTask) | Lookup | [TreatmentTaskDefinition](#TreatmentTaskDefinition) | 0/1 (optional) |

##### **TaskSchedule** (parent of this InducedTreatmentTask)
Target Type: [TaskSchedule](#TaskSchedule)
Addressed by: [TaskScheduleId](#InducedTreatmentTaskTaskScheduleId-Field).
##### **InducedTask** (lookup from this InducedTreatmentTask)
Target Type: [TreatmentTaskDefinition](#TreatmentTaskDefinition)
Addressed by: [TaskDefinitionName](#InducedTreatmentTaskTaskDefinitionName-Field).




## TaskCycleDefinition


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [TaskScheduleId](#TaskCycleDefinitionTaskScheduleId-Field) **(PK)** (FK) | *guid* | YES | no |
| [ReschedulingOffsetFixpoint](#TaskCycleDefinitionReschedulingOffsetFixpoint-Field) | *int32* | YES | no |
| [ReschedulingOffset](#TaskCycleDefinitionReschedulingOffset-Field) | *int32* | YES | no |
| [ReschedulingOffsetUnit](#TaskCycleDefinitionReschedulingOffsetUnit-Field) | *string* | YES | no |
| [CycleLimit](#TaskCycleDefinitionCycleLimit-Field) | *int32* | no | no |
| SharedSkipCounters | *boolean* | YES | no |
| SharedLostCounters | *boolean* | YES | no |
| [ReschedulingByEstimate](#TaskCycleDefinitionReschedulingByEstimate-Field) | *boolean* | YES | no |
| [IncreaseTaskNumberBasePerCycle](#TaskCycleDefinitionIncreaseTaskNumberBasePerCycle-Field) | *int32* | YES | no |
#### Unique Keys
* TaskScheduleId **(primary)**

#### TaskCycleDefinition.**TaskScheduleId** (Field)
* this field represents the identity (PK) of the record
* this field is used as foreign key to address the related 'TaskSchedule'

#### TaskCycleDefinition.**ReschedulingOffsetFixpoint** (Field)

0=InducementOfScheduleOrCycle: when the start of the last cycle was induced / -1=InducementOfPredessessor: when the last task or subschedule (based on the 'Position') of the previous cycle was induced.
*items of sub-schedules are not relevant - when addressing a sub-schedule as predecessor, then only its entry will be used
*this behaviour can be concretized via 'ReschedulingByEstimate'


#### TaskCycleDefinition.**ReschedulingOffset** (Field)

estimated scheduling time relative to the ReschedulingBase


#### TaskCycleDefinition.**ReschedulingOffsetUnit** (Field)

'h'=Hours / 'm'=Minutes / 's'=Seconds


#### TaskCycleDefinition.**CycleLimit** (Field)

number of cycles (of null for a infinite number of cycles)

* this field is optional, so that '*null*' values are supported

#### TaskCycleDefinition.**ReschedulingByEstimate** (Field)

If set to true, the offset calculation will be based on the ESTIMATED completion of the predecessor (see 'Fixpoint'). Otherwise, when set to false, the offset calculation will be based on the REAL completion (if recorded execution data is available during calculation) of the predecessor. *this will not evaluated, when the 'Fixpoint' is set to 0!


#### TaskCycleDefinition.**IncreaseTaskNumberBasePerCycle** (Field)

-1: automatic, based on the usage of task numbers within the schedule



### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [TaskSchedule](#TaskSchedule-parent-of-this-TaskCycleDefinition) | Parent | [TaskSchedule](#TaskSchedule) | 0/1 (optional) |

##### **TaskSchedule** (parent of this TaskCycleDefinition)
Target Type: [TaskSchedule](#TaskSchedule)
Addressed by: [TaskScheduleId](#TaskCycleDefinitionTaskScheduleId-Field).




## TreatmentTaskDefinition


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [TaskDefinitionName](#TreatmentTaskDefinitionTaskDefinitionName-Field) **(PK)** | *string* (50) | YES | no |
| [StudyWorkflowName](#TreatmentTaskDefinitionStudyWorkflowName-Field) (FK) | *string* (100) | YES | no |
| [StudyWorkflowVersion](#TreatmentTaskDefinitionStudyWorkflowVersion-Field) (FK) | *string* (20) | YES | no |
| [BillablePriceOnCompletedExecution](#TreatmentTaskDefinitionBillablePriceOnCompletedExecution-Field) | *decimal* | no | no |
| ShortDescription | *string* | YES | no |
| [TaskSpecificDocumentationUrl](#TreatmentTaskDefinitionTaskSpecificDocumentationUrl-Field) | *string* | no | no |
| TreatmentDescription | *string* | YES | no |
| [ImportantNotices](#TreatmentTaskDefinitionImportantNotices-Field) | *string* | no | no |
#### Unique Keys
* TaskDefinitionName **(primary)**

#### TreatmentTaskDefinition.**TaskDefinitionName** (Field)

Name of the Definition - INVARIANT! because it is used to generate Identifers for induced executions!

* this field represents the identity (PK) of the record
* the maximum length of the content within this field is 50 characters.

#### TreatmentTaskDefinition.**StudyWorkflowName** (Field)
* this field is used as foreign key to address the related 'ResearchStudy'
* the maximum length of the content within this field is 100 characters.

#### TreatmentTaskDefinition.**StudyWorkflowVersion** (Field)
* this field is used as foreign key to address the related 'ResearchStudy'
* the maximum length of the content within this field is 20 characters.

#### TreatmentTaskDefinition.**BillablePriceOnCompletedExecution** (Field)
* this field is optional, so that '*null*' values are supported

#### TreatmentTaskDefinition.**TaskSpecificDocumentationUrl** (Field)
* this field is optional, so that '*null*' values are supported

#### TreatmentTaskDefinition.**ImportantNotices** (Field)
* this field is optional, so that '*null*' values are supported


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [Inducements](#Inducements-refering-to-this-TreatmentTaskDefinition) | Referers | [InducedTreatmentTask](#InducedTreatmentTask) | * (multiple) |
| [ResearchStudy](#ResearchStudy-parent-of-this-TreatmentTaskDefinition) | Parent | [ResearchStudyDefinition](#ResearchStudyDefinition) | 0/1 (optional) |

##### **Inducements** (refering to this TreatmentTaskDefinition)
Target: [InducedTreatmentTask](#InducedTreatmentTask)
##### **ResearchStudy** (parent of this TreatmentTaskDefinition)
Target Type: [ResearchStudyDefinition](#ResearchStudyDefinition)
Addressed by: [StudyWorkflowName](#TreatmentTaskDefinitionStudyWorkflowName-Field) + [StudyWorkflowVersion](#TreatmentTaskDefinitionStudyWorkflowVersion-Field).


