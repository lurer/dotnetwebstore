using BOL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ShoppingCartService
{
    public class ShoppingCartManager
    {

        private static ShoppingCartManager instance;

        private static List<ShoppingCart> shoppingCarts;

        private ShoppingCartManager()
        {
            shoppingCarts = new List<ShoppingCart>();
        }

        public static ShoppingCartManager getInstance()
        {
            if(instance == null)
            {
                instance = new ShoppingCartManager();
            }
            return instance;
        }


        public void addShoppingCartToList(ShoppingCart newCart)
        {
            shoppingCarts.Add(newCart);
        }

        public ShoppingCart getMyShoppingCart(string sessionID)
        {
            var cart =  shoppingCarts.ToList().Where(x => x.SessionID == sessionID).FirstOrDefault();
            if(cart != null)
            {
                updateCartTotalPrice(cart);
            }
            
            return cart;
        }

        public void deleteShopppingCart(string sessionID)
        {
            shoppingCarts.Remove(shoppingCarts.Find(x => x.SessionID == sessionID));
        }


        public void updateCartTotalPrice(ShoppingCart cart)
        {
            cart.PriceOfCart = cart.Items.Select(x => x.Price).Sum();
        }
    }
}
