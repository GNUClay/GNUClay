using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class SemanticAnalyzerSentenceContext
    {
        public SemanticAnalyzerSentenceContext Parent = null;

        public Sentence Sentence = null;
     
        public CGNode SentenceNode = null;

        public CGNode Subject = null;
        public CGNode Verb = null;
        public CGNode Object = null;
    }

    public class SemanticAnalyzerSentenceCommonContext
    {
        public SemanticAnalyzerSentenceContext RootSentenceContext = null;
        public SemanticAnalyzerSentenceContext CurrentSentenceContext = null;

        public CGNode RootNode = null;

        public Dictionary<ulong, CGNode> Concepts = new Dictionary<ulong, CGNode>();
        public Dictionary<ulong, CGNode> Relations = new Dictionary<ulong, CGNode>();

        public ulong GetTemplateInstanceKey(CGNode node)
        {
            if(mTemplateInstanceKeysDict.ContainsKey(node))
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
