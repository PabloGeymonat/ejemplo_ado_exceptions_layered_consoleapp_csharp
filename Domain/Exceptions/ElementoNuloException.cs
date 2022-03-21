using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class ElementoInvalidoException : Exception
    {
        public ElementoInvalidoException(string message) : base(message)
        {
        }
    }
    
}
