using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF.FromStringHelpers.Parser
{
    public class UnexpectedIdentifierSGFParserException : Exception
    {
        public UnexpectedIdentifierSGFParserException()
        {
        }

        public UnexpectedIdentifierSGFParserException(string message)
            : base(message)
        {
        }
    }
}
