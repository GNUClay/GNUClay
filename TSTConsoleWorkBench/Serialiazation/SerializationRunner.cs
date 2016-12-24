using GnuClay.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Serialiazation
{
    public class SerializationRunner
    {
        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            try
            {
                var tmpEngine = new GnuClayEngine();

                tmpEngine.Resume();
                tmpEngine.Resume();
                tmpEngine.Suspend();
                tmpEngine.Suspend();
                tmpEngine.Resume();
                tmpEngine.Resume();
            }
            catch (Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(e);
            }
        }
    }
}
