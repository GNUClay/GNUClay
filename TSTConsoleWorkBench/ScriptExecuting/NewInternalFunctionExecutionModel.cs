using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewInternalFunctionExecutionModel
    {
        public NewInternalFunctionExecutionModel(FunctionModel source, GnuClayEngineComponentContext mainContext,  NewGnuClayThreadExecutionContext executionContext)
        {
            mMainContext = mainContext;
            mExecutionContext = executionContext;
            mFunction = source;

            mCurrentCommand = mFunction.FirstCommand;
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private NewGnuClayThreadExecutionContext mExecutionContext = null;
        private FunctionModel mFunction = null;

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

        public Stack<INewValue> ValuesStack { get; set; } = new Stack<INewValue>();

        public void NBeginCall()
        {
            CurrentFunction = null;
            CurrentHolder = null;
            Target = 0;
            IsCalledByNamedParameters = null;
            CurrentPositionOfParam = -1;
        }

        public INewValue CurrentHolder { get; set; }
        public INewValue CurrentFunction { get; set; }
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
                if(mIsCalledByNamedParameters == value)
                {
                    return;
                }

                mIsCalledByNamedParameters = value;

                if(mIsCalledByNamedParameters.HasValue)
                {
                    if(mIsCalledByNamedParameters.Value)
                    {
                        NamedParams = new List<NewNamedParamInfo>();
                    }
                    else
                    {
                        PositionedParams = new List<NewPositionParamInfo>();
                    }
                }
            }
        }

        public bool? IsSetParamName = false;
        public INewValue CurrentParamName { get; set; }
        public INewValue CurrentParamValue { get; set; }

        public List<NewNamedParamInfo> NamedParams { get; set; }
        public List<NewPositionParamInfo> PositionedParams { get; set; }
        public int CurrentPositionOfParam = -1;

        public void NProcessParam()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin NProcessParam");

            if(IsCalledByNamedParameters.Value)
            {
                var tmpNamedParamInfo = new NewNamedParamInfo();
                tmpNamedParamInfo.ParamName = CurrentParamName;
                tmpNamedParamInfo.ParamValue = CurrentParamValue;

                NamedParams.Add(tmpNamedParamInfo);

                return;
            }

            CurrentPositionOfParam++;

            var tmpPositiondedParamInfo = new NewPositionParamInfo();
            tmpPositiondedParamInfo.ParamValue = CurrentParamValue;
            tmpPositiondedParamInfo.Position = CurrentPositionOfParam;

            PositionedParams.Add(tmpPositiondedParamInfo);

            NLog.LogManager.GetCurrentClassLogger().Info("End NProcessParam");
        }

        public string ToDbgString()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine("Begin ValuesStack");

            foreach (var val in ValuesStack)
            {
                tmpSb.AppendLine(val.ToString());
            }

            tmpSb.AppendLine("End ValuesStack");

            tmpSb.AppendLine($"{nameof(CurrentFunction)} = {CurrentFunction}");
            tmpSb.AppendLine($"{nameof(Target)} = {Target}");
            tmpSb.AppendLine($"{nameof(IsCalledByNamedParameters)} = {IsCalledByNamedParameters}");
            tmpSb.AppendLine($"{nameof(IsSetParamName)} = {IsSetParamName}");
            tmpSb.AppendLine($"{nameof(CurrentParamName)} = {CurrentParamName}");
            tmpSb.AppendLine($"{nameof(CurrentParamValue)} = {CurrentParamValue}");

            if(NamedParams == null)
            {
                tmpSb.AppendLine($"{nameof(NamedParams)} = null");
            }
            else
            {
                tmpSb.AppendLine($"Begin {nameof(NamedParams)}");

                foreach(var item in NamedParams)
                {
                    tmpSb.AppendLine($"item = {item}");
                }

                tmpSb.AppendLine($"End {nameof(NamedParams)}");
            }

            if(PositionedParams == null)
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
            
            return tmpSb.ToString();
        }

        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");
            NLog.LogManager.GetCurrentClassLogger().Info($"Run ToDbgString = {ToDbgString()}");

            while (mIsRun)
            {
                NRun();
            }
        }

        private bool mIsRun = true;

        private void Exit()
        {
            mIsRun = false;
        }

        private ScriptCommand mCurrentCommand = null;

        private void NRun()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("NRun");

            if (mCurrentCommand == null)
            {
                Exit();
                return;
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"NRun Item {mCurrentCommand.ToDbgString()}");

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

                case OperationCode.PushValFromProp:
                    ProcessPushValFromProp();
                    break;

                case OperationCode.PushValFromVal:
                    ProcessPushValFromVal();
                    break;

                case OperationCode.SetValToProp:
                    ProcessSetValToProp();
                    break;

                case OperationCode.SetValToVar:
                    ProcessSetValToVar();
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

                case OperationCode.JumpIfFalse:
                    ProcessJumpIfFalse();
                    break;

                case OperationCode.Jump:
                    ProcessJump();
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(operationCode), operationCode, null);
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"NRun ToDbgString = {ToDbgString()}");
        }

        private void ProcessNop()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessNop");

            mCurrentCommand = mCurrentCommand.Next;

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessNop");
        }

        private void ProcessPushConst()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessPushConst");

            var value = new NewConstValue(mCurrentCommand.Key, mCurrentCommand.Value);
            ValuesStack.Push(value);
            mCurrentCommand = mCurrentCommand.Next;

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessPushConst");
        }

        private void ProcessPushEntity()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessPushEntity");

            var value = new NewEntityValue(mCurrentCommand.Key);
            ValuesStack.Push(value);

            mCurrentCommand = mCurrentCommand.Next;

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessPushEntity");
        }

        private void ProcessPushProp()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessPushProp");

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessPushProp");
        }

        private void ProcessPushVar()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessPushVar");

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessPushVar");
        }

        private void ProcessPushValFromProp()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessPushValFromProp");

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessPushValFromProp");
        }

        private void ProcessPushValFromVal()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessPushValFromVal");

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessPushValFromVal");
        }

        private void ProcessSetValToProp()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessSetValToProp");

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessSetValToProp");
        }

        private void ProcessSetValToVar()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessSetValToVar");

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessSetValToVar");
        }

        private void ProcessBeginCall()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessBeginCall");

            NBeginCall();

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessBeginCall");
        }

        private void ProcessBeginCallMethod()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessBeginCallMethod");

            NBeginCall();

            var functionValue = new NewEntityValue(mCurrentCommand.Key);

            CurrentFunction = functionValue;
            mCurrentCommand = mCurrentCommand.Next;

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessBeginCallMethod");
        }

        private void ProcessBeginCallMethodOfPrevEntity()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessBeginCallMethodOfPrevEntity");

            NBeginCall();

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessBeginCallMethodOfPrevEntity");
        }

        private void ProcessSetTarget()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessSetTarget");

            var targetValue = ValuesStack.Pop();
            Target = targetValue.TypeKey;

            mCurrentCommand = mCurrentCommand.Next;

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessSetTarget");
        }

        private void ProcessSetParamName()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessSetParamName");

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

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessSetParamName");
        }

        private void ProcessSetParamVal()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessSetParamVal");

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
            CurrentParamValue = tmpVal;

            NProcessParam();

            mCurrentCommand = mCurrentCommand.Next;

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessSetParamVal");
        }

        private void ProcessCallUnOp()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessCallUnOp");

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessCallUnOp");
        }

        private void ProcessCallBinOp()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessCallBinOp");

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessCallBinOp");
        }

        private void ProcessCall()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessCall");

            var resultOfCalling = mExecutionContext.NewFunctionEngine.CallByNamedParameters(CurrentFunction, CurrentHolder, Target, NamedParams);

            PostProcessCall(resultOfCalling);

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessCall");
        }

        private void ProcessCallByPos()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessCallByPos");

            var resultOfCalling = mExecutionContext.NewFunctionEngine.CallByPositionedParameters(CurrentFunction, CurrentHolder, Target, PositionedParams);

            PostProcessCall(resultOfCalling);

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessCallByPos");
        }

        private void PostProcessCall(NewResultOfCalling resultOfCalling)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin PostProcessCall");
            NLog.LogManager.GetCurrentClassLogger().Info($"PostProcessCall resultOfCalling = {resultOfCalling}");

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End PostProcessCall");
        }

        private void ProcessJumpIfFalse()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessJumpIfFalse");

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessJumpIfFalse");
        }

        private void ProcessJump()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessJump");

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessJump");
        }
    }
}
