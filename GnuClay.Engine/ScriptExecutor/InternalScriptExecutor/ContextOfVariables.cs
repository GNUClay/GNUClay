using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.InternalScriptExecutor
{
    public class ContextOfVariables
    {
        public ContextOfVariables(GnuClayEngineComponentContext context)
        {
            mContext = context;
            mUndefinedValue = mContext.CommonValuesFactory.UndefinedValue();
        }

        private GnuClayEngineComponentContext mContext = null;
        private IValue mUndefinedValue = null;

        public IValue GetVariable(ulong variableKey)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"GetVariable variableKey = {variableKey}");
#endif

            if(mVariablesDict.ContainsKey(variableKey))
            {
                return mVariablesDict[variableKey];
            }

            var tmpVariable = new VariableValue(mUndefinedValue);
            mVariablesDict[variableKey] = tmpVariable;

            return tmpVariable;
        }

        public void SetValue(ulong variableKey, IValue value)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"SetValue variableKey = {variableKey} value = {value}");
#endif
            mVariablesValuesDict[variableKey] = value;
        }

        public IValue GetValue(ulong variableKey)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"GetValue variableKey = {variableKey}");
#endif
            return mVariablesValuesDict[variableKey];
        }

        private Dictionary<ulong, IValue> mVariablesValuesDict = new Dictionary<ulong, IValue>();
        private Dictionary<ulong, IValue> mVariablesDict = new Dictionary<ulong, IValue>();

#if DEBUG
        public string ToDbgString()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine("Begin Variables");

            foreach (var kvpItem in mVariablesDict)
            {
                tmpSb.AppendLine($"key = {kvpItem.Key} value = {kvpItem.Value}");
            }

            tmpSb.AppendLine("End Variables");

            tmpSb.AppendLine("Begin Variable Value");

            foreach (var kvpItem in mVariablesValuesDict)
            {
                tmpSb.AppendLine($"key = {kvpItem.Key} value = {kvpItem.Value}");
            }

            tmpSb.AppendLine("End Variable Value");

            return tmpSb.ToString();
        }
#endif
    }
}
