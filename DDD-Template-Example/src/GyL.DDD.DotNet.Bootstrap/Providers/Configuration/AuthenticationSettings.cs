namespace GyL.DDD.DotNet.Bootstrap.Providers.Configuration
{
	public class AuthenticationSettings
	{
		public JwtDefinition Jwt { set; get; }
		public string AuthenticationScheme { set; get; }
		public bool? Keycloak { set; get; }
	}
}
