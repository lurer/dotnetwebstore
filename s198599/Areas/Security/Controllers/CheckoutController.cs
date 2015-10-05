using BLL.BussinessTransactions;
using BLL.ShoppingCartService;
using BOL.Models;
using Microsoft.AspNet.Identity;
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

            var mySessionID = Session["SessionID"] as string;
            string myId = User.Identity.GetUserName();

            ShoppingCart myCart = ShoppingCartManager.getInstance().getMyShoppingCart(mySessionID);
            User myUser = new UserTransaction().getUserByEmail(myId);

            var myOrder = new Order();
            myOrder.User = myUser;
            myOrder.DateTime = DateTime.Now;
            myOrder.Items = new List<OrderLine>();

            foreach(var item in myCart.Items)
            {
                var orderLine = new OrderLine()
                {
                    Amount = 1,
                    Discount = 0,
                    Item = item
                };
                myOrder.Items.Add(orderLine);
            }

            new OrderTransaction().Insert(myOrder);

            return RedirectToAction("Index", "Home", new { area = "Common" });
        }

        public ActionResult ChangeAccount()
        {
            return RedirectToAction("Index", "MyUser", new { area = "Customer" });
        }
    }
}