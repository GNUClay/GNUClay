using GnuClay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreLoaderFromSharedLibrary
{
    /// <summary>
    /// Loads and caches shared libraries.
    /// </summary>
    public class CoreLoaderFromSharedLibraryComponent : BaseCoreComponent, ICoreLoaderFromSharedLibraryComponent
    {
        public CoreLoaderFromSharedLibraryComponent(ICoreContext context)
            : base(context, KindOfCoreComponent.CoreLoaderFromSharedLibrary)
        {
        }
    }
}
