using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Admin_Block_NewsletterMessage : System.Web.UI.Page
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

		}
		else
		{
			Response.Redirect("Home");
		}
		//--------------------------------------
	}

	protected void msgbtn_Click(object sender, EventArgs e)
	{

	}
}