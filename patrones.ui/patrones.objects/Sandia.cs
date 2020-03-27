using System;
using System.Collections.Generic;
using System.Text;

namespace patrones.objects
{
	public class Sandia : Fruta
	{

		public Sandia() : base(0)
		{
		}

		public Sandia(float precio) : base(precio)
		{
		}

		public override float CalcularTotal(float cantidad)
		{
			Console.WriteLine("Soy una Sandia");
			return cantidad * Precio;
		}
	}
}
