using GnuClay.CGConverters.Helpers.ToStringHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.CG;

namespace GnuClay.CGConverters.SGF
{
    public class SGFLeafFactory : ILeafFactory
    {
        public IBaseLeaf CreateConceptualLeaf(ILeafContext context, IConceptualNode node)
        {
            return new SGFConceptualLeaf(context, node);
        }

        public IBaseLeaf CreateRelationLeaf(ILeafContext context, IRelationNode node)
        {
            return new SGFRelationLeaf(context, node);
        }

        public IBaseLeaf CreateRootLeaf(ILeafContext context, IConceptualNode node)
        {
            return new SGFRootLeaf(context, node);
        }

        public IBaseLeaf CreateSubGraphLeaf(ILeafContext context, IConceptualNode node)
        {
            return new SGFSubGraphLeaf(context, node);
        }
    }
}
