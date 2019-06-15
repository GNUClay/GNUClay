using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Interfaces
{
    public interface ICoreLoaderFromSourceCodeComponent: ICoreComponent
    {
        void LoadAppFromFile(string fileName);
        void LoadFromFile(string fileName);
    }
}
