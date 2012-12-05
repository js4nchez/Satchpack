using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Configuration;
using System.Net;

namespace Satchpack.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Returns the home page of the Satchpack website.
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns the 'Frequently Asked Questions' page.
        /// </summary>
        public ActionResult Faq()
        {
            return View();
        }

        /// <summary>
        /// Returns the 'Contact Us' page.
        /// </summary>
        public ActionResult ContactUs()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public ActionResult ContactUsSendEmail(string body, string email, string name)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(ConfigurationManager.AppSettings["SupportEmail"]);
            message.Subject = string.Format("Satchpack Complaint From: {0}", name);
            message.Body = string.Format("Message from email: {0}\n\r\n\r{1}", email, body);
            message.To.Add(new MailAddress(ConfigurationManager.AppSettings["SupportEmail"]));
            message.To.Add(new MailAddress(ConfigurationManager.AppSettings["PersonalEmail"]));

            SmtpClient server = new SmtpClient(
                ConfigurationManager.AppSettings["EmailHost"].ToString(),
                int.Parse(ConfigurationManager.AppSettings["EmailPort"].ToString()));

            server.Credentials = new NetworkCredential(
                ConfigurationManager.AppSettings["SupportEmail"].ToString(),
                ConfigurationManager.AppSettings["SupportEmailPassword"].ToString());
            server.Send(message);
            return View("Index");
        }
    }
}
