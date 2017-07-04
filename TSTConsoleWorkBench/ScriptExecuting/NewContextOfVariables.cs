using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewContextOfVariables
    {
        public void SetValue(ulong variableKey, INewValue value)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"SetValue variableKey = {variableKey} value = {value}");

            mVariablesDict[variableKey] = value;
        }

        private Dictionary<ulong, INewValue> mVariablesDict = new Dictionary<ulong, INewValue>(); 

        public string ToDbgString()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine("Begin Variables");

            foreach(var kvpItem in mVariablesDict)
            {
                tmpSb.AppendLine($"key = {kvpItem.Key} value = {kvpItem.Value}");
            }

            tmpSb.AppendLine("End Variables");

            return tmpSb.ToString();
        }
    }
}
