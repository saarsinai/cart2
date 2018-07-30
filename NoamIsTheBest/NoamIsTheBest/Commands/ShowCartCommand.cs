using System.Linq;
using NoamIsTheBest.Exceptions;

namespace NoamIsTheBest.Commands
{
    public class ShowCartCommand : ICommand
    {
        private bool ShowCart { get; set; }

        public bool IsRelevant(string userInput)
        {
            ShowCart = userInput.ToLower() == "show me my shopping cart";
            return ShowCart;
        }

        public string Execute()
        {
            var cart = ShoppingCart.Instance.CartList;
            if (!cart.Any())
            {
                return "Your cart is empty";
            }

            var productsNames = string.Join(", ", cart.Select(x => x.Name));
            return $"Your cart: {productsNames}";
        }
    }
}