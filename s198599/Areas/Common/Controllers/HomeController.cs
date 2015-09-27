using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL.Models;
using BLL.ObjectServices;

namespace s198599.Areas.Common.Controllers
{
    public class HomeController : Controller
    {
        // GET: Common/Home
        public ActionResult Index()
        {
            var user = new BOL.Models.Customer()
            {
                FirstName = "Mari",
                LastName = "Elken",
                Address = "Gladengveien 15",
                PostCode = "0661",
                PostAddress = "Oslo"
            };
            CustomerService userService = new CustomerService();
            userService.Insert(user);
            return View();
        }
    }
}