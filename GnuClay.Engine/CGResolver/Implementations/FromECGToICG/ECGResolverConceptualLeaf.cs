using GnuClay.Engine.Implementations;
using GnuClay.Engine.StorageOfKnowledges.Interfaces;
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
            : base(context, inputNode.Parent)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor inputNode.FullName = {0}", inputNode.FullName);

            mInputNode = inputNode;

            mObjectsRegistry = Context.MainContext.KS.ObjectsRegistry;
        }

        private IObjectsRegistry mObjectsRegistry = null;

        private ECG.ConceptualNode mInputNode = null;

        private NodeNameInfo mNodeNameInfo = null;

        private ICG.ConceptualNode mClassICGNode = null;

        private ICG.ConceptualNode mInstanceICGNode = null;

        public override void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run mInputNode.FullName = {0}", mInputNode.FullName);

            throw new NotImplementedException();

            /*var tmpParentECGNode = mInputNode.Parent;

            mNodeNameInfo = _QueryStringHelper.CreateNodeNameInfo(mInputNode.FullName);

            NLog.LogManager.GetCurrentClassLogger().Info(mNodeNameInfo);

            if(mNodeNameInfo.HasClass)
            {
                if(mNodeNameInfo.HasClassQuestion || mNodeNameInfo.HasClassVar)
                {
                    ProcessClassVarOrQuestion();
                }
                else
                {
                    ProcessClass();
                }         
            }
            
            if(mNodeNameInfo.HasInstance)
            {
                if(mNodeNameInfo.HasInstanceVar || mNodeNameInfo.HasInstanceQuestion)
                {
                    ProcessInstanceVarOrQuestion();
                }
                else
                {
                    ProcessInstance();
                } 
            }
            
            if(mNodeNameInfo.HasClass && mNodeNameInfo.HasInstance)
            {
                CombineClassAndInstance();
            }
            
            if(!mNodeNameInfo.HasClass && !mNodeNameInfo.HasClass)
            {
                NotClassOrInstance();
            }*/
        }

        /*private void ProcessClass()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessClass mNodeNameInfo.ClassName = {0}", mNodeNameInfo.ClassName);

            ulong tmpKey = 0;

            if(mObjectsRegistry.ContainsWord(mNodeNameInfo.ClassName))
            {
                tmpKey = mObjectsRegistry.GetKey(mNodeNameInfo.ClassName);

                mClassICGNode = (ICG.ConceptualNode)Context.GetICGNodeByKey(tmpKey);
            }
            else
            {
                tmpKey = mObjectsRegistry.AddWord(mNodeNameInfo.ClassName);

                mClassICGNode = CreateAndDeclareClass(tmpKey);
            }

            NLog.LogManager.GetCurrentClassLogger().Info("ProcessClass tmpKey = {0}", tmpKey);

            if(!mNodeNameInfo.HasInstance)
            {
                Context.LinkECGNodeAndKey(mInputNode, tmpKey);
            }
        }

        private void ProcessClassVarOrQuestion()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessClassVarOrQuestion");

            ulong tmpKey = 0;

            if (Context.ExistsVar(mNodeNameInfo.ClassName))
            {
                NLog.LogManager.GetCurrentClassLogger().Info("ProcessClassVarOrQuestion Context.ExistsVar");

                tmpKey = Context.GetKeyByVarName(mNodeNameInfo.ClassName);

                mClassICGNode = (ICG.ConceptualNode)Context.GetICGNodeByKey(tmpKey);
            }
            else
            {
                NLog.LogManager.GetCurrentClassLogger().Info("ProcessClassVarOrQuestion !Context.ExistsVar");

                CheckClassVarName(mNodeNameInfo.ClassName);

                tmpKey = Context.RegVarName(mNodeNameInfo.ClassName);

                mClassICGNode = CreateAndDeclareClass(tmpKey);

                DeclareAsVar(mClassICGNode);

                mClassICGNode.HasQuestion = mNodeNameInfo.HasClassQuestion;
                mClassICGNode.Quantification = mNodeNameInfo.ClassQuantification;
                mClassICGNode.HasVar = mNodeNameInfo.HasClassVar;
            }

            NLog.LogManager.GetCurrentClassLogger().Info("ProcessClassVarOrQuestion tmpKey = {0}", tmpKey);

            if (!mNodeNameInfo.HasInstance)
            {
                Context.LinkECGNodeAndKey(mInputNode, tmpKey);
            }
        }

        private void ProcessInstance()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessInstance mNodeNameInfo.InstanceName = {0}", mNodeNameInfo.InstanceName);

            ulong tmpKey = 0;

            if (Context.ContainsInstanceName(mNodeNameInfo.InstanceName))
            {
                tmpKey = Context.GetKeyByInstanceName(mNodeNameInfo.InstanceName);

                mInstanceICGNode = (ICG.ConceptualNode)Context.GetICGNodeByKey(tmpKey);
            }
            else
            {
                tmpKey = Context.RegInstanceName(mNodeNameInfo.InstanceName);

                CreateAndDeclareNewInstance(tmpKey);
            }

            NLog.LogManager.GetCurrentClassLogger().Info("ProcessInstance tmpKey = {0}", tmpKey);

            Context.LinkECGNodeAndKey(mInputNode, tmpKey);
        }

        private void CreateAndDeclareNewInstance(ulong key)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("CreateAndDeclareNewInstance key = {0}", key);

            mInstanceICGNode = new ICG.ConceptualNode(ParentICGNode);

            mInstanceICGNode.Key = key;

            mInstanceICGNode.IsInstance = true;

            Context.RegICGNode(mInstanceICGNode);

            DeclareAsInstance();
        }

        private void DeclareAsInstance()
        {
            var tmpIsICGNode = new ICG.RelationNode(ParentICGNode);

            tmpIsICGNode.Key = PreDefinedConceptsCodes.IS;

            Context.RegICGNode(tmpIsICGNode);

            mInstanceICGNode.AddOutputNode(tmpIsICGNode);

            var tmpInstanceConceptNode = GetInstanceConceptNode();

            tmpIsICGNode.AddOutputNode(mInstanceICGNode);
        }

        private ICG.ConceptualNode GetInstanceConceptNode()
        {
            if(Context.ContainsICGNodeWithKey(PreDefinedConceptsCodes.INSTANCE))
            {
                return (ICG.ConceptualNode)Context.GetICGNodeByKey(PreDefinedConceptsCodes.INSTANCE);
            }

            var tmpInstanceConceptNode = new ICG.ConceptualNode(ParentICGNode);

            tmpInstanceConceptNode.Key = PreDefinedConceptsCodes.INSTANCE;

            Context.RegICGNode(tmpInstanceConceptNode);

            return tmpInstanceConceptNode;
        }

        private void ProcessInstanceVarOrQuestion()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessInstanceVarOrQuestion mNodeNameInfo.InstanceName = {0}", mNodeNameInfo.InstanceName);

            ulong tmpKey = 0;

            if(Context.ExistsInstanceVar(mNodeNameInfo.InstanceName))
            {
                NLog.LogManager.GetCurrentClassLogger().Info("ProcessInstanceVarOrQuestion Context.ExistsInstanceVar");

                tmpKey = Context.GetKeyByInstanceVarName(mNodeNameInfo.InstanceName);

                mInstanceICGNode = (ICG.ConceptualNode)Context.GetICGNodeByKey(tmpKey);
            }
            else
            {
                NLog.LogManager.GetCurrentClassLogger().Info("ProcessInstanceVarOrQuestion !Context.ExistsInstanceVar");

                CheckInstanceVarName(mNodeNameInfo.InstanceName);

                tmpKey = Context.RegInstanceVar(mNodeNameInfo.InstanceName);

                CreateAndDeclareNewInstance(tmpKey);

                mInstanceICGNode.HasQuestion = mNodeNameInfo.HasInstanceQuestion;
                mInstanceICGNode.Quantification = mNodeNameInfo.InstanceQuantification;
                mInstanceICGNode.HasVar = mNodeNameInfo.HasInstanceVar;
            }

            NLog.LogManager.GetCurrentClassLogger().Info("ProcessClassVarOrQuestion tmpKey = {0}", tmpKey);

            Context.LinkECGNodeAndKey(mInputNode, tmpKey);
        }

        private void CombineClassAndInstance()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("CombineClassAndInstance");

            var tmpIsICGNode = new ICG.RelationNode(ParentICGNode);

            tmpIsICGNode.Key = PreDefinedConceptsCodes.IS;

            Context.RegICGNode(tmpIsICGNode);

            mInstanceICGNode.AddOutputNode(tmpIsICGNode);

            tmpIsICGNode.AddOutputNode(mClassICGNode);
        }

        private void NotClassOrInstance()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("NotClassOrInstance");

            var tmpICGNode = GetUniversalAllConceptNode();

            NLog.LogManager.GetCurrentClassLogger().Info("NotClassOrInstance tmpICGNode.Key = {0}", tmpICGNode.Key);

            Context.LinkECGNodeAndKey(mInputNode, tmpICGNode.Key);
        }*/
    }
}
