using MyNPCLib;
using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing_v2;
using MyNPCLib.SimpleWordsDict;
using OpenNLP.Tools.SentenceDetect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TmpSandBox
{
    public class TSTSentenceParserUnknownWordsDetectorImpl: ITSTSentenceParserImpl
    {
        public TSTSentenceParserUnknownWordsDetectorImpl(IWordsDict wordsDict, string basePath, EnglishMaximumEntropySentenceDetector sentencesDetector, List<string> unknownWordsList)
        {
            mWordsDict = wordsDict;
            mBasePath = basePath;
            mSentenceDetector = sentencesDetector;
            mUnknownWordsList = unknownWordsList;
        }

        private EnglishMaximumEntropySentenceDetector mSentenceDetector;
        private IWordsDict mWordsDict;
        private string mBasePath;
        private List<string> mUnknownWordsList;

        public void Parse(string text)
        {
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

                while(true)
                {
                    var extendedTokensList = context.GetСlusterOfExtendedTokens();

#if DEBUG
                    LogInstance.Log($"extendedTokensList.Count = {extendedTokensList.Count}");
#endif

                    if(extendedTokensList.Count == 0)
                    {
                        break;
                    }

                    if(!extendedTokensList.Any(p => p.Kind == KindOfATNToken.Word))
                    {
                        continue;
                    }

                    if(extendedTokensList.Any(p => p.PartOfSpeech == GrammaticalPartOfSpeech.Undefined))
                    {
                        var word = extendedTokensList.First(p => p.PartOfSpeech == GrammaticalPartOfSpeech.Undefined).Content;

#if DEBUG
                        LogInstance.Log($"extendedTokensList.First(p => p.PartOfSpeech == GrammaticalPartOfSpeech.Undefined) = {extendedTokensList.First(p => p.PartOfSpeech == GrammaticalPartOfSpeech.Undefined)}");
                        LogInstance.Log($"word = {word}");
#endif

                        foreach(var extendedToken in extendedTokensList)
                        {
                            LogInstance.Log($"extendedToken = {extendedToken}");
                        }

                        mUnknownWordsList.Add(word);
                    }
                }
            }
        }
    }
}
