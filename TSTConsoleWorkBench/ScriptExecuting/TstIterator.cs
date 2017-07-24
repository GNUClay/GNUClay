using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.ScriptExecutor.CommonData;
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

        public void GetCurrentValue(PropertyAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"GetCurrentValue action = {action}");

            throw new NotImplementedException();
        }

        public void SetCurrentValue(PropertyAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"SetCurrentValue action = {action}");

            throw new NotImplementedException();
        }
    }
}
