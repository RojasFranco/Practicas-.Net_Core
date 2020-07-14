namespace GyL.DDD.DotNet.Bootstrap.Providers.Configuration
{
	public class PersistanceSettings
	{
		public string ConnectionStringName { get; set; }
		public string MigrationsAssembly { get; set; }
		public bool HealthChecks { get; set; }
	}
}
