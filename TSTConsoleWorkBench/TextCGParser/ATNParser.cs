using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class ATNParser
    {
        public ATNParser(List<ExtendToken> tokens)
        {
            mTokens = tokens;
        }

        private List<ExtendToken> mTokens = null;

        private List<Phrase> mResultList = new List<Phrase>();

        public List<Phrase> Result
        {
            get
            {
                return mResultList;
            }
        }

        public void AddResult(Phrase phrase)
        {
            mResultList.Add(phrase);
        }

        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            var context = new TextPhraseContext();

            context.Tokens = new Queue<ExtendToken>(mTokens);

            var node = new ATNNode(context, this);

            node.Run();

            NLog.LogManager.GetCurrentClassLogger().Info("End Run");
        }
    }
}
