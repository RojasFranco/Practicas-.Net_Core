using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GyL.DDD.DotNet.Swagger.Filters
{
    public class BasePathFilter : IDocumentFilter
    {
        public string BasePath { get; set; }

        public BasePathFilter(string basePath)
        {
            this.BasePath = basePath;
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Servers.Add(new OpenApiServer { Url = BasePath });
        }
    }
}
