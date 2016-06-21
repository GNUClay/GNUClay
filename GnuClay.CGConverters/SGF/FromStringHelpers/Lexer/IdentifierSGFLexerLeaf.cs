using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF.FromStringHelpers.Lexer
{
    public class IdentifierSGFLexerLeaf: BaseContainerSGFLexerLeaf
    {
        public IdentifierSGFLexerLeaf(SGFLexerContext context)
            : base(context, SGFTokenKind.Identifier)
        {
        }

        protected override void ProcessChar(char ch)
        {
            if (char.IsLetterOrDigit(ch) || ch == '_')
            {
                AddChar(ch);

                return;
            }

            Context.Recovery(ch);

            Exit();
        }
    }
}
