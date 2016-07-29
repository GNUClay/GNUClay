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

        string FullName { get; set; }

        IConceptualNode Parent { get; }

        IList<INode> InputNodes { get; }

        void AddInputNode(INode node);

        void RemoveInputNode(INode node);

        IList<INode> OutputNodes { get; }

        void AddOutputNode(INode node);

        void RemoveOutputNode(INode node);
    }
}
