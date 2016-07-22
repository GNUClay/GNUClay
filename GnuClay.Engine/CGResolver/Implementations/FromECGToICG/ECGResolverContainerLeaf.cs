using GnuClay.Engine.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG
{
    public class ECGResolverContainerLeaf: ECGResolverBaseContainerLeaf
    {
        public ECGResolverContainerLeaf(ECGResolverContext context, ECG.ConceptualNode inputNode)
            : base(context, inputNode)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }

        protected override void OnRun()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("OnRun");

            var tmpKey = Context.RegContainerECGNode(InputNode);

            NLog.LogManager.GetCurrentClassLogger().Info("OnRun tmpKey = {0}", tmpKey);

            var tmpParentECGNode = InputNode.Parent;

            var tmpParentKey = Context.GetKeyByNode(tmpParentECGNode);

            NLog.LogManager.GetCurrentClassLogger().Info("OnRun tmpParentKey = {0}", tmpParentKey);

            var tmpParentICGNode = Context.GetICGNodeByKey(tmpParentKey) as ICG.ConceptualNode;

            var tmpICGNode = new ICG.ConceptualNode(tmpParentICGNode);

            tmpICGNode.Key = tmpKey;

            Context.RegContainerICGNode(tmpICGNode);

            var tmpIsICGNode = new ICG.RelationNode(tmpParentICGNode);

            tmpIsICGNode.Key = PreDefinedConceptsCodes.IS;

            Context.RegICGNode(tmpIsICGNode);

            tmpICGNode.AddOutputNode(tmpIsICGNode);

            ICG.ConceptualNode tmpPropositionICGNode = null;

            if(Context.ContainsICGNodeWithKey(PreDefinedConceptsCodes.PROPOSITION))
            {
                tmpPropositionICGNode = (ICG.ConceptualNode)Context.GetICGNodeByKey(PreDefinedConceptsCodes.PROPOSITION);
            }
            else
            {
                tmpPropositionICGNode = new ICG.ConceptualNode(tmpParentICGNode);

                tmpPropositionICGNode.Key = PreDefinedConceptsCodes.PROPOSITION;

                Context.RegICGNode(tmpPropositionICGNode);
            }

            tmpIsICGNode.AddOutputNode(tmpPropositionICGNode);

            var tmpIsICGNode_2 = new ICG.RelationNode(tmpParentICGNode);

            tmpIsICGNode_2.Key = PreDefinedConceptsCodes.IS;

            Context.RegICGNode(tmpIsICGNode_2);

            tmpICGNode.AddOutputNode(tmpIsICGNode_2);

            ICG.ConceptualNode tmpInstanceNode = null;

            if (Context.ContainsICGNodeWithKey(PreDefinedConceptsCodes.INSTANCE))
            {
                tmpInstanceNode = (ICG.ConceptualNode)Context.GetICGNodeByKey(PreDefinedConceptsCodes.INSTANCE);
            }
            else
            {
                tmpInstanceNode = new ICG.ConceptualNode(tmpParentICGNode);

                tmpInstanceNode.Key = PreDefinedConceptsCodes.INSTANCE;

                Context.RegICGNode(tmpInstanceNode);
            }

            tmpIsICGNode_2.AddOutputNode(tmpInstanceNode);
        }
    }
}
