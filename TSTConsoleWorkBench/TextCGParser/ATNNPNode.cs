using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class ATNNPNode
    {
        public ATNNPNode(ATNNPParserContext context, ATNNPParser parent)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");

            mParent = parent;
            mContext = context;
        }

        private ATNNPParserContext mContext = null;
        private ATNNPParser mParent = null;

        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            var token = mContext.GetToken();

            NLog.LogManager.GetCurrentClassLogger().Info($"Run token = {token}");

            var partsOfSpeechList = token.PartOfSpeech;

            foreach(var partOfSpeech in partsOfSpeechList)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"Run partOfSpeech = {partOfSpeech}");

                switch(partOfSpeech)
                {
                    case GrammaticalPartOfSpeech.Article:
                        if(mContext.CurrentNP == null)
                        {
                            mContext.CurrentNP = new NounPhrase();
                            mContext.RootNP = mContext.CurrentNP;
                        }

                        mContext.CurrentNP.Determiner = token;

                        var targetContext = 

                        throw new NotImplementedException();

                    default: throw new ArgumentOutOfRangeException(nameof(partOfSpeech), partOfSpeech.ToString());
                }

                throw new NotImplementedException();
            }            
        }
    }
}
