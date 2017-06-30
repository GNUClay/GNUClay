using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewInternalThreadExecutor
    {
        public NewInternalThreadExecutor(FunctionModel source, NewGnuClayThreadExecutionContext context)
        {
            mContext = context;

            SetFunction(source);
        }

        private NewGnuClayThreadExecutionContext mContext = null;

        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");
            NLog.LogManager.GetCurrentClassLogger().Info($"Run mCurrentFunction.ToDbgString = {mCurrentFunction.ToDbgString()}");

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

        private Stack<NewInternalFunctionExecutionModel> mCallStack = new Stack<NewInternalFunctionExecutionModel>();
        private NewInternalFunctionExecutionModel mCurrentFunction = null;
        private ScriptCommand mCurrentCommand = null;

        private void SetFunction(FunctionModel function)
        {
            mCurrentFunction = new NewInternalFunctionExecutionModel(function);
            mCallStack.Push(mCurrentFunction);
            mCurrentCommand = mCurrentFunction.FirstCommand;
        }

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

            switch(operationCode)
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

            NLog.LogManager.GetCurrentClassLogger().Info($"NRun mCurrentFunction.ToDbgString = {mCurrentFunction.ToDbgString()}");
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
            mCurrentFunction.ValuesStack.Push(value);
            mCurrentCommand = mCurrentCommand.Next;

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessPushConst");
        }

        private void ProcessPushEntity()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessPushEntity");

            var value = new NewEntityValue(mCurrentCommand.Key);
            mCurrentFunction.ValuesStack.Push(value);

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

            mCurrentFunction.BeginCall();

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessBeginCall");
        }

        private void ProcessBeginCallMethod()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessBeginCallMethod");

            mCurrentFunction.BeginCall();
            mCurrentFunction.FunctionKey = mCurrentCommand.Key;
            mCurrentCommand = mCurrentCommand.Next;

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessBeginCallMethod");
        }

        private void ProcessBeginCallMethodOfPrevEntity()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessBeginCallMethodOfPrevEntity");

            mCurrentFunction.BeginCall();


            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessBeginCallMethodOfPrevEntity");
        }

        private void ProcessSetTarget()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessSetTarget");

            var targetValue = mCurrentFunction.ValuesStack.Pop();
            mCurrentFunction.Target = targetValue.TypeKey;

            mCurrentCommand = mCurrentCommand.Next;

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessSetTarget");
        }

        private void ProcessSetParamName()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessSetParamName");

            if(mCurrentFunction.IsCalledByNamedParameters == null)
            {
                mCurrentFunction.IsCalledByNamedParameters = true;
                mCurrentFunction.IsSetParamName = true;
            }
            else
            {
                if(!mCurrentFunction.IsCalledByNamedParameters.Value)
                {
                    throw new NotSupportedException();
                }

                if(mCurrentFunction.IsSetParamName.Value)
                {
                    throw new NotSupportedException();
                }

                mCurrentFunction.IsSetParamName = true;
            }

            var tmpVal = mCurrentFunction.ValuesStack.Pop();
            mCurrentFunction.CurrentParamName = tmpVal;

            mCurrentCommand = mCurrentCommand.Next;

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessSetParamName");
        }

        private void ProcessSetParamVal()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessSetParamVal");

            if (mCurrentFunction.IsCalledByNamedParameters == null)
            {
                mCurrentFunction.IsCalledByNamedParameters = false;
            }
            else
            {
                if(!mCurrentFunction.IsCalledByNamedParameters.Value && mCurrentFunction.IsSetParamName.Value)
                {
                    throw new NotSupportedException();
                }
            }

            mCurrentFunction.IsSetParamName = false;

            var tmpVal = mCurrentFunction.ValuesStack.Pop();
            mCurrentFunction.CurrentParamValue = tmpVal;

            mCurrentFunction.ProcessParam();

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

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessCall");
        }

        private void ProcessCallByPos()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessCallByPos");

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessCallByPos");
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
