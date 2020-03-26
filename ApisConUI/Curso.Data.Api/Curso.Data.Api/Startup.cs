using Curso.Data.Services;
using Curso.Data.Services.FolderAltaPersona;
using Curso.Model.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Curso.Data.Api
{
	public class Startup
	{

		readonly string _allowSpecificOrigins = "_CURSO_";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddCors(options =>
			{
				options.AddPolicy(_allowSpecificOrigins,
				builder =>
				{
					//builder.WithOrigins("https://localhost:44321")
					//	.WithHeaders("application/json", "application/json; charset=utf-8", "content-type")
					//	.WithMethods("GET","POST","PUT");
					builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
				});
			});

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

			string connectionString = this.Configuration.GetConnectionString("LocalHostDb");
			//string connectionString = this.Configuration.GetValue<string>("ConnectionStrings:LocalHostDb");
			services.AddDbContext<CursoContext>(options => options.UseSqlServer(connectionString));

			services.AddScoped<ICargaTabla, CargaTabla>();

			services.AddScoped<IAltaPersona, AltaPersona>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CursoContext cursoContext)
		{
			cursoContext.Database.EnsureCreated();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors(_allowSpecificOrigins);

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			DefaultFilesOptions options = new DefaultFilesOptions();
			options.DefaultFileNames.Clear();
			options.DefaultFileNames.Add("index.html");
			app.UseDefaultFiles(options);
			app.UseStaticFiles();
		}
	}
}
