using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StorageOfKnowledges.Interfaces
{
    public interface IObjectsRegistry
    {
        ulong AddWord(string word);

        ulong AddWord(string word, ulong targetKey, byte targetGeneration);

        bool ContainsKey(ulong key);

        ulong GetKey(string word);

        void AddWordToExistsKey(string word, ulong key);
    }
}
