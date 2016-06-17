using GnuClay.CG;
using GnuClay.CGConverters.Helpers.ToStringHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.DOT
{
    public class RelationDotLeaf: RelationLeaf
    {
        public RelationDotLeaf(ILeafContext context, IRelationNode node)
            : base(context, node)
        {
        }

        protected override void OnRun()
        {
            Sb.Append(Name);
            Sb.Append("[shape=ellipse,label=\"");
            Sb.Append(Node.FullName);
            Sb.Append("\"];");
        }
    }
}
