using GnuClay.Core.CommonInterfaces.CoreScopesRegistry;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreScopesRegistry
{
    public class BasicLogicalStorage: ILogicalStorage
    {
        public KindOfScope Kind => KindOfScope.Base;
    }
}
