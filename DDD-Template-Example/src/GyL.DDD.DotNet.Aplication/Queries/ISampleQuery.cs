using GyL.DDD.DotNet.Aplication.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Aplication.Queries
{
	public interface ISampleQuery
	{
		Task<SampleDto> GetSampleByIdAsync(long id);

		Task<List<SampleDto>> GetSamplesAsync();
	}
}
