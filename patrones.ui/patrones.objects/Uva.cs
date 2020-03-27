using System;
using System.Collections.Generic;
using System.Text;

namespace patrones.objects
{
	public class Uva : Fruta
	{

		public Uva() : base(0)
		{
		}

		public Uva(float precio) : base(precio)
		{
		}

		public override float CalcularTotal(float cantidad)
		{
			Console.WriteLine("Soy una Uva");
			return cantidad * Precio;
		}
	}
}
