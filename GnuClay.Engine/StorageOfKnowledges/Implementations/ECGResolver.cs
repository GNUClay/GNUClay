using GnuClay.Engine.Implementations;
using GnuClay.Engine.Interfaces;
using GnuClay.Engine.StorageOfKnowledges.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StorageOfKnowledges.Implementations
{
    public class ECGResolver: GnuClayEngineComponent, IECGResolver
    {
        public ECGResolver(IGnuClayEngineContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }
    }
}
