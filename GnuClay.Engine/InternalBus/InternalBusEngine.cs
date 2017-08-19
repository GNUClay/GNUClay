using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.InternalBus
{
    public class InternalBusEngine : BaseGnuClayEngineComponent
    {
        public InternalBusEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        public void EmitOnWriteFact()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("EmitOnWriteFact");
#endif
        }

        public void EmitOnWriteRule()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("EmitOnWriteRule");
#endif
        }

        public void EmitInvalidateCache()
        {
            OnInvalidateCache?.Invoke();
        }

        public event Action OnInvalidateCache;
    }
}
