using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Summary description for MyMail
/// </summary>
public class MyMail
{
    public bool SendMail(string to, string sub, string msg)
    {
        try
        {
			//MailMessage ml = new MailMessage();
			//ml.From = new MailAddress("bksmhl-info@booksmahal.in");
			//ml.To.Add(to);
			//ml.Subject = sub;
			//ml.Body = msg;
			//ml.IsBodyHtml = true;
			//SmtpClient smtp = new SmtpClient("relay-hosting.secureserver.net", 25);
			//smtp.Credentials = new System.Net.NetworkCredential("bksmhl-info@booksmahal.in", "BooksMahal@1601");
			//smtp.EnableSsl = false;
			//smtp.Send(ml);
			//ml.Dispose();
			SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
			client.EnableSsl = true;
			client.UseDefaultCredentials = false;
			client.Credentials = new NetworkCredential("scrietcvgclub@gmail.com", "SCRIETCVGClub");
			MailMessage txt = new MailMessage();
			txt.To.Add(to);
			txt.From = new MailAddress("scrietcvgclub@gmail.com");
			txt.Subject = sub;
			txt.Body = msg;
			txt.IsBodyHtml = true;
			client.Send(txt);
			return true;
        }
        catch(Exception ex)
        {
            return false;
        }
    }
}