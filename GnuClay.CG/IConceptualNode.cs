using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CG
{
    public interface IConceptualNode: INode
    {
        string ClassName { get; set; }

        IList<INode> Children { get; }
    }
}
