using GnuClay.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG
{
    public class ECGResolverContext
    {
        public ECGResolverContext(IGnuClayEngineContext mainContext)
        {
            mMainContext = mainContext;
        }

        private IGnuClayEngineContext mMainContext = null;

        public IGnuClayEngineContext MainContext
        {
            get
            {
                return mMainContext;
            }
        }

        public ulong RegRootECGNode(ECG.ConceptualNode node)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("RegRootNode");

            return RegContainerECGNode(node);
        }

        public void RegRootICGNode(ICG.ConceptualNode node)
        {
            mICGNodeFromKey[node.Key] = node;

            mResult = node;
        }

        public ulong RegContainerECGNode(ECG.ConceptualNode node)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("RegContainerECGNode");

            var tmpNodeName = Guid.NewGuid().ToString("D");

            NLog.LogManager.GetCurrentClassLogger().Info("RegRootNode tmpNodeName = {0}", tmpNodeName);

            var tmpKey = MainContext.KS.ObjectsRegistry.AddWord(tmpNodeName);

            NLog.LogManager.GetCurrentClassLogger().Info("RegRootNode tmpKey = {0}", tmpKey);

            mInstacesKeys.Add(tmpNodeName, tmpKey);
            mInstancesAliases[tmpNodeName] = tmpNodeName;

            LinkECGNodeAndKey(node, tmpKey);

            return tmpKey;
        }

        public void RegContainerICGNode(ICG.ConceptualNode node)
        {
            mICGNodeFromKey[node.Key] = node;
        }

        public void RegICGNode(ICG.BaseNode node)
        {
            mICGNodeFromKey[node.Key] = node;
        }

        public void LinkECGNodeAndKey(ECG.ConceptualNode node, ulong key)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("LinkECGNodeAndKey node.FullName = {0}, key = {1}", node.FullName, key);

            mECGNodeFromKey[key] = node;
            mKeyFromECGNode[node] = key;
        }

        public ulong GetKeyByNode(ECG.ConceptualNode node)
        {
            return mKeyFromECGNode[node];
        }

        public ICG.BaseNode GetICGNodeByKey(ulong key)
        {
            return mICGNodeFromKey[key];
        }

        public bool ContainsICGNodeWithKey(ulong key)
        {
            return mICGNodeFromKey.ContainsKey(key);
        }

        public bool ContainsInstanceName(string name)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ContainsInstanceName name = {0}", name);

            return mInstancesAliases.ContainsKey(name);
        }

        public ulong GetKeyByInstanceName(string name)
        {
            return mInstacesKeys[mInstancesAliases[name]];
        }

        public ulong RegInstanceName(string name)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("RegInstanceName name = {0}", name);

            var tmpNodeName = Guid.NewGuid().ToString("D");

            NLog.LogManager.GetCurrentClassLogger().Info("RegInstanceName tmpNodeName = {0}", tmpNodeName);

            var tmpKey = MainContext.KS.ObjectsRegistry.AddWord(tmpNodeName);

            NLog.LogManager.GetCurrentClassLogger().Info("RegRootNode tmpKey = {0}", tmpKey);

            mInstacesKeys.Add(tmpNodeName, tmpKey);
            mInstancesAliases[name] = tmpNodeName;

            return tmpKey;
        }

        public void RegRelationWithSimpleName(ECG.RelationNode ecgNode, ICG.RelationNode icgNode, ulong key, string name)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("RegRelationWithSimpleName key = {0}, name = {1}", key, name);

            mRelationsICGNodeFromECG[ecgNode] = icgNode;

            mRelationsAliases[name] = name;

            mRelationsKeys[name] = key;
        }

        public ICG.RelationNode GetICGRelationNodeByECGRelationNode(ECG.RelationNode ecgNode)
        {
            return mRelationsICGNodeFromECG[ecgNode];
        }

        private Dictionary<string, ulong> mInstacesKeys = new Dictionary<string, ulong>();
        private Dictionary<string, string> mInstancesAliases = new Dictionary<string, string>();

        private Dictionary<ulong, ECG.ConceptualNode> mECGNodeFromKey = new Dictionary<ulong, ECG.ConceptualNode>();

        private Dictionary<ECG.ConceptualNode, ulong> mKeyFromECGNode = new Dictionary<ECG.ConceptualNode, ulong>();

        private Dictionary<ulong, ICG.BaseNode> mICGNodeFromKey = new Dictionary<ulong, ICG.BaseNode>();



        private Dictionary<ECG.RelationNode, ICG.RelationNode> mRelationsICGNodeFromECG = new Dictionary<ECG.RelationNode, ICG.RelationNode>();

        private Dictionary<string, string> mRelationsAliases = new Dictionary<string, string>();

        private Dictionary<string, ulong> mRelationsKeys = new Dictionary<string, ulong>();


        private ICG.ConceptualNode mResult = null;

        public ICG.ConceptualNode Result
        {
            get
            {
                return mResult;
            }
        }
    }
}
