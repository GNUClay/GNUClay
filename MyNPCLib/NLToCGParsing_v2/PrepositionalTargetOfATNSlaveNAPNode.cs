using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
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
            var actualTarget = context.GetByRunTimeSessionKey<PrepositionalPhrase_v2>(mPrepositionalPhrase);

            var wordNode = node.AsBaseWordPhrase;

            actualTarget.ChildrenNodesList.Add(wordNode);
        }
    }
}
