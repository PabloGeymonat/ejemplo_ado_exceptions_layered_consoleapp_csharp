using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class ElementoNuloException : Exception
    {
        public ElementoNuloException(string message) : base(message)
        {
        }
    }
    
}
