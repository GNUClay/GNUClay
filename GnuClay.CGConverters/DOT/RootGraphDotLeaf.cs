using GnuClay.CG;
using GnuClay.CGConverters.Helpers.ToStringHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.DOT
{
    public class RootGraphDotLeaf : BaseContainerDotLeaf
    {
        public RootGraphDotLeaf(ILeafContext context, IConceptualNode node)
            :base(context, node)
        {
        }
  
        protected override void PringBegin()
        {
            Sb.Append("digraph ");
            Sb.Append(Name);
            Sb.AppendLine("{");
            Sb.AppendLine("compound=true;");
        }
    }
}
