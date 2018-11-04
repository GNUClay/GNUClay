using MyNPCLib.NLToCGParsing.PhraseTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class SubjectTargetOfATNSlaveNAPNode: ITargetOfATNSlaveNAPNode
    {
        public void SetNode(BaseNounLikePhrase node, ContextOfATNParsing_v2 context)
        {
            context.Sentence.NounPhrase = node;
        }
    }
}
