using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.Compiler.InternalCompiler
{
    public abstract class BaseLeaf
    {
        protected BaseLeaf(GnuClayEngineComponentContext context)
        {
            Context = context;
        }

        protected GnuClayEngineComponentContext Context { get; set; }

        public List<ScriptCommand> Result
        {
            get
            {
                return mResult;
            }
        }

        private List<ScriptCommand> mResult = new List<ScriptCommand>();

        protected void AddCommand(ScriptCommand command)
        {
            mResult.Add(command);
        }

        protected void AddCommands(List<ScriptCommand> commands)
        {
            mResult.AddRange(commands);
        }

        protected ScriptCommand CreatePushEntityCommand(ulong typeKey)
        {
            var tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushEntity;
            tmpCommand.Key = typeKey;
            return tmpCommand;
        }

#if DEBUG
        public void ShowCommands()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ShowCommands Begin Commands");
            foreach(var cmd in mResult)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"ShowCommands cmd = {cmd.ToDbgString()}");
            }
            NLog.LogManager.GetCurrentClassLogger().Info("ShowCommands End Commands");
        }
#endif
    }
}
