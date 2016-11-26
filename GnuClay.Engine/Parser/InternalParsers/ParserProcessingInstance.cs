using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.Parser.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class ParserProcessingInstance
    {
        public ParserProcessingInstance(GnuClayEngineComponentContext context)
        {
            mContext = new ParsingContext();
            mContext.MainContext = context;         
        }

        private ParsingContext mContext = null;

        public GnuClayQuery Parse(string queryText)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Parse queryText = `{queryText}`");

            mContext.Lexer = new Lexer(queryText);

            var result = new GnuClayQuery();

            Token token = null;

            while((token = mContext.GetToken()) != null)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"token = `{token}`");
            }

            NLog.LogManager.GetCurrentClassLogger().Info("Finish");

            return result;
        }
    }
}
