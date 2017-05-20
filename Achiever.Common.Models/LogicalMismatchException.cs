using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achiever.Common.Models
{
    /// <summary>
    /// Throw when a argument or logic can broke the business logic of the application
    /// </summary>
    public class LogicalMismatchException : ApplicationException
    {
        public LogicalMismatchException(string msg)
            :base(msg)
        {
        }
        public LogicalMismatchException(string msg, Exception innerEx)
            :base(msg, innerEx)
        {
        }
    }
}
