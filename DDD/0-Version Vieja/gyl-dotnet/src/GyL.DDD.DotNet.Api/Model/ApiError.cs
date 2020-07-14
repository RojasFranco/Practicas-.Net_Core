using Flunt.Notifications;
using GyL.DDD.DotNet.Aplication.Notifications;
using System.Collections.Generic;

namespace GyL.DDD.DotNet.Api.Model
{
    public class ApiError
    {
        public IEnumerable<Notification> _notifications { get; private set; }

        public ApiError() { }

        public ApiError(IEnumerable<Notification> notifications, StatusCode? error = null)
        {
            this._notifications = notifications;
        }

        public static ApiError FromResult(Result result)
        {
            return new ApiError(result.Notifications, result.StatusCode);
        }
    }
}
