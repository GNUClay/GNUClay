using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonUtils.ParserHelpers
{
    [Serializable]
    public class UnexpectedTokenException : Exception
    {
        public UnexpectedTokenException()
        {
        }

        public UnexpectedTokenException(string message)
            : base(message)
        {
        }
    }
}
