﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.InternalStorage
{
    public interface IReadOnlyStorageDataDictionary
    {
        string GetValue(int key);
        int UniqueKeysCount();
    }
}
