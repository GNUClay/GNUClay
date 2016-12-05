using GnuClay.CommonClientTypes;
using GnuClay.Engine.Parser.CommonData;
using System.Text;

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
