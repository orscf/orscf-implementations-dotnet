# UnblindingClearanceAwaiterService
Following the "PASSIVE-APPROVAL" Workflow, this endpoint is directly implemented on the IMS!
"PASSIVE-APPROVAL" is based on the idea, that clearances have to be (pre-)delivered by a foreign master system ('push' principle)

### Methods:



## .GrantClearanceForUnblinding
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|unblindingToken|String|**IN**-Param (required)|
|pseudonymsToUnblind|String[] *(array)*|**IN**-Param (required)|
|grantedUnitl|DateTime|**IN**-Param (required)|
no return value (void)
# UnblindingClearanceGrantingService
Following the "ACTIVE-APPROVAL" Workflow, this endpoint is usually implemented on a FOREIGN system, that should be queried by an IMS!
"ACTIVE-APPROVAL" is based on the idea, that clearances have to be requested on demand from a foreign master system  ('pull' principle)

### Methods:



## .HasClearanceForUnblinding
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|unblindingToken|String|**IN**-Param (required)|
|pseudonymsToUnblind|String[] *(array)*|**IN**-Param (required)|
|accessRelatedDetails|Dictionary`2|**IN**-Param (required)|
**return value:** Int32
# AgeEvaluationService

### Methods:



## .EvaluateAge
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|momentOfValuation|DateTime|**IN**-Param (required)|
|pseudonymesToEvaluate|String[] *(array)*|**IN**-Param (required)|
|ages|Int32[] *(array)*|**OUT**-Param (required)|
no return value (void)
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
'ImsApiInfo',
'Pseudonymization',
'AgeEvaluation',
'Unblinding',
'UnblindingClearanceAwaiter'  (backend workflow for "PASSIVE-APPROVAL"),
'UnblindingClearanceGranting' (backend workflow for "ACTIVE-APPROVAL")
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



## .GetExtendedFieldDescriptors
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|languagePref|String|**IN**-Param (optional): Preferred language for the 'DisplayLabel' and 'InputDescription' fields of the returned descriptors. ONLY RELEVANT FOR THE UI!|
**return value:** [ExtendedFieldDescriptor](#MedicalResearch.IdentityManagement.Model.ExtendedFieldDescriptor)[] *(array)*
# PseudonymizationService
Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS)

### Methods:



## .GetOrCreatePseudonym
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|givenName|String|**IN**-Param (required)|
|familyName|String|**IN**-Param (required)|
|birthDate|String|**IN**-Param (required)|
|extendedFields|Dictionary`2|**IN**-Param (required)|
|pseudonym|String|**OUT**-Param (required)|
|wasCreatedNewly|Boolean|**OUT**-Param (required)|
**return value:** Boolean



## .GetExisitingPseudonym
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|givenName|String|**IN**-Param (required)|
|familyName|String|**IN**-Param (required)|
|birthDate|String|**IN**-Param (required)|
|extendedFields|Dictionary`2|**IN**-Param (required)|
|pseudonym|String|**OUT**-Param (required)|
**return value:** Boolean
# UnblindingService
Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS)

### Methods:



## .RequestUnblindingToken
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|pseudonymsToUnblind|String[] *(array)*|**IN**-Param (required)|
|requestReason|String|**IN**-Param (required)|
|requestBy|String|**IN**-Param (required)|
|unblindingToken|String|**OUT**-Param (required)|
**return value:** Int32



## .TryUnblind
Returns:
1: on SUCCESS (unblindedIdentities should contain data) /
0: if no realtime response is possible (delayed approval is outstanding)
-1: if a new unblindingToken is required (because the current has expired or has been repressed) /
-2: if the access is denied for addressed scope of data
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|unblindingToken|String|**IN**-Param (required)|
|pseudonymsToUnblind|String[] *(array)*|**IN**-Param (required)|
|unblindedIdentities|[IdentityDetails](#MedicalResearch.IdentityManagement.Model.IdentityDetails)[] *(array)*|**IN**-Param (required)|
**return value:** Int32



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
|GivenName|String|(required): the firstname a person (named as in the HL7 standard)|
|FamilyName|String|(required): the lastname a person (named as in the HL7 standard)|
|BirthDate|String|(required): date in format 'yyyy-MM-dd' (must NOT be a partial date for this usecase!)|
|ExtendedFields|Dictionary`2|(optional): additional values for each 'extendedField' that is mandatory within (and specific to) the current IMS-System. To retrieve the declarations for such fields call 'GetExtendedFieldDescriptors'|
