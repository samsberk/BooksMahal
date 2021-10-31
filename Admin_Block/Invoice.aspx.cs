using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Block_Invoice : System.Web.UI.Page
{
	string cmd, cmid;
	DBManager dm = new DBManager();
	EncryptionDecryption em = new EncryptionDecryption();
	SMSSender ss = new SMSSender();
	GenCaptcha gc = new GenCaptcha();
	MyMail mm = new MyMail();
	protected void Page_Load(object sender, EventArgs e)
	{

		if (Request.Cookies["mid"] == null)
			cmid = "Blank";
		else
			cmid = Request.Cookies["mid"].Value;

		cmd = "select * from manager where MID='" + cmid + "'";
		DataTable dtm = dm.SelectQuery(cmd);
		if (dtm.Rows.Count > 0)
		{
			if (Session["orderidforinvoice"] != null)
			{
				cmd = "select * from orders where OID='" + Session["orderidforinvoice"] + "'";
				DataTable dt = dm.SelectQuery(cmd);
				if (dt.Rows.Count > 0)
				{
					namelbl.Text = dt.Rows[0]["Name"].ToString();
					addresslbl.Text = dt.Rows[0]["Address"].ToString() + ", " + dt.Rows[0]["City"].ToString() + ", " + dt.Rows[0]["PIN"].ToString();
					contactlbl.Text = dt.Rows[0]["Mobile"].ToString();
					oidlbl.Text = "#" + dt.Rows[0]["OID"].ToString();
					totamlbl.Text = "&#8377; " + dt.Rows[0]["Amount"].ToString() + ".00";
				}
				else
				{
					Response.Write("<script>alert('Something went wrong, Try again.')</script>");
				}
			}
			else
			{
				Response.Redirect("Administrator_Home");
			}
		}
		else
		{
			Response.Redirect("Home");
		}
		//--------------------------------------
	}
}