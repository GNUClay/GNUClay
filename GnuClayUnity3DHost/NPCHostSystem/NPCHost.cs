using GnuClayUnity3DHost.NPCHostSystem.Internal;
using GnuClayUnity3DHost.BusSystem;
using GnuClayUnity3DHost.BaseHostSystem;
using System;
using System.Collections.Generic;
using System.Text;
using GnuClay;

namespace GnuClayUnity3DHost.NPCHostSystem
{
    public class NPCHost: BaseHost<CommonContextOfNPCHost>, IHostControllingRef
    {
        public NPCHost(NPCHostOptions options)
            : base(options)
        {
        }

        void IHostControllingRef.SetEngine(IEngineInternalRef engine)
        {
            Context.Engine = engine;
        }

        ILog IHostControllingRef.Logger => Context.LoggerComponent;
    }
}
