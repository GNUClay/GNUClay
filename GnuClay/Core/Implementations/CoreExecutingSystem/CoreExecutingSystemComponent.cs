using GnuClay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreExecutingSystem
{
    public class CoreExecutingSystemComponent: BaseCoreComponent, ICoreExecutingSystemComponent
    {
        public CoreExecutingSystemComponent(ICoreContext context)
            : base(context, KindOfCoreComponent.CoreExecutingSystem)
        {
        }
    }
}
