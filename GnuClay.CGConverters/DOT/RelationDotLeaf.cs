using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.DOT
{
    public class RelationDotLeaf: DotBaseLeaf
    {
        public RelationDotLeaf(DotContext context, IRelationNode node)
            : base(context)
        {
            mNode = node;
            Name = Context.GetNodeName();
            Context.RegLeaf(mNode, this);
        }

        private IRelationNode mNode = null;

        protected override void OnRun()
        {
            Sb.Append(Name);
            Sb.Append("[shape=ellipse,label=\"");
            Sb.Append(mNode.FullName);
            Sb.Append("\"];");
        }
    }
}
