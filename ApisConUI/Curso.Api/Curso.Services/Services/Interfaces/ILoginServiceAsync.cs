using Curso.Common.DTO;
using Curso.Model.Model;
using System.Threading.Tasks;

namespace Curso.Services.Services.Interfaces
{
	public interface ILoginServiceAsync
	{
		Task<User> Login(UserDTO user);

		Task ChangePassword(User dbUser, UserDTO user);
	}
}
