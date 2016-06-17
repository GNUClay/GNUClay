using GnuClay.CG;
using GnuClay.CGConverters.Helpers.ToStringHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF
{
    public class SGFRelationLeaf : RelationLeaf
    {
        public SGFRelationLeaf(ILeafContext context, IRelationNode node)
            : base(context, node)
        {
        }

        protected override void OnRun()
        {
            Sb.Append(Name);
            Sb.Append(":(");

            if (!string.IsNullOrWhiteSpace(Node.FullName))
            {
                Sb.Append("\"");
                Sb.Append(Node.FullName);
                Sb.Append("\"");
            }

            Sb.Append(");");
        }
    }
}
