using GnuClay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreLoaderFromSourceCode
{
    public class CoreLoaderFromSourceCodeComponent : BaseCoreComponent, ICoreLoaderFromSourceCodeComponent
    {
        public CoreLoaderFromSourceCodeComponent(ICoreContext context)
            : base(context, KindOfCoreComponent.CoreLoaderFromSourceCode)
        {
        }
    }
}
