using GnuClay.CommonClasses.FileStorages;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem.Internal.IdsStorageSystem
{
    public class IdsDataStorage: BaseSimpleJsonFileStorage<IdsData>
    {
        // TODO: fix me!
        public override void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
