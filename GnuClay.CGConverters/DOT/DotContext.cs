using GnuClay.CG;
using GnuClay.CGConverters.Helpers.ToStringHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.DOT
{
    public class DotContext: BaseLeafContext
    {
        public DotContext()
            : base(new DotLeafFactory())
        {
        }
    }
}
