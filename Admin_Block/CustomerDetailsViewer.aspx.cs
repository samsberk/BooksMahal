using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Block_CustomerDetailsViewer : System.Web.UI.Page
{
	string cmd, strpid, cmid;
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

			cmd = "select * from customer where CID='" + strpid + "'";
			DataTable dtc = dm.SelectQuery(cmd);
			if (dtc.Rows.Count > 0)
			{
				cidlbl.Text = dtc.Rows[0][0].ToString();
				mobilelbl.Text = dtc.Rows[0][1].ToString();
				namelbl.Text = dtc.Rows[0][2].ToString();
				addresslbl.Text = dtc.Rows[0][4].ToString();
				citylbl.Text = dtc.Rows[0][5].ToString();
				pinlbl.Text = dtc.Rows[0][6].ToString();
				torderlbl.Text = dtc.Rows[0][7].ToString();
				astlbl.Text = dtc.Rows[0][8].ToString();
				sofferlbl.Text = dtc.Rows[0][9].ToString();
				memlbl.Text = dtc.Rows[0][10].ToString();
			}
		}
		else
		{
			Response.Redirect("Home");
		}
		//--------------------------------------
		

	}

	protected void deluser_Click(object sender, EventArgs e)
	{
		if (Request.QueryString["data"] == null)
			strpid = "None";
		else
			strpid = Request.QueryString["data"];

		cmd = "delete from customer where CID='" + strpid + "'";
		dm.ExInsertUpdateorDelete(cmd);
		Response.Redirect("Administrator_Customer_Manager");
	}

	protected void mailbtn_Click(object sender, EventArgs e)
	{
		if (Request.QueryString["data"] == null)
			strpid = "None";
		else
			strpid = Request.QueryString["data"];

		mm.SendMail(strpid, subjecttxt.Text.ToString(), bodytxt.Text.ToString());
		Response.Redirect("Administrator_Customer_Details_Viewer?data=" + strpid + "");
	}

	protected void msgbtn_Click(object sender, EventArgs e)
	{
		if (Request.QueryString["data"] == null)
			strpid = "None";
		else
			strpid = Request.QueryString["data"];
	}
}