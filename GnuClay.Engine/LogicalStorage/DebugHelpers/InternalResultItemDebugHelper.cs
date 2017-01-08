using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.LogicalStorage.InternalResolver;
using System.Text;

namespace GnuClay.Engine.LogicalStorage.DebugHelpers
{
    public static class InternalResultItemDebugHelper
    {
        public static string ConvertToString(InternalResultItem source, IReadOnlyStorageDataDictionary dataDictionary)
        {
            var tmpSb = new StringBuilder();

            foreach(var tmpParamInfo in source.ParamsValues)
            {
                tmpSb.Append(dataDictionary.GetValue(tmpParamInfo.ParamKey));
                tmpSb.Append(" = ");
                tmpSb.Append(dataDictionary.GetValue(tmpParamInfo.EntityKey));
                tmpSb.Append(";");
            }

            _StringBuilderHelper.TruncateEnd(tmpSb);

            return tmpSb.ToString();
        }
    }
}
