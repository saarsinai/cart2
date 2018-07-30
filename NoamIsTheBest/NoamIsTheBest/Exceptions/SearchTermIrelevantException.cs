using System;

namespace NoamIsTheBest.Exceptions
{
    public class SearchTermIrelevantException : Exception
    {
        public SearchTermIrelevantException() : base("Input did not contain relevant term to Command")
        {
            
        }
    }
}