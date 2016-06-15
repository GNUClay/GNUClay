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

        bool ContainsKey(ulong key);

        ulong GetKey(string word);

        void AddWordToKey(string word, ulong key);
    }
}
