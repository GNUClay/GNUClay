using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public class ContextOfSystemVariables
    {
        public ContextOfSystemVariables(GnuClayEngineComponentContext context)
        {
            mContext = context;
        }

        [NonSerialized]
        private GnuClayEngineComponentContext mContext = null;
        public ContextOfSystemVariables Parent { get; set; }

        public IValue GetVariable(ulong variableKey)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessPushSystemVar variableKey = {variableKey}");
#endif

            if (mVariablesDict.ContainsKey(variableKey))
            {
                return mVariablesDict[variableKey];
            }

            if(Parent != null)
            {
                return Parent.GetVariable(variableKey);
            }

            throw new InternalCallException(mContext.ErrorsFactory.CreateUncaughtReferenceError());
        }

        public void SetVariable(ulong variableKey, IValue value)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"SetVariable variableKey = {variableKey} value = {value.ToString(mContext.DataDictionary, 0)}");
#endif

            if(value.IsSystemVariable)
            {
                mVariablesDict[variableKey] = value;
            }
            else
            {
                mVariablesDict[variableKey] = new SystemVariableValue(value);
            }         
        }

        private Dictionary<ulong, IValue> mVariablesDict = new Dictionary<ulong, IValue>();
    }
}
