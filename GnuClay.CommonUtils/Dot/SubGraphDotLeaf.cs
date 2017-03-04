using GnuClay.CommonUtils.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonUtils.Dot
{
    public class SubGraphDotLeaf : BaseContainerLeaf
    {
        public SubGraphDotLeaf(DotContext context, CGNode node)
            : base(context, node)
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
