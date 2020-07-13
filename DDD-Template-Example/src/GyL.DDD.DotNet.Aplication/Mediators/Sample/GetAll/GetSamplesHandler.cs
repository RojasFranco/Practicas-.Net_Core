using GyL.DDD.DotNet.Aplication.Dto;
using GyL.DDD.DotNet.Aplication.Notifications;
using GyL.DDD.DotNet.Aplication.Notifications.Messages;
using GyL.DDD.DotNet.Aplication.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Aplication.Mediators.Sample.GetAll
{
	public class GetSamplesHandler : IRequestHandler<GetSamplesRequest, Response<List<SampleDto>>>
	{
		private readonly ISampleQuery _sampleQuery;
		public GetSamplesHandler(ISampleQuery sampleQuery)
		{
			_sampleQuery = sampleQuery;
		}

		public async Task<Response<List<SampleDto>>> Handle(GetSamplesRequest request, CancellationToken cancellationToken)
		{
			if (request.Invalid)
				return new Response<List<SampleDto>>(request.Notifications, null) { StatusCode = StatusCode.BadRequest };

			var result = await _sampleQuery.GetSamplesAsync();

			if (result == null)
			{
				Response<List<SampleDto>> emptyResult = new Response<List<SampleDto>>(request.Notifications, null) { StatusCode = StatusCode.NotFound };
				emptyResult.AddNotification("List<SampleDto>", NotificationMessages.GetAll_NotFound.Message);
				return emptyResult;
			}

			return new Response<List<SampleDto>>(request.Notifications, result) { StatusCode = StatusCode.OK };

		}
	}
}