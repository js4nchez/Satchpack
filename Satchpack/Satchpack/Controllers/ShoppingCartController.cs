using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Satchpack.Controllers
{
    public class ShoppingCartController : Controller
    {
        /// <summary>
        /// Returns the view where a user can add products to their cart.
        /// </summary>
        public ActionResult Product()
        {
            return View();
        }

        /// <summary>
        /// Returns the view where a user can modify their cart and proceed to checkout.
        /// </summary>
        public ActionResult EditCart()
        {
            return View();
        }
    }
}
