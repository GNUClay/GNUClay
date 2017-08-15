using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.InternalScriptExecutor
{
    public class InternalFunctionExecutionModel
    {
        public InternalFunctionExecutionModel(FunctionModel source, GnuClayEngineComponentContext mainContext, GnuClayThreadExecutionContext executionContext, EntityAction entityAction)
        {
            mMainContext = mainContext;
            mCommonValuesFactory = mainContext.CommonValuesFactory;
            mExecutionContext = executionContext;

            mEntityAction = entityAction;
            mEntityAction.State = EntityActionState.Running;

            mFunction = source;

            mCurrentCommand = mFunction.FirstCommand;
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private GnuClayThreadExecutionContext mExecutionContext = null;
        private CommonValuesFactory mCommonValuesFactory = null;
        private FunctionModel mFunction = null;
        private EntityAction mEntityAction = null;

        public ScriptCommand FirstCommand
        {
            get
            {
                return mFunction.FirstCommand;
            }
        }

        public ScriptCommand this[int lineNumber]
        {
            get
            {
                return mFunction[lineNumber];
            }
        }

        public Stack<IValue> ValuesStack { get; set; } = new Stack<IValue>();

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
                tmpSb.AppendLine(val.ToString());
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

#if DEBUG
        public void RunDbg()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("RunDbg");
            NLog.LogManager.GetCurrentClassLogger().Info($"RunDbg ToDbgString = {ToDbgString()}");

            while (mIsRun)
            {
                NRun();
            }
        }
#endif

        private bool mIsRun = true;

        private void Exit()
        {
            mIsRun = false;
            mEntityAction.State = EntityActionState.Completed;
        }

        private void ExitWithError(IValue error)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ExitWithError error = {error}");
#endif
            mIsRun = false;
            mEntityAction.State = EntityActionState.Faulted;
            mEntityAction.Error = error;
        }

        private void ExitWithResult(IValue result)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ExitWithResult result = {result}");
#endif
            mIsRun = false;
            mEntityAction.State = EntityActionState.Completed;
            mEntityAction.Result = result;
        }

        private ScriptCommand mCurrentCommand = null;

        private void NRun()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("NRun");
#endif
            if (mCurrentCommand == null)
            {
                Exit();
                return;
            }

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"NRun Item {mCurrentCommand.ToDbgString()}");
#endif
            var operationCode = mCurrentCommand.OperationCode;

            switch (operationCode)
            {
                case OperationCode.Nop:
                    ProcessNop();
                    break;

                case OperationCode.PushConst:
                    ProcessPushConst();
                    break;

                case OperationCode.PushEntity:
                    ProcessPushEntity();
                    break;

                case OperationCode.PushProp:
                    ProcessPushProp();
                    break;

                case OperationCode.PushVar:
                    ProcessPushVar();
                    break;

                case OperationCode.BeginCall:
                    ProcessBeginCall();
                    break;

                case OperationCode.BeginCallMethod:
                    ProcessBeginCallMethod();
                    break;

                case OperationCode.BeginCallMethodOfPrevEntity:
                    ProcessBeginCallMethodOfPrevEntity();
                    break;

                case OperationCode.SetTarget:
                    ProcessSetTarget();
                    break;

                case OperationCode.SetParamName:
                    ProcessSetParamName();
                    break;

                case OperationCode.SetParamVal:
                    ProcessSetParamVal();
                    break;

                case OperationCode.CallUnOp:
                    ProcessCallUnOp();
                    break;

                case OperationCode.CallBinOp:
                    ProcessCallBinOp();
                    break;

                case OperationCode.Call:
                    ProcessCall();
                    break;

                case OperationCode.CallByPos:
                    ProcessCallByPos();
                    break;

                case OperationCode.CallAsync:
                    ProcessCallAsync();
                    break;

                case OperationCode.CallAsyncByPos:
                    ProcessCallAsyncByPos();
                    break;

                case OperationCode.JumpIfFalse:
                    ProcessJumpIfFalse();
                    break;

                case OperationCode.Jump:
                    ProcessJump();
                    break;

                case OperationCode.Return:
                    ProcessReturn();
                    break;

                case OperationCode.ReturnValue:
                    ProcessReturnValue();
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(operationCode), operationCode, null);
            }

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"NRun ToDbgString = {ToDbgString()}");
#endif
        }

        private void ProcessNop()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessNop");
