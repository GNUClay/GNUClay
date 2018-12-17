using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class ATNParser_v2
    {
        public ATNParser_v2(IWordsDict wordsDict)
        {
            mWordsDict = wordsDict;
        }

        private IWordsDict mWordsDict;

        public IList<Sentence_v2> Run(string text)
        {
#if DEBUG
            //LogInstance.Log($"text = {text}");
#endif

            var commonContext = new CommonContextOfATNParsing_v2();
            var context = new ContextOfATNParsing_v2(text, mWordsDict, commonContext);

            var atnNode = new ATNInitNode_v2(context);
            atnNode.Run();

            var sentencesList = commonContext.SentencesList;

            if (sentencesList.Count > 1)
            {
                sentencesList = sentencesList.Distinct(new ComparerOfSentence_v2()).ToList();
            }

#if DEBUG
            //LogInstance.Log($"sentencesList.Count = {sentencesList.Count}");
            //foreach(var tmpSentences in sentencesList)
            //{
            //    LogInstance.Log($"tmpSentences = {tmpSentences}");
            //}
#endif

            return sentencesList;
        }
    }
}
