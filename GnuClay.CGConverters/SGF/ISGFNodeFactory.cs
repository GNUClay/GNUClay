using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF
{
    public interface ISGFNodeFactory
    {
        IConceptualNode CreateConceptualNode(IConceptualNode parent);

        IRelationNode CreateRelationNode(IConceptualNode parent);
    }
}
