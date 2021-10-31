using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Admin_Block_NewsletterMail : System.Web.UI.Page
{
	string cmd, cmid;
	int i;
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

		}
		else
		{
			Response.Redirect("Home");
		}
		//--------------------------------------



	}

	protected void mailbtn_Click(object sender, EventArgs e)
	{
		cmd = "select * from customer";
		DataTable dt = dm.SelectQuery(cmd);
		if (dt.Rows.Count > 0)
		{
			for (i = 0; i < dt.Rows.Count; i++)
			{
				mm.SendMail(dt.Rows[i][0].ToString(), subjecttxt.Text.ToString(), bodytxt.Text.ToString());
			}
			Response.Redirect("Administrator_Newsletter_Mail");
		}
		else
		{
			Response.Write("<script>alert('None user Detected.')</script>");
		}
	}
}