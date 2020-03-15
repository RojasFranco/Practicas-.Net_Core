using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using curso.common.CustomAttributes;
using curso.common.Interfaces;

namespace curso.common.DTOs
{
	public class PersonaV4  
	{
		string _nombre;
		string _apellido;

		public PersonaV4(string nombre, string apellido)
		{
			_nombre = nombre;
			_apellido = apellido;
		}

		private void Test() { }

		[HeaderNameAttribute("NOMBRE")]
		public string Nombre { get => _nombre; set => _nombre = value; }

		[HeaderName("APELLIDO")]
		public string Apellido { get => _apellido; set => _apellido = value; }
	}
}
