using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF.FromStringHelpers.Lexer
{
    public class TwoQuotesSGFLexerLeaf: BaseContainerSGFLexerLeaf
    {
        public TwoQuotesSGFLexerLeaf(SGFLexerContext context)
            : base(context, SGFTokenKind.String)
        {
        }

        protected override void ProcessChar(char ch)
        {
            if(ch == '"')
            {
                Exit();

                return;
            }

            AddChar(ch);
        }
    }
}
