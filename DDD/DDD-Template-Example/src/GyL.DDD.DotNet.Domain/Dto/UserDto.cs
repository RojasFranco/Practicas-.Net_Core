using System.Collections.Generic;

namespace GyL.DDD.DotNet.Domain.Dto
{
	public class UserDto : IUser
	{
		public string NameIdentifier { get; set; }
		public string Username { get; set; }
		public List<string> Roles { get; set; }
		public string GivenName { get; set; }
		public string Surname { get; set; }
	}
}
