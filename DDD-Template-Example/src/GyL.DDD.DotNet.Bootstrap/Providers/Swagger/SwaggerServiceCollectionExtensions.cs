using GyL.DDD.DotNet.Bootstrap.Providers.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace GyL.DDD.DotNet.Bootstrap.Providers.Swagger
{
	public static class SwaggerServiceCollectionExtensions
	{
		private static BootstrapSettings _settings;

		public static IServiceCollection ConfigureSwaggerServices(this IServiceCollection services, BootstrapSettings settings)
		{
			_settings = settings;

			services.AddSwaggerGen(config =>
			{
				foreach (var version in _settings.SwaggerSettings.Versions)
				{
					config.SwaggerDoc(version.VersionName.ToLower(), new OpenApiInfo
					{
						Title = version.Title,
						Version = version.VersionName.ToUpper(),
						Description = version.Description,
						TermsOfService = !string.IsNullOrEmpty(version.TermsOfServiceUri) ? new Uri(version.TermsOfServiceUri) : null,
						Contact = (!string.IsNullOrEmpty(version.ContactMail)) ? new OpenApiContact
						{
							Name = version.ContactName,
							Email = version.ContactMail
						} : null,
						License = (!string.IsNullOrEmpty(version.LicenseUri)) ? new OpenApiLicense
						{
							Name = version.LicenseName,
							Url = new Uri(version.LicenseUri)
						} : null
					});
				}

				if (_settings.SwaggerSettings?.IncludeXmlComments == true)
					IncludeXmlComments(config);

				if (_settings.SwaggerSettings?.SecurityDefinition != null)
					SetSecurityDefinitions(config);

				config.DescribeAllEnumsAsStrings();
				config.DescribeStringEnumsInCamelCase();
				config.DescribeAllParametersInCamelCase();

			});

			return services;
		}

		public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
		{
			var prefix = string.IsNullOrEmpty(_settings.SwaggerSettings.RoutePrefix) ? "swagger" : _settings.SwaggerSettings.RoutePrefix;

			app.UseSwagger(option =>
			{
				option.RouteTemplate = $"{prefix}/" + "{documentName}/swagger.json";
			});

			app.UseSwaggerUI(option =>
			{
				foreach (var version in _settings.SwaggerSettings.Versions)
				{
					option.SwaggerEndpoint($"/{prefix}/{version.VersionName.ToLower()}/swagger.json", version.VersionDescription.ToUpper());
				}
				option.RoutePrefix = prefix;
				option.ShowExtensions();
				option.DocExpansion(DocExpansion.List);
				//option.EnableFilter();
			});

			return app;
		}

		private static void IncludeXmlComments(SwaggerGenOptions options)
		{
			bool includeControllerXmlComments = _settings.SwaggerSettings?.IncludeControllerXmlComments == true;
			var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
			var files = Directory.GetFiles(path, "*.xml");
			foreach (var filePath in files)
				options.IncludeXmlComments(filePath, includeControllerXmlComments);
		}
		private static void SetSecurityDefinitions(SwaggerGenOptions config)
		{
			var securityDefinition = _settings.SwaggerSettings?.SecurityDefinition;
			switch (securityDefinition?.Type?.ToLower())
			{
				case "basic":
					config.AddSecurityDefinition(securityDefinition.Type.ToLower(), new OpenApiSecurityScheme
					{
						Name = securityDefinition.Name,
						Type = SecuritySchemeType.Http,
						Scheme = securityDefinition.Scheme.ToLower(),
						In = ParameterLocation.Header,
						Description = securityDefinition.Description
					});
					config.AddSecurityRequirement(new OpenApiSecurityRequirement
					{
						{
							  new OpenApiSecurityScheme
								{
									Reference = new OpenApiReference
									{
										Type = ReferenceType.SecurityScheme,
										Id = securityDefinition.Type.ToLower()
									}
								},
								new string[] {}
						}
					});
					break;
				case "apikey":
					config.AddSecurityDefinition(SecuritySchemeType.ApiKey.ToString(), new OpenApiSecurityScheme
					{
						Name = securityDefinition.Name,
						Description = securityDefinition.Description,
						In = ParameterLocation.Header,
						Type = SecuritySchemeType.ApiKey,
						BearerFormat = securityDefinition.BearerFormat,
						Scheme = securityDefinition.Scheme,
					});
					config.AddSecurityRequirement(new OpenApiSecurityRequirement
					{
						{
							new OpenApiSecurityScheme
							{
								Reference = new OpenApiReference {
									Type = ReferenceType.SecurityScheme,
									Id = SecuritySchemeType.ApiKey.ToString()
								}
							},
							new string[] { }
						}
					});
					break;
				case "oauth2": //TODO Falta el ServiceCollectionExtensions en Authentication o ver sin funciona asi
					{
						var openApiOAuthFlow = new OpenApiOAuthFlow
						{
							AuthorizationUrl = new Uri(securityDefinition.AuthorizationUrl),
							TokenUrl = new Uri(securityDefinition.TokenUrl),
						};

						securityDefinition.Flow = (securityDefinition.Flow ?? string.Empty).ToLower();

						config.AddSecurityDefinition(SecuritySchemeType.OAuth2.ToString(), new OpenApiSecurityScheme
						{
							Type = SecuritySchemeType.OAuth2,
							Flows = new OpenApiOAuthFlows
							{
								Password = securityDefinition.Flow.Equals("password") ? openApiOAuthFlow : null,
								ClientCredentials = securityDefinition.Flow.Equals("clientcredentials") ? openApiOAuthFlow : null
							},
							Description = securityDefinition.Description,
						});

						config.AddSecurityRequirement(new OpenApiSecurityRequirement()
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
						});
						break;
					}
				default:
					break;
			}
		}
	}
}
