using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Internal.EntitiesStorageSystem
{
    public class EntitiesStorage : BaseEngineLoggedComponent
    {
        public EntitiesStorage(CommonContext context, ILog logger)
            : base(context, logger)
        {
        }
    }
}
