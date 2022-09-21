using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MedicalResearch.VisitData.Persistence.EF;
using MedicalResearch.VisitData;
using System;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Threading.Tasks;
using MedicalResearch.VisitData.Persistence;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using System.IO;
using MedicalResearch.VisitData.StoreAccess;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Writers;
using MedicalResearch.VisitData.Model;
using Security.AccessTokenHandling;

namespace MedicalResearch.VisitData.WebAPI {

  public class Startup {

    public Startup(IConfiguration configuration) {
      _Configuration = configuration;
      VisitDataDbContext.ConnectionString = configuration.GetValue<String>("SqlConnectionString");
    }

    private static IConfiguration _Configuration = null;
    public static IConfiguration Configuration { get { return _Configuration; } }

    const string _ApiTitle = "ORSCF VisitData";
    Version _ApiVersion = null;

    public void ConfigureServices(IServiceCollection services) {

      services.AddLogging();

      _ApiVersion = typeof(StudyExecutionScope).Assembly.GetName().Version;

      VisitDataDbContext.Migrate();

      string outDir = AppDomain.CurrentDomain.BaseDirectory;

      //services.AddSingleton<IDataRecordings, DataRecordingStore>();
      //services.AddSingleton<IVisits, VisitStore>();
      //services.AddSingleton<IDrugApplyments, DrugApplymentStore>();
      //services.AddSingleton<IStudyEvents, StudyEventStore>();
      //services.AddSingleton<IStudyExecutionScopes, StudyExecutionScopeStore>();
      //services.AddSingleton<ITreatments, TreatmentStore>();

      var apiService = new ApiService(
        _Configuration.GetValue<string>("OAuthTokenRequestUrl")
      );
      services.AddSingleton<IVdrApiInfoService>(apiService);
      services.AddSingleton<IVdrEventSubscriptionService>(apiService);

      services.AddSingleton<IVisitConsumeService>(apiService);
      services.AddSingleton<IVisitSubmissionService>(apiService);
      services.AddSingleton<IVisitHL7ExportService>(apiService);
      services.AddSingleton<IVisitHL7ImportService>(apiService);
      services.AddSingleton<IDataEnrollmentService>(apiService);
      services.AddSingleton<IDataRecordingSubmissionService>(apiService);

      services.AddControllers();

      services.AddSwaggerGen(c => {
        
        c.EnableAnnotations(true, true);

        c.IncludeXmlComments(outDir + "Hl7.Fhir.R4.Core.xml", true);
        c.IncludeXmlComments(outDir + "ORSCF.VisitData.Contract.xml", true);
        c.IncludeXmlComments(outDir + "ORSCF.VisitData.Service.xml", true);
        c.IncludeXmlComments(outDir + "ORSCF.VisitData.Service.WebAPI.xml", true);

        #region bearer

        //https://www.thecodebuzz.com/jwt-authorization-token-swagger-open-api-asp-net-core-3-0/
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
          Name = "Authorization",
          Type = SecuritySchemeType.ApiKey,
          Scheme = "Bearer",
          BearerFormat = "JWT",
          In = ParameterLocation.Header,
          Description = "JWT Authorization header using the Bearer scheme."
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
          {
              {
                    new OpenApiSecurityScheme
                      {
                          Reference = new OpenApiReference
                          {
                              Type = ReferenceType.SecurityScheme,
                              Id = "Bearer"
                          }
                      },
                      new string[] {}

              }
          });

        #endregion

        c.UseInlineDefinitionsForEnums();

        //c.SwaggerDoc(
        //  "StoreAccessV1",
        //  new OpenApiInfo {
        //    Title = _ApiTitle + "-StoreAccess",
        //    Version = _ApiVersion.ToString(3),
        //    Description = "NOTE: This is not intended be a 'RESTful' api, as it is NOT located on the persistence layer and is therefore NOT focused on doing CRUD operations! This HTTP-based API uses a 'call-based' approach to known BL operations. IN-, OUT- and return-arguments are transmitted using request-/response- wrappers (see [UJMW](https://github.com/KornSW/UnifiedJsonMessageWrapper)), which are very lightweight and are a compromise for broad support and adaptability in REST-inspired technologies as well as soap-inspired technologies!",
        //    Contact = new OpenApiContact {
        //      Name = "Open Research Study Communication Format",
        //      Email = "info@orscf.org",
        //      Url = new Uri("https://orscf.org")
        //    }
        //  }
        //);

        c.SwaggerDoc(
          "ApiV1",
          new OpenApiInfo {
            Title = _ApiTitle + "-API",
            Version = _ApiVersion.ToString(3),
            Description = "NOTE: This is not intended be a 'RESTful' api, as it is NOT located on the persistence layer and is therefore NOT focused on doing CRUD operations! This HTTP-based API uses a 'call-based' approach to known BL operations. IN-, OUT- and return-arguments are transmitted using request-/response- wrappers (see [UJMW](https://github.com/KornSW/UnifiedJsonMessageWrapper)), which are very lightweight and are a compromise for broad support and adaptability in REST-inspired technologies as well as soap-inspired technologies!",
            Contact = new OpenApiContact {
              Name = "Open Research Study Communication Format",
              Email = "info@orscf.org",
              Url = new Uri("https://orscf.org")
            },
          }
        );

      });

    }
    
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerfactory) {

      var logFileFullName = _Configuration.GetValue<string>("LogFileName");
      var logDir = Path.GetFullPath(Path.GetDirectoryName(logFileFullName));
      Directory.CreateDirectory(logDir);
      loggerfactory.AddFile(logFileFullName);

      //required for the www-root
      app.UseStaticFiles();

      if (!_Configuration.GetValue<bool>("ProdMode")) {
        app.UseDeveloperExceptionPage();
      }

      string validateTokensVia = _Configuration.GetValue<string>("ValidateTokensVia");
      if (validateTokensVia.StartsWith("http")) {
        DefaultAccessTokenValidator.Instance = new ValidationServiceConnector(
          validateTokensVia,
          _Configuration.GetValue<string>("ValidationServiceConnectorToken")
        ).AccessTokenValidator;
      }
      else {
        DefaultAccessTokenValidator.Instance = new RulesetBasedAccessTokenValidator(validateTokensVia);
      }

      if (_Configuration.GetValue<bool>("EnableSwaggerUi")) {
        var baseUrl = _Configuration.GetValue<string>("BaseUrl");

        app.UseSwagger(o => {
          //warning: needs subfolder! jsons cant be within same dir as swaggerui (below)
          o.RouteTemplate = "docs/schema/{documentName}.{json|yaml}";
          //o.SerializeAsV2 = true;
        });

        app.UseSwaggerUI(c => {

          c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
          c.DefaultModelExpandDepth(2);
          c.DefaultModelsExpandDepth(0);
          //c.ConfigObject.DefaultModelExpandDepth = 2;

          c.DocumentTitle = _ApiTitle + " - OpenAPI Definition(s)";

          //represents the sorting in SwaggerUI combo-box
          c.SwaggerEndpoint("schema/ApiV1.json", _ApiTitle + "-API v" + _ApiVersion.ToString(3));
          //c.SwaggerEndpoint("schema/StoreAccessV1.json", _ApiTitle + "-StoreAccess v" + _ApiVersion.ToString(3));

          c.RoutePrefix = "docs";

          //requires MVC app.UseStaticFiles();
          c.InjectStylesheet(baseUrl + "swagger-ui/custom.css");

        });

      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });

    }
  }

}
