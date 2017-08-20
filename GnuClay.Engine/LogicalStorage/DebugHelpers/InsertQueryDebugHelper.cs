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
            var tmpSb = new StringBuilder("INSERT ");

            foreach(var tmpItem in query.Items)
            {
                var itemKey = tmpItem.Key;

                if (itemKey > 0)
                {
                    tmpSb.Append($"{dataDictionary.GetValue(itemKey)}:");
                }
                tmpSb.Append("{");
                tmpSb.Append(RuleInstanceDebugHelper.ConvertToString(tmpItem, dataDictionary));
                tmpSb.Append("},");
            }

            _StringBuilderHelper.TruncateEnd(tmpSb);

            return tmpSb.ToString();
        }
    }
}
