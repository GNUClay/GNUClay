using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Inheritance
{
    public class CyclicInheritanceException: Exception
    {
        public CyclicInheritanceException(string subName, string superName)
            : base($"Cyclic inheritence `{subName}` form `{superName}`.")
        {
        }
    }
}
