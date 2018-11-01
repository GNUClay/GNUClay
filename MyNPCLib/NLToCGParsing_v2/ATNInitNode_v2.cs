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
            LogInstance.Log("Begin");
        }

        protected override void ProcessNextToken()
        {
            LogInstance.Log("Begin");

            AddTask(new ANTSubjTransNodeFactory_v2(this, new ATNExtendedToken() {
                Content = ":)"
            }));
        }
    }
}
