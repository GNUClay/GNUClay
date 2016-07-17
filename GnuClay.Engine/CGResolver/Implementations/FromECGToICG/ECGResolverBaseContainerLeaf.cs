using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG
{
    public abstract class ECGResolverBaseContainerLeaf : ECGResolverBaseLeaf
    {
        protected ECGResolverBaseContainerLeaf(ECGResolverContext context, ECG.ConceptualNode inputNode)
            : base(context)
        {
            mInputNode = inputNode;
        }

        private ECG.ConceptualNode mInputNode = null;

        protected ECG.ConceptualNode InputNode
        {
            get
            {
                return mInputNode;
            }
        }

        public override void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            OnRun();

            ProcessChildNodes();

            ProcessLinks();
        }

        protected virtual void OnRun()
        {
            throw new NotImplementedException();
        }

        private void ProcessChildNodes()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessChildNodes");

            var tmpConceptsType = typeof(ECG.ConceptualNode);

            var tmpConceptsChildren = mInputNode.Children.Where(p => p.GetType() == tmpConceptsType).Select(p =>(ECG.ConceptualNode)p).ToList();

            NLog.LogManager.GetCurrentClassLogger().Info("ProcessChildNodes tmpConceptsChildren.Count = {0}", tmpConceptsChildren.Count);

            var tmpContainerConcepts = tmpConceptsChildren.Where(p => p.Children.Count > 0).ToList();

            NLog.LogManager.GetCurrentClassLogger().Info("ProcessChildNodes tmpContainerConcepts.Count = {0}", tmpContainerConcepts.Count);

            foreach(var tmpItem in tmpContainerConcepts)
            {
                var tmpSubLeaf = new ECGResolverContainerLeaf(Context, tmpItem);

                tmpSubLeaf.Run();
            }

            var tmpNotContainerConcepts = tmpConceptsChildren.Where(p => p.Children.Count == 0).ToList();

            NLog.LogManager.GetCurrentClassLogger().Info("ProcessChildNodes tmpNotContainerConcepts.Count = {0}", tmpNotContainerConcepts.Count);

            foreach (var tmpItem in tmpNotContainerConcepts)
            {
                var tmpSubLeaf = new ECGResolverConceptualLeaf(Context, tmpItem);

                tmpSubLeaf.Run();
            }

            var tmpRelationType = typeof(ECG.RelationNode);

            var tmpRelations = mInputNode.Children.Where(p => p.GetType() == tmpRelationType).Select(p => (ECG.RelationNode)p).ToList();

            NLog.LogManager.GetCurrentClassLogger().Info("ProcessChildNodes tmpRelations.Count = {0}", tmpRelations.Count);

            foreach (var tmpItem in tmpRelations)
            {
                var tmpSubLeaf = new ECGResolverRelationLeaf(Context, tmpItem);

                tmpSubLeaf.Run();
            }

            throw new NotImplementedException();
        }

        private void ProcessLinks()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessChildNodes");

            throw new NotImplementedException();
        }
    }
}
