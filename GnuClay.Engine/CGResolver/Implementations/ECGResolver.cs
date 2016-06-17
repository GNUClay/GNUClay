using GnuClay.Engine.CGResolver.Interfaces;
using GnuClay.Engine.Implementations;
using GnuClay.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations
{
    public class ECGResolver : GnuClayEngineComponent, IECGResolver
    {
        public ECGResolver(IGnuClayEngineContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }
    }
}
