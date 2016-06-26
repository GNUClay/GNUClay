using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.CG;
using GnuClay.CGConverters.Helpers.ToStringHelpers;
using GnuClay.CGConverters.SGF.FromStringHelpers.Lexer;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.CGConverters.SGF.FromStringHelpers.Parser;

namespace GnuClay.CGConverters.SGF
{
    public class SGFConverter : BaseConverter<SGFContext>
    {
        public SGFConverter()
            : this(null)
        {
        }

        public SGFConverter(ISGFNodeFactory nodeFactory)
        {
            mNodeFactory = nodeFactory;
        }

        private ISGFNodeFactory mNodeFactory = null;

        public override IConceptualNode ConvertFromString(string source)
        {
            var tmpLexer = new SGFLexerEngine();

            var tmpTokensList = tmpLexer.Run(source);

            var tmpParser = new SGFParserEngine(mNodeFactory);

            return tmpParser.Run(tmpTokensList);
        }
    }
}
