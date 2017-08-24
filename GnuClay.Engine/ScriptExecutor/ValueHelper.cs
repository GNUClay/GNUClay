using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public static class ValueHelper
    {
        public static bool NEquals(IValue c1, IValue c2)
        {
            if (ReferenceEquals(c1, c2))
            {
                return true;
            }

            if (c1 == null)
            {
                return false;
            }

            if (c2 == null)
            {
                return false;
            }

            if (c1.TypeKey != c2.TypeKey)
            {
                return false;
            }

            if (c1.Kind == KindOfValue.Value)
            {
                if (!c1.Value.Equals(c2.Value))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
