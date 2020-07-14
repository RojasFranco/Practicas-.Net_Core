using GyL.DDD.DotNet.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Domain.Repositories
{
	public interface ISampleRepository
	{
		Task InsertAsync(Sample value);
		Task UpdateAsync(Sample sample, string nuevaDescripcion);
	}
}
