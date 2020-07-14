using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Aplication.Queries
{
	public interface ITestQuery
	{
		Task<SampleDto> GetSample(int id);
		Task<List<SampleDto>> GetAllSample();
	}
}
