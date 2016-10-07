using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.CommonData
{
    public class RuleException : Exception
    {
        public RuleException()
        {
        }

        public RuleException(string message)
            : base(message)
        {
        }

        public RuleException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
