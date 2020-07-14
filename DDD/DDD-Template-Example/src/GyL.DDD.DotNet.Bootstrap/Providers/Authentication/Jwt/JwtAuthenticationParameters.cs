using GyL.DDD.DotNet.Bootstrap.Providers.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace GyL.DDD.DotNet.Bootstrap.Providers.Authentication.Jwt
{
	public class JwtAuthenticationParameters
	{
		public JwtAuthenticationParameters(JwtDefinition jwtDefinition)
		{
			Authority = jwtDefinition.Authority;
			Audience = jwtDefinition.Audience;
			Issuer = jwtDefinition.Issuer;
			RequireHttpsMetadata = jwtDefinition.RequireHttpsMetadata;
			SaveToken = jwtDefinition.SaveToken;
			IncludeErrorDetails = jwtDefinition.IncludeErrorDetails;
			ValidateAudience = jwtDefinition.ValidateAudience;
			ValidateIssuerSigningKey = jwtDefinition.ValidateIssuerSigningKey;
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtDefinition.SecretKey));
			ValidateIssuer = jwtDefinition.ValidateIssuer;
			ValidateLifetime = jwtDefinition.ValidateLifetime;
			RequireExpirationTime = jwtDefinition.RequireExpirationTime;
			ClockSkew = TimeSpan.FromMinutes(jwtDefinition.ClockSkew);
		}

		public JwtAuthenticationParameters()
		{
			RequireHttpsMetadata = false;
			SaveToken = true;
			IncludeErrorDetails = true;
			ValidateAudience = false;
			ValidateIssuerSigningKey = true;
			ValidateIssuer = false;
			ValidateLifetime = true;
			// Clock skew compensates for server time drift.
			// We recommend 5 minutes or less:
			ClockSkew = TimeSpan.FromMinutes(1);
			// Ensure the token hasn't expired:
			RequireExpirationTime = true;
			IssuerSigningKey = null;
		}

		public string Authority { get; set; }
		public string Audience { get; set; }
		public string Issuer { get; set; }
		public bool RequireHttpsMetadata { get; set; }
		public bool SaveToken { get; set; }
		public bool IncludeErrorDetails { get; set; }
		public bool ValidateAudience { get; set; }
		public bool ValidateIssuerSigningKey { get; set; }
		public SecurityKey IssuerSigningKey { get; set; }
		public bool ValidateIssuer { get; set; }
		public bool ValidateLifetime { get; set; }
		public bool RequireExpirationTime { get; set; }
		public TimeSpan ClockSkew { get; set; }
	}
}
