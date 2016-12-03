using GnuClay.Engine.Parser.InternalParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser
{
    public class UnexpectedTokenException : Exception
    {
        public UnexpectedTokenException(Token token)
            : base($"Unexpected token {token.ToDebugString()}")
        {
        }
    }
}
