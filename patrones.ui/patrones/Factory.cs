using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace patrones
{
	public abstract class Factory
	{
		public static object Instanciar(string nombre, params object?[]? args)
		{
			string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			Assembly assembly = Assembly.LoadFrom(path + @"\patrones.objects.dll");
			Type type = assembly.GetType("patrones.objects." + nombre, false, true);

			//Fruta fruta = (Fruta)Activator.CreateInstance(Assembly.LoadFrom(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\patrones.objects.dll").GetType("patrones.objects." + nombre));

			return Activator.CreateInstance(type, args);
	
			//switch (nombre.Trim().ToLower())
			//{
			//	case "pera":
			//		return new Pera();
			//	case "uva":
			//		return new Uva();
			//	case "manzana":
			//		return new Manzana();
			//	case "banana":
			//		return new Banana();
			//	default:
			//		return null;
			//}
		}
	}
}
