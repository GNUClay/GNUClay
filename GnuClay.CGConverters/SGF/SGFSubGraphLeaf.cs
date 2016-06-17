using GnuClay.CG;
using GnuClay.CGConverters.Helpers.ToStringHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF
{
    public class SGFSubGraphLeaf: SGFBaseContainerLeaf
    {
        public SGFSubGraphLeaf(ILeafContext context, IConceptualNode node)
            : base(context, node)
        {
        }

        protected override void PringBegin()
        {
            Sb.Append(Name);
            Sb.Append(":[");

            if(!string.IsNullOrWhiteSpace(Node.FullName))
            {
                Sb.Append("\"");
                Sb.Append(Node.FullName);
                Sb.Append("\":");
            }

            Sb.AppendLine("{");
        }
    }
}
