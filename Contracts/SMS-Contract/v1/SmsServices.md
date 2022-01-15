# InstituteMgmtService
Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS)

### Methods:



## .GetInstituteUidByTitle
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|instituteTitle|String|**IN**-Param (required)|
**return value:** Guid



## .GetInstituteTitleByUid
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|instituteUid|Guid|**IN**-Param (required)|
**return value:** String



## .ArchiveInstitute
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|instituteUid|Guid|**IN**-Param (required)|
**return value:** String



## .GetInstituteInfos
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|instituteUid|Guid|**IN**-Param (required)|
**return value:** String



## .CreateInstituteIfMissing
ensures, that an institute with the given Uid exists
and returns true, if it has been newly created
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|instituteUid|Guid|**IN**-Param (required)|
**return value:** Boolean



## .UpdateInstitueTitle
updated the title of the the institute or returns false,
if there is no record for the given instituteUid
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|instituteUid|Guid|**IN**-Param (required)|
|newTitle|String|**IN**-Param (required)|
**return value:** Boolean
# SiteParticipationService
Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS)

### Methods:
# SmsApiInfoService
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
supported by this implementation. The following values are Possible:
'InstituteMgmt', 'StudySetup', 'StudyAccess', 'SiteParticipation'
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
# StudyAccessService
Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS)

### Methods:



## .SubscribeStudyStateChangedEvents
Subscribes the Event when the State of a Study was changed
to the given "EventQueue" which is accessable via "EventQueueService"
(including http notifications)
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|eventQueueId|Guid|**IN**-Param (required)|
**return value:** Boolean



## .UnsubscribeStudyStateChangedEvents
Unsubscribes the Event when the State of a Study was changed
for the given "EventQueue"
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|eventQueueId|Guid|**IN**-Param (required)|
**return value:** Boolean
# StudySetupService
Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS)

### Methods:



## .GetStudyTitleByIdentifier
returns null, if there is no matching record
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|studyIdentifier|String|**IN**-Param (required)|
**return value:** String
