using GyL.DDD.DotNet.Bootstrap.Providers.Configuration;
using GyL.DDD.DotNet.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlKata.Compilers;
using System.Data;
using System.Data.SqlClient;

namespace GyL.DDD.DotNet.Bootstrap.Providers.Persistance
{
	public static class PersistanceServiceCollectionExtensions
    {
        public static IServiceCollection ConfigurePersistanceServices(this IServiceCollection services, IConfiguration configuration, BootstrapSettings settings)
        {
            var connectionString = configuration.GetConnectionString(settings?.PersistanceSettings?.ConnectionStringName);

            services.AddTransient<Compiler, SqlServerCompiler>(); 
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });

            services.AddDbContextPool<SampleDbContext>(options =>
            {
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(settings?.PersistanceSettings?.MigrationsAssembly));
                options.EnableSensitiveDataLogging(false);
            });

            if (settings.PersistanceSettings?.HealthChecks == true)
            {
                services.AddHealthChecks().AddSqlServer(connectionString, "SELECT 1;", tags: new string[] { "db", "sqlserver" });
            }

            return services;
        }

        public static IApplicationBuilder ConfigurePersistence(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<SampleDbContext>().Database.Migrate();
            }
            return app;
        }
    }
}
