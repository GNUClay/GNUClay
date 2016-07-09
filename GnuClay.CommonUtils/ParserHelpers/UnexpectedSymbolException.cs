using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonUtils.ParserHelpers
{
    public class UnexpectedSymbolException : Exception
    {
        public UnexpectedSymbolException()
        {
        }

        public UnexpectedSymbolException(string message)
            : base(message)
        {
        }
    }
}
