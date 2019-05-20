using GnuClay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreCompiler
{
    public class CoreCompilerComponent : BaseCoreComponent, ICoreCompilerComponent
    {
        public CoreCompilerComponent(ICoreContext context)
            : base(context, KindOfCoreComponent.CoreCompiler)
        {
        }
    }
}
