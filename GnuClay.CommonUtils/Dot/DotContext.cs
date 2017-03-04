using GnuClay.CommonUtils.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonUtils.Dot
{
    public class DotContext
    {
        public BaseLeaf CreateRootLeaf(CGNode node)
        {
            return new RootGraphDotLeaf(this, node);
        }

        public BaseLeaf CreateConceptualLeaf(CGNode node)
        {
            return new ConceptualLeaf(this, node);
        }

        public BaseLeaf CreateSubGraphLeaf(CGNode node)
        {
            return new SubGraphDotLeaf(this, node);
        }

        public BaseLeaf CreateRelationLeaf(CGNode node)
        {
            return new RelationLeaf(this, node);
        }

        public BaseLeaf CreateLeaf(CGNode node)
        {
            if (node.Kind == CGNodeKind.Concept)
            {
                if (node.Children.Count == 0)
                {
                    return CreateConceptualLeaf(node);
                }

                return CreateSubGraphLeaf(node);
            }

            if (node.Kind == CGNodeKind.Relation)
            {
                return CreateRelationLeaf(node);
            }

            throw new NotImplementedException();
        }

        private uint mN = 0;

        public virtual string GetNodeName()
        {
            mN++;

            return $"n_{mN}";
        }

        private uint mClusterN = 0;

        public virtual string GetClusterName()
        {
            mClusterN++;

            return $"cluster_{mClusterN}";
        }

        private Dictionary<CGNode, BaseLeaf> mLeafsDict = new Dictionary<CGNode, BaseLeaf>();

        public void RegLeaf(CGNode node, BaseLeaf leaf)
        {
            if (mLeafsDict.ContainsKey(node))
            {
                return;
            }

            mLeafsDict.Add(node, leaf);
        }

        public BaseLeaf GetLeaf(CGNode node)
        {
            return mLeafsDict[node];
        }
    }
}
