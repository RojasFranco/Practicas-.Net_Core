using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace curso.ui
{
	public partial class login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//this.Button2_Click(null, null);
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			Response.Write("Hola mundo");
			//Button1.Visible = false;
			txtUsuario.ReadOnly = false;
			//btnLogin.

		}
	}
}