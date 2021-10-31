using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Admin_Block_PINManager : System.Web.UI.Page
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

		cmd = "select * from manager where MID='" + cmid + "'";
		DataTable dt = dm.SelectQuery(cmd);
		if (dt.Rows.Count > 0)
		{
			if (Request.QueryString["delete"] == null)
				delete = "Blank";
			else
				delete = Request.QueryString["delete"];
			cmd = "delete from pincode where PIN='" + delete + "'";
			if (dm.ExInsertUpdateorDelete(cmd))
			{
				Response.Redirect("Administrator_PIN_Code_Manager");
			}

			cmd = "select * from pincode";
			DataTable dtpin = dm.SelectQuery(cmd);
			if (dtpin.Rows.Count > 0)
			{
				for (i = 0; i < dtpin.Rows.Count; i++)
				{
					pinph.Controls.Add(new Literal { Text = "<tr><td><a href='Administrator_PIN_Code_Manager?delete=" + dtpin.Rows[i][0].ToString() + "' class='btn btn-danger btn-xs'>Delete</a></td><td>" + dtpin.Rows[i][0].ToString() + "</td></tr>" });
				}
			}
			
		}
		else
		{
			Response.Redirect("Home");
		}

	}
	protected void pinbtn_Click(object sender, EventArgs e)
	{
		if (pintxt.Text == "")
		{
			Response.Write("<script>alert('Enter PIN Code.')</script>");
		}
		else
		{
			cmd = "select * from pincode where PIN='" + pintxt.Text.ToString() + "'";
			DataTable dtc = dm.SelectQuery(cmd);
			if (dtc.Rows.Count > 0)
			{
				pintxt.Text = "";
				Response.Write("<script>alert('Already added this PIN Code')</script>");
			}
			else
			{
				cmd = "insert into pincode values('" + pintxt.Text.ToString() + "')";
				if (dm.ExInsertUpdateorDelete(cmd))
				{
					Response.Redirect("Administrator_PIN_Code_Manager");
				}
				else
				{
					Response.Write("<script>alert('Something went wrong, please try again.')</script>");
				}
			}
		}
	}
}