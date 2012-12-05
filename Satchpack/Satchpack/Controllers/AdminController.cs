using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Satchpack.Domain.Entities;
using Satchpack.Domain.DAL_Abstract;

namespace Satchpack.Controllers
{
    public class AdminController : Controller
    {
        private IDAL_Base _dal;
        public AdminController(IDAL_Base dal)
        {
            _dal = dal;
        }

        public ActionResult Login(string username, string password)
        {
            DAL_Entity userEntity = new User();
            List<DAL_Entity> dalEntities = _dal.RetrieveEntities(userEntity);
            List<User> users = new List<User>();

            foreach (var item in dalEntities)
                if (item is User)
                    users.Add((User)item);

            User adminUser = users.SingleOrDefault(u => u.Username.Equals(username) && u.Password.Equals(password));
            if (adminUser != null)
            {
                return View("Index"); 
            }
            return View();            
        }
        public ActionResult Logout()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();        
        }
    }
}
