using GyL.DDD.DotNet.Aplication.Dto;
using GyL.DDD.DotNet.Aplication.Notifications;
using GyL.DDD.DotNet.Aplication.Notifications.Messages;

namespace GyL.DDD.DotNet.Aplication.Mediators.Sample.GetById
{
	public class GetSampleByIdRequest : Request<Response<SampleDto>>
	{
		public GetSampleByIdRequest(long id)
		{
			if (id <= 0)
			    AddNotification(NotificationMessages.GetById_InvalidId.Property, NotificationMessages.GetById_InvalidId.Message);

			Id = id;
		}

		public long Id { get; set; }
	}
}
