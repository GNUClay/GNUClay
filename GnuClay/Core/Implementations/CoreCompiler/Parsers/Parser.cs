using GnuClay.Core.CommonInterfaces.CoreCompiler;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreCompiler.Parsers
{
    public class Parser: BaseParser
    {
        public Parser(IParserContext context)
            : base(context)
        {
        }

        public ICompiledResult Result => throw new NotImplementedException();
    }
}
