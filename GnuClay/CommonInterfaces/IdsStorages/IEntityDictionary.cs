using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.CommonInterfaces.IdsStorages
{
    public interface IEntityDictionary
    {
        string Name { get; }
        ulong GetKey(string name);
        string GetName(ulong key);
        KindOfKey GetKindOfKey(ulong key);
        bool IsEntity(ulong key);
    }
}
