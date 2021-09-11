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

namespace MedicalResearch.VisitData.WebAPI {

  public class Startup {

    public Startup(IConfiguration configuration) {
      _Configuration = configuration;
      VisitDataDbContext.ConnectionString = configuration.GetValue<String>("SqlConnectionString");
    }

    private static IConfiguration _Configuration = null;
    public static IConfiguration Configuration { get { return _Configuration; } }

    const string _ApiTitle = "Visit Data Repository API";
    Version _ApiVersion = null;

    public void ConfigureServices(IServiceCollection services) {

      services.AddLogging();

      //Version.TryParse(VisitDataDbContext.SchemaVersion, out _ApiVersion);
      _ApiVersion = typeof(IVisits).Assembly.GetName().Version;

      VisitDataDbContext.Migrate();

      string outDir = AppDomain.CurrentDomain.BaseDirectory;
     
      services.AddSingleton<IDataRecordings, DataRecordingStore>();
      services.AddSingleton<IVisits, VisitStore>();
      services.AddSingleton<IDrugApplyments, DrugApplymentStore>();
      services.AddSingleton<IStudyEvents, StudyEventStore>();
      services.AddSingleton<IStudyExecutionScopes, StudyExecutionScopeStore>();
      services.AddSingleton<ITreatments, TreatmentStore>();

      services.AddControllers();
      
      services.AddSwaggerGen(c => {

        c.EnableAnnotations(true, true);

        c.IncludeXmlComments(outDir + "ORSCF.SimpleVisitDataRepository.WebAPI.xml", true);
        c.IncludeXmlComments(outDir + "ORSCF.SimpleVisitDataRepository.BL.xml", true);
        c.IncludeXmlComments(outDir + "ORSCF.VisitData.Model.xml", true);

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

        c.SwaggerDoc(
          "v" + _ApiVersion.ToString(1),
          new OpenApiInfo {
            Title = _ApiTitle,
            Version = _ApiVersion.ToString(3),
            Description = "stores data for research study related visits",
            Contact = new OpenApiContact { 
              Name = "Open Research Study Communication Format",
              Email = "info@orscf.org",
              Url = new Uri("https://orscf.org")
            }
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

      if (_Configuration.GetValue<bool>("EnableSwaggerUi")) {
        var baseUrl = _Configuration.GetValue<string>("BaseUrl");

        app.UseSwagger(o => {
          //warning: needs subfolder! jsons cant be within same dir as swaggerui (below)
          o.RouteTemplate = "docs/schema/{documentName}.{json|yaml}";
        });

        app.UseSwaggerUI(c => {

          c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
          c.DefaultModelExpandDepth(2);
          c.DefaultModelsExpandDepth(2);
          //c.ConfigObject.DefaultModelExpandDepth = 2;

          c.DocumentTitle = _ApiTitle + " - OpenAPI Schema";

          c.SwaggerEndpoint("schema/v" + _ApiVersion.ToString(1) + ".json", _ApiTitle + " " + _ApiVersion.ToString(3));
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
