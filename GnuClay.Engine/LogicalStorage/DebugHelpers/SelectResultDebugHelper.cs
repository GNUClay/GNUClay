using GnuClay.CommonClientTypes;
using GnuClay.CommonClientTypes.CommonData;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.LogicalStorage.CommonData;
using System;
using System.Text;

namespace GnuClay.Engine.LogicalStorage.DebugHelpers
{
    public class SelectResultDebugHelper
    {
        public static string ConvertToString(SelectResult source, IReadOnlyStorageDataDictionary dataDictionary)
        {
            return ConvertToString(LogicalStorageConvertors.Convert(source), dataDictionary);
        }

        public static string ConvertToString(ISelectResult source, IReadOnlyStorageDataDictionary dataDictionary)
        {
            var tmpSb = new StringBuilder();

            if (!source.Success)
            {
                tmpSb.AppendLine("Has errors!");
                tmpSb.AppendLine($"ErrorText `{source.ErrorText}`");
            }

            if(!source.HaveBeenFound)
            {
                tmpSb.AppendLine("no");
                return tmpSb.ToString();
            }

            tmpSb.AppendLine("yes");

            foreach(var tmpItem in source.Items)
            {
                tmpSb.AppendLine(ConvertToString(tmpItem, dataDictionary));
            }

            return tmpSb.ToString();
        }

        public static string ConvertToString(SelectResultItem source, IReadOnlyStorageDataDictionary dataDictionary)
        {
            return ConvertToString(LogicalStorageConvertors.Convert(source), dataDictionary);
        }

        public static string ConvertToString(ISelectResultItem source, IReadOnlyStorageDataDictionary dataDictionary)
        {
            var tmpSb = new StringBuilder();

            foreach (var tmpParamInfo in source.Params)
            {
                tmpSb.Append(dataDictionary.GetValue(tmpParamInfo.ParamKey));
                tmpSb.Append(" = ");
                switch(tmpParamInfo.Kind)
                {
                    case ExpressionNodeKind.Entity:
                        tmpSb.Append(dataDictionary?.GetValue(tmpParamInfo.EntityKey));
                        break;

                    case ExpressionNodeKind.Value:
                        if(tmpParamInfo.Value == null)
                        {
                            tmpSb.Append("null");
                        }
                        else
                        {
                            tmpSb.Append(tmpParamInfo.Value);
                        }
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(tmpParamInfo.Kind), tmpParamInfo.Kind.ToString());
                }
                
                tmpSb.Append(";");
            }

            _StringBuilderHelper.TruncateEnd(tmpSb);

            return tmpSb.ToString();
        }
    }
}