#endif
            mCurrentCommand = mCurrentCommand.Next;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessNop");
#endif
        }

        private void ProcessPushConst()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessPushConst");
#endif
            var value = mMainContext.ConstTypeProvider.CreateConstValue(mCurrentCommand.Key, mCurrentCommand.Value);
            ValuesStack.Push(value);
            mCurrentCommand = mCurrentCommand.Next;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessPushConst");
#endif
        }

        private void ProcessPushEntity()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessPushEntity");
#endif
            var value = new EntityValue(mCurrentCommand.Key);
            ValuesStack.Push(value);

            mCurrentCommand = mCurrentCommand.Next;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessPushEntity");
#endif
        }

        private void ProcessPushProp()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessPushProp");
#endif

            var tmpHolder = ValuesStack.Pop();
            var propertyKey = mCurrentCommand.Key;
            var resultOfCalling = mMainContext.PropertiesEngine.FindProperty(tmpHolder, propertyKey);
            PostProcessCall(resultOfCalling);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessPushProp");
#endif
        }

        private void ProcessPushVar()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessPushVar");
#endif

            var varKey = mCurrentCommand.Key;
            var tmpVar = mExecutionContext.ContextOfVariables.GetVariable(varKey);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessPushVar tmpVar = {tmpVar}");
#endif

            ValuesStack.Push(tmpVar);
            mCurrentCommand = mCurrentCommand.Next;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessPushVar");
#endif
        }

        private void ProcessBeginCall()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessBeginCall");
#endif

            NBeginCall();

            throw new NotImplementedException();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessBeginCall");
#endif
        }

        private void ProcessBeginCallMethod()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessBeginCallMethod");
#endif
            NBeginCall();
            var functionValue = new EntityValue(mCurrentCommand.Key);
            CurrentFunction = functionValue;
            mCurrentCommand = mCurrentCommand.Next;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessBeginCallMethod");
#endif
        }

        private void ProcessBeginCallMethodOfPrevEntity()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessBeginCallMethodOfPrevEntity");
#endif
            NBeginCall();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessBeginCallMethodOfPrevEntity ToDbgString = {ToDbgString()}");
#endif
            CurrentHolder = ValuesStack.Pop();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessBeginCallMethodOfPrevEntity ToDbgString = {ToDbgString()}");
#endif
            var functionValue = new EntityValue(mCurrentCommand.Key);
            CurrentFunction = functionValue;
            mCurrentCommand = mCurrentCommand.Next;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessBeginCallMethodOfPrevEntity");
#endif
        }

        private void ProcessSetTarget()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessSetTarget");
#endif
            var targetValue = ValuesStack.Pop();
            Target = targetValue.TypeKey;
            mCurrentCommand = mCurrentCommand.Next;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessSetTarget");
#endif
        }

        private void ProcessSetParamName()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessSetParamName");
#endif
            if (IsCalledByNamedParameters == null)
            {
                IsCalledByNamedParameters = true;
                IsSetParamName = true;
            }
            else
            {
                if (!IsCalledByNamedParameters.Value)
                {
                    throw new NotSupportedException();
                }

                if (IsSetParamName.Value)
                {
                    throw new NotSupportedException();
                }

                IsSetParamName = true;
            }

            var tmpVal = ValuesStack.Pop();
            CurrentParamName = tmpVal;
            mCurrentCommand = mCurrentCommand.Next;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessSetParamName");
#endif
        }

        private void ProcessSetParamVal()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessSetParamVal");
#endif
            NProcessSetParamVal();
            mCurrentCommand = mCurrentCommand.Next;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessSetParamVal");
#endif
        }

        private void NProcessSetParamVal()
        {
            if (IsCalledByNamedParameters == null)
            {
                IsCalledByNamedParameters = false;
            }
            else
            {
                if (!IsCalledByNamedParameters.Value && IsSetParamName.Value)
                {
                    throw new NotSupportedException();
                }
            }

            IsSetParamName = false;
            var tmpVal = ValuesStack.Pop();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"NProcessSetParamVal tmpVal = {tmpVal}");
