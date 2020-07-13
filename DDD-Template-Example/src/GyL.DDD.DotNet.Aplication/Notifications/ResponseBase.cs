using Flunt.Notifications;
using System.Collections.Generic;

namespace GyL.DDD.DotNet.Aplication.Notifications
{
    public class ResponseBase : BaseNotifiable
    {
        public ResponseBase(StatusCode statusCode) : base(statusCode)
        {
        }

        public ResponseBase(IReadOnlyCollection<Notification> notifications) : base(notifications)
        {
        }
    }
}
