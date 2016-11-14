using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.LogicalStorage.CommonData;
using System.Text;

namespace GnuClay.Engine.LogicalStorage.DebugHelpers
{
    public class SelectResultDebugHelper
    {
        public static string ConvertToString(SelectResult source, IReadOnlyStorageDataDictionary dataDictionary, IReadOnlyStorageDataDictionary localStorage = null)
        {
            if(!source.Success)
            {
                return "no";
            }

            if (localStorage == null)
            {
                localStorage = new StorageDataDictionaryForVariables();
            }

            var tmpSb = new StringBuilder();

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
                tmpSb.Append(dataDictionary.GetValue(tmpParamInfo.EntityKey));
                tmpSb.Append(";");
            }

            _StringBuilderHelper.TruncateEnd(tmpSb);

            return tmpSb.ToString();
        }
    }
}
