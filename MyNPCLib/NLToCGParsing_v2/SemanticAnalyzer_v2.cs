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

            foreach(var plainSentence in plainSentencesList)
            {
                var sentenceNode = new SentenceNodeOfSemanticAnalyzer_v2(context, plainSentence);
                sentenceNode.Run();
            }

#if DEBUG
            LogInstance.Log("End");
#endif

            return outerConceptualGraph;
        }

        private List<PlainSentence> ConvertToPlainSentencesList(Sentence_v2 sentence)
        {
            var result = new List<PlainSentence>();

            if(sentence.NounPhrasesList.IsEmpty() && sentence.VerbPhrasesList.IsEmpty())
            {
                var item = new PlainSentence();
                item.Aspect = sentence.Aspect;
                item.Tense = sentence.Tense;
                item.Voice = sentence.Voice;
                item.Mood = sentence.Mood;
                item.Modal = sentence.Modal;
                item.IsQuestion = sentence.IsQuestion;
                item.IsNegation = sentence.IsNegation;
                item.ConditionsList = sentence.ConditionsList;
                item.QuestionToObjectsList = sentence.QuestionToObjectsList;
                item.VocativePhrasesList = sentence.VocativePhrasesList;

                result.Add(item);
            }
            else
            {
                if (sentence.NounPhrasesList.IsEmpty())
                {
                    foreach (var verbPhrase in sentence.VerbPhrasesList)
                    {
                        var item = new PlainSentence();
                        item.VerbPhrase = verbPhrase;
                        item.Aspect = sentence.Aspect;
                        item.Tense = sentence.Tense;
                        item.Voice = sentence.Voice;
                        item.Mood = sentence.Mood;
                        item.Modal = sentence.Modal;
                        item.IsQuestion = sentence.IsQuestion;
                        item.IsNegation = sentence.IsNegation;
                        item.ConditionsList = sentence.ConditionsList;
                        item.QuestionToObjectsList = sentence.QuestionToObjectsList;
                        item.VocativePhrasesList = sentence.VocativePhrasesList;

                        result.Add(item);
                    }
                }
                else
                {
                    if(sentence.VerbPhrasesList.IsEmpty())
                    {
                        foreach (var nounPhrase in sentence.NounPhrasesList)
                        {
                            var item = new PlainSentence();
                            item.NounPhrase = nounPhrase;
                            item.Aspect = sentence.Aspect;
                            item.Tense = sentence.Tense;
                            item.Voice = sentence.Voice;
                            item.Mood = sentence.Mood;
                            item.Modal = sentence.Modal;
                            item.IsQuestion = sentence.IsQuestion;
                            item.IsNegation = sentence.IsNegation;
                            item.ConditionsList = sentence.ConditionsList;
                            item.QuestionToObjectsList = sentence.QuestionToObjectsList;
                            item.VocativePhrasesList = sentence.VocativePhrasesList;

                            result.Add(item);
                        }
                    }
                    else
                    {
                        foreach (var nounPhrase in sentence.NounPhrasesList)
                        {
                            foreach (var verbPhrase in sentence.VerbPhrasesList)
                            {
                                var item = new PlainSentence();
                                item.NounPhrase = nounPhrase;
                                item.VerbPhrase = verbPhrase;
                                item.Aspect = sentence.Aspect;
                                item.Tense = sentence.Tense;
                                item.Voice = sentence.Voice;
                                item.Mood = sentence.Mood;
                                item.Modal = sentence.Modal;
                                item.IsQuestion = sentence.IsQuestion;
                                item.IsNegation = sentence.IsNegation;
                                item.ConditionsList = sentence.ConditionsList;
                                item.QuestionToObjectsList = sentence.QuestionToObjectsList;
                                item.VocativePhrasesList = sentence.VocativePhrasesList;

                                result.Add(item);
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
