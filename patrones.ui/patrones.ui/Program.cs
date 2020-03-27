using patrones.objects;
using System;

namespace patrones.ui
{
	class Programretret
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Fruta fruta;
			float value;
			bool salir = false;
			while (!salir)
			{
				Console.Clear();
				Console.Write("Ingrese el nombre de una fruta: ");
				string nombre = Console.ReadLine();
				salir = nombre.Trim().ToLower() == "salir";
				fruta = (ITotalable)Factory.Instanciar(nombre, null);
				if (fruta != null)
				{
					(Singleton.Instancia()).Contador += 1;
					Console.Write("Ingrese el precio de la fruta: ");
					value = 0;
					while (!float.TryParse(Console.ReadLine(), out value))
					{
						Console.Write("Ingrese el precio de la fruta: ");
					}
					fruta.Precio = value;
					Console.WriteLine("Total: " + fruta.CalcularTotal(15));
				}
				else
				{
					Console.WriteLine("No vendemos esa fruta");
				}
				Console.ReadKey();
			}
			Singleton singleton2 = Singleton.Instancia();
			Console.WriteLine("Compraste " + singleton2.Contador + " frutas");
		}
	}
}
