﻿using GnuClay.Engine.StandardLibrary.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public interface ITypeProvider: IValueFactory
    {
        string TypeName { get; }
        ulong TypeKey { get; }
    }
}
