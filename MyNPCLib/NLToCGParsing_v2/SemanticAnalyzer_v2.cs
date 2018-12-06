using MyNPCLib.CG;
using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class SemanticAnalyzer_v2
    {
        public SemanticAnalyzer_v2(IWordsDict wordDict)
        {
            mWordsDict = wordDict;
        }

        private IWordsDict mWordsDict;

        public ConceptualGraph Run(Sentence_v2 sentence)
        {
#if DEBUG
            LogInstance.Log($"sentence = {sentence}");
#endif
            var outerConceptualGraph = new ConceptualGraph();
            var context = new ContextOfSemanticAnalyzer();
            context.OuterConceptualGraph = outerConceptualGraph;
            context.WordsDict = mWordsDict;

            var plainSentencesList = ConvertToPlainSentencesList(sentence);

#if DEBUG
            LogInstance.Log($"plainSentencesList.Count = {plainSentencesList.Count}");
#endif

            throw new NotImplementedException();

            //var sentenceNode = new SentenceNodeOfSemanticAnalyzer_v2(context, sentence);
            //var sentenceResult = sentenceNode.Run();

#if DEBUG
            LogInstance.Log($"sentenceResult = {sentenceResult}");
#endif

            var result = outerConceptualGraph;

#if DEBUG
            LogInstance.Log("End");
#endif

            return result;
        }

        private List<PlainSentence> ConvertToPlainSentencesList(Sentence_v2 sentence)
        {
            var result = new List<PlainSentence>();

            foreach(var nounPhrase in sentence.NounPhrasesList)
            {
                foreach(var verbPhrase in sentence.VerbPhrasesList)
                {
                    var item = new PlainSentence();
                    item.NounPhrase = nounPhrase;
                    item.VerbPhrase = verbPhrase;
                    item.Aspect = sentence.Aspect;
                    item.Tense = sentence.Tense;
                    item.Voice = sentence.Voice;
                    item. = sentence.;
                    item. = sentence.;
                    item. = sentence.;
                    item. = sentence.;
                    item. = sentence.;
                    /*
        public GrammaticalMood Mood { get; set; } = GrammaticalMood.Undefined;
        public KindOfModal Modal { get; set; } = KindOfModal.Undefined;
        public bool IsQuestion { get; set; }
        public bool IsNegation { get; set; }
                public List<BaseWordPhrase_v2> ConditionsList { get; set; } = new List<BaseWordPhrase_v2>();
        public List<BaseWordPhrase_v2> QuestionToObjectsList { get; set; } = new List<BaseWordPhrase_v2>();
        public List<NounPhrase_v2> VocativePhrasesList { get; set; } = new List<NounPhrase_v2>();
                    */

                    result.Add(item);
                }
            }

            return result;
        }
    }
}
