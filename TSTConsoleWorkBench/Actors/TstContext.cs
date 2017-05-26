using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public class TstContext: IContextOfLogicalProcesses
    {
        public void AddFilter(CommandFilter filter)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddFilter filter = {filter}");

            throw new NotImplementedException();
        }

        public ulong GetKey(string val)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"GetKey val = {val}");

            throw new NotImplementedException();
        }

        public void GoToMarket()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("GoToMarket");
        }
    }
}
