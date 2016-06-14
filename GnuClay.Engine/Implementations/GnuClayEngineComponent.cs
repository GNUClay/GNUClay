using GnuClay.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Implementations
{
    public abstract class GnuClayEngineComponent: IGnuClayEngineComponent
    {
        protected GnuClayEngineComponent(IGnuClayEngineContext context)
        {
            mContext = context;

            mContext.RegComponent(this);
        }

        private IGnuClayEngineContext mContext = null;

        public IGnuClayEngineContext Context
        {
            get
            {
                return mContext;
            }
        }

        public virtual void Init()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Init {0}", GetType().Name);
        }
    }
}
