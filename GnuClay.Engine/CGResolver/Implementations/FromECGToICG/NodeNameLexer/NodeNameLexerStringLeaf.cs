using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameLexer
{
    public class NodeNameLexerStringLeaf: NodeNameLexerBaseContainerLeaf
    {
        public NodeNameLexerStringLeaf(NodeNameLexerContext context)
            : base(context)
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
