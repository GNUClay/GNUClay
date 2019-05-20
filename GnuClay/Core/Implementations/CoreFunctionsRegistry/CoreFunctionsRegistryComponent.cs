using GnuClay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreFunctionsRegistry
{
    public class CoreFunctionsRegistryComponent : BaseCoreComponent, ICoreFunctionsRegistryComponent
    {
        public CoreFunctionsRegistryComponent(ICoreContext context)
            : base(context, KindOfCoreComponent.CoreFunctionsRegistry)
        {
        }
    }
}
