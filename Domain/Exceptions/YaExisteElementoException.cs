using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class YaExisteElementoException : Exception
    {
        public YaExisteElementoException(string message) : base(message)
        {
        }
    }
    
}
