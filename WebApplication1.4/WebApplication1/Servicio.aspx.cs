using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace curso.ui
{
	public partial class Servicio : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string t = "1";
		}
		/*
		[WebMethod]
		public static string Login(string user, string password) {

			Result result = new Result();
			result.Status = "ok";
			result.Message = "grilla.html";
			JavaScriptSerializer ser = new JavaScriptSerializer();
			return ser.Serialize(result);
		}
		*/
	}
}