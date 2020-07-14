using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace GyL.DDD.DotNet.Bootstrap.Providers
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigureSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "GyL Template",
                    Version = "v1",
                    Description = "REST API Template DDD arquitecture"
                });
                c.IncludeXmlComments(string.Format(@"{0}/GyL.DDD.DotNet.API.xml", System.AppDomain.CurrentDomain.BaseDirectory));
                c.DescribeAllEnumsAsStrings();
                /*
                var securityScheme = new OpenApiSecurityScheme()
                {
                    Description = @"JWT Authorization header using the Bearer scheme.<br/> 
									Enter 'Bearer' [space] and then your token in the text input below.<br/> 
                                    <strong>Example:<strong/> 'Bearer 12345abc$pingui$def......'",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer",
                    Name = "Authorization"
                };
                c.AddSecurityDefinition("Bearer", securityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                            new List<string>()
                    }
                });*/
            });

            return services;
        }

        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "gyl-dotnet-template/docs/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/gyl-dotnet-template/docs/v1/swagger.json", "GyL Template");
                c.RoutePrefix = "gyl-dotnet-template/docs";
            });

            return app;
        }
    }
}
