using GyL.DDD.DotNet.Aplication.Dto;
using GyL.DDD.DotNet.Aplication.Notifications;
using GyL.DDD.DotNet.Aplication.Notifications.Messages;

namespace GyL.DDD.DotNet.Aplication.Mediators.Sample.Update
{
	public class UpdateSampleRequest : Request<ResponseBase>
	{
		public UpdateSampleRequest()
		{
			//Only for Mapper
		}

		public UpdateSampleRequest(long id, SampleDto sampleDto)
		{
			if (id <= 0)
				AddNotification(NotificationMessages.Update_InvalidId.Property, NotificationMessages.Update_InvalidId.Message);
			if (sampleDto == null)
				AddNotification("SampleDto", NotificationMessages.Update_DtoIsNull.Message);
			else
			{
				if (string.IsNullOrEmpty(sampleDto.Description))
					AddNotification("description", NotificationMessages.Update_InvalidId.Message);
				Id = id;
				Description = sampleDto.Description;
			}
		}

		public long Id { get; set; }

		public string Description { get; set; }
	}
}
