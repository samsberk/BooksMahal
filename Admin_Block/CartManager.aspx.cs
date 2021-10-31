using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Block_CartManager : System.Web.UI.Page
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
			cmd = "delete from cart where CartID='" + delete + "'";
			if (dm.ExInsertUpdateorDelete(cmd))
			{
				Response.Redirect("Administrator_Cart_Manager");
			}

			cmd = "select * from cart";
			DataTable dtcart = dm.SelectQuery(cmd);
			if (dtcart.Rows.Count > 0)
			{
				for (i = 0; i < dtcart.Rows.Count; i++)
				{
					cartph.Controls.Add(new Literal { Text = "<tr><td><a href='Administrator_Cart_Manager?delete=" + dtcart.Rows[i][0].ToString() + "' class='btn btn-danger btn-xs'>Delete</a></td><td>" + dtcart.Rows[i][0].ToString() + "</td><td>" + dtcart.Rows[i][1].ToString() + "</td><td>" + dtcart.Rows[i][2].ToString() + "</td><td>" + dtcart.Rows[i][3].ToString() + "</td></tr>" });
				}
			}
		}
		else
		{
			Response.Redirect("Home");
		}
	}
}