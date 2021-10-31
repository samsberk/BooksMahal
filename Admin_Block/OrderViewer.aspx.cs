using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Block_OrderViewer : System.Web.UI.Page
{
	string cmd, info, sub, msg, st, cmid;
	int i;
	DBManager dm = new DBManager();
	EncryptionDecryption em = new EncryptionDecryption();
	SMSSender ss = new SMSSender();
	GenCaptcha gc = new GenCaptcha();
	MyMail mm = new MyMail();
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
			if (Request.QueryString["for"] == null)
				info = "None";
			else
				info = Request.QueryString["for"];

			Session["orderidforinvoice"] = null;
			orderidlbl.Text = info;
			cmd = "select * from orders where OID='" + info + "'";
			DataTable dt = dm.SelectQuery(cmd);
			if (dt.Rows.Count > 0)
			{
				oidlbl.Text = dt.Rows[0][0].ToString();
				oelbl.Text = dt.Rows[0][1].ToString();
				onlbl.Text = dt.Rows[0][2].ToString();
				omlbl.Text = dt.Rows[0][3].ToString();
				oalbl.Text = dt.Rows[0][4].ToString();
				oclbl.Text = dt.Rows[0][5].ToString();
				opinlbl.Text = dt.Rows[0][6].ToString();
				oamlbl.Text = dt.Rows[0][7].ToString();
				otlbl.Text = dt.Rows[0][8].ToString();

				if (dt.Rows[0]["OrderStatus"].ToString() == "ACCEPTED")
					accshow.Text = "Accepted";
				else if (dt.Rows[0]["OrderStatus"].ToString() == "REJECTED")
					accshow.Text = "Rejected";
				else if (dt.Rows[0]["OrderStatus"].ToString() == "DELIVERED")
					accshow.Text = "Delivered";

				cmd = "select * from customer where CID='" + dt.Rows[0]["Email"].ToString() + "'";
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
				if (dt.Rows[0]["OrderStatus"].ToString() == "DELIVERED" || dt.Rows[0]["OrderStatus"].ToString() == "REJECTED")
				{
					cmd = "select * from delivered where OID='" + info + "'";
					DataTable dtop = dm.SelectQuery(cmd);
					if (dtop.Rows.Count > 0)
					{
						for (i = 0; i < dtop.Rows.Count; i++)
						{
							cmd = "select * from product where PID='" + dtop.Rows[i]["PID"].ToString() + "'";
							DataTable dtp = dm.SelectQuery(cmd);
							if (i == 0)
								opdetailsph.Controls.Add(new Literal { Text = "<tr><td>" + dtp.Rows[0]["PID"].ToString() + "</td><td><img src='../ProductPicture/" + dtp.Rows[0]["CoverPic"].ToString() + "' alt='Not Available' style='height:130px;width:100px;' /></td><td>" + dtp.Rows[0]["PName"].ToString() + "</td><td>&#8377; " + dtp.Rows[0]["StrikePrice"].ToString() + "</td><td>" + dtp.Rows[0]["Discount"].ToString() + "%</td><td>&#8377; " + dtp.Rows[0]["SellPrice"].ToString() + "</td><td>" + dtop.Rows[i]["Quantity"].ToString() + "</td><td>&#8377; " + dtop.Rows[i]["Amount"].ToString() + "</td><td rowspan='" + dtop.Rows.Count + "'>&#8377; " + dt.Rows[0]["Amount"].ToString() + "</td></tr>" });
							else
								opdetailsph.Controls.Add(new Literal { Text = "<tr><td>" + dtp.Rows[0]["PID"].ToString() + "</td><td><img src='../ProductPicture/" + dtp.Rows[0]["CoverPic"].ToString() + "' alt='Not Available' style='height:130px;width:100px;' /></td><td>" + dtp.Rows[0]["PName"].ToString() + "</td><td>&#8377; " + dtp.Rows[0]["StrikePrice"].ToString() + "</td><td>" + dtp.Rows[0]["Discount"].ToString() + "%</td><td>&#8377; " + dtp.Rows[0]["SellPrice"].ToString() + "</td><td>" + dtop.Rows[i]["Quantity"].ToString() + "</td><td>&#8377; " + dtop.Rows[i]["Amount"].ToString() + "</td></tr>" });
						}
					}
					else
					{
						opdetailsph.Controls.Add(new Literal { Text = "<tr><td colspan='8'>No Product Found that is/are ordered</td></tr>" });
					}
				}
				else
				{
					cmd = "select * from odproduct where OID='" + info + "'";
					DataTable dtop = dm.SelectQuery(cmd);
					if (dtop.Rows.Count > 0)
					{
						for (i = 0; i < dtop.Rows.Count; i++)
						{
							cmd = "select * from product where PID='" + dtop.Rows[i]["PID"].ToString() + "'";
							DataTable dtp = dm.SelectQuery(cmd);
							if (i == 0)
								opdetailsph.Controls.Add(new Literal { Text = "<tr><td>" + dtp.Rows[0]["PID"].ToString() + "</td><td><img src='../ProductPicture/" + dtp.Rows[0]["CoverPic"].ToString() + "' alt='Not Available' style='height:130px;width:100px;' /></td><td>" + dtp.Rows[0]["PName"].ToString() + "</td><td>&#8377; " + dtp.Rows[0]["StrikePrice"].ToString() + "</td><td>" + dtop.Rows[i]["Discount"].ToString() + "%</td><td>&#8377; " + dtp.Rows[0]["SellPrice"].ToString() + "</td><td>" + dtop.Rows[i]["Quantity"].ToString() + "</td><td>&#8377; " + dtop.Rows[i]["Amount"].ToString() + "</td><td rowspan='" + dtop.Rows.Count + "'>&#8377; " + dt.Rows[0]["Amount"].ToString() + "</td></tr>" });
							else
								opdetailsph.Controls.Add(new Literal { Text = "<tr><td>" + dtp.Rows[0]["PID"].ToString() + "</td><td><img src='../ProductPicture/" + dtp.Rows[0]["CoverPic"].ToString() + "' alt='Not Available' style='height:130px;width:100px;' /></td><td>" + dtp.Rows[0]["PName"].ToString() + "</td><td>&#8377; " + dtp.Rows[0]["StrikePrice"].ToString() + "</td><td>" + dtop.Rows[i]["Discount"].ToString() + "%</td><td>&#8377; " + dtp.Rows[0]["SellPrice"].ToString() + "</td><td>" + dtop.Rows[i]["Quantity"].ToString() + "</td><td>&#8377; " + dtop.Rows[i]["Amount"].ToString() + "</td></tr>" });
						}
					}
					else
					{
						opdetailsph.Controls.Add(new Literal { Text = "<tr><td colspan='8'>No Product Found that is/are ordered</td></tr>" });
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

	protected void acceptbtn_Click(object sender, EventArgs e)
	{
		if (Request.QueryString["for"] == null)
			info = "None";
		else
			info = Request.QueryString["for"];

		cmd = "select * from orders where OID='" + info + "'";
		DataTable dt = dm.SelectQuery(cmd);
		st = "ACCEPTED";
		cmd = "update orders set OrderStatus='" + st + "' where OID='" + info + "'";
		if (dm.ExInsertUpdateorDelete(cmd))
		{
			sub = "Order is on way at BooksMahal.com";
			msg = "Your order was accepted at " + DateTime.Now.ToString() + " for Order ID <b>" + info + "</b>, and it is on the way. It will reach as soon as possible. Thank You.";
			mm.SendMail(dt.Rows[0]["Email"].ToString(), sub, msg);
			Response.Redirect("Administrator_Order_Viewer?for=" + info + "");
		}
	}
	protected void printinvoice_Click(object sender, EventArgs e)
	{
		if (Request.QueryString["for"] == null)
			info = "None";
		else
			info = Request.QueryString["for"];
		Session["orderidforinvoice"] = info;
		Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('Invoice','_newtab');", true);
	}
	protected void rejectbtn_Click(object sender, EventArgs e)
	{
		if (Request.QueryString["for"] == null)
			info = "None";
		else
			info = Request.QueryString["for"];

		cmd = "select * from orders where OID='" + info + "'";
		DataTable dt = dm.SelectQuery(cmd);
		st = "REJECTED";
		cmd = "update orders set OrderStatus='" + st + "' where OID='" + info + "'";
		if (dm.ExInsertUpdateorDelete(cmd))
		{
			sub = "Order Canceled at BooksMahal.com";
			msg = "Your order was canceled at " + DateTime.Now.ToString() + " for Order ID <b>" + info + "</b>. Thank You.";
			mm.SendMail(dt.Rows[0]["Email"].ToString(), sub, msg);
			cmd = "select * from odproduct where OID='" + info + "'";
			DataTable dtod = dm.SelectQuery(cmd);
			if (dtod.Rows.Count > 0)
			{
				for (i = 0; i < dtod.Rows.Count; i++)
				{
					cmd = "insert into delivered(OID, CID, PID, Quantity, Amount, Discount) values('" + dtod.Rows[i]["OID"].ToString() + "','" + dtod.Rows[i]["CID"].ToString() + "','" + dtod.Rows[i]["PID"].ToString() + "','" + dtod.Rows[i]["Quantity"].ToString() + "','" + dtod.Rows[i]["Amount"].ToString() + "','" + dtod.Rows[i]["Discount"].ToString() + "')";
					dm.ExInsertUpdateorDelete(cmd);
				}
			}
			cmd = "delete from odproduct where CID='" + dt.Rows[0]["Email"].ToString() + "'";
			dm.ExInsertUpdateorDelete(cmd);
			Response.Redirect("Administrator_Order_Viewer?for=" + info + "");
		}
	}
	protected void deliverbtn_Click(object sender, EventArgs e)
	{
		if (Request.QueryString["for"] == null)
			info = "None";
		else
			info = Request.QueryString["for"];

		cmd = "select * from orders where OID='" + info + "'";
		DataTable dt = dm.SelectQuery(cmd);
		st = "DELIVERED";
		cmd = "update orders set PaymentStatus='" + pstxt.SelectedValue.ToString() + "', OrderStatus='" + st + "', PaymentMode='" + pmtxt.SelectedValue.ToString() + "', TransactionNo='" + transtxt.Text.ToUpper().ToString() + "' where OID='" + info + "'";
		if (dm.ExInsertUpdateorDelete(cmd))
		{
			sub = "Order Delivered from BooksMahal.com";
			msg = "Your order was Delivered at " + DateTime.Now.ToString() + " for Order ID <b>" + info + "</b>. Thank You.";
			mm.SendMail(dt.Rows[0]["Email"].ToString(), sub, msg);
			cmd = "select * from odproduct where OID='" + info + "'";
			DataTable dtod = dm.SelectQuery(cmd);
			if (dtod.Rows.Count > 0)
			{
				for (i = 0; i < dtod.Rows.Count; i++)
				{
					cmd = "insert into delivered(OID, CID, PID, Quantity, Amount, Discount) values('" + dtod.Rows[i]["OID"].ToString() + "','" + dtod.Rows[i]["CID"].ToString() + "','" + dtod.Rows[i]["PID"].ToString() + "','" + dtod.Rows[i]["Quantity"].ToString() + "','" + dtod.Rows[i]["Amount"].ToString() + "','" + dtod.Rows[i]["Discount"].ToString() + "')";
					dm.ExInsertUpdateorDelete(cmd);
				}
			}
			cmd = "delete from odproduct where CID='" + dt.Rows[0]["Email"].ToString() + "'";
			dm.ExInsertUpdateorDelete(cmd);
			Response.Redirect("Administrator_Order_Viewer?for=" + info + "");
		}
	}
}