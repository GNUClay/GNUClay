using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.DOT
{
    public class DotContext
    {
        public IDotLeafFactory mDotLeafFactory = new DotLeafFactory();

        public DotBaseLeaf CreateLeaf(INode node)
        {
            return mDotLeafFactory.CreateLeaf(this, node);
        }

        private uint mN = 0;

        public string GetNodeName()
        {
            mN++;

            var tmpSb = new StringBuilder();

            tmpSb.Append("n_");
            tmpSb.Append(mN);

            return tmpSb.ToString();
        }

        private uint mClusterN = 0;

        public string GetClusterName()
        {
            mClusterN++;

            var tmpSb = new StringBuilder();

            tmpSb.Append("cluster_");
            tmpSb.Append(mClusterN);

            return tmpSb.ToString();
        }

        private Dictionary<INode, DotBaseLeaf> mLeafsDict = new Dictionary<INode, DotBaseLeaf>();

        public void RegLeaf(INode node, DotBaseLeaf leaf)
        {
            if(mLeafsDict.ContainsKey(node))
            {
                return;
            }

            mLeafsDict.Add(node, leaf);
        }

        public DotBaseLeaf GetLeaf(INode node)
        {
            return mLeafsDict[node];
        }
    }
}
