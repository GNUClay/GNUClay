using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.CG;
using GnuClay.ECG;

namespace GnuClay.CGConverters.SGF
{
    public class SGFECGNodeFactory : ISGFNodeFactory
    {
        public IConceptualNode CreateConceptualNode(IConceptualNode parent)
        {
            ConceptualNode tmpConceptualNodeParent = null;

            if(parent != null)
            {
                tmpConceptualNodeParent = (ConceptualNode)parent;
            }

            return new ConceptualNode(tmpConceptualNodeParent);
        }

        public IRelationNode CreateRelationNode(IConceptualNode parent)
        {
            ConceptualNode tmpConceptualNodeParent = null;

            if (parent != null)
            {
                tmpConceptualNodeParent = (ConceptualNode)parent;
            }

            return new RelationNode(tmpConceptualNodeParent);
        }
    }
}
