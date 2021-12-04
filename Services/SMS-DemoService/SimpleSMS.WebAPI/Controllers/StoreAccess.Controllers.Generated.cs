﻿/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

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
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/institutes")]
  public class InstitutesController : ControllerBase {
    
    private readonly ILogger<InstitutesController> _Logger;
    private readonly IInstitutes _Institutes;
    
    public InstitutesController(ILogger<InstitutesController> logger, IInstitutes institutes) {
      _Logger = logger;
      _Institutes = institutes;
    }
    
    /// <summary> Loads a specific Institute addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetInstituteByInstituteUid")]
    [HttpPost("getInstituteByInstituteUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetInstituteByInstituteUid), Description = "Loads a specific Institute addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetInstituteByInstituteUidResponse GetInstituteByInstituteUid([FromBody][SwaggerRequestBody(Required = true)]  GetInstituteByInstituteUidRequest args) {
      try {
        var response = new GetInstituteByInstituteUidResponse();
        response.@return = _Institutes.GetInstituteByInstituteUid(
        args.instituteUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetInstituteByInstituteUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads Institutes. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetInstitutes")]
    [HttpPost("getInstitutes"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetInstitutes), Description = "Loads Institutes.")]
    public GetInstitutesResponse GetInstitutes([FromBody][SwaggerRequestBody(Required = true)]  GetInstitutesRequest args) {
      try {
        var response = new GetInstitutesResponse();
        response.@return = _Institutes.GetInstitutes(
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetInstitutesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads Institutes where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-SearchInstitutes")]
    [HttpPost("searchInstitutes"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchInstitutes), Description = "Loads Institutes where values matching to the given filterExpression")]
    public SearchInstitutesResponse SearchInstitutes([FromBody][SwaggerRequestBody(Required = true)]  SearchInstitutesRequest args) {
      try {
        var response = new SearchInstitutesResponse();
        response.@return = _Institutes.SearchInstitutes(
        args.filterExpression,
        args.sortingExpression,
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchInstitutesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new Institute and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-AddNewInstitute")]
    [HttpPost("addNewInstitute"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewInstitute), Description = "Adds a new Institute and returns its primary identifier (or null on failure).")]
    public AddNewInstituteResponse AddNewInstitute([FromBody][SwaggerRequestBody(Required = true)]  AddNewInstituteRequest args) {
      try {
        var response = new AddNewInstituteResponse();
        response.@return = _Institutes.AddNewInstitute(
        args.institute
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewInstituteResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Institute addressed by the primary identifier fields within the given Institute. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateInstitute")]
    [HttpPost("updateInstitute"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateInstitute), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given Institute addressed by the primary identifier fields within the given Institute. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateInstituteResponse UpdateInstitute([FromBody][SwaggerRequestBody(Required = true)]  UpdateInstituteRequest args) {
      try {
        var response = new UpdateInstituteResponse();
        response.@return = _Institutes.UpdateInstitute(
        args.institute
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateInstituteResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Institute addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateInstituteByInstituteUid")]
    [HttpPost("updateInstituteByInstituteUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateInstituteByInstituteUid), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given Institute addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateInstituteByInstituteUidResponse UpdateInstituteByInstituteUid([FromBody][SwaggerRequestBody(Required = true)]  UpdateInstituteByInstituteUidRequest args) {
      try {
        var response = new UpdateInstituteByInstituteUidResponse();
        response.@return = _Institutes.UpdateInstituteByInstituteUid(
        args.instituteUid,
        args.institute
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateInstituteByInstituteUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific Institute addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-DeleteInstituteByInstituteUid")]
    [HttpPost("deleteInstituteByInstituteUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteInstituteByInstituteUid), Description = "Deletes a specific Institute addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteInstituteByInstituteUidResponse DeleteInstituteByInstituteUid([FromBody][SwaggerRequestBody(Required = true)]  DeleteInstituteByInstituteUidRequest args) {
      try {
        var response = new DeleteInstituteByInstituteUidResponse();
        response.@return = _Institutes.DeleteInstituteByInstituteUid(
        args.instituteUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteInstituteByInstituteUidResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/researchStudies")]
  public class ResearchStudiesController : ControllerBase {
    
    private readonly ILogger<ResearchStudiesController> _Logger;
    private readonly IResearchStudies _ResearchStudies;
    
    public ResearchStudiesController(ILogger<ResearchStudiesController> logger, IResearchStudies researchStudies) {
      _Logger = logger;
      _ResearchStudies = researchStudies;
    }
    
    /// <summary> Loads a specific ResearchStudy addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetResearchStudyByResearchStudyUid")]
    [HttpPost("getResearchStudyByResearchStudyUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetResearchStudyByResearchStudyUid), Description = "Loads a specific ResearchStudy addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetResearchStudyByResearchStudyUidResponse GetResearchStudyByResearchStudyUid([FromBody][SwaggerRequestBody(Required = true)]  GetResearchStudyByResearchStudyUidRequest args) {
      try {
        var response = new GetResearchStudyByResearchStudyUidResponse();
        response.@return = _ResearchStudies.GetResearchStudyByResearchStudyUid(
        args.researchStudyUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetResearchStudyByResearchStudyUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads ResearchStudies. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetResearchStudies")]
    [HttpPost("getResearchStudies"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetResearchStudies), Description = "Loads ResearchStudies.")]
    public GetResearchStudiesResponse GetResearchStudies([FromBody][SwaggerRequestBody(Required = true)]  GetResearchStudiesRequest args) {
      try {
        var response = new GetResearchStudiesResponse();
        response.@return = _ResearchStudies.GetResearchStudies(
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetResearchStudiesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads ResearchStudies where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-SearchResearchStudies")]
    [HttpPost("searchResearchStudies"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchResearchStudies), Description = "Loads ResearchStudies where values matching to the given filterExpression")]
    public SearchResearchStudiesResponse SearchResearchStudies([FromBody][SwaggerRequestBody(Required = true)]  SearchResearchStudiesRequest args) {
      try {
        var response = new SearchResearchStudiesResponse();
        response.@return = _ResearchStudies.SearchResearchStudies(
        args.filterExpression,
        args.sortingExpression,
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchResearchStudiesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new ResearchStudy and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-AddNewResearchStudy")]
    [HttpPost("addNewResearchStudy"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewResearchStudy), Description = "Adds a new ResearchStudy and returns its primary identifier (or null on failure).")]
    public AddNewResearchStudyResponse AddNewResearchStudy([FromBody][SwaggerRequestBody(Required = true)]  AddNewResearchStudyRequest args) {
      try {
        var response = new AddNewResearchStudyResponse();
        response.@return = _ResearchStudies.AddNewResearchStudy(
        args.researchStudy
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewResearchStudyResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ResearchStudy addressed by the primary identifier fields within the given ResearchStudy. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateResearchStudy")]
    [HttpPost("updateResearchStudy"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateResearchStudy), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given ResearchStudy addressed by the primary identifier fields within the given ResearchStudy. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateResearchStudyResponse UpdateResearchStudy([FromBody][SwaggerRequestBody(Required = true)]  UpdateResearchStudyRequest args) {
      try {
        var response = new UpdateResearchStudyResponse();
        response.@return = _ResearchStudies.UpdateResearchStudy(
        args.researchStudy
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateResearchStudyResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ResearchStudy addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateResearchStudyByResearchStudyUid")]
    [HttpPost("updateResearchStudyByResearchStudyUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateResearchStudyByResearchStudyUid), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given ResearchStudy addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateResearchStudyByResearchStudyUidResponse UpdateResearchStudyByResearchStudyUid([FromBody][SwaggerRequestBody(Required = true)]  UpdateResearchStudyByResearchStudyUidRequest args) {
      try {
        var response = new UpdateResearchStudyByResearchStudyUidResponse();
        response.@return = _ResearchStudies.UpdateResearchStudyByResearchStudyUid(
        args.researchStudyUid,
        args.researchStudy
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateResearchStudyByResearchStudyUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific ResearchStudy addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-DeleteResearchStudyByResearchStudyUid")]
    [HttpPost("deleteResearchStudyByResearchStudyUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteResearchStudyByResearchStudyUid), Description = "Deletes a specific ResearchStudy addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteResearchStudyByResearchStudyUidResponse DeleteResearchStudyByResearchStudyUid([FromBody][SwaggerRequestBody(Required = true)]  DeleteResearchStudyByResearchStudyUidRequest args) {
      try {
        var response = new DeleteResearchStudyByResearchStudyUidResponse();
        response.@return = _ResearchStudies.DeleteResearchStudyByResearchStudyUid(
        args.researchStudyUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteResearchStudyByResearchStudyUidResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/sites")]
  public class SitesController : ControllerBase {
    
    private readonly ILogger<SitesController> _Logger;
    private readonly ISites _Sites;
    
    public SitesController(ILogger<SitesController> logger, ISites sites) {
      _Logger = logger;
      _Sites = sites;
    }
    
    /// <summary> Loads a specific Site addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetSiteBySiteUid")]
    [HttpPost("getSiteBySiteUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetSiteBySiteUid), Description = "Loads a specific Site addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetSiteBySiteUidResponse GetSiteBySiteUid([FromBody][SwaggerRequestBody(Required = true)]  GetSiteBySiteUidRequest args) {
      try {
        var response = new GetSiteBySiteUidResponse();
        response.@return = _Sites.GetSiteBySiteUid(
        args.siteUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetSiteBySiteUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads Sites. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetSites")]
    [HttpPost("getSites"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetSites), Description = "Loads Sites.")]
    public GetSitesResponse GetSites([FromBody][SwaggerRequestBody(Required = true)]  GetSitesRequest args) {
      try {
        var response = new GetSitesResponse();
        response.@return = _Sites.GetSites(
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetSitesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads Sites where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-SearchSites")]
    [HttpPost("searchSites"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchSites), Description = "Loads Sites where values matching to the given filterExpression")]
    public SearchSitesResponse SearchSites([FromBody][SwaggerRequestBody(Required = true)]  SearchSitesRequest args) {
      try {
        var response = new SearchSitesResponse();
        response.@return = _Sites.SearchSites(
        args.filterExpression,
        args.sortingExpression,
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchSitesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new Site and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-AddNewSite")]
    [HttpPost("addNewSite"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewSite), Description = "Adds a new Site and returns its primary identifier (or null on failure).")]
    public AddNewSiteResponse AddNewSite([FromBody][SwaggerRequestBody(Required = true)]  AddNewSiteRequest args) {
      try {
        var response = new AddNewSiteResponse();
        response.@return = _Sites.AddNewSite(
        args.site
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewSiteResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Site addressed by the primary identifier fields within the given Site. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateSite")]
    [HttpPost("updateSite"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateSite), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given Site addressed by the primary identifier fields within the given Site. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateSiteResponse UpdateSite([FromBody][SwaggerRequestBody(Required = true)]  UpdateSiteRequest args) {
      try {
        var response = new UpdateSiteResponse();
        response.@return = _Sites.UpdateSite(
        args.site
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateSiteResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Site addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateSiteBySiteUid")]
    [HttpPost("updateSiteBySiteUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateSiteBySiteUid), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given Site addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateSiteBySiteUidResponse UpdateSiteBySiteUid([FromBody][SwaggerRequestBody(Required = true)]  UpdateSiteBySiteUidRequest args) {
      try {
        var response = new UpdateSiteBySiteUidResponse();
        response.@return = _Sites.UpdateSiteBySiteUid(
        args.siteUid,
        args.site
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateSiteBySiteUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific Site addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-DeleteSiteBySiteUid")]
    [HttpPost("deleteSiteBySiteUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteSiteBySiteUid), Description = "Deletes a specific Site addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteSiteBySiteUidResponse DeleteSiteBySiteUid([FromBody][SwaggerRequestBody(Required = true)]  DeleteSiteBySiteUidRequest args) {
      try {
        var response = new DeleteSiteBySiteUidResponse();
        response.@return = _Sites.DeleteSiteBySiteUid(
        args.siteUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteSiteBySiteUidResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/systemEndpoints")]
  public class SystemEndpointsController : ControllerBase {
    
    private readonly ILogger<SystemEndpointsController> _Logger;
    private readonly ISystemEndpoints _SystemEndpoints;
    
    public SystemEndpointsController(ILogger<SystemEndpointsController> logger, ISystemEndpoints systemEndpoints) {
      _Logger = logger;
      _SystemEndpoints = systemEndpoints;
    }
    
    /// <summary> Loads a specific SystemEndpoint addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetSystemEndpointBySystemEndpointUid")]
    [HttpPost("getSystemEndpointBySystemEndpointUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetSystemEndpointBySystemEndpointUid), Description = "Loads a specific SystemEndpoint addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetSystemEndpointBySystemEndpointUidResponse GetSystemEndpointBySystemEndpointUid([FromBody][SwaggerRequestBody(Required = true)]  GetSystemEndpointBySystemEndpointUidRequest args) {
      try {
        var response = new GetSystemEndpointBySystemEndpointUidResponse();
        response.@return = _SystemEndpoints.GetSystemEndpointBySystemEndpointUid(
        args.systemEndpointUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetSystemEndpointBySystemEndpointUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads SystemEndpoints. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetSystemEndpoints")]
    [HttpPost("getSystemEndpoints"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetSystemEndpoints), Description = "Loads SystemEndpoints.")]
    public GetSystemEndpointsResponse GetSystemEndpoints([FromBody][SwaggerRequestBody(Required = true)]  GetSystemEndpointsRequest args) {
      try {
        var response = new GetSystemEndpointsResponse();
        response.@return = _SystemEndpoints.GetSystemEndpoints(
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetSystemEndpointsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads SystemEndpoints where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-SearchSystemEndpoints")]
    [HttpPost("searchSystemEndpoints"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchSystemEndpoints), Description = "Loads SystemEndpoints where values matching to the given filterExpression")]
    public SearchSystemEndpointsResponse SearchSystemEndpoints([FromBody][SwaggerRequestBody(Required = true)]  SearchSystemEndpointsRequest args) {
      try {
        var response = new SearchSystemEndpointsResponse();
        response.@return = _SystemEndpoints.SearchSystemEndpoints(
        args.filterExpression,
        args.sortingExpression,
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchSystemEndpointsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new SystemEndpoint and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-AddNewSystemEndpoint")]
    [HttpPost("addNewSystemEndpoint"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewSystemEndpoint), Description = "Adds a new SystemEndpoint and returns its primary identifier (or null on failure).")]
    public AddNewSystemEndpointResponse AddNewSystemEndpoint([FromBody][SwaggerRequestBody(Required = true)]  AddNewSystemEndpointRequest args) {
      try {
        var response = new AddNewSystemEndpointResponse();
        response.@return = _SystemEndpoints.AddNewSystemEndpoint(
        args.systemEndpoint
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewSystemEndpointResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SystemEndpoint addressed by the primary identifier fields within the given SystemEndpoint. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateSystemEndpoint")]
    [HttpPost("updateSystemEndpoint"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateSystemEndpoint), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given SystemEndpoint addressed by the primary identifier fields within the given SystemEndpoint. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateSystemEndpointResponse UpdateSystemEndpoint([FromBody][SwaggerRequestBody(Required = true)]  UpdateSystemEndpointRequest args) {
      try {
        var response = new UpdateSystemEndpointResponse();
        response.@return = _SystemEndpoints.UpdateSystemEndpoint(
        args.systemEndpoint
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateSystemEndpointResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SystemEndpoint addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateSystemEndpointBySystemEndpointUid")]
    [HttpPost("updateSystemEndpointBySystemEndpointUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateSystemEndpointBySystemEndpointUid), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given SystemEndpoint addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateSystemEndpointBySystemEndpointUidResponse UpdateSystemEndpointBySystemEndpointUid([FromBody][SwaggerRequestBody(Required = true)]  UpdateSystemEndpointBySystemEndpointUidRequest args) {
      try {
        var response = new UpdateSystemEndpointBySystemEndpointUidResponse();
        response.@return = _SystemEndpoints.UpdateSystemEndpointBySystemEndpointUid(
        args.systemEndpointUid,
        args.systemEndpoint
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateSystemEndpointBySystemEndpointUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific SystemEndpoint addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-DeleteSystemEndpointBySystemEndpointUid")]
    [HttpPost("deleteSystemEndpointBySystemEndpointUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteSystemEndpointBySystemEndpointUid), Description = "Deletes a specific SystemEndpoint addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteSystemEndpointBySystemEndpointUidResponse DeleteSystemEndpointBySystemEndpointUid([FromBody][SwaggerRequestBody(Required = true)]  DeleteSystemEndpointBySystemEndpointUidRequest args) {
      try {
        var response = new DeleteSystemEndpointBySystemEndpointUidResponse();
        response.@return = _SystemEndpoints.DeleteSystemEndpointBySystemEndpointUid(
        args.systemEndpointUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteSystemEndpointBySystemEndpointUidResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/instituteRelatedSystemAssignments")]
  public class InstituteRelatedSystemAssignmentsController : ControllerBase {
    
    private readonly ILogger<InstituteRelatedSystemAssignmentsController> _Logger;
    private readonly IInstituteRelatedSystemAssignments _InstituteRelatedSystemAssignments;
    
    public InstituteRelatedSystemAssignmentsController(ILogger<InstituteRelatedSystemAssignmentsController> logger, IInstituteRelatedSystemAssignments instituteRelatedSystemAssignments) {
      _Logger = logger;
      _InstituteRelatedSystemAssignments = instituteRelatedSystemAssignments;
    }
    
    /// <summary> Loads a specific InstituteRelatedSystemAssignment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUid")]
    [HttpPost("getInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUid), Description = "Loads a specific InstituteRelatedSystemAssignment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUidResponse GetInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUid([FromBody][SwaggerRequestBody(Required = true)]  GetInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUidRequest args) {
      try {
        var response = new GetInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUidResponse();
        response.@return = _InstituteRelatedSystemAssignments.GetInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUid(
        args.instituteRelatedSystemAssignemntUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads InstituteRelatedSystemAssignments. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetInstituteRelatedSystemAssignments")]
    [HttpPost("getInstituteRelatedSystemAssignments"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetInstituteRelatedSystemAssignments), Description = "Loads InstituteRelatedSystemAssignments.")]
    public GetInstituteRelatedSystemAssignmentsResponse GetInstituteRelatedSystemAssignments([FromBody][SwaggerRequestBody(Required = true)]  GetInstituteRelatedSystemAssignmentsRequest args) {
      try {
        var response = new GetInstituteRelatedSystemAssignmentsResponse();
        response.@return = _InstituteRelatedSystemAssignments.GetInstituteRelatedSystemAssignments(
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetInstituteRelatedSystemAssignmentsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads InstituteRelatedSystemAssignments where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-SearchInstituteRelatedSystemAssignments")]
    [HttpPost("searchInstituteRelatedSystemAssignments"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchInstituteRelatedSystemAssignments), Description = "Loads InstituteRelatedSystemAssignments where values matching to the given filterExpression")]
    public SearchInstituteRelatedSystemAssignmentsResponse SearchInstituteRelatedSystemAssignments([FromBody][SwaggerRequestBody(Required = true)]  SearchInstituteRelatedSystemAssignmentsRequest args) {
      try {
        var response = new SearchInstituteRelatedSystemAssignmentsResponse();
        response.@return = _InstituteRelatedSystemAssignments.SearchInstituteRelatedSystemAssignments(
        args.filterExpression,
        args.sortingExpression,
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchInstituteRelatedSystemAssignmentsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new InstituteRelatedSystemAssignment and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-AddNewInstituteRelatedSystemAssignment")]
    [HttpPost("addNewInstituteRelatedSystemAssignment"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewInstituteRelatedSystemAssignment), Description = "Adds a new InstituteRelatedSystemAssignment and returns its primary identifier (or null on failure).")]
    public AddNewInstituteRelatedSystemAssignmentResponse AddNewInstituteRelatedSystemAssignment([FromBody][SwaggerRequestBody(Required = true)]  AddNewInstituteRelatedSystemAssignmentRequest args) {
      try {
        var response = new AddNewInstituteRelatedSystemAssignmentResponse();
        response.@return = _InstituteRelatedSystemAssignments.AddNewInstituteRelatedSystemAssignment(
        args.instituteRelatedSystemAssignment
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewInstituteRelatedSystemAssignmentResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InstituteRelatedSystemAssignment addressed by the primary identifier fields within the given InstituteRelatedSystemAssignment. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateInstituteRelatedSystemAssignment")]
    [HttpPost("updateInstituteRelatedSystemAssignment"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateInstituteRelatedSystemAssignment), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given InstituteRelatedSystemAssignment addressed by the primary identifier fields within the given InstituteRelatedSystemAssignment. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateInstituteRelatedSystemAssignmentResponse UpdateInstituteRelatedSystemAssignment([FromBody][SwaggerRequestBody(Required = true)]  UpdateInstituteRelatedSystemAssignmentRequest args) {
      try {
        var response = new UpdateInstituteRelatedSystemAssignmentResponse();
        response.@return = _InstituteRelatedSystemAssignments.UpdateInstituteRelatedSystemAssignment(
        args.instituteRelatedSystemAssignment
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateInstituteRelatedSystemAssignmentResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InstituteRelatedSystemAssignment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUid")]
    [HttpPost("updateInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUid), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given InstituteRelatedSystemAssignment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUidResponse UpdateInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUid([FromBody][SwaggerRequestBody(Required = true)]  UpdateInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUidRequest args) {
      try {
        var response = new UpdateInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUidResponse();
        response.@return = _InstituteRelatedSystemAssignments.UpdateInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUid(
        args.instituteRelatedSystemAssignemntUid,
        args.instituteRelatedSystemAssignment
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific InstituteRelatedSystemAssignment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-DeleteInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUid")]
    [HttpPost("deleteInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUid), Description = "Deletes a specific InstituteRelatedSystemAssignment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUidResponse DeleteInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUid([FromBody][SwaggerRequestBody(Required = true)]  DeleteInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUidRequest args) {
      try {
        var response = new DeleteInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUidResponse();
        response.@return = _InstituteRelatedSystemAssignments.DeleteInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUid(
        args.instituteRelatedSystemAssignemntUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteInstituteRelatedSystemAssignmentByInstituteRelatedSystemAssignemntUidResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/systemConnections")]
  public class SystemConnectionsController : ControllerBase {
    
    private readonly ILogger<SystemConnectionsController> _Logger;
    private readonly ISystemConnections _SystemConnections;
    
    public SystemConnectionsController(ILogger<SystemConnectionsController> logger, ISystemConnections systemConnections) {
      _Logger = logger;
      _SystemConnections = systemConnections;
    }
    
    /// <summary> Loads a specific SystemConnection addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetSystemConnectionBySystemConnectionUid")]
    [HttpPost("getSystemConnectionBySystemConnectionUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetSystemConnectionBySystemConnectionUid), Description = "Loads a specific SystemConnection addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetSystemConnectionBySystemConnectionUidResponse GetSystemConnectionBySystemConnectionUid([FromBody][SwaggerRequestBody(Required = true)]  GetSystemConnectionBySystemConnectionUidRequest args) {
      try {
        var response = new GetSystemConnectionBySystemConnectionUidResponse();
        response.@return = _SystemConnections.GetSystemConnectionBySystemConnectionUid(
        args.systemConnectionUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetSystemConnectionBySystemConnectionUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads SystemConnections. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetSystemConnections")]
    [HttpPost("getSystemConnections"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetSystemConnections), Description = "Loads SystemConnections.")]
    public GetSystemConnectionsResponse GetSystemConnections([FromBody][SwaggerRequestBody(Required = true)]  GetSystemConnectionsRequest args) {
      try {
        var response = new GetSystemConnectionsResponse();
        response.@return = _SystemConnections.GetSystemConnections(
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetSystemConnectionsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads SystemConnections where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-SearchSystemConnections")]
    [HttpPost("searchSystemConnections"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchSystemConnections), Description = "Loads SystemConnections where values matching to the given filterExpression")]
    public SearchSystemConnectionsResponse SearchSystemConnections([FromBody][SwaggerRequestBody(Required = true)]  SearchSystemConnectionsRequest args) {
      try {
        var response = new SearchSystemConnectionsResponse();
        response.@return = _SystemConnections.SearchSystemConnections(
        args.filterExpression,
        args.sortingExpression,
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchSystemConnectionsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new SystemConnection and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-AddNewSystemConnection")]
    [HttpPost("addNewSystemConnection"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewSystemConnection), Description = "Adds a new SystemConnection and returns its primary identifier (or null on failure).")]
    public AddNewSystemConnectionResponse AddNewSystemConnection([FromBody][SwaggerRequestBody(Required = true)]  AddNewSystemConnectionRequest args) {
      try {
        var response = new AddNewSystemConnectionResponse();
        response.@return = _SystemConnections.AddNewSystemConnection(
        args.systemConnection
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewSystemConnectionResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SystemConnection addressed by the primary identifier fields within the given SystemConnection. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateSystemConnection")]
    [HttpPost("updateSystemConnection"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateSystemConnection), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given SystemConnection addressed by the primary identifier fields within the given SystemConnection. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateSystemConnectionResponse UpdateSystemConnection([FromBody][SwaggerRequestBody(Required = true)]  UpdateSystemConnectionRequest args) {
      try {
        var response = new UpdateSystemConnectionResponse();
        response.@return = _SystemConnections.UpdateSystemConnection(
        args.systemConnection
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateSystemConnectionResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SystemConnection addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateSystemConnectionBySystemConnectionUid")]
    [HttpPost("updateSystemConnectionBySystemConnectionUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateSystemConnectionBySystemConnectionUid), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given SystemConnection addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateSystemConnectionBySystemConnectionUidResponse UpdateSystemConnectionBySystemConnectionUid([FromBody][SwaggerRequestBody(Required = true)]  UpdateSystemConnectionBySystemConnectionUidRequest args) {
      try {
        var response = new UpdateSystemConnectionBySystemConnectionUidResponse();
        response.@return = _SystemConnections.UpdateSystemConnectionBySystemConnectionUid(
        args.systemConnectionUid,
        args.systemConnection
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateSystemConnectionBySystemConnectionUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific SystemConnection addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-DeleteSystemConnectionBySystemConnectionUid")]
    [HttpPost("deleteSystemConnectionBySystemConnectionUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteSystemConnectionBySystemConnectionUid), Description = "Deletes a specific SystemConnection addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteSystemConnectionBySystemConnectionUidResponse DeleteSystemConnectionBySystemConnectionUid([FromBody][SwaggerRequestBody(Required = true)]  DeleteSystemConnectionBySystemConnectionUidRequest args) {
      try {
        var response = new DeleteSystemConnectionBySystemConnectionUidResponse();
        response.@return = _SystemConnections.DeleteSystemConnectionBySystemConnectionUid(
        args.systemConnectionUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteSystemConnectionBySystemConnectionUidResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/involvedPersons")]
  public class InvolvedPersonsController : ControllerBase {
    
    private readonly ILogger<InvolvedPersonsController> _Logger;
    private readonly IInvolvedPersons _InvolvedPersons;
    
    public InvolvedPersonsController(ILogger<InvolvedPersonsController> logger, IInvolvedPersons involvedPersons) {
      _Logger = logger;
      _InvolvedPersons = involvedPersons;
    }
    
    /// <summary> Loads a specific InvolvedPerson addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetInvolvedPersonByInvolvedPersonUid")]
    [HttpPost("getInvolvedPersonByInvolvedPersonUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetInvolvedPersonByInvolvedPersonUid), Description = "Loads a specific InvolvedPerson addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetInvolvedPersonByInvolvedPersonUidResponse GetInvolvedPersonByInvolvedPersonUid([FromBody][SwaggerRequestBody(Required = true)]  GetInvolvedPersonByInvolvedPersonUidRequest args) {
      try {
        var response = new GetInvolvedPersonByInvolvedPersonUidResponse();
        response.@return = _InvolvedPersons.GetInvolvedPersonByInvolvedPersonUid(
        args.involvedPersonUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetInvolvedPersonByInvolvedPersonUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads InvolvedPersons. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetInvolvedPersons")]
    [HttpPost("getInvolvedPersons"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetInvolvedPersons), Description = "Loads InvolvedPersons.")]
    public GetInvolvedPersonsResponse GetInvolvedPersons([FromBody][SwaggerRequestBody(Required = true)]  GetInvolvedPersonsRequest args) {
      try {
        var response = new GetInvolvedPersonsResponse();
        response.@return = _InvolvedPersons.GetInvolvedPersons(
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetInvolvedPersonsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads InvolvedPersons where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-SearchInvolvedPersons")]
    [HttpPost("searchInvolvedPersons"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchInvolvedPersons), Description = "Loads InvolvedPersons where values matching to the given filterExpression")]
    public SearchInvolvedPersonsResponse SearchInvolvedPersons([FromBody][SwaggerRequestBody(Required = true)]  SearchInvolvedPersonsRequest args) {
      try {
        var response = new SearchInvolvedPersonsResponse();
        response.@return = _InvolvedPersons.SearchInvolvedPersons(
        args.filterExpression,
        args.sortingExpression,
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchInvolvedPersonsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new InvolvedPerson and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-AddNewInvolvedPerson")]
    [HttpPost("addNewInvolvedPerson"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewInvolvedPerson), Description = "Adds a new InvolvedPerson and returns its primary identifier (or null on failure).")]
    public AddNewInvolvedPersonResponse AddNewInvolvedPerson([FromBody][SwaggerRequestBody(Required = true)]  AddNewInvolvedPersonRequest args) {
      try {
        var response = new AddNewInvolvedPersonResponse();
        response.@return = _InvolvedPersons.AddNewInvolvedPerson(
        args.involvedPerson
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewInvolvedPersonResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InvolvedPerson addressed by the primary identifier fields within the given InvolvedPerson. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateInvolvedPerson")]
    [HttpPost("updateInvolvedPerson"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateInvolvedPerson), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given InvolvedPerson addressed by the primary identifier fields within the given InvolvedPerson. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateInvolvedPersonResponse UpdateInvolvedPerson([FromBody][SwaggerRequestBody(Required = true)]  UpdateInvolvedPersonRequest args) {
      try {
        var response = new UpdateInvolvedPersonResponse();
        response.@return = _InvolvedPersons.UpdateInvolvedPerson(
        args.involvedPerson
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateInvolvedPersonResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InvolvedPerson addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateInvolvedPersonByInvolvedPersonUid")]
    [HttpPost("updateInvolvedPersonByInvolvedPersonUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateInvolvedPersonByInvolvedPersonUid), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given InvolvedPerson addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateInvolvedPersonByInvolvedPersonUidResponse UpdateInvolvedPersonByInvolvedPersonUid([FromBody][SwaggerRequestBody(Required = true)]  UpdateInvolvedPersonByInvolvedPersonUidRequest args) {
      try {
        var response = new UpdateInvolvedPersonByInvolvedPersonUidResponse();
        response.@return = _InvolvedPersons.UpdateInvolvedPersonByInvolvedPersonUid(
        args.involvedPersonUid,
        args.involvedPerson
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateInvolvedPersonByInvolvedPersonUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific InvolvedPerson addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-DeleteInvolvedPersonByInvolvedPersonUid")]
    [HttpPost("deleteInvolvedPersonByInvolvedPersonUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteInvolvedPersonByInvolvedPersonUid), Description = "Deletes a specific InvolvedPerson addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteInvolvedPersonByInvolvedPersonUidResponse DeleteInvolvedPersonByInvolvedPersonUid([FromBody][SwaggerRequestBody(Required = true)]  DeleteInvolvedPersonByInvolvedPersonUidRequest args) {
      try {
        var response = new DeleteInvolvedPersonByInvolvedPersonUidResponse();
        response.@return = _InvolvedPersons.DeleteInvolvedPersonByInvolvedPersonUid(
        args.involvedPersonUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteInvolvedPersonByInvolvedPersonUidResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/involvementRoles")]
  public class InvolvementRolesController : ControllerBase {
    
    private readonly ILogger<InvolvementRolesController> _Logger;
    private readonly IInvolvementRoles _InvolvementRoles;
    
    public InvolvementRolesController(ILogger<InvolvementRolesController> logger, IInvolvementRoles involvementRoles) {
      _Logger = logger;
      _InvolvementRoles = involvementRoles;
    }
    
    /// <summary> Loads a specific InvolvementRole addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetInvolvementRoleByInvolvedPersonRoleUid")]
    [HttpPost("getInvolvementRoleByInvolvedPersonRoleUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetInvolvementRoleByInvolvedPersonRoleUid), Description = "Loads a specific InvolvementRole addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetInvolvementRoleByInvolvedPersonRoleUidResponse GetInvolvementRoleByInvolvedPersonRoleUid([FromBody][SwaggerRequestBody(Required = true)]  GetInvolvementRoleByInvolvedPersonRoleUidRequest args) {
      try {
        var response = new GetInvolvementRoleByInvolvedPersonRoleUidResponse();
        response.@return = _InvolvementRoles.GetInvolvementRoleByInvolvedPersonRoleUid(
        args.involvedPersonRoleUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetInvolvementRoleByInvolvedPersonRoleUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads InvolvementRoles. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetInvolvementRoles")]
    [HttpPost("getInvolvementRoles"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetInvolvementRoles), Description = "Loads InvolvementRoles.")]
    public GetInvolvementRolesResponse GetInvolvementRoles([FromBody][SwaggerRequestBody(Required = true)]  GetInvolvementRolesRequest args) {
      try {
        var response = new GetInvolvementRolesResponse();
        response.@return = _InvolvementRoles.GetInvolvementRoles(
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetInvolvementRolesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads InvolvementRoles where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-SearchInvolvementRoles")]
    [HttpPost("searchInvolvementRoles"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchInvolvementRoles), Description = "Loads InvolvementRoles where values matching to the given filterExpression")]
    public SearchInvolvementRolesResponse SearchInvolvementRoles([FromBody][SwaggerRequestBody(Required = true)]  SearchInvolvementRolesRequest args) {
      try {
        var response = new SearchInvolvementRolesResponse();
        response.@return = _InvolvementRoles.SearchInvolvementRoles(
        args.filterExpression,
        args.sortingExpression,
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchInvolvementRolesResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new InvolvementRole and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-AddNewInvolvementRole")]
    [HttpPost("addNewInvolvementRole"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewInvolvementRole), Description = "Adds a new InvolvementRole and returns its primary identifier (or null on failure).")]
    public AddNewInvolvementRoleResponse AddNewInvolvementRole([FromBody][SwaggerRequestBody(Required = true)]  AddNewInvolvementRoleRequest args) {
      try {
        var response = new AddNewInvolvementRoleResponse();
        response.@return = _InvolvementRoles.AddNewInvolvementRole(
        args.involvementRole
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewInvolvementRoleResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InvolvementRole addressed by the primary identifier fields within the given InvolvementRole. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateInvolvementRole")]
    [HttpPost("updateInvolvementRole"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateInvolvementRole), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given InvolvementRole addressed by the primary identifier fields within the given InvolvementRole. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateInvolvementRoleResponse UpdateInvolvementRole([FromBody][SwaggerRequestBody(Required = true)]  UpdateInvolvementRoleRequest args) {
      try {
        var response = new UpdateInvolvementRoleResponse();
        response.@return = _InvolvementRoles.UpdateInvolvementRole(
        args.involvementRole
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateInvolvementRoleResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InvolvementRole addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateInvolvementRoleByInvolvedPersonRoleUid")]
    [HttpPost("updateInvolvementRoleByInvolvedPersonRoleUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateInvolvementRoleByInvolvedPersonRoleUid), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given InvolvementRole addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateInvolvementRoleByInvolvedPersonRoleUidResponse UpdateInvolvementRoleByInvolvedPersonRoleUid([FromBody][SwaggerRequestBody(Required = true)]  UpdateInvolvementRoleByInvolvedPersonRoleUidRequest args) {
      try {
        var response = new UpdateInvolvementRoleByInvolvedPersonRoleUidResponse();
        response.@return = _InvolvementRoles.UpdateInvolvementRoleByInvolvedPersonRoleUid(
        args.involvedPersonRoleUid,
        args.involvementRole
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateInvolvementRoleByInvolvedPersonRoleUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific InvolvementRole addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-DeleteInvolvementRoleByInvolvedPersonRoleUid")]
    [HttpPost("deleteInvolvementRoleByInvolvedPersonRoleUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteInvolvementRoleByInvolvedPersonRoleUid), Description = "Deletes a specific InvolvementRole addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteInvolvementRoleByInvolvedPersonRoleUidResponse DeleteInvolvementRoleByInvolvedPersonRoleUid([FromBody][SwaggerRequestBody(Required = true)]  DeleteInvolvementRoleByInvolvedPersonRoleUidRequest args) {
      try {
        var response = new DeleteInvolvementRoleByInvolvedPersonRoleUidResponse();
        response.@return = _InvolvementRoles.DeleteInvolvementRoleByInvolvedPersonRoleUid(
        args.involvedPersonRoleUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteInvolvementRoleByInvolvedPersonRoleUidResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/studyRelatedSystemAssignments")]
  public class StudyRelatedSystemAssignmentsController : ControllerBase {
    
    private readonly ILogger<StudyRelatedSystemAssignmentsController> _Logger;
    private readonly IStudyRelatedSystemAssignments _StudyRelatedSystemAssignments;
    
    public StudyRelatedSystemAssignmentsController(ILogger<StudyRelatedSystemAssignmentsController> logger, IStudyRelatedSystemAssignments studyRelatedSystemAssignments) {
      _Logger = logger;
      _StudyRelatedSystemAssignments = studyRelatedSystemAssignments;
    }
    
    /// <summary> Loads a specific StudyRelatedSystemAssignment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid")]
    [HttpPost("getStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid), Description = "Loads a specific StudyRelatedSystemAssignment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUidResponse GetStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid([FromBody][SwaggerRequestBody(Required = true)]  GetStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUidRequest args) {
      try {
        var response = new GetStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUidResponse();
        response.@return = _StudyRelatedSystemAssignments.GetStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid(
        args.studyRelatedSystemAssignmentUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads StudyRelatedSystemAssignments. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetStudyRelatedSystemAssignments")]
    [HttpPost("getStudyRelatedSystemAssignments"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetStudyRelatedSystemAssignments), Description = "Loads StudyRelatedSystemAssignments.")]
    public GetStudyRelatedSystemAssignmentsResponse GetStudyRelatedSystemAssignments([FromBody][SwaggerRequestBody(Required = true)]  GetStudyRelatedSystemAssignmentsRequest args) {
      try {
        var response = new GetStudyRelatedSystemAssignmentsResponse();
        response.@return = _StudyRelatedSystemAssignments.GetStudyRelatedSystemAssignments(
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetStudyRelatedSystemAssignmentsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads StudyRelatedSystemAssignments where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-SearchStudyRelatedSystemAssignments")]
    [HttpPost("searchStudyRelatedSystemAssignments"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchStudyRelatedSystemAssignments), Description = "Loads StudyRelatedSystemAssignments where values matching to the given filterExpression")]
    public SearchStudyRelatedSystemAssignmentsResponse SearchStudyRelatedSystemAssignments([FromBody][SwaggerRequestBody(Required = true)]  SearchStudyRelatedSystemAssignmentsRequest args) {
      try {
        var response = new SearchStudyRelatedSystemAssignmentsResponse();
        response.@return = _StudyRelatedSystemAssignments.SearchStudyRelatedSystemAssignments(
        args.filterExpression,
        args.sortingExpression,
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchStudyRelatedSystemAssignmentsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new StudyRelatedSystemAssignment and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-AddNewStudyRelatedSystemAssignment")]
    [HttpPost("addNewStudyRelatedSystemAssignment"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewStudyRelatedSystemAssignment), Description = "Adds a new StudyRelatedSystemAssignment and returns its primary identifier (or null on failure).")]
    public AddNewStudyRelatedSystemAssignmentResponse AddNewStudyRelatedSystemAssignment([FromBody][SwaggerRequestBody(Required = true)]  AddNewStudyRelatedSystemAssignmentRequest args) {
      try {
        var response = new AddNewStudyRelatedSystemAssignmentResponse();
        response.@return = _StudyRelatedSystemAssignments.AddNewStudyRelatedSystemAssignment(
        args.studyRelatedSystemAssignment
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewStudyRelatedSystemAssignmentResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyRelatedSystemAssignment addressed by the primary identifier fields within the given StudyRelatedSystemAssignment. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateStudyRelatedSystemAssignment")]
    [HttpPost("updateStudyRelatedSystemAssignment"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateStudyRelatedSystemAssignment), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given StudyRelatedSystemAssignment addressed by the primary identifier fields within the given StudyRelatedSystemAssignment. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateStudyRelatedSystemAssignmentResponse UpdateStudyRelatedSystemAssignment([FromBody][SwaggerRequestBody(Required = true)]  UpdateStudyRelatedSystemAssignmentRequest args) {
      try {
        var response = new UpdateStudyRelatedSystemAssignmentResponse();
        response.@return = _StudyRelatedSystemAssignments.UpdateStudyRelatedSystemAssignment(
        args.studyRelatedSystemAssignment
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateStudyRelatedSystemAssignmentResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyRelatedSystemAssignment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid")]
    [HttpPost("updateStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given StudyRelatedSystemAssignment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUidResponse UpdateStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid([FromBody][SwaggerRequestBody(Required = true)]  UpdateStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUidRequest args) {
      try {
        var response = new UpdateStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUidResponse();
        response.@return = _StudyRelatedSystemAssignments.UpdateStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid(
        args.studyRelatedSystemAssignmentUid,
        args.studyRelatedSystemAssignment
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific StudyRelatedSystemAssignment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-DeleteStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid")]
    [HttpPost("deleteStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid), Description = "Deletes a specific StudyRelatedSystemAssignment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUidResponse DeleteStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid([FromBody][SwaggerRequestBody(Required = true)]  DeleteStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUidRequest args) {
      try {
        var response = new DeleteStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUidResponse();
        response.@return = _StudyRelatedSystemAssignments.DeleteStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUid(
        args.studyRelatedSystemAssignmentUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteStudyRelatedSystemAssignmentByStudyRelatedSystemAssignmentUidResponse { fault = ex.Message };
      }
    }
    
  }
  
  [ApiController]
  [ApiExplorerSettings(GroupName = "StoreAccessV1")]
  [Route("store/siteRelatedSystemAssignments")]
  public class SiteRelatedSystemAssignmentsController : ControllerBase {
    
    private readonly ILogger<SiteRelatedSystemAssignmentsController> _Logger;
    private readonly ISiteRelatedSystemAssignments _SiteRelatedSystemAssignments;
    
    public SiteRelatedSystemAssignmentsController(ILogger<SiteRelatedSystemAssignmentsController> logger, ISiteRelatedSystemAssignments siteRelatedSystemAssignments) {
      _Logger = logger;
      _SiteRelatedSystemAssignments = siteRelatedSystemAssignments;
    }
    
    /// <summary> Loads a specific SiteRelatedSystemAssignment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid")]
    [HttpPost("getSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid), Description = "Loads a specific SiteRelatedSystemAssignment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.")]
    public GetSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUidResponse GetSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid([FromBody][SwaggerRequestBody(Required = true)]  GetSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUidRequest args) {
      try {
        var response = new GetSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUidResponse();
        response.@return = _SiteRelatedSystemAssignments.GetSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid(
        args.siteRelatedSystemAssignmentUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads SiteRelatedSystemAssignments. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-GetSiteRelatedSystemAssignments")]
    [HttpPost("getSiteRelatedSystemAssignments"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(GetSiteRelatedSystemAssignments), Description = "Loads SiteRelatedSystemAssignments.")]
    public GetSiteRelatedSystemAssignmentsResponse GetSiteRelatedSystemAssignments([FromBody][SwaggerRequestBody(Required = true)]  GetSiteRelatedSystemAssignmentsRequest args) {
      try {
        var response = new GetSiteRelatedSystemAssignmentsResponse();
        response.@return = _SiteRelatedSystemAssignments.GetSiteRelatedSystemAssignments(
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new GetSiteRelatedSystemAssignmentsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Loads SiteRelatedSystemAssignments where values matching to the given filterExpression </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-SearchSiteRelatedSystemAssignments")]
    [HttpPost("searchSiteRelatedSystemAssignments"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(SearchSiteRelatedSystemAssignments), Description = "Loads SiteRelatedSystemAssignments where values matching to the given filterExpression")]
    public SearchSiteRelatedSystemAssignmentsResponse SearchSiteRelatedSystemAssignments([FromBody][SwaggerRequestBody(Required = true)]  SearchSiteRelatedSystemAssignmentsRequest args) {
      try {
        var response = new SearchSiteRelatedSystemAssignmentsResponse();
        response.@return = _SiteRelatedSystemAssignments.SearchSiteRelatedSystemAssignments(
        args.filterExpression,
        args.sortingExpression,
        (args.page.HasValue ? args.page.Value : 1),
        (args.pageSize.HasValue ? args.pageSize.Value : 20)
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new SearchSiteRelatedSystemAssignmentsResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Adds a new SiteRelatedSystemAssignment and returns its primary identifier (or null on failure). </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-AddNewSiteRelatedSystemAssignment")]
    [HttpPost("addNewSiteRelatedSystemAssignment"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(AddNewSiteRelatedSystemAssignment), Description = "Adds a new SiteRelatedSystemAssignment and returns its primary identifier (or null on failure).")]
    public AddNewSiteRelatedSystemAssignmentResponse AddNewSiteRelatedSystemAssignment([FromBody][SwaggerRequestBody(Required = true)]  AddNewSiteRelatedSystemAssignmentRequest args) {
      try {
        var response = new AddNewSiteRelatedSystemAssignmentResponse();
        response.@return = _SiteRelatedSystemAssignments.AddNewSiteRelatedSystemAssignment(
        args.siteRelatedSystemAssignment
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new AddNewSiteRelatedSystemAssignmentResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SiteRelatedSystemAssignment addressed by the primary identifier fields within the given SiteRelatedSystemAssignment. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateSiteRelatedSystemAssignment")]
    [HttpPost("updateSiteRelatedSystemAssignment"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateSiteRelatedSystemAssignment), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given SiteRelatedSystemAssignment addressed by the primary identifier fields within the given SiteRelatedSystemAssignment. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateSiteRelatedSystemAssignmentResponse UpdateSiteRelatedSystemAssignment([FromBody][SwaggerRequestBody(Required = true)]  UpdateSiteRelatedSystemAssignmentRequest args) {
      try {
        var response = new UpdateSiteRelatedSystemAssignmentResponse();
        response.@return = _SiteRelatedSystemAssignments.UpdateSiteRelatedSystemAssignment(
        args.siteRelatedSystemAssignment
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateSiteRelatedSystemAssignmentResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SiteRelatedSystemAssignment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-UpdateSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid")]
    [HttpPost("updateSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(UpdateSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid), Description = "Updates all values (which are not \"FixedAfterCreation\") of the given SiteRelatedSystemAssignment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public UpdateSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUidResponse UpdateSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid([FromBody][SwaggerRequestBody(Required = true)]  UpdateSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUidRequest args) {
      try {
        var response = new UpdateSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUidResponse();
        response.@return = _SiteRelatedSystemAssignments.UpdateSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid(
        args.siteRelatedSystemAssignmentUid,
        args.siteRelatedSystemAssignment
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new UpdateSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUidResponse { fault = ex.Message };
      }
    }
    
    /// <summary> Deletes a specific SiteRelatedSystemAssignment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true. </summary>
    /// <param name="args"> request capsule containing the method arguments </param>
    [RequireBaererAuth("store-DeleteSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid")]
    [HttpPost("deleteSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid"), Produces("application/json")]
    [SwaggerOperation(OperationId = nameof(DeleteSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid), Description = "Deletes a specific SiteRelatedSystemAssignment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.")]
    public DeleteSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUidResponse DeleteSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid([FromBody][SwaggerRequestBody(Required = true)]  DeleteSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUidRequest args) {
      try {
        var response = new DeleteSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUidResponse();
        response.@return = _SiteRelatedSystemAssignments.DeleteSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUid(
        args.siteRelatedSystemAssignmentUid
        );
        return response;
      }
      catch (Exception ex) {
        _Logger.LogCritical(ex, ex.Message);
        return new DeleteSiteRelatedSystemAssignmentBySiteRelatedSystemAssignmentUidResponse { fault = ex.Message };
      }
    }
    
  }
  
}
