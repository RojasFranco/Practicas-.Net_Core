using GyL.DDD.DotNet.Aplication.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace GyL.DDD.DotNet.Api.Presenters
{
	public class SamplePresenter : BasePresenter, ISamplePresenter
	{
		public IActionResult GetResult(ResponseBase response)
		{
			return (response.Invalid) ? base.CreateInvalidResult(response) : base.CreateValidResult(response);
		}

		public IActionResult GetResult<T>(Response<T> response) where T : class, new()
		{
			return (response.Invalid) ? base.CreateInvalidResult(response) : base.CreateValidResult(response);
		}
	}
}
