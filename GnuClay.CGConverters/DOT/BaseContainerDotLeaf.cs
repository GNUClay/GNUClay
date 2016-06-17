using GnuClay.CG;
using GnuClay.CGConverters.Helpers.ToStringHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.DOT
{
    public abstract class BaseContainerDotLeaf : BaseContainerLeaf
    {
        protected BaseContainerDotLeaf(ILeafContext context, IConceptualNode node)
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

        protected override void ProcessLink(IBaseLeaf begin, IBaseLeaf end)
        {
            if (begin.IsContainer)
            {
                Sb.Append(begin.SomeChildLeaf.Name);
            }
            else
            {
                Sb.Append(begin.Name);
            }

            Sb.Append(" -> ");

            if (end.IsContainer)
            {
                Sb.Append(end.SomeChildLeaf.Name);
            }
            else
            {
                Sb.Append(end.Name);
            }

            if (begin.IsContainer || end.IsContainer)
            {
                Sb.Append("[");

                if (begin.IsContainer)
                {
                    Sb.Append("ltail=");
                    Sb.Append(begin.Name);
                    Sb.Append(",");
                }

                if (end.IsContainer)
                {
                    Sb.Append("lhead=");
                    Sb.Append(end.Name);
                }

                Sb.Append("]");
            }

            Sb.AppendLine(";");
        }
    }
}
