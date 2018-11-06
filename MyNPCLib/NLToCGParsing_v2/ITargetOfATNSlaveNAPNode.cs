using MyNPCLib.NLToCGParsing.PhraseTree;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public interface ITargetOfATNSlaveNAPNode
    {
        void SetNode(BasePhrase_v2 node, ContextOfATNParsing_v2 context);
    }
}
