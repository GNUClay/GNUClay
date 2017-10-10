using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes
{
    /// <summary>
    /// Connector to GnuClay server.
    /// </summary>
    public interface IGnuClayServerConnection: IDisposable
    {
        IGnuClayEntityConnection ConnectToEntity(string entityName);
        IGnuClayEntityConnection CreateEntity();
        IGnuClayEntityConnection CreateEntity(byte[] data);
        void DestroyEntity(string entityName);
        bool ContainsEntity(string entityName);
        string[] EntitiesNames { get; }

        void Suspend();
        void Resume();
        bool IsRunning { get; }
        void Load(string name);
        void Save(string name);
        void Clear();
        bool IsDestroyed { get; 
        void Destroy();
    }
}
