using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoamIsTheBest.Models;

namespace NoamIsTheBest
{
    public class ShoppingCart
    {
        private static ShoppingCart instance;

        private ShoppingCart()
        {
            CartList = new List<Product>();
        }

        public List<Product> LastSearchProducts { get; set; }
        public List<Product> CartList { get; set; }

        public static ShoppingCart Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShoppingCart();
                }
                return instance;
            }
        }
    }
}
