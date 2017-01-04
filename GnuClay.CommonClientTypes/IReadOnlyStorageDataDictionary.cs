using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes
{
    public interface IReadOnlyStorageDataDictionary
    {
        string GetValue(ulong key);
    }
}
