using GyL.DDD.DotNet.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using SqlKata.Compilers;
using System.Data.SqlClient;
using GyL.DDD.DotNet.Domain.Repositories;
using GyL.DDD.DotNet.Persistance.Repositories;
using GyL.DDD.DotNet.Aplication.Queries;
using GyL.DDD.DotNet.Persistance.Queries;

namespace GyL.DDD.DotNet.Bootstrap.Providers
{
    public static class PersistanceConfiguration
    {
        public static IServiceCollection ConfigurePersistanceServices(this IServiceCollection services, IConfiguration configuration, bool addHealthCheck = true)
        {
            var connectionString = configuration.GetConnectionString("DB");

            services.AddTransient<Compiler, SqlServerCompiler>(); 
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });

            services.AddDbContextPool<GyLDbContext>(options =>
            {
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("GyL.DDD.DotNet.Persistance"));
                options.EnableSensitiveDataLogging(false);
            });

            if (addHealthCheck)
            {
                services.AddHealthChecks().AddSqlServer(connectionString, "SELECT 1;", tags: new string[] { "db", "sqlserver" });
            }

            services.AddTransient<ITestQuery, TestQuery>();
            services.AddTransient<ISampleRepository, SampleRepository>();

            return services;
        }

        public static IApplicationBuilder ConfigurePersistence(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<GyLDbContext>().Database.Migrate();
            }
            return app;
        }
    }
}
