using GnuClay.CommonClientTypes.ResultTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes
{
    public interface IGnuClayEntityConnection: IReadOnlyStorageDataDictionary
    {
        void Suspend();
        void Resume();
        SelectResult Query(string text);
    }
}
