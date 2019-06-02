using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreCompiler.Parsers
{
    public class UnexpectedSymbolException : Exception
    {
        public UnexpectedSymbolException(char symbol)
            : base($"Unexpected symbol `{symbol}`")
        {
        }
    }
}
