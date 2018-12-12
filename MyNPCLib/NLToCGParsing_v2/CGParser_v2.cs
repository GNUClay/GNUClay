using MyNPCLib.CG;
using MyNPCLib.NLToCGParsing;
using OpenNLP.Tools.SentenceDetect;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class CGParser_v2
    {
        public CGParser_v2(CGParserOptions_v2 options)
        {
            var modelPath = OpenNLPPathsHelper.EnglishSDnbinPath(options.BasePath);
#if DEBUG
            //LogInstance.Log($"modelPath = {modelPath}");
#endif

            mSentenceDetector = new EnglishMaximumEntropySentenceDetector(modelPath);

            mATNParser = new ATNParser_v2(options.WordsDict);
            mSemanticAnalyzer = new SemanticAnalyzer_v2(options.WordsDict);
        }

        private EnglishMaximumEntropySentenceDetector mSentenceDetector;
        private ATNParser_v2 mATNParser;
        private SemanticAnalyzer_v2 mSemanticAnalyzer;
        private readonly object mRunLockObj = new object();

        public GCParsingResult Run(string text)
        {
            lock (mRunLockObj)
            {
#if DEBUG
                //LogInstance.Log($"text = {text}");
#endif

                var result = new GCParsingResult();

                if (string.IsNullOrWhiteSpace(text))
                {
                    return result;
                }

                var itemsList = new List<ConceptualGraph>();
                result.Items = itemsList;

                var sentencesList = mSentenceDetector.SentenceDetect(text);

#if DEBUG
                //LogInstance.Log($"sentencesList.Length = {sentencesList.Length}");
#endif

                var isFirst = true;
                ConceptualGraph prevGraph = null;

                foreach (var sentence in sentencesList)
                {
#if DEBUG
                    //LogInstance.Log($"sentence = {sentence}");
#endif

                    var itemsResultList = RunSentence(sentence);

                    foreach (var itemResult in itemsResultList)
                    {
                        itemsList.Add(itemResult);

                        if (isFirst)
                        {
                            isFirst = false;
                            result.FistItem = itemResult;
                        }
                        else
                        {
                            itemResult.PrevGraph = prevGraph;
                        }

                        prevGraph = itemResult;
                    }
                }

                return result;
            }
        }

        private IList<ConceptualGraph> RunSentence(string text)
        {
#if DEBUG
            //LogInstance.Log($"text = {text}");
#endif

            var result = new List<ConceptualGraph>();
            var sentencesList = mATNParser.Run(text);

#if DEBUG
            //LogInstance.Log($"sentencesList.Count = {sentencesList.Count}");
#endif
            foreach (var sentence in sentencesList)
            {
#if DEBUG
                //LogInstance.Log($"sentence = {sentence}");
#endif

                var itemResult = mSemanticAnalyzer.Run(sentence);
                result.Add(itemResult);
            }

            return result;
        }
    }
}
