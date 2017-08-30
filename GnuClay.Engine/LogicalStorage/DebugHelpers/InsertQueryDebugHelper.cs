using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.Parser.CommonData;
using System.Text;

namespace GnuClay.Engine.LogicalStorage.DebugHelpers
{
    public static class InsertQueryDebugHelper
    {
        public static string ConvertToString(InsertQuery query, IReadOnlyStorageDataDictionary dataDictionary)
        {
            var tmpSb = new StringBuilder();

            if(query.Rewrite)
            {
                tmpSb.Append("REWRITE");
            }
            else
            {
                tmpSb.Append("WRITE");
            }

            tmpSb.Append(" ");

            foreach (var tmpItem in query.Items)
            {
                tmpSb.Append($"{RuleInstanceDebugHelper.ConvertToString(tmpItem, dataDictionary)},");
            }

            _StringBuilderHelper.TruncateEnd(tmpSb);

            return tmpSb.ToString();
        }
    }
}
