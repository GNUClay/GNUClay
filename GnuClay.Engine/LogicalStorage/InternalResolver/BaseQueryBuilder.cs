using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.InternalResolver
{
    public class BaseQueryBuilder
    {
        protected BaseQueryBuilder(GnuClayEngineComponentContext context, LogicalStorageContext logicalContext)
        {
            Context = context;
            LogicalStorageContext = logicalContext;
            CommonLogicalHelper = logicalContext.CommonLogicalHelper;
            DataDictionary = Context.DataDictionary;
        }

        protected GnuClayEngineComponentContext Context;
        protected LogicalStorageContext LogicalStorageContext;
        protected StorageDataDictionary DataDictionary;
        protected CommonLogicalHelper CommonLogicalHelper;
    }
}
