using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}
