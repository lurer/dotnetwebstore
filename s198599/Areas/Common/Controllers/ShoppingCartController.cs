using BLL.BussinessTransactions;
using BLL.ShoppingCartService;
using BOL.Models;
using s198599.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace s198599.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class ShoppingCartController : Controller
    {
        public JsonResult AddItemToCart(int id, string mySessionID)
        {

            if(mySessionID != null)
            {
                var myCart = ShoppingCartManager.getInstance().getMyShoppingCart(mySessionID);

                if(myCart == null)
                {
                    myCart = new ShoppingCart();
                    myCart.Items = new List<Item>();
                    ShoppingCartManager.getInstance().addShoppingCartToList(myCart);
                }
                var newItem = new ItemTransaction().GetById(id);
                if (newItem.InStock > 0) {

                    myCart.Items.Add(newItem);
                    myCart.SessionID = mySessionID;
                    ShoppingCartManager.getInstance().updateCartTotalPrice(myCart);
                    return this.Json(myCart);
                }
            }
            return null;
            
        }

        public ActionResult GetMyCart()
        {
            var mySessionID = Session["SessionID"] as string;
            var myCart = ShoppingCartManager.getInstance().getMyShoppingCart(mySessionID);
            return View(myCart);
        }


        public JsonResult GetMyUpdatedCartJSON()
        {
            var mySessionID = Session["SessionID"] as string;

            var myCart = ShoppingCartManager.getInstance().getMyShoppingCart(mySessionID);

            if (myCart == null)
            {
                myCart = new ShoppingCart();
                myCart.Items = new List<Item>();
            }
            myCart.SessionID = mySessionID;
            ShoppingCartManager.getInstance().updateCartTotalPrice(myCart);

            return this.Json(myCart);
        }


        public ActionResult Delete(int? id)
        {
            var myCart = getMyCartFromManager();
            if(myCart != null)
                myCart.Items.Remove(myCart.Items.ToList().Where(x => x.ItemID == id).FirstOrDefault());
            return RedirectToAction("GetMyCart");
        }


        private ShoppingCart getMyCartFromManager()
        {
            var mySessionID = Session["SessionID"] as string;
            return ShoppingCartManager.getInstance().getMyShoppingCart(mySessionID);
        }
    }
}