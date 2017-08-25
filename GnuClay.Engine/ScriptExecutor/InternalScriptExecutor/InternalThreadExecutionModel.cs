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
    public class InternalThreadExecutionModel
    {
        public InternalThreadExecutionModel(FunctionModel source, GnuClayEngineComponentContext mainContext, GnuClayThreadExecutionContext executionContext, EntityAction entityAction)
        {
            mMainContext = mainContext;
            mCommonValuesFactory = mainContext.CommonValuesFactory;
            mTrueValue = mCommonValuesFactory.TrueValue();
            mFalseValue = mCommonValuesFactory.FalseValue();

            SetFrame(source, entityAction, executionContext);         
        }

        private GnuClayEngineComponentContext mMainContext = null;
        
        private CommonValuesFactory mCommonValuesFactory = null;
        
        private Stack<InternalFunctionExecutionModel> mExcutionFramesStack = new Stack<InternalFunctionExecutionModel>();
        private InternalFunctionExecutionModel mCurrentFrame = null;

        private void SetFrame(FunctionModel source, EntityAction entityAction, GnuClayThreadExecutionContext executionContext)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("SetFrame");
#endif
            mCurrentFrame = new InternalFunctionExecutionModel(source, entityAction, executionContext);
            mExcutionFramesStack.Push(mCurrentFrame);
            mCurrentFrame.CurrentCommandIsFirst();
        }

        private IValue mTrueValue = null;
        private IValue mFalseValue = null;

#if DEBUG
        public void RunDbg()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("RunDbg");
            NLog.LogManager.GetCurrentClassLogger().Info($"RunDbg ToDbgString = {mCurrentFrame.ToDbgString()}");

            while (mIsRun)
            {
                NRun();
            }
        }
#endif

        private bool mIsRun = true;

        private void Exit()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Exit mExcutionFramesStack.Count = {mExcutionFramesStack.Count}");
#endif

            mCurrentFrame.mEntityAction.State = EntityActionState.Completed;

            if (mExcutionFramesStack.Count > 1)
            {
                mExcutionFramesStack.Pop();
                mCurrentFrame = mExcutionFramesStack.Peek();
                var resultOfCalling = new ResultOfCalling();
                resultOfCalling.Success = true;
                resultOfCalling.Result = mCommonValuesFactory.UndefinedValue();

                PostProcessCall(resultOfCalling);
                return;
            }

            mIsRun = false;         
        }

        private void ExitWithError(IValue error)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ExitWithError error = {error}");
            NLog.LogManager.GetCurrentClassLogger().Info($"ExitWithError mExcutionFramesStack.Count = {mExcutionFramesStack.Count}");
#endif

            mCurrentFrame.mEntityAction.State = EntityActionState.Faulted;
            mCurrentFrame.mEntityAction.Error = error;

            if (mExcutionFramesStack.Count > 1)
            {
                mExcutionFramesStack.Pop();
                mCurrentFrame = mExcutionFramesStack.Peek();
                var resultOfCalling = new ResultOfCalling();
                resultOfCalling.Success = false;
                resultOfCalling.Error = error;

                PostProcessCall(resultOfCalling);
                return;
            }

            mIsRun = false;

        }

        private void ExitWithResult(IValue result)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ExitWithResult result = {result}");
            NLog.LogManager.GetCurrentClassLogger().Info($"ExitWithResult mExcutionFramesStack.Count = {mExcutionFramesStack.Count}");
#endif

            mCurrentFrame.mEntityAction.State = EntityActionState.Completed;
            mCurrentFrame.mEntityAction.Result = result;

            if (mExcutionFramesStack.Count > 1)
            {
                mExcutionFramesStack.Pop();
                mCurrentFrame = mExcutionFramesStack.Peek();
                var resultOfCalling = new ResultOfCalling();
                resultOfCalling.Success = true;
                resultOfCalling.Result = result;

                PostProcessCall(resultOfCalling);
                return;
            }

            mIsRun = false;
        }

        private ScriptCommand mCurrentCommand = null;

        private void NRun()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("NRun");
#endif
            mCurrentCommand = mCurrentFrame.CurrentCommand;

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

                case OperationCode.JumpIfTrue:
                    ProcessJumpIfTrue();
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
            NLog.LogManager.GetCurrentClassLogger().Info($"NRun ToDbgString = {mCurrentFrame.ToDbgString()}");
#endif
        }

        private void ProcessNop()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessNop");
