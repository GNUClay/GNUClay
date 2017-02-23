using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonUtils.TypeHelpers
{
    public static class _StringBuilderHelper
    {
        public static void TruncateEnd(this StringBuilder sb)
        {
            if(sb.Length == 0)
            {
                return;
            }

            sb.Remove(sb.Length - 1, 1);
        }
    }
}
