using GyL.DDD.DotNet.Aplication.Dto;
using GyL.DDD.DotNet.Aplication.Notifications;
using System.Collections.Generic;

namespace GyL.DDD.DotNet.Aplication.Mediators.Sample.GetAll
{
	public class GetSamplesRequest : Request<Response<List<SampleDto>>>
	{
		public GetSamplesRequest()
		{
		}

		public int Id { get; set; }
	}
}
