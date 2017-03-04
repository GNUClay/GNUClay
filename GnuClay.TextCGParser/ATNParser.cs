using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.TextCGParser
{
    public class ATNParser
    {
        public ATNParser(List<ExtendToken> tokens)
        {
            mTokens = tokens;
        }

        private List<ExtendToken> mTokens = null;

        private List<Sentence> mResultList = new List<Sentence>();

        public List<Sentence> Result
        {
            get
            {
                return mResultList;
            }
        }

        public void AddResult(Sentence phrase)
        {
            mResultList.Add(phrase);
        }

        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            var context = new TextPhraseContext(mTokens);

            var node = new ATNNode(context, this);

            node.Run();

            NLog.LogManager.GetCurrentClassLogger().Info("End Run");
        }
    }
}
