using GyL.DDD.DotNet.Aplication.Dto;
using GyL.DDD.DotNet.Aplication.Notifications;
using GyL.DDD.DotNet.Aplication.Notifications.Messages;

namespace GyL.DDD.DotNet.Aplication.Mediators.Sample.Create
{
	public class CreateSampleRequest : Request<Response<SampleDto>>
	{
		public CreateSampleRequest() : base()
		{
			//Only for Mapper
		}

		public CreateSampleRequest(SampleDto sampleDto): base()
		{
			if (sampleDto == null)
				AddNotification("SampleDto", NotificationMessages.Create_DtoIsNull.Message);
			else {
				if (string.IsNullOrEmpty(sampleDto.Description))
					AddNotification("description", NotificationMessages.Create_IsNullOrEmpty.Message);

				Description = sampleDto.Description;
			}
		}

		public string Description { get; set; }
	}
}
