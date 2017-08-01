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

            return CreateVariable(variableKey, mUndefinedValue);
        }

        public IValue CreateVariable(ulong variableKey, IValue variableValue)
        {
            var tmpVariable = new VariableValue(variableValue);
            mVariablesDict[variableKey] = tmpVariable;

            return tmpVariable;
        }

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

            return tmpSb.ToString();
        }
#endif
    }
}
