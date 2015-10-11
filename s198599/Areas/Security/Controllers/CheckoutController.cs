using BLL.BussinessObjectOperations;
using BLL.ShoppingCartService;
using BOL.Models;
using BOL.Models.Payment;
using Microsoft.AspNet.Identity;
using s198599.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace s198599.Areas.Security.Controllers
{
    [Authorize(Roles ="C")]
    public class CheckoutController : BaseController
    {
        [Authorize(Roles ="C")]
        // GET: Security/Checkout
        public ActionResult CheckingOut()
        {
            var mySessionID = Session["SessionID"] as string;
            ShoppingCart myCart = ShoppingCartManager.getInstance().getMyShoppingCart(mySessionID);
            myCart.Payment = new CreditCardPaymentImpl();
            return View();
        }


        public ActionResult ConfirmCheckout()
        {
            return View();
        }

        public ActionResult CancelOrder()
        {
            var mySessionID = Session["SessionID"] as string;
            ShoppingCart myCart = ShoppingCartManager.getInstance().getMyShoppingCart(mySessionID);
            myCart.EmptyCart();
            return SetSessionMessage(RedirectToAction("ListAll", "DisplayItems", new { area = "Common" }), "info", "Your order was canceled.");
        }

        public ActionResult CompleteOrder()
        {

            var mySessionID = Session["SessionID"] as string;
            string myId = User.Identity.GetUserName();
            ShoppingCart myCart = ShoppingCartManager.getInstance().getMyShoppingCart(mySessionID);

            User myUser = new UserTransaction().getUserByEmail(myId);
            if(myUser == null)
                SetSessionMessage(View(), "fail", "Something went wrong. Please try again");

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

            var updatedOrder = new OrderTransaction().Insert(myOrder);
            if(updatedOrder == null)
                SetSessionMessage(View(), "fail", "Something went wrong. The order is not registered");
            myCart.EmptyCart();
            return SetSessionMessage(RedirectToAction("ListAll", "DisplayItems", new { area = "Common" }), "success", "The order is registered");
        }

        public ActionResult ChangeAccount()
        {
            return RedirectToAction("Index", "MyUser", new { area = "Customer" });
        }
    }
}