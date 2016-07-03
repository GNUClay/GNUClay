using GnuClay.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Implementations
{
    public abstract class BaseGnuClayEngineInitializator: IGnuClayEngineInitializator
    {
        protected BaseGnuClayEngineInitializator(IGnuClayEngineContext context)
        {
            mContext = context;
        }

        private IGnuClayEngineContext mContext = null;

        protected IGnuClayEngineContext Context
        {
            get
            {
                return mContext;
            }
        }

        public abstract void Run();
    }
}
