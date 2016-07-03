using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG
{
    public abstract class ECGResolverBaseLeaf
    {
        protected ECGResolverBaseLeaf(ECGResolverContext context)
        {
            mContext = context;
        }

        private ECGResolverContext mContext = null;

        protected ECGResolverContext Context
        {
            get
            {
                return mContext;
            }
        }

        public abstract void Run();
    }
}
