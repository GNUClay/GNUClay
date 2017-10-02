using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.CommonData
{
    public interface IExternalParamInfo: ISmartToString
    {
        IExternalValue ParamName { get; }
        IExternalValue ParamValue { get; }
    }
}
