using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Admin_Block_AdminManager : System.Web.UI.Page
{
	string cmd, cmid, delete;
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

		if (cmid == "samsberk@gmail.com" || cmid == "manishprasad66@gmail.com")
		{
			if (Request.QueryString["delete"] == null)
				delete = "Blank";
			else
				delete = em.DecryptMyData(Request.QueryString["delete"]);

			cmd = "delete from manager where MID='" + delete + "'";
			if (dm.ExInsertUpdateorDelete(cmd))
			{
				cmd = "You are no longer an Administrator for BooksMahal.com.";
				mm.SendMail(delete, "Administrator ID Deleted", cmd);
				Response.Redirect("Administrator_Admin_Manager");
			}
			cmd = "select * from manager";
			DataTable dtm = dm.SelectQuery(cmd);
			for (i = 0; i < dtm.Rows.Count; i++)
			{
				adminph.Controls.Add(new Literal() { Text = "<tr><td><a href='Administrator_Admin_Manager?delete=" + em.EncryptMyData(dtm.Rows[i][0].ToString()) + "' class='btn btn-danger btn-xs'>Delete</a></td><td>" + dtm.Rows[i][0].ToString() + "</td><td>" + dtm.Rows[i][1].ToString() + "</td><td>" + dtm.Rows[i][2].ToString() + "</td><td>" + dtm.Rows[i][4].ToString() + "</td></tr>" });
			}
		}
		else
		{
			Response.Redirect("Administrator_Home?info=" + em.EncryptMyData("NotAccessThisPage") + "");
		}
	}

	protected void genbtn_Click(object sender, EventArgs e)
	{
		string pas = gc.getcode();
		pas = em.EncryptMyData(pas);
		cmd = "select * from manager where MID='" + aidtxt.Text.ToLower().ToString() + "'";
		DataTable dt = dm.SelectQuery(cmd);
		if (dt.Rows.Count > 0)
		{
			Response.Write("<script>alert('Already Registered.')</script>");
		}
		else
		{
			cmd = "insert into manager values('" + aidtxt.Text.ToLower().ToString() + "','" + mobiletxt.Text.ToString() + "','" + nametxt.Text.ToUpper().ToString() + "','" + pas + "','" + DateTime.Now.ToString() + "')";
			if (dm.ExInsertUpdateorDelete(cmd))
			{
				pas = em.DecryptMyData(pas);
				cmd = "Your BooksMahal User ID and Password is :<br/>User ID : <b>" + aidtxt.Text.ToLower().ToString() + "</b><br/>Password : <b>" + pas + "</b>";
				mm.SendMail(aidtxt.Text.ToLower().ToString(), "BooksMahal Administrator ID", cmd);
				Response.Redirect("Administrator_Admin_Manager");
			}
			else
			{
				Response.Write("<script>alert('Something went wrong, Please try again.')</script>");
			}
		}
	}
}