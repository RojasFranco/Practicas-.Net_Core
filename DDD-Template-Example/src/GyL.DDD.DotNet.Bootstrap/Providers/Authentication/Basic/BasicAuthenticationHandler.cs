using GyL.DDD.DotNet.Aplication.Services;
using GyL.DDD.DotNet.Domain.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace GyL.DDD.DotNet.Bootstrap.Providers.Authentication.Basic
{
	public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
	{
		private readonly IUserService _userService;

		public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IUserService userService) : base(options, logger, encoder, clock)
		{
			_userService = userService;
		}

		protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
		{
			if (!Request.Headers.ContainsKey("Authorization"))
				return AuthenticateResult.Fail("Missing authorization header");
			IUser user = null;
			try
			{
				var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
				var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
				var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
				var username = credentials[0];
				var password = credentials[1];
				user = await _userService.Authenticate(username, password);
			}
			catch
			{
				return AuthenticateResult.Fail("Invalid authorization header");
			}

			if (user == null)
				return AuthenticateResult.Fail("Invalid username or password");

			List<Claim> claims = new List<Claim>();

			claims.Add(new Claim(ClaimTypes.NameIdentifier, user.NameIdentifier));
			claims.Add(new Claim(ClaimTypes.Name, user.Username));
			claims.Add(new Claim(ClaimTypes.GivenName, user.GivenName));
			claims.Add(new Claim(ClaimTypes.Surname, user.Surname));

			foreach (var role in user.Roles)
				claims.Add(new Claim(ClaimTypes.Role, role));

			var identity = new ClaimsIdentity(claims, Scheme.Name);
			var principal = new ClaimsPrincipal(identity);
			var ticket = new AuthenticationTicket(principal, Scheme.Name);
			
			return AuthenticateResult.Success(ticket);
		}
	}
}