using GnuClay.CommonUtils.Tasking;
using GnuClay.CommonUtils.TypeHelpers;
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
    public class InternalThreadExecutor
    {
        public InternalThreadExecutor(GnuClayEngineComponentContext mainContext, InternalThreadExecutorData data)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"constructor (2) data = {data}");
#endif

            Init(mainContext);

            mExecutionFramesStack = data.ExecutionFramesStack;
            mCurrentFrame = mExecutionFramesStack.First();
        }

        public InternalThreadExecutor(FunctionModel source, GnuClayEngineComponentContext mainContext, GnuClayThreadExecutionContext executionContext, EntityAction entityAction)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
#endif

            Init(mainContext);

            SetFrame(source, entityAction, executionContext);         
        }

        private void Init(GnuClayEngineComponentContext mainContext)
        {
            mMainContext = mainContext;
            mCommonValuesFactory = mainContext.CommonValuesFactory;
            mDataDictionary = mainContext.DataDictionary;
            mTrueValue = mCommonValuesFactory.TrueValue();
            mFalseValue = mCommonValuesFactory.FalseValue();

            mActiveObject = new ActiveObject();
            mActiveObject.Context = mMainContext.ActiveContext;
            mActiveObject.RunAction = NRun;
            mActiveObject.IsShouldAutoActivateOnBeginning = true;
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private ActiveObject mActiveObject = null;

        private CommonValuesFactory mCommonValuesFactory = null;
        private StorageDataDictionary mDataDictionary = null;

        private Stack<InternalFunctionExecutionModel> mExecutionFramesStack = new Stack<InternalFunctionExecutionModel>();
        private InternalFunctionExecutionModel mCurrentFrame = null;

        private void SetFrame(FunctionModel source, EntityAction entityAction, GnuClayThreadExecutionContext executionContext)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("SetFrame");
#endif
            mCurrentFrame = new InternalFunctionExecutionModel(source, entityAction, executionContext);
            mExecutionFramesStack.Push(mCurrentFrame);
            mCurrentFrame.CurrentCommandIsFirst();
        }

        public InternalThreadExecutorData Save()
        {
            var result = new InternalThreadExecutorData();
            result.ExecutionFramesStack = mExecutionFramesStack;
            return result;
        }

        private IValue mTrueValue = null;
        private IValue mFalseValue = null;

        public void Run()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Run");
#endif
            mActiveObject.Run();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("End Run");
#endif
        }

        private void Exit()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Exit mExcutionFramesStack.Count = {mExecutionFramesStack.Count}");
#endif

            mCurrentFrame.mEntityAction.State = EntityActionState.Completed;

            if (mExecutionFramesStack.Count > 1)
            {
                mExecutionFramesStack.Pop();
                mCurrentFrame = mExecutionFramesStack.Peek();
                var resultOfCalling = new ResultOfCalling();
                resultOfCalling.Success = true;
                resultOfCalling.Result = mCommonValuesFactory.UndefinedValue();

                PostProcessCall(resultOfCalling);
                return;
            }

            mActiveObject.Stop();     
        }

        private void ExitWithError(IValue error)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ExitWithError error = {error.ToString(mDataDictionary, 0)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"ExitWithError mExcutionFramesStack.Count = {mExecutionFramesStack.Count}");
#endif

            mCurrentFrame.mEntityAction.State = EntityActionState.Faulted;
            mCurrentFrame.mEntityAction.Error = error;

            if (mExecutionFramesStack.Count > 1)
            {
                mExecutionFramesStack.Pop();
                mCurrentFrame = mExecutionFramesStack.Peek();
                var resultOfCalling = new ResultOfCalling();
                resultOfCalling.Success = false;
                resultOfCalling.Error = error;

                PostProcessCall(resultOfCalling);
                return;
            }

            mActiveObject.Stop();
        }

        private void ExitWithResult(IValue result)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ExitWithResult result = {result.ToString(mDataDictionary, 0)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"ExitWithResult mExcutionFramesStack.Count = {mExecutionFramesStack.Count}");
#endif

            mCurrentFrame.mEntityAction.State = EntityActionState.Completed;
            mCurrentFrame.mEntityAction.Result = result;

            if (mExecutionFramesStack.Count > 1)
            {
                mExecutionFramesStack.Pop();
                mCurrentFrame = mExecutionFramesStack.Peek();
                var resultOfCalling = new ResultOfCalling();
                resultOfCalling.Success = true;
                resultOfCalling.Result = result;

                PostProcessCall(resultOfCalling);
                return;
            }

            mActiveObject.Stop();
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
            NLog.LogManager.GetCurrentClassLogger().Info($"NRun Item {mCurrentCommand.ToShortString(mDataDictionary, 0)}");
