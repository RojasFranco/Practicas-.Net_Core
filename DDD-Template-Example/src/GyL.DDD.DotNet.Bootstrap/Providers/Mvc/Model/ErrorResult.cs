using Flunt.Notifications;
using GyL.DDD.DotNet.Aplication.Notifications;
using System.Collections.Generic;

namespace GyL.DDD.DotNet.Bootstrap.Providers.Mvc.Model
{
	public class ErrorResult
    {
        public IEnumerable<Notification> Notifications { get; private set; }

        public ErrorResult() { }

        private ErrorResult(IEnumerable<Notification> notifications)
        {
            this.Notifications = notifications;
        }

        public static ErrorResult FromResponse(ResponseBase result)
        {
            return new ErrorResult(result.Notifications);
        }
    }
}
