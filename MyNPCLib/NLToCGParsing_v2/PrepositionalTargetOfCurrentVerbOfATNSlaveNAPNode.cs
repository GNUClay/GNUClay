using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class PrepositionalTargetOfCurrentVerbOfATNSlaveNAPNode: ITargetOfATNSlaveNAPNode
    {
        public PrepositionalTargetOfCurrentVerbOfATNSlaveNAPNode(VerbPhrase_v2 verbPhrase)
        {
            mVerbPhrase = verbPhrase;
        }

        private VerbPhrase_v2 mVerbPhrase;

        public void SetNode(BasePhrase_v2 node, ContextOfATNParsing_v2 context)
        {
            var wordNode = node.AsPrepositionalPhrase;

            if (wordNode == null)
            {
                throw new ArgumentNullException(nameof(wordNode));
            }

            NSetNode(wordNode, context);
        }

        public void ReplaceNode(BasePhrase_v2 node, ContextOfATNParsing_v2 context)
        {
            var wordNode = node.AsPrepositionalPhrase;

            var actualTarget = context.GetByRunTimeSessionKey<VerbPhrase_v2>(mVerbPhrase);

            var itemsList = actualTarget.PrepositionalList;

            if (itemsList.Count > 0)
            {
                var lastNode = itemsList.Last();
                itemsList.Remove(lastNode);
            }

            NSetNode(wordNode, context);
        }

        private void NSetNode(PrepositionalPhrase_v2 wordNode, ContextOfATNParsing_v2 context)
        {
#if DEBUG
            //LogInstance.Log($"wordNode = {wordNode}");
            //LogInstance.Log($"context = {context}");
#endif

            var actualTarget = context.GetByRunTimeSessionKey<VerbPhrase_v2>(mVerbPhrase);

            actualTarget.PrepositionalList.Add(wordNode);

#if DEBUG
            //LogInstance.Log($"context = {context}");
#endif
        }

        public void ResetNodes(ContextOfATNParsing_v2 context)
        {
            var actualTarget = context.GetByRunTimeSessionKey<VerbPhrase_v2>(mVerbPhrase);

            actualTarget.PrepositionalList.Clear();
        }
    }
}
