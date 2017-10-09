using GnuClay.CommonUtils.CG;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine;
using GnuClay.Engine.CommonStorages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.TextCGParser
{
    public class SemanticAnalyzer
    {
        public SemanticAnalyzer(List<Sentence> sentences, GnuClayEngine engine)
        {
            mSentences = sentences;
            mEngine = engine;

            DataDictionary = mEngine.DataDictionary;

            InitConcepts();
        }

        private List<Sentence> mSentences = null;
        private GnuClayEngine mEngine = null;
        private StorageDataDictionary DataDictionary = null;

        private void InitConcepts()
        {
            AnimateKey = DataDictionary.GetKey("animate");
            StateKey = DataDictionary.GetKey("state");
        }

        private ulong AnimateKey = 0;
        private ulong StateKey = 0;

        private List<SemanticConcepts> LoadSemanticConcepts(string content)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Run LoadSemanticConcepts content = {content}");

            var queryStr = $"READ {{>: {{is(`{content}`, $X)}}}}";

            var queryResult = mEngine.Query(queryStr);

            if (queryResult.Success && queryResult.HaveBeenFound)
            {
                var result = new List<SemanticConcepts>();

                foreach (var item in queryResult.Items)
                {
                    var key = item.Params.First().EntityKey;

                    if (key == AnimateKey)
                    {
                        result.Add(SemanticConcepts.Animate);
                        continue;
                    }

                    if (key == StateKey)
                    {
                        result.Add(SemanticConcepts.State);
                        continue;
                    }
                }

                return result;
            }

            return new List<SemanticConcepts>();
        }

        private string TenseToString(GrammaticalTenses tense)
        {
            switch (tense)
            {
                case GrammaticalTenses.Present:
                    return "present";

                default: throw new ArgumentOutOfRangeException(nameof(tense), tense.ToString());
            }
        }

        private string AspectToString(GrammaticalAspect aspect)
        {
            switch (aspect)
            {
                case GrammaticalAspect.Simple:
                    return "simple";

                default: throw new ArgumentOutOfRangeException(nameof(aspect), aspect.ToString());
            }
        }

        private List<CGNode> mResult = new List<CGNode>();

        public List<CGNode> Result
        {
            get
            {
                return mResult;
            }
        }

        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            mResult = new List<CGNode>();

            if (_ListHelper.IsEmpty(mSentences))
            {
                return;
            }

            foreach (var sentence in mSentences)
            {
                ProcessSentence(sentence, null);
            }

            NLog.LogManager.GetCurrentClassLogger().Info("End Run");
        }

        private enum ProcessNPKind
        {
            Subject,
            Object,
            Additional
        }

        private void ProcessSentence(Sentence sentence, SemanticAnalyzerSentenceCommonContext context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSentence sentence = {sentence.ToDbgString()}");

            var IsStart = false;

            if (context == null)
            {
                var rootNode = new CGNode();
                rootNode.Kind = CGNodeKind.Concept;

                context = new SemanticAnalyzerSentenceCommonContext();
                context.RootNode = rootNode;

                IsStart = true;

                var rootConcreteContext = new SemanticAnalyzerSentenceContext();

                context.RootSentenceContext = rootConcreteContext;
                context.CurrentSentenceContext = rootConcreteContext;
                rootConcreteContext.SentenceNode = rootNode;
            }

            var concreteContext = new SemanticAnalyzerSentenceContext();

            var parent = context.CurrentSentenceContext;

            concreteContext.Parent = parent;

            parent.Children.Add(concreteContext);

            context.CurrentSentenceContext = concreteContext;

            var sentenceNode = new CGNode(concreteContext.Parent.SentenceNode);
            sentenceNode.Kind = CGNodeKind.Concept;

            concreteContext.Sentence = sentence;
            concreteContext.SentenceNode = sentenceNode;

            if (sentence.Subject != null)
            {
                ProcessNP(context, ProcessNPKind.Subject, sentence.Subject);
            }

            ProcessVerb(context, sentence.Verb);

            if (sentence.Object != null)
            {
                ProcessNP(context, ProcessNPKind.Object, sentence.Object);
            }

            NLog.LogManager.GetCurrentClassLogger().Info("ProcessSentence Next");

            if (IsStart)
            {
                var rootNode = context.RootNode;

                var primaryChildNode = context.RootSentenceContext.Children.First();
                var primaryChildSentence = primaryChildNode.Sentence;

                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSentence primaryChildSentence = {primaryChildSentence.ToDbgString()}");

                var primaryChildCGNode = primaryChildNode.SentenceNode;

                var tenseNode = new CGNode(rootNode);
                tenseNode.Kind = CGNodeKind.Concept;

                tenseNode.ClassName = TenseToString(primaryChildSentence.Tense);

                var tenseRelation = new CGNode(rootNode);
                tenseRelation.Kind = CGNodeKind.Relation;
                tenseRelation.ClassName = "tense";

                tenseRelation.AddInputNode(primaryChildCGNode);
                tenseRelation.AddOutputNode(tenseNode);

                var aspectNode = new CGNode(rootNode);
                aspectNode.Kind = CGNodeKind.Concept;
                aspectNode.ClassName = AspectToString(primaryChildSentence.Aspect);

                var aspectRelation = new CGNode(rootNode);
                aspectRelation.Kind = CGNodeKind.Relation;
                aspectRelation.ClassName = "aspect";

                aspectRelation.AddInputNode(primaryChildCGNode);
                aspectRelation.AddOutputNode(aspectNode);

                ProcessLinkingConcepts(context, null);

                mResult.Add(context.RootNode);
            }

            NLog.LogManager.GetCurrentClassLogger().Info("ProcessSentence Next Next");

            //throw new NotImplementedException();
        }

        private void ProcessNP(SemanticAnalyzerSentenceCommonContext context, ProcessNPKind kind, NounPhrase np)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNP kind = {kind} np = {np.ToDbgString()}");

            var cgNode = new CGNode(context.CurrentSentenceContext.SentenceNode);
            cgNode.Kind = CGNodeKind.Concept;

            var extendTokenNoun = np.Noun as ExtendToken;

            if (extendTokenNoun == null)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("ProcessNP extendTokenNoun == null");

                throw new NotImplementedException();
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNP extendTokenNoun = {extendTokenNoun}");

            if (extendTokenNoun.Is(GrammaticalNumberOfWord.Singular))
            {
                NLog.LogManager.GetCurrentClassLogger().Info("ProcessNP extendTokenNoun.Is(GrammaticalNumberOfWord.Singular)");

                ProcessInstanceNP(context, np, cgNode, extendTokenNoun, kind);
            }
            else
            {
                NLog.LogManager.GetCurrentClassLogger().Info("ProcessNP NOT extendTokenNoun.Is(GrammaticalNumberOfWord.Singular)");

                throw new NotImplementedException();
            }

            if (np.Adjective != null)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("ProcessNP np.Adjective != null");

                throw new NotImplementedException();
            }

            if (np.Prepositional != null)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("ProcessNP np.Prepositional != null");

                throw new NotImplementedException();
            }

            //throw new NotImplementedException();
        }

        private void ProcessInstanceNP(SemanticAnalyzerSentenceCommonContext context, NounPhrase np, CGNode node, ExtendToken extendTokenNoun, ProcessNPKind kind)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessInstanceNP np = {np.ToDbgString()} extendTokenNoun = {extendTokenNoun} kind = {kind}");

            var tKey = context.GetTemplateInstanceKey(node);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessInstanceNP tKey = {tKey}");

            node.ClassName = extendTokenNoun.Content;
            node.InstanceName = $"#{tKey}";

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessInstanceNP node.Name = {node.Name}");

            RegNP(context, node, kind, extendTokenNoun);
        }

        private void RegNP(SemanticAnalyzerSentenceCommonContext context, CGNode node, ProcessNPKind kind, ExtendToken extendTokenNoun)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"RegNP node.Name = {node.Name} kind = {kind}");

            var currentConcreteContext = context.CurrentSentenceContext;

            var rootKey = extendTokenNoun.RootKey;

            var rootName = DataDictionary.GetValue(rootKey);

            NLog.LogManager.GetCurrentClassLogger().Info($"RegNP rootKey = {rootKey} rootName = {rootName}");

            var conceptsList = LoadSemanticConcepts(rootName);

            foreach (var c in conceptsList)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"RegNP c = {c}");
            }

            var targetConcept = SemanticConcepts.Unknown;

            if (conceptsList.Any())
            {
                targetConcept = conceptsList.First();
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"RegNP targetConcept = {targetConcept}");

            context.SemanticConceptsDict[node] = targetConcept;

            switch (kind)
            {
                case ProcessNPKind.Subject:
                    currentConcreteContext.Subject = node;
                    break;

                case ProcessNPKind.Object:
                    currentConcreteContext.Object = node;
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(kind), kind.ToString());
            }
        }

        private void ProcessVerb(SemanticAnalyzerSentenceCommonContext context, ExtendToken verb)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb verb = {verb.ToDbgString()}");
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb verb = {verb}");

            var currentConcreteContext = context.CurrentSentenceContext;

            var rootName = mEngine.DataDictionary.GetValue(verb.RootKey);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb rootName = {rootName}");

            var cgNode = new CGNode(context.CurrentSentenceContext.SentenceNode);
            cgNode.Kind = CGNodeKind.Concept;

            cgNode.ClassName = rootName;

            var conceptsList = LoadSemanticConcepts(rootName);

            foreach (var c in conceptsList)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb c = {c}");
            }

            var targetConcept = SemanticConcepts.Unknown;

            if (conceptsList.Any())
            {
                targetConcept = conceptsList.First();
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"RegNP targetConcept = {targetConcept}");

            context.SemanticConceptsDict[cgNode] = targetConcept;

            currentConcreteContext.Verb = cgNode;

            //throw new NotImplementedException();
        }

        private void ProcessLinkingConcepts(SemanticAnalyzerSentenceCommonContext context, SemanticAnalyzerSentenceContext concreteContext)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessLinkingConcepts (concreteContext == null) = {(concreteContext == null)}");

            if (concreteContext == null)
            {
                concreteContext = context.RootSentenceContext;
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessLinkingConcepts concreteContext = {concreteContext.ToDbgString()}");

            var sentenceNode = concreteContext.SentenceNode;

            var subject = concreteContext.Subject;
            var verb = concreteContext.Verb;
            var objectNode = concreteContext.Object;

            if (subject != null && verb != null)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("ProcessLinkingConcepts subject != null && verb != null");

                var subjectConcept = context.SemanticConceptsDict[subject];
                var verbConcept = context.SemanticConceptsDict[verb];

                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessLinkingConcepts subjectConcept = {subjectConcept} verbConcept = {verbConcept}");

                var subjectToVerbRelationName = string.Empty;
                var verbToSubjectRelationName = string.Empty;

                switch (subjectConcept)
                {
                    case SemanticConcepts.Animate:
                        switch (verbConcept)
                        {
                            case SemanticConcepts.State:
                                subjectToVerbRelationName = "state";
                                verbToSubjectRelationName = "expensier";
                                break;

                            default: throw new ArgumentOutOfRangeException(nameof(verbConcept), verbConcept.ToString());
                        }
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(subjectConcept), subjectConcept.ToString());
                }

                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessLinkingConcepts subjectToVerbRelationName = {subjectToVerbRelationName} verbToSubjectRelationName = {verbToSubjectRelationName}");

                var stvRelation = new CGNode(sentenceNode);
                stvRelation.Kind = CGNodeKind.Relation;

                stvRelation.ClassName = subjectToVerbRelationName;

                stvRelation.AddInputNode(subject);
                stvRelation.AddOutputNode(verb);

                var vtsRelation = new CGNode(sentenceNode);
                vtsRelation.Kind = CGNodeKind.Relation;

                vtsRelation.ClassName = verbToSubjectRelationName;

                vtsRelation.AddInputNode(verb);
                vtsRelation.AddOutputNode(subject);
            }

            if (verb != null && objectNode != null)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("ProcessLinkingConcepts verb != null && objectNode != null");

                var verbConcept = context.SemanticConceptsDict[verb];
                var objectConcept = context.SemanticConceptsDict[objectNode];

                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessLinkingConcepts verbConcept = {verbConcept} objectConcept = {objectConcept}");

                var verbToObjectRelationName = string.Empty;

                switch (objectConcept)
                {
                    case SemanticConcepts.Animate:
                        switch (verbConcept)
                        {
                            case SemanticConcepts.State:
                                verbToObjectRelationName = "object";
                                break;

                            default: throw new ArgumentOutOfRangeException(nameof(verbConcept), verbConcept.ToString());
                        }
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(objectConcept), objectConcept.ToString());
                }

                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessLinkingConcepts verbToObjectRelationName = {verbToObjectRelationName}");

                var vtoRelation = new CGNode(sentenceNode);
                vtoRelation.Kind = CGNodeKind.Relation;

                vtoRelation.ClassName = verbToObjectRelationName;

                vtoRelation.AddInputNode(verb);
                vtoRelation.AddOutputNode(objectNode);
                //throw new NotImplementedException();
            }

            var concreteContextChildren = concreteContext.Children;

            if (concreteContextChildren.Any())
            {
                foreach (var child in concreteContextChildren)
                {
                    ProcessLinkingConcepts(context, child);
                }
            }

            //throw new NotImplementedException();
        }
    }
}
