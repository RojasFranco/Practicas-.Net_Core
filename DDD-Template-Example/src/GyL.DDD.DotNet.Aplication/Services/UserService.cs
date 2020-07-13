using GyL.DDD.DotNet.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Aplication.Services
{
	public interface IUserService
	{
		Task<IUser> Authenticate(string username, string password);
	}

	public class UserService : IUserService
	{
		public UserService()
		{

		}

		public async Task<IUser> Authenticate(string username, string password)
		{
			//TODO ROLES
			var user = new UserDto();
			user.NameIdentifier = Guid.NewGuid().ToString();
			user.Username = username;
			user.GivenName = username;
			user.Surname = username;
			user.Roles = new List<string>() { "admin", username };
			return user;
			//throw new System.NotImplementedException();
		}
	}
}
