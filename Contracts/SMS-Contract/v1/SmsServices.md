# InstituteRegistryService
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
# SiteParticipationService
Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS)

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
