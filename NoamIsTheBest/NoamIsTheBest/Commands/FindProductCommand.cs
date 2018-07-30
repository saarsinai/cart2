using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using NoamIsTheBest.Exceptions;
using NoamIsTheBest.Models;

namespace NoamIsTheBest.Commands
{
    public class FindProductCommand : ICommand
    {
        private string SearchTerm { get; set; }

        public bool IsRelevant(string userInput)
        {
            var relevant = userInput.ToLower().StartsWith("i want to buy");
            if (relevant)
                SearchTerm = ExtrapulateSearchTerm(userInput);

            return relevant;
        }

        public string Execute()
        {
            InsureData();
            
            var productResults = FetchProductsByTerm(SearchTerm);

            if (productResults == null || !productResults.Any())
                return $"no items found for {SearchTerm}";
            
            ShoppingCart.Instance.LastSearchProducts = productResults;

            var productsNames = string.Join(", ", productResults.Select(x => x.Name));
            return $"i found {productResults.Count} items: {productsNames}";
        }

        private void InsureData()
        {
            // TODO: add more tests for input (like only whitespace)
            if (string.IsNullOrEmpty(SearchTerm))
            {
                // TODO: write to log
                throw new SearchTermIrelevantException();
            }
        }

        private static string ExtrapulateSearchTerm(string userInput)
        {
            return userInput.ToLower().Replace("i want to buy ", string.Empty);
        }

        private static List<Product> FetchProductsByTerm(string searchTerm)
        {
            try
            {
                // TODO: switch to API call
                List<Product> items;

                using (var httpClient = new HttpClient())
                {
                    var requestUri = new Uri($"http://localhost:2424/noamIsTheBest?search={searchTerm}");
                    var response = httpClient.GetStringAsync(requestUri).Result;
                    items = JsonConvert.DeserializeObject<ProductsList>(response).Products;
                }

                return items;
            }
            catch (Exception e)
            {
                // TODO: console log exception from API
                throw new Exception(e.Message);
            }

            //                using (var r = new StreamReader(@"C:\Users\saarsinai\Downloads\products.json"))
            //                {
            //                    var json = r.ReadToEnd();
            //                    items = JsonConvert.DeserializeObject<List<Product>>(json);
            //                }

            //                return items.FindAll(x => x.Name.ToLower().Contains(searchTerm));
        }
    }

    public class ProductsList
    {
        public List<Product> Products { get; set; }
    }
}


