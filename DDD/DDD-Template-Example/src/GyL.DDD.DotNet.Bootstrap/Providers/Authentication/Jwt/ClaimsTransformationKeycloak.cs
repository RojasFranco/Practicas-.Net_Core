using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Bootstrap.Providers.Authentication.Jwt
{
	internal class ClaimsTransformationKeycloak : IClaimsTransformation
	{
		public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
		{
			ClaimsIdentity claimsIdentity = (ClaimsIdentity)principal.Identity;
			// flatten realm_access because Microsoft identity model doesn't support nested claims
			// by map it to Microsoft identity model, because automatic JWT bearer token mapping already processed here
			if (claimsIdentity.IsAuthenticated && claimsIdentity.HasClaim((claim) => claim.Type == "realm_access"))
			{
				var realmAccessClaim = claimsIdentity.FindFirst((claim) => claim.Type == "realm_access");
				var realmAccessDictionary = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(realmAccessClaim.Value);
				if (realmAccessDictionary["roles"] != null)
				{
					foreach (var role in realmAccessDictionary["roles"])
					{
						claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
					}
				}
			}
			if (claimsIdentity.IsAuthenticated && claimsIdentity.HasClaim((claim) => claim.Type == "preferred_username"))
			{
				var username = claimsIdentity.FindFirst((claim) => claim.Type == "preferred_username");
				claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, username.Value));
			}
			return Task.FromResult(principal);
		}
	}
}
