using BLL.AuthenticationServices;
using BLL.BussinessObjectOperations;
using BLL.ShoppingCartService;
using BOL.Models;
using s198599.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace s198599.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class SecurityController : BaseController
    {
        // GET: Security/Register
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "FirstName,LastName,Email,Password,Telephone,Address,PostCode,PostAddress")] User User)
        {

            if (ModelState.IsValid)
            {
                new ComplexTransactions().createUserAndUpdateRole(User);
                return RedirectToAction("Login", "Security", new { area = "Security" });
            }
            return View(User);
        }



        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            try
            {

                if (PasswordUtility.CheckUsedPasswordAgainstHashed(user.Email, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);

                    Session.Add("UserId", user.UserID);
                    return RedirectToAction("Index", "Home", new { area = "Common" });
                }
                else
                {
                    TempData["LoginMsg"] = "Login failed, please try again.";
                    return SetSessionMessage(View(user), "fail", "You did not supply correct information. Please try again.");
                }
            }
            catch (Exception e)
            {
                TempData["LoginMsg"] = "Login failed " + e.Message;
                return SetSessionMessage(RedirectToAction("Login"), "success", "You are now logged in.");
            }
        }

        public ActionResult SignOut()
        {
            var sessionID = Session["SessionID"] as string;
            ShoppingCartManager.getInstance().deleteShopppingCart(sessionID);
            FormsAuthentication.SignOut();
            Session.Abandon();
            return SetSessionMessage(RedirectToAction("Index", "Home", new { area = "Common" }), "success", "You are now logged out!");
        }
    }
}