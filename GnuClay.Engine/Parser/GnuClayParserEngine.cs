using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.Parser.CommonData;
using GnuClay.Engine.Parser.InternalParsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser
{
    public class GnuClayParserEngine : BaseGnuClayEngineComponent
    {
        public GnuClayParserEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("GnuClayParserEngine");
        }

        public GnuClayQuery Parse(string queryText)
        {
            var tmpParserProcess = new ParserProcessingInstance(Context);
            return tmpParserProcess.Parse(queryText);
        }
    }
}
