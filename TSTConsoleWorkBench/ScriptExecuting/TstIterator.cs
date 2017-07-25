using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class TstIterator: BaseSystemType
    {
        public TstIterator(ulong typeKey)
            : base(typeKey)
        {
        }

        public override ulong GetLongHashCode()
        {
            throw new NotImplementedException();
        }

        private int a = 0;

        public void GetCurrentValue(PropertyAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin GetCurrentValue action = {action}");

            NLog.LogManager.GetCurrentClassLogger().Info($"Begin GetCurrentValue a = {a}");

            action.Result = new EntityValue(29);

            NLog.LogManager.GetCurrentClassLogger().Info($"End GetCurrentValue action = {action}");
        }

        public void SetCurrentValue(PropertyAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin SetCurrentValue action = {action}");

            NLog.LogManager.GetCurrentClassLogger().Info($"Begin GetCurrentValue a = {a}");

            a = 15;

            NLog.LogManager.GetCurrentClassLogger().Info($"End SetCurrentValue action = {action}");
        }
    }
}
