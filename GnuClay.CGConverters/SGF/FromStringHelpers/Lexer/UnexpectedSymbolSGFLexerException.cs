using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF.FromStringHelpers.Lexer
{
    [Serializable]
    public class UnexpectedSymbolSGFLexerException : Exception
    {
        public UnexpectedSymbolSGFLexerException()
        {
        }

        public UnexpectedSymbolSGFLexerException(string message)
            : base(message)
        {
        }
    }
}
