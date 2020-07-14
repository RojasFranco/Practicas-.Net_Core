using Flunt.Notifications;
using System.Collections.Generic;

namespace GyL.DDD.DotNet.Aplication.Notifications
{
	public abstract class BaseNotifiable : Notifiable
    {
        public BaseNotifiable()
        {
        }

        public BaseNotifiable(StatusCode statusCode)
        {
            this.StatusCode = statusCode;
        }

        public BaseNotifiable(IReadOnlyCollection<Notification> notifications)
        {
            AddNotifications(notifications);
        }

        public void AddNotification(string error)
        {
            AddNotification(null, error);
        }

        public void AddNotification(string error, StatusCode statusCode)
        {
            AddNotification(null, error);
            StatusCode = statusCode;
        }

        public void AddNotification(string property, string message, StatusCode statusCode)
        {
            AddNotification(property, message);
            StatusCode = statusCode;
        }

        public void AddNotification(Notification notification, StatusCode statusCode)
        {
            AddNotification(notification);
            StatusCode = statusCode;
        }
        public void AddNotifications(IReadOnlyCollection<Notification> notifications, StatusCode statusCode)
        {
            AddNotifications(notifications);
            StatusCode = statusCode;
        }

        public StatusCode? StatusCode { get; set; }
    }
}
