using GnuClay.Engine.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG
{
    public abstract class ECGResolverBaseLeaf
    {
        protected ECGResolverBaseLeaf(ECGResolverContext context, ECG.ConceptualNode parentNode)
        {
            mContext = context;

            mParentECGNode = parentNode;

            FindParentICGNode();
        }

        private ECGResolverContext mContext = null;

        protected ECGResolverContext Context
        {
            get
            {
                return mContext;
            }
        }

        public abstract void Run();

        private ECG.ConceptualNode mParentECGNode = null;

        private ICG.ConceptualNode mParentICGNode = null;

        protected ICG.ConceptualNode ParentICGNode
        {
            get
            {
                return mParentICGNode;
            }
        }

        private void FindParentICGNode()
        {
            if(mParentECGNode == null)
            {
                return;
            }

            var tmpParentKey = Context.GetKeyByNode(mParentECGNode);

            NLog.LogManager.GetCurrentClassLogger().Info("OnRun tmpParentKey = {0}", tmpParentKey);

            mParentICGNode = Context.GetICGNodeByKey(tmpParentKey) as ICG.ConceptualNode;
        }

        protected void DeclareNewClass(ICG.ConceptualNode classNode)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("DeclareNewClass");

            var tmpIsICGNode = new ICG.RelationNode(ParentICGNode);

            tmpIsICGNode.Key = PreDefinedConceptsCodes.IS;

            Context.RegICGNode(tmpIsICGNode);

            classNode.AddOutputNode(tmpIsICGNode);

            var tmpClassConceptNode = GetClassConceptNode();

            tmpIsICGNode.AddOutputNode(tmpClassConceptNode);
        }

        private ICG.ConceptualNode GetClassConceptNode()
        {
            if (Context.ContainsICGNodeWithKey(PreDefinedConceptsCodes.CLASS))
            {
                return (ICG.ConceptualNode)Context.GetICGNodeByKey(PreDefinedConceptsCodes.CLASS);
            }

            var tmpClassConceptNode = new ICG.ConceptualNode(ParentICGNode);

            tmpClassConceptNode.Key = PreDefinedConceptsCodes.CLASS;

            Context.RegICGNode(tmpClassConceptNode);

            return tmpClassConceptNode;
        }

        protected ICG.ConceptualNode CreateAndDeclareClass(ulong key)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("CreateAndDeclareClass key = {0}", key);

            var tmpClassICGNode = new ICG.ConceptualNode(ParentICGNode);

            tmpClassICGNode.Key = key;

            Context.RegICGNode(tmpClassICGNode);

            DeclareNewClass(tmpClassICGNode);

            return tmpClassICGNode;
        }
    }
}
