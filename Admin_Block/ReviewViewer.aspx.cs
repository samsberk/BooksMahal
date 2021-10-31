using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Block_ReviewViewer : System.Web.UI.Page
{
	string cmd, strpid, cmid;
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
		DataTable dt = dm.SelectQuery(cmd);
		if (dt.Rows.Count > 0)
		{
			if (Request.QueryString["data"] == null)
				strpid = "None";
			else
				strpid = Request.QueryString["data"];

			cmd = "select * from product where PID='" + strpid + "'";
			DataTable dtp = dm.SelectQuery(cmd);
			if (dtp.Rows.Count > 0)
			{
				phproduct.Controls.Add(new Literal() { Text = "<tr><td>" + dtp.Rows[i][0].ToString() + "</td><td>" + dtp.Rows[i][1].ToString() + "</td><td>" + dtp.Rows[i][2].ToString() + "</td><td>" + dtp.Rows[i][3].ToString() + "</td><td>" + dtp.Rows[i][4].ToString() + "</td><td>" + dtp.Rows[i][5].ToString() + "</td><td>" + dtp.Rows[i][6].ToString() + "</td><td>" + dtp.Rows[i][9].ToString() + "</td></tr>" });
			}

			cmd = "select * from review where PID='" + strpid + "'";
			DataTable dtr = dm.SelectQuery(cmd);
			if (dtr.Rows.Count > 0)
			{
				for (i = 0, j = 1; i < dtr.Rows.Count; i++, j++)
				{
					reviewph.Controls.Add(new Literal() { Text = "<tr><td>" + j + "</td><td>" + dtr.Rows[0][0].ToString() + "</td><td><a href='Administrator_Customer_Details_Viewer?data=" + dtr.Rows[0][2].ToString() + "' class='link click-on'>" + dtr.Rows[0][2].ToString() + "</a></td><td>" + dtr.Rows[0][3].ToString() + "</td></tr>" });
				}
			}
			else
			{
				reviewph.Controls.Add(new Literal() { Text = "<tr><td colspan='4'>None given by Customer for this product.</td></tr>" });
			}
		}
		else
		{
			Response.Redirect("Home");
		}
		//--------------------------------------




		
	}
}