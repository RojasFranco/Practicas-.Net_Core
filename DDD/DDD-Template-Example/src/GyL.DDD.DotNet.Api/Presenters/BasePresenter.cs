using GyL.DDD.DotNet.Aplication.Notifications;
using GyL.DDD.DotNet.Bootstrap.Providers.Mvc.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GyL.DDD.DotNet.Api.Presenters
{
	public class BasePresenter : IBasePresenter
	{
		public virtual IActionResult GetActionResult<TResponse>(TResponse response) where TResponse : ResponseBase
		{
			if (response.Invalid)
				return CreateInvalidResult(response);
			else
				return new OkResult();
		}

		public virtual IActionResult GetActionResult<TResponse, TEntity>(TResponse response) where TEntity : class where TResponse : Response<TEntity>
		{
			if (response.Invalid)
			{
				return CreateInvalidResult(response);
			}
			return new JsonResult(response.Entity)
			{
				StatusCode = (int?)response.StatusCode
			};
		}

		protected virtual IActionResult CreateValidResult<TResponse>(TResponse response) where TResponse : ResponseBase
		{
			switch (response.StatusCode)
			{
				case StatusCode.OK: return new OkResult(); //200
				case StatusCode.NoContent: return new NoContentResult(); //204
				default: return new OkResult(); //200;
			}
		}

		protected virtual IActionResult CreateValidResult<TResponse>(Response<TResponse> response) where TResponse : class, new()
		{
			switch (response.StatusCode)
			{
				case StatusCode.OK:
					if (response.Entity != null)
						return new JsonResult(response.Entity)
						{
							StatusCode = (int)HttpStatusCode.OK //200
						};
					else
						return new OkResult(); //200
				case StatusCode.Created: return new CreatedResult("", response.Entity); //201
				case StatusCode.NoContent: return new NoContentResult(); //204
				default: return new OkResult(); //200;
			}
		}

		protected virtual IActionResult CreateInvalidResult<TResponse>(TResponse response) where TResponse : ResponseBase
		{
			var error = ErrorResult.FromResponse(response);
			switch (response.StatusCode)
			{
				case StatusCode.NotFound: return new NotFoundObjectResult(error); //404
				case StatusCode.UnprocessableEntity: return new UnprocessableEntityObjectResult(error); //422
				case StatusCode.Unauthorized: return new UnauthorizedObjectResult(error); //401
				case StatusCode.BadRequest: //400
				default: return new BadRequestObjectResult(error); // 400
			}
		}
	}
}
