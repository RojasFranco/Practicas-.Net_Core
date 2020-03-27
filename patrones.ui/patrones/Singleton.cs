using System;
using System.Collections.Generic;
using System.Text;

namespace patrones
{
	public class Singleton
	{
		private static Singleton _singleton = null;
		private static object _lock = new object();
		
		private int contador;
		private Singleton()
		{

		}

		public int Contador { get => contador; set => contador = value; }

		public static Singleton Instancia()
		{
			lock (_lock) 
			{
				if (_singleton == null)
					_singleton = new Singleton();
				return _singleton;
			}
		}
	}
}
