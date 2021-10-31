using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Admin_Block_OrderManager : System.Web.UI.Page
{
	string cmd, cmid;
	int i, j;
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
		DataTable dtm = dm.SelectQuery(cmd);
		if (dtm.Rows.Count > 0)
		{
			cmd = "select * from orders";
			DataTable dt = dm.SelectQuery(cmd);
			if (dt.Rows.Count > 0)
			{
				for (i = 0, j = 1; i < dt.Rows.Count; i++)
				{
					if (dt.Rows[i][10].ToString() == "NEW")
					{
						neworderph.Controls.Add(new Literal { Text = "<tr><td>" + j + "</td><td><a href='Administrator_Order_Viewer?for=" + dt.Rows[i][0].ToString() + "' class='link click-on'>" + dt.Rows[i][0].ToString() + "</a></td><td>" + dt.Rows[i][1].ToString() + "</td><td>" + dt.Rows[i][2].ToString() + "</td><td>" + dt.Rows[i][3].ToString() + "</td><td>" + dt.Rows[i][4].ToString() + "</td></tr>" });
						j++;
					}
				}
				for (i = 0, j = 1; i < dt.Rows.Count; i++)
				{
					if (dt.Rows[i][10].ToString() == "ACCEPTED")
					{
						accptorderph.Controls.Add(new Literal { Text = "<tr><td>" + j + "</td><td><a href='Administrator_Order_Viewer?for=" + dt.Rows[i][0].ToString() + "' class='link click-on'>" + dt.Rows[i][0].ToString() + "</a></td><td>" + dt.Rows[i][1].ToString() + "</td><td>" + dt.Rows[i][2].ToString() + "</td><td>" + dt.Rows[i][3].ToString() + "</td><td>" + dt.Rows[i][4].ToString() + "</td></tr>" });
						j++;
					}
				}
				for (i = 0, j = 1; i < dt.Rows.Count; i++)
				{
					if (dt.Rows[i][10].ToString() == "DELIVERED")
					{
						delorderph.Controls.Add(new Literal { Text = "<tr><td>" + j + "</td><td><a href='Administrator_Order_Viewer?for=" + dt.Rows[i][0].ToString() + "' class='link click-on'>" + dt.Rows[i][0].ToString() + "</a></td><td>" + dt.Rows[i][1].ToString() + "</td><td>" + dt.Rows[i][2].ToString() + "</td><td>" + dt.Rows[i][3].ToString() + "</td><td>" + dt.Rows[i][4].ToString() + "</td></tr>" });
						j++;
					}
				}
				for (i = 0, j = 1; i < dt.Rows.Count; i++)
				{
					if (dt.Rows[i][10].ToString() == "REJECTED")
					{
						canorderph.Controls.Add(new Literal { Text = "<tr><td>" + j + "</td><td><a href='Administrator_Order_Viewer?for=" + dt.Rows[i][0].ToString() + "' class='link click-on'>" + dt.Rows[i][0].ToString() + "</a></td><td>" + dt.Rows[i][1].ToString() + "</td><td>" + dt.Rows[i][2].ToString() + "</td><td>" + dt.Rows[i][3].ToString() + "</td><td>" + dt.Rows[i][4].ToString() + "</td></tr>" });
						j++;
					}
				}
			}
		}
		else
		{
			Response.Redirect("Home");
		}
		//--------------------------------------



		
	}
}