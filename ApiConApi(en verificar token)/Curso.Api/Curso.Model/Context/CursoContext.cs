using Curso.Model.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System.Linq;

namespace Curso.Model.Context
{
	public class CursoContext : DbContext
	{
		private readonly string _connectionString;

		public CursoContext(string connectionString)
		{
			_connectionString = connectionString;
		}

		public CursoContext(DbContextOptions<CursoContext> options) : base(options)
		{
			_connectionString = ((RelationalOptionsExtension)options.Extensions.Where(e => e is SqlServerOptionsExtension).FirstOrDefault()).ConnectionString;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(_connectionString);
				base.OnConfiguring(optionsBuilder);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<User> Users { get; set; }

		public DbSet<Person> Persons { get; set; }
	}
}
