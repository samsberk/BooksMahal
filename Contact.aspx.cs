using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Contact : System.Web.UI.Page
{
	string cmd, info, cc;
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

		if (info == "AlreadyAddedThisProduct")
		{
			informer.Text = "AlreadyAddedThisProduct";
			alerttext.Text = "This Book is already added into your cart.";
		}
		else if (info == "ProductAddedintoCart")
		{
			informer.Text = "ProductAddedintoCart";
			alerttext.Text = "Added into cart.<br/><a href='Cart' class='btn btn-info addtocart close-alert-box'>Go to Cart</a>";
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
		else if (info == "QueryNotSubmitted")
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
		else if (info == "SuccessfullySendYourMessage")
		{
			informer.Text = "SuccessfullySendYourMessage";
			alerttext.Text = "Sent";
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
			cmd = "select * from cart where CID='" + cc + "'";
			DataTable dtcc = dm.SelectQuery(cmd);
			addeditems.Text = dtcc.Rows.Count.ToString();
		}
	}
	protected void sendbtn_Click(object sender, EventArgs e)
	{
		if(mm.SendMail("manishprasad66@gmail.com", txtsub.Text.ToString(), txtmsg.Text.ToString()) == true)
		{
			Response.Redirect("Contact?info=" + em.EncryptMyData("SuccessfullySendYourMessage") + "");
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
				Response.Redirect("Contact?info=" + em.EncryptMyData("AlreadyRegistered") + "");
			}
			else
			{
				cmd = "insert into newsletter values('" + nltxt.Text.ToLower().ToString() + "')";
				if (dm.ExInsertUpdateorDelete(cmd))
				{
					Response.Redirect("Contact?info=" + em.EncryptMyData("SuccessfullForNewsletter") + "");
				}
				else
				{
					Response.Redirect("Contact?info=" + em.EncryptMyData("QueryNotSubmitted") + "");
				}
			}
		}
		else
		{
			Response.Redirect("Contact?info=" + em.EncryptMyData("MustEnterYourEmail") + "");
		}
	}
}