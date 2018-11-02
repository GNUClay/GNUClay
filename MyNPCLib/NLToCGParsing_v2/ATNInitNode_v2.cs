using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing_v2.ATNNodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class ATNInitNode_v2: BaseATNNode_v2
    {
        public ATNInitNode_v2(ContextOfATNParsing_v2 context)
            : base(context, null)
        {
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Init;

        protected override void ImplementGoalToken()
        {
        }

        protected override void ProcessNextToken()
        {
#if DEBUG
            LogInstance.Log("Begin");
#endif

            throw new NotImplementedException();
        }
    }
}
