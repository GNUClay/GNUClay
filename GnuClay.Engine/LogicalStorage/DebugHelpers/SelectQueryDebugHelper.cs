using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.DebugHelpers
{
    public static class SelectQueryDebugHelper
    {
        public static string ConvertToString(SelectQuery query, IReadOnlyStorageDataDictionary dataDictionary, IReadOnlyStorageDataDictionary localDataDictionary = null)
        {
            if (localDataDictionary == null)
            {
                localDataDictionary = new StorageDataDictionaryForVariables();
            }

            var tmpSb = new StringBuilder();

            tmpSb.Append("SELECT {");
            tmpSb.Append(ExpressionNodeDebugHelper.ConvertToString(query.SelectedTree, dataDictionary, localDataDictionary));
            tmpSb.Append("}");

            return tmpSb.ToString();
        }
    }
}
