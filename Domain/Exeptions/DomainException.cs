using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exeptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {

        }
    }
}
