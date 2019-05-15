﻿using GnuClayUnity3DHost.BusSystem;
using GnuClayUnity3DHost.BaseHostSystem;
using GnuClayUnity3DHost.PassiveObjectHostSystem.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.PassiveObjectHostSystem
{
    public class PassiveObjectHost : BaseHost<CommonContextOfPassiveObjectHost>
    {
        public PassiveObjectHost(PassiveObjectHostOptions options)
            : base(options)
        {
        }
    }
}
