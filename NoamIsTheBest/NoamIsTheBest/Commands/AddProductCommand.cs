using System.Globalization;
using System.Linq;
using NoamIsTheBest.Exceptions;

namespace NoamIsTheBest.Commands
{
    public class AddProductCommand : ICommand
    {
        private int LastSearchProductLocation { get; set; }

        public bool IsRelevant(string userInput)
        {
            var textStartWith = userInput.ToLower().StartsWith("add item ");
            var endWith = userInput.ToLower().EndsWith(" to cart");
            if (!textStartWith || !endWith)
                return false;

            LastSearchProductLocation = ExtrapulateSearchTerm(userInput);
            return true;
        }

        public string Execute()
        {
            InsureData();

            var searchProduct = ShoppingCart.Instance.LastSearchProducts[LastSearchProductLocation - 1];
            ShoppingCart.Instance.CartList.Add(searchProduct);

            LastSearchProductLocation = -1;

            return $"Item '{searchProduct.Name}' added to your cart";
        }

        private void InsureData()
        {
            // TODO: add more tests for input (like only whitespace)
            var lastSearchProducts = ShoppingCart.Instance.LastSearchProducts;
            if (lastSearchProducts == null)
            {
                // TODO: write to log
                throw new NoValidLastSearchProductsException();
            }
            
            if (!Enumerable.Range(1, lastSearchProducts.Count).Contains(LastSearchProductLocation))
            {
                // TODO: write to log
                throw new ProductLocationNotInSearchResultsException();
            }
        }

        private static int ExtrapulateSearchTerm(string userInput)
        {
            var term = userInput.ToLower().Replace("add item ", string.Empty).Replace(" to cart", string.Empty);
            if (int.TryParse(term, NumberStyles.Integer, null, out var productNum))
                return productNum;
            return -1;
        }
    }
}