using Microsoft.AspNetCore.Mvc;
using GyL.DDD.DotNet.Api.Model;
using GyL.DDD.DotNet.Aplication.Notifications;

namespace GyL.DDD.DotNet.Api.Presenters
{
	public class BasePresenter : IBasePresenter
	{
		public virtual IActionResult GetActionResult<T>(T result)
			where T : Result
		{
			if (result.Invalid)
			{
				return CreateErrorResult(result);
			}

			return new OkResult();
		}

		public virtual IActionResult GetActionResult<T, Y>(T result)
			where Y : class
			where T : EntityResult<Y>
		{
			if (result.StatusCode != null)
			{
				return CreateErrorResult(result);
			}

			var res = new JsonResult(result.Entity)
			{
				StatusCode = 200
			};
			return res;

		}

		protected virtual IActionResult CreateErrorResult<T>(T result)
			where T : Result
		{
			var errorBody = ApiError.FromResult(result);
			switch (result.StatusCode)
			{
				case StatusCode.NotFound: return new NotFoundObjectResult(errorBody);
				case StatusCode.UnprocessableEntity: return new UnprocessableEntityObjectResult(errorBody);
				case StatusCode.Unauthorized: return new UnauthorizedObjectResult(errorBody);
				case StatusCode.BadRequest:
				default: return new BadRequestObjectResult(errorBody);
			}
		}
	}
}
