using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Single : System.Web.UI.Page
{
	string cmd, st, cc, data, sub, msg, info, sss;
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
			showbtn.Text = "signoutbtn";
			cmd = "select * from cart where CID='" + cc + "'";
			DataTable dtcc = dm.SelectQuery(cmd);
			addeditems.Text = dtcc.Rows.Count.ToString();
		}

		if (Request.QueryString["for"] == null)
			data = "None";
		else
			data = em.DecryptMyData(Request.QueryString["for"]);
		if (Request.QueryString["info"] == null)
			info = "None";
		else
			info = em.DecryptMyData(Request.QueryString["info"]);

		if (Session["rbook"] != null)
			sss = Session["rbook"].ToString();
		else
			sss = "None";

		if (sss == "Requested")
		{
			informer.Text = "RequestedSuccessfully";
			alerttext.Text = "Request Sent for this Book. We will notify you as soon as possible.";
		}
		Session["rbook"] = null;
		

		cmd = "select * from product where PID='" + data + "'";
		DataTable dtup = dm.SelectQuery(cmd);
		if(dtup.Rows.Count>0)
		{
			picph.Controls.Add(new Literal { Text = "<ul class='slides'><li data-thumb='ProductPicture/" + dtup.Rows[0][10].ToString() + "'><div class='thumb-image'> <img src='ProductPicture/" + dtup.Rows[0][10].ToString() + "' data-imagezoom='true' class='img-fluid' style='width:100%;'/> </div></li> <li data-thumb='ProductPicture/" + dtup.Rows[0][11].ToString() + "'><div class='thumb-image'> <img src='ProductPicture/" + dtup.Rows[0][11].ToString() + "' data-imagezoom='true' class='img-fluid' style='width:100%;'/></div></li></ul>" });
			namelbl.Text = dtup.Rows[0][1].ToString();
			sellplbl.Text = "Price : Rs. " + dtup.Rows[0][4].ToString() + ".00";
			strikeplbl.Text = "Actual Price : Rs. " + dtup.Rows[0][5].ToString() + ".00";
			discountlbl.Text = "Discount : " + dtup.Rows[0][6].ToString() + "% OFF";
			tstocklbl.Text = "Items in Stock : " + dtup.Rows[0][3].ToString() + " Nos";
			desclbl.Text = dtup.Rows[0][7].ToString();
			infolbl.Text = dtup.Rows[0][8].ToString();
			if (dtup.Rows[0][3].ToString() == "0")
				shownotebtn.Text = "zero";
			else
				shownotebtn.Text = "notZero";

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

	protected void addcartbtn_Click(object sender, EventArgs e)
	{
		if (Request.QueryString["for"] == null)
			data = "None";
		else
			data = Request.QueryString["for"];

		Response.Redirect("Cart?add=" + data + "");
	}

	protected void checkpinbtn_Click(object sender, EventArgs e)
	{
		informer.Text = "Blank";
		if (pintxt.Text == "")
		{
			checkpinlbl.Text = "<div class='alert alert-warning'>Please enter PIN Code.</div>";
		}
		else
		{
			cmd = "select * from pincode where PIN='" + pintxt.Text.ToString() + "'";
			DataTable dtpin = dm.SelectQuery(cmd);
			if (dtpin.Rows.Count > 0)
			{
				checkpinlbl.Text = "<div class='alert alert-success'>This item is available for this area.</div>";
			}
			else
			{
				checkpinlbl.Text = "<div class='alert alert-danger'>This item is not available for this area.</div>";
			}
		}
	}
	protected void reqbookbtn_Click(object sender, EventArgs e)
	{
		if (Request.Cookies["cid"] == null)
		{
			Response.Redirect("User_Zone?i=" + em.EncryptMyData("SignUpFirst") + "");
		}
		else
		{
			if (Request.QueryString["for"] == null)
				data = "None";
			else
				data = em.DecryptMyData(Request.QueryString["for"]);
			cc = Request.Cookies["cid"].Value;
			cmd = "select * from customer where CID='" + cc + "'";
			DataTable dtc = dm.SelectQuery(cmd);
			if (dtc.Rows.Count > 0)
			{
				sub = "Request for Item";
				msg = "<h3>Product Details -</h3><br>Product ID : " + data + "<br><br><h3>Requested By -<h3>Name : " + dtc.Rows[0]["Name"].ToString() + "<br/>Mobile : " + dtc.Rows[0]["Mobile"].ToString() + "<br>Email ID : " + cc + "";
				mm.SendMail("booksmahal4256@gmail.com", sub, msg);
				Session["rbook"] = "Requested";
				Response.Redirect("Single?for=" + em.EncryptMyData(data) + "");
			}
		}
	}
	protected void nlbtn_Click(object sender, EventArgs e)
	{
		Response.Redirect("Home");
	}
}