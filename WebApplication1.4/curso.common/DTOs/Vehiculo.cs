using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using curso.common.CustomAttributes;
using curso.common.Interfaces;

namespace curso.common.DTOs
{
	public class Vehiculo : IRowneable
	{
		string _marca;
		string _patente;
		string _modelo;

		[HeaderName("Marca")]
		public string Marca { get => _marca; set => _marca = value; }

		[HeaderName("Patente")]
		public string Patente { get => _patente; set => _patente = value; }

		[HeaderName("Modelo")]
		public string Modelo { get => _modelo; set => _modelo = value; }

		public List<string> ToRow()
		{
			return new List<string>() { Marca, Patente, Modelo };
		}
	}
}