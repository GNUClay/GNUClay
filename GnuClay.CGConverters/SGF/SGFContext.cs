using GnuClay.CGConverters.Helpers.ToStringHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF
{
    public class SGFContext : BaseLeafContext
    {
        public SGFContext()
            : base(new SGFLeafFactory())
        {
        }

        public override string GetClusterName()
        {
            return GetNodeName();
        }
    }
}
