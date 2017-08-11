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
        protected BaseInternalResolver(GnuClayEngineComponentContext context, LogicalStorageContext logicalContext)
        {
            Context = context;
            LogicalStorageContext = logicalContext;

            mInternalStorageEngine = logicalContext.InternalStorageEngine;
            mASTTransformer = logicalContext.ASTTransformer;
            mStorageDataDictionary = context.DataDictionary;
            mInternalResolverEngine = logicalContext.InternalResolverEngine;

           IsKey = mStorageDataDictionary.GetKey(SystemRelationsNamesConstants.Is);
        }

        protected GnuClayEngineComponentContext Context;
        protected LogicalStorageContext LogicalStorageContext;

        protected InternalStorageEngine mInternalStorageEngine = null;
        protected StorageDataDictionary mStorageDataDictionary = null;
        protected ASTTransformer mASTTransformer = null;
        protected InternalResolverEngine mInternalResolverEngine = null;

        protected ulong IsKey;
    }
}
