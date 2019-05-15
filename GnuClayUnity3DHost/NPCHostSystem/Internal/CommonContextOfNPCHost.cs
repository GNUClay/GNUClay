using GnuClayUnity3DHost.BaseHostSystem;
using GnuClayUnity3DHost.BaseHostSystem.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.NPCHostSystem.Internal
{
    public class CommonContextOfNPCHost: CommonContextOfBaseHost
    {
        /// <summary>
        ///  Dispose this instance.
        /// </summary>
        /// <param name="disposing">Is the instance released not in finalizer.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
