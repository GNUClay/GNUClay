using MyNPCLib.NLToCGParsing.PhraseTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public interface ITargetOfATNSlaveNAPNode
    {
        void SetNode(BaseNounLikePhrase node, ContextOfATNParsing_v2 context);
    }
}