#endif

            CurrentParamValue = tmpVal;

            NProcessParam();
        }

        private void NRevertPosotionedParams()
        {
            PositionedParams.Reverse();

            var n = 0;

            foreach(var param in PositionedParams)
            {
                param.Position = n;
                n++;
            }
        }

        private void ProcessCallUnOp()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessCallUnOp");
#endif
            NBeginCall();
            NProcessSetParamVal();
            CurrentFunction = new EntityValue(mCurrentCommand.Key);
            var resultOfCalling = mMainContext.FunctionsEngine.CallByPositionedParameters(mExecutionContext, mEntityAction, CurrentFunction, CurrentHolder, Target, PositionedParams);
            PostProcessCall(resultOfCalling);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessCallUnOp");
#endif
        }

        private void ProcessCallBinOp()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessCallBinOp");
#endif
            NBeginCall();
            NProcessSetParamVal();
            NProcessSetParamVal();
            NRevertPosotionedParams();
            CurrentFunction = new EntityValue(mCurrentCommand.Key);
            var resultOfCalling = mMainContext.FunctionsEngine.CallByPositionedParameters(mExecutionContext, mEntityAction, CurrentFunction, CurrentHolder, Target, PositionedParams);
            PostProcessCall(resultOfCalling);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessCallBinOp");
#endif
        }

        private void ProcessCall()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessCall");
#endif
            var resultOfCalling = mMainContext.FunctionsEngine.CallByNamedParameters(mExecutionContext, mEntityAction, CurrentFunction, CurrentHolder, Target, NamedParams);
            PostProcessCall(resultOfCalling);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessCall");
#endif
        }

        private void ProcessCallByPos()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessCallByPos");
#endif
            NRevertPosotionedParams();
            var resultOfCalling = mMainContext.FunctionsEngine.CallByPositionedParameters(mExecutionContext, mEntityAction, CurrentFunction, CurrentHolder, Target, PositionedParams);
            PostProcessCall(resultOfCalling);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessCallByPos");
#endif
        }

        private void ProcessCallAsync()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessCallAsync");
#endif
            var resultOfCalling = mMainContext.FunctionsEngine.CallAsyncByNamedParameters(mExecutionContext, mEntityAction, CurrentFunction, CurrentHolder, Target, NamedParams);
            PostProcessCall(resultOfCalling);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessCallAsync");
#endif
        }

        private void ProcessCallAsyncByPos()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessCallAsyncByPos");
#endif
            var resultOfCalling = mMainContext.FunctionsEngine.CallAsyncByPositionedParameters(mExecutionContext, mEntityAction, CurrentFunction, CurrentHolder, Target, PositionedParams);
            PostProcessCall(resultOfCalling);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessCallAsyncByPos");
#endif
        }

        private void PostProcessCall(ResultOfCalling resultOfCalling)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin PostProcessCall");
            NLog.LogManager.GetCurrentClassLogger().Info($"PostProcessCall resultOfCalling = {resultOfCalling}");
#endif
            if (!resultOfCalling.Success)
            {
                ExitWithError(resultOfCalling.Error);
                return;
            }

            ValuesStack.Push(resultOfCalling.Result);
            mCurrentCommand = mCurrentCommand.Next;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End PostProcessCall");
#endif
        }

        private void ProcessJumpIfFalse()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessJumpIfFalse");
#endif
            throw new NotImplementedException();
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessJumpIfFalse");
#endif
        }

        private void ProcessJump()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessJump");
#endif
            throw new NotImplementedException();
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessJump");
#endif
        }

        private void ProcessReturn()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessReturn");
#endif
            Exit();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessReturn");
#endif
        }

        private void ProcessReturnValue()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessReturnValue");
#endif
            var tmpValue = ValuesStack.Pop();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessBeginCallMethodOfPrevEntity ToDbgString = {ToDbgString()}");
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessBeginCallMethodOfPrevEntity tmpValue = {tmpValue}");
#endif
            
            if(tmpValue.IsValueContainer)
            {
                tmpValue = tmpValue.ValueFromContainer;
            }

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessBeginCallMethodOfPrevEntity NEXT tmpValue = {tmpValue}");
#endif

            ExitWithResult(tmpValue);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessReturnValue");
#endif
        }
    }
}
