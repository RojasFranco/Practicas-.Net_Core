using GyL.DDD.DotNet.Bootstrap.Providers.Authentication.Basic;
using GyL.DDD.DotNet.Bootstrap.Providers.Authentication.Jwt;
using GyL.DDD.DotNet.Bootstrap.Providers.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GyL.DDD.DotNet.Bootstrap.Providers.Authentication
{
	public static class AuthenticationServiceCollectionExtensions
	{
		private static BootstrapSettings _settings;
		public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, BootstrapSettings settings)
		{
			_settings = settings;
			switch (_settings.AuthenticationSettings?.AuthenticationScheme?.ToLower())
			{
				case "basic":
					services.ConfigureBasicAuthentication(settings);
					break;
				case "jwt":
					services.ConfigureJwtAuthentication(settings);
					break;

			}
			return services;
		}
	}
}
