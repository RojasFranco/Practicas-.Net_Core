using GyL.DDD.DotNet.Api.Presenters;
using GyL.DDD.DotNet.Aplication.Services;
using GyL.DDD.DotNet.Bootstrap;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;

namespace GyL.DDD.DotNet.Api
{
	public class Startup
	{
		private readonly IConfiguration _configuration;
		
		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.ConfigureServices(_configuration);

			services.AddTransient<ISamplePresenter, SamplePresenter>();

			//IdentityModelEventSource.ShowPII = true; //Add this line
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime appLifetime, IConfiguration configuration)
		{
			app.Configure(env.IsDevelopment(), appLifetime, configuration);
		}
	}
}
