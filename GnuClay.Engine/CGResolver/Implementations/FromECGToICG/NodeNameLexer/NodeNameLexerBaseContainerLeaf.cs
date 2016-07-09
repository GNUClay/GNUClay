using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameLexer
{
    public abstract class NodeNameLexerBaseContainerLeaf: NodeNameLexerBaseLeaf
    {
        protected NodeNameLexerBaseContainerLeaf(NodeNameLexerContext context)
            : base(context)
        {
        }

        private StringBuilder mBuffer = new StringBuilder();

        public void AddChar(char ch)
        {
            mBuffer.Append(ch);
        }

        protected override void OnExit()
        {
            Context.AddToken(CreateToken(NodeNameTokenKind.String, mBuffer.ToString()));
        }
    }
}
