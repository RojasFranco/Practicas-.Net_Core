using System.Collections.Generic;

namespace GyL.DDD.DotNet.Bootstrap.Providers.Configuration
{
	public class SwaggerSettings
	{
		public string RoutePrefix { get; set; }
		public SecurityDefinition SecurityDefinition { get; set; }
		public bool IncludeXmlComments { get; set; }
		public bool IncludeControllerXmlComments { get; set; }

		public List<SwaggerVersion> Versions { get; set; }
	}
}
