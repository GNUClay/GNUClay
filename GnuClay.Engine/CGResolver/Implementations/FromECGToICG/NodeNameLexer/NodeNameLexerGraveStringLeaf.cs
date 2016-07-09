using GnuClay.CommonUtils.ParserHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameLexer
{
    public class NodeNameLexerGraveStringLeaf: NodeNameLexerBaseContainerLeaf
    {
        public NodeNameLexerGraveStringLeaf(NodeNameLexerContext context)
            : base(context)
        {
        }

        protected override void ProcessChar(char ch)
        {
            if(ch == '`')
            {
                Exit();

                return;
            }

            AddChar(ch);
        }

        protected override void OnExitIfEndOfString()
        {
            throw new UnexpectedSymbolException("Missing closing quotation mark");
        }
    }
}
