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
                ProcessSentence(sentence);
            }

            NLog.LogManager.GetCurrentClassLogger().Info("End Run");
        }

        private enum ProcessNPKind
        {
            Subject,
            Object
        }

        private void ProcessSentence(Sentence sentence)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSentence sentence = {sentence.ToDbgString()}");

            var context = new SemanticAnalyzerSentenceContext();
            context.Sentence = sentence;

            if(sentence.Subject != null)
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

        private void ProcessNP(SemanticAnalyzerSentenceContext context, ProcessNPKind kind, NounPhrase np)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNP kind = {kind} np = {np.ToDbgString()}");

            throw new NotImplementedException();
        }

        private void ProcessVerb(SemanticAnalyzerSentenceContext context, ExtendToken verb)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb verb = {verb.ToDbgString()}");

            throw new NotImplementedException();
        }
    }
}
