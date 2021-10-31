using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class _Default : System.Web.UI.Page
{
	string cmd, cc, st, info, sub, msg;
	int i;
	DBManager dm = new DBManager();
	EncryptionDecryption em = new EncryptionDecryption();
	SMSSender ss = new SMSSender();
	GenCaptcha gc = new GenCaptcha();
	MyMail mm = new MyMail();
	protected void Page_Load(object sender, EventArgs e)
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
			cc = Request.Cookies["cid"].Value;
			cmd = "select * from customer where CID='" + Request.Cookies["cid"].Value.ToString() + "'";
			DataTable dtcuscheck = dm.SelectQuery(cmd);
			if (dtcuscheck.Rows.Count > 0)
			{
				showbtn.Text = "signoutbtn";
				cmd = "select * from cart where CID='" + cc + "'";
				DataTable dtcc = dm.SelectQuery(cmd);
				addeditems.Text = dtcc.Rows.Count.ToString();
				if (info == "AlreadyAddedThisProduct")
				{
					informer.Text = "AlreadyAddedThisProduct";
					alerttext.Text = "This Book is already added into your cart.";
				}
				else if (info == "ProductAddedintoCart")
				{
					informer.Text = "ProductAddedintoCart";
					alerttext.Text = "Added into cart.<br/><a href='Shop' class='btn btn-info addtocart close-alert-box'>Continue to Shop</a>";
				}
				else if (info == "CouldnotAddthisProduct")
				{
					informer.Text = "CouldnotAddthisProduct";
					alerttext.Text = "Something went wrong, Please try again.";
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


				if (Session["signout"] != null)
				{
					Session["signout"] = null;
					Response.Redirect("User_Zone");
				}
				
			}
			else
				showbtn.Text = "signinbtn";
		}

		st = "NEW";
		cmd = "select * from product where State='" + st + "'";
		DataTable dtnp = dm.SelectQuery(cmd);
		if (dtnp.Rows.Count > 0)
		{
			for (i = 0; i < dtnp.Rows.Count; i++)
			{
				if (i < 8)
					newproph.Controls.Add(new Literal { Text = "<div class='col-lg-3 col-md-4 col-sm-6'><br /><div class='product-googles-info googles'><div class='men-pro-item'><div class='men-thumb-item'><img src='ProductPicture/" + dtnp.Rows[i][10].ToString() + "' class='img-fluid' alt='&ensp;Product Image' style='height:200px;width:150px;'/><div class='men-cart-pro'><div class='inner-men-cart-pro'><a href='Single?for=" + em.EncryptMyData(dtnp.Rows[i][0].ToString()) + "' class='link-product-add-cart'>Quick View</a></div></div><span class='product-new-top'>New</span></div><div class='item-info-product' style='padding-top:10px;'><a class='proname' href='Single?for=" + em.EncryptMyData(dtnp.Rows[i][0].ToString()) + "'>" + dtnp.Rows[i][1].ToString() + "</a><br /><span class='money'><b>Rs. " + dtnp.Rows[i][4].ToString() + "</b></span>&ensp;<span style='text-decoration:line-through;'>Rs. " + dtnp.Rows[i][5].ToString() + "</span>&ensp;<span class='money'><b>" + dtnp.Rows[i][6].ToString() + "% OFF</b></span><br /><a href='Cart?add=" + em.EncryptMyData(dtnp.Rows[i][0].ToString()) + "' class='btn btn-info addtocart click-on'><i class='fa fa-cart-plus'></i>&ensp;ADD TO CART</a></div></div></div></div>" });
			}
		}
		st = "FEATURED";
		cmd = "select * from product where State='" + st + "'";
		DataTable dtfp = dm.SelectQuery(cmd);
		if (dtfp.Rows.Count > 0)
		{
			for (i = 0; i < dtfp.Rows.Count; i++)
			{
				fproph.Controls.Add(new Literal { Text = "<div class='item'><div class='gd-box-info text-center'><div class='product-men women_two bot-gd'><div class='product-googles-info goggles slide-img'><div class='men-pro-item'><div class='men-thumb-item'><center><img src='ProductPicture/" + dtfp.Rows[i][10].ToString() + "' class='img-fluid' alt='&ensp;Product Image' style='height:200px;width:150px;'/></center><div class='men-cart-pro'><div class='inner-men-cart-pro'><a href='Single?for=" + em.EncryptMyData(dtfp.Rows[i][0].ToString()) + "' class='link-product-add-cart'>Quick View</a></div></div><span class='product-new-top'>New</span></div><div class='item-info-product'><br><a class='proname' href='Single?for=" + em.EncryptMyData(dtfp.Rows[i][0].ToString()) + "'>" + dtfp.Rows[i][1].ToString() + "</a><br /><br /><span class='money'><b>Rs. " + dtfp.Rows[i][4].ToString() + "</b></span>&emsp;<span style='text-decoration:line-through;'>Rs. " + dtfp.Rows[i][5].ToString() + "</span><br /><span class='money'><b>" + dtfp.Rows[i][6].ToString() + "% OFF</b></span></div></div></div></div></div></div>" });
			}
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

	protected void nlbtn_Click(object sender, EventArgs e)
	{
		if (nltxt.Text != "")
		{
			cmd = "select * from newsletter where EmailID='" + nltxt.Text.ToLower().ToString() + "'";
			DataTable dt = dm.SelectQuery(cmd);
			if (dt.Rows.Count > 0)
			{
				Response.Redirect("Home?info=" + em.EncryptMyData("AlreadyRegistered") + "");
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
						Response.Redirect("Home?info=" + em.EncryptMyData("SuccessfullForNewsletter") + "");
					}
					else
					{
						Response.Redirect("Home?info=" + em.EncryptMyData("QueryNotSubmitted") + "");
					}
				}
				else
				{
					Response.Redirect("Home?info=" + em.EncryptMyData("QueryNotSubmitted") + "");
				}
			}
		}
		else
		{
			Response.Redirect("Home?info=" + em.EncryptMyData("MustEnterYourEmail") + "");
		}
	}
}