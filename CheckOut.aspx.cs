using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class CheckOut : System.Web.UI.Page
{
	string cmd, cc, info, city, ps, os, pm, trno, sub, msg, sr2;
	int i, j, op, tp = 0, sr, sp, ttp = 0, dp, discount;
	int ct = 0, qt = 0;
	DBManager dm = new DBManager();
	EncryptionDecryption em = new EncryptionDecryption();
	SMSSender ss = new SMSSender();
	GenCaptcha gc = new GenCaptcha();
	MyMail mm = new MyMail();
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["checkout"] == null)
		{
			Response.Redirect("Cart");
		}
		else
		{
			if (Request.QueryString["info"] == null)
				info = "None";
			else
				info = em.DecryptMyData(Request.QueryString["info"]);

			if (info == "SuccessfullForNewsletter")
			{
				informer.Text = "SuccessfullForNewsletter";
				alerttext.Text = "Subscribed for Newsletter.";
			}
			else if (info == "QueryNotSubmitted")
			{
				informer.Text = "QueryNotSubmitted";
				alerttext.Text = "Something went wrong, Please try again letter.";
			}
			else if (info == "MustEnterYourEmail")
			{
				informer.Text = "MustEnterYourEmail";
				alerttext.Text = "Please enter your E-Mail ID before subscribing the BooksMahal for Newsletter.";
			}
			else if (info == "CanNotDeliverInThisArea")
			{
				informer.Text = "CanNotDeliverInThisArea";
				alerttext.Text = "This item is not available in this area, Please change this address or contact to BooksMahal Help Center.";
			}


			cmd = "select * from product";
			DataTable dtpa = dm.SelectQuery(cmd);
			if (dtpa.Rows.Count > 0)
			{
				for (i = 0; i < dtpa.Rows.Count; i++)
				{
					keywordph.Controls.Add(new Literal { Text = "<li><a href='Shop?for=" + dtpa.Rows[i]["PID"].ToString() + "'>" + dtpa.Rows[i]["PName"].ToString() + "</a></li>" });
				}
			}
			cmd = "select * from category";
			DataTable dtca = dm.SelectQuery(cmd);
			if (dtca.Rows.Count > 0)
			{
				for (i = 0; i < dtca.Rows.Count; i++)
				{
					keywordph.Controls.Add(new Literal { Text = "<li><a href='Shop?for=" + dtca.Rows[i][0].ToString() + "'>" + dtca.Rows[i][0].ToString() + "</a></li>" });
				}
			}

			if (Request.Cookies["cid"] == null)
			{
				cc = "None";
				showbtn.Text = "signinbtn";
			}
			else
			{
				cc = Request.Cookies["cid"].Value;
				showbtn.Text = "signoutbtn";
				cmd = "select * from customer where CID='" + cc + "'";
				DataTable dtcus = dm.SelectQuery(cmd);
				if (dtcus.Rows.Count > 0)
				{
					label1.Text = dtcus.Rows[0][0].ToString();
					label2.Text = dtcus.Rows[0][1].ToString();
					label3.Text = dtcus.Rows[0][2].ToString();
					label4.Text = dtcus.Rows[0][4].ToString();
					label5.Text = dtcus.Rows[0][6].ToString();
				}

				cmd = "select * from cart where CID='" + cc + "'";
				DataTable dtc = dm.SelectQuery(cmd);
				addeditems.Text = dtc.Rows.Count.ToString();
				if (dtc.Rows.Count > 0)
				{
					for (i = 0, j = 1; i < dtc.Rows.Count; i++, j++)
					{
						cmd = "select * from product where PID='" + dtc.Rows[i][2].ToString() + "'";
						DataTable dtp = dm.SelectQuery(cmd);
						if (dtp.Rows.Count > 0)
						{
							if (dtp.Rows[0]["Category"].ToString() == "ENGG. QUANTUMS")
							{
								ct++;
								qt = qt + int.Parse(dtc.Rows[i]["Quantity"].ToString());
							}

						}
					}
					if (ct >= 5 || qt >= 5)
					{
						dquoteph.Controls.Add(new Literal { Text = "<span style='font-size:16px;font-weight:bold;color:red;'>Congratulations!<br />25% Discount (on Engg. Quantums) coupan added.</span><br /><br />" });
						for (i = 0, j = 1; i < dtc.Rows.Count; i++, j++)
						{
							cmd = "select * from product where PID='" + dtc.Rows[i][2].ToString() + "'";
							DataTable dtp = dm.SelectQuery(cmd);
							if (dtp.Rows.Count > 0)
							{
								sp = int.Parse(dtp.Rows[0][5].ToString()) * int.Parse(dtc.Rows[i][3].ToString());
								if (dtp.Rows[0]["Category"].ToString() == "ENGG. QUANTUMS")
									discount = 25;
								else
									discount = int.Parse(dtp.Rows[0]["Discount"].ToString());
								dp = (sp * discount) / 100;
								op = sp - dp;
								pricelist.Controls.Add(new Literal { Text = "<tr><td>" + j + "</td><td>" + dtp.Rows[0]["PName"].ToString() + "</td><td>" + dtp.Rows[0]["Category"].ToString() + "</td><td>" + dtc.Rows[i][3].ToString() + "</td><td>&#8377 " + sp.ToString() + ".00</td><td>" + discount.ToString() + "%</td><td>&#8377 " + op.ToString() + ".00</td></tr>" });
								tp = tp + op;
							}
						}
					}
					else
					{
						for (i = 0, j = 1; i < dtc.Rows.Count; i++, j++)
						{
							cmd = "select * from product where PID='" + dtc.Rows[i][2].ToString() + "'";
							DataTable dtp = dm.SelectQuery(cmd);
							if (dtp.Rows.Count > 0)
							{
								sp = int.Parse(dtp.Rows[0][5].ToString()) * int.Parse(dtc.Rows[i][3].ToString());
								discount = int.Parse(dtp.Rows[0]["Discount"].ToString());
								dp = (sp * discount) / 100;
								op = sp - dp;
								pricelist.Controls.Add(new Literal { Text = "<tr><td>" + j + "</td><td>" + dtp.Rows[0]["PName"].ToString() + "</td><td>" + dtp.Rows[0]["Category"].ToString() + "</td><td>" + dtc.Rows[i][3].ToString() + "</td><td>&#8377 " + sp.ToString() + ".00</td><td>" + discount.ToString() + "%</td><td>&#8377 " + op.ToString() + ".00</td></tr>" });
								tp = tp + op;
							}
						}
					}
					totcostlbl.Text = "&#8377 " + tp.ToString() + ".00";
				}
			}
		}
	}

	protected void formbtn_Click(object sender, EventArgs e)
	{
		if (Session["checkout"] == null)
		{
			Response.Redirect("Cart");
		}
		else
		{
			if (Request.QueryString["info"] == null)
				info = "None";
			else
				info = em.DecryptMyData(Request.QueryString["info"]);

			if (Request.Cookies["cid"] == null)
			{
				cc = "None";
				showbtn.Text = "signinbtn";
			}
			else
			{
				cmd = "select * from pincode where PIN='" + pintxt.Text.ToString() + "'";
				DataTable dtpin = dm.SelectQuery(cmd);
				if (dtpin.Rows.Count > 0)
				{
					cmd = "select * from cart where CID='" + cc + "'";
					DataTable dtc = dm.SelectQuery(cmd);
					if (dtc.Rows.Count > 0)
					{
						city = "MEERUT";
						ps = "PENDING";
						os = "NEW";
						pm = "WAITING";
						trno = "WAITING";
						cmd = "select * from customer where CID='" + cc + "'";
						DataTable dtcus = dm.SelectQuery(cmd);
						cmd = "select * from orders";
						DataTable dtord = dm.SelectQuery(cmd);
						sr = dtord.Rows.Count + 19111;
						cmd = "insert into orders values('" + sr + "','" + emailtxt.Text.ToLower().ToString() + "','" + nametxt.Text.ToUpper().ToString() + "','" + mobiletxt.Text.ToString() + "','" + addresstxt.Text.ToUpper().ToString() + "','" + city + "','" + pintxt.Text.ToString() + "','" + tp.ToString() + "','" + DateTime.Now.ToString() + "','" + ps + "','" + os + "','" + pm + "','" + trno + "')";
						if (dm.ExInsertUpdateorDelete(cmd))
						{
							for (i = 0; i < dtc.Rows.Count; i++)
							{
								cmd = "select * from product where PID='" + dtc.Rows[i][2].ToString() + "'";
								DataTable dtp = dm.SelectQuery(cmd);
								sp = int.Parse(dtp.Rows[0][5].ToString()) * int.Parse(dtc.Rows[i][3].ToString());
								if (ct >= 5 || qt >= 5)
								{
									if (dtp.Rows[0]["Category"].ToString() == "ENGG. QUANTUMS")
										discount = 25;
									else
										discount = int.Parse(dtp.Rows[0]["Discount"].ToString());
									tp = sp - (sp * discount) / 100;
								}
								else
								{
									discount = int.Parse(dtp.Rows[0]["Discount"].ToString());
									tp = sp - (sp * discount) / 100;
								}
								cmd = "select * from odproduct where CID='" + cc + "'";
								DataTable dtodp = dm.SelectQuery(cmd);
								sr2 = cc + "_" + dtodp.Rows.Count + 1;
								cmd = "insert into odproduct values('" + sr2 + "','" + sr + "','" + cc + "','" + dtc.Rows[i][2].ToString() + "','" + dtc.Rows[i][3].ToString() + "','" + tp.ToString() + "','" + discount.ToString() + "')";
								if (dm.ExInsertUpdateorDelete(cmd))
								{
									cmd = "update product set TStock=TStock-'" + int.Parse(dtc.Rows[i]["Quantity"].ToString()) + "' where PID='" + dtp.Rows[0][0].ToString() + "'";
									dm.ExInsertUpdateorDelete(cmd);
								}
							}
							sub = "Order Placed Successfully";
							msg = "Your order was placed successfully at " + DateTime.Now.ToString() + ".<br>Your Order No : <b>" + sr + "</b><br>Track Your Order <a href='Track_Your_Order?=" + em.EncryptMyData(sr.ToString()) + "'>Here</a><br><br><h4 style='text-align:right;'>Team BooksMahal</h4>";
							mm.SendMail(cc, sub, msg);
							Session["orderplaced"] = sr.ToString();
							cmd = "delete from cart where CID='" + cc + "'";
							dm.ExInsertUpdateorDelete(cmd);
							cmd = "update customer set TOrder=TOrder+1 where CID='" + cc + "'";
							dm.ExInsertUpdateorDelete(cmd);
							Response.Redirect("Order_Placed_Successfully");
						}
						else
						{
							Response.Redirect("CheckOut?info=" + em.EncryptMyData("QueryNotSubmitted") + "");
						}
					}
				}
				else
				{
					Response.Redirect("CheckOut?info=" + em.EncryptMyData("CanNotDeliverInThisArea") + "");
				}
			}
		}
	}

	protected void nlbtn_Click(object sender, EventArgs e)
	{
		if (nltxt.Text != "")
		{
			cmd = "select * from newsletter where EmailID='" + nltxt.Text.ToLower().ToString() + "'";
			DataTable dt = dm.SelectQuery(cmd);
			if (dt.Rows.Count > 0)
			{
				Response.Redirect("CheckOut?info=" + em.EncryptMyData("AlreadyRegistered") + "");
			}
			else
			{
				sub = "Subscribed for Newsletter at BooksMahal.com";
				msg = "Hi there,<br/>Now, You will receive exclusive offers and many more from BooksMahal.com.";
				if (mm.SendMail(nltxt.Text.ToLower().ToString(), sub, msg))
				{
					cmd = "insert into newsletter values('" + nltxt.Text.ToLower().ToString() + "')";
					if (dm.ExInsertUpdateorDelete(cmd))
					{
						Response.Redirect("CheckOut?info=" + em.EncryptMyData("SuccessfullForNewsletter") + "");
					}
					else
					{
						Response.Redirect("CheckOut?info=" + em.EncryptMyData("QueryNotSubmitted") + "");
					}
				}
				else
				{
					Response.Redirect("CheckOut?info=" + em.EncryptMyData("QueryNotSubmitted") + "");
				}
			}
		}
		else
		{
			Response.Redirect("CheckOut?info=" + em.EncryptMyData("MustEnterYourEmail") + "");
		}
	}
}