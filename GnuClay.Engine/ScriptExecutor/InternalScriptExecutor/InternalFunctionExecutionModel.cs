using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.InternalScriptExecutor
{
    [Serializable]
    public class InternalFunctionExecutionModel
    {
        public InternalFunctionExecutionModel(FunctionModel source, EntityAction entityAction, GnuClayThreadExecutionContext executionContext)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
#endif
            mExecutionContext = executionContext;
            mFunction = source;

            mEntityAction = entityAction;
            mEntityAction.State = EntityActionState.Running;
        }

        private FunctionModel mFunction = null;

        private ScriptCommand mCurrentCommand = null;
        public void CurrentCommandIsFirst()
        {
            mCurrentCommand = mFunction.FirstCommand;
        }

        public void CurrentCommandIsNext()
        {
            mCurrentCommand = mCurrentCommand.Next;
        }

        public void CurrentCommandAtLine(int lineNumber)
        {
            mCurrentCommand = mFunction[lineNumber];
        }

        public ScriptCommand CurrentCommand
        {
            get
            {
                return mCurrentCommand;
            }
        }

        public Stack<IValue> ValuesStack { get; set; } = new Stack<IValue>();

        public void PushValue(IValue value)
        {
            ValuesStack.Push(value);
        }

        public IValue PopValue()
        {
            return ValuesStack.Pop();
        }

        public List<IValue> PopValues(int count)
        {
            var result = new List<IValue>();

            while (count > 0)
            {
                result.Add(PopValue());
                count--;
            }

            return result;
        }

        public void ClearStack()
        {
            ValuesStack.Clear();
        }

        public EntityAction mEntityAction = null;
        public GnuClayThreadExecutionContext mExecutionContext = null;

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

            tmpSb.AppendLine($"{spacesString}Begin InternalFunctionExecutionModel");
            tmpSb.AppendLine($"{spacesString}Begin ValuesStack");

            foreach (var val in ValuesStack)
            {
                tmpSb.AppendLine(val?.ToString(dataDictionary, nextIndent));
            }

            tmpSb.AppendLine($"{spacesString}End ValuesStack");

            tmpSb.Append(mExecutionContext.ContextOfVariables.ToString(dataDictionary, nextIndent));
            tmpSb.AppendLine($"{spacesString}{nameof(CurrentCommand)} = {CurrentCommand?.ToShortString(dataDictionary, 0)}"); 
            tmpSb.AppendLine($"{spacesString}End InternalFunctionExecutionModel");
            return tmpSb.ToString();
        }
    }
}
