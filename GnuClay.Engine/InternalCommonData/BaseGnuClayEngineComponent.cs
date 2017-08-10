using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.InternalCommonData
{
    public abstract class BaseGnuClayEngineComponent
    {
        protected BaseGnuClayEngineComponent(GnuClayEngineComponentContext context)
        {
            Context = context;
        }

        protected GnuClayEngineComponentContext Context = null;

        public virtual void FirstInit()
        {
        }

        public virtual void SecondInit()
        {
        }
    }
}
