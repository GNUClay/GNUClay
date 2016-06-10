using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.DOT
{
    public class ConceptualDotLeaf: DotBaseLeaf
    {
        public ConceptualDotLeaf(DotContext context, IConceptualNode node)
            : base(context)
        {
            mNode = node;
            Name = Context.GetNodeName();
            Context.RegLeaf(mNode, this);
        }

        private IConceptualNode mNode = null;

        protected override void OnRun()
        {
            Sb.Append(Name);
            Sb.Append("[shape=box,label=\"");
            Sb.Append(mNode.FullName);
            Sb.Append("\"];");
        }
    }
}
