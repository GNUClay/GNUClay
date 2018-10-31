using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public abstract class BaseATNNode_v2
    {
        public BaseATNNode_v2(ContextOfATNParsing_v2 context)
        {
            Context = context;
        }

        public ContextOfATNParsing_v2 Context { get; private set; }
    }
}
