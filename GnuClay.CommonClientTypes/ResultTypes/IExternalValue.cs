﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.ResultTypes
{
    public enum ExternalValueKind
    {
        Entity,
        Value
    }

    public interface IExternalValue
    {
        ExternalValueKind Kind { get; }
        ulong TypeKey { get; }
        object Value { get; }
    }
}
