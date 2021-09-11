# ORSCF-StudyManagement Schema Specification

|          | Info                                    |
|----------|-----------------------------------------|
|author:   |[ORSCF](https://www.orscf.org) ("Open Research Study Communication Formats") / T.Korn|
|license:  |[Apache-2](https://choosealicense.com/licenses/apache-2.0/)|
|version:  |1.5.0|
|timestamp:|2021-08-04 12:40|

### Contents

  * .  [Institute](#Institute)
  * .  [ResearchStudy](#ResearchStudy)
  * ........\  [Site](#Site)
  * ........\  [Subject](#Subject)

# Model:

![chart](./chart.png)



## Institute


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [InstituteUid](#InstituteInstituteUid-Field) **(PK)** | *guid* | YES | no |
| InstituteTitle | *string* | YES | no |
| IsArchived | *boolean* | YES | no |
#### Unique Keys
* InstituteUid **(primary)**

#### Institute.**InstituteUid** (Field)
* this field represents the identity (PK) of the record


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [SponsoredStudies](#SponsoredStudies-refering-to-this-Institute) | Referers | [ResearchStudy](#ResearchStudy) | * (multiple) |
| [RepresentedSites](#RepresentedSites-refering-to-this-Institute) | Referers | [Site](#Site) | * (multiple) |

##### **SponsoredStudies** (refering to this Institute)
Target: [ResearchStudy](#ResearchStudy)
##### **RepresentedSites** (refering to this Institute)
Target: [Site](#Site)




## ResearchStudy

entity, which relates to [HL7.ResearchStudy](https://www.hl7.org/fhir/researchstudy.html)
### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [StudyIdentifier](#ResearchStudyStudyIdentifier-Field) **(PK)** | *string* (250) | YES | no |
| StudyTitle | *string* | YES | no |
| [SponsoringInstituteUid](#ResearchStudySponsoringInstituteUid-Field) (FK) | *guid* | YES | no |
| StudyWorkflowName | *string* | YES | no |
| StudyWorkflowVersion | *string* | YES | no |
| [Phase](#ResearchStudyPhase-Field) | *string* | no | no |
| [LKP](#ResearchStudyLKP-Field) | *string* | no | no |
| [StartDate](#ResearchStudyStartDate-Field) | *datetime* | no | no |
| [TerminationDate](#ResearchStudyTerminationDate-Field) | *datetime* | no | no |
| [SubjectIdentifierTitle](#ResearchStudySubjectIdentifierTitle-Field) | *string* | YES | no |
| [ImsApiUrl](#ResearchStudyImsApiUrl-Field) | *string* | no | no |
| [VdrApiUrl](#ResearchStudyVdrApiUrl-Field) | *string* | no | no |
| [BdrApiUrl](#ResearchStudyBdrApiUrl-Field) | *string* | no | no |
| [WdrApiUrl](#ResearchStudyWdrApiUrl-Field) | *string* | no | no |
| [Status](#ResearchStudyStatus-Field) | *string* | YES | no |
| [TerminatedReason](#ResearchStudyTerminatedReason-Field) | *string* | no | no |
| IsArchived | *boolean* | YES | no |
#### Unique Keys
* StudyIdentifier **(primary)**

#### ResearchStudy.**StudyIdentifier** (Field)
* this field represents the identity (PK) of the record
* the maximum length of the content within this field is 250 characters.

#### ResearchStudy.**SponsoringInstituteUid** (Field)
* this field is used as foreign key to address the related 'SponsoringInstitute'

#### ResearchStudy.**Phase** (Field)

AS DECLARED BY [HL7.ResearchStudyPhase](https://www.hl7.org/fhir/valueset-research-study-phase.html):
n-a | early-phase-1 | phase-1 | phase-1-phase-2 | phase-2 | phase-2-phase-3 | phase-3 | phase-4

* this field is optional, so that '*null*' values are supported

#### ResearchStudy.**LKP** (Field)
* this field is optional, so that '*null*' values are supported

#### ResearchStudy.**StartDate** (Field)
* this field is optional, so that '*null*' values are supported

#### ResearchStudy.**TerminationDate** (Field)
* this field is optional, so that '*null*' values are supported

#### ResearchStudy.**SubjectIdentifierTitle** (Field)

A title which informs about the sematic of the SubjectIdentifer (which concrete value is used): "Randomization-Number", "Screening-Number", ...


#### ResearchStudy.**ImsApiUrl** (Field)

Url of the API Endpoint which provides access to the 'IdentityManagementSystem' for this study (following the ORSCF-Standard)

* this field is optional, so that '*null*' values are supported

#### ResearchStudy.**VdrApiUrl** (Field)

Url of the API Endpoint which provides access to the 'VisitDataRepository' for this study (following the ORSCF-Standard)

* this field is optional, so that '*null*' values are supported

#### ResearchStudy.**BdrApiUrl** (Field)

Url of the API Endpoint which provides access to the 'BillingDataRepository' for this study (following the ORSCF-Standard)

* this field is optional, so that '*null*' values are supported

#### ResearchStudy.**WdrApiUrl** (Field)

Url of the API Endpoint which provides access to the 'WorkflowDefinitionRepository' for this study (following the ORSCF-Standard)

* this field is optional, so that '*null*' values are supported

#### ResearchStudy.**Status** (Field)

AS DECLARED BY [HL7.ResearchStudyStatus](https://www.hl7.org/fhir/valueset-research-study-status.html):
active | administratively-completed | approved | closed-to-accrual | closed-to-accrual-and-intervention | completed | disapproved | in-review | temporarily-closed-to-accrual | temporarily-closed-to-accrual-and-intervention | withdrawn


#### ResearchStudy.**TerminatedReason** (Field)
* this field is optional, so that '*null*' values are supported


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [SponsoringInstitute](#SponsoringInstitute-lookup-from-this-ResearchStudy) | Lookup | [Institute](#Institute) | 0/1 (optional) |
| [SiteParticipations](#SiteParticipations-childs-of-this-ResearchStudy) | Childs | [Site](#Site) | * (multiple) |
| [Subjects](#Subjects-childs-of-this-ResearchStudy) | Childs | [Subject](#Subject) | * (multiple) |

##### **SponsoringInstitute** (lookup from this ResearchStudy)
Target Type: [Institute](#Institute)
Addressed by: [SponsoringInstituteUid](#ResearchStudySponsoringInstituteUid-Field).
##### **SiteParticipations** (childs of this ResearchStudy)
Target: [Site](#Site)
##### **Subjects** (childs of this ResearchStudy)
Target: [Subject](#Subject)




## Site


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [SiteIdentifier](#SiteSiteIdentifier-Field) **(PK)** | *string* (250) | YES | no |
| [RepresentingInstituteUid](#SiteRepresentingInstituteUid-Field) (FK) | *guid* | YES | no |
| [StudyIdentifier](#SiteStudyIdentifier-Field) **(PK)** (FK) | *string* (250) | YES | no |
| [EnrollmentDate](#SiteEnrollmentDate-Field) | *datetime* | no | no |
| [TerminationDate](#SiteTerminationDate-Field) | *datetime* | no | no |
| [TerminatedReason](#SiteTerminatedReason-Field) | *string* | no | no |
| SiteTitle | *string* | YES | no |
| [Status](#SiteStatus-Field) | *string* | YES | no |
#### Unique Keys
* SiteIdentifier + StudyIdentifier **(primary)**

#### Site.**SiteIdentifier** (Field)
* this field represents the identity (PK) of the record
* the maximum length of the content within this field is 250 characters.

#### Site.**RepresentingInstituteUid** (Field)
* this field is used as foreign key to address the related 'RepresentingInstitute'

#### Site.**StudyIdentifier** (Field)
* this field represents the identity (PK) of the record
* this field is used as foreign key to address the related 'Study'
* the maximum length of the content within this field is 250 characters.

#### Site.**EnrollmentDate** (Field)
* this field is optional, so that '*null*' values are supported

#### Site.**TerminationDate** (Field)
* this field is optional, so that '*null*' values are supported

#### Site.**TerminatedReason** (Field)
* this field is optional, so that '*null*' values are supported

#### Site.**Status** (Field)

AS DECLARED BY HL7



### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [RepresentingInstitute](#RepresentingInstitute-lookup-from-this-Site) | Lookup | [Institute](#Institute) | 0/1 (optional) |
| [Study](#Study-parent-of-this-Site) | Parent | [ResearchStudy](#ResearchStudy) | 0/1 (optional) |
| [ActualSubjects](#ActualSubjects-refering-to-this-Site) | Referers | [Subject](#Subject) | * (multiple) |
| [EnrolledSubjects](#EnrolledSubjects-refering-to-this-Site) | Referers | [Subject](#Subject) | * (multiple) |

##### **RepresentingInstitute** (lookup from this Site)
Target Type: [Institute](#Institute)
Addressed by: [RepresentingInstituteUid](#SiteRepresentingInstituteUid-Field).
##### **Study** (parent of this Site)
Target Type: [ResearchStudy](#ResearchStudy)
Addressed by: [StudyIdentifier](#SiteStudyIdentifier-Field).
##### **ActualSubjects** (refering to this Site)
Target: [Subject](#Subject)
##### **EnrolledSubjects** (refering to this Site)
Target: [Subject](#Subject)




## Subject

entity, which relates to [HL7.ResearchSubject](https://www.hl7.org/fhir/researchsubject.html)
### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [CandidateIdentifier](#SubjectCandidateIdentifier-Field) **(PK)** | *string* (250) | YES | no |
| [ActualSiteIdentifier](#SubjectActualSiteIdentifier-Field) (FK) | *string* (250) | YES | no |
| [StudyIdentifier](#SubjectStudyIdentifier-Field) **(PK)** (FK) | *string* (250) | YES | no |
| [EnrollingSiteIdentifier](#SubjectEnrollingSiteIdentifier-Field) (FK) | *string* (250) | YES | no |
| [EnrollmentDate](#SubjectEnrollmentDate-Field) | *datetime* | no | no |
| [TerminationDate](#SubjectTerminationDate-Field) | *datetime* | no | no |
| [TerminatedReason](#SubjectTerminatedReason-Field) | *string* | no | no |
| [SubjectIdentifier](#SubjectSubjectIdentifier-Field) | *string* | no | no |
| [Status](#SubjectStatus-Field) | *string* | YES | no |
| [CustomDisplayTitle](#SubjectCustomDisplayTitle-Field) | *string* | no | no |
| [SiteSpecificPatientIdentifier](#SubjectSiteSpecificPatientIdentifier-Field) | *string* | no | no |
#### Unique Keys
* CandidateIdentifier + StudyIdentifier **(primary)**

#### Subject.**CandidateIdentifier** (Field)
* this field represents the identity (PK) of the record
* the maximum length of the content within this field is 250 characters.

#### Subject.**ActualSiteIdentifier** (Field)
* this field is used as foreign key to address the related 'ActualSite'
* the maximum length of the content within this field is 250 characters.

#### Subject.**StudyIdentifier** (Field)
* this field represents the identity (PK) of the record
* this field is used as foreign key to address the related 'Study'
* this field is used as foreign key to address the related 'ActualSite'
* this field is used as foreign key to address the related 'EnrollingSite'
* the maximum length of the content within this field is 250 characters.

#### Subject.**EnrollingSiteIdentifier** (Field)
* this field is used as foreign key to address the related 'EnrollingSite'
* the maximum length of the content within this field is 250 characters.

#### Subject.**EnrollmentDate** (Field)
* this field is optional, so that '*null*' values are supported

#### Subject.**TerminationDate** (Field)
* this field is optional, so that '*null*' values are supported

#### Subject.**TerminatedReason** (Field)
* this field is optional, so that '*null*' values are supported

#### Subject.**SubjectIdentifier** (Field)
* this field is optional, so that '*null*' values are supported

#### Subject.**Status** (Field)

AS DECLARED BY [HL7.ResearchSubjectStatus](https://www.hl7.org/fhir/valueset-research-subject-status.html):
candidate | eligible | follow-up | ineligible | not-registered | off-study | on-study | on-study-intervention | on-study-observation | pending-on-study | potential-candidate | screening | withdrawn


#### Subject.**CustomDisplayTitle** (Field)
* this field is optional, so that '*null*' values are supported

#### Subject.**SiteSpecificPatientIdentifier** (Field)
* this field is optional, so that '*null*' values are supported


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [Study](#Study-parent-of-this-Subject) | Parent | [ResearchStudy](#ResearchStudy) | 0/1 (optional) |
| [ActualSite](#ActualSite-lookup-from-this-Subject) | Lookup | [Site](#Site) | 0/1 (optional) |
| [EnrollingSite](#EnrollingSite-lookup-from-this-Subject) | Lookup | [Site](#Site) | 0/1 (optional) |

##### **Study** (parent of this Subject)
Target Type: [ResearchStudy](#ResearchStudy)
Addressed by: [StudyIdentifier](#SubjectStudyIdentifier-Field).
##### **ActualSite** (lookup from this Subject)
Target Type: [Site](#Site)
Addressed by: [ActualSiteIdentifier](#SubjectActualSiteIdentifier-Field) + [StudyIdentifier](#SubjectStudyIdentifier-Field).
##### **EnrollingSite** (lookup from this Subject)
Target Type: [Site](#Site)
Addressed by: [EnrollingSiteIdentifier](#SubjectEnrollingSiteIdentifier-Field) + [StudyIdentifier](#SubjectStudyIdentifier-Field).


