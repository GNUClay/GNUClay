using GnuClay.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.Engine.CodeExecutionSystem.Interfaces;
using GnuClay.Engine.StorageOfKnowledges.Interfaces;

namespace GnuClay.Engine.Tests.Stubs
{
    public class GnuClayEngineContextStub : IGnuClayEngineContext
    {
        public ICESystem CE { get; set; }

        public IStorage KS { get; set; }

        public void InitComponents()
        {
        }

        public void RegComponent(IGnuClayEngineComponent component)
        {
        }
    }
}
