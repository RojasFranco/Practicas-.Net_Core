using curso.common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using curso.DAC;

namespace curso.Bussines
{
    public class PersonaBussines
    {
		public TableJSONv4<PersonaV3> ObtenerPersonas()
		{
			PersonaDAC personaDAC = new PersonaDAC("Data Source=DESKTOP-FEKA2OH ;Initial Catalog=Curso2020;Integrated Security=True;User=Pingui;Password=saraza;");
			return personaDAC.ObtenerPersonas();
		}
	}
}