#endif
            mCurrentFrame.CurrentCommandIsNext();

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
            mCurrentFrame.PushValue(value);
            mCurrentFrame.CurrentCommandIsNext();

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
            mCurrentFrame.PushValue(value);
            mCurrentFrame.CurrentCommandIsNext();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessPushEntity");
#endif
        }

        private void ProcessPushProp()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessPushProp");
#endif

            var tmpHolder = mCurrentFrame.PopValue();
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
            var tmpVar = mCurrentFrame.mExecutionContext.ContextOfVariables.GetVariable(varKey);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessPushVar tmpVar = {tmpVar}");
#endif

            mCurrentFrame.PushValue(tmpVar);
            mCurrentFrame.CurrentCommandIsNext();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessPushVar");
#endif
        }

        private void ProcessBeginCall()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessBeginCall");
#endif

            mCurrentFrame.NBeginCall();

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
            mCurrentFrame.NBeginCall();
            var functionValue = new EntityValue(mCurrentCommand.Key);
            mCurrentFrame.CurrentFunction = functionValue;
            mCurrentFrame.CurrentCommandIsNext();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessBeginCallMethod");
#endif
        }

        private void ProcessBeginCallMethodOfPrevEntity()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessBeginCallMethodOfPrevEntity");
#endif
            mCurrentFrame.NBeginCall();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessBeginCallMethodOfPrevEntity ToDbgString = {mCurrentFrame.ToDbgString()}");
#endif
            mCurrentFrame.CurrentHolder = mCurrentFrame.PopValue();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessBeginCallMethodOfPrevEntity ToDbgString = {mCurrentFrame.ToDbgString()}");
#endif
            var functionValue = new EntityValue(mCurrentCommand.Key);
            mCurrentFrame.CurrentFunction = functionValue;
            mCurrentFrame.CurrentCommandIsNext();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessBeginCallMethodOfPrevEntity");
#endif
        }

        private void ProcessSetTarget()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessSetTarget");
#endif
            var targetValue = mCurrentFrame.PopValue();
            mCurrentFrame.Target = targetValue.TypeKey;
            mCurrentFrame.CurrentCommandIsNext();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessSetTarget");
#endif
        }

        private void ProcessSetParamName()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessSetParamName");
#endif
            if (mCurrentFrame.IsCalledByNamedParameters == null)
            {
                mCurrentFrame.IsCalledByNamedParameters = true;
                mCurrentFrame.IsSetParamName = true;
            }
            else
            {
                if (!mCurrentFrame.IsCalledByNamedParameters.Value)
                {
                    throw new NotSupportedException();
                }

                if (mCurrentFrame.IsSetParamName.Value)
                {
                    throw new NotSupportedException();
                }

                mCurrentFrame.IsSetParamName = true;
            }

            var tmpVal = mCurrentFrame.PopValue();
            mCurrentFrame.CurrentParamName = tmpVal;
            mCurrentFrame.CurrentCommandIsNext();

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
            mCurrentFrame.CurrentCommandIsNext();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessSetParamVal");
#endif
        }

        private void NProcessSetParamVal()
        {
            if (mCurrentFrame.IsCalledByNamedParameters == null)
            {
                mCurrentFrame.IsCalledByNamedParameters = false;
            }
            else
            {
                if (!mCurrentFrame.IsCalledByNamedParameters.Value && mCurrentFrame.IsSetParamName.Value)
                {
                    throw new NotSupportedException();
                }
            }

            mCurrentFrame.IsSetParamName = false;
            var tmpVal = mCurrentFrame.PopValue();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"NProcessSetParamVal tmpVal = {tmpVal}");
