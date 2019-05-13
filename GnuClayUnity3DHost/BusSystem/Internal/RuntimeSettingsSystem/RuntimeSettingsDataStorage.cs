using GnuClay.CommonClasses;
using GnuClay.CommonClasses.Storages;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem.Internal.RuntimeSettingsSystem
{
    public class RuntimeSettingsDataStorage: BaseSimpleJsonFileStorage<RuntimeSettingsData>
    {
        public RuntimeSettingsDataStorage()
        {
        }

        /// <summary>
        /// Clears all data in the storage.
        /// </summary>
        public override void Clear()
        {
            Data = new RuntimeSettingsData();
        }
    }
}
