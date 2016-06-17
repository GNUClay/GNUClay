using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.Helpers.ToStringHelpers
{
    public abstract class RelationLeaf: BaseLeaf, IRelationLeaf
    {
        protected RelationLeaf(ILeafContext context, IRelationNode node)
            : base(context)
        {
            mNode = node;
            Name = Context.GetNodeName();
            Context.RegLeaf(mNode, this);
        }

        private IRelationNode mNode = null;

        public IRelationNode Node
        {
            get
            {
                return mNode;
            }
        }
    }
}
