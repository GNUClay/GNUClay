using GnuClay.Core.CommonInterfaces.CoreScopesRegistry;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Interfaces
{
    public interface ICoreScopesRegistryComponent: ICoreComponent
    {
        IScope BaseScope { get; }
    }
}
