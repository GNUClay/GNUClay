using MyNPCLib.NLToCGParsing.PhraseTree;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Linq;
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

            if(sentence.Tense == GrammaticalTenses.All)
            {
                sentence.Tense = GrammaticalTenses.Present;
            }

            mSentencesList.Add(sentence);

            if(mSentencesList.Any(p => p.Mood == GrammaticalMood.Imperative) && mSentencesList.Any(p => p.Mood != GrammaticalMood.Imperative))
            {
                var nonImperativeSentence = mSentencesList.First(p => p.Mood != GrammaticalMood.Imperative);
                mSentencesList.Remove(nonImperativeSentence);
            }
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
