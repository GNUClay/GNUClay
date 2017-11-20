using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.CommonData
{
    /// <summary type="i">
    /// Represents information about param of a function.
    /// </summary>
    public interface IExternalParamInfo: ISmartToString
    {
        /// <summary>
        /// Represents the name of the param.
        /// </summary>
        IExternalValue ParamName { get; }

        /// <summary>
        /// Represents the value of the param.
        /// </summary>
        IExternalValue ParamValue { get; }
    }
}
