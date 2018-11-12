using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class AdditionalInfoTargetOfATNSlaveNAPNode : ITargetOfATNSlaveNAPNode
    {
        public AdditionalInfoTargetOfATNSlaveNAPNode(NounPhrase_v2 nounPhrase)
        {
            mNounPhrase = nounPhrase;
        }

        private NounPhrase_v2 mNounPhrase;

        public void SetNode(BasePhrase_v2 node, ContextOfATNParsing_v2 context)
        {
            var actualTarget = context.GetByRunTimeSessionKey<NounPhrase_v2>(mNounPhrase);

            var wordNode = node.AsBaseWordPhrase;

            actualTarget.AdditionalInfoList.Add(wordNode);
        }

        public void ReplaceNode(BasePhrase_v2 node, ContextOfATNParsing_v2 context)
        {
            throw new NotImplementedException();
        }

        public void ResetNodes(ContextOfATNParsing_v2 context)
        {
            throw new NotImplementedException();
        }
    }
}
