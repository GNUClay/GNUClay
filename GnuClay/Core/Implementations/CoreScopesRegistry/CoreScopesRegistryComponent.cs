using GnuClay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreScopesRegistry
{
    public class CoreScopesRegistryComponent : BaseCoreComponent, ICoreScopesRegistryComponent
    {
        public CoreScopesRegistryComponent(ICoreContext context)
            : base(context, KindOfCoreComponent.CoreScopesRegistry)
        {
        }
    }
}
