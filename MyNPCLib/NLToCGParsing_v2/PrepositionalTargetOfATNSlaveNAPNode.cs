using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class PrepositionalTargetOfATNSlaveNAPNode: ITargetOfATNSlaveNAPNode
    {
        public PrepositionalTargetOfATNSlaveNAPNode(PrepositionalPhrase_v2 prepositionalPhrase)
        {
            mPrepositionalPhrase = prepositionalPhrase;
        }

        private PrepositionalPhrase_v2 mPrepositionalPhrase;

        public void SetNode(BasePhrase_v2 node, ContextOfATNParsing_v2 context)
        {
            var wordNode = node.AsBaseWordPhrase;

            if(wordNode == null)
            {
                throw new ArgumentNullException(nameof(wordNode));
            }

            NSetNode(wordNode, context);
        }

        public void ReplaceNode(BasePhrase_v2 node, ContextOfATNParsing_v2 context)
        {
            var wordNode = node.AsBaseWordPhrase;

            var actualTarget = context.GetByRunTimeSessionKey<PrepositionalPhrase_v2>(mPrepositionalPhrase);

            var itemsList = actualTarget.ChildrenNodesList;

            if (itemsList.Count > 0)
            {
                var lastNode = itemsList.Last();
                itemsList.Remove(lastNode);
            }

            NSetNode(wordNode, context);
        }

        private void NSetNode(BaseWordPhrase_v2 wordNode, ContextOfATNParsing_v2 context)
        {
            var actualTarget = context.GetByRunTimeSessionKey<PrepositionalPhrase_v2>(mPrepositionalPhrase);

            actualTarget.ChildrenNodesList.Add(wordNode);
        }

        public void ResetNodes(ContextOfATNParsing_v2 context)
        {
            var actualTarget = context.GetByRunTimeSessionKey<PrepositionalPhrase_v2>(mPrepositionalPhrase);

            actualTarget.ChildrenNodesList.Clear();
        }
    }
}
