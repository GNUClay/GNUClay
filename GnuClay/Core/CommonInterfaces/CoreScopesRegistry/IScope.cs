using GnuClay.Core.CommonInterfaces.CoreCompiler;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.CommonInterfaces.CoreScopesRegistry
{
    public interface IScope
    {
        KindOfScope Kind { get; }

        /// <summary>
        /// Adds information from compiled result.
        /// </summary>
        /// <param name="compiledResult">Added compiled result.</param>
        void AddFromCompiledResult(ICompiledResult compiledResult);

        ILogicalStorage LogicalStorage { get; }
        IInheritanceStorage InheritanceStorage { get; }
        IMethodsStorage MethodsStorage { get; }
    }
}
