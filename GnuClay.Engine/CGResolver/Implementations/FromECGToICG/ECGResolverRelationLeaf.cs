using GnuClay.Engine.StorageOfKnowledges.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG
{
    public class ECGResolverRelationLeaf: ECGResolverBaseLeaf
    {
        public ECGResolverRelationLeaf(ECGResolverContext context, ECG.RelationNode inputNode)
             : base(context, inputNode.Parent)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor inputNode.FullName = {0}", inputNode.FullName);

            mInputNode = inputNode;

            mObjectsRegistry = Context.MainContext.KS.ObjectsRegistry;
        }

        private IObjectsRegistry mObjectsRegistry = null;

        private ECG.RelationNode mInputNode = null;

        private NodeNameInfo mNodeNameInfo = null;

        private ICG.RelationNode mICGNode = null;

        public override void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            mNodeNameInfo = _QueryStringHelper.CreateNodeNameInfo(mInputNode.FullName);

            NLog.LogManager.GetCurrentClassLogger().Info(mNodeNameInfo);

            if(mNodeNameInfo.HasInstance)
            {
                var tmpSb = new StringBuilder("Invalid name of relation node `");
                tmpSb.Append(mInputNode.FullName);
                tmpSb.Append("`. Name cannot be notation with instance of concept.");

                throw new Exception(tmpSb.ToString());
            }

            if(mNodeNameInfo.HasClassVar || mNodeNameInfo.HasClassQuestion)
            {
                ProcessVarOrQuestion();
            }
            else
            {
                if(mNodeNameInfo.HasClass)
                {
                    ProcessSimpleName();
                }
                else
                {
                    ProcessNotSimpleNameOrVarOrQuestion();
                }
            }
        }

        private void ProcessSimpleName()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessSimpleName");

            ulong tmpKey = 0;

            if (mObjectsRegistry.ContainsWord(mNodeNameInfo.ClassName))
            {
                tmpKey = mObjectsRegistry.GetKey(mNodeNameInfo.ClassName);
            }
            else
            {
                tmpKey = mObjectsRegistry.AddWord(mNodeNameInfo.ClassName);

                CreateAndDeclareClass(tmpKey);
            }

            NLog.LogManager.GetCurrentClassLogger().Info("ProcessClass tmpKey = {0}", tmpKey);

            mICGNode = new ICG.RelationNode(ParentICGNode);

            mICGNode.Key = tmpKey;

            Context.RegRelation(mInputNode, mICGNode);
        }

        private void ProcessVarOrQuestion()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessVarOrQuestion");

            ulong tmpKey = 0;

            if (mObjectsRegistry.ContainsWord(mNodeNameInfo.ClassName))
            {
                tmpKey = mObjectsRegistry.GetKey(mNodeNameInfo.ClassName);
            }
            else
            {
                tmpKey = mObjectsRegistry.AddWord(mNodeNameInfo.ClassName);

                CreateAndDeclareClass(tmpKey);
            }

            NLog.LogManager.GetCurrentClassLogger().Info("ProcessVarOrQuestion tmpKey = {0}", tmpKey);

            mICGNode = new ICG.RelationNode(ParentICGNode);

            mICGNode.Key = tmpKey;

            mICGNode.HasQuestion = mNodeNameInfo.HasClassQuestion;
            mICGNode.Quantification = mNodeNameInfo.ClassQuantification;
            mICGNode.HasVar = mNodeNameInfo.HasClassVar;

            Context.RegRelation(mInputNode, mICGNode);
        }

        private void ProcessNotSimpleNameOrVarOrQuestion()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessNotSimpleNameOrVarOrQuestion");

            var tmpICGNode = GetUniversalAllConceptNode();

            NLog.LogManager.GetCurrentClassLogger().Info("NotClassOrInstance tmpICGNode.Key = {0}", tmpICGNode.Key);

            mICGNode = new ICG.RelationNode(ParentICGNode);

            mICGNode.Key = tmpICGNode.Key;

            Context.RegRelation(mInputNode, mICGNode);
        }
    }
}
