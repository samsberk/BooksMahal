using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Block_CustomerManager : System.Web.UI.Page
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
			cmd = "select * from customer";
			DataTable dt = dm.SelectQuery(cmd);
			if (dt.Rows.Count > 0)
			{
				for (i = 0, j = 1; i < dt.Rows.Count; i++, j++)
				{
					userph.Controls.Add(new Literal() { Text = "<tr><td>" + j + "</td><td><a href='Administrator_Customer_Details_Viewer?data=" + dt.Rows[i][0].ToString() + "' class='link click-on'>" + dt.Rows[i][0].ToString() + "</a></td><td>" + dt.Rows[i][2].ToString() + "</td><td><a href='tel:" + dt.Rows[i][1].ToString() + "' class='link'>" + dt.Rows[i][1].ToString() + "</a></td></tr>" });
				}
			}
			else
			{
				userph.Controls.Add(new Literal() { Text = "<tr><td colspan='4'>None Registered Customer.</td></tr>" });
			}
		}
		else
		{
			Response.Redirect("Home");
		}
		//--------------------------------------

		
	}
}