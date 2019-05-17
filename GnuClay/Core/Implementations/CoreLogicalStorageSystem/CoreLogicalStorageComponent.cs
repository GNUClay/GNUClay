using GnuClay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreLogicalStorageSystem
{
    public class CoreLogicalStorageComponent: BaseCoreComponent, ICoreLogicalStorageComponent
    {
        public CoreLogicalStorageComponent(ICoreContext context)
            : base(context, KindOfCoreComponent.CoreLogicalStorage)
        {
        }
    }
}
