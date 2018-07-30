using System;

namespace NoamIsTheBest.Exceptions
{
    internal class ProductLocationNotInSearchResultsException : Exception
    {
        public ProductLocationNotInSearchResultsException() : base("Product location have not been found in the last search results")
        {

        }
    }
}