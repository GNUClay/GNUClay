using GnuClay.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG
{
    public class ECGResolverContext
    {
        public ECGResolverContext(IGnuClayEngineContext mainContext)
        {
            mMainContext = mainContext;
        }

        private IGnuClayEngineContext mMainContext = null;

        public IGnuClayEngineContext MainContext
        {
            get
            {
                return mMainContext;
            }
        }
    }
}
