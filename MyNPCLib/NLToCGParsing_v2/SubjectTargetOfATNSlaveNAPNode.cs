using MyNPCLib.NLToCGParsing.PhraseTree;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class SubjectTargetOfATNSlaveNAPNode: ITargetOfATNSlaveNAPNode
    {
        public void SetNode(BasePhrase_v2 node, ContextOfATNParsing_v2 context)
        {
            var nounNode = node.AsNounPhrase;

            NSetNode(nounNode, context);
        }

        public void ReplaceNode(BasePhrase_v2 node, ContextOfATNParsing_v2 context)
        {
            var nounNode = node.AsNounPhrase;

            var itemsList = context.Sentence.NounPhrasesList;

            if (itemsList.Count > 0)
            {
                var lastNode = itemsList.Last();
                itemsList.Remove(lastNode);
            }

            NSetNode(nounNode, context);
        }

        private void NSetNode(NounPhrase_v2 nounNode, ContextOfATNParsing_v2 context)
        {
            context.Sentence.NounPhrasesList.Add(nounNode);
        }

        public void ResetNodes(ContextOfATNParsing_v2 context)
        {
            context.Sentence.NounPhrasesList.Clear();
        }
    }
}
