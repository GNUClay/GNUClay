using GnuClay.Engine.Implementations;
using GnuClay.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench
{
    public static class GnuClayCreator
    {
        private static IGnuClayEngine mEngine = null;

        public static IGnuClayEngine Create()
        {
            if(mEngine != null)
            {
                return mEngine;
            }

            var tmpFactory = new GnuClayEngineFactory();

            mEngine = tmpFactory.Create();

            /*mEngine.OnStartRunning += () => {
                NLog.LogManager.GetCurrentClassLogger().Info("OnStartRunning");
            };

            mEngine.OnStopRunning += () => {
                NLog.LogManager.GetCurrentClassLogger().Info("OnStopRunning");
            };*/

            var tmpThread = new Thread(NRunOnSecondThread);
            tmpThread.Start();

            while (!mEngine.IsRunning)
            { 
            }

            return mEngine;
        }

        private static void NRunOnSecondThread()
        {
            mEngine.Run();
        }
    }
}
