using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ICG
{
    public class RelationNode : BaseNode, IRelationNode
    {
        public RelationNode()
        {
        }

        public RelationNode(ConceptualNode parent)
            : base(parent)
        {
        }

        public override bool IsRelation
        {
            get
            {
                return true;
            }
        }
    }
}
