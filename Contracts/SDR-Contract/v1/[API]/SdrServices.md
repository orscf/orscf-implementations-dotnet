# SdrApiInfoService
Provides interoperability information for the current implementation

### Methods:



## .GetApiVersion
returns the version of the ORSCF specification which is implemented by this API,
(this can be used for backward compatibility within inhomogeneous infrastructures)
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|(none)|||
**return value:** String



## .GetCapabilities
returns a list of API-features (there are several 'services' for different use cases, described by ORSCF)
supported by this implementation. The following values are possible:
'SubjectOverview', 'SubjectEnrollment', 'ParticipationStateMgmt'
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|(none)|||
**return value:** String[] *(array)*



## .GetPermittedAuthScopes
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|authState|Int32|**OUT**-Param (required)|
**return value:** String[] *(array)*



## .GetOAuthTokenRequestUrl
OPTIONAL: If the authentication on the current service is mapped
using tokens and should provide information about the source at this point,
the login URL to be called up via browser (OAuth ['CIBA-Flow'](https://openid.net/specs/openid-client-initiated-backchannel-authentication-core-1_0.html)) is returned here.
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|(none)|||
**return value:** String
# ParticipationStateMgmtService
Provides an workflow-level API for interating with a 'SubjectDataRepository' (SDR)

### Methods:
# SubjectEnrollmentService
Provides an workflow-level API for interating with a 'SubjectDataRepository' (SDR)

### Methods:



## .EnrollIdentityAsSubject
returns the null on failure or the assigned SubjectIdentifier on success
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|researchStudyName|String|**IN**-Param (required)|
|siteName|String|**IN**-Param (required)|
|dateOfEnrollment|DateTime|**IN**-Param (required)|
|details|[IdentityDetails](#MedicalResearch.SubjectData.Model.IdentityDetails)|**IN**-Param (required)|
|preDefinedSubjectId|String|**IN**-Param (optional)|
**return value:** String



## .UpdateIdentityInformationBySubjectId
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|researchStudyName|String|**IN**-Param (required)|
|subjectId|String|**IN**-Param (required)|
|newDetails|[IdentityDetails](#MedicalResearch.SubjectData.Model.IdentityDetails)|**IN**-Param (required)|
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
# SubjectOverviewService
Provides an workflow-level API for interating with a 'SubjectDataRepository' (SDR)

### Methods:



# Models:



## MedicalResearch.SubjectData.Model.IdentityDetails
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
