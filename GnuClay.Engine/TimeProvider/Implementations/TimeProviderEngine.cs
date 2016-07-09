using GnuClay.CommonUtils.Tasking;
using GnuClay.Engine.Implementations;
using GnuClay.Engine.Interfaces;
using GnuClay.Engine.TimeProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.TimeProvider.Implementations
{
    public class TimeProviderEngine: GnuClayEngineComponent, ITimeProviderEngine
    {
        public TimeProviderEngine(IGnuClayEngineContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }

        private ActiveObject mActiveObject = null;

        private object mLockObj = new object();

        public ulong Now
        {
            get
            {
                lock(mLockObj)
                {
                    return mCurrTicks;
                }
            }
        }

        public override void Init()
        {
            mActiveObject = new ActiveObject();

            mActiveObject.Context = Context.ActiveContext;

            mActiveObject.RunAction = NRun;
        }

        private ulong mCurrTicks = 0;

        private void NRun()
        {
            lock (mLockObj)
            {
                mCurrTicks++;
            }
        }
    }
}
