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

            if (query.IsDeleteQuery)
            {
                tmpSb.Append("DELETE");
            }
            else
            {
                tmpSb.Append("READ");
            }

            tmpSb.Append(" ");

            tmpSb.Append("{");
            tmpSb.Append(ExpressionNodeDebugHelper.ConvertToString(query.SelectedTree, dataDictionary));
            tmpSb.Append("}");

            return tmpSb.ToString();
        }
    }
}
