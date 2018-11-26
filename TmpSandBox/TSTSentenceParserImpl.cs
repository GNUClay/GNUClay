using MyNPCLib;
using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing_v2;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using MyNPCLib.SimpleWordsDict;
using OpenNLP.Tools.SentenceDetect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TmpSandBox
{
    public class TSTSentenceParserImpl: ITSTSentenceParserImpl
    {
        public TSTSentenceParserImpl(IWordsDict wordsDict, string basePath, EnglishMaximumEntropySentenceDetector sentencesDetector)
        {
            mWordsDict = wordsDict;
            mBasePath = basePath;
            mSentenceDetector = sentencesDetector;
        }

        private EnglishMaximumEntropySentenceDetector mSentenceDetector;
        private IWordsDict mWordsDict;
        private string mBasePath;

        public void Parse(string text)
        {
            var cgParserOptions = new CGParserOptions();
            cgParserOptions.WordsDict = mWordsDict;
            cgParserOptions.BasePath = AppDomain.CurrentDomain.BaseDirectory;

            var sentencesList = mSentenceDetector.SentenceDetect(text);

#if DEBUG
            LogInstance.Log($"sentencesList.Length = {sentencesList.Length}");
#endif

            foreach (var sentence in sentencesList)
            {
#if DEBUG
                LogInstance.Log($"sentence = {sentence}");
#endif

                var commonContext = new CommonContextOfATNParsing_v2();
                var context = new ContextOfATNParsing_v2(sentence, mWordsDict, commonContext);
                var atnNode = new ATNInitNode_v2(context);
                atnNode.Run();

                var resultList = commonContext.SentencesList;

                LogInstance.Log($"resultList.Count = {resultList.Count}");

                if (resultList.Count > 1)
                {
                    resultList = resultList.Distinct(new ComparerOfSentence_v2()).ToList();

                    LogInstance.Log($"resultList.Count (2) = {resultList.Count}");

                    //throw new NotImplementedException();
                }

                foreach (var resultItem in resultList)
                {
                    LogInstance.Log($"resultItem.GetHashCode() = {resultItem.GetHashCode()}");
                    LogInstance.Log($"resultItem = {resultItem}");
                }
            }
        }
    }
}
