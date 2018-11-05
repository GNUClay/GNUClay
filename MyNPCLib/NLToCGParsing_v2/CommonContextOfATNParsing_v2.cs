using MyNPCLib.NLToCGParsing.PhraseTree;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class CommonContextOfATNParsing_v2
    {
        private IList<Sentence_v2> mSentencesList = new List<Sentence_v2>();

        public void AddSentence(Sentence_v2 sentence)
        {
#if DEBUG
            //LogInstance.Log($"sentence = {sentence}");
#endif

            mSentencesList.Add(sentence);
        }

        public IList<Sentence_v2> SentencesList
        {
            get
            {
                return mSentencesList;
            }
        }
    }
}
