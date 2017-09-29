using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.CommonData
{
    public interface IExternalCommandFilterParam: ILongHashableObject
    {
        bool IsAnyType { get; }
        ulong TypeKey { get; }
    }
}
