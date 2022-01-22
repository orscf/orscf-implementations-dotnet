# VdrApiInfoService
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
'VisitOverview', 'VisitScheduling', 'VisitDataConsume', 'VisitDataSubmission'
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
# VisitDataConsumeService
Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR)

### Methods:
# VisitDataSubmissionService
Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR)

### Methods:
# VisitOverviewService
Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR)

### Methods:
# VisitSchedulingService
Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR)

### Methods:
