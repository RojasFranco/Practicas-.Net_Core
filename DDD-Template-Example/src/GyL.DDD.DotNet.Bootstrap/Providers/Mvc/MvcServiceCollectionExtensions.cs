using GyL.DDD.DotNet.Bootstrap.Providers.Configuration;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.Web;
using System.Net;

namespace GyL.DDD.DotNet.Bootstrap.Providers.Mvc
{
	public static class MvcServiceCollectionExtensions
	{
		private static BootstrapSettings _settings;
		private static Logger _logger;
		public static IServiceCollection ConfigureMvcServices(this IServiceCollection services, BootstrapSettings settings)
		{
			_settings = settings;

			ServiceProvider serviceProvider = services.BuildServiceProvider();
			_logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

			services.AddMvc(options =>
			{
				options.EnableEndpointRouting = false;
				options.Conventions.Add(new ApiExplorerGroupPerVersionConvention());
			});

			//services.AddMvc();
			services.AddControllers();
			////.AddNewtonsoftJson(x =>
			////{
			////    x.SerializerSettings.DateFormatString = "dd-MM-yyyy";
			////});

			return services;
		}

		public static IApplicationBuilder ConfigureMvc(this IApplicationBuilder app, bool isDevelopment)
		{
			if (isDevelopment)
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler(builder =>
				{
					builder.Run(async handler =>
					{
						handler.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
						handler.Response.ContentType = "application/json";

						var feature = handler.Features.Get<IExceptionHandlerFeature>();
						_logger.Error(feature.Error, "Unhandled Exception -> ");
						if (feature != null)
						{
							await handler.Response.WriteAsync(new
							{
								StatusCode = handler.Response.StatusCode,
								Message = "\"Internal Server Error.\""
							}.ToString());
						}
					});
				});
			}

			app.UseRouting();
			app.UseDefaultFiles();
			app.UseStaticFiles();
			app.UseMvc();

			app.UseAuthorization();
			app.UseAuthentication();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				if (_settings.MvcSettings?.HealthCheck == true)
				{
					endpoints.MapHealthChecks("/health", new HealthCheckOptions()
					{
						Predicate = _ => true,
						ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
					});
				}
			});

			return app;
		}
	}
}
