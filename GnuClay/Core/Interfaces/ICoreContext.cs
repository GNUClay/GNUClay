using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Interfaces
{
    public interface ICoreContext : IDisposable
    {
        ICoreLogicalStorageComponent CoreLogicalStorage { get; }
        ICoreExecutingSystemComponent CoreExecutingSystem { get; }
        ICoreObjectsRegistryComponent CoreObjectsRegistry { get; }
        ICoreScopesRegistryComponent CoreScopesRegistry { get; }
        ICoreFunctionsRegistryComponent CoreFunctionsRegistry { get; }
        ICoreTriggersRegistryComponent CoreTriggersRegistry { get; }
        ICoreProcessesRegistryComponent CoreProcessesRegistry { get; }
        ICoreExternalResourcesComponent CoreExternalResources { get; }
        ICoreCompilerComponent CoreCompiler { get; }

        ILog Logger { get; }
        IRemoteDebug RemoteDebugger { get; }
    }
}
