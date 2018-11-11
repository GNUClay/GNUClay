using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public abstract class ATNSlaveNAPBaseStateNode
    {
        protected ATNSlaveNAPBaseStateNode(ContextOfATNParsing_v2 context, ITargetOfATNSlaveNAPNode target, ContextOfATNSlaveNAPStateNode contextOfState)
        {
            Context = context;
            Target = target;
            ContextOfState = contextOfState;
        }

        protected ATNSlaveNAPBaseStateNode(ContextOfATNParsing_v2 context, ContextOfATNSlaveNAPStateNode contextOfState)
        {
            Context = context;
            ContextOfState = contextOfState;
        }

        protected ContextOfATNParsing_v2 Context;
        protected ITargetOfATNSlaveNAPNode Target;
        protected ContextOfATNSlaveNAPStateNode ContextOfState;

        public abstract ATNSlaveNAPBaseStateNode Fork(ContextOfATNParsing_v2 context, ContextOfATNSlaveNAPStateNode contextOfState);
        public abstract bool Run(ATNExtendedToken token);
    }
}
