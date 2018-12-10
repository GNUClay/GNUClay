using MyNPCLib.CG;
using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class AjectivePhraseNodeOfSemanticAnalyzer_v2 : BaseNodeOfSemanticAnalyzer_v2
    {
        public AjectivePhraseNodeOfSemanticAnalyzer_v2(ContextOfSemanticAnalyzer context, PlainSentence sentence, AdjectivePhrase_v2 adjectivePhrase)
            : base(context)
        {
            mSentence = sentence;
            mAdjectivePhrase = adjectivePhrase;
        }

        private PlainSentence mSentence;
        private AdjectivePhrase_v2 mAdjectivePhrase;
        private ConceptCGNode mConcept;

        public ResultOfNodeOfSemanticAnalyzer Run()
        {
#if DEBUG
            LogInstance.Log($"mAdjectivePhrase = {mAdjectivePhrase}");
#endif

            var result = new ResultOfNodeOfSemanticAnalyzer();
            var resultPrimaryRolesDict = result.PrimaryRolesDict;
            var resultSecondaryRolesDict = result.SecondaryRolesDict;
            var conceptualGraph = Context.ConceptualGraph;

            var ajective = mAdjectivePhrase.Adjective;

#if DEBUG
            LogInstance.Log($"ajective = {ajective}");
#endif

            mConcept = new ConceptCGNode();
            result.RootConcept = mConcept;
            mConcept.Parent = conceptualGraph;
            mConcept.Name = GetName(ajective);

            var ajectiveFullLogicalMeaning = ajective.FullLogicalMeaning;

            if (ajectiveFullLogicalMeaning.IsEmpty())
            {
                return result;
            }

            foreach (var logicalMeaning in ajectiveFullLogicalMeaning)
            {
#if DEBUG
                //LogInstance.Log($"logicalMeaning = {logicalMeaning}");
#endif

                PrimaryRolesDict.Add(logicalMeaning, mConcept);
                resultPrimaryRolesDict.Add(logicalMeaning, mConcept);
            }

#if DEBUG
            //LogInstance.Log($"PrimaryRolesDict = {PrimaryRolesDict}");
            //LogInstance.Log("End");
#endif

            return result;
        }
    }
}
