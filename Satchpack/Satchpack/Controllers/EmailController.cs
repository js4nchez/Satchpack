using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace Satchpack.Controllers
{
    public class EmailController : Controller
    {
        public ActionResult ContactUsSendEmail(string body, string email, string name)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(ConfigurationManager.AppSettings["SupportEmail"]);
            message.Subject = string.Format("Satchpack Complaint From: {0}", name);
            message.Body = string.Format("Message from email: {0}\n\n{1}", email, body);
            message.To.Add(new MailAddress(ConfigurationManager.AppSettings["SupportEmail"]));
            message.To.Add(new MailAddress(ConfigurationManager.AppSettings["PersonalEmail"]));

            SmtpClient server = new SmtpClient(
                ConfigurationManager.AppSettings["EmailHost"].ToString(),
                int.Parse(ConfigurationManager.AppSettings["EmailPort"].ToString()));

            server.Credentials = new NetworkCredential(
                ConfigurationManager.AppSettings["SupportEmail"].ToString(),
                ConfigurationManager.AppSettings["SupportEmailPassword"].ToString());
            server.Send(message);
            return RedirectToAction("Index", "Home");
        }
    }
}