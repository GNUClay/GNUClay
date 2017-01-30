using GnuClay.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class TextParsingTenseContext: BaseTextParsingContext
    {
        public TextParsingTenseContext(GnuClayEngine engine)
            : base(engine)
        {
            NLog.LogManager.GetCurrentClassLogger().Info(nameof(TextParsingTenseContext));
        }
    }
}
