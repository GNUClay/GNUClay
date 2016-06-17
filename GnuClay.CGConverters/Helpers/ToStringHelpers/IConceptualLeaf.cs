using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.Helpers.ToStringHelpers
{
    public interface IConceptualLeaf: IBaseLeaf
    {
        IConceptualNode Node { get; }
    }
}
