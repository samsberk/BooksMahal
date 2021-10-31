using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class Admin_Block_samsberk1003 : System.Web.UI.Page
{
	string cmd;
	DBManager dm = new DBManager();
	EncryptionDecryption em = new EncryptionDecryption();
	GenCaptcha gc = new GenCaptcha();
	MyMail mm = new MyMail();
	SMSSender ss = new SMSSender();
	protected void Page_Load(object sender, EventArgs e)
	{

	}

	protected void genbtn_Click(object sender, EventArgs e)
	{
		if (aidtxt.Text != "" || passtxt.Text != "" || nametxt.Text != "" || mobiletxt.Text != "")
		{
			string pas = em.EncryptMyData(passtxt.Text.ToString());
			cmd = "insert into manager values('" + aidtxt.Text.ToLower().ToString() + "','" + mobiletxt.Text.ToString() + "','" + nametxt.Text.ToUpper().ToString() + "','" + pas + "','" + DateTime.Now.ToString() + "')";
			if (dm.ExInsertUpdateorDelete(cmd))
			{
				Response.Write("<a href='bksmhl1601'>Go</a>");
				Response.Write("<script>alert('ok')</script>");
			}
			else
			{
				Response.Write("<script>alert('not ok')</script>");
			}
		}
	}
}