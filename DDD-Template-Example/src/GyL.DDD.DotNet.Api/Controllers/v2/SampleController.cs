using GyL.DDD.DotNet.Api.Presenters;
using GyL.DDD.DotNet.Aplication.Dto;
using GyL.DDD.DotNet.Aplication.Mediators.Sample.Create;
using GyL.DDD.DotNet.Aplication.Mediators.Sample.GetAll;
using GyL.DDD.DotNet.Aplication.Mediators.Sample.GetById;
using GyL.DDD.DotNet.Aplication.Mediators.Sample.Update;
using GyL.DDD.DotNet.Aplication.Notifications;
using GyL.DDD.DotNet.Bootstrap.Providers.Mvc.Model;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Api.Controllers.v2
{
	[ApiConventionType(typeof(DefaultApiConventions))]
	[Produces("application/json")]
	[Consumes("application/json")]
	[Route("api/v2/[controller]")]
	[ApiController]
	[EnableCors("AllowAll")]
	//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[Authorize(AuthenticationSchemes = "Basic")]
	public class SampleController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly ISamplePresenter _presenter;
		private readonly ILogger<SampleController> _logger;

		public SampleController(ILogger<SampleController> logger, IMediator mediator, ISamplePresenter presenter)
		{
			_mediator = mediator;
			_presenter = presenter;
			_logger = logger;
			//_logger.LogWarning("SampleController started");
		}

		/// <summary>
		/// ACA RESUMEN DE LA FUNCIONALIDAD
		/// </summary>
		/// <remarks>ACA VAN LAS OBSERVACIONES</remarks>
		/// <param name="id" example="123">Id de la entidad Sample</param>
		/// <returns>SanpleDto</returns>
		/// <response code="200">Schema SampleDto</response> 
		/// <response code="400">Bad request</response>
		/// <response code="401">Unauthorized request</response>
		/// <response code="403">Forbidden</response> 
		/// <response code="404">Item was not found</response> 
		/// api/sample/{id}
		[HttpGet("{id}")]
		[ApiExplorerSettings(GroupName = "v2")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SampleDto))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResult))]
		[ProducesErrorResponseType(typeof(void))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResult))]
		public async Task<IActionResult> GetSample(int id)
		{
			return _presenter.GetResult(await _mediator.Send(new GetSampleByIdRequest(id)));
		}

		/// <summary>
		/// ACA RESUMEN DE LA FUNCIONALIDAD
		/// </summary>
		/// <remarks>ACA VAN LAS OBSERVACIONES Solo accesible para el rol 'Manager'</remarks>
		/// <returns>List of SampleDto</returns>
		/// <response code="200">List of schema SampleDto objects</response> 
		/// <response code="400">Bad request</response>
		/// <response code="401">Unauthorized request</response>
		/// <response code="403">Forbidden</response> 
		/// <response code="404">Item was not found</response> 
		/// api/sample
		[HttpGet]
		[ApiExplorerSettings(GroupName = "v2")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SampleDto>))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResult))]
		[ProducesErrorResponseType(typeof(void))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResult))]
		[Authorize(Roles = "Manager")]
		public async Task<IActionResult> GetSamples()
		{
			return _presenter.GetResult(await _mediator.Send(new GetSamplesRequest()));
		}

		/// <summary>
		/// ACA RESUMEN DE LA FUNCIONALIDAD
		/// </summary>
		/// <remarks>ACA VAN LAS OBSERVACIONES</remarks>
		/// <param name="sampleDto">Schema SampleDto</param>
		/// <returns>No tiene valor de retorno</returns>
		/// <response code="201">Sample entity created successfully</response>
		/// <response code="400">Bad request</response>
		/// <response code="401">Unauthorized request</response>
		/// <response code="403">Forbidden</response> 
		/// api/sample
		[HttpPost]
		[ApiExplorerSettings(GroupName = "v2")]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SampleDto))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResult))]
		[ProducesErrorResponseType(typeof(void))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		public async Task<IActionResult> CreateSample([FromBody] SampleDto sampleDto)
		{
			return _presenter.GetResult(await _mediator.Send(new CreateSampleRequest(sampleDto)));
		}

		/// <summary>
		/// ACA RESUMEN DE LA FUNCIONALIDAD
		/// </summary>
		/// <remarks>ACA VAN LAS OBSERVACIONES</remarks>
		/// <param name="id" example="123">Id de la entidad Sample</param>
		/// <param name="sampleDto">Schema SampleDto</param>
		/// <returns>No tiene valor de retorno</returns>
		/// <response code="204">Sample entity updated successfully</response>
		/// <response code="400">Bad request</response>
		/// <response code="401">Unauthorized request</response>
		/// <response code="403">Forbidden</response> 
		/// api/sample/{id}
		[HttpPut("{id}")]
		[ApiExplorerSettings(GroupName = "v2")]
		[ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(NoContentResult))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResult))]
		[ProducesErrorResponseType(typeof(void))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		public async Task<IActionResult> UpdatePutSample(long id, [FromBody] SampleDto sampleDto)
		{
			return _presenter.GetResult(await _mediator.Send(new UpdateSampleRequest(id, sampleDto)));
		}

		/// <summary>
		/// ACA RESUMEN DE LA FUNCIONALIDAD
		/// </summary>
		/// <remarks>ACA VAN LAS OBSERVACIONES</remarks>
		/// <param name="id" example="123">Id de la entidad Sample</param>
		/// <returns>No tiene valor de retorno</returns>
		/// <response code="204">Sample entity deleted successfully</response>
		/// <response code="400">Bad request</response>
		/// <response code="401">Unauthorized request</response>
		/// <response code="403">Forbidden</response> 
		/// api/sample/{id}
		[HttpDelete("{id}")]
		[ApiExplorerSettings(GroupName = "v2")]
		[ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(NoContentResult))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResult))]
		[ProducesErrorResponseType(typeof(void))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		public async Task<IActionResult> DeleteSample(long id)
		{
			return _presenter.GetResult(await _mediator.Send(new DeleteSampleRequest(id)));
		}
	}
}
