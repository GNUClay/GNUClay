using MyNPCLib.CG;
using MyNPCLib.CommonServiceGrammaticalElements;
using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class SentenceNodeOfSemanticAnalyzer_v2: BaseNodeOfSemanticAnalyzer_v2
    {
        public SentenceNodeOfSemanticAnalyzer_v2(ContextOfSemanticAnalyzer context, PlainSentence sentence)
            : base(context)
        {
            mSentence = sentence;
        }

        private PlainSentence mSentence;
        private ConceptualGraph mConceptualGraph;

        public ResultOfNodeOfSemanticAnalyzer Run()
        {
#if DEBUG
            LogInstance.Log($"mSentence = {mSentence}");
#endif
            var result = new ResultOfNodeOfSemanticAnalyzer();
            var resultPrimaryRolesDict = result.PrimaryRolesDict;
            var resultSecondaryRolesDict = result.SecondaryRolesDict;

            mConceptualGraph = new ConceptualGraph();
            mConceptualGraph.Parent = Context.OuterConceptualGraph;
            Context.ConceptualGraph = mConceptualGraph;
            mConceptualGraph.Name = NamesHelper.CreateEntityName();

            CreateGrammaticalRelations();

            if(!mSentence.VocativePhrasesList.IsEmpty())
            {
                foreach(var vocative in mSentence.VocativePhrasesList)
                {
#if DEBUG
                    LogInstance.Log($"vocative = {vocative}");
#endif

                    var vocativeNode = new NounPhraseNodeOfSemanticAnalyzer_v2(Context, mSentence, vocative);
                    var vocativeResult = vocativeNode.Run();

#if DEBUG
                    LogInstance.Log($"vocativeResult = {vocativeResult}");
#endif

                    var entitiesList = vocativeResult.PrimaryRolesDict.GetByRole("entity");

                    foreach(var vocativeEntity in entitiesList)
                    {
                        CreateAdresatRelation(vocativeEntity);
                    }
                }              
            }

            var subject = mSentence.NounPhrase;

#if DEBUG
            LogInstance.Log($"subject = {subject}");
#endif

            ResultOfNodeOfSemanticAnalyzer subjectResult = null;

            if (subject != null)
            {
                var subjectNode = new NounPhraseNodeOfSemanticAnalyzer_v2(Context, mSentence, subject);
                subjectResult = subjectNode.Run();

#if DEBUG
                LogInstance.Log($"subjectResult = {subjectResult}");
#endif
            }

            var rootVerb = mSentence.VerbPhrase;
           
#if DEBUG
            LogInstance.Log($"rootVerb = {rootVerb}");
#endif

            ResultOfNodeOfSemanticAnalyzer verbResult = null;

            if (rootVerb != null)
            {
                var verbNode = new VerbPhraseNodeOfSemanticAnalyzer_v2(Context, mSentence, rootVerb);
                verbResult = verbNode.Run();
#if DEBUG
                LogInstance.Log($"verbResult = {verbResult}");
#endif

                if(mSentence.Mood == GrammaticalMood.Imperative)
                {
                    var commandRelation = new RelationCGNode();
                    commandRelation.Name = SpecialNamesOfRelations.CommandRelationName;
                    commandRelation.Parent = mConceptualGraph;

                    commandRelation.AddOutputNode(verbResult.RootConcept);
                }
            }

            if(subjectResult != null && verbResult != null)
            {
                var entitiesList = subjectResult.PrimaryRolesDict.GetByRole("entity");

                if (!entitiesList.IsEmpty())
                {
                    //state -> experiencer -> animate

                    var primaryStatesList = verbResult.PrimaryRolesDict.GetByRole("state");

                    if (!primaryStatesList.IsEmpty())
                    {
                        foreach (var state in primaryStatesList)
                        {
                            foreach (var entity in entitiesList)
                            {
                                CreateExperiencerRelation(state, entity);
                                CreateStateRelation(state, entity);
                            }
                        }
                    }
                    //act -> agent -> animate

                    var primaryActsList = verbResult.PrimaryRolesDict.GetByRole("act");

                    if (!primaryActsList.IsEmpty())
                    {
                        foreach (var act in primaryActsList)
                        {
                            foreach (var entity in entitiesList)
                            {
                                CreateAgentRelation(act, entity);
                                CreateActionRelation(act, entity);
                            }
                        }
                    }
                }                   
            }
            
            return result;
        }

        private void CreateGrammaticalRelations()
        {
            var conceptualGraph = Context.ConceptualGraph;
            var outerConceptualGraph = Context.OuterConceptualGraph;

            var aspectName = GrammaticalElementsHeper.GetAspectName(mSentence.Aspect);

#if DEBUG
            //LogInstance.Log($"aspectName = {aspectName}");
#endif

            if (!string.IsNullOrWhiteSpace(aspectName))
            {
                var grammarConcept = new ConceptCGNode();
                grammarConcept.Parent = outerConceptualGraph;
                grammarConcept.Name = aspectName;

                var grammarRelation = new RelationCGNode();
                grammarRelation.Parent = outerConceptualGraph;
                grammarRelation.Name = CGGramamaticalNamesOfRelations.AspectName;

                conceptualGraph.AddOutputNode(grammarRelation);
                grammarRelation.AddOutputNode(grammarConcept);
            }

            var tenseName = GrammaticalElementsHeper.GetTenseName(mSentence.Tense);

#if DEBUG
            //LogInstance.Log($"tenseName = {tenseName}");
#endif 

            if (!string.IsNullOrWhiteSpace(tenseName))
            {
                var grammarConcept = new ConceptCGNode();
                grammarConcept.Parent = outerConceptualGraph;
                grammarConcept.Name = tenseName;

                var grammarRelation = new RelationCGNode();
                grammarRelation.Parent = outerConceptualGraph;
                grammarRelation.Name = CGGramamaticalNamesOfRelations.TenseName;

                conceptualGraph.AddOutputNode(grammarRelation);
                grammarRelation.AddOutputNode(grammarConcept);
            }

            var voiceName = GrammaticalElementsHeper.GetVoiceName(mSentence.Voice);

#if DEBUG
            //LogInstance.Log($"voiceName = {voiceName}");
#endif
            if (!string.IsNullOrWhiteSpace(voiceName))
            {
                var grammarConcept = new ConceptCGNode();
                grammarConcept.Parent = outerConceptualGraph;
                grammarConcept.Name = voiceName;

                var grammarRelation = new RelationCGNode();
                grammarRelation.Parent = outerConceptualGraph;
                grammarRelation.Name = CGGramamaticalNamesOfRelations.VoiceName;

                conceptualGraph.AddOutputNode(grammarRelation);
                grammarRelation.AddOutputNode(grammarConcept);
            }

            var moodName = GrammaticalElementsHeper.GetMoodName(mSentence.Mood);

#if DEBUG
            //LogInstance.Log($"moodName = {moodName}");
#endif

            if (!string.IsNullOrWhiteSpace(moodName))
            {
                var grammarConcept = new ConceptCGNode();
                grammarConcept.Parent = outerConceptualGraph;
                grammarConcept.Name = moodName;

                var grammarRelation = new RelationCGNode();
                grammarRelation.Parent = outerConceptualGraph;
                grammarRelation.Name = CGGramamaticalNamesOfRelations.MoodName;

                conceptualGraph.AddOutputNode(grammarRelation);
                grammarRelation.AddOutputNode(grammarConcept);
            }

            var modalName = GrammaticalElementsHeper.GetModalName(mSentence.Modal);

#if DEBUG
            //LogInstance.Log($"modalName = {modalName}");
#endif

            if (!string.IsNullOrWhiteSpace(modalName))
            {
                var grammarConcept = new ConceptCGNode();
                grammarConcept.Parent = outerConceptualGraph;
                grammarConcept.Name = modalName;

                var grammarRelation = new RelationCGNode();
                grammarRelation.Parent = outerConceptualGraph;
                grammarRelation.Name = CGGramamaticalNamesOfRelations.ModalName;

                conceptualGraph.AddOutputNode(grammarRelation);
                grammarRelation.AddOutputNode(grammarConcept);
            }
        }

        private void CreateAgentRelation(ConceptCGNode verbConcept, ConceptCGNode nounConcept)
        {
            var relationName = SpecialNamesOfRelations.AgentRelationName;

            if (Context.RelationStorage.ContainsRelation(verbConcept.Name, nounConcept.Name, relationName))
            {
                return;
            }

            var conceptualGraph = Context.ConceptualGraph;

            var relation = new RelationCGNode();
            relation.Parent = conceptualGraph;
            relation.Name = relationName;

            verbConcept.AddOutputNode(relation);
            relation.AddOutputNode(nounConcept);

            Context.RelationStorage.AddRelation(verbConcept.Name, nounConcept.Name, relationName);
        }

        private void CreateActionRelation(ConceptCGNode verbConcept, ConceptCGNode nounConcept)
        {
            var relationName = SpecialNamesOfRelations.ActionRelationName;

            if (Context.RelationStorage.ContainsRelation(nounConcept.Name, verbConcept.Name, relationName))
            {
                return;
            }

            var conceptualGraph = Context.ConceptualGraph;

            var relation = new RelationCGNode();
            relation.Parent = conceptualGraph;
            relation.Name = relationName;

            nounConcept.AddOutputNode(relation);
            relation.AddOutputNode(verbConcept);

            Context.RelationStorage.AddRelation(nounConcept.Name, verbConcept.Name, relationName);
        }

        private void CreateAdresatRelation(ConceptCGNode nounConcept)
        {
            var conceptualGraph = Context.ConceptualGraph;
            var outerConceptualGraph = Context.OuterConceptualGraph;

            nounConcept.Parent = outerConceptualGraph;

            var grammarRelation = new RelationCGNode();
            grammarRelation.Parent = outerConceptualGraph;
            grammarRelation.Name = SpecialNamesOfRelations.AdresatRelationName;

            conceptualGraph.AddOutputNode(grammarRelation);
            grammarRelation.AddOutputNode(nounConcept);
        }

        private void CreateExperiencerRelation(ConceptCGNode verbConcept, ConceptCGNode nounConcept)
        {
#if DEBUG
            //LogInstance.Log($"verbConcept = {verbConcept}");
            //LogInstance.Log($"nounConcept = {nounConcept}");
#endif

            var relationName = SpecialNamesOfRelations.ExperiencerRelationName;

            if (Context.RelationStorage.ContainsRelation(verbConcept.Name, nounConcept.Name, relationName))
            {
                return;
            }

            var conceptualGraph = Context.ConceptualGraph;

            var relation = new RelationCGNode();
            relation.Parent = conceptualGraph;
            relation.Name = relationName;

            verbConcept.AddOutputNode(relation);
            relation.AddOutputNode(nounConcept);

            Context.RelationStorage.AddRelation(verbConcept.Name, nounConcept.Name, relationName);
        }

        private void CreateStateRelation(ConceptCGNode verbConcept, ConceptCGNode nounConcept)
        {
            var relationName = SpecialNamesOfRelations.StateRelationName;

            if (Context.RelationStorage.ContainsRelation(nounConcept.Name, verbConcept.Name, relationName))
            {
                return;
            }

            var conceptualGraph = Context.ConceptualGraph;

            var relation = new RelationCGNode();
            relation.Parent = conceptualGraph;
            relation.Name = relationName;

            nounConcept.AddOutputNode(relation);
            relation.AddOutputNode(verbConcept);

            Context.RelationStorage.AddRelation(verbConcept.Name, nounConcept.Name, relationName);
        }
    }
}
