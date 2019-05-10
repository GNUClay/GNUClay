using GnuClay;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem.Internal.CommonScenarios
{
    public abstract class BaseBusOfHostScenario: BaseScenario
    {
        protected BaseBusOfHostScenario(ILog logger, CommonContextOfBusOfHosts context)
            : base(logger)
        {
            Context = context;
        }

        protected CommonContextOfBusOfHosts Context;
    }
}
