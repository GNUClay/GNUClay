using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Interfaces
{
    public interface ICoreComponent: IDisposable
    {
        KindOfCoreComponent KindOfComponent { get; }
        void InitRefsToOtherComponents();
    }
}
