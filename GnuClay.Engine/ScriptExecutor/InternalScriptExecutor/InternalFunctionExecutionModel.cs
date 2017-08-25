using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.InternalScriptExecutor
{
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

        public EntityAction mEntityAction = null;
        public GnuClayThreadExecutionContext mExecutionContext = null;
        public void NBeginCall()
        {
            CurrentFunction = null;
            CurrentHolder = null;
            Target = 0;
            IsCalledByNamedParameters = null;
            CurrentPositionOfParam = -1;
            NamedParams = null;
            PositionedParams = null;
            CurrentParamName = null;
            CurrentParamValue = null;
        }

        public IValue CurrentHolder { get; set; }
        public IValue CurrentFunction { get; set; }
        public ulong Target { get; set; }

        private bool? mIsCalledByNamedParameters = null;
        public bool? IsCalledByNamedParameters
        {
            get
            {
                return mIsCalledByNamedParameters;
            }

            set
            {
                if (mIsCalledByNamedParameters == value)
                {
                    return;
                }

                mIsCalledByNamedParameters = value;

                if (mIsCalledByNamedParameters.HasValue)
                {
                    if (mIsCalledByNamedParameters.Value)
                    {
                        NamedParams = new List<NamedParamInfo>();
                    }
                    else
                    {
                        PositionedParams = new List<PositionParamInfo>();
                    }
                }
            }
        }

        public bool? IsSetParamName = false;
        public IValue CurrentParamName { get; set; }
        public IValue CurrentParamValue { get; set; }

        public List<NamedParamInfo> NamedParams { get; set; }
        public List<PositionParamInfo> PositionedParams { get; set; }
        public int CurrentPositionOfParam = -1;

        public void NProcessParam()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin NProcessParam");
#endif
            if (IsCalledByNamedParameters.Value)
            {
                var tmpNamedParamInfo = new NamedParamInfo();
                tmpNamedParamInfo.ParamName = CurrentParamName;
                tmpNamedParamInfo.ParamValue = CurrentParamValue;

                NamedParams.Add(tmpNamedParamInfo);

                return;
            }

            CurrentPositionOfParam++;
            var tmpPositiondedParamInfo = new PositionParamInfo();
            tmpPositiondedParamInfo.ParamValue = CurrentParamValue;
            tmpPositiondedParamInfo.Position = CurrentPositionOfParam;
            PositionedParams.Add(tmpPositiondedParamInfo);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End NProcessParam");
#endif
        }

#if DEBUG
        public string ToDbgString()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine("Begin ValuesStack");

            foreach (var val in ValuesStack)
            {
                tmpSb.AppendLine(val?.ToString());
            }

            tmpSb.AppendLine("End ValuesStack");

            tmpSb.AppendLine($"{nameof(CurrentHolder)} = {CurrentHolder}");
            tmpSb.AppendLine($"{nameof(CurrentFunction)} = {CurrentFunction}");
            tmpSb.AppendLine($"{nameof(Target)} = {Target}");
            tmpSb.AppendLine($"{nameof(IsCalledByNamedParameters)} = {IsCalledByNamedParameters}");
            tmpSb.AppendLine($"{nameof(IsSetParamName)} = {IsSetParamName}");
            tmpSb.AppendLine($"{nameof(CurrentParamName)} = {CurrentParamName}");
            tmpSb.AppendLine($"{nameof(CurrentParamValue)} = {CurrentParamValue}");

            if (NamedParams == null)
            {
                tmpSb.AppendLine($"{nameof(NamedParams)} = null");
            }
            else
            {
                tmpSb.AppendLine($"Begin {nameof(NamedParams)}");

                foreach (var item in NamedParams)
                {
                    tmpSb.AppendLine($"item = {item}");
                }

                tmpSb.AppendLine($"End {nameof(NamedParams)}");
            }

            if (PositionedParams == null)
            {
                tmpSb.AppendLine($"{nameof(PositionedParams)} = null");
            }
            else
            {
                tmpSb.AppendLine($"Begin {nameof(PositionedParams)}");

                foreach (var item in PositionedParams)
                {
                    tmpSb.AppendLine($"item = {item}");
                }

                tmpSb.AppendLine($"End {nameof(PositionedParams)}");
            }

            tmpSb.AppendLine($"{nameof(CurrentPositionOfParam)} = {CurrentPositionOfParam}");
            tmpSb.Append(mExecutionContext.ContextOfVariables.ToDbgString());

            return tmpSb.ToString();
        }
#endif
    }
}
