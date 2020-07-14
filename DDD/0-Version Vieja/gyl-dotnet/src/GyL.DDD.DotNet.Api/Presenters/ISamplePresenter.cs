using GyL.DDD.DotNet.Aplication.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Api.Presenters
{
	public interface ISamplePresenter
	{
		IActionResult GetResult(Result result);
		IActionResult GetResult<T>(EntityResult<T> result) where T : class, new();
	}
}
