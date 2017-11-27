using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace EmailExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult sendMessage(string message, string fromWho, string subject)
        {
            //Smtp Client Settings
            SmtpClient client = new SmtpClient("yourDomain"); //yourDomain as htttp://www.google.com
            client.Credentials = new NetworkCredential("senderMailAdress", "senderMailPassword");
            client.EnableSsl = false; //if you have SSL make this 'true'
            client.Port = 587; // if you have different port change this

            //MailMessageSettings
            MailMessage mes = new MailMessage();
            //Set the mail from
            mes.From = new MailAddress("displayName"); //displayName must be like 'test@test.com'
            //Set the receviers
            mes.To.Add("recevierMailAdress"); // with Add() method you can add many recevier
            //Set the subject and message
            mes.Subject = subject;
            mes.Body = message;
            try
            {
                client.Send(mes);
            }
            catch { }

            return RedirectToAction("Index");
        }


        //<system.net>
        //  <mailSettings>
        //    <smtp>
        //      <network host = "yourDomain" port="587" enableSsl="false" userName="senderMailAdress" password="senderMailPassword" />
        //    </smtp>
        //  </mailSettings>
        //</system.net>
        //if you want do mail settings in web.config you should add these lines to web.config
        public ActionResult sendMessageSettingFromWebConfig(string message, string fromWho, string subject)
        {
            //Smtp Client Settings
            SmtpClient client = new SmtpClient();
            //MailMessageSettings
            MailMessage mes = new MailMessage();
            //Set the mail from
            mes.From = new MailAddress("displayName"); //displayName must be like 'test@test.com'
            //Set the receviers
            mes.To.Add("receiverMailAdress"); // with Add() method you can add many recevier
            //Set the subject and message
            mes.Subject = subject;
            mes.Body = message;
            try
            {
                client.Send(mes);
            }
            catch { }

            return RedirectToAction("Index");
        }
    }
}