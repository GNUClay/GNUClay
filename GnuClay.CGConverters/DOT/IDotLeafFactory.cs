using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.DOT
{
    public interface IDotLeafFactory
    {
        DotBaseLeaf CreateLeaf(DotContext context, INode node);
    }
}
