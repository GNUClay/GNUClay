using GnuClay.CommonUtils.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.TextCGParser
{
    public class SemanticAnalyzerSentenceContext
    {
        public SemanticAnalyzerSentenceContext Parent = null;
        public List<SemanticAnalyzerSentenceContext> Children = new List<SemanticAnalyzerSentenceContext>();

        public Sentence Sentence = null;

        public CGNode SentenceNode = null;

        public CGNode Subject = null;
        public CGNode Verb = null;
        public CGNode Object = null;

        public string ToDbgString()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine($"{nameof(Sentence)} = {Sentence?.ToDbgString()}");
            tmpSb.AppendLine($"{nameof(SentenceNode)} = {SentenceNode?.ToDbgString()}");
            tmpSb.AppendLine($"{nameof(Subject)} = {Subject?.ToDbgString()}");
            tmpSb.AppendLine($"{nameof(Verb)} = {Verb?.ToDbgString()}");
            tmpSb.AppendLine($"{nameof(Object)} = {Object?.ToDbgString()}");

            tmpSb.AppendLine("Begin Children");

            foreach (var child in Children)
            {
                tmpSb.AppendLine($"{nameof(child)} = {child?.ToDbgString()}");
            }

            tmpSb.AppendLine("End Children");

            return tmpSb.ToString();
        }
    }

    public class SemanticAnalyzerSentenceCommonContext
    {
        public SemanticAnalyzerSentenceContext RootSentenceContext = null;
        public SemanticAnalyzerSentenceContext CurrentSentenceContext = null;

        public CGNode RootNode = null;

        public Dictionary<ulong, CGNode> Concepts = new Dictionary<ulong, CGNode>();
        public Dictionary<ulong, CGNode> Relations = new Dictionary<ulong, CGNode>();

        public Dictionary<CGNode, SemanticConcepts> SemanticConceptsDict = new Dictionary<CGNode, SemanticConcepts>();

        public ulong GetTemplateInstanceKey(CGNode node)
        {
            if (mTemplateInstanceKeysDict.ContainsKey(node))
            {
                return mTemplateInstanceKeysDict[node];
            }

            mCurrTemplateInstanceKey++;
            mTemplateInstanceKeysDict[node] = mCurrTemplateInstanceKey;

            return mCurrTemplateInstanceKey;
        }

        private Dictionary<CGNode, ulong> mTemplateInstanceKeysDict = new Dictionary<CGNode, ulong>();
        private ulong mCurrTemplateInstanceKey = 0;
    }
}
