﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.TimeProvider.Interfaces
{
    public interface ITimeProviderEngine
    {
        ulong Now { get; }
    }
}
