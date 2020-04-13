namespace Curso.Common.DTO
{
	public class UserDTO
	{
		private string _userName;
		private string _password;
		private string _newPassword;

		public string UserName { get => _userName; set => _userName = value; }
		public string Password { get => _password; set => _password = value; }
		public string NewPassword { get => _newPassword; set => _newPassword = value; }
	}
}
