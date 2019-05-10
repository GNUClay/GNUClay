using GnuClay.CommonHelpers.JsonSerializationHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem.Internal.RuntimeSettingsSystem
{
    public class RuntimeSettingsDataTypeFactory: MapTypeFactory
    {
        public RuntimeSettingsDataTypeFactory()
            : base((name) => {
                switch (name)
                {
                    case "GnuClayUnity3DHost.BusSystem.Internal.RuntimeSettingsSystem.RuntimeSettingsData":
                        return typeof(RuntimeSettingsData);

                    default:
                        throw new ArgumentOutOfRangeException(nameof(name), name, null);
                }
            })
        {
        }
    }
}
