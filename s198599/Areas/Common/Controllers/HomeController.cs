using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL.Models;
using BLL.BussinessTransactions;
using BLL.AuthenticationServices;
using AuthenticationServices;

namespace s198599.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Common/Home
        public ActionResult Index()
        {
            insertAdminIfNotFound();
            return View();
        }

        private void insertAdminIfNotFound()
        {

            var users = new UserTransaction();
            var admin = new User()
            {
                FirstName = "Admin",
                LastName = "Admin",
                Address = "Osloveien 123",
                PostCode = "1234",
                PostAddress = "Oslo",
                Email = "admin@online.no",
                Telephone = "22334455",
                RoleStringId = "A",
                Password = PasswordUtility.HashMyPassword("admin123")
            };
            users.Insert(admin);
        }
    }
}