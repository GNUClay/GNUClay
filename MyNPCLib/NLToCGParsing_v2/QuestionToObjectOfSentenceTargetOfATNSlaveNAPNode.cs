using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class QuestionToObjectOfSentenceTargetOfATNSlaveNAPNode : ITargetOfATNSlaveNAPNode
    {
        public void SetNode(BasePhrase_v2 node, ContextOfATNParsing_v2 context)
        {
            var wordNode = node.AsBaseWordPhrase;
            context.Sentence.QuestionToObjectsList.Add(wordNode);
        }

        public void ReplaceNode(BasePhrase_v2 node, ContextOfATNParsing_v2 context)
        {
            throw new NotImplementedException();
        }
    }
}
