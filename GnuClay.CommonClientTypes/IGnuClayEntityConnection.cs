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
    }
}
