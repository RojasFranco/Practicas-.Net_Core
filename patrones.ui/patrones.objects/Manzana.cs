using System;
using System.Collections.Generic;
using System.Text;

namespace patrones.objects
{
	public class Manzana : Fruta
	{

		public Manzana() : base(0)
		{
		}

		public Manzana(float precio) : base(precio)
		{
		}

		public Manzana(float precio, string nombre, int otro) : base(precio)
		{
		}

		public override float CalcularTotal(float cantidad)
		{
			Console.WriteLine("Soy una Manzana");
			return cantidad * Precio;
		}
	}
}
