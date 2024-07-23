using Expect.Timeslots.Data;

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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();
            app.UseAuthorization();
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
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            SwaggerOptions.Configure(services);
            services.AddPersistance(Configuration);
        }
    }
}
