using Expect.Timeslots.Api.Middlewares;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Expect.Timelots.Auth
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });
            app.UseIdentityServer();
            app.UseMvc();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddAuthorization();
            services.AddControllers().AddNewtonsoftJson();
            services.AddApiVersioning();
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
                .AddInMemoryClients(IdentityConfiguration.Clients);
        }
    }
}
