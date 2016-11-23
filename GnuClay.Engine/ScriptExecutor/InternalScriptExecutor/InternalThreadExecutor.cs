using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.InternalScriptExecutor
{
    public class InternalThreadExecutor
    {
        public InternalThreadExecutor(FunctionModel source, GnuClayThreadExecutionContext context)
        {
            mContext = context;
            SetFunction(source);
        }

        private GnuClayThreadExecutionContext mContext = null;

        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            while (mCurrentCommand != null)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"Run Item {mCurrentCommand.ToDbgString()}");
                
                switch (mCurrentCommand.OperationCode)
                {
                    case OperationCode.Nop:
                        mCurrentCommand = mCurrentCommand.Next;
                        break;

                    case OperationCode.PushConst:
                        ProsessPushConst();
                        break;

                    case OperationCode.CallBinOp:
                        ProcessCallBinOp();
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(mCurrentCommand.OperationCode), $"Unknown OperationCode `{mCurrentCommand.OperationCode}`.");
                }

                NLog.LogManager.GetCurrentClassLogger().Info(mCurrentFunction.ValueStackToDbgString());
            }
        }

        private Stack<InternalFunctionExecutionModel> mCallStack = new Stack<InternalFunctionExecutionModel>();

        private InternalFunctionExecutionModel mCurrentFunction = null;

        private ScriptCommand mCurrentCommand = null;

        private void SetFunction(FunctionModel function)
        {
            mCurrentFunction = new InternalFunctionExecutionModel(function);
            mCallStack.Push(mCurrentFunction);
            mCurrentCommand = mCurrentFunction.FirstCommand;
        }

        private void ProsessPushConst()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProsessPushConst");
            mCurrentFunction.ValuesStack.Push(mContext.MainContext.TypeProcessingContext.CreateValue(mCurrentCommand.Key, mCurrentCommand.Value));
            mCurrentCommand = mCurrentCommand.Next;
        }

        private void ProcessCallBinOp()
        {
            var op2 = mCurrentFunction.ValuesStack.Pop();

            NLog.LogManager.GetCurrentClassLogger().Info($"op2 = {op2}");

            var op1 = mCurrentFunction.ValuesStack.Pop();

            NLog.LogManager.GetCurrentClassLogger().Info($"op1 = {op1}");

            NLog.LogManager.GetCurrentClassLogger().Info(mCurrentFunction.ValueStackToDbgString());

            NLog.LogManager.GetCurrentClassLogger().Info(mCurrentFunction.ValueStackToDbgString());

            var op = mContext.MainContext.TypeProcessingContext.CallBinaryOperator(mCurrentCommand.Key, op1, op2);

            NLog.LogManager.GetCurrentClassLogger().Info($"op = {op}");

            mCurrentFunction.ValuesStack.Push(op);

            NLog.LogManager.GetCurrentClassLogger().Info(mCurrentFunction.ValueStackToDbgString());

            mCurrentCommand = mCurrentCommand.Next;
        }
    }
}
