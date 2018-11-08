using System;
using System.Collections.Generic;
using System.Text;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class PossesiveTargetOfATNSlaveNAPNode : ITargetOfATNSlaveNAPNode
    {
        public PossesiveTargetOfATNSlaveNAPNode(NounPhrase_v2 nounPhrase)
        {
            mNounPhrase = nounPhrase;
        }

        private NounPhrase_v2 mNounPhrase;

        public void SetNode(BasePhrase_v2 node, ContextOfATNParsing_v2 context)
        {
            var actualTarget = context.GetByRunTimeSessionKey<NounPhrase_v2>(mNounPhrase);

            var wordNode = node.AsBaseWordPhrase;

            actualTarget.PossesiveList.Add(wordNode);
        }
    }
}
