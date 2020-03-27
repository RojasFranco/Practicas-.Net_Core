using System;
using System.Collections.Generic;
using System.Text;

namespace patrones.objects
{
	public class Pera : Fruta
	{

		public Pera() : base(0)
		{
		}

		public Pera(float precio) : base(precio)
		{
		}

		public override float CalcularTotal(float cantidad)
		{
			Console.WriteLine("Soy una Pera");
			return cantidad * Precio;
		}
	}
}
