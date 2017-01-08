using GnuClay.CommonClientTypes;
using GnuClay.Engine.LogicalStorage.CommonData;
using System.Text;

namespace GnuClay.Engine.LogicalStorage.DebugHelpers
{
    public static class RuleInstanceDebugHelper
    {
        public static string ConvertToString(RuleInstance source, IReadOnlyStorageDataDictionary dataDictionary)
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append(">: {");
            tmpSb.Append(ExpressionNodeDebugHelper.ConvertToString(source.Part_1.Tree, dataDictionary));
            tmpSb.Append("}");

            if(source.Part_2 != null)
            {
                tmpSb.Append(" -> {");
                tmpSb.Append(ExpressionNodeDebugHelper.ConvertToString(source.Part_2.Tree, dataDictionary));
                tmpSb.Append("}");
            }

            return tmpSb.ToString();
        }
    }
}
