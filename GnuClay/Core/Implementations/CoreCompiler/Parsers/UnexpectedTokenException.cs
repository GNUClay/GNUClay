using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreCompiler.Parsers
{
    public class UnexpectedTokenException : Exception
    {
        public UnexpectedTokenException(Token token)
            : base($"Unexpected token {token.ToDebugString()}")
        {
        }
    }
}
