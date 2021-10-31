using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Cart : System.Web.UI.Page
{
	string cmd, cc, ab, rb, pq, mq, fo, info, msg, sub, cartid;
	int i;
	DBManager dm = new DBManager();
	EncryptionDecryption em = new EncryptionDecryption();
	SMSSender ss = new SMSSender();
	GenCaptcha gc = new GenCaptcha();
	MyMail mm = new MyMail();
	protected void Page_Load(object sender, EventArgs e)
	{
		/*------------------------------------------------- Check the user Login or not --------------------------------------------------------*/
		if (Request.Cookies["cid"] == null)
		{
			cc = "None";
			Response.Redirect("User_Zone?i=" + em.EncryptMyData("SignUpFirst") + "");
			showbtn.Text = "signinbtn";
		}
		else
		{
			cc = Request.Cookies["cid"].Value;
			cmd = "select * from customer where CID='" + Request.Cookies["cid"].Value.ToString() + "'";
			DataTable dtcuscheck = dm.SelectQuery(cmd);
			if (dtcuscheck.Rows.Count > 0)
			{
				showbtn.Text = "signoutbtn";
				cmd = "select * from cart where CID='" + cc + "'";
				DataTable dtc = dm.SelectQuery(cmd);
				if (dtc.Rows.Count > 0)
				{
					for (i = 0; i < dtc.Rows.Count; i++)
					{
						cmd = "select * from product where PID='" + dtc.Rows[i][2].ToString() + "'";
						DataTable dtp = dm.SelectQuery(cmd);
						if (dtp.Rows.Count > 0)
						{
							if (int.Parse(dtp.Rows[0][3].ToString()) < int.Parse(dtc.Rows[i]["Quantity"].ToString()))
							{
								cmd = "delete from cart where CID='" + cc + "' and PID='" + dtp.Rows[0]["PID"].ToString() + "'";
								dm.ExInsertUpdateorDelete(cmd);
							}
							else
								cartph.Controls.Add(new Literal { Text = "<tr><td><a href='Single?data=" + dtc.Rows[i][2].ToString() + "' class='links click-on'><img src='ProductPicture/" + dtp.Rows[0][10].ToString() + "' style='height:100px;width:70px;' /></a></td><td><a href='Single?data=" + dtc.Rows[i][2].ToString() + "' class='links click-on'>" + dtp.Rows[0][1].ToString() + "</a></td><td><a href='Cart?mquan=" + em.EncryptMyData("MinusOne") + "&fo=" + em.EncryptMyData(dtc.Rows[i][2].ToString()) + "' class='btn btn-warning btn-design click-on' style='margin-bottom:10px;'><i class='fa fa-minus'></i></a><h4 style='border:0.5px solid lightgray;'>" + dtc.Rows[i][3].ToString() + "</h4><a href='Cart?pquan=" + em.EncryptMyData("AddOne") + "&fo=" + em.EncryptMyData(dtc.Rows[i][2].ToString()) + "' class='btn btn-success btn-design click-on'><i class='fa fa-plus'></i></a></td><td>Rs." + dtp.Rows[0][4].ToString() + "*" + dtc.Rows[i][3].ToString() + "</td><td><a href='Cart?remove=" + em.EncryptMyData(dtp.Rows[0][0].ToString()) + "' class='btn btn-danger btn-design click-on'><i class='fa fa-times'></i></a></td></tr>" });
						}
					}
				}
				else
				{
					showdiv.Text = "HideThisDiv";
					cartph.Controls.Add(new Literal { Text = "<tr><td colspan='5'>Your Cart is Empty.<br><a href='Shop' class='btn btn-info btn-design'>Add Books</a></td></tr>" });
					showcheck.Text = "empty";
				}
				addeditems.Text = i.ToString();
				/*------------------------------------------------- Query Strings --------------------------------------------------------*/
				/*------ check Information cart -------------*/
				if (Request.QueryString["info"] == null)
					info = "None";
				else
					info = em.DecryptMyData(Request.QueryString["info"]);
				/*------ Add into cart -------------*/
				if (Request.QueryString["add"] == null)
					ab = "None";
				else
				{
					ab = em.DecryptMyData(Request.QueryString["add"]);
					cmd = "select * from cart where PID='" + ab + "' and CID='" + cc + "'";
					DataTable dtadd = dm.SelectQuery(cmd);
					if (dtadd.Rows.Count > 0)
					{
						Response.Redirect("Cart?info=" + em.EncryptMyData("AlreadyAddedThisProduct") + "");
					}
					else
					{
						cmd = "select * from product where PID='" + ab + "'";
						DataTable dtpplus = dm.SelectQuery(cmd);
						if (dtpplus.Rows.Count > 0)
						{
							if (int.Parse(dtpplus.Rows[0][3].ToString()) == 0)
							{
								Response.Redirect("Cart?info=" + em.EncryptMyData("OutOfStock") + "");
							}
							else
							{
								cmd = "select * from cart where CID='" + cc + "'";
								DataTable dttc = dm.SelectQuery(cmd);
								cartid = cc + "_" + ab;
								i = 1;
								cmd = "insert into cart values('" + cartid + "','" + cc + "','" + ab + "','" + i.ToString() + "')";
								if (dm.ExInsertUpdateorDelete(cmd))
									navitem.Text = "<script>window.location.href = 'Cart?info=" + em.EncryptMyData("ProductAddedintoCart") + "'</script>";
								else
									navitem.Text = "<script>window.location.href = 'Cart?info=" + em.EncryptMyData("CouldnotAddthisProduct") + "'</script>";
							}
						}
					}
				}

				/*------ Remove from cart -------------*/
				if (Request.QueryString["remove"] == null)
					rb = "None";
				else
				{
					rb = em.DecryptMyData(Request.QueryString["remove"]);
					cmd = "delete from cart where CID='" + cc + "' and PID='" + rb + "'";
					dm.ExInsertUpdateorDelete(cmd);
					Response.Redirect("Cart");
				}
				/*------ Plus quantity -------------*/
				if (Request.QueryString["pquan"] == null)
					pq = "None";
				else
				{
					pq = em.DecryptMyData(Request.QueryString["pquan"]);
				}
				/*------ Minus quantity -----------*/
				if (Request.QueryString["mquan"] == null)
					mq = "None";
				else
				{
					mq = em.DecryptMyData(Request.QueryString["mquan"]);
				}
				/*------ Plus Minus Operation -----------*/
				if (Request.QueryString["fo"] == null)
					fo = "None";
				else
				{
					fo = em.DecryptMyData(Request.QueryString["fo"]);
					cmd = "select * from cart where CID='" + cc + "' and PID='" + fo + "'";
					DataTable dtc2 = dm.SelectQuery(cmd);
					int quan;
					if (dtc2.Rows.Count > 0)
						quan = int.Parse(dtc2.Rows[0][3].ToString());
					else
						quan = 0;
					if (pq == "AddOne")
					{
						cmd = "select * from product where PID='" + fo + "'";
						DataTable dtpplus = dm.SelectQuery(cmd);
						if (dtpplus.Rows.Count > 0)
						{
							if (int.Parse(dtpplus.Rows[0][3].ToString()) > quan)
							{
								quan++;
								cmd = "update cart set Quantity='" + quan.ToString() + "' where CID='" + cc + "' and PID='" + fo + "'";
								dm.ExInsertUpdateorDelete(cmd);
								Response.Redirect("Cart");
							}
							else
							{
								Response.Redirect("Cart?info=" + em.EncryptMyData("LimitedStock") + "");
							}
						}
					}
					else if (mq == "MinusOne")
					{
						if (quan == 1)
						{
							Response.Redirect("Cart?info=" + em.EncryptMyData("ItIsMinimumNumberofQuantity") + "");
						}
						else
						{
							quan--;
							cmd = "update cart set Quantity='" + quan.ToString() + "' where CID='" + cc + "' and PID='" + fo + "'";
							dm.ExInsertUpdateorDelete(cmd);
							Response.Redirect("Cart");
						}
					}
				}
				/*------ Set Alert -----------*/
				if (info == "ItIsMinimumNumberofQuantity")
				{
					informer.Text = "ItIsMinimumNumberofQuantity";
					alerttext.Text = "The Quantity of this product is already 1.";
				}
				else if (info == "AlreadyRegistered")
				{
					informer.Text = "AlreadyRegistered";
					alerttext.Text = "This Email is already Subscribe for Newsletter.";
				}
				else if (info == "SuccessfullForNewsletter")
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
				else if (info == "LimitedStock")
				{
					informer.Text = "LimitedStock";
					alerttext.Text = "Could not increase quantity, Because there are no more items available in stock.";
				}
				else if (info == "OutOfStock")
				{
					informer.Text = "OutOfStock";
					alerttext.Text = "Could not add this product, Because there are no more items available in stock.";
				}
				else if (info == "AlreadyAddedThisProduct")
				{
					informer.Text = "AlreadyAddedThisProduct";
					alerttext.Text = "This Book is already added into your cart.";
				}
				else if (info == "ProductAddedintoCart")
				{
					informer.Text = "ProductAddedintoCart";
					alerttext.Text = "Added into cart.<br/><br/><a href='Shop' class='btn btn-info addtocart close-alert-box'>Continue to Shop</a>";
				}
				else if (info == "CouldnotAddthisProduct")
				{
					informer.Text = "CouldnotAddthisProduct";
					alerttext.Text = "Something went wrong, Please try again.";
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

			}
			else
				Response.Redirect("User_Zone?i=" + em.EncryptMyData("SignUpFirst") + "");
			
		}

		
	}

	protected void checkoutbtn_Click(object sender, EventArgs e)
	{
		Session["checkout"] = cc;
		Response.Redirect("CheckOut");
	}

	protected void nlbtn_Click(object sender, EventArgs e)
	{
		if (nltxt.Text != "")
		{
			cmd = "select * from newsletter where EmailID='" + nltxt.Text.ToLower().ToString() + "'";
			DataTable dt = dm.SelectQuery(cmd);
			if (dt.Rows.Count > 0)
			{
				Response.Redirect("Cart?info=" + em.EncryptMyData("AlreadyRegistered") + "");
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
						Response.Redirect("Cart?info=" + em.EncryptMyData("SuccessfullForNewsletter") + "");
					}
					else
					{
						Response.Redirect("Cart?info=" + em.EncryptMyData("QueryNotSubmitted") + "");
					}
				}
				else
				{
					Response.Redirect("Cart?info=" + em.EncryptMyData("QueryNotSubmitted") + "");
				}
			}
		}
		else
		{
			Response.Redirect("Cart?info=" + em.EncryptMyData("MustEnterYourEmail") + "");
		}
	}
}