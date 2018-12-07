using MyNPCLib.CG;
using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
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
            LogInstance.Log($"mVerbPhrase = {mVerbPhrase}");
#endif
            throw new NotImplementedException();
        }
    }
}
