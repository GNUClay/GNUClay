using GnuClay.Core.CommonInterfaces.CoreScopesRegistry;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreScopesRegistry
{
    public class BasicInheritanceStorage: IInheritanceStorage
    {
        public KindOfScope Kind => KindOfScope.Base;
    }
}
