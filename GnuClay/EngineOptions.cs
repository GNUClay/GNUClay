using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay
{
    /// <summary>
    /// Options of the Engine.
    /// </summary>
    public class EngineOptions
    {
        /// <summary>
        /// File name of application of the NPC.
        /// </summary>
        public string AppFileName { get; set; }

        /// <summary>
        /// Reference to instance of host.
        /// </summary>
        public IHost Host { get; set; }
    }
}
