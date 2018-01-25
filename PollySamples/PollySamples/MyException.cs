using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollySamples
{
    public class MyException : Exception
    {
        public  MyException(string name, Exception inner) : base(name, inner)
        { }
    }
}
