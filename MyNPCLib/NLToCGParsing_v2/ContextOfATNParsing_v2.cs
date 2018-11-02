using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing.PhraseTree;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class ContextOfATNParsing_v2
    {
        public ContextOfATNParsing_v2(string text, IWordsDict wordsDict, CommonContextOfATNParsing_v2 commonContext)
        {
            CommonContext = commonContext;
            mATNExtendedLexer = new ATNExtendedLexer(text, wordsDict);
        }

        private ContextOfATNParsing_v2()
        {
        }

        private CommonContextOfATNParsing_v2 CommonContext;
        private ATNExtendedLexer mATNExtendedLexer;
        public Sentence Sentence { get; set; }

        public ContextOfATNParsing_v2 Fork()
        {
            var result = new ContextOfATNParsing_v2();
            result.CommonContext = CommonContext;
            result.mATNExtendedLexer = mATNExtendedLexer.Fork();
            result.Sentence = Sentence?.Fork();
            return result;
        }

        public IList<ATNExtendedToken> GetСlusterOfExtendedTokens()
        {
            return mATNExtendedLexer.GetСlusterOfExtendedTokens();
        }
    }
}
