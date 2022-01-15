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
# ImsApiInfoService
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
'Pseudonymization', 'IdentityUnblinding',
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
# PseudonymizationService
Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS)

### Methods:



## .GetExtendedFieldDescriptors
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|languagePref|String|**IN**-Param (optional): Preferred language for the 'DisplayLabel' and 'InputDescription' fields of the returned descriptors.|
**return value:** [ExtendedFieldDescriptor](#MedicalResearch.IdentityManagement.Model.ExtendedFieldDescriptor)[] *(array)*



## .GetOrCreatePseudonym
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|researchStudyUid|Guid|**IN**-Param (required)|
|givenName|String|**IN**-Param (required)|
|familyName|String|**IN**-Param (required)|
|birthDate|String|**IN**-Param (required)|
|extendedFields|Dictionary`2|**IN**-Param (required)|
|siteUid|Guid|**IN**-Param (required)|
|pseudonym|String|**OUT**-Param (required)|
|wasCreatedNewly|Boolean|**OUT**-Param (required)|
**return value:** Boolean



## .GetExisitingPseudonym
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|researchStudyUid|Guid|**IN**-Param (required)|
|givenName|String|**IN**-Param (required)|
|familyName|String|**IN**-Param (required)|
|birthDate|String|**IN**-Param (required)|
|extendedFields|Dictionary`2|**IN**-Param (required)|
|pseudonym|String|**OUT**-Param (required)|
**return value:** Boolean



# Models:



## MedicalResearch.IdentityManagement.Model.ExtendedFieldDescriptor
#### Fields:
|Name|Type|Description|
|----|----|-----------|
|TechnicalName|String|(required)|
|IsRequired|Boolean|(required)|
|DisplayLabel|String|(required)|
|InputDescription|String|(optional)|
|RegularExpression|String|(optional)|



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
