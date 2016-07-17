using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameLexer;
using GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG
{
    public static class _QueryStringHelper
    {
        public static NodeNameInfo CreateNodeNameInfo(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            try
            {
                var tmpLexerEngine = new NodeNameLexerEngine();

                var tmpTokensList = tmpLexerEngine.Run(name);

                var tmpParser = new NodeNameParserEngine();

                return tmpParser.Run(tmpTokensList);
            }catch(Exception e)
            {
                throw new ArgumentException(e.ToString(), e);
            }
        }
    }
}
