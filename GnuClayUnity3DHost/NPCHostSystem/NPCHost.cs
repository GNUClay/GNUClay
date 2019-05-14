using GnuClayUnity3DHost.NPCHostSystem.Internal;
using GnuClayUnity3DHost.BusSystem;
using GnuClayUnity3DHost.HostSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.NPCHostSystem
{
    public class NPCHost: BaseHost<CommonContextOfNPCHost>
    {
        public NPCHost(NPCHostOptions options)
            : base(options)
        {
        }
    }
}
