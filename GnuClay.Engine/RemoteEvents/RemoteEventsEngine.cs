using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.RemoteEvents
{
    public class RemoteEventsEngine : BaseGnuClayEngineComponent
    {
        public RemoteEventsEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("RemoteEventsEngine");
        }

        public void Emit(RemoteEvent e)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Emit e = {e}");
        }
    }
}
