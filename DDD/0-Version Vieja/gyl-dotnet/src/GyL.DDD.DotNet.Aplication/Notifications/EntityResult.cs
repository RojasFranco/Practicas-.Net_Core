using Flunt.Notifications;
using System.Collections.Generic;

namespace GyL.DDD.DotNet.Aplication.Notifications
{
    public class EntityResult<T> : Result where T : class
    {
        public EntityResult(IReadOnlyCollection<Notification> notifications, T entity)
            : base(notifications)
        {
            Entity = entity;
        }

        public T Entity { get; }
    }
}
