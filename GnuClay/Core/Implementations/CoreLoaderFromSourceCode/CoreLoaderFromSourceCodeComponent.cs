using GnuClay.CommonHelpers.FileHelpers;
using GnuClay.Core.CommonInterfaces.CoreCompiler;
using GnuClay.Core.Implementations.CoreCompiler;
using GnuClay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreLoaderFromSourceCode
{
    public class CoreLoaderFromSourceCodeComponent : BaseCoreComponent, ICoreLoaderFromSourceCodeComponent
    {
        public CoreLoaderFromSourceCodeComponent(ICoreContext context)
            : base(context, KindOfCoreComponent.CoreLoaderFromSourceCode)
        {
        }

        public void LoadFromFile(string fileName)
        {
#if DEBUG
            Debug($"fileName = {fileName}");
#endif

            var contents = FileHelper.ReadAllContent(fileName);

#if DEBUG
            Debug($"contents = {contents}");
#endif

            var compiledResult = CoreCompiler.Compile(contents);

#if DEBUG
            Debug($"compiledResult = {compiledResult}");
#endif

            CoreScopesRegistry.BaseScope.AddFromCompiledResult(compiledResult);
        }
    }
}
