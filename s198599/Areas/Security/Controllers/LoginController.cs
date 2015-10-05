using BLL.AuthenticationServices;
using BOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace s198599.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Security/Login
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(User user)
        {
            try {
                

                if (PasswordUtility.CheckUsedPasswordAgainstHashed(user.Email, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                   
                    Session.Add("UserId", user.UserID);
                    return RedirectToAction("Index", "Home", new { area = "Common" });
                }
                else
                {
                    TempData["LoginMsg"] = "Login failed, please try again.";
                    return RedirectToAction("Index");
                }
            }catch(Exception e)
            {
                TempData["LoginMsg"] = "Login failed " + e.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }
    }
}