using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.DOT
{
    public class SubGraphDotLeaf: BaseContainerDotLeaf
    {
        public SubGraphDotLeaf(DotContext context, IConceptualNode node)
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
