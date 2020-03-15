using curso.common.DTOs;
using curso.DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curso.Bussines
{
	public class SecurityBussines
	{
		public LoginResultDTO Login(UserDTO userDTO) {
			SecurityDAC securityDAC = new SecurityDAC("Data Source=DESKTOP-FM6RR0I ;Initial Catalog=CursoGyL;Integrated Security=True;User=DESKTOP-FM6RR0I;Password=;");
			LoginResultDTO loginResultDTO = securityDAC.Login(userDTO);
			if (loginResultDTO.User == null) {
				loginResultDTO.Status = "fail";
				loginResultDTO.Message = "El usuario no existe";
				return loginResultDTO;
			}
			if (loginResultDTO.User.Password != userDTO.Password)
			{
				loginResultDTO.Status = "fail";
				loginResultDTO.Message = "La contraseña es incorecta";
				return loginResultDTO;
			}
			loginResultDTO.Status = "ok";
			loginResultDTO.Message = "grilla.html";
			return loginResultDTO;
		}

		public LoginResultDTO CambiarContrasenia(UserDTO userDTO, string passNueva)
		{
			LoginResultDTO retornoLogin = this.Login(userDTO);
			SecurityDAC securityDAC = new SecurityDAC("Data Source=DESKTOP-FM6RR0I ;Initial Catalog=CursoGyL;Integrated Security=True;User=DESKTOP-FM6RR0I;Password=;");
			if (retornoLogin.Status=="ok")
			{
				securityDAC.CambioContrania(userDTO, passNueva);				
			}

			return retornoLogin;

		}
	}
}
