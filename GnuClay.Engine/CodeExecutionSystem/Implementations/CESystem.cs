using GnuClay.Engine.CodeExecutionSystem.Interfaces;
using GnuClay.Engine.Implementations;
using GnuClay.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CodeExecutionSystem.Implementations
{
    /// <summary>
    /// This is the execution system of code of the my simple AI engine.
    /// </summary>
    public class CESystem: GnuClayEngineComponent, ICESystem 
    {
        public CESystem(IGnuClayEngineContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }
    }
}
