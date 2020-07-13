using GyL.DDD.DotNet.Bootstrap.Providers.Aplication;
using GyL.DDD.DotNet.Bootstrap.Providers.Authentication;
using GyL.DDD.DotNet.Bootstrap.Providers.Configuration;
using GyL.DDD.DotNet.Bootstrap.Providers.Cors;
using GyL.DDD.DotNet.Bootstrap.Providers.Mediator;
using GyL.DDD.DotNet.Bootstrap.Providers.Mvc;
using GyL.DDD.DotNet.Bootstrap.Providers.Persistance;
using GyL.DDD.DotNet.Bootstrap.Providers.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace GyL.DDD.DotNet.Bootstrap
{
	public static class ServiceConfiguration
	{
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BootstrapSettings>(configuration.GetSection(nameof(BootstrapSettings)));
            BootstrapSettings settings = services.BuildServiceProvider().GetService<IOptions<BootstrapSettings>>().Value;

            services.ConfigureMvcServices(settings);

            services.ConfigureCors(settings);

            services.ConfigureSwaggerServices(settings);

            services.ConfigurePersistanceServices(configuration, settings);

            services.ConfigureMediatorServices(settings);

            services.ConfigureAuthentication(settings);

            services.ConfigureAplicationServices(settings);

            return services;
        }

        public static IApplicationBuilder Configure(this IApplicationBuilder app, bool isDevelopnment, IHostApplicationLifetime appLifetime, IConfiguration configuration)
        {
            app.ConfigureMvc(isDevelopnment);
            app.ConfigureSwagger();
            app.ConfigurePersistence();
            return app;
        }
    }
}
