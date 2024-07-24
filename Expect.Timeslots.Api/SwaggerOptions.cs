using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Expect.Timeslots.Api
{
    /// <summary>
    /// Swagger configuration
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <param name="provider"></param>
    public class ConfiugreSwaggerOptions(IApiVersionDescriptionProvider provider) : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider = provider;

        /// <summary>
        /// Configure swagger
        /// </summary>
        /// <param name="options"></param>
        public void Configure(SwaggerGenOptions options)
        {
            
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);

            foreach (var desc in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(desc.GroupName, new OpenApiInfo
                {
                    Title = $"Timeslots Web API v{desc.ApiVersion}",
                    Contact = new()
                    {
                        Email = "roma.veselov.1990@mail.ru",
                        Name = "Roman Veselov",
                    },
                    Description = "Web API for controlling timeslots for logistic purposes",
                    Version = desc.ApiVersion.ToString(),
                });
            }
        }
    }
}
