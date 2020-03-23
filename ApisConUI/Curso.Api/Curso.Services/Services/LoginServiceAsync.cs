using Curso.Common.DTO;
using Curso.Model.Context;
using Curso.Model.Model;
using Curso.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Curso.Services.Services
{
	public class LoginServiceAsync : ILoginServiceAsync
	{
		private readonly ILogger<LoginServiceAsync> _logger;
		private readonly CursoContext _cursoContext;

		public LoginServiceAsync(ILogger<LoginServiceAsync> logger, CursoContext cursoContext)
		{
			_logger = logger;
			_cursoContext = cursoContext;
			_logger.LogInformation("Constructor LoginServiceAsync");
		}

		public async Task<User> Login(UserDTO user)
		{
			var dbUser = await _cursoContext.Users.Where(u => u.UserName == user.UserName).FirstOrDefaultAsync();
			if (dbUser != null && dbUser.Password != user.Password)
				return null;
			if (dbUser != null && dbUser.Password == user.Password)
			{
				dbUser.LastLoginDate = DateTime.Now;
				await _cursoContext.SaveChangesAsync();
			}
			return dbUser;
		}

		public async Task ChangePassword(User dbUser, UserDTO user)
		{
			dbUser.Password = user.NewPassword;
			await _cursoContext.SaveChangesAsync();
		}
	}
}
