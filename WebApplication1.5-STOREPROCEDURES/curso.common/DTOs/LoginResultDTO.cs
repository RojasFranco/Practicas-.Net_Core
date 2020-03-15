using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curso.common.DTOs
{
	public class LoginResultDTO
	{
		string _status;
		string _message;
		UserDTO _user;

		public string Status { get => _status; set => _status = value; }
		public string Message { get => _message; set => _message = value; }
		public UserDTO User { get => _user; set => _user = value; }
	}
}
