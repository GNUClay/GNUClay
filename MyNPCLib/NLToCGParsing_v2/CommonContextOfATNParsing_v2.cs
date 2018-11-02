using MyNPCLib.NLToCGParsing.PhraseTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class CommonContextOfATNParsing_v2
    {
        private IList<Sentence> mSentencesList = new List<Sentence>();

        public void AddSentence(Sentence sentence)
        {
#if DEBUG
            //LogInstance.Log($"sentence = {sentence}");
#endif

            mSentencesList.Add(sentence);
        }

        public IList<Sentence> SentencesList
        {
            get
            {
                return mSentencesList;
            }
        }
    }
}
