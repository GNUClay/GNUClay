using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class FirstConditionOfSentenceTargetOfATNSlaveNAPNode : ITargetOfATNSlaveNAPNode
    {
        public void SetNode(BasePhrase_v2 node, ContextOfATNParsing_v2 context)
        {
            var wordNode = node.AsBaseWordPhrase;
            NSetNode(wordNode, context);
        }

        public void ReplaceNode(BasePhrase_v2 node, ContextOfATNParsing_v2 context)
        {
#if DEBUG
            //LogInstance.Log($"node = {node}");
#endif

            var wordNode = node.AsBaseWordPhrase;

            var itemsList = context.Sentence.ConditionsList;

            if (itemsList.Count > 0)
            {
                var lastNode = itemsList.Last();
                itemsList.Remove(lastNode);
            }

            NSetNode(wordNode, context);
        }

        private void NSetNode(BaseWordPhrase_v2 wordNode, ContextOfATNParsing_v2 context)
        {
            context.Sentence.ConditionsList.Add(wordNode);
        }

        public void ResetNodes(ContextOfATNParsing_v2 context)
        {
            throw new NotImplementedException();
        }
    }
}
