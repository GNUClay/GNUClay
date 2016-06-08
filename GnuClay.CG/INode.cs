using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CG
{
    public interface INode
    {
        bool IsConcept { get; }

        bool IsRelation { get; }

        string Name { get; set; }

        string FullName { get; }

        IConceptualNode Parent { get; }

        IList<IConceptualNode> Annotations { get; }

        IList<INode> InputNodes { get; }

        IList<INode> OutputNodes { get; }
    }
}