#endif

            mCurrentFrame.CurrentParamValue = tmpVal;

            mCurrentFrame.NProcessParam();
        }

        private void NRevertPositionedParams()
        {
            mCurrentFrame.PositionedParams.Reverse();

            var n = 0;

            foreach(var param in mCurrentFrame.PositionedParams)
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
            mCurrentFrame.NBeginCall();
            NProcessSetParamVal();
            mCurrentFrame.CurrentFunction = new EntityValue(mCurrentCommand.Key);
            var resultOfCalling = mMainContext.FunctionsEngine.CallByPositionedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, mCurrentFrame.CurrentFunction, mCurrentFrame.CurrentHolder, mCurrentFrame.Target, mCurrentFrame.PositionedParams);
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
            mCurrentFrame.NBeginCall();
            NProcessSetParamVal();
            NProcessSetParamVal();
            NRevertPositionedParams();
            mCurrentFrame.CurrentFunction = new EntityValue(mCurrentCommand.Key);
            var resultOfCalling = mMainContext.FunctionsEngine.CallByPositionedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, mCurrentFrame.CurrentFunction, mCurrentFrame.CurrentHolder, mCurrentFrame.Target, mCurrentFrame.PositionedParams);
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
            var resultOfCalling = mMainContext.FunctionsEngine.CallByNamedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, mCurrentFrame.CurrentFunction, mCurrentFrame.CurrentHolder, mCurrentFrame.Target, mCurrentFrame.NamedParams);
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
            NRevertPositionedParams();
            var resultOfCalling = mMainContext.FunctionsEngine.CallByPositionedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, mCurrentFrame.CurrentFunction, mCurrentFrame.CurrentHolder, mCurrentFrame.Target, mCurrentFrame.PositionedParams);
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
            var resultOfCalling = mMainContext.FunctionsEngine.CallAsyncByNamedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, mCurrentFrame.CurrentFunction, mCurrentFrame.CurrentHolder, mCurrentFrame.Target, mCurrentFrame.NamedParams);
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
            var resultOfCalling = mMainContext.FunctionsEngine.CallAsyncByPositionedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, mCurrentFrame.CurrentFunction, mCurrentFrame.CurrentHolder, mCurrentFrame.Target, mCurrentFrame.PositionedParams);
            PostProcessCall(resultOfCalling);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessCallAsyncByPos");
#endif
        }

        private void PostProcessCall(ResultOfCalling resultOfCalling)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin PostProcessCall");
            NLog.LogManager.GetCurrentClassLogger().Info($"PostProcessCall before ToDbgString = {mCurrentFrame.ToDbgString()}");
            NLog.LogManager.GetCurrentClassLogger().Info($"PostProcessCall resultOfCalling = {resultOfCalling}");
#endif
            if (!resultOfCalling.Success)
            {
                ExitWithError(resultOfCalling.Error);
                return;
            }

            if(resultOfCalling.IsUserDefined)
            {
                var tmpEntityAction = resultOfCalling.EntityAction;
                var tmpCommand = tmpEntityAction.Command;
                SetFrame(resultOfCalling.ExecutableCode, tmpEntityAction, tmpCommand.ExecutionContext);
                
                foreach(var namedParam in tmpCommand.NamedParams)
                {
#if DEBUG
                    NLog.LogManager.GetCurrentClassLogger().Info($"PostProcessCall namedParam = {namedParam}");
#endif
                    var tmpVariable = mCurrentFrame.mExecutionContext.ContextOfVariables.GetVariable(namedParam.ParamName.TypeKey);
                    tmpVariable.ValueFromContainer = namedParam.ParamValue;
                }
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"PostProcessCall after ToDbgString = {mCurrentFrame.ToDbgString()}");
                NLog.LogManager.GetCurrentClassLogger().Info("End PostProcessCall (1)");
#endif
                return;
            }

            mCurrentFrame.PushValue(resultOfCalling.Result);
            mCurrentFrame.CurrentCommandIsNext();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"PostProcessCall after ToDbgString = {mCurrentFrame.ToDbgString()}");
            NLog.LogManager.GetCurrentClassLogger().Info("End PostProcessCall");
#endif
        }

        private void ProcessJumpIfTrue()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessJumpIfTrue");
#endif
            var tmpValue = mCurrentFrame.PopValue();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessJumpIfTrue ToDbgString = {mCurrentFrame.ToDbgString()}");
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessJumpIfTrue tmpValue = {tmpValue}");
#endif

            if (ValueHelper.NEquals(tmpValue, mTrueValue))
            {
                mCurrentFrame.CurrentCommandAtLine((int)mCurrentCommand.Key);

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info("End ProcessJumpIfTrue");
#endif
                return;
            }

            throw new NotImplementedException();
        }

        private void ProcessJumpIfFalse()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessJumpIfFalse");
#endif
            var tmpValue = mCurrentFrame.PopValue();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessJumpIfFalse ToDbgString = {mCurrentFrame.ToDbgString()}");
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessJumpIfFalse tmpValue = {tmpValue}");
#endif

            if (ValueHelper.NEquals(tmpValue, mFalseValue))
            {
                mCurrentFrame.CurrentCommandAtLine((int)mCurrentCommand.Key);

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info("End ProcessJumpIfFalse");
#endif
                return;
            }

            throw new NotImplementedException();
        }

        private void ProcessJump()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessJump");
#endif

            mCurrentFrame.CurrentCommandAtLine((int)mCurrentCommand.Key);

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
            var tmpValue = mCurrentFrame.PopValue();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessBeginCallMethodOfPrevEntity ToDbgString = {mCurrentFrame.ToDbgString()}");
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
