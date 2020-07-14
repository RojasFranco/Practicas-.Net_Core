using GyL.DDD.DotNet.Bootstrap.Providers.Configuration;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace GyL.DDD.DotNet.Bootstrap.Providers.Cors
{
	public static class CorsServiceCollectionExtensions
	{
		private static BootstrapSettings _settings;
		public static IServiceCollection ConfigureCors(this IServiceCollection services, BootstrapSettings settings)
		{
			_settings = settings;
			BuildCors(services);

			return services;
		}

		private static void BuildCors(IServiceCollection services)
		{
			foreach (var cors in _settings.CorsSettings.Cors)
			{
				services.AddCors(options =>
				{
					options.AddPolicy(cors.Name,
						builder =>
						{
							BuildOrigins(builder, cors.Origins);
							BuildMethods(builder, cors.Methods);
							BuildHeaders(builder, cors.Headers);
							BuildExposedHeaders(builder, cors.ExposedHeaders);
						});
				});
			}
		}

		private static void BuildOrigins(CorsPolicyBuilder builder, List<string> origins)
		{
			if (origins != null)
				builder.WithOrigins(origins.ToArray());
			else
				builder.AllowAnyOrigin();
		}

		private static void BuildMethods(CorsPolicyBuilder builder, List<string> methods)
		{
			if (methods != null)
				builder.WithMethods(methods.ToArray());
			else
				builder.AllowAnyMethod();
		}

		private static void BuildHeaders(CorsPolicyBuilder builder, List<string> headers)
		{
			if (headers != null)
				builder.WithHeaders(headers.ToArray());
			else
				builder.AllowAnyHeader();
		}

		private static void BuildExposedHeaders(CorsPolicyBuilder builder, List<string> exposedHeaders)
		{
			if (exposedHeaders != null)
				builder.WithExposedHeaders(exposedHeaders.ToArray());
		}
	}
}