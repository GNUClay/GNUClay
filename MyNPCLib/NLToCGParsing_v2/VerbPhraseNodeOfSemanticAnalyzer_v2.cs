using MyNPCLib.CG;
using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class VerbPhraseNodeOfSemanticAnalyzer_v2 : BaseNodeOfSemanticAnalyzer_v2
    {
        public VerbPhraseNodeOfSemanticAnalyzer_v2(ContextOfSemanticAnalyzer context, PlainSentence sentence, VerbPhrase_v2 verbPhrase)
            : base(context)
        {
            mSentence = sentence;
            mVerbPhrase = verbPhrase;
        }

        private PlainSentence mSentence;
        private VerbPhrase_v2 mVerbPhrase;
        private ConceptCGNode mConcept;

        public ResultOfNodeOfSemanticAnalyzer Run()
        {
#if DEBUG
            LogInstance.Log($"mVerbPhrase = {mVerbPhrase}");
#endif

            var result = new ResultOfNodeOfSemanticAnalyzer();
            var resultPrimaryRolesDict = result.PrimaryRolesDict;
            var resultSecondaryRolesDict = result.SecondaryRolesDict;
            var verb = mVerbPhrase.Verb;
            var conceptualGraph = Context.ConceptualGraph;
            mConcept = new ConceptCGNode();
            result.RootConcept = mConcept;
            mConcept.Parent = conceptualGraph;

            mConcept.Name = GetName(verb);

#if DEBUG
            LogInstance.Log($"verb = {verb}");
#endif

            var verbsRolesStorage = new RolesStorageOfSemanticAnalyzer();

            var verbFullLogicalMeaning = verb.FullLogicalMeaning;

            foreach (var logicalMeaning in verbFullLogicalMeaning)
            {
#if DEBUG
                LogInstance.Log($"logicalMeaning = {logicalMeaning}");
#endif

                PrimaryRolesDict.Add(logicalMeaning, mConcept);
                resultPrimaryRolesDict.Add(logicalMeaning, mConcept);
                verbsRolesStorage.Add(logicalMeaning, mConcept);
            }

            if (verbFullLogicalMeaning.IsEmpty())
            {
                return result;
            }

            var nounObjectsList = mVerbPhrase.ObjectsList;

            var objectsRolesStorage = new RolesStorageOfSemanticAnalyzer();

            if (!nounObjectsList.IsEmpty())
            {
#if DEBUG
                LogInstance.Log($"nounObjectsList.Count = {nounObjectsList.Count}");
#endif

                foreach (var nounObject in nounObjectsList)
                {
#if DEBUG
                    LogInstance.Log($"nounObject = {nounObject}");
#endif

                    throw new NotImplementedException();
                }
            }

            return result;
        }
    }
}
