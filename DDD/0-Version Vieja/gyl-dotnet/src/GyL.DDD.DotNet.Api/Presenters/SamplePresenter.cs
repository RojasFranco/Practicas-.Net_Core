using GyL.DDD.DotNet.Aplication.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Api.Presenters
{
	public class SamplePresenter : BasePresenter, ISamplePresenter
	{
		public IActionResult GetResult(Result result)
		{
			return result.Invalid ? base.GetActionResult(result) :
				new JsonResult(new { })
				{
					StatusCode = 200,
				};
		}

		public IActionResult GetResult<T>(EntityResult<T> result) where T : class, new()
		{
			return result.Invalid ? base.GetActionResult(result) :
				new JsonResult(result.Entity) { StatusCode = 200 };
		}
	}
}
