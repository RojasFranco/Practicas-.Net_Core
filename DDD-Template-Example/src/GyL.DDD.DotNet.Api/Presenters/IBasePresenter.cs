using GyL.DDD.DotNet.Aplication.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace GyL.DDD.DotNet.Api.Presenters
{
    public interface IBasePresenter
    {
        IActionResult GetActionResult<T, Y>(T response)
            where T : Response<Y>
            where Y : class;
        IActionResult GetActionResult<T>(T response) where T : ResponseBase;
    }
}
