using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class TrackOrder : System.Web.UI.Page
{
	string cmd, cc, info, sub, msg, sss;
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
			}
			else
				showbtn.Text = "signinbtn";
		}

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
		else if (info == "CanNotBlack")
		{
			informer.Text = "CanNotBlack";
			alerttext.Text = "Please enter Order ID.";
		}
		else if (info == "EnterCorrectOID")
		{
			informer.Text = "EnterCorrectOID";
			alerttext.Text = "Invalid Order ID.";
		}


		if (Session["torder"] != null)
		{
			sss = Session["torder"].ToString();
			if (sss == "NEW")
			{
				showdiv.Text = "NEW";
			}
			else if (sss == "ACCEPTED")
			{
				showdiv.Text = "ACCEPTED";
			}
			else if (sss == "DELIVERED")
			{
				showdiv.Text = "DELIVERED";
			}
			else if (sss == "REJECTED")
			{
				showdiv.Text = "REJECTED";
			}
			Session["torder"] = null;
		}
		else
			showdiv.Text = "NOTHING";

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

	protected void trackbtn_Click(object sender, EventArgs e)
	{
		if (oidtxt.Text == "")
		{
			Response.Redirect("Track_Your_Order?info=" + em.EncryptMyData("CanNotBlack") + "");
		}
		else
		{
			cmd = "select * from orders where OID='" + oidtxt.Text.ToString() + "'";
			DataTable dto = dm.SelectQuery(cmd);
			if (dto.Rows.Count > 0)
			{
				if (dto.Rows[0]["OrderStatus"].ToString() == "NEW")
				{
					Session["torder"] = dto.Rows[0]["OrderStatus"].ToString();
					Response.Redirect("Track_Your_Order");
				}
				else if (dto.Rows[0]["OrderStatus"].ToString() == "ACCEPTED")
				{
					Session["torder"] = dto.Rows[0]["OrderStatus"].ToString();
					Response.Redirect("Track_Your_Order");
				}
				else if (dto.Rows[0]["OrderStatus"].ToString() == "DELIVERED")
				{
					Session["torder"] = dto.Rows[0]["OrderStatus"].ToString();
					Response.Redirect("Track_Your_Order");
				}
				else if (dto.Rows[0]["OrderStatus"].ToString() == "REJECTED")
				{
					Session["torder"] = dto.Rows[0]["OrderStatus"].ToString();
					Response.Redirect("Track_Your_Order");
				}
			}
			else
			{
				Response.Redirect("Track_Your_Order?info=" + em.EncryptMyData("EnterCorrectOID") + "");
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
				Response.Redirect("Track_Your_Order?info=" + em.EncryptMyData("AlreadyRegistered") + "");
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
						Response.Redirect("Track_Your_Order?info=" + em.EncryptMyData("SuccessfullForNewsletter") + "");
					}
					else
					{
						Response.Redirect("Track_Your_Order?info=" + em.EncryptMyData("QueryNotSubmitted") + "");
					}
				}
				else
				{
					Response.Redirect("Track_Your_Order?info=" + em.EncryptMyData("QueryNotSubmitted") + "");
				}
			}
		}
		else
		{
			Response.Redirect("Track_Your_Order?info=" + em.EncryptMyData("MustEnterYourEmail") + "");
		}
	}
}