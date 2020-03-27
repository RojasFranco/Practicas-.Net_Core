using System;
using System.Collections.Generic;
using System.Text;

namespace patrones.objects
{

	public class Banana : Fruta
	{

		public Banana() : base(0)
		{
		}

		public Banana(float precio) : base(precio)
		{
		}

		public override float CalcularTotal(float cantidad)
		{
			Console.WriteLine("Soy una Banana");
			return cantidad * Precio;
		}
	}
}
