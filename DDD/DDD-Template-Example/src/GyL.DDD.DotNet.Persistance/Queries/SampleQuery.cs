using GyL.DDD.DotNet.Aplication.Dto;
using GyL.DDD.DotNet.Aplication.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Persistance.Queries
{
	public class SampleQuery : ISampleQuery
	{
		private readonly IDbConnection _connection;
		private readonly Compiler _compiler;

		public SampleQuery(IDbConnection connection, Compiler compiler)
		{
			_connection = connection;
			_compiler = compiler;
		}

		public async Task<SampleDto> GetSampleByIdAsync(long id)
		{
			var query = new QueryFactory(_connection, _compiler).Query("Sample")
				.When(id != 0, q => q.Where("id", "=", id));
			return await query.FirstOrDefaultAsync<SampleDto>();
		}

		public async Task<List<SampleDto>> GetSamplesAsync()
		{
			var query = new QueryFactory(_connection, _compiler).Query("Sample");
			var result = await query.GetAsync<SampleDto>();
			return result.ToList();
		}
	}
}
