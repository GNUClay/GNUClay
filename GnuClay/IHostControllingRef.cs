using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay
{
    public interface IHostControllingRef
    {
        void SetEngine(IEngineInternalRef engine);
    }
}
