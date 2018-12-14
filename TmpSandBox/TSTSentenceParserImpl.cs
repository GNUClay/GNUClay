using MyNPCLib;
using MyNPCLib.ConvertingCGToInternal;
using MyNPCLib.ConvertingInternalCGToPersistLogicalData;
using MyNPCLib.DebugHelperForPersistLogicalData;
using MyNPCLib.Dot;
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
            mSemanticAnalyzer = new SemanticAnalyzer_v2(wordsDict);

            mEntityDictionary = new EntityDictionary();
        }

        private EnglishMaximumEntropySentenceDetector mSentenceDetector;
        private IWordsDict mWordsDict;
        private string mBasePath;
        private SemanticAnalyzer_v2 mSemanticAnalyzer;
        public bool ConvertToConceptualGraph { get; set; }
        private EntityDictionary mEntityDictionary;

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

                    if(ConvertToConceptualGraph)
                    {
                        var graph = mSemanticAnalyzer.Run(resultItem);

                        LogInstance.Log($"graph = {graph}");

                        var dotStr = DotConverter.ConvertToString(graph);

                        LogInstance.Log($"dotStr = {dotStr}");

                        var internalCG = ConvertorCGToInternal.Convert(graph, mEntityDictionary);

                        dotStr = DotConverter.ConvertToString(internalCG);

                        LogInstance.Log($"dotStr (2) = {dotStr}");

                        var ruleInstancesList = ConvertorInternalCGToPersistLogicalData.ConvertConceptualGraph(internalCG, mEntityDictionary);

                        LogInstance.Log($"ruleInstancesList.Count = {ruleInstancesList.Count}");

                        foreach (var ruleInstance in ruleInstancesList)
                        {
                            //LogInstance.Log($"ruleInstance = {ruleInstance}");

                            {
                                var debugStr = DebugHelperForRuleInstance.ToString(ruleInstance);

                                LogInstance.Log($"debugStr = {debugStr}");
                            }
                        }
                    }
                }
            }
        }
    }
}
