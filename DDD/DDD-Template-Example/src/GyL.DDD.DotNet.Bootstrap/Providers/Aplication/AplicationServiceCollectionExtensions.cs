using GyL.DDD.DotNet.Aplication.Queries;
using GyL.DDD.DotNet.Bootstrap.Providers.Configuration;
using GyL.DDD.DotNet.Domain.Repositories;
using GyL.DDD.DotNet.Persistance;
using GyL.DDD.DotNet.Persistance.Queries;
using GyL.DDD.DotNet.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GyL.DDD.DotNet.Bootstrap.Providers.Aplication
{
	public static class AplicationServiceCollectionExtensions
	{
        public static IServiceCollection ConfigureAplicationServices(this IServiceCollection services, BootstrapSettings settings)
        {
            services.AddTransient<ISampleQuery, SampleQuery>();
            services.AddTransient<ISampleRepository, SampleRepository>();
            services.AddScoped<IUnitOfWork, SampleUnitOfWork>();

            return services;
        }
    }
}
