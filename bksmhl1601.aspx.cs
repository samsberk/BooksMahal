using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;


public partial class bksmhl1601 : System.Web.UI.Page
{
	string cmd, cmid;
	DBManager dm = new DBManager();
	EncryptionDecryption em = new EncryptionDecryption();
	GenCaptcha gc = new GenCaptcha();
	MyMail mm = new MyMail();
	SMSSender ss = new SMSSender();
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Request.Cookies["mid"] == null)
			cmid = "Blank";
		else
			cmid = Request.Cookies["mid"].Value;

		cmd = "select * from manager where MID='" + cmid + "'";
		DataTable dt = dm.SelectQuery(cmd);
		if (dt.Rows.Count > 0)
		{
			Response.Redirect("Administrator_Home");
		}
	}

	protected void loginbtn_Click(object sender, EventArgs e)
	{
		string pas = em.EncryptMyData(apastxt.Text.ToString());
		cmd = "select * from manager where MID='" + aidtxt.Text.ToLower().ToString() + "' and Password='" + pas + "'";
		DataTable dt = dm.SelectQuery(cmd);
		if (dt.Rows.Count > 0)
		{
			cmd = "Hello " + dt.Rows[0][2].ToString() + ",<br/>You are Logged in as Administrator on BooksMahal.com at " + DateTime.Now.ToString() + "";
			mm.SendMail(dt.Rows[0][0].ToString(), "BooksMahal Administrator Login Success", cmd);
			HttpCookie acook = new HttpCookie("mid")
			{
				Value = dt.Rows[0][0].ToString(),
				Expires = DateTime.Now.AddDays(7)
			};
			Response.Cookies.Add(acook);
			Response.Redirect("Administrator_Home");
		}
		else
		{
			Response.Redirect("Home");
		}
	}
}