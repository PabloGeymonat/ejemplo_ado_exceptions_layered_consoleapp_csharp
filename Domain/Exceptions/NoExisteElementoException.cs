using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class NoExisteElementoException : Exception
    {
        public NoExisteElementoException(string message) : base(message)
        {
        }
    }
    
}
