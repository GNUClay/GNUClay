using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class ATNSlaveNAPNode
    {
        public ATNSlaveNAPNode()
        {
        }

        public StateOfATNSlaveNAPNode State { get; set; }

        public ATNSlaveNAPNode Fork()
        {
            var result = new ATNSlaveNAPNode();
            result.State = State;

            return result;
        }

        public void Run(ATNExtendedToken token)
        {
#if DEBUG
            LogInstance.Log($"State = {State}");
            LogInstance.Log($"token = {token}");
#endif
        }
    }
}
