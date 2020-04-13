using Curso.Common.DTO;
using Curso.Model.Model;
using System;
using System.Threading.Tasks;

namespace Curso.Services.Services.Interfaces
{
	public interface ILoginServiceAsync
	{
		Task<User> Login(UserDTO user, Guid token);

		Task ChangePassword(User dbUser, UserDTO user);
	}
}
