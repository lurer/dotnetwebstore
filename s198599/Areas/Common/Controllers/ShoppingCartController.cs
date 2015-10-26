using BLL.BussinessObjectOperations;
using BLL.ShoppingCartService;
using BOL.Models;
using s198599.Controllers;
using s198599.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace s198599.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class ShoppingCartController : BaseController
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
                var newItem = new ItemBLL().GetById(id);
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
            if (myCart != null)
            {
                bool ok = myCart.Items.Remove(myCart.Items.ToList().Where(x => x.ItemID == id).FirstOrDefault());
                if (ok)
                    SetSessionMessage(View(), SESSIONMESSAGE.INFO, "The product was removed from your shopping cart!");
                else
                    SetSessionMessage(View(), SESSIONMESSAGE.FAIL, "Something went wrong. Please update your page!");

            }
            return RedirectToAction("GetMyCart");
        }


        private ShoppingCart getMyCartFromManager()
        {
            var mySessionID = Session["SessionID"] as string;
            return ShoppingCartManager.getInstance().getMyShoppingCart(mySessionID);
        }

    }
}