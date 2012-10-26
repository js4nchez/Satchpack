using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Satchpack.Domain.DAL_Abstract;
using Satchpack.Domain.Entities;
using Satchpack.Models;

namespace Satchpack.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IInventoryDAL _dal;
        public ShoppingCartController(IInventoryDAL dal)
        {
            _dal = dal;
        }

        /// <summary>
        /// Returns the view where a user can add products to their cart.
        /// </summary>
        public ActionResult Product()
        {
            List<DAL_Entity> entities = _dal.RetrieveEntities(new Inventory());
            AvailableProducts products = new AvailableProducts();
            foreach (var item in entities)
                if (item is Inventory)
                    products.Products.Add((Inventory)item);
            return View(products);
        }

        /// <summary>
        /// Returns the view where a user can modify their cart and proceed to checkout.
        /// </summary>
        public ActionResult EditCart()
        {
            return View(GetCart());
        }

        /// <summary>
        /// Adds a product to the user's ShoppingCart.
        /// </summary>
        /// <param name="productId">The Id of the product being added to the cart.</param>
        public ActionResult AddToCart(int productId)
        {
            ShoppingCart cart = GetCart();
            Product product = (Product)_dal.RetrieveEntityById(new Product() { Id = productId });
            cart.OrderItems.Add(new OrderItem()
            {
                Product = product,
                Quantity = 1,
            });
            return View("EditCart", GetCart());
        }

        /// <summary>
        /// Removes a product from the user's ShoppingCart
        /// </summary>
        public ActionResult RemoveFromCart()
        {
            return View();
        }

        /// <summary>
        /// Generates the header of the website (This includes the shopping cart).
        /// </summary>
        public PartialViewResult GenerateHeader()
        {
            return PartialView(GetCart());    
        }

        /// <summary>
        /// Retrieves the current session's ShoppingCart.
        /// If there currently is no ShoppingCart, then one is created for this session.
        /// </summary>
        private ShoppingCart GetCart()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}
