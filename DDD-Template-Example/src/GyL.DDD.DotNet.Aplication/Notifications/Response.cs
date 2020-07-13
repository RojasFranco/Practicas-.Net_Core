using Flunt.Notifications;
using System.Collections.Generic;

namespace GyL.DDD.DotNet.Aplication.Notifications
{
	public class Response<TEntity> : ResponseBase where TEntity : class
    {
        public Response(IReadOnlyCollection<Notification> notifications, TEntity entity) : base(notifications)
        {
            Entity = entity;
        }

        public TEntity Entity { get; }
    }
}
