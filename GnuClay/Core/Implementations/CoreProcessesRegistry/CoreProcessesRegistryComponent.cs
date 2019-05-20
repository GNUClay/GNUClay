using GnuClay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreProcessesRegistry
{
    public class CoreProcessesRegistryComponent : BaseCoreComponent, ICoreProcessesRegistryComponent
    {
        public CoreProcessesRegistryComponent(ICoreContext context)
            : base(context, KindOfCoreComponent.CoreProcessesRegistry)
        {
        }
    }
}
