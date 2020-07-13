using Microsoft.AspNetCore.Authentication;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Bootstrap.Providers.Authentication.Jwt
{
	internal class ClaimsTransformation : IClaimsTransformation
	{
		public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
		{
			ClaimsIdentity claimsIdentity = (ClaimsIdentity)principal.Identity;
			if (claimsIdentity.IsAuthenticated)
			{
				var roles = claimsIdentity.Claims.Where(x => x.Type == "Role").ToArray();
				if (roles != null)
				{
					foreach (var role in roles)
					{
						claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.Value));
					}
				}
				var username = claimsIdentity.Claims.Where(x => x.Type == "sub").FirstOrDefault();
				claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, username.Value));
				var givenName = claimsIdentity.Claims.Where(x => x.Type == "GivenName").FirstOrDefault();
				claimsIdentity.AddClaim(new Claim(ClaimTypes.GivenName, givenName?.Value));
				var surname = claimsIdentity.Claims.Where(x => x.Type == "Surname").FirstOrDefault();
				claimsIdentity.AddClaim(new Claim(ClaimTypes.Surname, surname?.Value));
			}
			return Task.FromResult(principal);
		}
	}
}