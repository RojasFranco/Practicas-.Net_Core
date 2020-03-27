using System;
using System.Collections.Generic;
using System.Text;

namespace patrones.objects
{
	public abstract class Fruta
	{
		private float _precio;

		public float Precio { get => _precio; set => _precio = value; }

		public Fruta(float precio)
		{
			_precio = precio;
		}

		public abstract float CalcularTotal(float cantidad);
	}
}
