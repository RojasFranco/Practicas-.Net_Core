using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curso.common.DTOs
{
	public class UserDTO
	{
		private string _user;
		private string _password;

		public UserDTO(string user, string password  )
		{
			_user = user;
			_password = password;
		}

		public string User { get => _user; set => _user = value; }
		public string Password { get => _password; set => _password = value; }
	}
}
