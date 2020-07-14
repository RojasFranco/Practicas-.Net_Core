using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using GyL.DDD.DotNet.Swagger.Configuration;
using GyL.DDD.DotNet.Swagger.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Reflection;

namespace GyL.DDD.DotNet.Swagger.ServiceCollection
{
    public static class SwaggerServiceCollectionExtensions
    {

        public static void AddGyLSwagger(this IServiceCollection services, OpenApiInfo apiInfo, IConfiguration configuration, string basePath = "", Action<SwaggerGenOptions> options = null)
        {
            services.Configure<SwaggerSettings>(configuration.GetSection(nameof(SwaggerSettings)));
            var swaggerSettings = services.BuildServiceProvider().GetService<IOptions<SwaggerSettings>>().Value;

            _ = services.AddSwaggerGen(config =>
            {
                config.DocumentFilter<BasePathFilter>(basePath);
                config.DocumentFilter<LowercaseDocumentFilter>();
                config.OperationFilter<SecurityRequirementsOperationFilter>();

                config.DescribeAllEnumsAsStrings();
                config.DescribeStringEnumsInCamelCase();
                config.DescribeAllParametersInCamelCase();

                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                if (swaggerSettings?.SecurityDefinitions != null)
                    SetSecurityDefinitions(swaggerSettings, config);

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    apiInfo.Version = description.ApiVersion.ToString();
                    if (description.IsDeprecated)
                    {
                        apiInfo.Description += "This API is depreciated.";
                    }

                    config.SwaggerDoc(description.GroupName, apiInfo);
                }

                options?.Invoke(config);

                IncludeXMLS(config);
            });
        }

        private static void SetSecurityDefinitions(SwaggerSettings swaggerSettings, SwaggerGenOptions config)
        {
            foreach (var item in swaggerSettings.SecurityDefinitions)
            {
                switch (item.Type.ToLower())
                {
                    case "basic":
                        config.AddSecurityDefinition(SecuritySchemeType.Http.ToString(), new OpenApiSecurityScheme
                        {                            
                            Type = SecuritySchemeType.Http,
                            Scheme = "basic"
                        });
                        break;
                    case "apikey":
                        config.AddSecurityDefinition(SecuritySchemeType.ApiKey.ToString(), new OpenApiSecurityScheme
                        {
                            Description = item.Description,
                            In = ParameterLocation.Header,
                            Name = item.Name,
                            Type = SecuritySchemeType.ApiKey,
                        });
                        break;
                    case "oauth2":
                        {
                            var openApiOAuthFlow = new OpenApiOAuthFlow
                            {
                                AuthorizationUrl = new Uri(item.AuthorizationUrl),
                                TokenUrl = new Uri(item.TokenUrl),
                            };

                            item.Flow = (item.Flow ?? string.Empty).ToLower();

                            config.AddSecurityDefinition(SecuritySchemeType.OAuth2.ToString(), new OpenApiSecurityScheme
                            {
                                Type = SecuritySchemeType.OAuth2,
                                Flows = new OpenApiOAuthFlows
                                {
                                    Password = item.Flow.Equals("password") ? openApiOAuthFlow : null,
                                    ClientCredentials = item.Flow.Equals("clientcredentials") ? openApiOAuthFlow : null
                                },
                                Description = item.Description,
                            });
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private static void IncludeXMLS(SwaggerGenOptions options)
        {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var files = Directory.GetFiles(path, "*.xml");
            foreach (var item in files)
                options.IncludeXmlComments(item);
        }
    }
}
