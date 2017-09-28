using GnuClay.CommonClientTypes.Inheritance;
using GnuClay.CommonClientTypes.ResultTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes
{
    public interface IGnuClayEntityConnection: IReadOnlyStorageDataDictionary, IDisposable
    {
        string Name { get; }
        void Suspend();
        void Resume();
        bool IsRunning { get; }
        SelectResult Query(string text);      
        void Load(string name);
        void Load(byte[] data);
        void Save(string name);
        byte[] Save();
        void Clear();
        bool IsDestroyed { get; }
        void Destroy();

        ulong GetKey(string val);
        string GetValue(ulong key);

        void SetInheritance(ulong subKey, ulong superKey, double rank);
        List<InheritanceItem> LoadListOfSuperClasses(ulong targetKey);
        double GetInheritanceRank(ulong subKey, ulong superKey);
        List<InheritanceItem> LoadListOfSubClasses(ulong targetKey);
        List<InheritanceItem> LoadAllInheritanceItems();

        ulong AddLogHandler(Action<IExternalValue> handler);
        void RemoveLogHandler(ulong descriptor);
    }
}
