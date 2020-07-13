using GyL.DDD.DotNet.Bootstrap.Providers.Configuration;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;

namespace GyL.DDD.DotNet.Bootstrap.Providers.Mediator
{
    public static class MediatorServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureMediatorServices(this IServiceCollection services, BootstrapSettings settings)
        {
            List<Assembly> assemblies = new List<Assembly>();
            foreach (var assemblyString in settings.MediatorSettings.Assemblies)
                assemblies.Add(Assembly.Load(assemblyString));
            
            services.AddMediatR(assemblies.ToArray());
            
            return services;
        }
    }
}
