using GnuClay.Core.CommonInterfaces.CoreCompiler;
using GnuClay.Core.Implementations.CoreCompiler.Parsers;
using GnuClay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreCompiler
{
    public class CoreCompilerComponent : BaseCoreComponent, ICoreCompilerComponent
    {
        public CoreCompilerComponent(ICoreContext context)
            : base(context, KindOfCoreComponent.CoreCompiler)
        {
        }

        public ICompiledResult Compile(string contents)
        {
#if DEBUG
            Debug($"contents = {contents}");
#endif

            var parserContext = new ParserContext(contents, Logger);

            var parser = new Parser(parserContext);
            parser.Run();

            var result = parser.Result;

            return result;
        }
    }
}
