using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Expect.Timeslots.Api
{
    /// <summary>
    /// Swagger options
    /// </summary>
    public static class SwaggerOptions
    {
        private static string _docVersion = "v1";

        /// <summary>
        /// Configure swagger
        /// </summary>
        /// <param name="services"></param>
        public static void Configure(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(_docVersion, new OpenApiInfo
                {
                    Title = "Timeslots Web API",
                    Contact = new()
                    {
                        Email = "roma.veselov.1990@mail.ru",
                        Name = "Roman Veselov",
                    },
                    Description = "Web API for controlling timeslots for logistic purposes",
                    Version = _docVersion,
                });
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

            });
        }
    }
}
