using GyL.DDD.DotNet.Bootstrap.Providers.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace GyL.DDD.DotNet.Bootstrap.Providers.Authentication.Jwt
{
	public static class JwtAuthenticationServiceCollectionExtensions
	{
		private static BootstrapSettings _settings;
		public static IServiceCollection ConfigureJwtAuthentication(this IServiceCollection services, BootstrapSettings settings, JwtBearerEvents events = null)
		{
			_settings = settings;

			Configure(services, new JwtAuthenticationParameters(_settings.AuthenticationSettings.Jwt), events);
			return services;
		}

		public static void ConfigureJwtAuthentication(this IServiceCollection services, JwtAuthenticationParameters jwtAuthenticationParameters, JwtBearerEvents events = null)
		{
			Configure(services, jwtAuthenticationParameters, events);
		}

		private static void Configure(IServiceCollection services, JwtAuthenticationParameters jwtAuthenticationParameters, JwtBearerEvents events)
		{
			if (_settings.AuthenticationSettings?.Keycloak == true)
				services.AddTransient<IClaimsTransformation, ClaimsTransformationKeycloak>();
			else
				services.AddTransient<IClaimsTransformation, ClaimsTransformation>();

			JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = jwtAuthenticationParameters.RequireHttpsMetadata;
				options.SaveToken = jwtAuthenticationParameters.SaveToken;
				options.Authority = jwtAuthenticationParameters.Authority;
				options.IncludeErrorDetails = jwtAuthenticationParameters.IncludeErrorDetails;
				options.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateAudience = jwtAuthenticationParameters.ValidateAudience,
					ValidAudience = jwtAuthenticationParameters.Audience,
					ValidateIssuer = jwtAuthenticationParameters.ValidateIssuer,
					ValidIssuer = jwtAuthenticationParameters.Issuer,
					RequireExpirationTime = jwtAuthenticationParameters.RequireExpirationTime,
					ValidateLifetime = jwtAuthenticationParameters.ValidateLifetime,
					ClockSkew = jwtAuthenticationParameters.ClockSkew,
					ValidateIssuerSigningKey = jwtAuthenticationParameters.ValidateIssuerSigningKey,
					IssuerSigningKey = jwtAuthenticationParameters.IssuerSigningKey,
				};
				if (events != null)
					options.Events = events;
			});
		}
	}
}
