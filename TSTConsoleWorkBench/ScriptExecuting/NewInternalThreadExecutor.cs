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

            while(mIsRun)
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
                    return OperationCode.ToString();

                case OperationCode.PushConst:
                    return $"{OperationCode}: {Key} {Value}";

                case OperationCode.PushEntity:
                    return $"{OperationCode}: {Key}";

                case OperationCode.PushProp:
                    return $"{OperationCode}: {Key}";

                case OperationCode.PushVar:
                    return $"{OperationCode}: {Key}";

                case OperationCode.PushValFromProp:
                    return $"{OperationCode}: {Key}";

                case OperationCode.PushValFromVal:
                    return $"{OperationCode}: {Key}";

                case OperationCode.SetValToProp:
                    return $"{OperationCode}: {Key}";

                case OperationCode.SetValToVar:
                    return $"{OperationCode}: {Key}";

                case OperationCode.BeginCall:
                    return $"{OperationCode}";

                case OperationCode.BeginCallMethod:
                    return $"{OperationCode}: {Key}";

                case OperationCode.BeginCallMethodOfPrevEntity:
                    return $"{OperationCode}: {Key}";

                case OperationCode.SetTarget:
                    return $"{OperationCode}";

                case OperationCode.SetParamName:
                    return $"{OperationCode}";

                case OperationCode.SetParamVal:
                    return $"{OperationCode}";

                case OperationCode.CallUnOp:
                    return $"{OperationCode}: {Key}";

                case OperationCode.CallBinOp:
                    return $"{OperationCode}: {Key}";

                case OperationCode.Call:
                    return $"{OperationCode}";

                case OperationCode.CallByPos:
                    return $"{OperationCode}";

                case OperationCode.JumpIfFalse:
                    return $"{OperationCode}: {Key}";

                case OperationCode.Jump:
                    return $"{OperationCode}: {Key}";

                default: throw new ArgumentOutOfRangeException(nameof(operationCode), operationCode, null);
            }
        }

        private void ProcessNop()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessNop");

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessNop");
        }

        private void ProcessPushConst()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessPushConst");

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessPushConst");
        }

        private void ProcessPushEntity()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessPushEntity");

            throw new NotImplementedException();

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

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessBeginCall");
        }

        private void ProcessBeginCallMethod()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessBeginCallMethod");

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessBeginCallMethod");
        }

        private void ProcessBeginCallMethodOfPrevEntity()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessBeginCallMethodOfPrevEntity");

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessBeginCallMethodOfPrevEntity");
        }

        private void ProcessSetTarget()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessSetTarget");

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessSetTarget");
        }

        private void ProcessSetParamName()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessSetParamName");

            throw new NotImplementedException();

            NLog.LogManager.GetCurrentClassLogger().Info("End ProcessSetParamName");
        }

        private void ProcessSetParamVal()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessSetParamVal");

            throw new NotImplementedException();

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
