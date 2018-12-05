using MyNPCLib.CG;
using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class SemanticAnalyzer_v2
    {
        public SemanticAnalyzer_v2(IWordsDict wordDict)
        {
            mWordsDict = wordDict;
        }

        private IWordsDict mWordsDict;

        public ConceptualGraph Run(Sentence_v2 sentence)
        {
#if DEBUG
            LogInstance.Log($"sentence = {sentence}");
#endif
            var outerConceptualGraph = new ConceptualGraph();
            var context = new ContextOfSemanticAnalyzer();
            context.OuterConceptualGraph = outerConceptualGraph;
            context.WordsDict = mWordsDict;



            throw new NotImplementedException();
        }
    }
}
