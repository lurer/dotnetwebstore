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
                new ComplexBLL().createUserAndUpdateRole(User);
                return SetSessionMessage(RedirectToAction("Login", "Security", new { area = "Security" }), SESSIONMESSAGE.SUCCESS, "Registration was successful");
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
                    return SetSessionMessage(RedirectToAction("Index", "Home", new { area = "Common" }),SESSIONMESSAGE.SUCCESS,"Login was successfull!");
                }
                else
                {
                    return SetSessionMessage(View(user), SESSIONMESSAGE.FAIL, "You did not supply correct information. Please try again.");
                }
            }
            catch (Exception)
            {
                return SetSessionMessage(RedirectToAction("Login"), SESSIONMESSAGE.SUCCESS, "You are now logged in.");
            }
        }

        public ActionResult SignOut()
        {
            var sessionID = Session["SessionID"] as string;
            ShoppingCartManager.getInstance().deleteShopppingCart(sessionID);
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }
    }
}