using GnuClay.CG;
using GnuClay.CGConverters.Helpers.ToStringHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF
{
    public class SGFConceptualLeaf : ConceptualLeaf
    {
        public SGFConceptualLeaf(ILeafContext context, IConceptualNode node)
            : base(context, node)
        {
        }

        protected override void OnRun()
        {
            Sb.Append(Name);
            Sb.Append(":[");

            if (!string.IsNullOrWhiteSpace(Node.FullName))
            {
                Sb.Append("\"");
                Sb.Append(Node.FullName);
                Sb.Append("\"");
            }

            Sb.Append("];");
        }
    }
}
