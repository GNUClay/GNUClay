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
            mECGNodeFromKey[tmpKey] = node;

            mKeyFromECGNode[node] = tmpKey;

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

        public ulong GetKeyByNode(ECG.ConceptualNode node)
        {
            return mKeyFromECGNode[node];
        }

        public ICG.BaseNode GetICGNodeByKey(ulong key)
        {
            return mICGNodeFromKey[key];
        }

        private Dictionary<string, ulong> mInstacesKeys = new Dictionary<string, ulong>();
        private Dictionary<string, string> mInstancesAliases = new Dictionary<string, string>();

        private Dictionary<ulong, ECG.ConceptualNode> mECGNodeFromKey = new Dictionary<ulong, ECG.ConceptualNode>();

        private Dictionary<ECG.ConceptualNode, ulong> mKeyFromECGNode = new Dictionary<ECG.ConceptualNode, ulong>();

        private Dictionary<ulong, ICG.BaseNode> mICGNodeFromKey = new Dictionary<ulong, ICG.BaseNode>();

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
