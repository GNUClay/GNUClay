using MyNPCLib.NLToCGParsing.PhraseTree;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class ObjectTargetOfATNSlaveNAPNode: ITargetOfATNSlaveNAPNode
    {
        public void SetNode(BasePhrase_v2 node, ContextOfATNParsing_v2 context)
        {
            var nounNode = node.AsNounPhrase;

            context.Sentence.LastVerbPhrase.ObjectsList.Add(nounNode);
        }
    }
}
