using GnuClay.Engine;
using GnuClay.Engine.CommonStorages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public abstract class BaseTextParsingContext
    {
        protected BaseTextParsingContext(GnuClayEngine engine)
        {
            Engine = engine;
            DataDictionary = Engine.DataDictionary;
        }

        protected GnuClayEngine Engine = null;
        protected StorageDataDictionary DataDictionary = null;
    }
}
