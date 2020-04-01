using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using curso.common.DTOs;
using curso.ui.Extensions;
using System.Collections.Generic;
using curso.Bussines;

namespace curso.ui
{
	/// <summary>
	/// Descripción breve de Service
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
	[System.Web.Script.Services.ScriptService]
	public class Service : System.Web.Services.WebService
	{

		[WebMethod]
		[System.Web.Script.Services.ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
		public string Login(string user, string password)
		{
			SecurityBussines securityBussines = new SecurityBussines();
			JavaScriptSerializer ser = new JavaScriptSerializer();
			return ser.Serialize(securityBussines.Login(new UserDTO(user, password)));
		}

		[WebMethod]
		[System.Web.Script.Services.ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
		public string CambiarContrasenia(string user, string passwordActual, string passNueva)
		{
			SecurityBussines securityBussines = new SecurityBussines();
			JavaScriptSerializer ser = new JavaScriptSerializer();
			return ser.Serialize(securityBussines.CambiarContrasenia(new UserDTO(user, passwordActual), passNueva));
		}

		[WebMethod]
		[System.Web.Script.Services.ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
		public string GetGridDataV1()
		{
			TableJSONv1 tableJSON = new TableJSONv1();
			tableJSON.Headers.Add("Nombre");
			tableJSON.Headers.Add("Apellido");

			for (int i = 0; i < 100; i++)
			{
				List<string> row = new List<string>();
				row.Add("Jose-" + i.ToString());
				row.Add("Perez-" + i.ToString());
				tableJSON.Rows.Add(row);
			}

			JavaScriptSerializer ser = new JavaScriptSerializer();
			return ser.Serialize(tableJSON);
		}

		[WebMethod]
		[System.Web.Script.Services.ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
		public string GetGridDataV2()
		{
			TableJSONv2 tableJSON = new TableJSONv2();
			tableJSON.Headers.Add("Nombre");
			tableJSON.Headers.Add("Apellido");

			for (int i = 0; i < 100; i++)
			{
				Persona persona = new Persona("Jose-" + i.ToString(), "Perez-" + i.ToString());
				tableJSON.Data.Add(persona);
			}

			JavaScriptSerializer ser = new JavaScriptSerializer();
			return ser.Serialize(tableJSON);
		}

		[WebMethod]
		[System.Web.Script.Services.ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
		public string GetGridDataV3()
		{
			TableJSONv3 tableJSON = new TableJSONv3(typeof(PersonaV3));
			for (int i = 0; i < 100; i++)
			{
				PersonaV3 persona = new PersonaV3("Jose-" + i.ToString(), "Perez-" + i.ToString());
				tableJSON.Data.Add(persona);
			}
			JavaScriptSerializer ser = new JavaScriptSerializer();
			return ser.Serialize(tableJSON);
		}

		[WebMethod]
		[System.Web.Script.Services.ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
		public string GetGridDataV4()
		{
			PersonaBussines personaBussines = new PersonaBussines();
			JavaScriptSerializer ser = new JavaScriptSerializer();
			return ser.Serialize(personaBussines.ObtenerPersonas());
		}

		[WebMethod]
		[System.Web.Script.Services.ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
		public string GetGridDataV5()
		{
			TableJSONv4<Vehiculo> tableJSON = new TableJSONv4<Vehiculo>();
			for (int i = 0; i < 100; i++)
			{
				Vehiculo vehiculo = new Vehiculo();
				vehiculo.Marca = "Marca-" + i.ToString();
				vehiculo.Patente = "Patente-" + i.ToString();
				vehiculo.Modelo = "Modelo-" + i.ToString();
				tableJSON.Data.Add(vehiculo);
			}
			JavaScriptSerializer ser = new JavaScriptSerializer();
			return ser.Serialize(tableJSON);
		}

		[WebMethod]
		[System.Web.Script.Services.ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
		public string GetGridDataV6()
		{
			TableJSONv4<PersonaV4> tableJSON = new TableJSONv4<PersonaV4>();
			for (int i = 0; i < 100; i++)
			{
				PersonaV4 persona = new PersonaV4("Jose-" + i.ToString(), "Perez-" + i.ToString());
				tableJSON.Data.Add(persona.GetRowneable("saraza"));
			}
			JavaScriptSerializer ser = new JavaScriptSerializer();
			return ser.Serialize(tableJSON);
		}

	}
}
