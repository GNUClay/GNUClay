using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.InternalResolver
{
    public abstract class BaseInternalResolver
    {
        protected BaseInternalResolver(InternalStorageEngine engine, GnuClayEngineComponentContext context)
        {
            mContext = context;

            mInternalStorageEngine = engine;
            mStorageDataDictionary = context.DataDictionary;

            IsKey = mStorageDataDictionary.GetKey(SystemRelationsNamesConstants.Is);
        }

        protected GnuClayEngineComponentContext mContext;

        protected InternalStorageEngine mInternalStorageEngine = null;
        protected StorageDataDictionary mStorageDataDictionary = null;

        protected ulong IsKey;
    }
}
