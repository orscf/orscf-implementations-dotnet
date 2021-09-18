# WorkflowConsumerService
Provides an workflow-level API for interating with a  'WorkflowDefinitionRepository' (WDR)

### Methods:



## .GetWorkflowDefintion
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|workflowDefinitionName|String|**IN**-Param (required)|
|workflowVersion|String|**IN**-Param (required)|
**return value:** [ResearchStudyDefinition](#MedicalResearch.Workflow.Model.ResearchStudyDefinition)



## .GetApiVersion
returns the Version of the API itself, which can be used for
backward compatibility within inhomogeneous infrastructures
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|(none)|||
**return value:** String



## .HasAccess
returns if the authenticated accessor of the
API has the permission to use this service
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|(none)|||
**return value:** Boolean
# WorkflowDesignerService
Provides an workflow-level API for interating with a  'WorkflowDefinitionRepository' (WDR)

### Methods:



## .GetApiVersion
returns the Version of the API itself, which can be used for
backward compatibility within inhomogeneous infrastructures
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|(none)|||
**return value:** String



## .HasAccess
returns if the authenticated accessor of the
API has the permission to use this service
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|(none)|||
**return value:** Boolean



# Models:



## MedicalResearch.Workflow.Model.ResearchStudyDefinition
#### Fields:
|Name|Type|Description|
|----|----|-----------|
|StudyWorkflowName|String|(required): the official invariant name of the study as given by the sponsor *this field has a max length of 100|
|StudyWorkflowVersion|String|(required): This value follows the rules of 'Semantic Versioning' (https://semver.org) and needs to be updated exactly and only on transition to DraftState.Released! If the previously DraftState was 'DraftNewFix', then the 3. number must be increased at this time! If the previously DraftState was 'DraftNewMinor', then the 2. number must be increased, and the 3. number must be set to 0 at this time! If the previously DraftState was 'DraftNewMajor', then the 1. number must be increased, and the 2.+3. number must be set to 0 at this time! *this field has a max length of 20|
|OfficialLabel|String|(required)|
|DefinitionOwner|String|(required)|
|DocumentationUrl|String|(required)|
|LogoImage|String|(optional): Logo in base64 *this field is optional (use null as value)|
|Description|String|(required)|
|VersionIdentity|String|(required): IT MUST NOT be updated on every change during Draft! Format: the Author, which is starting the new Draft (Alphanumeric, in PascalCase without blanks or other Symbols) + the current UTC-Time when setting the value (in ISO8601 format) separated by a Pipe "|" Sample: "MaxMustermann|2020-06-15T13:45:30.0000000Z".|
|LastChangeUtc|DateTime|(required)|
|DraftState|Int32|(required): 0=Released / 1=DraftNewFix / 2=DraftNewMinor / 3=DraftNewMajor|
|BillingCurrency|String|(optional): *this field is optional (use null as value)|
|BillablePriceForGeneralPreparation|Decimal? *(nullable)*|(optional): *this field is optional|
|StudyDocumentationUrl|String|(optional): *this field is optional (use null as value)|
|CaseReportFormUrl|String|(optional): *this field is optional (use null as value)|
|Arms|List`1|(optional)|
|DataRecordingTasks|List`1|(optional)|
|DrugApplymentTasks|List`1|(optional)|
|ProcedureDefinitions|List`1|(optional)|
|ProcedureSchedules|List`1|(optional)|
|TreatmentTasks|List`1|(optional)|
|TaskSchedules|List`1|(optional)|
|Events|List`1|(optional)|
|SubStudies|List`1|(optional)|
