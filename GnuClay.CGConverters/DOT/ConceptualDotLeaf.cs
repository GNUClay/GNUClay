using GnuClay.CG;
using GnuClay.CGConverters.Helpers.ToStringHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.DOT
{
    public class ConceptualDotLeaf: ConceptualLeaf
    {
        public ConceptualDotLeaf(ILeafContext context, IConceptualNode node)
            : base(context, node)
        {
        }

        protected override void OnRun()
        {
            Sb.Append(Name);
            Sb.Append("[shape=box,label=\"");
            Sb.Append(Node.FullName);
            Sb.Append("\"];");
        }
    }
}
