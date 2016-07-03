using GnuClay.Engine.CGResolver.Interfaces;
using GnuClay.Engine.CodeExecutionSystem.Interfaces;
using GnuClay.Engine.StorageOfKnowledges.Interfaces;
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

        void RegComponent(IGnuClayEngineComponent component);

        void InitComponents();
    }
}
