using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage
{
    public abstract class BaseLogicalStorageComponent
    {
        protected BaseLogicalStorageComponent(GnuClayEngineComponentContext context, LogicalStorageContext logicalContext)
        {
            Context = context;
            LogicalContext = logicalContext;
        }

        protected GnuClayEngineComponentContext Context = null;
        protected LogicalStorageContext LogicalContext = null;

        public virtual void FirstInit()
        {
        }

        public virtual void SecondInit()
        {
        }
    }
}
