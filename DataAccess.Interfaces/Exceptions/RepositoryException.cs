using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces.Exceptions
{
    public class RepositoryException : Exception
    {
        public RepositoryException(string message) : base(message)
        {
        }
    }
    
}
