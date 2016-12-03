using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser
{
    public class UnexpectedSymbolException : Exception
    {
        public UnexpectedSymbolException(char symbol)
            : base($"Unexpected symbol `{symbol}`")
        {
        }
    }
}
