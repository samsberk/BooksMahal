using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class SignUp : System.Web.UI.Page
{
	string cmd, sub, msg, otp, st="NOT VERIFIED", info;
	string f , i, el, redirecturl;
	int j;
	DBManager dm = new DBManager();
	EncryptionDecryption em = new EncryptionDecryption();
	GenCaptcha gc = new GenCaptcha();
	MyMail mm = new MyMail();
	SMSSender ss = new SMSSender();
	protected void Page_Load(object sender, EventArgs e)
	{
		Session["checkout"] = null;
		if (Request.Cookies["cid"] == null)
		{
			if (Request.QueryString["info"] == null)
				info = "None";
			else
				info = em.DecryptMyData(Request.QueryString["info"]);

			if (Request.QueryString["f"] == null)
				f = "Sign_In";
			else
				f = Request.QueryString["f"];

			if (Request.QueryString["i"] == null)
				i = "Default";
			else
				i = em.DecryptMyData(Request.QueryString["i"]);

			if (Request.QueryString["el"] == null)
				el = "None";
			else
				el = Request.QueryString["el"];

			if (Request.QueryString["redirecturl"] == null)
				redirecturl = "None";
			else
				redirecturl = em.DecryptMyData(Request.QueryString["redirecturl"]);


			if (Session["signout"] != null)
			{
				Session["signout"] = null;
				informer.Text = "loggedout";
				alerttext.Text = "Logged Out";
			}



			if (f == "Sign_Up")
			{
				show.Text = "0";
				st = "NOT VERIFIED";
				cmd = "delete from customer where AStatus='" + st + "'";
				dm.ExInsertUpdateorDelete((cmd));
			}
			else if (f == "Sign_In")
				show.Text = "1";
			else if (f == "2")
			{
				st = "NOT VERIFIED";
				cmd = "select * from customer where CID='" + el + "' and  AStatus='" + st + "'";
				DataTable dfnf = dm.SelectQuery(cmd);
				if (dfnf.Rows.Count > 0)
					show.Text = "2";
				else
					Response.Redirect("User_Zone?i=" + em.EncryptMyData("InvalidAccess") + "&f=Sign_Up");
			}
			else if (f == "3")
			{
				st = "VERIFIED BNF";
				cmd = "select * from customer where CID='" + el + "'";
				DataTable dfnf = dm.SelectQuery(cmd);
				if (dfnf.Rows.Count > 0)
					show.Text = "3";
				else
					Response.Redirect("User_Zone?i=" + em.EncryptMyData("InvalidAccess") + "&f=Sign_Up");
			}
			else if (f == "Forgot_Password")
				show.Text = "4";
			else if (f == "5")
			{
				cmd = "select * from customer where CID='" + el + "'";
				DataTable dfnf = dm.SelectQuery(cmd);
				if (dfnf.Rows.Count > 0)
					show.Text = "5";
				else
					Response.Redirect("User_Zone?i=" + em.EncryptMyData("InvalidAccess") + "&f=Forgot_Password");
			}
			else if (f == "6")
			{
				if (Session["cid"] != null)
				{
					show.Text = "6";
				}
				else
					Response.Redirect("User_Zone?i=" + em.EncryptMyData("InvalidAccess") + "&f=Forgot_Password");
			}

			if (i == "AlreadyRegistered")
			{
				informer.Text = "AlreadyRegistered";
				alerttext.Text = "This Email ID is <b>Already Registered</b>.<br/>You can Login <a href='User_Zone?f=Sign_In'>Here</a>";
			}
			else if (i == "QueryNotSubmitted")
			{
				informer.Text = "QueryNotSubmitted";
				alerttext.Text = "Something went wrong, please try again. Thank You.";
			}
			else if (i == "InvalidEmailid")
			{
				informer.Text = "InvalidEmailid";
				alerttext.Text = "<b>Invalid Email ID</b>, Please enter valid Email ID. Thank You";
			}
			else if (i == "InvalidOTP")
			{
				informer.Text = "InvalidOTP";
				alerttext.Text = "<b>Invalid OTP</b>, Please try again.<br/>Check <b>SPAM</b> folder if OTP is not present in <b>INBOX</b>.";
			}
			else if (i == "InvalidAccess")
			{
				informer.Text = "InvalidAccess";
				alerttext.Text = "You can not access Requested Page.";
			}
			else if (i == "InvalidUseridorPassword")
			{
				informer.Text = "InvalidUseridorPassword";
				alerttext.Text = "<b>Invalid Email ID or Password.</b><br/>If you don't have <b>BooksMahal Account</b>, Then you can create <a href='User_Zone?f=Sign_Up'>Here</a>.<br>You can also Reset your Password <a href='User_Zone?f=Forgot_Password'>Here</a>.";
			}
			else if (i == "VerifiedButNotFilled")
			{
				informer.Text = "VerifiedButNotFilled";
				alerttext.Text = "Fill this form to continue to BooksMahal.com";
			}
			else if (i == "PasswordChanged")
			{
				informer.Text = "PasswordChanged";
				alerttext.Text = "Password Changed.";
			}
			else if (i == "SignUpFirst")
			{
				informer.Text = "SignUpFirst";
				alerttext.Text = "Please Sign In fisrt.";
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


			cmd = "select * from product";
			DataTable dtpa = dm.SelectQuery(cmd);
			if (dtpa.Rows.Count > 0)
			{
				for (j = 0; j < dtpa.Rows.Count; j++)
				{
					keywordph.Controls.Add(new Literal { Text = "<li><a href='Shop?for=" + dtpa.Rows[j]["PID"].ToString() + "'>" + dtpa.Rows[j]["PName"].ToString() + "</a></li>" });
				}
			}
			cmd = "select * from category";
			DataTable dtca = dm.SelectQuery(cmd);
			if (dtca.Rows.Count > 0)
			{
				for (j = 0; j < dtca.Rows.Count; j++)
				{
					keywordph.Controls.Add(new Literal { Text = "<li><a href='Shop?for=" + dtca.Rows[j][0].ToString() + "'>" + dtca.Rows[j][0].ToString() + "</a></li>" });
				}
			}
		}
		else
		{
			cmd = "select * from customer where CID='" + Request.Cookies["cid"].Value.ToString() + "'";
			DataTable dtcuscheck = dm.SelectQuery(cmd);
			if (dtcuscheck.Rows.Count > 0)
			{
				Response.Redirect("Home");
			}
			else
			{
				if (Request.QueryString["info"] == null)
					info = "None";
				else
					info = em.DecryptMyData(Request.QueryString["info"]);

				if (Request.QueryString["f"] == null)
					f = "Sign_In";
				else
					f = Request.QueryString["f"];

				if (Request.QueryString["i"] == null)
					i = "Default";
				else
					i = em.DecryptMyData(Request.QueryString["i"]);

				if (Request.QueryString["el"] == null)
					el = "None";
				else
					el = Request.QueryString["el"];

				if (Request.QueryString["redirecturl"] == null)
					redirecturl = "None";
				else
					redirecturl = em.DecryptMyData(Request.QueryString["redirecturl"]);


				if (Session["signout"] != null)
				{
					Session["signout"] = null;
					informer.Text = "loggedout";
					alerttext.Text = "Logged Out";
				}



				if (f == "Sign_Up")
				{
					show.Text = "0";
					st = "NOT VERIFIED";
					cmd = "delete from customer where AStatus='" + st + "'";
					dm.ExInsertUpdateorDelete((cmd));
				}
				else if (f == "Sign_In")
					show.Text = "1";
				else if (f == "2")
				{
					st = "NOT VERIFIED";
					cmd = "select * from customer where CID='" + el + "' and  AStatus='" + st + "'";
					DataTable dfnf = dm.SelectQuery(cmd);
					if (dfnf.Rows.Count > 0)
						show.Text = "2";
					else
						Response.Redirect("User_Zone?i=" + em.EncryptMyData("InvalidAccess") + "&f=Sign_Up");
				}
				else if (f == "3")
				{
					st = "VERIFIED BNF";
					cmd = "select * from customer where CID='" + el + "' and  AStatus='" + st + "'";
					DataTable dfnf = dm.SelectQuery(cmd);
					if (dfnf.Rows.Count > 0)
						show.Text = "3";
					else
						Response.Redirect("User_Zone?i=" + em.EncryptMyData("InvalidAccess") + "&f=Sign_Up");
				}
				else if (f == "Forgot_Password")
					show.Text = "4";
				else if (f == "5")
				{
					cmd = "select * from customer where CID='" + el + "'";
					DataTable dfnf = dm.SelectQuery(cmd);
					if (dfnf.Rows.Count > 0)
						show.Text = "5";
					else
						Response.Redirect("User_Zone?i=" + em.EncryptMyData("InvalidAccess") + "&f=Forgot_Password");
				}
				else if (f == "6")
				{
					if (Session["cid"] != null)
					{
						show.Text = "6";
					}
					else
						Response.Redirect("User_Zone?i=" + em.EncryptMyData("InvalidAccess") + "&f=Forgot_Password");
				}

				if (i == "AlreadyRegistered")
				{
					informer.Text = "AlreadyRegistered";
					alerttext.Text = "This Email ID is <b>Already Registered</b>.<br/>You can Login <a href='User_Zone?f=Sign_In'>Here</a>";
				}
				else if (i == "QueryNotSubmitted")
				{
					informer.Text = "QueryNotSubmitted";
					alerttext.Text = "Something went wrong, please try again. Thank You.";
				}
				else if (i == "InvalidEmailid")
				{
					informer.Text = "InvalidEmailid";
					alerttext.Text = "<b>Invalid Email ID</b>, Please enter valid Email ID. Thank You";
				}
				else if (i == "InvalidOTP")
				{
					informer.Text = "InvalidOTP";
					alerttext.Text = "<b>Invalid OTP</b>, Please try again.<br/>Check <b>SPAM</b> folder if OTP is not present in <b>INBOX</b>.";
				}
				else if (i == "InvalidAccess")
				{
					informer.Text = "InvalidAccess";
					alerttext.Text = "You can not access Requested Page.";
				}
				else if (i == "InvalidUseridorPassword")
				{
					informer.Text = "InvalidUseridorPassword";
					alerttext.Text = "<b>Invalid Email ID or Password.</b><br/>If you don't have <b>BooksMahal Account</b>, Then you can create <a href='User_Zone?f=Sign_Up'>Here</a>.<br>You can also Reset your Password <a href='User_Zone?f=Forgot_Password'>Here</a>.";
				}
				else if (i == "VerifiedButNotFilled")
				{
					informer.Text = "VerifiedButNotFilled";
					alerttext.Text = "Fill this form to continue to BooksMahal.com";
				}
				else if (i == "PasswordChanged")
				{
					informer.Text = "PasswordChanged";
					alerttext.Text = "Password Changed.";
				}
				else if (i == "SignUpFirst")
				{
					informer.Text = "SignUpFirst";
					alerttext.Text = "Please Sign In fisrt.";
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
				cmd = "select * from product";
				DataTable dtpa = dm.SelectQuery(cmd);
				if (dtpa.Rows.Count > 0)
				{
					for (j = 0; j < dtpa.Rows.Count; j++)
					{
						keywordph.Controls.Add(new Literal { Text = "<li><a href='Shop?for=" + dtpa.Rows[j]["PID"].ToString() + "'>" + dtpa.Rows[j]["PName"].ToString() + "</a></li>" });
					}
				}
				cmd = "select * from category";
				DataTable dtca = dm.SelectQuery(cmd);
				if (dtca.Rows.Count > 0)
				{
					for (j = 0; j < dtca.Rows.Count; j++)
					{
						keywordph.Controls.Add(new Literal { Text = "<li><a href='Shop?for=" + dtca.Rows[j][0].ToString() + "'>" + dtca.Rows[j][0].ToString() + "</a></li>" });
					}
				}
			}
		}

		

	}

	protected void supbtn_Click(object sender, EventArgs e)
	{
		if (Request.QueryString["f"] == null)
			f = "Sign_In";
		else
			f = Request.QueryString["f"];

		if (Request.QueryString["i"] == null)
			i = "Default";
		else
			i = em.DecryptMyData(Request.QueryString["i"]);

		if (Request.QueryString["el"] == null)
			el = "None";
		else
			el = Request.QueryString["el"];

		if (Request.QueryString["redirecturl"] == null)
			redirecturl = "None";
		else
			redirecturl = em.DecryptMyData(Request.QueryString["redirecturl"]);

		cmd = "select * from customer where CID='" + signupidtxt.Text.ToLower().ToString() + "'";
		DataTable dfc = dm.SelectQuery(cmd);
		if(dfc.Rows.Count>0)
		{
			Response.Redirect("User_Zone?i=" + em.EncryptMyData("AlreadyRegistered") + "");
		}
		else
		{
			string mem = "NO", sp = "NO", p;
			st = "NOT VERIFIED";
			p = em.EncryptMyData(signuppasstxt.Text);
			cmd = "insert into customer(CID, Password, TOrder, AStatus, SpecialOffer, Member) values(N'" + signupidtxt.Text.ToLower().ToString() + "',N'" + p + "',0,'" + st + "','" + sp + "','" + mem + "')";
			if (dm.ExInsertUpdateorDelete(cmd))
			{
				otp = gc.getcode();
				sub = "OTP for BooksMahal.com";
				msg = "OTP for BooksMahal.com is <b>" + otp + "</b>, generated at " + DateTime.Now.ToString() + ".";
				if (mm.SendMail(signupidtxt.Text.ToLower().ToString(), sub, msg))
				{
					Response.Redirect("User_Zone?redirecturl=" + em.EncryptMyData(otp) + "&f=2&el=" + signupidtxt.Text.ToLower().ToString() + "");
				}
				else
				{
					Response.Redirect("User_Zone?i=" + em.EncryptMyData("InvalidEmailid") + "");
				}
			}
			else
			{
				Response.Redirect("User_Zone?i=" + em.EncryptMyData("QueryNotSubmitted") + "");
			}
		}
	}

	protected void loginbtn_Click(object sender, EventArgs e)
	{
		if (Request.QueryString["f"] == null)
			f = "Sign_In";
		else
			f = Request.QueryString["f"];

		if (Request.QueryString["i"] == null)
			i = "Default";
		else
			i = em.DecryptMyData(Request.QueryString["i"]);

		if (Request.QueryString["el"] == null)
			el = "None";
		else
			el = Request.QueryString["el"];

		if (Request.QueryString["redirecturl"] == null)
			redirecturl = "None";
		else
			redirecturl = em.DecryptMyData(Request.QueryString["redirecturl"]);


		string p = em.EncryptMyData(loginpasstxt.Text.ToString());
		cmd = "select * from customer where CID='" + loginidtxt.Text.ToLower().ToString() + "' and Password='" + p + "'";
		DataTable dlogin = dm.SelectQuery(cmd);
		if(dlogin.Rows.Count>0)
		{
			if (chkbxrmbrme.Checked == true)
			{
				HttpCookie cookcid = new HttpCookie("cid")
				{
					Value = loginidtxt.Text.ToLower().ToString(),
					Expires = DateTime.Now.AddDays(30)
				};
				Response.Cookies.Add(cookcid);
			}
			else
			{
				HttpCookie cookcid = new HttpCookie("cid")
				{
					Value = loginidtxt.Text.ToLower().ToString(),
					Expires = DateTime.Now.AddHours(3)
				};
				Response.Cookies.Add(cookcid);
			}
			if (dlogin.Rows[0]["AStatus"].ToString() == "VERIFIED BNF")
				Response.Redirect("User_Zone?i=" + em.EncryptMyData("VerifiedButNotFilled") + "&f=3&el=" + em.EncryptMyData(loginidtxt.Text.ToLower().ToString()) + "");
			else if (dlogin.Rows[0]["AStatus"].ToString() == "VERIFIED")
				Response.Redirect("Home");
		}
		else
		{
			Response.Redirect("User_Zone?i=" + em.EncryptMyData("InvalidUseridorPassword") + "&el=" + em.EncryptMyData(loginidtxt.Text.ToLower().ToString()) + "");
		}
	}

	protected void formbtn_Click(object sender, EventArgs e)
	{
		if (Request.QueryString["f"] == null)
			f = "Sign_In";
		else
			f = Request.QueryString["f"];

		if (Request.QueryString["i"] == null)
			i = "Default";
		else
			i = em.DecryptMyData(Request.QueryString["i"]);

		if (Request.QueryString["el"] == null)
			el = "None";
		else
			el = Request.QueryString["el"];

		if (Request.QueryString["redirecturl"] == null)
			redirecturl = "None";
		else
			redirecturl = em.DecryptMyData(Request.QueryString["redirecturl"]);

		string city = "MEERUT";
		st = "VERIFIED";
		cmd = "update customer set Mobile='" + mobiletxt.Text.ToString() + "', Name=N'" + nametxt.Text.ToUpper().ToString() + "', Address=N'" + addresstxt.Text.ToUpper().ToString() + "', City='" + city + "', PIN='" + pintxt.Text.ToString() + "', AStatus='" + st + "' where CID='" + el + "'";
		if (dm.ExInsertUpdateorDelete(cmd))
		{
			sub = "Account Created on BooksMahal.com";
			msg = "Hello " + nametxt.Text.ToUpper().ToString() + ",<br/>Your account was created successfully on BooksMahal.com at " + DateTime.Now.ToString() + ".<br/><br/>Find Books here <a href='http://www.booksmahal.com' target='_blank'>BooksMahal.com</a>";
			mm.SendMail(el, sub, msg);
			HttpCookie cookcid = new HttpCookie("cid")
			{
				Value = el,
				Expires = DateTime.Now.AddDays(30)
			};
			Response.Cookies.Add(cookcid);
			Response.Redirect("Home");
		}
		else
		{
			Response.Redirect("User_Zone?f=3&el=" + el + "&i=" + em.EncryptMyData("QueryNotSubmitted") + "");
		}
	}

	protected void subotpbtn_Click(object sender, EventArgs e)
	{
		if (Request.QueryString["f"] == null)
			f = "Sign_In";
		else
			f = Request.QueryString["f"];

		if (Request.QueryString["i"] == null)
			i = "Default";
		else
			i = em.DecryptMyData(Request.QueryString["i"]);

		if (Request.QueryString["el"] == null)
			el = "None";
		else
			el = Request.QueryString["el"];

		if (Request.QueryString["redirecturl"] == null)
			redirecturl = "None";
		else
			redirecturl = em.DecryptMyData(Request.QueryString["redirecturl"]);

		if (otptxt.Text==redirecturl)
		{
			st = "VERIFIED BNF";
			cmd = "update customer set AStatus='" + st + "' where CID='" + el + "'";
			if (dm.ExInsertUpdateorDelete(cmd))
			{
				Response.Redirect("User_Zone?f=3&el=" + el + "");
			}
			else
			{
				Response.Redirect("User_Zone?f=Sign_Up&el=" + el + "&i=" + em.EncryptMyData("QueryNotSubmitted") + "");
			}
		}
		else
		{
			Response.Redirect("User_Zone?redirecturl=" + em.EncryptMyData(redirecturl) + "&f=2&el=" + el + "&i="+em.EncryptMyData("InvalidOTP")+"");
		}
	}
	
	protected void resendotpbtn_Click(object sender, EventArgs e)
	{
		if (Request.QueryString["f"] == null)
			f = "Sign_In";
		else
			f = Request.QueryString["f"];

		if (Request.QueryString["i"] == null)
			i = "Default";
		else
			i = em.DecryptMyData(Request.QueryString["i"]);

		if (Request.QueryString["el"] == null)
			el = "None";
		else
			el = Request.QueryString["el"];

		if (Request.QueryString["redirecturl"] == null)
			redirecturl = "None";
		else
			redirecturl = em.DecryptMyData(Request.QueryString["redirecturl"]);

		otp = gc.getcode();
		sub = "OTP for BooksMahal.com";
		msg = "OTP for BooksMahal.com is <b>" + otp + "</b>, generated at " + DateTime.Now.ToString() + ".";
		if (mm.SendMail(el, sub, msg))
		{
			Response.Redirect("User_Zone?redirecturl=" + em.EncryptMyData(otp) + "&f=2&el=" + el + "");
		}
		else
		{
			Response.Redirect("User_Zone?i=" + em.EncryptMyData("InvalidEmailid") + "");
		}
	}

	protected void forgotbtn_Click(object sender, EventArgs e)
	{
		if (Request.QueryString["f"] == null)
			f = "Sign_In";
		else
			f = Request.QueryString["f"];

		if (Request.QueryString["i"] == null)
			i = "Default";
		else
			i = em.DecryptMyData(Request.QueryString["i"]);

		if (Request.QueryString["el"] == null)
			el = "None";
		else
			el = Request.QueryString["el"];

		if (Request.QueryString["redirecturl"] == null)
			redirecturl = "None";
		else
			redirecturl = em.DecryptMyData(Request.QueryString["redirecturl"]);

		cmd = "select * from customer where CID='" + forgotidtxt.Text.ToLower().ToString() + "'";
		DataTable dfc = dm.SelectQuery(cmd);
		if (dfc.Rows.Count > 0)
		{
			otp = gc.getcode();
			sub = "OTP for BooksMahal.com";
			msg = "OTP for BooksMahal.com is <b>" + otp + "</b>, generated at " + DateTime.Now.ToString() + ".";
			mm.SendMail(forgotidtxt.Text.ToLower().ToString(), sub, msg);
			Response.Redirect("User_Zone?f=5&el=" + em.EncryptMyData(forgotidtxt.Text.ToLower().ToString()) + "&redirecturl=" + em.EncryptMyData(otp) + "");
		}
		else
		{
			Response.Redirect("User_Zone?i=" + em.EncryptMyData("InvalidEmailid") + "");
		}
	}

	protected void forgototpbtn_Click(object sender, EventArgs e)
	{
		if (Request.QueryString["f"] == null)
			f = "Sign_In";
		else
			f = Request.QueryString["f"];

		if (Request.QueryString["i"] == null)
			i = "Default";
		else
			i = em.DecryptMyData(Request.QueryString["i"]);

		if (Request.QueryString["el"] == null)
			el = "None";
		else
			el = Request.QueryString["el"];

		if (Request.QueryString["redirecturl"] == null)
			redirecturl = "None";
		else
			redirecturl = em.DecryptMyData(Request.QueryString["redirecturl"]);

		if (forgototptxt.Text == redirecturl)
		{
			Session["cid"] = el;
			Response.Redirect("User_Zone?f=6&el=" + el + "&redirecturl=" + em.EncryptMyData(redirecturl) + "");
		}
		else
		{
			Response.Redirect("User_Zone?redirecturl=" + em.EncryptMyData(redirecturl) + "&f=2&el=" + el + "&i=" + em.EncryptMyData("InvalidOTP") + "");
		}
	}

	protected void forgototpresendbtn_Click(object sender, EventArgs e)
	{
		if (Request.QueryString["f"] == null)
			f = "Sign_In";
		else
			f = Request.QueryString["f"];

		if (Request.QueryString["i"] == null)
			i = "Default";
		else
			i = em.DecryptMyData(Request.QueryString["i"]);

		if (Request.QueryString["el"] == null)
			el = "None";
		else
			el = Request.QueryString["el"];

		if (Request.QueryString["redirecturl"] == null)
			redirecturl = "None";
		else
			redirecturl = em.DecryptMyData(Request.QueryString["redirecturl"]);

		otp = gc.getcode();
		sub = "OTP for BooksMahal.com";
		msg = "OTP for BooksMahal.com is <b>" + otp + "</b>, generated at " + DateTime.Now.ToString() + ".";
		if (mm.SendMail(el, sub, msg))
		{
			Response.Redirect("User_Zone?f=5&el=" + el + "&redirecturl=" + em.EncryptMyData(otp) + "");
		}
		else
		{
			Response.Redirect("User_Zone?i=" + em.EncryptMyData("InvalidEmailid") + "&f=5");
		}
	}


	protected void resetpassbtn_Click(object sender, EventArgs e)
	{
		if (Request.QueryString["f"] == null)
			f = "Sign_In";
		else
			f = Request.QueryString["f"];

		if (Request.QueryString["i"] == null)
			i = "Default";
		else
			i = em.DecryptMyData(Request.QueryString["i"]);

		if (Request.QueryString["el"] == null)
			el = "None";
		else
			el = Request.QueryString["el"];

		if (Request.QueryString["redirecturl"] == null)
			redirecturl = "None";
		else
			redirecturl = em.DecryptMyData(Request.QueryString["redirecturl"]);

		string p = em.EncryptMyData(resetpasstxt.Text.ToString());
		cmd = "update customer set Password='" + p + "' where CID='" + el + "'";
		if(dm.ExInsertUpdateorDelete(cmd))
		{
			sub = "Password Changed";
			msg = "Your Password for BooksMahal.com is changed on " + DateTime.Now.ToString() + ".<br/>if you do this then ignore this e-mail. Otherwise Secure your account.";
			mm.SendMail(el, sub, msg);
			Session["cid"] = null;
			Response.Redirect("User_Zone?i=" + em.EncryptMyData("PasswordChanged") + "");
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
				Response.Redirect("User_Zone?info=" + em.EncryptMyData("AlreadyRegistered") + "");
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
						Response.Redirect("User_Zone?info=" + em.EncryptMyData("SuccessfullForNewsletter") + "");
					}
					else
					{
						Response.Redirect("User_Zone?info=" + em.EncryptMyData("QueryNotSubmitted") + "");
					}
				}
				else
				{
					Response.Redirect("User_Zone?info=" + em.EncryptMyData("QueryNotSubmitted") + "");
				}
			}
		}
		else
		{
			Response.Redirect("User_Zone?info=" + em.EncryptMyData("MustEnterYourEmail") + "");
		}
	}
}