using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.CG;
using GnuClay.CGConverters.Helpers.ToStringHelpers;

namespace GnuClay.CGConverters.DOT
{
    public class DotLeafFactory : ILeafFactory
    {
        public IBaseLeaf CreateRootLeaf(ILeafContext context, IConceptualNode node)
        {
            return new RootGraphDotLeaf(context, node);
        }

        public IBaseLeaf CreateConceptualLeaf(ILeafContext context, IConceptualNode node)
        {
            return new ConceptualDotLeaf(context, node);
        }

        public IBaseLeaf CreateSubGraphLeaf(ILeafContext context, IConceptualNode node)
        {
            return new SubGraphDotLeaf(context, node);
        }

        public IBaseLeaf CreateRelationLeaf(ILeafContext context, IRelationNode node)
        {
            return new RelationDotLeaf(context, node);
        }
    }
}
