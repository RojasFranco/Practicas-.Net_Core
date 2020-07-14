using GyL.DDD.DotNet.Aplication.Queries;
using GyL.DDD.DotNet.Domain.Model;
using GyL.DDD.DotNet.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Persistance.Repositories
{
	public class SampleRepository : ISampleRepository
	{
		private readonly GyLDbContext _gyLDbContext;

		public SampleRepository(GyLDbContext gyLDbContext)
		{
			_gyLDbContext = gyLDbContext;
		}

		public async Task InsertAsync(Sample value)
		{
			await _gyLDbContext.AddAsync(value);
			_gyLDbContext.SaveChanges();
		}

		public async Task UpdateAsync(Sample sample, string nuevaDescripcion)
		{
			sample.Description = nuevaDescripcion;
			_gyLDbContext.Update(sample);
			await _gyLDbContext.SaveChangesAsync();
		}
	}
}
