using System;
using System.Collections.Generic;
using System.Text;
using GyL.DDD.DotNet.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace GyL.DDD.DotNet.Persistance
{
	public partial class SampleDbContext : DbContext
	{

		public virtual DbSet<Sample> Sample { get; set; }

		public SampleDbContext(DbContextOptions<SampleDbContext> options)
			: base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder modelBuilder) 
		{

		}

	}
}
