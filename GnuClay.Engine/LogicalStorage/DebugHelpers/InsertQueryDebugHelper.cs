using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.DebugHelpers
{
    public static class InsertQueryDebugHelper
    {
        public static string ConvertToString(InsertQuery query, IReadOnlyStorageDataDictionary dataDictionary)
        {
            var tmpSb = new StringBuilder("INSERT ");

            foreach(var tmpItem in query.Items)
            {
                tmpSb.Append("{");
                tmpSb.Append(RuleInstanceDebugHelper.ConvertToString(tmpItem, dataDictionary));
                tmpSb.Append("},");
            }

            _StringBuilderHelper.TruncateEnd(tmpSb);

            return tmpSb.ToString();
        }
    }
}
