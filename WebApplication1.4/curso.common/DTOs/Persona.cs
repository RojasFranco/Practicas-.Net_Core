using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using curso.common.Interfaces;

namespace curso.common.DTOs
{
	public class Persona : IRowneable
	{
		string _nombre;
		string _apellido;

		public Persona(string nombre, string apellido)
		{
			_nombre = nombre;
			_apellido = apellido;
		}

		public string Nombre { get => _nombre; set => _nombre = value; }
		public string Apellido { get => _apellido; set => _apellido = value; }

		public List<string> ToRow()
		{
			return new List<string>() { Nombre, Apellido };
		}
	}
}