using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF.FromStringHelpers.Parser
{
    public class UnexpectedTokenSGFParserException : Exception
    {
        public UnexpectedTokenSGFParserException()
        {
        }

        public UnexpectedTokenSGFParserException(string message)
            : base(message)
        {
        }
    }
}
