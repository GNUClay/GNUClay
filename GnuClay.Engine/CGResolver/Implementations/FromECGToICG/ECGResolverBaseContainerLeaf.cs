using GnuClay.CommonUtils.TypeHelpers;
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
            : base(context, inputNode.Parent)
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

            var tmpNotContainerConcepts = tmpConceptsChildren.Where(p => p.Children.Count == 0).ToList();

            NLog.LogManager.GetCurrentClassLogger().Info("ProcessChildNodes tmpNotContainerConcepts.Count = {0}", tmpNotContainerConcepts.Count);

            foreach (var tmpItem in tmpNotContainerConcepts)
            {
                var tmpSubLeaf = new ECGResolverConceptualLeaf(Context, tmpItem);

                tmpSubLeaf.Run();
            }

            var tmpContainerConcepts = tmpConceptsChildren.Where(p => p.Children.Count > 0).ToList();

            NLog.LogManager.GetCurrentClassLogger().Info("ProcessChildNodes tmpContainerConcepts.Count = {0}", tmpContainerConcepts.Count);

            foreach(var tmpItem in tmpContainerConcepts)
            {
                var tmpSubLeaf = new ECGResolverContainerLeaf(Context, tmpItem);

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
        }

        private void ProcessLinks()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessLinks");

            throw new NotImplementedException();

            /*foreach (var node in mInputNode.Children)
            {
                if(_ListHelper.IsEmpty(node.OutputNodes))
                {
                    continue;
                }

                NLog.LogManager.GetCurrentClassLogger().Info("ProcessLinks node.FullName = {0}", node.FullName);

                var tmpICGNode = GetLinkedICGNode(node);

                NLog.LogManager.GetCurrentClassLogger().Info("ProcessLinks tmpICGNode.Key = {0}", tmpICGNode.Key);

                foreach(var secondNode in node.OutputNodes)
                {
                    NLog.LogManager.GetCurrentClassLogger().Info("ProcessLinks secondNode.FullName = {0}", secondNode.FullName);

                    var tmpSecondICGNode = GetLinkedICGNode(secondNode);

                    NLog.LogManager.GetCurrentClassLogger().Info("ProcessLinks tmpSecondICGNode.Key = {0}", tmpSecondICGNode.Key);

                    tmpICGNode.AddOutputNode(tmpSecondICGNode);

                    NLog.LogManager.GetCurrentClassLogger().Info("ProcessLinks {0} ⇒ {1}", node.FullName, secondNode.FullName);
                    NLog.LogManager.GetCurrentClassLogger().Info("ProcessLinks {0} ⇒ {1}", tmpICGNode.Key, tmpSecondICGNode.Key);
                }
            }*/
        }

        /*private ICG.BaseNode GetLinkedICGNode(ECG.BaseNode node)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("GetLinkedICGNode node.FullName = {0}", node.FullName);

            if(node is ECG.ConceptualNode)
            {
                return GetLinkedICGConceptNode(node as ECG.ConceptualNode);
            }

            return GetLinkedICGRelationNode(node as ECG.RelationNode);
        }

        private ICG.BaseNode GetLinkedICGConceptNode(ECG.ConceptualNode node)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("GetLinkedICGConceptNode node.FullName = {0}", node.FullName);

            var tmpKey = Context.GetKeyByNode(node);

            NLog.LogManager.GetCurrentClassLogger().Info("GetLinkedICGConceptNode tmpKey = {0}", tmpKey);

            return Context.GetICGNodeByKey(tmpKey);
        }

        private ICG.BaseNode GetLinkedICGRelationNode(ECG.RelationNode node)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("GetLinkedICGRelationNode node.FullName = {0}", node.FullName);

            return Context.GetICGRelationNodeByECGRelationNode(node);
        }*/
    }
}
