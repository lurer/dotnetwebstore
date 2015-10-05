using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace s198599.Areas.Security.Controllers
{
    [Authorize(Roles ="C")]
    public class CheckoutController : Controller
    {
        [Authorize(Roles ="C")]
        // GET: Security/Checkout
        public ActionResult CheckingOut()
        {
            return View();
        }


        public ActionResult ConfirmCheckout()
        {

            return View();
        }

        public ActionResult CancelOrder()
        {
            return View();
        }

        public ActionResult CompleteOrder()
        {
            return View();
        }

        public ActionResult ChangeAccount()
        {
            return RedirectToAction("Index", "MyUser", new { area = "Customer" });
        }
    }
}