using GnuClay.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class TextParsingAspectContext: BaseTextParsingContext
    {
        public TextParsingAspectContext(GnuClayEngine engine)
            : base(engine)
        {
            NLog.LogManager.GetCurrentClassLogger().Info(nameof(TextParsingAspectContext));
        }
    }
}
