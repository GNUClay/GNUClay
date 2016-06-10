using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.CG;

namespace GnuClay.CGConverters.DOT
{
    public class DotLeafFactory : IDotLeafFactory
    {
        public DotBaseLeaf CreateLeaf(DotContext context, INode node)
        {
            if(node is IConceptualNode)
            {
                var tmpConceptualNode = node as IConceptualNode;

                if (tmpConceptualNode.Children.Count == 0)
                {
                    return new ConceptualDotLeaf(context, tmpConceptualNode);
                }

                return new SubGraphDotLeaf(context, tmpConceptualNode);
            }

            if(node is IRelationNode)
            {
                var tmpRelationNode = node as IRelationNode;

                return new RelationDotLeaf(context, tmpRelationNode);
            }

            throw new NotImplementedException();
        }
    }
}
