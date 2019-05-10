using GnuClay;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem.Internal.CommonScenarios
{
    public class StartScenario: BaseBusOfHostScenario
    {
        public StartScenario(ILog logger, CommonContextOfBusOfHosts context)
            : base(logger, context)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public void Execute(ref StateOfEngine state, object stateLockObj)
        {
#if DEBUG
            Debug($"state = {state}");
#endif

            var nameOfCurrentImage = Context.RunTimeSettingsStorageComponent.GetNameOfCurrentImage();

#if DEBUG
            Debug($"nameOfCurrentImage = {nameOfCurrentImage}");
#endif

            if(string.IsNullOrWhiteSpace(nameOfCurrentImage))
            {
                var createDefaultImageScenario = new CreateDefaultImageScenario(Logger, Context);
                createDefaultImageScenario.Execute(ref state, stateLockObj);
            }
        }
    }
}
