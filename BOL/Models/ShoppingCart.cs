using BOL.Models;
using BOL.Models.Payment;
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

        public void EmptyCart()
        {
            Items.Clear();
        }


        public IPayment Payment { get; set; }

    }
}