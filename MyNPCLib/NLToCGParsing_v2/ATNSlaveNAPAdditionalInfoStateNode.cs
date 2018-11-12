using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public enum KindOfATNSlaveNAPAdditionalInfoStateNode
    {
        Init,
        GotPronoun
    }

    public class ATNSlaveNAPAdditionalInfoStateNode : ATNSlaveNAPBaseStateNode
    {
        public ATNSlaveNAPPrepositionalStateNode(ContextOfATNParsing_v2 context, ITargetOfATNSlaveNAPNode target, ContextOfATNSlaveNAPStateNode contextOfState)
            : base(context, target, contextOfState)
        {
        }

        public ATNSlaveNAPPrepositionalStateNode(ContextOfATNParsing_v2 context, ContextOfATNSlaveNAPStateNode contextOfState)
            : base(context, contextOfState)
        {
        }

        private KindOfATNSlaveNAPAdditionalInfoStateNode State = KindOfATNSlaveNAPAdditionalInfoStateNode.Init;
        private NounPhrase_v2 
    }
}
