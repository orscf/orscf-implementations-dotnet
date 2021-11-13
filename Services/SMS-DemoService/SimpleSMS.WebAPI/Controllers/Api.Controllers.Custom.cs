using MedicalResearch.StudyManagement.StoreAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Security;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MedicalResearch.StudyManagement.WebAPI {
  
  [ApiController]
  [Route("api/test")]
  [ApiExplorerSettings(GroupName = "ApiV1")]
  public partial class TestController : ControllerBase {
    
    private readonly ILogger<TestController> _Logger;
    private readonly IInstitutes _Institutes;
    
    public TestController(ILogger<TestController> logger, IInstitutes institutes) {
      _Logger = logger;
      _Institutes = institutes;
    }
    
    ///// <summary> Loads a specific Institute addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    ///// <param name="args"> request capsule containing the method arguments </param>
    //[RequireBaererAuth("GetTest")]
    //[HttpPost("getTest"), Produces("application/json")]
    //public GetInstituteByInstituteUidResponse GetTest([FromBody][SwaggerRequestBody(Required = true)] GetInstituteByInstituteUidRequest args) {
    //  try {
    //    var response = new GetInstituteByInstituteUidResponse();
    //    response.@return = _Institutes.GetInstituteByInstituteUid(
    //    args.instituteUid
    //    );
    //    return response;
    //  }
    //  catch (Exception ex) {
    //    _Logger.LogCritical(ex, ex.Message);
    //    return new GetInstituteByInstituteUidResponse { fault = ex.Message };
    //  }
    //}
    

  
  }

}
