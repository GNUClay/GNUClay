using GnuClay.CommonUtils.Tasking;
using GnuClay.Engine.CGResolver.Interfaces;
using GnuClay.Engine.CodeExecutionSystem.Interfaces;
using GnuClay.Engine.GC.Interfaces;
using GnuClay.Engine.StorageOfKnowledges.Interfaces;
using GnuClay.Engine.TimeProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Interfaces
{
    public interface IGnuClayEngineContext
    {
        ICESystem CE { get;}

        IStorage KS { get; }

        IGCEngine GC { get; set; }

        ITimeProviderEngine TimeProvider { get; set; }

        ActiveContext ActiveContext { get; set; }

        void RegComponent(IGnuClayEngineComponent component);

        void InitComponents();
    }
}
