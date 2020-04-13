using Curso.Common.DTO;
using Curso.Model.Model;
using Curso.Services.Services.FolderAutorizacion;
using Curso.Services.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Curso.Api.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
	[EnableCors("_CURSO_")]
	public class SecurityController : ControllerBase
    {
		private readonly ILogger<SecurityController> _logger;
		private readonly ILoginServiceAsync _loginService;
		private readonly IValidacionTiempoEnLinea _validacionTiempoEnLinea;		

		public SecurityController(ILogger<SecurityController> logger, ILoginServiceAsync loginService, IValidacionTiempoEnLinea validacionTiempoEnLinea)
		{
			_logger = logger;
			_loginService = loginService;
			_logger.LogInformation("Constructor SecurityController");
			_validacionTiempoEnLinea = validacionTiempoEnLinea;
		}

		// POST: api/Security
		[HttpPost("Login")]
		public async Task<ActionResult> Login([FromBody] UserDTO user)
		{
			var token = Guid.NewGuid();
			if (user.UserName == null || user.UserName.Length < 3 || user.Password == null || user.Password.Length < 5)
				return BadRequest(new ResultJson() { Message = "Verifique los datos enviados." });
			var dbUser = await _loginService.Login(user, token);
			if (dbUser == null)
				return Unauthorized(new ResultJson() { Message = "Usuario y/o contraseña invalidos" });
			else
			{				
				return Ok(new ResultJson() { Message = dbUser.DefaultPage, TokenActualizado = token });
			}
		}

		// POST: api/Security
		[HttpPost("Change")]
		public async Task<ActionResult> Change([FromBody] UserDTO user)
		{
			var token = Guid.NewGuid();
			if (user.UserName == null || user.UserName.Length < 3 || 
				user.Password == null || user.Password.Length < 5 ||
				user.NewPassword == null || user.NewPassword.Length < 5)
				return BadRequest(new ResultJson() { Message = "Verifique los datos enviados." });
			var dbUser = await _loginService.Login(user, token);
			if (dbUser == null)
				return Unauthorized(new ResultJson() { Message = "Usuario y/o contraseña invalidos" });
			else {
				await _loginService.ChangePassword(dbUser, user);
				return Created("", new ResultJson() { Message = dbUser.DefaultPage, TokenActualizado=token });
			}
		}


		[HttpGet("ValidarTokenTiempo/{token}")]///{token}
		public async Task<bool> ValidarUsuarioPorToken(string token)
		{
			
			if(!Guid.TryParse(token, out Guid guidValidado))
			{
				return false;				
			}

			var retorno = await _validacionTiempoEnLinea.VerificarTiempo(guidValidado);
			return retorno;
			
		}

	}
}
