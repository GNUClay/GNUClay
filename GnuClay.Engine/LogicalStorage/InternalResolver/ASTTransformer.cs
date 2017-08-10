using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using GnuClay.Engine.Parser.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.InternalResolver
{
    public class ASTTransformer: BaseLogicalStorageComponent
    {
        public ASTTransformer(GnuClayEngineComponentContext context, LogicalStorageContext logicalContext)
            : base(context, logicalContext)
        {
        }

        private StorageDataDictionary mDataDictionary = null;

        public override void FirstInit()
        {
            mDataDictionary = Context.DataDictionary;
        }

        public SelectQuery GetRewritingQuery(RuleInstance targetItem)
        {
            var builder = new RewritingSelectQueryBuilder(Context, LogicalContext);
            return builder.Run(targetItem);
        }
    }
}
