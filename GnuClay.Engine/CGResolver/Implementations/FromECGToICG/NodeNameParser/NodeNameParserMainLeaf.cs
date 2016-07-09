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
        public NodeNameParserMainLeaf(NodeNameParserContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }

        protected override void ProcessToken(NodeNameToken token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessToken token = {0}", token);
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
