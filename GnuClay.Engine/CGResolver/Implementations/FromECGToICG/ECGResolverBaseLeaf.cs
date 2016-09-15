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
            NLog.LogManager.GetCurrentClassLogger().Info("FindParentICGNode");

            if (mParentECGNode == null)
            {
                return;
            }

            mParentICGNode = Context.GetICGNodeFromECG(mParentECGNode) as ICG.ConceptualNode;
        }

        /*protected void DeclareNewClass(ICG.ConceptualNode classNode)
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

        protected ICG.ConceptualNode GetUniversalAllConceptNode()
        {
            if (Context.ContainsICGNodeWithKey(PreDefinedConceptsCodes.UNIVERSAL_ALL))
            {
                return (ICG.ConceptualNode)Context.GetICGNodeByKey(PreDefinedConceptsCodes.UNIVERSAL_ALL);
            }

            var tmpClassConceptNode = new ICG.ConceptualNode(ParentICGNode);

            tmpClassConceptNode.Key = PreDefinedConceptsCodes.UNIVERSAL_ALL;

            tmpClassConceptNode.Quantification = ICG.QuantificationInfo.Universal;

            Context.RegICGNode(tmpClassConceptNode);

            return tmpClassConceptNode;
        }

        protected void DeclareAsVar(ICG.ConceptualNode node)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("DeclareAsVar");

            var tmpIsICGNode = new ICG.RelationNode(ParentICGNode);

            tmpIsICGNode.Key = PreDefinedConceptsCodes.IS;

            Context.RegICGNode(tmpIsICGNode);

            node.AddOutputNode(tmpIsICGNode);

            var tmpVarConceptNode = GetVarConceptNode();

            tmpIsICGNode.AddOutputNode(tmpVarConceptNode);
        }

        private ICG.ConceptualNode GetVarConceptNode()
        {
            if (Context.ContainsICGNodeWithKey(PreDefinedConceptsCodes.VARIABLE))
            {
                return (ICG.ConceptualNode)Context.GetICGNodeByKey(PreDefinedConceptsCodes.VARIABLE);
            }

            var tmpClassConceptNode = new ICG.ConceptualNode(ParentICGNode);

            tmpClassConceptNode.Key = PreDefinedConceptsCodes.VARIABLE;

            Context.RegICGNode(tmpClassConceptNode);

            return tmpClassConceptNode;
        }

        protected void CheckInstanceVarName(string varName)
        {
            if(Context.ExistsVar(varName) || Context.ContainsInstanceName(varName))
            {
                throw CreateUsingInstanceVarInTheClass(varName);
            }
        }

        protected void CheckClassVarName(string varName)
        {
            if(Context.ExistsInstanceVar(varName) || Context.ContainsInstanceName(varName))
            {
                throw CreateUsingInstanceVarInTheClass(varName);
            }
        }

        private ArgumentException CreateUsingInstanceVarInTheClass(string varName)
        {
            return new ArgumentException("Using an instance variable in the class.", varName);
        }*/
    }
}
