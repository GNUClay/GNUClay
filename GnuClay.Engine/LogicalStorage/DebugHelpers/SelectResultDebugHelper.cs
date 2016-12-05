using GnuClay.CommonClientTypes;
using GnuClay.CommonClientTypes.ResultTypes;
using GnuClay.CommonUtils.TypeHelpers;
using System.Text;

namespace GnuClay.Engine.LogicalStorage.DebugHelpers
{
    public class SelectResultDebugHelper
    {
        public static string ConvertToString(SelectResult source, IReadOnlyStorageDataDictionary dataDictionary, IReadOnlyStorageDataDictionary localStorage = null)
        {
            var tmpSb = new StringBuilder();

            if (source.HasErrors)
            {
                tmpSb.AppendLine("Has errors!");
                tmpSb.AppendLine($"ErrorText `{source.ErrorText}`");
            }

            if(!source.HaveBeenFound)
            {
                tmpSb.AppendLine("no");
                return tmpSb.ToString();
            }

            if (localStorage == null)
            {
                localStorage = new StorageDataDictionaryForVariables();
            }

            tmpSb.AppendLine("yes");

            foreach(var tmpItem in source.Items)
            {
                tmpSb.AppendLine(ConvertToString(tmpItem, dataDictionary, localStorage));
            }

            return tmpSb.ToString();
        }

        public static string ConvertToString(SelectResultItem source, IReadOnlyStorageDataDictionary dataDictionary, IReadOnlyStorageDataDictionary localStorage)
        {
            if (localStorage == null)
            {
                localStorage = new StorageDataDictionaryForVariables();
            }

            var tmpSb = new StringBuilder();

            foreach (var tmpParamInfo in source.Params)
            {
                tmpSb.Append(localStorage.GetValue(tmpParamInfo.ParamKey));
                tmpSb.Append(" = ");
                tmpSb.Append(dataDictionary?.GetValue(tmpParamInfo.EntityKey));
                tmpSb.Append(";");
            }

            _StringBuilderHelper.TruncateEnd(tmpSb);

            return tmpSb.ToString();
        }
    }
}
