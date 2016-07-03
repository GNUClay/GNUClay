using GnuClay.Engine.CGResolver.Implementations;
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

        public IGnuClayEngineInitializatorFactory InitializatorFactory { get; set; } = new DefaultGnuClayEngineInitializatorFactory();

        public ECG.ConceptualNode Query(ECG.ConceptualNode inputNode)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Query");

            var tmpConverter = new ECGResolver(Context);

            var tmpTargetICG = tmpConverter.ConvertECGToICG(inputNode);

            throw new NotImplementedException();
        }
    }
}
