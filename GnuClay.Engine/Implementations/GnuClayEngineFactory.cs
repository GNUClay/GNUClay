using GnuClay.Engine.CodeExecutionSystem.Implementations;
using GnuClay.Engine.GC.Implementations;
using GnuClay.Engine.Interfaces;
using GnuClay.Engine.StorageOfKnowledges.Implementations;
using GnuClay.Engine.TimeProvider.Implementations;

namespace GnuClay.Engine.Implementations
{
    public class GnuClayEngineFactory: IGnuClayEngineFactory
    {
        public IGnuClayEngine Create()
        {
            var tmpContext = new GnuClayEngineContext();

            tmpContext.CE = new CESystem(tmpContext);

            tmpContext.KS = new Storage(tmpContext);

            tmpContext.GC = new GCEngine(tmpContext);

            tmpContext.TimeProvider = new TimeProviderEngine(tmpContext);

            var tmpEngine = new GnuClayEngine(tmpContext);

            tmpContext.InitComponents();

            return tmpEngine;
        }
    }
}
