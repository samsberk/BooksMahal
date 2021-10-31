using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Shop : System.Web.UI.Page
{
	string cmd, sub, msg, cc, st, data, info;
	int i;
	DBManager dm = new DBManager();
	EncryptionDecryption em = new EncryptionDecryption();
	SMSSender ss = new SMSSender();
	GenCaptcha gc = new GenCaptcha();
	MyMail mm = new MyMail();
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Request.Cookies["cid"] == null)
		{
			cc = "None";
			showbtn.Text = "signinbtn";
		}
		else
		{
			cc = Request.Cookies["cid"].Value;
			cmd = "select * from cart where CID='" + cc + "'";
			DataTable dtcc = dm.SelectQuery(cmd);
			addeditems.Text = dtcc.Rows.Count.ToString();
			showbtn.Text = "signoutbtn";
		}

		if (Request.QueryString["info"] == null)
			info = "None";
		else
			info = em.DecryptMyData(Request.QueryString["info"]);

		if (info == "AlreadyRegistered")
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

		if (Request.QueryString["for"] == null)
			data = "None";
		else
			data = Request.QueryString["for"];

		if (data == "None")
		{
			cmd = "select * from category";
			DataTable dtcat = dm.SelectQuery(cmd);
			if (dtcat.Rows.Count > 0)
			{
				for (i = 0; i < dtcat.Rows.Count; i++)
				{
					st = dtcat.Rows[i]["CategoryName"].ToString();
					cmd = "select * from product where Category='" + st + "'";
					DataTable dtfp = dm.SelectQuery(cmd);
					if (dtfp.Rows.Count > 0)
					{
						catwiseph.Controls.Add(new Literal { Text = "<h3 class='tittle-w3layouts my-lg-4 my-4'>&ensp;" + st + "</h3><div class='col-lg-12 col-sm-3'><div class='slider-img mid-sec'><div class='mid-slider'><div class='owl-carousel owl-theme row'>" });
						for (i = 0; i < dtfp.Rows.Count; i++)
						{
							if (i < 4)
								catwiseph.Controls.Add(new Literal { Text = "<div class='item'><div class='gd-box-info text-center'><div class='product-men women_two bot-gd'><div class='product-googles-info goggles slide-img'><div class='men-pro-item'><div class='men-thumb-item'><center><img src='ProductPicture/" + dtfp.Rows[i][10].ToString() + "' class='img-fluid' alt='&ensp;Product Image' style='width:60%;'/></center><div class='men-cart-pro'><div class='inner-men-cart-pro'><a href='Single?for=" + em.EncryptMyData(dtfp.Rows[i][0].ToString()) + "' class='link-product-add-cart'>Quick View</a></div></div><span class='product-new-top'>New</span></div><div class='item-info-product'><a class='proname' href='Single?for=" + em.EncryptMyData(dtfp.Rows[i][0].ToString()) + "'>" + dtfp.Rows[i][1].ToString() + "</a><br /><span class='money'><b>Rs. " + dtfp.Rows[i][4].ToString() + "</b></span>&emsp;<span style='text-decoration:line-through;'>Rs. " + dtfp.Rows[i][5].ToString() + "</span><br /><span class='money'><b>" + dtfp.Rows[i][6].ToString() + "% OFF</b></span></div></div></div></div></div></div>" });
						}
						catwiseph.Controls.Add(new Literal { Text = "</div></div></div><div class='row'><div class='col-sm-3'></div><div class='col-sm-6'><a href='Shop?for=" + st + "' class='btn btn-warning btn-block' style='margin-top:10px;'>View More</a></div><div class='col-sm-3'></div></div><hr /></div>" });
					}
				}
			}
		}
		else
		{
			cmd = "select * from category where CategoryName='" + data + "'";
			DataTable dtcat = dm.SelectQuery(cmd);
			if (dtcat.Rows.Count > 0)
			{
				for (i = 0; i < dtcat.Rows.Count; i++)
				{
					st = dtcat.Rows[i]["CategoryName"].ToString();
					cmd = "select * from product where Category='" + st + "'";
					DataTable dtfp = dm.SelectQuery(cmd);
					if (dtfp.Rows.Count > 0)
					{
						catwiseph.Controls.Add(new Literal { Text = "<h3 class='tittle-w3layouts col-lg-12 my-4'>&ensp;" + st + "</h3>" });
						for (i = 0; i < dtfp.Rows.Count; i++)
						{
							catwiseph.Controls.Add(new Literal { Text = "<div class='col-lg-3 col-md-4 col-sm-6'><br /><div class='product-googles-info googles'><div class='men-pro-item'><div class='men-thumb-item'><img src='ProductPicture/" + dtfp.Rows[i][10].ToString() + "' class='img-fluid' alt='&ensp;Product Image' style='height:200px;width:150px;'/><div class='men-cart-pro'><div class='inner-men-cart-pro'><a href='Single?for=" + em.EncryptMyData(dtfp.Rows[i][0].ToString()) + "' class='link-product-add-cart'>Quick View</a></div></div></div><div class='item-info-product' style='padding-top:10px;'><a class='proname' href='Single?for=" + em.EncryptMyData(dtfp.Rows[i][0].ToString()) + "'>" + dtfp.Rows[i][1].ToString() + "</a><br /><span class='money'><b>Rs. " + dtfp.Rows[i][4].ToString() + "</b></span>&ensp;<span style='text-decoration:line-through;'>Rs. " + dtfp.Rows[i][5].ToString() + "</span>&ensp;<span class='money'><b>" + dtfp.Rows[i][6].ToString() + "% OFF</b></span><br /><a href='Cart?add=" + em.EncryptMyData(dtfp.Rows[i][0].ToString()) + "' class='btn btn-info addtocart'><i class='fa fa-cart-plus'></i>&ensp;ADD TO CART</a></div></div></div></div>" });
						}
					}
					else
					{
						catwiseph.Controls.Add(new Literal { Text = "<h3 class='tittle-w3layouts col-lg-12 my-4'>&ensp;" + st + "</h3><br>" });
						catwiseph.Controls.Add(new Literal { Text = "<div class='col-sm-3'></div><div class='col-sm-6 text-center'><i class='fa fa-exclamation-circle' style='font-size:150px;color:brown;'></i><br /><br /><h3>Books Not Found</h3><br /><a href='Shop' class='btn btn-info'>Continue Shopping</a><br /><br /></div><div class='col-sm-3'></div>" });
					}
				}
			}
			else
			{
				cmd = "select * from product where PID='" + data + "'";
				DataTable dtp = dm.SelectQuery(cmd);
				if (dtp.Rows.Count > 0)
				{
					catwiseph.Controls.Add(new Literal { Text = "<h3 class='tittle-w3layouts col-lg-12 my-4'>&ensp;" + dtp.Rows[0]["Category"].ToString() + "</h3>" });
					catwiseph.Controls.Add(new Literal { Text = "<div class='col-lg-3 col-md-4 col-sm-6'><br /><div class='product-googles-info googles'><div class='men-pro-item'><div class='men-thumb-item'><img src='ProductPicture/" + dtp.Rows[i][10].ToString() + "' class='img-fluid' alt='&ensp;Product Image' style='height:200px;width:150px;'/><div class='men-cart-pro'><div class='inner-men-cart-pro'><a href='Single?for=" + em.EncryptMyData(dtp.Rows[i][0].ToString()) + "' class='link-product-add-cart'>Quick View</a></div></div></div><div class='item-info-product' style='padding-top:10px;'><a class='proname' href='Single?for=" + em.EncryptMyData(dtp.Rows[i][0].ToString()) + "'>" + dtp.Rows[i][1].ToString() + "</a><br /><span class='money'><b>Rs. " + dtp.Rows[i][4].ToString() + "</b></span>&ensp;<span style='text-decoration:line-through;'>Rs. " + dtp.Rows[i][5].ToString() + "</span>&ensp;<span class='money'><b>" + dtp.Rows[i][6].ToString() + "% OFF</b></span><br /><a href='Cart?add=" + em.EncryptMyData(dtp.Rows[i][0].ToString()) + "' class='btn btn-info addtocart'><i class='fa fa-cart-plus'></i>&ensp;ADD TO CART</a></div></div></div></div>" });
				}
				else
				{
					catwiseph.Controls.Add(new Literal { Text = "<div class='col-sm-3'></div><div class='col-sm-6 text-center'><i class='fa fa-exclamation-circle' style='font-size:150px;color:brown;'></i><br /><br /><h3>Books Not Found</h3><br /><a href='Shop' class='btn btn-info'>Find Here</a><br /><br /></div><div class='col-sm-3'></div>" });
				}
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
		st = "FEATURED";
		cmd = "select * from product where State='" + st + "'";
		DataTable dtfpf = dm.SelectQuery(cmd);
		if (dtfpf.Rows.Count > 0)
		{
			for (i = 0; i < dtfpf.Rows.Count; i++)
			{
				fproph.Controls.Add(new Literal { Text = "<div class='item'><div class='gd-box-info text-center'><div class='product-men women_two bot-gd'><div class='product-googles-info goggles slide-img'><div class='men-pro-item'><div class='men-thumb-item'><center><img src='ProductPicture/" + dtfpf.Rows[i][10].ToString() + "' class='img-fluid' alt='&ensp;Product Image' style='height:200px;width:150px;'/></center><div class='men-cart-pro'><div class='inner-men-cart-pro'><a href='Single?for=" + em.EncryptMyData(dtfpf.Rows[i][0].ToString()) + "' class='link-product-add-cart'>Quick View</a></div></div><span class='product-new-top'>New</span></div><div class='item-info-product'><br><a class='proname' href='Single?for=" + em.EncryptMyData(dtfpf.Rows[i][0].ToString()) + "'>" + dtfpf.Rows[i][1].ToString() + "</a><br /><br /><span class='money'><b>Rs. " + dtfpf.Rows[i][4].ToString() + "</b></span>&emsp;<span style='text-decoration:line-through;'>Rs. " + dtfpf.Rows[i][5].ToString() + "</span><br /><span class='money'><b>" + dtfpf.Rows[i][6].ToString() + "% OFF</b></span></div></div></div></div></div></div>" });
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
				Response.Redirect("Shop?info=" + em.EncryptMyData("AlreadyRegistered") + "");
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
						Response.Redirect("Shop?info=" + em.EncryptMyData("SuccessfullForNewsletter") + "");
					}
					else
					{
						Response.Redirect("Shop?info=" + em.EncryptMyData("QueryNotSubmitted") + "");
					}
				}
				else
				{
					Response.Redirect("Shop?info=" + em.EncryptMyData("QueryNotSubmitted") + "");
				}
			}
		}
		else
		{
			Response.Redirect("Shop?info=" + em.EncryptMyData("MustEnterYourEmail") + "");
		}
	}
}
