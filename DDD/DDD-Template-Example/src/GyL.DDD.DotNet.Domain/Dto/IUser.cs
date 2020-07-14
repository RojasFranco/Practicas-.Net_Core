using System.Collections.Generic;

namespace GyL.DDD.DotNet.Domain.Dto
{
	public interface IUser
	{
		string NameIdentifier { set; get; }
		string Username { set; get; }
		string GivenName { set; get; }
		string Surname { set; get; }
		List<string> Roles { set; get; }
	}
}
