using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public abstract class BaseATNNodeFactory_v2
    {
        public abstract BaseATNNode_v2 Create(ContextOfATNParsing_v2 context);
    }
}
