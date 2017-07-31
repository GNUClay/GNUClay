﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public interface IValue : ILongHashableObject
    {
        KindOfValue Kind { get; }
        ulong TypeKey { get; }
        bool IsProperty { get; }
        bool IsVariable { get; }
        bool IsValueContainer { get; }
        IValue ValueOfContainer { get; set; }
        bool IsNull { get; }
        bool IsUndefined { get; }
        bool IsNullOrUndefined { get; }

        void ExecuteSetLogicalProperty(PropertyAction action, KindOfLogicalOperator kindOfLogicalOperators);
        void ExecuteGetLogicalProperty(PropertyAction action);
    }
}
