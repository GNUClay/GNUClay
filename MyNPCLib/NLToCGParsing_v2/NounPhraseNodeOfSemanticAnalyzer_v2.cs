using MyNPCLib.CG;
using MyNPCLib.CommonServiceGrammaticalElements;
using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class NounPhraseNodeOfSemanticAnalyzer_v2: BaseNodeOfSemanticAnalyzer_v2
    {
        public NounPhraseNodeOfSemanticAnalyzer_v2(ContextOfSemanticAnalyzer context, PlainSentence sentence, NounPhrase_v2 nounPhrase)
            : base(context)
        {
            mSentence = sentence;
            mNounPhrase = nounPhrase;
        }

        private PlainSentence mSentence;
        private NounPhrase_v2 mNounPhrase;
        private ConceptCGNode mConcept;

        public ResultOfNodeOfSemanticAnalyzer Run()
        {
#if DEBUG
            //LogInstance.Log($"mNounPhrase = {mNounPhrase}");
#endif

            var result = new ResultOfNodeOfSemanticAnalyzer();
            var resultPrimaryRolesDict = result.PrimaryRolesDict;
            var resultSecondaryRolesDict = result.SecondaryRolesDict;

            if(mNounPhrase.NumberValue.HasValue)
            {
                throw new NotImplementedException();
            }
            
            var conceptualGraph = Context.ConceptualGraph;

            var noun = mNounPhrase.Noun;

#if DEBUG
            //LogInstance.Log($"noun = {noun}");
#endif

            if (noun == null)
            {
                return result;
            }

            ProcessNoun(result);

            var determinersList = mNounPhrase.DeterminersList;
            var ajectivesList = mNounPhrase.AdjectivePhrasesList;

            if (!determinersList.IsEmpty())
            {
                //mHasDeterminers = true;

#if DEBUG
                //LogInstance.Log($"determinersList.Count = {determinersList.Count}");
#endif

                foreach (var determiner in determinersList)
                {
#if DEBUG
                    //LogInstance.Log($"determiner = {determiner}");
#endif
                    CreateDeterminerMark(mConcept, noun, determiner);
                }

                //throw new NotImplementedException();
            }

            if (!ajectivesList.IsEmpty())
            {
#if DEBUG
                //LogInstance.Log($"ajectivesList.Count = {ajectivesList.Count}");
#endif

                foreach (var ajective in ajectivesList)
                {
#if DEBUG
                    //LogInstance.Log($"ajective = {ajective}");
#endif

                    var ajectiveNode = new AjectivePhraseNodeOfSemanticAnalyzer_v2(Context, mSentence, ajective);
                    var ajectiveNodeResult = ajectiveNode.Run();

#if DEBUG
                    //LogInstance.Log($"ajectiveNodeResult = {ajectiveNodeResult}");
#endif
                    var role = ajective.Adjective.LogicalMeaning.FirstOrDefault();

#if DEBUG
                    //LogInstance.Log($"role = {role}");
#endif

                    if (!string.IsNullOrWhiteSpace(role))
                    {
                        var ajectiveConcept = ajectiveNodeResult.RootConcept;

#if DEBUG
                        //LogInstance.Log($"ajectiveConcept = {ajectiveConcept.ToBriefString()}");
#endif

                        var ajectiveRelation = new RelationCGNode();
                        ajectiveRelation.Parent = conceptualGraph;
                        ajectiveRelation.Name = role;

                        MarkAsEntityCondition(ajectiveRelation);

                        ajectiveRelation.AddInputNode(mConcept);
                        ajectiveRelation.AddOutputNode(ajectiveConcept);
                    }
                }
            }

            var additionalInfoList = mNounPhrase.AdditionalInfoList;

            if(!additionalInfoList.IsEmpty())
            {
                throw new NotImplementedException();
            }

            var possesiveList = mNounPhrase.PossesiveList;

            if(!possesiveList.IsEmpty())
            {
                throw new NotImplementedException();
            }

            var nounFullLogicalMeaning = noun.FullLogicalMeaning;

            if (nounFullLogicalMeaning.IsEmpty())
            {
                return result;
            }

            foreach (var logicalMeaning in nounFullLogicalMeaning)
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

        private void ProcessNoun(ResultOfNodeOfSemanticAnalyzer result)
        {
            var noun = mNounPhrase.Noun;

#if DEBUG
            //LogInstance.Log($"noun = {noun}");
#endif
            var conceptualGraph = Context.ConceptualGraph;

            if(noun.IsName)
            {
                mConcept = new ConceptCGNode();
                result.RootConcept = mConcept;
                mConcept.Parent = conceptualGraph;
                mConcept.Name = "entity";

                var nameConcept = new ConceptCGNode();
                nameConcept.Parent = conceptualGraph;
                nameConcept.Name = GetName(noun);

                var nameRelation = new RelationCGNode();
                nameRelation.Parent = conceptualGraph;
                nameRelation.Name = "name";

                mConcept.AddOutputNode(nameRelation);
                nameRelation.AddOutputNode(nameConcept);

                Context.RelationStorage.AddRelation(mConcept.Name, nameConcept.Name, nameRelation.Name);

                MarkAsEntityCondition(nameRelation);

                return;
            }

            mConcept = new ConceptCGNode();
            result.RootConcept = mConcept;
            mConcept.Parent = conceptualGraph;
            mConcept.Name = GetName(noun);
        }

        private void CreateDeterminerMark(ConceptCGNode concept, ATNExtendedToken conceptExtendedToken, ATNExtendedToken determiner)
        {
            var relationName = CGGramamaticalNamesOfRelations.DeterminerName;
            var determinerConceptName = GetName(determiner);

            if (Context.RelationStorage.ContainsRelation(concept.Name, determinerConceptName, relationName))
            {
                return;
            }

            var conceptualGraph = Context.ConceptualGraph;

            var determinerConcept = new ConceptCGNode();
            determinerConcept.Parent = conceptualGraph;
            determinerConcept.Name = determinerConceptName;

            var determinerRelation = new RelationCGNode();
            determinerRelation.Parent = conceptualGraph;
            determinerRelation.Name = relationName;

            concept.AddOutputNode(determinerRelation);
            determinerRelation.AddOutputNode(determinerConcept);

            Context.RelationStorage.AddRelation(concept.Name, determinerConceptName, relationName);

            MarkAsEntityCondition(determinerRelation);
        }
    }
}
