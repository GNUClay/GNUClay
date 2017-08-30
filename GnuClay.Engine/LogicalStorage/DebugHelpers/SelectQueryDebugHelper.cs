using GnuClay.CommonClientTypes;
using GnuClay.Engine.Parser.CommonData;
using System.Text;

namespace GnuClay.Engine.LogicalStorage.DebugHelpers
{
    public static class SelectQueryDebugHelper
    {
        public static string ConvertToString(SelectQuery query, IReadOnlyStorageDataDictionary dataDictionary)
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append("READ {");
            tmpSb.Append(ExpressionNodeDebugHelper.ConvertToString(query.SelectedTree, dataDictionary));
            tmpSb.Append("}");

            return tmpSb.ToString();
        }
    }
}
