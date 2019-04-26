﻿using GnuClayUnity3DHost.HostSystem;
using GnuClayUnity3DHost.HostSystem.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BipedHostSystem.Internal
{
    public class CommonContextOfBipedHost: CommonContextOfBaseHost
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
