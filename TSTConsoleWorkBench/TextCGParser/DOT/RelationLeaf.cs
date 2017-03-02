using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser.DOT
{
    public class RelationLeaf : BaseLeaf
    {
        public RelationLeaf(DotContext context, CGNode node)
             : base(context)
        {
            mNode = node;
            Name = Context.GetNodeName();
            Context.RegLeaf(mNode, this);
        }

        private CGNode mNode = null;

        public CGNode Node
        {
            get
            {
                return mNode;
            }
        }

        protected override void OnRun()
        {
            Sb.Append(Name);
            Sb.Append("[shape=ellipse,label=\"");
            Sb.Append(Node.Name);
            Sb.Append("\"];");
        }
    }
}
