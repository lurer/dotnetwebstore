using BLL.BussinessTransactions;
using BOL.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace s198599.Areas.Customer.Controllers
{
    [Authorize]
    public class MyUserController : Controller
    {
        // GET: Customer/MyUser
        public ActionResult Index()
        {
            string myId = User.Identity.GetUserName();
            User myUser = new UserTransaction().getUserByEmail(myId);
            return View(myUser);
            
        }
    }
}