#endif
            var operationCode = mCurrentCommand.OperationCode;

            switch (operationCode)
            {
                case OperationCode.Nop:
                    ProcessNop();
                    break;

                case OperationCode.ClearStack:
                    ProcessClearStack();
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

                case OperationCode.PushSystemVar:
                    ProcessPushSystemVar();
                    break;

                case OperationCode.CallUnOp:
                    ProcessCallUnOp();
                    break;

                case OperationCode.CallBinOp:
                    ProcessCallBinOp();
                    break;

                case OperationCode.CallWTargetN:
                    ProcessCallWTargetN();
                    break;

                case OperationCode.CallWTarget:
                    ProcessCallWTarget();
                    break;

                case OperationCode.CallN:
                    ProcessCallN();
                    break;

                case OperationCode.Call:
                    ProcessCall();
                    break;

                case OperationCode.CallAsyncWTargetN:
                    ProcessCallAsyncWTargetN();
                    break;

                case OperationCode.CallAsyncWTarget:
                    ProcessCallAsyncWTarget();
                    break;

                case OperationCode.CallAsyncN:
                    ProcessCallAsyncN();
                    break;

                case OperationCode.CallAsync:
                    ProcessCallAsync();
                    break;

                case OperationCode.CallMWTargetN:
                    ProcessCallMWTargetN();
                    break;

                case OperationCode.CallMWTarget:
                    ProcessCallMWTarget();
                    break;

                case OperationCode.CallMN:
                    ProcessCallMN();
                    break;

                case OperationCode.CallM:
                    ProcessCallM();
                    break;

                case OperationCode.CallMAsyncWTargetN:
                    ProcessCallMAsyncWTargetN();
                    break;

                case OperationCode.CallMAsyncWTarget:
                    ProcessCallMAsyncWTarget();
                    break;

                case OperationCode.CallMAsyncN:
                    ProcessCallMAsyncN();
                    break;

                case OperationCode.CallMAsync:
                    ProcessCallMAsync();
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
            NLog.LogManager.GetCurrentClassLogger().Info($"NRun ToDbgString = {mCurrentFrame.ToString(mDataDictionary, 0)}");
#endif
        }

        private void ProcessNop()
        {
            mCurrentFrame.CurrentCommandIsNext();
        }

        private void ProcessClearStack()
        {
            mCurrentFrame.ClearStack();
            mCurrentFrame.CurrentCommandIsNext();
        }

        private void ProcessPushConst()
        {
            var value = mMainContext.ConstTypeProvider.CreateConstValue(mCurrentCommand.Key, mCurrentCommand.Value);
            mCurrentFrame.PushValue(value);
            mCurrentFrame.CurrentCommandIsNext();
        }

        private void ProcessPushEntity()
        {
            var value = new EntityValue(mCurrentCommand.Key);
            mCurrentFrame.PushValue(value);
            mCurrentFrame.CurrentCommandIsNext();
        }

        private void ProcessPushProp()
        {
            var tmpHolder = mCurrentFrame.PopValue();
            var propertyKey = mCurrentCommand.Key;
            var resultOfCalling = mMainContext.PropertiesEngine.FindProperty(tmpHolder, propertyKey);
            PostProcessCall(resultOfCalling);
        }

        private void ProcessPushVar()
        {
            var varKey = mCurrentCommand.Key;
            var tmpVar = mCurrentFrame.mExecutionContext.ContextOfVariables.GetVariable(varKey);

            mCurrentFrame.PushValue(tmpVar);
            mCurrentFrame.CurrentCommandIsNext();
        }

        private void ProcessPushSystemVar()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessPushSystemVar");
