using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.CommonData
{
    public class FactException: Exception
    {
        public FactException()
        {
        }

        public FactException(string message)
            : base(message)
        {
        }

        public FactException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
