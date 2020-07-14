using GyL.DDD.DotNet.Aplication.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace GyL.DDD.DotNet.Api.Presenters
{
	public interface ISamplePresenter
	{
		IActionResult GetResult(ResponseBase response);
		IActionResult GetResult<T>(Response<T> response) where T : class, new();
	}
}
