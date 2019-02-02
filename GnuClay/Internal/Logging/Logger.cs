using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Internal.Logging
{
    public class Logger: BaseEngineComponent, ILog
    {
        public Logger(CommonContext context)
            : base(context, null)
        {
            Logger = this;
        }
    }
}
