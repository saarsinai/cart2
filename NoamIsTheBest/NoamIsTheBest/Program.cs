using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoamIsTheBest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cartHandler = new ShoppingCartHandler();
            
            while (cartHandler.Run()) {}

        }
    }
}
