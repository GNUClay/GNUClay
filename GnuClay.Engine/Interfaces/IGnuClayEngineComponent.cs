﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Interfaces
{
    public interface IGnuClayEngineComponent
    {
        IGnuClayEngineContext Context { get; }

        void Init();
    }
}
