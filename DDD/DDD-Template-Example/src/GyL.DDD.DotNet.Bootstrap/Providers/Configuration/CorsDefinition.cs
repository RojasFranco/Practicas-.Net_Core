using System.Collections.Generic;

namespace GyL.DDD.DotNet.Bootstrap.Providers.Configuration
{
	public class CorsDefinition
	{
		public string Name { get; set; }
		public List<string> Origins { get; set; }
		public List<string> Methods { get; set; }
		public List<string> Headers { get; set; }
		public List<string> ExposedHeaders { get; set; }
	}
}
