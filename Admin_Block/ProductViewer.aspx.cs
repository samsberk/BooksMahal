using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Admin_Block_ProductViewer : System.Web.UI.Page
{
	string cmd, strpid, cmid;
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
			if (Request.QueryString["data"] == null)
				strpid = "None";
			else
				strpid = Request.QueryString["data"];

			cmd = "select * from category";
			DataTable dtcat = dm.SelectQuery(cmd);
			txtcateg.Items.Add("SELECT CATEGORY");
			if (dtcat.Rows.Count > 0)
			{
				for (i = 0; i < dtcat.Rows.Count; i++)
				{
					txtcateg.Items.Add(dtcat.Rows[i][0].ToString());
				}
			}
			cmd = "select * from product where PID='" + strpid + "'";
			DataTable dtp = dm.SelectQuery(cmd);
			if (dtp.Rows.Count > 0)
			{
				coverpic.ImageUrl = "~/ProductPicture/" + dtp.Rows[0][10].ToString();
				syllpic.ImageUrl = "~/ProductPicture/" + dtp.Rows[0][11].ToString();
				pidlbl.Text = dtp.Rows[0][0].ToString();
				namelbl.Text = dtp.Rows[0][1].ToString();
				categlbl.Text = dtp.Rows[0][2].ToString();
				stocklbl.Text = dtp.Rows[0][3].ToString();
				sellplbl.Text = dtp.Rows[0][4].ToString();
				strikeplbl.Text = dtp.Rows[0][5].ToString();
				discountlbl.Text = dtp.Rows[0][6].ToString();
				desclbl.Text = dtp.Rows[0][7].ToString();
				infolbl.Text = dtp.Rows[0][8].ToString();
				statelbl.Text = dtp.Rows[0][9].ToString();
				reviewlinklbl.Text = "<a href='Administrator_Review_Viewer?data=" + dtp.Rows[0][0].ToString() + "' target='_Blank' class='link'>Jump to Review Viewer <i class='fa fa-external-link-square'></i></a>";
			}
		}
		else
		{
			Response.Redirect("Home");
		}
		//--------------------------------------




		
	}

	protected void proupdate_Click(object sender, EventArgs e)
	{
		if (Request.QueryString["data"] == null)
			strpid = "None";
		else
			strpid = Request.QueryString["data"];

		cmd = "select * from product";
		DataTable dtprod = dm.SelectQuery(cmd);
		int tot = dtprod.Rows.Count + 1;
		cmd = "update product set PName='" + txtname.Text.ToString() + "', Category='" + txtcateg.SelectedValue.ToString() + "', TStock='" + txtstock.Text.ToString() + "', SellPrice='" + txtsellp.Text.ToString() + "', StrikePrice='" + txtstrikep.Text.ToString() + "', Discount='" + txtdiscount.Text.ToString() + "', Description='" + txtdesc.Text.ToString() + "', Information='" + txtinfo.Text.ToString() + "', State='" + txtstate.SelectedValue.ToString() + "' where PID='" + strpid + "'";
		if (dm.ExInsertUpdateorDelete(cmd))
		{
			Response.Redirect("Administrator_Product_Viewer?data=" + strpid + "");
		}
		else
		{
			Response.Write("<script>alert('Something went wrong, please try again.')</script>");
		}
	}

	protected void prodelete_Click(object sender, EventArgs e)
	{
		if (Request.QueryString["data"] == null)
			strpid = "None";
		else
			strpid = Request.QueryString["data"];

		cmd = "select * from product where PID='" + strpid + "'";
		DataTable dtp = dm.SelectQuery(cmd);
		FileInfo fl = new FileInfo(Server.MapPath("~/ProductPicture/" + dtp.Rows[0][10].ToString()));
		FileInfo fl2 = new FileInfo(Server.MapPath("~/ProductPicture/" + dtp.Rows[0][11].ToString()));
		fl.Delete();
		fl2.Delete();
		cmd = "delete from product where PID='" + strpid + "'";
		dm.ExInsertUpdateorDelete(cmd);
		cmd = "delete from review where PID='" + strpid + "'";
		dm.ExInsertUpdateorDelete(cmd);
		Response.Redirect("Administrator_Product_Manager");
	}
}