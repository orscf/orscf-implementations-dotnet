# IdentityEnrollmentService
Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS)

### Methods:



## .GetApiVersion
returns the Version of the API itself, which can be used to
backward compatibility within inhomogeneous infrastructures
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|(none)|||
**return value:** String



## .HasAccess
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|(none)|||
**return value:** Boolean



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
# IdentityManagementService
Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS)

### Methods:



## .GetApiVersion
returns the Version of the API itself, which can be used to
backward compatibility within inhomogeneous infrastructures
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|(none)|||
**return value:** String



## .HasAccess
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|(none)|||
**return value:** Boolean
# IdentityUnblindingService
Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS)

### Methods:



## .GetApiVersion
returns the Version of the API itself, which can be used to
backward compatibility within inhomogeneous infrastructures
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|(none)|||
**return value:** String



## .HasAccess
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|(none)|||
**return value:** Boolean



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
