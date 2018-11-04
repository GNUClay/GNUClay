using MyNPCLib.NLToCGParsing.PhraseTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class ObjectTargetOfATNSlaveNAPNode: ITargetOfATNSlaveNAPNode
    {
        public void SetNode(BaseNounLikePhrase node, ContextOfATNParsing_v2 context)
        {
            context.Sentence.VerbPhrase.Object = node;
        }
    }
}
