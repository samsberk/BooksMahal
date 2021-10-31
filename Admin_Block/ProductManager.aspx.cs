using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;


public partial class Admin_Block_ProductManager : System.Web.UI.Page
{
	string cmd, delete, cmid;
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
				delete = "KoiNahi";
			else
				delete = Request.QueryString["delete"];

			cmd = "delete from category where CategoryName='" + delete + "'";
			if (dm.ExInsertUpdateorDelete(cmd))
			{
				Response.Redirect("Administrator_Product_Manager");
			}


			cmd = "select * from category";
			DataTable dtcat = dm.SelectQuery(cmd);
			txtcateg.Items.Add("SELECT CATEGORY");
			if (dtcat.Rows.Count > 0)
			{
				for (i = 0; i < dtcat.Rows.Count; i++)
				{
					categph.Controls.Add(new Literal { Text = "<tr><td><a href='Administrator_Product_Manager?delete=" + dtcat.Rows[i][0].ToString() + "' class='btn btn-danger btn-xs'>Delete</a></td><td>" + dtcat.Rows[i][0].ToString() + "</td></tr>" });
					txtcateg.Items.Add(dtcat.Rows[i][0].ToString());
				}
			}

			cmd = "select * from product";
			DataTable dtpshow = dm.SelectQuery(cmd);
			for (i = 0; i < dtpshow.Rows.Count; i++)
			{
				phproduct.Controls.Add(new Literal() { Text = "<tr><td>" + dtpshow.Rows[i][0].ToString() + "</td><td><a href='Administrator_Product_Viewer?data=" + dtpshow.Rows[i][0].ToString() + "' class='link click-on'>" + dtpshow.Rows[i][1].ToString() + "</a></td><td>" + dtpshow.Rows[i][2].ToString() + "</td><td>" + dtpshow.Rows[i][3].ToString() + "</td><td>" + dtpshow.Rows[i][4].ToString() + "</td><td>" + dtpshow.Rows[i][5].ToString() + "</td><td>" + dtpshow.Rows[i][6].ToString() + "</td><td>" + dtpshow.Rows[i][9].ToString() + "</td></tr>" });
			}
		}
		else
		{
			Response.Redirect("Home");
		}
		//--------------------------------------




		
	}

	protected void btnaddcateg_Click(object sender, EventArgs e)
	{
		if (categtxt.Text == "")
		{
			Response.Write("<script>alert('Enter Category Name')</script>");
		}
		else
		{
			cmd = "select * from category where CategoryName='" + categtxt.Text.ToUpper().ToString() + "'";
			DataTable dtc = dm.SelectQuery(cmd);
			if (dtc.Rows.Count > 0)
			{
				categtxt.Text = "";
				Response.Write("<script>alert('Already added this category')</script>");
			}
			else
			{
				cmd = "insert into category values('" + categtxt.Text.ToUpper().ToString() + "')";
				if (dm.ExInsertUpdateorDelete(cmd))
				{
					Response.Redirect("Administrator_Product_Manager");
				}
				else
				{
					Response.Write("<script>alert('Something went wrong, please try again.')</script>");
				}
			}
		}
	}

	protected void btnaddproduct_Click(object sender, EventArgs e)
	{
		cmd = "select * from product";
		DataTable dtprod = dm.SelectQuery(cmd);
		int tot = dtprod.Rows.Count + 1;
		cmd = "select * from product where PID='" + pidtxt.Text.ToString() + "'";
		DataTable dtp = dm.SelectQuery(cmd);
		if (dtp.Rows.Count > 0)
		{
			Response.Write("<script>alert('Already Added this Product.')</script>");
		}
		else
		{
			cmd = "insert into product values('" + pidtxt.Text.ToString() + "','" + txtname.Text.ToString() + "','" + txtcateg.SelectedValue.ToString() + "','" + txtstock.Text.ToString() + "','" + txtsellp.Text.ToString() + "','" + txtstrikep.Text.ToString() + "','" + txtdiscount.Text.ToString() + "','" + txtdesc.Text.ToString() + "','" + txtinfo.Text.ToString() + "','" + txtstate.SelectedValue.ToString() + "','" + tot + "_Cover_" + txtcoverpic.FileName + "','" + tot + "_Syllabus_" + txtsyllpic.FileName + "')";
			if (dm.ExInsertUpdateorDelete(cmd))
			{
				txtcoverpic.SaveAs(Server.MapPath("~/ProductPicture/" + tot + "_Cover_" + txtcoverpic.FileName));
				txtsyllpic.SaveAs(Server.MapPath("~/ProductPicture/" + tot + "_Syllabus_" + txtsyllpic.FileName));
				Response.Redirect("Administrator_Product_Manager");
			}
			else
			{
				Response.Write("<script>alert('Something went wrong, please try again.')</script>");
			}
		}
	}
}