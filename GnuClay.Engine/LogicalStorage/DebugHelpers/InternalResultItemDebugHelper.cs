using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.LogicalStorage.InternalResolver;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.DebugHelpers
{
    public static class InternalResultItemDebugHelper
    {
        public static string ConvertToString(InternalResultItem source, StorageDataDictionary dataDictionary, StorageDataDictionaryForVariables localStorage)
        {
            if(localStorage == null)
            {
                localStorage = new StorageDataDictionaryForVariables();
            }

            var tmpSb = new StringBuilder();

            foreach(var tmpParamInfo in source.ParamsValues)
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
