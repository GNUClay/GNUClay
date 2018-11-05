using MyNPCLib.NLToCGParsing.PhraseTree;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class SubjectTargetOfATNSlaveNAPNode: ITargetOfATNSlaveNAPNode
    {
        public void SetNode(BaseNounLikePhrase_v2 node, ContextOfATNParsing_v2 context)
        {
            context.Sentence.NounPhrasesList.Add(node);
        }
    }
}
