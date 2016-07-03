using GnuClay.Engine.CGResolver.Implementations;
using GnuClay.Engine.CodeExecutionSystem.Implementations;
using GnuClay.Engine.Interfaces;
using GnuClay.Engine.StorageOfKnowledges.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Implementations
{
    public class GnuClayEngineFactory: IGnuClayEngineFactory
    {
        public IGnuClayEngine Create()
        {
            var tmpContext = new GnuClayEngineContext();

            tmpContext.CE = new CESystem(tmpContext);

            tmpContext.KS = new Storage(tmpContext);

            var tmpEngine = new GnuClayEngine(tmpContext);

            tmpContext.InitComponents();

            return tmpEngine;
        }
    }
}
