using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Internal.LogicalStorages
{
    public class LogicalStorage : BaseEngineLoggedComponent
    {
        public LogicalStorage(CommonContext context, ILog logger)
            : base(context, logger)
        {
        }
    }
}
