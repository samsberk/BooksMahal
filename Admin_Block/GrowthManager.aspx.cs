using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Admin_Block_GrowthManager : System.Web.UI.Page
{
	string cmd, cmid;
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
			int a = 1234, b = 5342, c = 3234, d = 7453, f = 1342, g = 6234;
			alllbl.Text = "<script type='text/javascript'>" +
					"var ctx2 = document.getElementById('myChart2');" +
					"var myChart2 = new Chart(ctx2, {type: 'line',data: {labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'],datasets: [{label: ' Total Orders ',data: [" + a + "," + b + "," + c + "," + d + "," + f + "," + g + "],backgroundColor: 'rgba(105,105,105,0.7)'}],borderColor: 'rgba(105,105,105,1)',borderWidth: 1}});" +
					"</script>";

			a = 2343; b = 2543; c = 5434; d = 7567; f = 3456; g = 5234;
			dellbl.Text = "<script type='text/javascript'>" +
					"var ctx2 = document.getElementById('myChart3');" +
					"var myChart2 = new Chart(ctx2, {type: 'line',data: {labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'],datasets: [{label: ' Total Orders ',data: [" + a + "," + b + "," + c + "," + d + "," + f + "," + g + "],backgroundColor: 'rgba(105,105,105,0.7)'}],borderColor: 'rgba(105,105,105,1)',borderWidth: 1}});" +
					"</script>";

			a = 5344; b = 7655; c = 1324; d = 6545; f = 2343; g = 6453;
			canlbl.Text = "<script type='text/javascript'>" +
					"var ctx2 = document.getElementById('myChart4');" +
					"var myChart2 = new Chart(ctx2, {type: 'line',data: {labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'],datasets: [{label: ' Total Orders ',data: [" + a + "," + b + "," + c + "," + d + "," + f + "," + g + "],backgroundColor: 'rgba(105,105,105,0.7)'}],borderColor: 'rgba(105,105,105,1)',borderWidth: 1}});" +
					"</script>";

		}
		else
		{
			Response.Redirect("Home");
		}
		//--------------------------------------

		

	}
}