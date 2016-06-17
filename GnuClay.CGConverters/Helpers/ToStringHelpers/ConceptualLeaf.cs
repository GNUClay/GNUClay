using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.Helpers.ToStringHelpers
{
    public abstract class ConceptualLeaf: BaseLeaf, IConceptualLeaf
    {
        protected ConceptualLeaf(ILeafContext context, IConceptualNode node)
            : base(context)
        {
            mNode = node;
            Name = Context.GetNodeName();
            Context.RegLeaf(mNode, this);
        }

        private IConceptualNode mNode = null;

        public IConceptualNode Node
        {
            get
            {
                return mNode;
            }
        }
    }
}
