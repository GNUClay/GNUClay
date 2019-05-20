using GnuClay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreTriggersRegistry
{
    public class CoreTriggersRegistryComponent : BaseCoreComponent, ICoreTriggersRegistryComponent
    {
        public CoreTriggersRegistryComponent(ICoreContext context)
            : base(context, KindOfCoreComponent.CoreTriggersRegistry)
        {
        }
    }
}
