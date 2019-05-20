using GnuClay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreObjectsRegistry
{
    public class CoreObjectsRegistryComponent : BaseCoreComponent, ICoreObjectsRegistryComponent
    {
        public CoreObjectsRegistryComponent(ICoreContext context)
            : base(context, KindOfCoreComponent.CoreObjectsRegistry)
        {
        }
    }
}
