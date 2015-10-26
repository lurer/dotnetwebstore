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
            var myCart = getMyShoppingCart();
            myCart.Payment = new CreditCardPaymentImpl();
            return View();
        }


        public ActionResult ConfirmCheckout()
        {
            return View();
        }

        public ActionResult CancelOrder()
        {
            var myCart = getMyShoppingCart();
            myCart.EmptyCart();
            return SetSessionMessage(RedirectToAction("ListAll", "DisplayItems", new { area = "Common" }), SESSIONMESSAGE.INFO, "Your order was canceled.");
        }

        public ActionResult CompleteOrder()
        {

            var myCart = getMyShoppingCart();

            User myUser = new UserBLL().getUserByEmail(User.Identity.Name);
            if(myUser == null)
                SetSessionMessage(View(), SESSIONMESSAGE.FAIL, "Something went wrong. Please try again");

            var myOrder = new Order();
            myOrder.User = myUser;
            myOrder.DateTime = DateTime.Now;
            myOrder.Items = new List<OrderLine>();

            var itemTransaction = new ItemBLL();
            foreach(var item in myCart.Items)
            {
                item.InStock--;
                itemTransaction.Update(item);

                var orderLine = new OrderLine()
                {
                    Amount = 1,
                    Discount = 0,
                    Item = item
                };
                myOrder.Items.Add(orderLine);
            }

            var updatedOrder = new OrderBLL().Insert(myOrder);
            if(updatedOrder == null)
                SetSessionMessage(View(), SESSIONMESSAGE.FAIL, "Something went wrong. The order is not registered");
            myCart.EmptyCart();
            return SetSessionMessage(RedirectToAction("ListAll", "DisplayItems", new { area = "Common" }), SESSIONMESSAGE.SUCESS, "The order is registered");
        }


        private ShoppingCart getMyShoppingCart()
        {
            var mySessionID = Session["SessionID"] as string;
            string myId = User.Identity.GetUserName();
            return ShoppingCartManager.getInstance().getMyShoppingCart(mySessionID);

        }


        public ActionResult ChangeAccount()
        {
            return RedirectToAction("Index", "MyUser", new { area = "Customer" });
        }
    }
}