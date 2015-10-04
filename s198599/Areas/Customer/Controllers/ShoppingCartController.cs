using BLL.BussinessTransactions;
using BLL.ShoppingCartService;
using BOL.Models;
using s198599.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace s198599.Areas.Customer.Controllers
{
    public class ShoppingCartController : Controller
    {
        public void AddItemToCart()
        {
            int? id = TempData["ItemId"] as int?;
            var mySessionID = Session["SessionID"] as string;
            if(mySessionID != null)
            {
                var myCart = ShoppingCartManager.getInstance().getMyShoppingCart(mySessionID);

                if(myCart == null)
                {
                    myCart = new ShoppingCart();
                }
                var newItem = new ItemTransaction().GetById(id);
                if (newItem.InStock > 0) { 
                    myCart.Items.Add(newItem);
                    
                }
            }
            
        }
    }
}