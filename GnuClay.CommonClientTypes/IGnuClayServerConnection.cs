﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes
{
    public interface IGnuClayServerConnection
    {
        IGnuClayEntityConnection ConnectToEntity(string entityName);
        IGnuClayEntityConnection CreateEntity();
        IGnuClayEntityConnection CreateEntity(byte[] data);
        void DestroyEntity(string entityName);
        bool ContainsEntity(string entityName);

        void Suspend();
        void Resume();
        bool IsRunning { get; }
        void Load();
        void Load(string name);
        void Save();
        void Save(string name);
        void Clear();
        bool IsDestroyed { get; }
        void Destroy();
    }
}
