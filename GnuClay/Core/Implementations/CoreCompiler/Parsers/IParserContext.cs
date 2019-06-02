using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreCompiler.Parsers
{
    public interface IParserContext
    {
        ILog Logger { get; }
        Token GetToken();
        void Recovery(Token token);
    }
}
