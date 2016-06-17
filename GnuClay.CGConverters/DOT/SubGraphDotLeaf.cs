using GnuClay.CG;
using GnuClay.CGConverters.Helpers.ToStringHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.DOT
{
    public class SubGraphDotLeaf: BaseContainerDotLeaf
    {
        public SubGraphDotLeaf(ILeafContext context, IConceptualNode node)
            :base(context, node)
        {     
        }

        protected override void PringBegin()
        {
            Sb.Append("subgraph ");
            Sb.Append(Name);
            Sb.AppendLine("{");
        }
    }
}
