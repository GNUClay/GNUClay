using GnuClay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreLoaderFromSharedLibrary
{
    /// <summary>
    /// Just gets shared libraries from common storage.
    /// </summary>
    public class ProxyCoreLoaderFromSharedLibraryComponent: BaseCoreComponent, ICoreLoaderFromSharedLibraryComponent
    {
        public ProxyCoreLoaderFromSharedLibraryComponent(ICoreContext context)
            : base(context, KindOfCoreComponent.CoreLoaderFromSharedLibrary)
        {
        }
    }
}
