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
                NLog.LogManager.GetCurrentClassLogger().Info(mCurrentFunction.ValueStackToDbgString());

                switch (mCurrentCommand.OperationCode)
                {
                    case OperationCode.Nop:
                        mCurrentCommand = mCurrentCommand.Next;
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(mCurrentCommand.OperationCode), $"Unknown OperationCode `{mCurrentCommand.OperationCode}`.");
                }
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
    }
}
