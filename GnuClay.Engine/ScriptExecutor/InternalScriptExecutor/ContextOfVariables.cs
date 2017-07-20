using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.InternalScriptExecutor
{
    public class ContextOfVariables
    {
        public void SetValue(ulong variableKey, IValue value)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"SetValue variableKey = {variableKey} value = {value}");

            mVariablesDict[variableKey] = value;
        }

        public IValue GetValue(ulong variableKey)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"GetValue variableKey = {variableKey}");

            return mVariablesDict[variableKey];
        }

        private Dictionary<ulong, IValue> mVariablesDict = new Dictionary<ulong, IValue>();

        public string ToDbgString()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine("Begin Variables");

            foreach (var kvpItem in mVariablesDict)
            {
                tmpSb.AppendLine($"key = {kvpItem.Key} value = {kvpItem.Value}");
            }

            tmpSb.AppendLine("End Variables");

            return tmpSb.ToString();
        }
    }
}
