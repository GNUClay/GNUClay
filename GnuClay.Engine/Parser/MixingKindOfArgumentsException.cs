using GnuClay.Engine.Parser.InternalParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser
{
    public class MixingKindOfArgumentsException : Exception
    {
        public MixingKindOfArgumentsException(Token token)
            : base($"Mixing named and positional arguments into one function. Near the token {token.ToDebugString()}")
        {
        }
    }
}
