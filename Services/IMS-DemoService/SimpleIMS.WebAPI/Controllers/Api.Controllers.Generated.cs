/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.IdentityManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Security;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MedicalResearch.IdentityManagement.WebAPI {
  
  namespace UnblindingClearanceAwaiter {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("unblindingClearanceAwaiter")]
    public partial class UnblindingClearanceAwaiterController : ControllerBase {
      
      private readonly ILogger<UnblindingClearanceAwaiterController> _Logger;
      private readonly IUnblindingClearanceAwaiterService _UnblindingClearanceAwaiter;
      
      public UnblindingClearanceAwaiterController(ILogger<UnblindingClearanceAwaiterController> logger, IUnblindingClearanceAwaiterService unblindingClearanceAwaiter) {
        _Logger = logger;
        _UnblindingClearanceAwaiter = unblindingClearanceAwaiter;
      }
      
      /// <summary> GrantClearanceForUnblinding </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("UnblindingClearanceAwaiter")]
      [HttpPost("grantClearanceForUnblinding"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GrantClearanceForUnblinding), Description = "GrantClearanceForUnblinding")]
      public GrantClearanceForUnblindingResponse GrantClearanceForUnblinding([FromBody][SwaggerRequestBody(Required = true)] GrantClearanceForUnblindingRequest args) {
        try {
          var response = new GrantClearanceForUnblindingResponse();
          _UnblindingClearanceAwaiter.GrantClearanceForUnblinding(
            args.unblindingToken,
            args.pseudonymsToUnblind,
            args.grantedUnitl
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GrantClearanceForUnblindingResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
  namespace UnblindingClearanceGranting {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("unblindingClearanceGranting")]
    public partial class UnblindingClearanceGrantingController : ControllerBase {
      
      private readonly ILogger<UnblindingClearanceGrantingController> _Logger;
      private readonly IUnblindingClearanceGrantingService _UnblindingClearanceGranting;
      
      public UnblindingClearanceGrantingController(ILogger<UnblindingClearanceGrantingController> logger, IUnblindingClearanceGrantingService unblindingClearanceGranting) {
        _Logger = logger;
        _UnblindingClearanceGranting = unblindingClearanceGranting;
      }
      
      /// <summary> Returns: 1: if clearance granted / 0: if no realtime response is possible (delayed approval) -1: if a new unblindingToken is required (because the current has expired or has been repressed) / -2: if the access is denied for addressed scope of data </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("UnblindingClearanceGranting")]
      [HttpPost("hasClearanceForUnblinding"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(HasClearanceForUnblinding), Description = "Returns: 1: if clearance granted / 0: if no realtime response is possible (delayed approval) -1: if a new unblindingToken is required (because the current has expired or has been repressed) / -2: if the access is denied for addressed scope of data")]
      public HasClearanceForUnblindingResponse HasClearanceForUnblinding([FromBody][SwaggerRequestBody(Required = true)] HasClearanceForUnblindingRequest args) {
        try {
          var response = new HasClearanceForUnblindingResponse();
          response.@return = _UnblindingClearanceGranting.HasClearanceForUnblinding(
            args.unblindingToken,
            args.pseudonymsToUnblind,
            args.accessRelatedDetails
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new HasClearanceForUnblindingResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
  namespace AgeEvaluation {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("ageEvaluation")]
    public partial class AgeEvaluationController : ControllerBase {
      
      private readonly ILogger<AgeEvaluationController> _Logger;
      private readonly IAgeEvaluationService _AgeEvaluation;
      
      public AgeEvaluationController(ILogger<AgeEvaluationController> logger, IAgeEvaluationService ageEvaluation) {
        _Logger = logger;
        _AgeEvaluation = ageEvaluation;
      }
      
      /// <summary> Calculates the age (only the integer Year) of several persons for a given date. This is supporting the very common usecase to evaluate inclusion criteria for research studies where the date of birth is not present alongside of the medical data. It allows for minimalist access disclosing the date of birth information (as happening when unblinding). </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("AgeEvaluation")]
      [HttpPost("evaluateAge"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(EvaluateAge), Description = "Calculates the age (only the integer Year) of several persons for a given date. This is supporting the very common usecase to evaluate inclusion criteria for research studies where the date of birth is not present alongside of the medical data. It allows for minimalist access disclosing the date of birth information (as happening when unblinding).")]
      public EvaluateAgeResponse EvaluateAge([FromBody][SwaggerRequestBody(Required = true)] EvaluateAgeRequest args) {
        try {
          var response = new EvaluateAgeResponse();
          _AgeEvaluation.EvaluateAge(
            args.momentOfValuation,
            args.pseudonymesToEvaluate,
            out var agesBuffer
          );
          response.ages = agesBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new EvaluateAgeResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
  namespace ImsApiInfo {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("imsApiInfo")]
    public partial class ImsApiInfoController : ControllerBase {
      
      private readonly ILogger<ImsApiInfoController> _Logger;
      private readonly IImsApiInfoService _ImsApiInfo;
      
      public ImsApiInfoController(ILogger<ImsApiInfoController> logger, IImsApiInfoService imsApiInfo) {
        _Logger = logger;
        _ImsApiInfo = imsApiInfo;
      }
      
      /// <summary> returns the version of the ORSCF specification which is implemented by this API, (this can be used for backward compatibility within inhomogeneous infrastructures) </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("ImsApiInfo")]
      [HttpPost("getApiVersion"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetApiVersion), Description = "returns the version of the ORSCF specification which is implemented by this API, (this can be used for backward compatibility within inhomogeneous infrastructures)")]
      public GetApiVersionResponse GetApiVersion([FromBody][SwaggerRequestBody(Required = true)] GetApiVersionRequest args) {
        try {
          var response = new GetApiVersionResponse();
          response.@return = _ImsApiInfo.GetApiVersion(
            
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetApiVersionResponse { fault = ex.Message };
        }
      }
      
      /// <summary> returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'ImsApiInfo', 'Pseudonymization', 'AgeEvaluation', 'Unblinding', 'UnblindingClearanceAwaiter'  (backend workflow for "PASSIVE-APPROVAL"), 'UnblindingClearanceGranting' (backend workflow for "ACTIVE-APPROVAL") </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("ImsApiInfo")]
      [HttpPost("getCapabilities"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetCapabilities), Description = "returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'ImsApiInfo', 'Pseudonymization', 'AgeEvaluation', 'Unblinding', 'UnblindingClearanceAwaiter'  (backend workflow for \"PASSIVE-APPROVAL\"), 'UnblindingClearanceGranting' (backend workflow for \"ACTIVE-APPROVAL\")")]
      public GetCapabilitiesResponse GetCapabilities([FromBody][SwaggerRequestBody(Required = true)] GetCapabilitiesRequest args) {
        try {
          var response = new GetCapabilitiesResponse();
          response.@return = _ImsApiInfo.GetCapabilities(
            
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetCapabilitiesResponse { fault = ex.Message };
        }
      }
      
      /// <summary> returns a list of available capabilities ("API:Pseudonymization") and/or data-scopes ("Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72") which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be: 0=auth needed / 1=authenticated / -1=auth expired / -2=auth invalid/disabled </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("ImsApiInfo")]
      [HttpPost("getPermittedAuthScopes"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetPermittedAuthScopes), Description = "returns a list of available capabilities (\"API:Pseudonymization\") and/or data-scopes (\"Study:9B2C3F48-2941-2F8F-4D35-7D117D5C6F72\") which are permitted for the CURRENT ACCESSOR and gives information about its 'authState', which can be: 0=auth needed / 1=authenticated / -1=auth expired / -2=auth invalid/disabled")]
      public GetPermittedAuthScopesResponse GetPermittedAuthScopes([FromBody][SwaggerRequestBody(Required = true)] GetPermittedAuthScopesRequest args) {
        try {
          var response = new GetPermittedAuthScopesResponse();
          response.@return = _ImsApiInfo.GetPermittedAuthScopes(
            out var authStateBuffer
          );
          response.authState = authStateBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetPermittedAuthScopesResponse { fault = ex.Message };
        }
      }
      
      /// <summary> OPTIONAL: If the authentication on the current service is mapped using tokens and should provide information about the source at this point, the login URL to be called up via browser (OAuth <see href="https://openid.net/specs/openid-client-initiated-backchannel-authentication-core-1_0.html">'CIBA-Flow'</see>) is returned here. </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("ImsApiInfo")]
      [HttpPost("getOAuthTokenRequestUrl"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetOAuthTokenRequestUrl), Description = "OPTIONAL: If the authentication on the current service is mapped using tokens and should provide information about the source at this point, the login URL to be called up via browser (OAuth <see href=\"https://openid.net/specs/openid-client-initiated-backchannel-authentication-core-1_0.html\">'CIBA-Flow'</see>) is returned here.")]
      public GetOAuthTokenRequestUrlResponse GetOAuthTokenRequestUrl([FromBody][SwaggerRequestBody(Required = true)] GetOAuthTokenRequestUrlRequest args) {
        try {
          var response = new GetOAuthTokenRequestUrlResponse();
          response.@return = _ImsApiInfo.GetOAuthTokenRequestUrl(
            
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetOAuthTokenRequestUrlResponse { fault = ex.Message };
        }
      }
      
      /// <summary> GetExtendedFieldDescriptors </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("ImsApiInfo")]
      [HttpPost("getExtendedFieldDescriptors"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetExtendedFieldDescriptors), Description = "GetExtendedFieldDescriptors")]
      public GetExtendedFieldDescriptorsResponse GetExtendedFieldDescriptors([FromBody][SwaggerRequestBody(Required = true)] GetExtendedFieldDescriptorsRequest args) {
        try {
          var response = new GetExtendedFieldDescriptorsResponse();
          response.@return = _ImsApiInfo.GetExtendedFieldDescriptors(
            args.languagePref
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetExtendedFieldDescriptorsResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
  namespace Pseudonymization {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("pseudonymization")]
    public partial class PseudonymizationController : ControllerBase {
      
      private readonly ILogger<PseudonymizationController> _Logger;
      private readonly IPseudonymizationService _Pseudonymization;
      
      public PseudonymizationController(ILogger<PseudonymizationController> logger, IPseudonymizationService pseudonymization) {
        _Logger = logger;
        _Pseudonymization = pseudonymization;
      }
      
      /// <summary> GetOrCreatePseudonym </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("Pseudonymization")]
      [HttpPost("getOrCreatePseudonym"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetOrCreatePseudonym), Description = "GetOrCreatePseudonym")]
      public GetOrCreatePseudonymResponse GetOrCreatePseudonym([FromBody][SwaggerRequestBody(Required = true)] GetOrCreatePseudonymRequest args) {
        try {
          var response = new GetOrCreatePseudonymResponse();
          response.@return = _Pseudonymization.GetOrCreatePseudonym(
            args.givenName,
            args.familyName,
            args.birthDate,
            args.extendedFields,
            out var pseudonymBuffer,
            out var wasCreatedNewlyBuffer
          );
          response.pseudonym = pseudonymBuffer;
          response.wasCreatedNewly = wasCreatedNewlyBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetOrCreatePseudonymResponse { fault = ex.Message };
        }
      }
      
      /// <summary> GetExisitingPseudonym </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("Pseudonymization")]
      [HttpPost("getExisitingPseudonym"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetExisitingPseudonym), Description = "GetExisitingPseudonym")]
      public GetExisitingPseudonymResponse GetExisitingPseudonym([FromBody][SwaggerRequestBody(Required = true)] GetExisitingPseudonymRequest args) {
        try {
          var response = new GetExisitingPseudonymResponse();
          response.@return = _Pseudonymization.GetExisitingPseudonym(
            args.givenName,
            args.familyName,
            args.birthDate,
            args.extendedFields,
            out var pseudonymBuffer
          );
          response.pseudonym = pseudonymBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetExisitingPseudonymResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
  namespace Unblinding {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("unblinding")]
    public partial class UnblindingController : ControllerBase {
      
      private readonly ILogger<UnblindingController> _Logger;
      private readonly IUnblindingService _Unblinding;
      
      public UnblindingController(ILogger<UnblindingController> logger, IUnblindingService unblinding) {
        _Logger = logger;
        _Unblinding = unblinding;
      }
      
      /// <summary> Returns: 1: if clearance granted (token can be DIRECTLY used to call 'TryUnblind') / 0: if no realtime response is possible (delayed approval is outstanding) -1: if a new unblindingToken is required (because the current has expired or has been repressed) / -2: if the access is denied for addressed scope of data </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("Unblinding")]
      [HttpPost("requestUnblindingToken"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(RequestUnblindingToken), Description = "Returns: 1: if clearance granted (token can be DIRECTLY used to call 'TryUnblind') / 0: if no realtime response is possible (delayed approval is outstanding) -1: if a new unblindingToken is required (because the current has expired or has been repressed) / -2: if the access is denied for addressed scope of data")]
      public RequestUnblindingTokenResponse RequestUnblindingToken([FromBody][SwaggerRequestBody(Required = true)] RequestUnblindingTokenRequest args) {
        try {
          var response = new RequestUnblindingTokenResponse();
          response.@return = _Unblinding.RequestUnblindingToken(
            args.pseudonymsToUnblind,
            args.requestReason,
            args.requestBy,
            out var unblindingTokenBuffer
          );
          response.unblindingToken = unblindingTokenBuffer;
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new RequestUnblindingTokenResponse { fault = ex.Message };
        }
      }
      
      /// <summary> Returns: 1: on SUCCESS (unblindedIdentities should contain data) / 0: if no realtime response is possible (delayed approval is outstanding) -1: if a new unblindingToken is required (because the current has expired or has been repressed) / -2: if the access is denied for addressed scope of data </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("Unblinding")]
      [HttpPost("tryUnblind"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(TryUnblind), Description = "Returns: 1: on SUCCESS (unblindedIdentities should contain data) / 0: if no realtime response is possible (delayed approval is outstanding) -1: if a new unblindingToken is required (because the current has expired or has been repressed) / -2: if the access is denied for addressed scope of data")]
      public TryUnblindResponse TryUnblind([FromBody][SwaggerRequestBody(Required = true)] TryUnblindRequest args) {
        try {
          var response = new TryUnblindResponse();
          response.@return = _Unblinding.TryUnblind(
            args.unblindingToken,
            args.pseudonymsToUnblind,
            args.unblindedIdentities
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new TryUnblindResponse { fault = ex.Message };
        }
      }
      
    }
    
  }
  
}
