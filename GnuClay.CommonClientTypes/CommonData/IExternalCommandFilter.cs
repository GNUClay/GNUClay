using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.CommonData
{
    public delegate void ExternalCommandHandler(IExternalEntityAction action);

    public interface IExternalCommandFilter: ILongHashableObject, ISmartToString
    {
        ulong FunctionKey { get; }
        ulong TargetKey { get; }
        ulong HolderKey { get; }
        Dictionary<ulong, IExternalCommandFilterParam> Params { get; }
        ExternalCommandHandler Handler { get; }
    }
}
