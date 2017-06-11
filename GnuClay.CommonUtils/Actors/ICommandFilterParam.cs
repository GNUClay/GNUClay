using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonUtils.Actors
{
    public interface ICommandFilterParam
    {
        bool IsAnyType { get; set; }
        ulong TypeKey { get; set; }
        bool IsAnyValue { get; set; }
        object Value { get; set; }
    }
}
