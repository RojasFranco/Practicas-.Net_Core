using Flunt.Notifications;
using GyL.DDD.DotNet.Aplication.Notifications;
using GyL.DDD.DotNet.Aplication.Queries;
using MediatR;

namespace GyL.DDD.DotNet.Aplication.Mediators.Test.Get
{
	public class GetSampleRequest : Notifiable, IRequest<EntityResult<SampleDto>>
	{
		public GetSampleRequest(int id)
		{
			if (id==2)
				AddNotification("id", "el id 2 no va");
			
			Id = id;
		}

		public int Id { get; set; }
	}
}
