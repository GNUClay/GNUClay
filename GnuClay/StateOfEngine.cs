using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay
{
    public enum StateOfEngine
    {
        Created,
        Compiling,
        Compiled,
        Loading,
        Loaded,
        Starting,
        Started,
        Stopping,
        Stopped,
        Destroyed
    }
}
