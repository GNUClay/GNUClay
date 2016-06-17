using GnuClay.CG;
using GnuClay.CGConverters.Helpers.ToStringHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF
{
    public abstract class SGFBaseContainerLeaf : BaseContainerLeaf
    {
        protected SGFBaseContainerLeaf(ILeafContext context, IConceptualNode node)
            : base(context, node)
        {
        }

        protected override void PrintEnd()
        {
            Sb.AppendLine("}]");
        }

        protected override void ProcessLink(IBaseLeaf begin, IBaseLeaf end)
        {
            Sb.Append(begin.Name);
            Sb.Append(" -> ");
            Sb.Append(end.Name);
            Sb.AppendLine(";");
        }
    }
}