#endif

            var varKey = mCurrentCommand.Key;
            var tmpVar = mCurrentFrame.mExecutionContext.ContextOfSystemVariables.GetVariable(varKey);

            mCurrentFrame.PushValue(tmpVar);
            mCurrentFrame.CurrentCommandIsNext();
        }

        private void ProcessCallUnOp()
        {
            var parameters = NGetPositionedParameters(1);
            var currentFunction = new EntityValue(mCurrentCommand.Key);
            var resultOfCalling = mMainContext.FunctionsEngine.CallByPositionedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, currentFunction, null, 0, parameters);
            PostProcessCall(resultOfCalling);
        }

        private void ProcessCallBinOp()
        {
            var parameters = NGetPositionedParameters(2);
            var currentFunction = new EntityValue(mCurrentCommand.Key);
            var resultOfCalling = mMainContext.FunctionsEngine.CallByPositionedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, currentFunction, null, 0, parameters);
            PostProcessCall(resultOfCalling);
        }

        private void ProcessCallWTargetN()
        {
            var parameters = NGetNamedParameters((int)mCurrentCommand.Key);
            var target = mCurrentFrame.PopValue();
            var currentFunction = mCurrentFrame.PopValue();     
            var resultOfCalling = mMainContext.FunctionsEngine.CallByNamedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, currentFunction, null, target.TypeKey, parameters);
            PostProcessCall(resultOfCalling);
        }

        private void ProcessCallWTarget()
        {
            var parameters = NGetPositionedParameters((int)mCurrentCommand.Key);
            var target = mCurrentFrame.PopValue();
            var currentFunction = mCurrentFrame.PopValue();          
            var resultOfCalling = mMainContext.FunctionsEngine.CallByPositionedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, currentFunction, null, target.TypeKey, parameters);
            PostProcessCall(resultOfCalling);
        }

        private void ProcessCallN()
        {
            var parameters = NGetNamedParameters((int)mCurrentCommand.Key);
            var currentFunction = mCurrentFrame.PopValue();     
            var resultOfCalling = mMainContext.FunctionsEngine.CallByNamedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, currentFunction, null, 0, parameters);
            PostProcessCall(resultOfCalling);
        }

        private void ProcessCall()
        {
            var parameters = NGetPositionedParameters((int)mCurrentCommand.Key);
            var currentFunction = mCurrentFrame.PopValue();           
            var resultOfCalling = mMainContext.FunctionsEngine.CallByPositionedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, currentFunction, null, 0, parameters);
            PostProcessCall(resultOfCalling);
        }

        private void ProcessCallAsyncWTargetN()
        {
            var parameters = NGetNamedParameters((int)mCurrentCommand.Key);
            var target = mCurrentFrame.PopValue();
            var currentFunction = mCurrentFrame.PopValue();           
            var resultOfCalling = mMainContext.FunctionsEngine.CallAsyncByNamedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, currentFunction, null, target.TypeKey, parameters);
            PostProcessCall(resultOfCalling);
        }

        private void ProcessCallAsyncWTarget()
        {
            var parameters = NGetPositionedParameters((int)mCurrentCommand.Key);
            var target = mCurrentFrame.PopValue();
            var currentFunction = mCurrentFrame.PopValue();    
            var resultOfCalling = mMainContext.FunctionsEngine.CallAsyncByPositionedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, currentFunction, null, 0, parameters);
            PostProcessCall(resultOfCalling);
        }

        private void ProcessCallAsyncN()
        {
            var parameters = NGetNamedParameters((int)mCurrentCommand.Key);
            var currentFunction = mCurrentFrame.PopValue();   
            var resultOfCalling = mMainContext.FunctionsEngine.CallAsyncByNamedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, currentFunction, null, 0, parameters);
            PostProcessCall(resultOfCalling);
        }

        private void ProcessCallAsync()
        {
            var parameters = NGetPositionedParameters((int)mCurrentCommand.Key);
            var currentFunction = mCurrentFrame.PopValue();   
            var resultOfCalling = mMainContext.FunctionsEngine.CallAsyncByPositionedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, currentFunction, null, 0, parameters);
            PostProcessCall(resultOfCalling);
        }

        private void ProcessCallMWTargetN()
        {
            var parameters = NGetNamedParameters((int)mCurrentCommand.Key);
            var target = mCurrentFrame.PopValue();
            var currentFunction = mCurrentFrame.PopValue();
            var subject = mCurrentFrame.PopValue();          
            var resultOfCalling = mMainContext.FunctionsEngine.CallByNamedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, currentFunction, subject, target.TypeKey, parameters);
            PostProcessCall(resultOfCalling);
        }

        private void ProcessCallMWTarget()
        {
            var parameters = NGetPositionedParameters((int)mCurrentCommand.Key);
            var target = mCurrentFrame.PopValue();
            var currentFunction = mCurrentFrame.PopValue();
            var subject = mCurrentFrame.PopValue();
            var resultOfCalling = mMainContext.FunctionsEngine.CallByPositionedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, currentFunction, subject, target.TypeKey, parameters);
            PostProcessCall(resultOfCalling);
        }

        private void ProcessCallMN()
        {
            var parameters = NGetNamedParameters((int)mCurrentCommand.Key);
            var currentFunction = mCurrentFrame.PopValue();
            var subject = mCurrentFrame.PopValue();           
            var resultOfCalling = mMainContext.FunctionsEngine.CallByNamedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, currentFunction, subject, 0, parameters);
            PostProcessCall(resultOfCalling);
        }

        private void ProcessCallM()
        {
            var parameters = NGetPositionedParameters((int)mCurrentCommand.Key);
            var currentFunction = mCurrentFrame.PopValue();
            var subject = mCurrentFrame.PopValue();       
            var resultOfCalling = mMainContext.FunctionsEngine.CallByPositionedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, currentFunction, subject, 0, parameters);
            PostProcessCall(resultOfCalling);
        }

        private void ProcessCallMAsyncWTargetN()
        {
            var parameters = NGetNamedParameters((int)mCurrentCommand.Key);
            var target = mCurrentFrame.PopValue();
            var currentFunction = mCurrentFrame.PopValue();
            var subject = mCurrentFrame.PopValue();          
            var resultOfCalling = mMainContext.FunctionsEngine.CallAsyncByNamedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, currentFunction, subject, target.TypeKey, parameters);
            PostProcessCall(resultOfCalling);
        }

        private void ProcessCallMAsyncWTarget()
        {
            var parameters = NGetPositionedParameters((int)mCurrentCommand.Key);
            var target = mCurrentFrame.PopValue();
            var currentFunction = mCurrentFrame.PopValue();
            var subject = mCurrentFrame.PopValue();         
            var resultOfCalling = mMainContext.FunctionsEngine.CallAsyncByPositionedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, currentFunction, subject, 0, parameters);
            PostProcessCall(resultOfCalling);
        }

        private void ProcessCallMAsyncN()
        {
            var parameters = NGetNamedParameters((int)mCurrentCommand.Key);
            var currentFunction = mCurrentFrame.PopValue();
            var subject = mCurrentFrame.PopValue();          
            var resultOfCalling = mMainContext.FunctionsEngine.CallAsyncByNamedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, currentFunction, subject, 0, parameters);
            PostProcessCall(resultOfCalling);
        }

        private void ProcessCallMAsync()
        {
            var parameters = NGetPositionedParameters((int)mCurrentCommand.Key);
            var currentFunction = mCurrentFrame.PopValue();
            var subject = mCurrentFrame.PopValue();           
            var resultOfCalling = mMainContext.FunctionsEngine.CallAsyncByPositionedParameters(mCurrentFrame.mExecutionContext, mCurrentFrame.mEntityAction, currentFunction, subject, 0, parameters);
            PostProcessCall(resultOfCalling);
        }

        private List<PositionParamInfo> NGetPositionedParameters(int count)
        {
            if(count == 0)
            {
                return new List<PositionParamInfo>();
            }

            var initResult = mCurrentFrame.PopValues(count);
            initResult.Reverse();
            var result = new List<PositionParamInfo>();
            var n = 0;

            foreach (var initItem in initResult)
            {
                var item = new PositionParamInfo();
                item.ParamValue = initItem;
                item.Position = n;
                result.Add(item);
                n++;
            }

            return result;
        }

        private List<NamedParamInfo> NGetNamedParameters(int count)
        {
            if (count == 0)
            {
                return new List<NamedParamInfo>();
            }

            var initResult = mCurrentFrame.PopValues(count * 2);
            initResult.Reverse();

            var initResultEnumerator = initResult.GetEnumerator();

            var odd = true;

            NamedParamInfo item = null;

            var result = new List<NamedParamInfo>();

            while (initResultEnumerator.MoveNext())
            {
                var initItem = initResultEnumerator.Current;

                if(odd)
                {
                    item = new NamedParamInfo();
                    item.ParamName = initItem;
                    odd = false;
                }
                else
                {
                    item.ParamValue = initItem;
                    result.Add(item);
                    odd = true;
                }
            }

            return result;
        }

        private void PostProcessCall(ResultOfCalling resultOfCalling)
        {
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
                    var tmpVariable = mCurrentFrame.mExecutionContext.ContextOfVariables.GetVariable(namedParam.ParamName.TypeKey);
                    tmpVariable.ValueFromContainer = namedParam.ParamValue;
                }
                return;
            }

            mCurrentFrame.PushValue(resultOfCalling.Result);
            mCurrentFrame.CurrentCommandIsNext();
        }

        private void ProcessJumpIfTrue()
        {
            var tmpValue = mCurrentFrame.PopValue();

            if (ValueHelper.NEquals(tmpValue, mTrueValue))
            {
                mCurrentFrame.CurrentCommandAtLine((int)mCurrentCommand.Key);
                return;
            }

            throw new NotImplementedException();
        }

        private void ProcessJumpIfFalse()
        {
            var tmpValue = mCurrentFrame.PopValue();
            if (ValueHelper.NEquals(tmpValue, mFalseValue))
            {
                mCurrentFrame.CurrentCommandAtLine((int)mCurrentCommand.Key);
                return;
            }

            throw new NotImplementedException();
        }

        private void ProcessJump()
        {
            mCurrentFrame.CurrentCommandAtLine((int)mCurrentCommand.Key);
        }

        private void ProcessReturn()
        {
            Exit();
        }

        private void ProcessReturnValue()
        {
            var tmpValue = mCurrentFrame.PopValue();          
            if(tmpValue.IsValueContainer)
            {
                tmpValue = tmpValue.ValueFromContainer;
            }

            ExitWithResult(tmpValue);
        }
    }
}
