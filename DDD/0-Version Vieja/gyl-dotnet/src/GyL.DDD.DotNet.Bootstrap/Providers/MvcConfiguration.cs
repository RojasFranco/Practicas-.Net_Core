using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace GyL.DDD.DotNet.Bootstrap.Providers
{
    public static class MvcConfiguration
	{
		public static IServiceCollection ConfigureMVCServices(this IServiceCollection services)
		{
			services.AddControllers();
			////.AddNewtonsoftJson(x =>
			////{
			////    x.SerializerSettings.DateFormatString = "dd-MM-yyyy";
			////});

			return services;
		}

        public static IApplicationBuilder ConfigureMVC(this IApplicationBuilder app, bool isDevelopment)
        {
            if (isDevelopment)
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appError =>
                {
                    appError.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";

                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (contextFeature != null)
                        {
                            await context.Response.WriteAsync(new
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = "Internal Server Error."
                            }.ToString());
                        }
                    });
                });
            }

            return app;
        }
    }
}
