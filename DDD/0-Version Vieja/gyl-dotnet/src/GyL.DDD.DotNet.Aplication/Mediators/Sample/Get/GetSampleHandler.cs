using GyL.DDD.DotNet.Aplication.Notifications;
using GyL.DDD.DotNet.Aplication.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Aplication.Mediators.Test.Get
{
	public class GetSampleHandler : IRequestHandler<GetSampleRequest, EntityResult<SampleDto>>
	{
		private readonly ITestQuery _testQuery;
		public GetSampleHandler(ITestQuery testQuery)
		{
			_testQuery = testQuery;
		}

		public async Task<EntityResult<SampleDto>> Handle(GetSampleRequest request, CancellationToken cancellationToken)
		{
			if (request.Invalid)
				return new EntityResult<SampleDto>(request.Notifications, null) { StatusCode = StatusCode.BadRequest };

			var result = await _testQuery.GetSample(request.Id);
			
			if (result == null) 
			{
				EntityResult<SampleDto>  t = new EntityResult<SampleDto>(request.Notifications, null) { StatusCode = StatusCode.NotFound };
				t.AddNotification("No funciona el excel");
				return t; 
			}
			
			return new EntityResult<SampleDto>(request.Notifications, result) { StatusCode = StatusCode.Ok };
		}
	}
}
