using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Interfaces
{
    public enum KindOfCoreComponent
    {
        CoreLogicalStorage,
        CoreExecutingSystem,
        CoreObjectsRegistry,
        CoreScopesRegistry,
        CoreFunctionsRegistry,
        CoreTriggersRegistry,
        CoreProcessesRegistry,
        CoreExternalResources,
        CoreCompiler,
        CoreLoaderFromSourceCode,
        CoreLoaderFromSharedLibrary
    }
}
