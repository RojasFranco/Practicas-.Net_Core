using Microsoft.AspNetCore.Mvc;
using GyL.DDD.DotNet.Aplication.Notifications;

namespace GyL.DDD.DotNet.Api.Presenters
{
    public interface IBasePresenter
    {
        IActionResult GetActionResult<T, Y>(T result)
            where T : EntityResult<Y>
            where Y : class;
        IActionResult GetActionResult<T>(T result) where T : Result;
    }
}
