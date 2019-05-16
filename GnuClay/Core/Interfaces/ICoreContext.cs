using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Interfaces
{
    public interface ICoreContext : IDisposable
    {
        ICoreLogicalStorageComponent CoreLogicalStorage { get; }
        ICoreExecutingSystemComponent CoreExecutingSystem { get; }
        ICoreClassRegistryComponent CoreClassRegistry { get; }
        ICoreScopesRegistryComponent CoreScopesRegistry { get; }
        ICoreFunctionsRegistryComponent CoreFunctionsRegistry { get; }
        ICoreTriggersRegistryComponent CoreTriggersRegistry { get; }
        ICoreProcessesRegistryComponent CoreProcessesRegistry { get; }
        ICoreExternalResourcesComponent CoreExternalResources { get; }
        ICoreCompilerComponent CoreCompiler { get; }
    }
}
