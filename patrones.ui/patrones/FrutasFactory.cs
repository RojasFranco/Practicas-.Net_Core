using patrones.objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace patrones
{
	public abstract class FrutasFactory
	{
		public static Fruta Instanciar(string nombre)
		{
			switch (nombre.Trim().ToLower())
			{
				case "pera":
					return new Pera();
				case "uva":
					return new Uva();
				case "manzana":
					return new Manzana();
				default:
					return null;
			}
		}
	}
}
