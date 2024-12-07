using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_13_OOP
{
    internal class NegativePriceException : ArgumentException
    {
        public double? Val;
        public NegativePriceException(double? val, string? message) : base(message)
        {
            Val = val;
        }
    }
    internal class NegativeVelocityException : ArgumentException
    {
        public double? Val;
        public NegativeVelocityException(double? val, string? message) : base(message)
        {
            Val = val;
        }
    }
    internal class UndeclaredPropertyException : ArgumentException
    {
        public string Val;
        public UndeclaredPropertyException(string val, string? message) : base(message)
        {
            Val = val;
        }
    }
}
