using Curso.Common.DTO;
using Curso.Data.Services;
using Curso.Data.Services.FolderActualizaPersona;
using Curso.Data.Services.FolderAltaPersona;
using Curso.Data.Services.FolderAutorizacion;
using Curso.Data.Services.FolderBajaPersona;
using Curso.Model.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using RestSharp;
using System;
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
		private readonly IAltaPersona _altaPersona;
		private readonly IBajaPersona _bajaPersona;
		private readonly IActualizaPersona _actualizaPersona;
		private readonly IAutorizando _autorizacion;

		public TablesController(ILogger<TablesController> logger, ICargaTabla cargaTabla, 
			IAltaPersona altaPersona, IBajaPersona bajaPersona, IActualizaPersona actualizaPersona, IAutorizando autorizando)
		{
			_logger = logger;
			//_loginService = loginService;
			_logger.LogInformation("Constructor TablesController");
			this._cargaTabla = cargaTabla;
			this._altaPersona = altaPersona;
			_bajaPersona = bajaPersona;
			_actualizaPersona = actualizaPersona;
			_autorizacion = autorizando;
		}

		public bool tokenValidoDeserealizado(string tokenValidar)
		{
			IRestResponse respuesta = _autorizacion.TestApi(tokenValidar);

			JavaScriptSerializer deserealizer = new JavaScriptSerializer();
			bool respuestaDeserealizada = deserealizer.Deserialize<bool>(respuesta.Content);
			return respuestaDeserealizada;

		}


		[HttpGet("Grilla1/{token}")]
		public async Task<ActionResult> GetGrilla1(string token)
		{
			bool validoToken = this.tokenValidoDeserealizado(token);
						

			if (!validoToken)
			{
				return Unauthorized(new ResultJson() { Message = "Token no activo, vuelva a logearse o ingrese nuevo token" });
			}

			
			
			var retorno = await _cargaTabla.CargarMiTabla();		
			if( retorno==null)
			{
				return NotFound(new ResultJson() { Message = "La tabla se encuentra vacia" });
			}
			return Ok(retorno);
		}

		[HttpPost("CrearPersona/{token}")]
		public async Task<ActionResult> AltaPersona([FromBody] PersonaTablaDTO persona, string token)
		{
			if (this.tokenValidoDeserealizado(token))
			{
				if (persona.NombreAlta == "" || persona.ApellidoAlta == "")
				{
					return BadRequest(new ResultJson() { Message = "No ingreso nombre o apellido" });
				}
				else if (persona.DniAlta > 99999999 || persona.DniAlta < 1000000)
				{
					return BadRequest(new ResultJson() { Message = "El dni no se encuentra en un rango valido" });
				}
				var personaCargada = await _altaPersona.CargarPersona(persona);
				if (personaCargada == null)
				{
					return BadRequest(new ResultJson() { Message = "El dni ya se encuentra cargado" });
				}
				return Created("", new ResultJson() { Message = "Alta realizada con exito" });
			}
			else
			{
				return Unauthorized(new ResultJson() { Message = "Token no activo, vuelva a logearse o ingrese nuevo token" });
			}
		}


		[HttpDelete("BorrarPersona/{dniAEliminar}/{token}")] //O PODIA Recibir en la funcion un obj de clase(que tenga como prop long dniEliminar)
		public async Task<ActionResult> EliminarPersona(long dniAEliminar, string token)
		{
			if (this.tokenValidoDeserealizado(token))
			{
				if (dniAEliminar < 1000000 || dniAEliminar > 99999999)
				{
					return BadRequest(new ResultJson() { Message = "El dni no esta en un rango valido" });
				}
				bool retornoDeBorrar = await _bajaPersona.BorrarPersona(dniAEliminar);
				if (retornoDeBorrar)
				{
					return Ok(new ResultJson() { Message = "Persona borrada con exito" });
				}
				else
				{
					return BadRequest(new ResultJson() { Message = "El dni no se encuentra en la base de datos" });
				}
			}
			else
			{
				return Unauthorized(new ResultJson() { Message = "El token no esta activo, sesion cerrada" });
			}
		}


		[HttpPut("ActualizarPersona")]
		public async Task<ActionResult> ActualizarPersona(Person datosPersona)
		{
			bool retorno = await _actualizaPersona.ActualizarPersona(datosPersona);
			if(retorno)
			{
				return Ok(new ResultJson() { Message = "Se ha actualizado correctamente" });
			}
			else
			{
				return BadRequest(new ResultJson() { Message = "El dni ingresado no esta en la base" });
			}

		}

	}
}