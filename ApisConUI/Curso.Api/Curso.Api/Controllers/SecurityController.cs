using Curso.Common.DTO;
using Curso.Services.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

		public SecurityController(ILogger<SecurityController> logger, ILoginServiceAsync loginService)
		{
			_logger = logger;
			_loginService = loginService;
			_logger.LogInformation("Constructor SecurityController");
		}

		// POST: api/Security
		[HttpPost("Login")]
		public async Task<ActionResult> Login([FromBody] UserDTO user)
		{
			if (user.UserName == null || user.UserName.Length < 3 || user.Password == null || user.Password.Length < 10)
				return BadRequest(new ResultJson() { Message = "Verifique los datos enviados." });
			var dbUser = await _loginService.Login(user);
			if (dbUser == null)
				return Unauthorized(new ResultJson() { Message = "Usuario y/o contraseña invalidos" });
			else return Ok(new ResultJson() { Message = dbUser.DefaultPage });
		}

		// POST: api/Security
		[HttpPost("Change")]
		public async Task<ActionResult> Change([FromBody] UserDTO user)
		{
			if (user.UserName == null || user.UserName.Length < 3 || 
				user.Password == null || user.Password.Length < 10 ||
				user.NewPassword == null || user.NewPassword.Length < 10)
				return BadRequest(new ResultJson() { Message = "Verifique los datos enviados." });
			var dbUser = await _loginService.Login(user);
			if (dbUser == null)
				return Unauthorized(new ResultJson() { Message = "Usuario y/o contraseña invalidos" });
			else {
				await _loginService.ChangePassword(dbUser, user);
				return Created("", new ResultJson() { Message = dbUser.DefaultPage });
			}
		}
	}
}
