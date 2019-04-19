using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Internal.CompillingSystem
{
    public class Compiler: BaseEngineLoggedComponent
    {
        public Compiler(CommonContext context, ILog logger)
            : base(context, logger)
        {
            //Log("Start");
        }
    }
}
