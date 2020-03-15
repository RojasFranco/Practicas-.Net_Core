using curso.common.DTOs;
using curso.common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curso.ui.Extensions
{
	public static class Extensions
	{
		public static IRowneable GetRowneable(this PersonaV4 persona, string parematro) {
			PersonaV3 personaV3 = new PersonaV3(persona.Nombre, persona.Apellido);
			return personaV3;
		}

		public static int GetRowneable(this PersonaV3 persona)
		{
			return 8;
		}
	}
}
