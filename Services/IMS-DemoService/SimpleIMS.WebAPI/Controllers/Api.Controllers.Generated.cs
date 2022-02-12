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
  
  namespace IdentityUnblinding {
    
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiV1")]
    [Route("identityUnblinding")]
    public partial class IdentityUnblindingController : ControllerBase {
      
      private readonly ILogger<IdentityUnblindingController> _Logger;
      private readonly IIdentityUnblindingService _IdentityUnblinding;
      
      public IdentityUnblindingController(ILogger<IdentityUnblindingController> logger, IIdentityUnblindingService identityUnblinding) {
        _Logger = logger;
        _IdentityUnblinding = identityUnblinding;
      }
      
      /// <summary> returns an unblindingToken which is not activated </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("IdentityUnblinding")]
      [HttpPost("requestUnblindingToken"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(RequestUnblindingToken), Description = "returns an unblindingToken which is not activated")]
      public RequestUnblindingTokenResponse RequestUnblindingToken([FromBody][SwaggerRequestBody(Required = true)] RequestUnblindingTokenRequest args) {
        try {
          var response = new RequestUnblindingTokenResponse();
          response.@return = _IdentityUnblinding.RequestUnblindingToken(
            args.researchStudyName,
            args.subjectId,
            args.reason,
            args.requestingPerson
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new RequestUnblindingTokenResponse { fault = ex.Message };
        }
      }
      
      /// <summary> 0: not activated yet, 1=activated (can be used for 'UnblindSubject'), 2=expired/already used </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("IdentityUnblinding")]
      [HttpPost("getUnblindingTokenState"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetUnblindingTokenState), Description = "0: not activated yet, 1=activated (can be used for 'UnblindSubject'), 2=expired/already used")]
      public GetUnblindingTokenStateResponse GetUnblindingTokenState([FromBody][SwaggerRequestBody(Required = true)] GetUnblindingTokenStateRequest args) {
        try {
          var response = new GetUnblindingTokenStateResponse();
          response.@return = _IdentityUnblinding.GetUnblindingTokenState(
            args.unblindingToken
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetUnblindingTokenStateResponse { fault = ex.Message };
        }
      }
      
      /// <summary> (only works with an activated unblindingOtp ) </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("IdentityUnblinding")]
      [HttpPost("unblindSubject"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(UnblindSubject), Description = "(only works with an activated unblindingOtp )")]
      public UnblindSubjectResponse UnblindSubject([FromBody][SwaggerRequestBody(Required = true)] UnblindSubjectRequest args) {
        try {
          var response = new UnblindSubjectResponse();
          response.@return = _IdentityUnblinding.UnblindSubject(
            args.researchStudyName,
            args.subjectId,
            args.unblindingToken
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new UnblindSubjectResponse { fault = ex.Message };
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
      
      /// <summary> returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'Pseudonymization', 'IdentityUnblinding', </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("ImsApiInfo")]
      [HttpPost("getCapabilities"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetCapabilities), Description = "returns a list of API-features (there are several 'services' for different use cases, described by ORSCF) supported by this implementation. The following values are possible: 'Pseudonymization', 'IdentityUnblinding',")]
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
      
      /// <summary> GetExtendedFieldDescriptors </summary>
      /// <param name="args"> request capsule containing the method arguments </param>
      [EvaluateBearerToken("Pseudonymization")]
      [HttpPost("getExtendedFieldDescriptors"), Produces("application/json")]
      [SwaggerOperation(OperationId = nameof(GetExtendedFieldDescriptors), Description = "GetExtendedFieldDescriptors")]
      public GetExtendedFieldDescriptorsResponse GetExtendedFieldDescriptors([FromBody][SwaggerRequestBody(Required = true)] GetExtendedFieldDescriptorsRequest args) {
        try {
          var response = new GetExtendedFieldDescriptorsResponse();
          response.@return = _Pseudonymization.GetExtendedFieldDescriptors(
            args.languagePref
          );
          return response;
        }
        catch (Exception ex) {
          _Logger.LogCritical(ex, ex.Message);
          return new GetExtendedFieldDescriptorsResponse { fault = ex.Message };
        }
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
            args.researchStudyUid,
            args.givenName,
            args.familyName,
            args.birthDate,
            args.extendedFields,
            args.siteUid,
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
            args.researchStudyUid,
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
  
}
