using GnuClay.CG;
using GnuClay.CGConverters.DOT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.Helpers.ToStringHelpers
{
    public interface ILeafContext
    {
        IBaseLeaf CreateLeaf(INode node);

        string GetNodeName();

        string GetClusterName();

        void RegLeaf(INode node, IBaseLeaf leaf);

        IBaseLeaf GetLeaf(INode node);

        ILeafFactory LeafFactory { get; }
    }
}
