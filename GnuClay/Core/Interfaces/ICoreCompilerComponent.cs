using GnuClay.Core.CommonInterfaces.CoreCompiler;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Interfaces
{
    public interface ICoreCompilerComponent: ICoreComponent
    {
        ICompiledResult Compile(string contents);
    }
}
