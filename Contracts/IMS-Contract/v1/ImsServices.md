# IdentityEnrollmentService
Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS)

### Methods:



## .EnrollIdentityAsSubject
returns the null on failure or the assigned SubjectIdentifier on success
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|researchStudyName|String|**IN**-Param (required)|
|siteName|String|**IN**-Param (required)|
|dateOfEnrollment|DateTime|**IN**-Param (required)|
|details|[IdentityDetails](#MedicalResearch.IdentityManagement.Model.IdentityDetails)|**IN**-Param (required)|
|preDefinedSubjectId|String|**IN**-Param (optional)|
**return value:** String



## .UpdateIdentityInformationBySubjectId
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|researchStudyName|String|**IN**-Param (required)|
|subjectId|String|**IN**-Param (required)|
|newDetails|[IdentityDetails](#MedicalResearch.IdentityManagement.Model.IdentityDetails)|**IN**-Param (required)|
|clearUnsuppliedValues|Boolean? *(nullable)*|**IN**-Param (optional)|
|newSiteName|String|**IN**-Param (optional)|
**return value:** Boolean



## .GetSiteNameBySubjectId
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|researchStudyName|String|**IN**-Param (required)|
|subjectId|String|**IN**-Param (required)|
**return value:** String



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
# IdentityManagementService
Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS)

### Methods:



## .GetUnblindingTokenInfos
returns the list of currently exposed unblinding-tokens
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|(none)|||
**return value:** [UnblindingTokenInfo](#MedicalResearch.IdentityManagement.Model.UnblindingTokenInfo)[] *(array)*



## .UnlockUnblindingToken
unlocks an unblinding-token to be usable for retrieval of indentity information
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|token|String|**IN**-Param (required)|
no return value (void)



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
# IdentityUnblindingService
Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS)

### Methods:



## .RequestUnblindingToken
returns an unblindingToken which is not activated
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|researchStudyName|String|**IN**-Param (required)|
|subjectId|String|**IN**-Param (required)|
|reason|String|**IN**-Param (required)|
|requestingPerson|String|**IN**-Param (required)|
**return value:** String



## .GetUnblindingTokenState
0: not activated yet, 1=activated (can be used for 'UnblindSubject'), 2=expired/already used
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|unblindingToken|String|**IN**-Param (required)|
**return value:** Int32



## .UnblindSubject
(only works with an activated unblindingOtp )
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|researchStudyName|String|**IN**-Param (required)|
|subjectId|String|**IN**-Param (required)|
|unblindingToken|String|**IN**-Param (required)|
**return value:** [IdentityDetails](#MedicalResearch.IdentityManagement.Model.IdentityDetails)



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



## MedicalResearch.IdentityManagement.Model.IdentityDetails
#### Fields:
|Name|Type|Description|
|----|----|-----------|
|FirstName|String|(optional)|
|LastName|String|(optional)|
|Email|String|(optional)|
|Phone|String|(optional)|
|Street|String|(optional)|
|HouseNumber|String|(optional)|
|PostCode|String|(optional)|
|City|String|(optional)|
|State|String|(optional)|
|Country|String|(optional): two letter ISO code|
|DateOfBirth|DateTime? *(nullable)*|(optional)|
|DateOfDeath|DateTime? *(nullable)*|(optional)|



## MedicalResearch.IdentityManagement.Model.UnblindingTokenInfo
#### Fields:
|Name|Type|Description|
|----|----|-----------|
|token|String|(optional)|
|state|Int32? *(nullable)*|(optional)|
|researchStudyName|String|(optional)|
|subjectId|String|(optional)|
|reason|String|(optional)|
|requestingPerson|String|(optional)|
