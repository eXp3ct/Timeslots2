using Expect.Timeslots.Api.Middlewares;
using Expect.Timeslots.Data;
using Expect.Timeslots.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Expect.Timeslots.Api
{
    /// <summary>
    /// API configuration
    /// </summary>
    /// <param name="configuration"></param>
    public class Startup(IConfiguration configuration)
    {
        /// <summary>
        /// appsettings
        /// </summary>
        public IConfiguration Configuration { get; set; } = configuration;

        /// <summary>
        /// Configure pipeline
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="provider"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                foreach (var desc in provider.ApiVersionDescriptions)
                {
                    opt.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json", desc.GroupName.ToUpperInvariant());
                }
            });

            app.UseRouting();
            app.UseAuthorization();
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });
        }

        /// <summary>
        /// Configure DI services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddControllers().AddNewtonsoftJson();
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.ReportApiVersions = true;
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("X-Api-Version"));

            }).AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });
            services.AddEndpointsApiExplorer();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfiugreSwaggerOptions>();
            services.AddSwaggerGen();
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddPersistance(Configuration);
            services.AddInfrastructure();
        }
    }
}
