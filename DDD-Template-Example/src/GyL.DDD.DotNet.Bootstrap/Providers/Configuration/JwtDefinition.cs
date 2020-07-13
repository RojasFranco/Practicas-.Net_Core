namespace GyL.DDD.DotNet.Bootstrap.Providers.Configuration
{
	public class JwtDefinition
	{
		public string Authority { get; set; }
		public string Audience { get; set; }
		public string Issuer { get; set; }
		public bool RequireHttpsMetadata { get; set; }
		public bool SaveToken { get; set; }
		public bool IncludeErrorDetails { get; set; }
		public bool ValidateAudience { get; set; }
		public bool ValidateIssuerSigningKey { get; set; }
		public string SecretKey { get; set; }
		public bool ValidateIssuer { get; set; }
		public bool ValidateLifetime { get; set; }
		public bool RequireExpirationTime { get; set; }
		public int ClockSkew { get; set; }
	}
}
