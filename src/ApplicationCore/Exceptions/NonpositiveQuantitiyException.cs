using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Exceptions
{
    public class NonpositiveQuantitiyException : Exception
    {
        public NonpositiveQuantitiyException() : base("At least one item contains a nonpositive value.")
        {
        }

        public NonpositiveQuantitiyException(string message) : base(message)
        {
        }

        //public NonpositiveQuantitiyException(string message, Exception inner) : base(message, inner)
        //{
        //}
    }
}
