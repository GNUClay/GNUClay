﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.CommonData
{
    public interface IExternalEntityAction : ISmartToString
    {
        ulong Key { get; }
        IExternalCommand Command { get; }
        ulong Initiator { get; }
    }
}
