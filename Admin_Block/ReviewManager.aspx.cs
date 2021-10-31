using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Block_ReviewManager : System.Web.UI.Page
{
	string cmd, cmid;
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
			cmd = "select * from product";
			DataTable dtpshow = dm.SelectQuery(cmd);
			for (i = 0; i < dtpshow.Rows.Count; i++)
			{
				phproduct.Controls.Add(new Literal() { Text = "<tr><td>" + dtpshow.Rows[i][0].ToString() + "</td><td><a href='Administrator_Review_Viewer?data=" + dtpshow.Rows[i][0].ToString() + "'>" + dtpshow.Rows[i][1].ToString() + "</a></td><td>" + dtpshow.Rows[i][2].ToString() + "</td><td>" + dtpshow.Rows[i][3].ToString() + "</td><td>" + dtpshow.Rows[i][4].ToString() + "</td><td>" + dtpshow.Rows[i][5].ToString() + "</td><td>" + dtpshow.Rows[i][6].ToString() + "</td><td>" + dtpshow.Rows[i][9].ToString() + "</td></tr>" });
			}
		}
		else
		{
			Response.Redirect("Home");
		}
		//--------------------------------------




		
	}
}