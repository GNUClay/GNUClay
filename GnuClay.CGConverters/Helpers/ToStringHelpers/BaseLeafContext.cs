using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.Helpers.ToStringHelpers
{
    public abstract class BaseLeafContext: ILeafContext
    {
        protected BaseLeafContext(ILeafFactory leafFactory)
        {
            mDotLeafFactory = leafFactory;
        }

        private ILeafFactory mDotLeafFactory = null;

        public IBaseLeaf CreateLeaf(INode node)
        {
            if (node is IConceptualNode)
            {
                var tmpConceptualNode = node as IConceptualNode;

                if (tmpConceptualNode.Children.Count == 0)
                {
                    return mDotLeafFactory.CreateConceptualLeaf(this, tmpConceptualNode);
                }

                return mDotLeafFactory.CreateSubGraphLeaf(this, tmpConceptualNode);
            }

            if (node is IRelationNode)
            {
                var tmpRelationNode = node as IRelationNode;

                return mDotLeafFactory.CreateRelationLeaf(this, tmpRelationNode);
            }

            throw new NotImplementedException();
        }

        private uint mN = 0;

        public virtual string GetNodeName()
        {
            mN++;

            var tmpSb = new StringBuilder();

            tmpSb.Append("n_");
            tmpSb.Append(mN);

            return tmpSb.ToString();
        }

        private uint mClusterN = 0;

        public virtual string GetClusterName()
        {
            mClusterN++;

            var tmpSb = new StringBuilder();

            tmpSb.Append("cluster_");
            tmpSb.Append(mClusterN);

            return tmpSb.ToString();
        }

        private Dictionary<INode, IBaseLeaf> mLeafsDict = new Dictionary<INode, IBaseLeaf>();

        public void RegLeaf(INode node, IBaseLeaf leaf)
        {
            if (mLeafsDict.ContainsKey(node))
            {
                return;
            }

            mLeafsDict.Add(node, leaf);
        }

        public IBaseLeaf GetLeaf(INode node)
        {
            return mLeafsDict[node];
        }
    }
}
