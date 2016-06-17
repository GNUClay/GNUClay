using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.Helpers.ToStringHelpers
{
    public interface ILeafFactory
    {
        IBaseLeaf CreateRootLeaf(ILeafContext context, IConceptualNode node);

        IBaseLeaf CreateConceptualLeaf(ILeafContext context, IConceptualNode node);

        IBaseLeaf CreateSubGraphLeaf(ILeafContext context, IConceptualNode node);

        IBaseLeaf CreateRelationLeaf(ILeafContext context, IRelationNode node);
    }
}
