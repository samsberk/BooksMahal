using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Admin_Block_Default : System.Web.UI.Page
{
	string cmd, cmid, info;
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
			if (Request.QueryString["info"] == null)
				info = "Blank";
			else
				info = em.DecryptMyData(Request.QueryString["info"]);

			if(info== "NotAccessThisPage")
			{
				informer.Text = "NotAccessThisPage";
				alerttext.Text = "You are not permitted to access Administrator Manager.";
			}
		}
		else
		{
			Response.Redirect("Home");
		}
		
	}
}