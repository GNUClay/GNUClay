using GnuClay;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem.Internal.CommonScenarios
{
    public class CreateDefaultImageScenario: BaseBusOfHostScenario
    {
        public CreateDefaultImageScenario(ILog logger, CommonContextOfBusOfHosts context)
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

            var imageName = Guid.NewGuid().ToString("D");

#if DEBUG
            Debug($"imageName = {imageName}");
#endif

            Context.CurrentImageName = imageName;

            Context.RunTimeSettingsStorageComponent.SetNameOfCurrentImage(imageName);

            var imageDirectoryName = Path.Combine(Context.ImagesDir, imageName);

#if DEBUG
            Debug($"imageDirectoryName = {imageDirectoryName}");
#endif

            Directory.CreateDirectory(imageDirectoryName);

            Context.CurrentImageDir = imageDirectoryName;
        }
    }
}
