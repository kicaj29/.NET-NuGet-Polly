using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PollySamples
{
    public class DbNotAvailableException : Exception
    {
        public DbNotAvailableException(Exception ex) : base("DbNotAvailableException", ex)
        {
            
        }
    }
}
