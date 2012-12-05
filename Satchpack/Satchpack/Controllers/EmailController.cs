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
        /// <summary>
        /// Sends an email to the emails located in the 'dbo.DistributionEmails' table
        /// </summary>
        /// <param name="from"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        private static void SendEmail(string from, string subject, string body)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(from);
            message.Subject = subject;
            message.Body = body;
            message.To.Add(new MailAddress(ConfigurationManager.AppSettings["SupportEmail"]));
            message.To.Add(new MailAddress(ConfigurationManager.AppSettings["PersonalEmail"]));

            SmtpClient server = new SmtpClient(
                ConfigurationManager.AppSettings["EmailHost"].ToString(),
                int.Parse(ConfigurationManager.AppSettings["EmailPort"].ToString()));

            server.Credentials = new NetworkCredential(
                ConfigurationManager.AppSettings["SupportEmail"].ToString(),
                ConfigurationManager.AppSettings["SupportEmailPassword"].ToString());
            server.Send(message);
        }
    }
}
