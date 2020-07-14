using GyL.DDD.DotNet.Aplication.Dto;
using GyL.DDD.DotNet.Aplication.Notifications;
using GyL.DDD.DotNet.Aplication.Notifications.Messages;
using GyL.DDD.DotNet.Aplication.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Aplication.Mediators.Sample.GetById
{
	public class GetSampleByIdHandler : IRequestHandler<GetSampleByIdRequest, Response<SampleDto>>
	{
		private readonly ISampleQuery _sampleQuery;
		public GetSampleByIdHandler(ISampleQuery sampleQuery)
		{
			_sampleQuery = sampleQuery;
		}

		public async Task<Response<SampleDto>> Handle(GetSampleByIdRequest request, CancellationToken cancellationToken)
		{
			if (request.Invalid)
				return new Response<SampleDto>(request.Notifications, null) { StatusCode = StatusCode.BadRequest };

			var result = await _sampleQuery.GetSampleByIdAsync(request.Id);
			
			if (result == null) 
			{
				Response<SampleDto> emptyResult = new Response<SampleDto>(request.Notifications, null) { StatusCode = StatusCode.NotFound };
				emptyResult.AddNotification("Sample", NotificationMessages.GetById_NotFound.Message);
				return emptyResult; 
			}
			
			return new Response<SampleDto>(request.Notifications, result) { StatusCode = StatusCode.OK };
		}
	}
}
