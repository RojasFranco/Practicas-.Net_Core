using GyL.DDD.DotNet.Api.Model;
using GyL.DDD.DotNet.Api.Presenters;
using GyL.DDD.DotNet.Aplication.Mediators.Sample.Get;
using GyL.DDD.DotNet.Aplication.Mediators.Sample.Insert;
using GyL.DDD.DotNet.Aplication.Mediators.Sample.Update;
using GyL.DDD.DotNet.Aplication.Mediators.Test.Get;
using GyL.DDD.DotNet.Aplication.Notifications;
using GyL.DDD.DotNet.Domain.Model;
using GyL.DDD.DotNet.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SampleController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly ISamplePresenter _presenter;
		private readonly ISampleRepository _repository;
		private readonly ILogger<SampleController> _logger;

		public SampleController(ILogger<SampleController> logger, IMediator mediator, ISamplePresenter presenter, ISampleRepository repository)
		{
			_mediator = mediator;
			_presenter = presenter;
			_logger = logger;
			_repository = repository;
		}

		/// <summary>
		/// Report list by external System
		/// </summary>
		/// <param name="reports"></param>
		/// <returns></returns>
		/// bcc-associates/associates/report
		[HttpGet("GetById/{id}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetTestById(int id)
		{
			//return _presenter.GetResult(await _mediator.Send(new GetSampleRequest(id)));
			var getSampleRequest = new GetSampleRequest(id);
			var mediator = await _mediator.Send(getSampleRequest);
			var valuePresenter = _presenter.GetResult(mediator);
			return valuePresenter;
		}

		[HttpPost("PostById/{id}/{descripcion}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> PostTestById(int id, string descripcion)
		{
			//return _presenter.GetResult(await _mediator.Send(new GetSampleRequest(id)));

			Sample sample = new Sample() { Description = descripcion, Id = id.ToString() };
			var insertSampleRequest = new InsertSampleRequest(sample);
			var mediator = await _mediator.Send(insertSampleRequest);
			var valuePresenter = _presenter.GetResult(mediator);
			return valuePresenter;
		}


		
		[HttpGet("GetAll")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetAll()
		{
			//return _presenter.GetResult(await _mediator.Send(new GetSampleRequest(id)));
			var getSampleRequest = new GetAllRequest();
			var mediator = await _mediator.Send(getSampleRequest);
			var valuePresenter = _presenter.GetResult(mediator);
			return valuePresenter;
		}

		[HttpPut("UpdateSample/{id}/{nuevaDescripcion}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiError))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> UpdateSample(int id, string nuevaDescripcion)
		{			
			var getSampleRequest = new UpdateSampleRequest(id, nuevaDescripcion);
			var mediator = await _mediator.Send(getSampleRequest);
			var valuePresenter = _presenter.GetResult(mediator);
			return valuePresenter;
		}
	}
}