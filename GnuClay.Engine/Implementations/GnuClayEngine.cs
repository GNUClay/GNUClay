using GnuClay.Engine.CGResolver.Implementations;
using GnuClay.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GnuClay.Engine.Implementations
{
    /// <summary>
    /// This is the simple AI engine.
    /// </summary>
    public class GnuClayEngine: GnuClayEngineComponent, IGnuClayEngine
    {
        public GnuClayEngine(IGnuClayEngineContext context)
            : base(context)
        {
        }

        [Obsolete("For testing only!")]
        public IGnuClayEngineContext TSTContext
        {
            get
            {
                return Context;
            }
        }

        public IGnuClayEngineInitializatorFactory InitializatorFactory { get; set; } = new DefaultGnuClayEngineInitializatorFactory();

        private object mLockObj = new object();

        private bool mIsRun = false;

        public bool IsRunning
        {
            get
            {
                lock (mLockObj)
                {
                    return mIsRun;
                }
            }
        }

        public void Run()
        {
            lock(mLockObj)
            {
                if(mIsRun)
                {
                    return;
                }

                mIsRun = true;

                var tmpInitializator = InitializatorFactory.Create(Context);

                tmpInitializator.Run();

                Context.SysActiveContext.ActivateAll();
                Context.ActiveContext.ActivateAll();
            }

            EmitOnStartRunning();

            while (mIsRun)
            {
                Thread.Sleep(500);
            }

            Context.ActiveContext.StopAll();
            Context.SysActiveContext.StopAll();

            EmitOnStopRunning();
        }

        public event Action OnStartRunning;
        public event Action OnStopRunning;

        private async void EmitOnStartRunning()
        {
            await EmitOnStartRunningTask();
        }

        private Task EmitOnStartRunningTask()
        {
            var tmpT = new Task(() =>
            {
                if(OnStartRunning != null)
                {
                    OnStartRunning();
                }
            });

            tmpT.Start();

            return tmpT;
        }

        private async void EmitOnStopRunning()
        {
            await EmitOnStopRunningTask();
        }

        private Task EmitOnStopRunningTask()
        {
            var tmpT = new Task(() =>
            {
                if (OnStopRunning != null)
                {
                    OnStopRunning();
                }
            });

            tmpT.Start();

            return tmpT;
        }

        public void Exit()
        {
            lock(mLockObj)
            {
                if(!mIsRun)
                {
                    return;
                }

                mIsRun = false;
            }
        }

        private void CheckRunning()
        {
            NLog.LogManager.GetCurrentClassLogger().Info(nameof(CheckRunning));
        }

        public ECG.ConceptualNode Query(ECG.ConceptualNode inputNode)
        {
            NLog.LogManager.GetCurrentClassLogger().Info(nameof(Query));

            CheckRunning();

            var tmpConverter = new ECGResolver(Context);

            var tmpTargetICG = tmpConverter.ConvertECGToICG(inputNode);

            throw new NotImplementedException();
        }
    }
}
