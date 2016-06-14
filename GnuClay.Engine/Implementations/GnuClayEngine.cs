using GnuClay.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Implementations
{
    /// <summary>
    /// This is the simple AI engine.
    /// </summary>
    public class GnuClayEngine: GnuClayEngineComponent, IGnuClayEngine
    {
        public GnuClayEngine(IGnuClayEngineContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }
    }
}
