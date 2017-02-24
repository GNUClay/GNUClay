using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class ATNNPParser
    {
        public ATNNPParser(ATNNPParserContext context)
        {
            mContext = context;
        }

        private ATNNPParserContext mContext = null;

        private List<ATNNPParserResult> mResultList = new List<ATNNPParserResult>();

        public List<ATNNPParserResult> Result
        {
            get
            {
                return mResultList;
            }
        }

        public void AddResult(NounPhrase phrase, ATNNPParserContext context)
        {
            mResultList.Add(new ATNNPParserResult()
            {
                NP = phrase,
                Context = context
            });
        }

        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            var node = new ATNNPNode(mContext, this);

            node.Run();

            NLog.LogManager.GetCurrentClassLogger().Info("End Run");
        }
    }
}
