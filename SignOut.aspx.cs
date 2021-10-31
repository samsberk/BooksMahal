using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class SignOut : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		Response.Cookies["cid"].Value = null;
		Session["signout"] = "signout";
		Response.Redirect("User_Zone");
	}
}