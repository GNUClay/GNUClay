using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class SemanticAnalyzer
    {
        public SemanticAnalyzer(List<Sentence> sentences, GnuClayEngine engine)
        {
            mSentences = sentences;
            mEngine = engine;
        }

        private List<Sentence> mSentences = null;
        private GnuClayEngine mEngine = null;

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

            if(_ListHelper.IsEmpty(mSentences))
            {
                return;
            }

            foreach(var sentence in mSentences)
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

            CGNode rootNode = null;
            CGNode sentenceNode = null;

            if (context == null)
            {
                rootNode = new CGNode();
                rootNode.Kind = CGNodeKind.Concept;

                sentenceNode = rootNode;
                context = new SemanticAnalyzerSentenceCommonContext();
                context.RootNode = rootNode;
            }

            var concreteContext = new SemanticAnalyzerSentenceContext();

            if (context.CurrentSentenceContext != null)
            {
                concreteContext.Parent = context.CurrentSentenceContext;
               
                sentenceNode = new CGNode(rootNode);
                sentenceNode.Kind = CGNodeKind.Concept;
            }

            context.CurrentSentenceContext = concreteContext;

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

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSentence Next");

            throw new NotImplementedException();
        }

        private void ProcessNP(SemanticAnalyzerSentenceCommonContext context, ProcessNPKind kind, NounPhrase np)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNP kind = {kind} np = {np.ToDbgString()}");

            var cgNode = new CGNode(context.CurrentSentenceContext.SentenceNode);
            cgNode.Kind = CGNodeKind.Concept;

            var extendTokenNoun = np.Noun as ExtendToken;

            if(extendTokenNoun == null)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("ProcessNP extendTokenNoun == null");

                throw new NotImplementedException();
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNP extendTokenNoun = {extendTokenNoun}");

            if(extendTokenNoun.Is(GrammaticalNumberOfWord.Singular))
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

            if(np.Prepositional != null)
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

            RegNP(context, node, kind);
        }

        private void RegNP(SemanticAnalyzerSentenceCommonContext context, CGNode node, ProcessNPKind kind)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"RegNP node.Name = {node.Name} kind = {kind}");

            var currentConcreteContext = context.CurrentSentenceContext;

            switch(kind)
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

            var verbName = mEngine.DataDictionary.GetValue(verb.RootKey);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb verbName = {verbName}");

            var cgNode = new CGNode(context.CurrentSentenceContext.SentenceNode);
            cgNode.Kind = CGNodeKind.Concept;

            cgNode.ClassName = verbName;

            //throw new NotImplementedException();
        }
    }
}
