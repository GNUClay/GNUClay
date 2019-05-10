using GnuClay.CommonClasses;
using GnuClay.CommonClasses.Storages;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem.Internal.RuntimeSettingsSystem
{
    public class RuntimeSettingsDataStorage: BaseJsonFileStorage<RuntimeSettingsData>
    {
        public RuntimeSettingsDataStorage()
            : base(new RuntimeSettingsDataTypeFactory(), Constants.ImageFileVersion)
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
