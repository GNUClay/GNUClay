using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class FirstConditionOfSentenceTargetOfATNSlaveNAPNode : ITargetOfATNSlaveNAPNode
    {
        public void SetNode(BasePhrase_v2 node, ContextOfATNParsing_v2 context)
        {
            var wordNode = node.AsBaseWordPhrase;
            context.Sentence.ConditionsList.Add(wordNode);
        }
    }
}
