using GnuClay.CommonInterfaces.IdsStorages;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem.Internal.IdsStorageSystem
{
    public class IdsData
    {
        public object LockObj { get; set; } = new object();
        public string Name { get; set; }
        public Dictionary<string, ulong> CaseInsensitiveWordsDict { get; set; } = new Dictionary<string, ulong>();
        public Dictionary<ulong, string> CaseInsensitiveBackWordsDict { get; set; } = new Dictionary<ulong, string>();
        public Dictionary<ulong, KindOfKey> KindOfKeyDict { get; set; } = new Dictionary<ulong, KindOfKey>();
        public ulong CurrIndex { get; set; }
    }
}
