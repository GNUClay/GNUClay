using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG
{
    public class ECGResolverConceptualLeaf: ECGResolverBaseLeaf
    {
        public ECGResolverConceptualLeaf(ECGResolverContext context, ECG.ConceptualNode inputNode)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");

            mInputNode = inputNode;
        }

        private ECG.ConceptualNode mInputNode = null;

        public override void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            ProcessChildNodes();

            throw new NotImplementedException();
        }

        private void ProcessChildNodes()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessChildNodes");

            throw new NotImplementedException();
        }
    }
}
