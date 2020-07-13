using GyL.DDD.DotNet.Aplication.Services;
using GyL.DDD.DotNet.Bootstrap.Providers.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace GyL.DDD.DotNet.Bootstrap.Providers.Authentication.Basic
{
	public static class BasicAuthenticationServiceCollectionExtensions
	{
		public static IServiceCollection ConfigureBasicAuthentication(this IServiceCollection services, BootstrapSettings settings)
		{
			services.AddScoped<IUserService, UserService>();

			services.AddAuthentication("Basic")
					.AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("Basic", null);

			return services;
		}
	}
}
