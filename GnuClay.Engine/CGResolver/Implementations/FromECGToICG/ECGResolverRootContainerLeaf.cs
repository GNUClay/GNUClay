using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG
{
    public class ECGResolverRootContainerLeaf: ECGResolverBaseContainerLeaf
    {
        public ECGResolverRootContainerLeaf(ECGResolverContext context, ECG.ConceptualNode inputNode)
            : base(context, inputNode)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }

        protected override void OnRun()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("OnRun");

            var tmpKey = Context.RegRootECGNode(InputNode);

            NLog.LogManager.GetCurrentClassLogger().Info("OnRun tmpKey = {0}", tmpKey);

            var tmpICGNode = new ICG.ConceptualNode();

            tmpICGNode.Key = tmpKey;

            Context.RegRootICGNode(tmpICGNode);
        }
    }
}
