using GnuClay.CommonClientTypes;
using GnuClay.CommonClientTypes.CommonData;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.InternalScriptExecutor
{
    [Serializable]
    public class ContextOfVariables: ISmartToString
    {
        public ContextOfVariables(GnuClayEngineComponentContext context)
        {
            mContext = context;
            mNullValue = mContext.CommonValuesFactory.NullValue();
        }

        [NonSerialized]
        private GnuClayEngineComponentContext mContext = null;
        [NonSerialized]
        private IValue mNullValue = null;

        public IValue GetVariable(ulong variableKey)
        {
            if(mVariablesDict.ContainsKey(variableKey))
            {
                return mVariablesDict[variableKey];
            }

            return CreateVariable(variableKey, mNullValue);
        }

        public IValue CreateVariable(ulong variableKey, IValue variableValue)
        {
            var tmpVariable = new VariableValue(variableValue);
            mVariablesDict[variableKey] = tmpVariable;

            return tmpVariable;
        }

        private Dictionary<ulong, IValue> mVariablesDict = new Dictionary<ulong, IValue>();

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return ToString(null, 0);
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="dataDictionary">An instance of the DataDictionary for human readable presentation.</param>
        /// <param name="indent">Indent for better formatting.</param>
        /// <returns>The string representation of this instance.</returns>
        public string ToString(IReadOnlyStorageDataDictionary dataDictionary, int indent)
        {
            var spacesString = _ObjectHelper.CreateSpaces(indent);
            var nextIndent = indent + 4;

            var tmpSb = new StringBuilder();

            tmpSb.AppendLine($"{spacesString}Begin ContextOfVariables");
            tmpSb.AppendLine($"{spacesString}Begin Variables");

            var nextSpacesString = _ObjectHelper.CreateSpaces(nextIndent);
            var nextNextIdent = nextIndent + 4;

            foreach (var kvpItem in mVariablesDict)
            {
                var itemSb = new StringBuilder();
                itemSb.AppendLine($"{nextSpacesString}key = {kvpItem.Key}");
                if(dataDictionary != null)
                {
                    itemSb.AppendLine($"{nextSpacesString}varName = {dataDictionary.GetValue(kvpItem.Key)}");
                }
                itemSb.AppendLine($"{nextSpacesString}value = {kvpItem.Value.ToString(dataDictionary, nextNextIdent)}");
                tmpSb.AppendLine(itemSb.ToString());
            }

            tmpSb.AppendLine($"{spacesString}End Variables");
            tmpSb.AppendLine($"{spacesString}Begin ContextOfVariables");
            return tmpSb.ToString();
        }
    }
}
