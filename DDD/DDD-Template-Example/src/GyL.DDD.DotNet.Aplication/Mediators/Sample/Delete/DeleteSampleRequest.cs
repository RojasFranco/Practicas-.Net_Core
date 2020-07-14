using GyL.DDD.DotNet.Aplication.Notifications;
using GyL.DDD.DotNet.Aplication.Notifications.Messages;

namespace GyL.DDD.DotNet.Aplication.Mediators.Sample.Update
{
	public class DeleteSampleRequest : Request<ResponseBase>
	{
		public DeleteSampleRequest()
		{
			//Only for Mapper
		}

		public DeleteSampleRequest(long id)
		{
			if (id <= 0)
				AddNotification(NotificationMessages.Delete_InvalidId.Property, NotificationMessages.Delete_InvalidId.Message);

			Id = id;
		}

		public long Id { get; set; }
	}
}
