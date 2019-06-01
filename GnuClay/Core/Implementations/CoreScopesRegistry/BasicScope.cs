using GnuClay.CommonClasses;
using GnuClay.Core.CommonInterfaces.CoreCompiler;
using GnuClay.Core.CommonInterfaces.CoreScopesRegistry;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreScopesRegistry
{
    public class BasicScope : BaseLoggedClass, IScope
    {
        public BasicScope(ILog logger)
            : base(logger)
        {
            mBasicMethodsStorage = new BasicMethodsStorage();
            mBasicInheritanceStorage = new BasicInheritanceStorage();
            mBasicLogicalStorage = new BasicLogicalStorage();
        }

        public KindOfScope Kind => KindOfScope.Base;

        private BasicLogicalStorage mBasicLogicalStorage;
        public ILogicalStorage LogicalStorage => mBasicLogicalStorage;

        private BasicInheritanceStorage mBasicInheritanceStorage;
        public IInheritanceStorage InheritanceStorage => mBasicInheritanceStorage;

        private BasicMethodsStorage mBasicMethodsStorage;
        public IMethodsStorage MethodsStorage => mBasicMethodsStorage;

        /// <summary>
        /// Adds information from compiled result.
        /// </summary>
        /// <param name="compiledResult">Added compiled result.</param>
        public void AddFromCompiledResult(ICompiledResult compiledResult)
        {
#if DEBUG
            Debug($"compiledResult = {compiledResult}");
#endif
            //throw new NotImplementedException();
        }
    }
}
