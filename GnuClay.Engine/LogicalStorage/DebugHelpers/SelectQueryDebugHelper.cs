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
        public static string ConvertToString(SelectQuery query, StorageDataDictionary dataDictionary, StorageDataDictionaryForVariables localDataDictionary)
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
