using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GyL.DDD.DotNet.Bootstrap.Providers;

namespace GyL.DDD.DotNet.Bootstrap
{
	public static class ServiceConfiguration
	{
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureMVCServices();

            services.ConfigureSwaggerServices();

            services.ConfigurePersistanceServices(configuration);

            services.ConfigureMediatrServices();

            //services.ConfigureGyL(configuration);

            return services;
        }
    }
}
