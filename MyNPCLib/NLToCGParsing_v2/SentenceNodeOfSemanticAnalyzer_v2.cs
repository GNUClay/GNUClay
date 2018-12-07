using MyNPCLib.CG;
using MyNPCLib.CommonServiceGrammaticalElements;
using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
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
                throw new NotImplementedException();
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
            }

            throw new NotImplementedException();
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
    }
}
