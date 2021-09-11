# ORSCF-BillingData Schema Specification

|          | Info                                    |
|----------|-----------------------------------------|
|author:   |[ORSCF](https://www.orscf.org) ("Open Research Study Communication Formats") / T.Korn|
|license:  |[Apache-2](https://choosealicense.com/licenses/apache-2.0/)|
|version:  |1.5.0|
|timestamp:|2021-08-04 12:40|

### Contents

  * .  [StudyExecutionScope](#StudyExecutionScope)
  * ........\  [BillableVisit](#BillableVisit)
  * ................\  [BillableTask](#BillableTask)
  * ........\  [BillingDemand](#BillingDemand)
  * ........\  [Invoice](#Invoice)

# Model:

![chart](./chart.png)



## StudyExecutionScope


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [StudyExecutionIdentifier](#StudyExecutionScopeStudyExecutionIdentifier-Field) **(PK)** | *guid* | YES | YES |
| [ExecutingInstituteIdentifier](#StudyExecutionScopeExecutingInstituteIdentifier-Field) | *string* | YES | YES |
| [StudyWorkflowName](#StudyExecutionScopeStudyWorkflowName-Field) | *string* (100) | YES | YES |
| [StudyWorkflowVersion](#StudyExecutionScopeStudyWorkflowVersion-Field) | *string* (20) | YES | YES |
| [ExtendedMetaData](#StudyExecutionScopeExtendedMetaData-Field) | *string* | no | no |
#### Unique Keys
* StudyExecutionIdentifier **(primary)**

#### StudyExecutionScope.**StudyExecutionIdentifier** (Field)

a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS')

* this field represents the identity (PK) of the record
* after the record has been created, the value of this field must not be changed any more!

#### StudyExecutionScope.**ExecutingInstituteIdentifier** (Field)

the institute which is executing the study (this should be an invariant technical representation of the company name or a guid)

* after the record has been created, the value of this field must not be changed any more!

#### StudyExecutionScope.**StudyWorkflowName** (Field)

the official invariant name of the study as given by the sponsor

* the maximum length of the content within this field is 100 characters.
* after the record has been created, the value of this field must not be changed any more!

#### StudyExecutionScope.**StudyWorkflowVersion** (Field)

version of the workflow

* the maximum length of the content within this field is 20 characters.
* after the record has been created, the value of this field must not be changed any more!

#### StudyExecutionScope.**ExtendedMetaData** (Field)

optional structure (in JSON-format) containing additional metadata regarding this record, which can be used by 'StudyExecutionSystems' to extend the schema

* this field is optional, so that '*null*' values are supported


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [BillableVisits](#BillableVisits-childs-of-this-StudyExecutionScope) | Childs | [BillableVisit](#BillableVisit) | * (multiple) |
| [BillingDemands](#BillingDemands-childs-of-this-StudyExecutionScope) | Childs | [BillingDemand](#BillingDemand) | * (multiple) |
| [Invoices](#Invoices-childs-of-this-StudyExecutionScope) | Childs | [Invoice](#Invoice) | * (multiple) |

##### **BillableVisits** (childs of this StudyExecutionScope)
Target: [BillableVisit](#BillableVisit)
##### **BillingDemands** (childs of this StudyExecutionScope)
Target: [BillingDemand](#BillingDemand)
##### **Invoices** (childs of this StudyExecutionScope)
Target: [Invoice](#Invoice)




## BillableVisit


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [VisitGuid](#BillableVisitVisitGuid-Field) **(PK)** | *guid* | YES | no |
| [StudyExecutionIdentifier](#BillableVisitStudyExecutionIdentifier-Field) (FK) | *guid* | YES | no |
| [ParticipantIdentifier](#BillableVisitParticipantIdentifier-Field) | *string* (50) | YES | no |
| [VisitProdecureName](#BillableVisitVisitProdecureName-Field) | *string* | YES | no |
| [VisitExecutionTitle](#BillableVisitVisitExecutionTitle-Field) | *string* | YES | no |
| [BillingDemandId](#BillableVisitBillingDemandId-Field) (FK) | *guid* | no | no |
| [InvoiceId](#BillableVisitInvoiceId-Field) (FK) | *guid* | no | no |
| [ExecutionEndDateUtc](#BillableVisitExecutionEndDateUtc-Field) | *datetime* | no | no |
| [SponsorValidationDateUtc](#BillableVisitSponsorValidationDateUtc-Field) | *datetime* | no | no |
| [ExecutorValidationDateUtc](#BillableVisitExecutorValidationDateUtc-Field) | *datetime* | no | no |
#### Unique Keys
* VisitGuid **(primary)**

#### BillableVisit.**VisitGuid** (Field)

a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS')

* this field represents the identity (PK) of the record

#### BillableVisit.**StudyExecutionIdentifier** (Field)

a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS')

* this field is used as foreign key to address the related 'StudyExecution'

#### BillableVisit.**ParticipantIdentifier** (Field)

identity of the patient which can be a randomization or screening number (the exact semantic is defined per study)

* the maximum length of the content within this field is 50 characters.

#### BillableVisit.**VisitProdecureName** (Field)

unique invariant name of the visit-procedure as defined in the 'StudyWorkflowDefinition' (originated from the sponsor)


#### BillableVisit.**VisitExecutionTitle** (Field)

title of the visit execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor)


#### BillableVisit.**BillingDemandId** (Field)
* this field is optional, so that '*null*' values are supported
* this field is used as foreign key to address the related 'AssignedBillingDemand'

#### BillableVisit.**InvoiceId** (Field)
* this field is optional, so that '*null*' values are supported
* this field is used as foreign key to address the related 'AssignedInvoice'

#### BillableVisit.**ExecutionEndDateUtc** (Field)
* this field is optional, so that '*null*' values are supported

#### BillableVisit.**SponsorValidationDateUtc** (Field)

indicates, that the visit is ready to get assigned to a 'BillingDemand' (usually this state is managed by the sponsor) This can only be set after there is a valid 'ExecutionEndDateUtc'

* this field is optional, so that '*null*' values are supported

#### BillableVisit.**ExecutorValidationDateUtc** (Field)

indicates, that the visit is ready to get assigned to a 'Invoice' (usually this state is managed by the executor) This can only be set after either the 'SponsorValidationDateUtc' is set (and there is a Demand) nor the states are only managed by the executor, so that the demand-part is completely skipped.

* this field is optional, so that '*null*' values are supported


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [BillableTasks](#BillableTasks-childs-of-this-BillableVisit) | Childs | [BillableTask](#BillableTask) | * (multiple) |
| [StudyExecution](#StudyExecution-parent-of-this-BillableVisit) | Parent | [StudyExecutionScope](#StudyExecutionScope) | 0/1 (optional) |
| [AssignedBillingDemand](#AssignedBillingDemand-lookup-from-this-BillableVisit) | Lookup | [BillingDemand](#BillingDemand) | 1 (required) |
| [AssignedInvoice](#AssignedInvoice-lookup-from-this-BillableVisit) | Lookup | [Invoice](#Invoice) | 1 (required) |

##### **BillableTasks** (childs of this BillableVisit)
Target: [BillableTask](#BillableTask)
##### **StudyExecution** (parent of this BillableVisit)
Target Type: [StudyExecutionScope](#StudyExecutionScope)
Addressed by: [StudyExecutionIdentifier](#BillableVisitStudyExecutionIdentifier-Field).
##### **AssignedBillingDemand** (lookup from this BillableVisit)
Target Type: [BillingDemand](#BillingDemand)
Addressed by: [BillingDemandId](#BillableVisitBillingDemandId-Field).
##### **AssignedInvoice** (lookup from this BillableVisit)
Target Type: [Invoice](#Invoice)
Addressed by: [InvoiceId](#BillableVisitInvoiceId-Field).




## BillableTask


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [TaskGuid](#BillableTaskTaskGuid-Field) **(PK)** | *guid* | YES | YES |
| [VisitGuid](#BillableTaskVisitGuid-Field) (FK) | *guid* | YES | YES |
| [TaskName](#BillableTaskTaskName-Field) | *string* | YES | YES |
| [TaskExecutionTitle](#BillableTaskTaskExecutionTitle-Field) | *string* | YES | YES |
#### Unique Keys
* TaskGuid **(primary)**

#### BillableTask.**TaskGuid** (Field)

a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS')

* this field represents the identity (PK) of the record
* after the record has been created, the value of this field must not be changed any more!

#### BillableTask.**VisitGuid** (Field)

a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS')

* this field is used as foreign key to address the related 'BillableVisit'
* after the record has been created, the value of this field must not be changed any more!

#### BillableTask.**TaskName** (Field)

unique invariant name of ths task-procedure as defined in the 'StudyWorkflowDefinition' (originated from the sponsor)

* after the record has been created, the value of this field must not be changed any more!

#### BillableTask.**TaskExecutionTitle** (Field)

title of the task execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor)

* after the record has been created, the value of this field must not be changed any more!


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [BillableVisit](#BillableVisit-parent-of-this-BillableTask) | Parent | [BillableVisit](#BillableVisit) | 0/1 (optional) |

##### **BillableVisit** (parent of this BillableTask)
Target Type: [BillableVisit](#BillableVisit)
Addressed by: [VisitGuid](#BillableTaskVisitGuid-Field).




## BillingDemand

created by the sponsor
### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [Id](#BillingDemandId-Field) **(PK)** | *guid* | YES | no |
| OfficialNumber | *string* | YES | no |
| [StudyExecutionIdentifier](#BillingDemandStudyExecutionIdentifier-Field) (FK) | *guid* | YES | no |
| [TransmissionDateUtc](#BillingDemandTransmissionDateUtc-Field) | *datetime* | no | no |
| CreationDateUtc | *datetime* | YES | no |
| CreatedByPerson | *string* | YES | no |
#### Unique Keys
* Id **(primary)**

#### BillingDemand.**Id** (Field)
* this field represents the identity (PK) of the record

#### BillingDemand.**StudyExecutionIdentifier** (Field)
* this field is used as foreign key to address the related 'StudyExecution'

#### BillingDemand.**TransmissionDateUtc** (Field)
* this field is optional, so that '*null*' values are supported


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [AssignedVisits](#AssignedVisits-refering-to-this-BillingDemand) | Referers | [BillableVisit](#BillableVisit) | * (multiple) |
| [StudyExecution](#StudyExecution-parent-of-this-BillingDemand) | Parent | [StudyExecutionScope](#StudyExecutionScope) | 0/1 (optional) |

##### **AssignedVisits** (refering to this BillingDemand)
Target: [BillableVisit](#BillableVisit)
##### **StudyExecution** (parent of this BillingDemand)
Target Type: [StudyExecutionScope](#StudyExecutionScope)
Addressed by: [StudyExecutionIdentifier](#BillingDemandStudyExecutionIdentifier-Field).




## Invoice

created by the executor-company
### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [Id](#InvoiceId-Field) **(PK)** | *guid* | YES | YES |
| [OfficialNumber](#InvoiceOfficialNumber-Field) | *string* | YES | YES |
| [StudyExecutionIdentifier](#InvoiceStudyExecutionIdentifier-Field) (FK) | *guid* | YES | YES |
| [OffcialInvoiceDate](#InvoiceOffcialInvoiceDate-Field) | *datetime* | YES | YES |
| [TransmissionDateUtc](#InvoiceTransmissionDateUtc-Field) | *datetime* | no | no |
| CreationDateUtc | *datetime* | YES | no |
| CreatedByPerson | *string* | YES | no |
| [PaymentSubmittedDateUtc](#InvoicePaymentSubmittedDateUtc-Field) | *datetime* | no | no |
| [PaymentReceivedDateUtc](#InvoicePaymentReceivedDateUtc-Field) | *datetime* | no | no |
#### Unique Keys
* Id **(primary)**

#### Invoice.**Id** (Field)
* this field represents the identity (PK) of the record
* after the record has been created, the value of this field must not be changed any more!

#### Invoice.**OfficialNumber** (Field)

the invoice number

* after the record has been created, the value of this field must not be changed any more!

#### Invoice.**StudyExecutionIdentifier** (Field)
* this field is used as foreign key to address the related 'StudyExecution'
* after the record has been created, the value of this field must not be changed any more!

#### Invoice.**OffcialInvoiceDate** (Field)
* after the record has been created, the value of this field must not be changed any more!

#### Invoice.**TransmissionDateUtc** (Field)
* this field is optional, so that '*null*' values are supported

#### Invoice.**PaymentSubmittedDateUtc** (Field)
* this field is optional, so that '*null*' values are supported

#### Invoice.**PaymentReceivedDateUtc** (Field)
* this field is optional, so that '*null*' values are supported


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [AssignedVisits](#AssignedVisits-refering-to-this-Invoice) | Referers | [BillableVisit](#BillableVisit) | * (multiple) |
| [StudyExecution](#StudyExecution-parent-of-this-Invoice) | Parent | [StudyExecutionScope](#StudyExecutionScope) | 0/1 (optional) |

##### **AssignedVisits** (refering to this Invoice)
Target: [BillableVisit](#BillableVisit)
##### **StudyExecution** (parent of this Invoice)
Target Type: [StudyExecutionScope](#StudyExecutionScope)
Addressed by: [StudyExecutionIdentifier](#InvoiceStudyExecutionIdentifier-Field).


