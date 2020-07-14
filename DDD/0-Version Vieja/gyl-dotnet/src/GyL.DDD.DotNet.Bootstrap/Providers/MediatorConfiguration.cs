using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GyL.DDD.DotNet.Bootstrap.Providers
{
    public static class MediatorConfiguration
    {
        public static IServiceCollection ConfigureMediatrServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.Load("GyL.DDD.DotNet.Aplication"));
            return services;
        }
    }
}
