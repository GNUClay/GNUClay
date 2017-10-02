using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.CommonData
{
    public interface IExternalCommand: ISmartToString
    {
        IExternalValue Function { get; }
        ulong DescriptorOfFunction { get; }
        IExternalValue Holder { get; }
        ulong TargetKey { get; }
        List<IExternalParamInfo> Params { get; }
        IExternalValue GetParamValue(ulong key);
    }
}
