using BOL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOL.Models
{
    public class ShoppingCart
    {

        private List<Item> cartItems;

        [Key]
        public string SessionID { get; set; }

        public List<Item> Items {
            get { return cartItems; }
            set { cartItems = value; }
        } 

        public double PriceOfCart { get; set; }

 /*       public double GetPriceOfItemsInCart {
            get
            {
                if (cartItems != null) { 
                    priceOfCart = cartItems.ToList().Select(x => x.Price).Sum();
                    return priceOfCart;
                }
                else
                    return 0.0;
            }
        }*/

    }
}