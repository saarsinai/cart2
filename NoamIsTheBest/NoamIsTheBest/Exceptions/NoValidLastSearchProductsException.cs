using System;

namespace NoamIsTheBest.Exceptions
{
    internal class NoValidLastSearchProductsException : Exception
    {
        public NoValidLastSearchProductsException() : base("You must seach for at list one valid product before trying to add product to your cart")
        {

        }

    }
}