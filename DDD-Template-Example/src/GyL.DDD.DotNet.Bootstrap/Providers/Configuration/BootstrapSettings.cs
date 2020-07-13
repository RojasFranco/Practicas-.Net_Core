namespace GyL.DDD.DotNet.Bootstrap.Providers.Configuration
{
	public class BootstrapSettings
	{
		public MediatorSettings MediatorSettings { get; set; }
		public MvcSettings MvcSettings { get; set; }
		public PersistanceSettings PersistanceSettings { get; set; }
		public SwaggerSettings SwaggerSettings { get; set; }
		public CorsSettings CorsSettings { get; set; }
		public AuthenticationSettings AuthenticationSettings { get; set; }
	}
}
