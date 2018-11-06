using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class ATNSlaveNAPPrepositionalStateNode: ATNSlaveNAPBaseStateNode
    {
        public ATNSlaveNAPPrepositionalStateNode(ContextOfATNParsing_v2 context, ITargetOfATNSlaveNAPNode target, ContextOfATNSlaveNAPStateNode contextOfState)
            : base(context, target, contextOfState)
        {
        }

        public ATNSlaveNAPPrepositionalStateNode(ContextOfATNParsing_v2 context, ContextOfATNSlaveNAPStateNode contextOfState)
            : base(context, contextOfState)
        {
        }

        public override ATNSlaveNAPBaseStateNode Fork(ContextOfATNParsing_v2 context, ContextOfATNSlaveNAPStateNode contextOfState)
        {
            throw new NotImplementedException();
        }

        public override void Run(ATNExtendedToken token)
        {
            throw new NotImplementedException();
        }
    }
}
