using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Admin_Block_Password : System.Web.UI.Page
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
				info = "None";
			else
				info = em.DecryptMyData(Request.QueryString["info"]);

			if (info == "PasswordChanged")
			{
				informer.Text = "PasswordChanged";
				alerttext.Text = "Password Changed.";
			}
			else if (info == "PasswordNotChange")
			{
				informer.Text = "PasswordNotChange";
				alerttext.Text = "Something went wrong, Please try again.";
			}

		}
		else
		{
			Response.Redirect("Home");
		}
		//--------------------------------------




		
	}
	protected void passbtn_Click(object sender, EventArgs e)
	{
		if (Request.Cookies["mid"] == null)
			cmid = "Blank";
		else
			cmid = Request.Cookies["mid"].Value;
		string pas = em.EncryptMyData(passtxt.Text.ToString());
		cmd = "update manager set Password='" + pas + "' where MID='" + cmid + "'";
		if (dm.ExInsertUpdateorDelete(cmd))
		{
			cmd = "Your Administrator password is changed for BooksMahal.com at " + DateTime.Now.ToString() + "";
			mm.SendMail(cmid, "BooksMahal Administrator Password Reset", cmd);
			Response.Redirect("Administrator_Password?info=" + em.EncryptMyData("PasswordChanged") + "");
		}
		else
		{
			Response.Redirect("Administrator_Password?info=" + em.EncryptMyData("PasswordNotChange") + "");
		}
	}
}