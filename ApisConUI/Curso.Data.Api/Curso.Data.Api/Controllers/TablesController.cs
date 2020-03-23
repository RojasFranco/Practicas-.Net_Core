using Curso.Data.Services;
using Curso.Model.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Curso.Data.Api.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
	[EnableCors("_CURSO_")]
	public class TablesController : ControllerBase
    {
		private readonly ILogger<TablesController> _logger;
		private readonly ICargaTabla _cargaTabla;

		public TablesController(ILogger<TablesController> logger, ICargaTabla cargaTabla)//, ILoginServiceAsync loginService)
		{
			_logger = logger;
			//_loginService = loginService;
			_logger.LogInformation("Constructor TablesController");
			this._cargaTabla = cargaTabla;
		}

		[HttpGet("Grilla1")]
		public async Task<ActionResult> GetGrilla1()
		{
			var retorno = await _cargaTabla.CargarMiTabla();			
			return Ok(retorno);
		}
	}
}