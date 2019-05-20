using GnuClay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreExternalResources
{
    public class CoreExternalResourcesComponent : BaseCoreComponent, ICoreExternalResourcesComponent
    {
        public CoreExternalResourcesComponent(ICoreContext context)
            : base(context, KindOfCoreComponent.CoreExternalResources)
        {
        }
    }
}
