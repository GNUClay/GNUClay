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
            //LogInstance.Log($"mVerbPhrase = {mVerbPhrase}");
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
            //LogInstance.Log($"verb = {verb}");
#endif

            var verbsRolesStorage = new RolesStorageOfSemanticAnalyzer();

            var verbFullLogicalMeaning = verb.FullLogicalMeaning;

            foreach (var logicalMeaning in verbFullLogicalMeaning)
            {
#if DEBUG
                //LogInstance.Log($"logicalMeaning = {logicalMeaning}");
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

            if (nounObjectsList.IsEmpty())
            {
                var isAct = verb.FullLogicalMeaning.Contains("act");
                var isState = verb.FullLogicalMeaning.Contains("state");

#if DEBUG
                //LogInstance.Log($"isAct = {isAct}");
                //LogInstance.Log($"isState = {isState}");
#endif

                if (isAct)
                {
                    var relationName = SpecialNamesOfRelations.ActionRelationName;
                    var relation = new RelationCGNode();
                    relation.Parent = conceptualGraph;
                    relation.Name = relationName;

                    relation.AddOutputNode(mConcept);
                }
                else
                {
                    if (isState)
                    {
                        var relationName = SpecialNamesOfRelations.StateRelationName;
                        var relation = new RelationCGNode();
                        relation.Parent = conceptualGraph;
                        relation.Name = relationName;

                        relation.AddOutputNode(mConcept);
                    }
                }
            }
            else
            {
#if DEBUG
                //LogInstance.Log($"nounObjectsList.Count = {nounObjectsList.Count}");
#endif

                foreach (var nounObject in nounObjectsList)
                {
#if DEBUG
                    //LogInstance.Log($"nounObject = {nounObject}");
#endif

                    throw new NotImplementedException();
                }
            }

            var prepositionalList = mVerbPhrase.PrepositionalList;

            if(!prepositionalList.IsEmpty())
            {
#if DEBUG
                //LogInstance.Log($"prepositionalList.Count = {prepositionalList.Count}");
#endif

                foreach(var prepositional in prepositionalList)
                {
#if DEBUG
                    //LogInstance.Log($"prepositional = {prepositional}");
#endif

                    var conditionalLogicalMeaning = GetConditionalLogicalMeaning(prepositional.Preposition.RootWord, verb.RootWord);

#if DEBUG
                    //LogInstance.Log($"conditionalLogicalMeaning = {conditionalLogicalMeaning}");
#endif
                    if (!string.IsNullOrWhiteSpace(conditionalLogicalMeaning))
                    {
                        var nounOfPrepositionalList = prepositional.ChildrenNodesList.Select(p => p.AsNounPhrase).Where(p => p != null).ToList();

#if DEBUG
                        //LogInstance.Log($"nounOfPrepositionalList.Count = {nounOfPrepositionalList.Count}");
#endif

                        foreach (var nounOfPrepositional in nounOfPrepositionalList)
                        {
#if DEBUG
                            //LogInstance.Log($"nounOfPrepositional = {nounOfPrepositional}");
#endif

                            var nodeOfNounOfPrepositional = new NounPhraseNodeOfSemanticAnalyzer_v2(Context, mSentence, nounOfPrepositional);
                            var nounOfPrepositionalResult = nodeOfNounOfPrepositional.Run();

#if DEBUG
                            //LogInstance.Log($"nounOfPrepositionalResult = {nounOfPrepositionalResult}");
#endif

                            var phisobjList = nounOfPrepositionalResult.PrimaryRolesDict.GetByRole("entity");

#if DEBUG
                            //LogInstance.Log($"phisobjList.Count = {phisobjList.Count}");
#endif

                            foreach (var phisobj in phisobjList)
                            {
#if DEBUG
                                //LogInstance.Log($"phisobj = {phisobj}");
#endif

                                var directionRelation = new RelationCGNode();
                                directionRelation.Parent = conceptualGraph;
                                directionRelation.Name = conditionalLogicalMeaning;

                                directionRelation.AddInputNode(mConcept);
                                directionRelation.AddOutputNode(phisobj);
                            }
                        }
                    }             
                }     
            }

            return result;
        }
    }
}
