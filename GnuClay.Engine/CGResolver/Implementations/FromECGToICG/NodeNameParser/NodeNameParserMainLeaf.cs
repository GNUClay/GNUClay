using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameLexer;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameParser
{
    public class NodeNameParserMainLeaf: NodeNameParserBaseLeaf
    {
        private enum State
        {
            Base
        }

        public NodeNameParserMainLeaf(NodeNameParserContext context)
            : base(context)
        {
        }

        private State mState = State.Base;

        protected override void ProcessToken(NodeNameToken token)
        {
            switch(mState)
            {
                case State.Base:
                    ProcessToken_InBase(token);
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InBase(NodeNameToken token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessToken_InBase token = {0}", token);

            throw CreateUnexpectedTokenException(token);
        }

        protected override void OnExit()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("OnExit");
        }

        protected override void OnExitIfEndOfString()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("OnExitIfEndOfString");
        }
    }
}
